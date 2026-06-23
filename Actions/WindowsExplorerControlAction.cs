using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 资源管理器/浏览器控制动作：模拟浏览器导航操作，包括后退、前进、返回首页和刷新
/// 使用虚拟键模拟对应的浏览器快捷键
/// </summary>
public class WindowsExplorerControlAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionExplorerControl;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionExplorerControlDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>独立的 InputSimulator 实例，与全局实例区分</summary>
    private InputSimulator inputSimulator = new InputSimulator();

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new ExplorerControlConfigurator(this, actionConfigurator);
    }

    /// <summary>
    /// 动作触发：解析配置中的操作类型并模拟对应的浏览器虚拟键
    /// 支持 back（后退）/forward（前进）/home（首页）/refresh（刷新）
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (this.Configuration.Length == 0) return;
        try
        {
            // 解析配置中的操作类型字符串
            string type = JObject.Parse(this.Configuration)["action"].ToString();
            switch (type)
            {
                case "back":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_BACK);
                    break;
                case "forward":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_FORWARD);
                    break;
                case "home":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_HOME);
                    break;
                case "refresh":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_REFRESH);
                    break;
            }
        }
        catch { }
    }
}
