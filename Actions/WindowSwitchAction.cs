using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using static SuchByte.WindowsUtils.Utils.WindowActivator;

namespace SuchByte.WindowsUtils.Actions;

public class WindowSwitchAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionWindowSwitch;

    public override string Description => PluginLanguageManager.PluginStrings.ActionWindowSwitchDescription;

    public override bool CanConfigure => true;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        MacroDeckLogger.Info(Main.Instance, $"WindowSwitchAction triggered. hasConfiguration={!string.IsNullOrWhiteSpace(this.Configuration)}");
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                var configurationObject = JObject.Parse(this.Configuration);
                string pattern = configurationObject["pattern"].ToString();
                MatchMode matchMode = Enum.Parse<MatchMode>(configurationObject["matchMode"].ToString());
                bool caseSensitive = configurationObject["caseSensitive"].ToObject<bool>();
                MacroDeckLogger.Info(Main.Instance, $"WindowSwitchAction parsed configuration. pattern='{pattern}', matchMode={matchMode}, caseSensitive={caseSensitive}");

                bool activated = ActivateWindowByTitle(pattern, matchMode, caseSensitive);
                MacroDeckLogger.Info(Main.Instance, $"WindowSwitchAction completed. activated={activated}");
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance, $"WindowSwitchAction failed: {e.Message}{Environment.NewLine}{e.StackTrace}");
            }
        }
    }

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new WindowSwitchConfigurator(this);
    }
}
