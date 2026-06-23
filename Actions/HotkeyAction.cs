using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Threading;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 单一热键动作：模拟按下由修饰键（Ctrl/Alt/Shift/Win）+ 主键组合的系统快捷键
/// 为兼容部分应用程序，采用 KeyDown + 延迟 + KeyUp 的方式而非一次性的 ModifiedKeyStroke
/// </summary>
public class HotkeyAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionHotkey;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionHotkeyDescription;

    /// <summary>该动作支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new HotkeyConfigurator(this, actionConfigurator);
    }

    /// <summary>
    /// 动作触发：解析配置中的修饰键组合并依次将它们按下和松开
    /// 使用 KeyDown + Sleep(100ms) + KeyUp 方式确保部分应用程序能正确识别快捷键信号
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        try
        {
            if (this.Configuration != null && this.Configuration.Length > 0)
            {
                JObject jObject = JObject.Parse(this.Configuration);
                if (jObject != null)
                {
                    // 收集配置中勾选的所有修饰键到列表，按展开顺序添加
                    List<VirtualKeyCode> modifierKeys = new List<VirtualKeyCode>();
                    VirtualKeyCode virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), jObject["key"].ToString());

                    if (bool.Parse(jObject["lwin"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.LWIN);
                    }
                    if (bool.Parse(jObject["rwin"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.RWIN);
                    }

                    if (bool.Parse(jObject["ctrl"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.CONTROL);
                    }
                    if (bool.Parse(jObject["lctrl"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.LCONTROL);
                    }
                    if (bool.Parse(jObject["rctrl"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.RCONTROL);
                    }

                    if (bool.Parse(jObject["shift"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.SHIFT);
                    }
                    if (bool.Parse(jObject["lshift"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.LSHIFT);
                    }
                    if (bool.Parse(jObject["rshift"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.RSHIFT);
                    }

                    if (bool.Parse(jObject["alt"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.MENU);
                    }
                    if (bool.Parse(jObject["lalt"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.LMENU);
                    }
                    if (bool.Parse(jObject["ralt"].ToString()))
                    {
                        modifierKeys.Add(VirtualKeyCode.RMENU);
                    }

                    // 采用 KeyDown+KeyUp+延迟的方式模拟按键，而非一次性的 ModifiedKeyStroke
                    // 原因：H.InputSimulator 的 ModifiedKeyStroke 速度太快，部分应用无法识别

                    // 先按下所有修饰键
                    foreach (VirtualKeyCode modifierKey in modifierKeys)
                    {
                        PluginInstance.Main.InputSimulator.Keyboard.KeyDown(modifierKey);
                    }

                    // 再按下主键
                    PluginInstance.Main.InputSimulator.Keyboard.KeyDown(virtualKeyCode);

                    // 延迟 100ms，确保应用程序有足够时间响应按下状态
                    Thread.Sleep(100);

                    // 松开主键
                    PluginInstance.Main.InputSimulator.Keyboard.KeyUp(virtualKeyCode);

                    // 按逆序松开修饰键
                    foreach (VirtualKeyCode modifierKey in modifierKeys)
                    {
                        PluginInstance.Main.InputSimulator.Keyboard.KeyUp(modifierKey);
                    }

                }
            }
        }
        catch { }
    }
}
