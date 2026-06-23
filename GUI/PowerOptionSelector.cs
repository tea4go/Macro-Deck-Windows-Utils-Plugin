using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 电源选项配置界面：从下拉框中选择要执行的电源操作（睡眠/休眠/关机/重启）
/// </summary>
public partial class PowerOptionSelector : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;

    /// <summary>当前展示选中的电源选项</summary>
    PowerOptions selectedPowerOption;

    /// <summary>
    /// 构造函数：动态加载电源选项枚举到下拉框并加载已有配置
    /// </summary>
    public PowerOptionSelector(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        this.lblPowerOption.Text = PluginLanguageManager.PluginStrings.ActionPowerOption + ":";

        // 动态从 PowerOptions 枚举加载选项，避免硬编码下拉项内容
        var powerOptionValues = Enum.GetValues(typeof(PowerOptions));
        object[] powerOptionValuesObject = new object[powerOptionValues.Length];
        powerOptionValues.CopyTo(powerOptionValuesObject, 0);

        this.powerOption.Items.AddRange(powerOptionValuesObject);
        this.powerOption.SelectedIndex = 0;
        this.powerOption.Text = Enum.GetName(PowerOptions.Sleep); // 默认选中睡眠

        this.LoadConfig();
    }

    /// <summary>
    /// 保存配置：解析选中的电源选项枚举并序列化为 JSON
    /// </summary>
    public override bool OnActionSave()
    {
        if (String.IsNullOrWhiteSpace(this.powerOption.Text))
        {
            return false;
        }

        // 将下拉框文本解析为枚举值
        this.selectedPowerOption = Enum.Parse<PowerOptions>(this.powerOption.Text);

        JObject configurationObject = JObject.FromObject(new
        {
            powerOption = this.selectedPowerOption
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        this.pluginAction.ConfigurationSummary = this.powerOption.Text;
        return true;
    }

    /// <summary>
    /// 从已保存配置中加载电源选项并同时更新下拉框的文本和选中索引
    /// </summary>
    private void LoadConfig()
    {
        if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                PowerOptions savedPowerOption = Enum.Parse<PowerOptions>(configurationObject["powerOption"].ToString());
                this.powerOption.Text = Enum.GetName(savedPowerOption);
                // 同时设置选中索引，确保下拉框显示正确高亮
                this.powerOption.SelectedIndex = this.powerOption.Items.IndexOf(savedPowerOption);
            }
            catch { }
        }
    }
}

/// <summary>
/// 电源操作选项枚举
/// </summary>
public enum PowerOptions
{
    /// <summary>睡眠：保持内存状态，降低功耗</summary>
    Sleep,
    /// <summary>休眠：将内存保存到磁盘并将电脑关机</summary>
    Hibernate,
    /// <summary>关机：将电脑完全关闭</summary>
    Shutdown,
    /// <summary>重启：关机并重新启动</summary>
    Restart
}