using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using SuchByte.MacroDeck.ActionButton;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using SuchByte.MacroDeck.Logging;
namespace SuchByte.WindowsUtils.Actions;

public class PowerOptionAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionPowerOption;

    public override string Description => PluginLanguageManager.PluginStrings.ActionPowerOptionDescription;

    public override bool CanConfigure => true;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                PowerOptions powerOption = Enum.Parse<PowerOptions>(configurationObject["powerOption"].ToString());

                switch (powerOption)
                {
                    case PowerOptions.Sleep:
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                        return;
                    case PowerOptions.Hibernate:
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                        return;
                    case PowerOptions.Shutdown:
                        Process.Start("shutdown", "/s /t 0");
                        return;
                    case PowerOptions.Restart:
                        Process.Start("shutdown", "/r /t 0");
                        return;
                    default:
                        MacroDeckLogger.Error(Main.Instance, "Invalid power option specified.");
                        return;
                }
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance, e.Message);
            }
        }
    }

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new PowerOptionSelector(this);
    }
}
