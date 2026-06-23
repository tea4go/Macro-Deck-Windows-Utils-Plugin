using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.WindowsUtils.Actions;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsInput;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 热键配置界面：用于选择修饰键组合（Ctrl/Alt/Shift/Win）和主键
/// </summary>
public partial class HotkeyConfigurator : ActionConfigControl
{
    /// <summary>当前正在配置的热键动作实例</summary>
    HotkeyAction pluginAction;

    /// <summary>
    /// 构造函数：初始化界面并加载已有配置
    /// </summary>
    public HotkeyConfigurator(HotkeyAction pluginAction, ActionConfigurator actionConfigurator)
    {
        this.pluginAction = pluginAction;
        InitializeComponent();

        this.LoadConfig();
    }

    /// <summary>
    /// 保存配置：将所有修饰键勾选状态和主键序列化为 JSON
    /// 配置摘要显示所有已选修饰键 + 主键的组合文本
    /// </summary>
    public override bool OnActionSave()
    {
        // 将所有修饰键勾选状态序列化为 JSON 字符串（存为字符串 "True"/"False")
        JObject jObject = new JObject
        {
            ["lwin"] = checkLWin.Checked.ToString(),
            ["rwin"] = checkRWin.Checked.ToString(),
            ["ctrl"] = checkCtrl.Checked.ToString(),
            ["lctrl"] = checkLCtrl.Checked.ToString(),
            ["rctrl"] = checkRCtrl.Checked.ToString(),
            ["shift"] = checkShift.Checked.ToString(),
            ["lshift"] = checkLShift.Checked.ToString(),
            ["rshift"] = checkRShift.Checked.ToString(),
            ["alt"] = checkAlt.Checked.ToString(),
            ["lalt"] = checkLAlt.Checked.ToString(),
            ["ralt"] = checkRAlt.Checked.ToString(),
            ["key"] = this.key.Text.ToString()
        };
        // 只有在主键不为空时才保存配置
        if (this.key.Text.Length > 0)
        {
            this.pluginAction.Configuration = jObject.ToString();
        }
        // 构建配置摘要字符串：已勾选的修饰键 + 主键
        this.pluginAction.ConfigurationSummary =
            (checkLWin.Checked ? "lwin + " : "") + (checkRWin.Checked ? "rwin + " : "") +
            (checkLCtrl.Checked ? "lctrl + " : "") + (checkRCtrl.Checked ? "rctrl + " : "") + (checkCtrl.Checked ? "ctrl + " : "") +
            (checkLShift.Checked ? "lshift + " : "") + (checkRShift.Checked ? "rshift + " : "") + (checkShift.Checked ? "shift + " : "") +
            (checkLAlt.Checked ? "lalt + " : "") + (checkRAlt.Checked ? "ralt + " : "") + (checkAlt.Checked ? "alt + " : "") +
            key.Text;

        return true;
    }

    /// <summary>
    /// 加载已有配置：加载所有 VirtualKeyCode 到主键下拉框，并还原修饰键状态
    /// </summary>
    private void LoadConfig()
    {
        // 将所有 VirtualKeyCode 枚举小加载到主键下拉框
        foreach (VirtualKeyCode keyCode in (VirtualKeyCode[])Enum.GetValues(typeof(VirtualKeyCode)))
        {
            this.key.Items.Add(keyCode);
        }
        if (this.pluginAction.Configuration != null && this.pluginAction.Configuration.Length > 0)
        {
            JObject jObject = JObject.Parse(this.pluginAction.Configuration);
            if (jObject != null)
            {
                // 还原所有修饰键的勾选状态
                this.checkLWin.Checked = Boolean.Parse(jObject["lwin"].ToString());
                this.checkRWin.Checked = Boolean.Parse(jObject["rwin"].ToString());
                this.checkCtrl.Checked = Boolean.Parse(jObject["ctrl"].ToString());
                this.checkLCtrl.Checked = Boolean.Parse(jObject["lctrl"].ToString());
                this.checkRCtrl.Checked = Boolean.Parse(jObject["rctrl"].ToString());
                this.checkShift.Checked = Boolean.Parse(jObject["shift"].ToString());
                this.checkLShift.Checked = Boolean.Parse(jObject["lshift"].ToString());
                this.checkRShift.Checked = Boolean.Parse(jObject["rshift"].ToString());
                this.checkAlt.Checked = Boolean.Parse(jObject["alt"].ToString());
                this.checkLAlt.Checked = Boolean.Parse(jObject["lalt"].ToString());
                this.checkRAlt.Checked = Boolean.Parse(jObject["ralt"].ToString());
                this.key.Text = jObject["key"].ToString();
            }
        }
    }

    /// <summary>
    /// VirtualKeyCode 参考链接点击：在浏览器中打开 H.InputSimulator 的 VirtualKeyCode 源代码页面佛为参考
    /// </summary>
    private void LblDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var p = new Process
        {
            StartInfo = new ProcessStartInfo("https://github.com/HavenDV/H.InputSimulator/blob/master/src/libs/H.InputSimulator/Native/VirtualKeyCode.cs")
            {
                UseShellExecute = true
            }
        };
        p.Start();
    }

}
