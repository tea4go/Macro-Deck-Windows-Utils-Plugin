using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using static SuchByte.WindowsUtils.Utils.WindowActivator;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 切换窗口动作：根据指定的标题模式查找并激活匹配的窗口
/// 支持部分匹配、全匹配、开头、结尾和正则表达式等多种匹配模式
/// </summary>
public class WindowSwitchAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionWindowSwitch;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionWindowSwitchDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置中的标题模式和匹配模式，并尝试激活匹配的窗口
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        MacroDeckLogger.Information(Main.Instance, $"WindowSwitchAction triggered. hasConfiguration={!string.IsNullOrWhiteSpace(this.Configuration)}");
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                var configurationObject = JObject.Parse(this.Configuration);
                string pattern = configurationObject["pattern"].ToString();
                // 解析匹配模式枚举（Partial/Full/StartsWith/EndsWith/Regex）
                MatchMode matchMode = Enum.Parse<MatchMode>(configurationObject["matchMode"].ToString());
                bool caseSensitive = configurationObject["caseSensitive"].ToObject<bool>();
                MacroDeckLogger.Information(Main.Instance, $"WindowSwitchAction parsed configuration. pattern='{pattern}', matchMode={matchMode}, caseSensitive={caseSensitive}");

                bool activated = ActivateWindowByTitle(pattern, matchMode, caseSensitive);
                MacroDeckLogger.Information(Main.Instance, $"WindowSwitchAction completed. activated={activated}");
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance, $"WindowSwitchAction failed: {e.Message}{Environment.NewLine}{e.StackTrace}", Array.Empty<object>());
            }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new WindowSwitchConfigurator(this);
    }
}
