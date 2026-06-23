using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using static SuchByte.WindowsUtils.Utils.WindowActivator;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 窗口切换动作的配置控件，允许用户设置标题匹配模式、大小写敏感性及匹配模式枚举
/// </summary>
public partial class WindowSwitchConfigurator : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;

    /// <summary>当前选中的标题匹配模式，默认为完全匹配</summary>
    MatchMode selectedMatchMode = MatchMode.Full;

    /// <summary>
    /// 构造函数：初始化控件、填充 MatchMode 下拉列表，并加载已保存的配置
    /// </summary>
    /// <param name="pluginAction">要配置的插件动作</param>
    public WindowSwitchConfigurator(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        this.lblPattern.Text = PluginLanguageManager.PluginStrings.Pattern + ": ";
        this.lblMatchMode.Text = PluginLanguageManager.PluginStrings.MatchMode + ": ";

        // 通过反射动态枚举 MatchMode 的所有值并填充到下拉列表中，避免硬编码枚举项
        var matchModeValues = Enum.GetValues(typeof(MatchMode));
        object[] matchModeValuesObject = new object[matchModeValues.Length];
        matchModeValues.CopyTo(matchModeValuesObject, 0);

        this.matchMode.Items.AddRange(matchModeValuesObject);
        this.matchMode.SelectedIndex = 0;
        // 默认显示 Partial（部分匹配）模式
        this.matchMode.Text = Enum.GetName(MatchMode.Partial);

        this.caseSensitive.Text = PluginLanguageManager.PluginStrings.CaseSensitive;

        this.LoadConfig();
    }

    /// <summary>
    /// 保存动作配置：将匹配模式、模式字符串和大小写敏感性序列化为 JSON 并存入动作配置
    /// </summary>
    /// <returns>所有必填字段均已填写时返回 true，否则返回 false</returns>
    public override bool OnActionSave()
    {
        // 校验必填字段：匹配模式字符串、下拉框文本和复选框值不能为空
        if (String.IsNullOrWhiteSpace(this.pattern.Text) || String.IsNullOrWhiteSpace(this.matchMode.Text) || String.IsNullOrWhiteSpace(this.caseSensitive.Checked.ToString()))
        {
            return false;
        }

        // 将下拉框文本解析为枚举值
        this.selectedMatchMode = Enum.Parse<MatchMode>(this.matchMode.Text);

        // 将配置序列化为 JSON 对象并保存
        JObject configurationObject = JObject.FromObject(new
        {
            pattern = this.pattern.Text,
            matchMode = this.selectedMatchMode,
            caseSensitive = this.caseSensitive.Checked
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        // 生成可读的配置摘要，显示在按键标签上
        string caseSensitiveText = this.caseSensitive.Checked ? "Case Sensitive" : "Case Insensitive";
        this.pluginAction.ConfigurationSummary = $"{this.selectedMatchMode.ToString()} Match ({caseSensitiveText}) - {this.pattern.Text}";
        return true;
    }

    /// <summary>
    /// 从已保存的 JSON 配置中加载控件状态（匹配模式、模式字符串、大小写敏感性）
    /// </summary>
    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.pattern.Text = configurationObject["pattern"]?.ToString();

                // 将保存的枚举字符串还原为枚举值，并同时设置文本和选中索引
                MatchMode savedMatchMode = Enum.Parse<MatchMode>(configurationObject["matchMode"]?.ToString());
                this.matchMode.Text = Enum.GetName(savedMatchMode);
                this.matchMode.SelectedIndex = this.matchMode.Items.IndexOf(savedMatchMode);

                this.caseSensitive.Checked = configurationObject["caseSensitive"].ToObject<bool>();
            }
            catch { }
        }
    }
}
