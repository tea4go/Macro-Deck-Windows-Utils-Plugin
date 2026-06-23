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

/// <summary>
/// 启动应用程序动作：支持启动、停止、显示和隐藏应用程序，并支持将按键状态与进程运行状态同步
/// </summary>
public class StartApplicationAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionStartApplication;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionStartApplicationDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：根据配置中的启动方式执行对应操作
    /// - Start：若进程未运行则启动，已运行则将其带到前台
    /// - Stop：结束指定进程
    /// - Show：将应用程序窗口带到前台
    /// - Hide：将应用程序窗口最小化到后台
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        try
        {
            var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
            if (configModel == null)
            {
                MacroDeckLogger.Warning(Main.Instance, "StartApplicationAction triggered but configuration is null");
                return;
            }

            MacroDeckLogger.Info(Main.Instance, $"StartApplicationAction triggered. method={configModel.StartMethod}, path='{configModel.Path}'");

            switch (configModel.StartMethod)
            {
                // 启动进程
                case StartMethod.Start:
                    // 若未运行则启动，若已运行则将其带到前台
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

            MacroDeckLogger.Info(Main.Instance, $"StartApplicationAction completed. method={configModel.StartMethod}");
        }
        catch (System.Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"StartApplicationAction failed: {ex.Message}{System.Environment.NewLine}{ex.StackTrace}");
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new StartApplicationActionConfigView(this);
    }

    /// <summary>
    /// 按键加载时触发：若配置了同步按键状态，则注册定时检查进程运行状态的事件处理器
    /// </summary>
    public override void OnActionButtonLoaded()
    {
        var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null || !configModel.SyncButtonState) return;

        Main.Instance.TickTimer.Elapsed += StateUpdateTimer_Elapsed;
    }

    /// <summary>
    /// 按键删除时触发：取消注册定时器事件，防止内存泄漏
    /// </summary>
    public override void OnActionButtonDelete()
    {
        Main.Instance.TickTimer.Elapsed -= StateUpdateTimer_Elapsed;
    }

    /// <summary>
    /// 定时器触发时的回调：将状态更新任务提交到线程池异步执行
    /// </summary>
    private void StateUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Task.Run(UpdateState);
    }

    /// <summary>
    /// 定期更新按键状态：检查关联的应用程序是否在运行，并同步到按键状态
    /// </summary>
    private void UpdateState()
    {
        if (this.ActionButton == null) return;
        var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
        // 配置为空、未开启同步或路径为空时跳过
        if (configModel == null || !configModel.SyncButtonState || string.IsNullOrWhiteSpace(configModel.Path)) return;
        this.ActionButton.State = ApplicationLauncher.IsRunning(configModel.Path);
    }
}
