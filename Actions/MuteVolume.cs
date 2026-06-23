using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 音量静音动作：模拟按下系统静音快捷键切换当前播放设备的静音状态
/// </summary>
public class MuteVolumeAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionMuteVolume;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionMuteVolumeDescription;

    /// <summary>
    /// 动作触发：模拟按下 VOLUME_MUTE 虚拟键切换系统静音状态
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);
    }
}
