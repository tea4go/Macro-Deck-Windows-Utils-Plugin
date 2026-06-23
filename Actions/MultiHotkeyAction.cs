using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Models;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 多热键序列动作：按序执行多个热键或延迟操作，支持同步按键状态。
/// 当已有序列在执行时再次触发，会终止当前序列并等待下次触发
/// （注：该动作目前已注释，暂未启用）
/// </summary>
public class MultiHotkeyAction : PluginAction
{
    /// <summary>动作名称</summary>
    public override string Name => "MultiHotkeyAction";

    /// <summary>动作描述</summary>
    public override string Description => "";

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>标识当前序列是否应被中断</summary>
    private bool stop = false;

    /// <summary>标识序列是否正在执行，防止并发执行</summary>
    private bool executing = false;

    /// <summary>
    /// 动作触发：异步执行序列中的每个动作步骤
    /// 若序列正在执行且未被停止，则设置停止标识中断当前序列
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        var configModel = MultiHotkeyActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null) return;
        // 如果序列正在执行且未被停止，则设置 stop 标识请求中断当前序列
        if (executing == !stop)
        {
            stop = true;
        }
        Task.Run(() =>
        {
            // 如果配置了同步按键状态，执行前将按键状态设为按下
            if (configModel.SyncButtonState) this.ActionButton.State = true;
            executing = true;
            foreach (var multiHotkeyAction in configModel.MultiHotkeyActions)
            {
                // 检查是否收到中断请求，若是则重置 stop 并退出序列
                if (stop)
                {
                    stop = false;
                    break;
                }
                multiHotkeyAction.Execute();
            }
            executing = false;
            // 序列执行完成同步按键状态为未按下
            if (configModel.SyncButtonState) this.ActionButton.State = false;
        });

    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new StartApplicationActionConfigView(this);
    }


}
