using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;
using SuchByte.WindowsUtils.Services;
using System.Threading.Tasks;
using SuchByte.MacroDeck.Logging;

namespace SuchByte.WindowsUtils.Actions;

public class StartApplicationAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionStartApplication;

    public override string Description => PluginLanguageManager.PluginStrings.ActionStartApplicationDescription;

    public override bool CanConfigure => true;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null) return;

        switch (configModel.StartMethod)
        {
            // 启动进程
            case StartMethod.Start:
                if (!ApplicationLauncher.IsRunning(configModel.Path))
                {
                    ApplicationLauncher.StartApplication(configModel.Path, configModel.Arguments, configModel.RunAsAdmin);
                }
                else
                {
                    ApplicationLauncher.BringToForeground(configModel.Path);
                }
                break;
            case StartMethod.Stop:
                ApplicationLauncher.KillApplication(configModel.Path);
                break;
            case StartMethod.Show:
                ApplicationLauncher.BringToForeground(configModel.Path);
                break;
            case StartMethod.Hide:
                ApplicationLauncher.BringToBackground(configModel.Path);
                break;
        }
    }

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new StartApplicationActionConfigView(this);
    }

    public override void OnActionButtonLoaded()
    {
        var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null || !configModel.SyncButtonState) return;

        Main.Instance.TickTimer.Elapsed += StateUpdateTimer_Elapsed;
    }

    public override void OnActionButtonDelete()
    {
        Main.Instance.TickTimer.Elapsed -= StateUpdateTimer_Elapsed;
    }


    private void StateUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Task.Run(UpdateState);
    }

    private void UpdateState()
    {
        if (this.ActionButton == null) return;
        var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null || !configModel.SyncButtonState || string.IsNullOrWhiteSpace(configModel.Path)) return;
        this.ActionButton.State = ApplicationLauncher.IsRunning(configModel.Path);
    }
}
