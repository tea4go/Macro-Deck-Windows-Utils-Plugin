using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Logging;
using SuchByte.WindowsUtils.Language;
using System.Runtime.InteropServices;
using System;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 麦克风静音动作：通过向当前前景窗口发送 WM_APPCOMMAND 消息来切换麦克风静音状态
/// </summary>
public class MuteMicrophoneAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionMuteMicrophone;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionMuteMicrophoneDescription;

    /// <summary>Windows 消息常量：应用程序命令消息类型</summary>
    private const int WM_APPCOMMAND = 0x319;

    /// <summary>APPCOMMAND 常量：麦克风音量静音操作</summary>
    private const int APPCOMMAND_MICROPHONE_VOLUME_MUTE = 0x180000;

    /// <summary>获取当前前景窗口的句柄</summary>
    [DllImport("user32.dll", SetLastError = false)]
    public static extern IntPtr GetForegroundWindow();

    /// <summary>向指定窗口发送消息</summary>
    [DllImport("user32.dll", SetLastError = false)]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// 动作触发：向当前前景窗口发送 WM_APPCOMMAND + MICROPHONE_VOLUME_MUTE
    /// 这个方式依赖系统和应用程序对此消息的支持，不同应用程序行为可能有差异
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        try
        {
            MacroDeckLogger.Information(Main.Instance, "MuteMicrophoneAction triggered");
            // 获取当前前景窗口句柄，麦克风命令需要发送到活跃窗口
            IntPtr h = GetForegroundWindow();
            // 发送麦克风静音命令：lParam 的高字包含 APPCOMMAND 值
            IntPtr result = SendMessageW(h, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MICROPHONE_VOLUME_MUTE);
            MacroDeckLogger.Information(Main.Instance, $"MuteMicrophoneAction completed. foregroundWindow={h}, result={result}");
        }
        catch (Exception e)
        {
            MacroDeckLogger.Error(Main.Instance, $"MuteMicrophoneAction failed: {e.Message}{Environment.NewLine}{e.StackTrace}", Array.Empty<object>());
        }
    }
}
