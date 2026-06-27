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

/// <summary>
/// 电源选项动作：执行睡眠、休眠、关机或重启等系统电源操作
/// </summary>
public class PowerOptionAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionPowerOption;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionPowerOptionDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置中的电源选项并执行对应的系统命令
    /// 睡眠/休眠使用 Windows Forms API，关机/重启通过 shutdown 命令实现
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        MacroDeckLogger.Information(Main.Instance, $"PowerOptionAction triggered. hasConfiguration={!string.IsNullOrWhiteSpace(this.Configuration)}");
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                PowerOptions powerOption = Enum.Parse<PowerOptions>(configurationObject["powerOption"].ToString());
                MacroDeckLogger.Information(Main.Instance, $"PowerOptionAction parsed configuration. powerOption={powerOption}");

                switch (powerOption)
                {
                    case PowerOptions.Sleep:
                        MacroDeckLogger.Information(Main.Instance, "PowerOptionAction executing Sleep");
                        // Suspend=睡眠，forceFlag=true 表示强制进入电源管理状态
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                        return;
                    case PowerOptions.Hibernate:
                        MacroDeckLogger.Information(Main.Instance, "PowerOptionAction executing Hibernate");
                        // Hibernate=休眠，将内存保存到磁盘并断电
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                        return;
                    case PowerOptions.Shutdown:
                        MacroDeckLogger.Information(Main.Instance, "PowerOptionAction executing Shutdown");
                        // /s=关机 /t 0=延迟 0 秒立即执行
                        Process.Start("shutdown", "/s /t 0");
                        return;
                    case PowerOptions.Restart:
                        MacroDeckLogger.Information(Main.Instance, "PowerOptionAction executing Restart");
                        // /r=重启 /t 0=延迟 0 秒立即执行
                        Process.Start("shutdown", "/r /t 0");
                        return;
                    default:
                        MacroDeckLogger.Error(Main.Instance, $"Invalid power option specified: {powerOption}", Array.Empty<object>());
                        return;
                }
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance, $"PowerOptionAction failed: {e.Message}{Environment.NewLine}{e.StackTrace}", Array.Empty<object>());
            }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new PowerOptionSelector(this);
    }
}
