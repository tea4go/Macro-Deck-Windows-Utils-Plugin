using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System.Runtime.InteropServices;
using System;

namespace SuchByte.WindowsUtils.Actions;

public class MuteMicrophoneAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionMuteMicrophone;

    public override string Description => PluginLanguageManager.PluginStrings.ActionMuteMicrophoneDescription;

    private const int WM_APPCOMMAND = 0x319;

    private const int APPCOMMAND_MICROPHONE_VOLUME_MUTE = 0x180000;

    [DllImport("user32.dll", SetLastError = false)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = false)]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        try
        {
            IntPtr h = GetForegroundWindow();
            SendMessageW(h, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MICROPHONE_VOLUME_MUTE);
        }
        catch { }
    }
}
