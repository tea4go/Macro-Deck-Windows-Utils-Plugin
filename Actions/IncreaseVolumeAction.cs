using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 提高音量动作：模拟按下系统音量增大快捷键将当前播放设备音量提高一档
/// </summary>
public class IncreaseVolumeAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionIncreaseVolume;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionIncreaseVolumeDescription;

    /// <summary>
    /// 动作触发：模拟按下 VOLUME_UP 虚拟键以提高系统音量
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP);
    }
}
