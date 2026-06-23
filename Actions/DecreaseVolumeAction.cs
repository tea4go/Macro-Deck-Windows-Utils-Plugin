using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 降低音量动作：模拟按下系统音量减小快捷键将当前播放设备音量降低一档
/// </summary>
public class DecreaseVolumeAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionDecreaseVolume;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionDecreaseVolumeDescription;

    /// <summary>
    /// 动作触发：模拟按下 VOLUME_DOWN 虚拟键以降低系统音量
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_DOWN);
    }
}
