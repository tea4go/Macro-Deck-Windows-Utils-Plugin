using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 资源管理器/浏览器操作配置界面：通过单选按键选择要执行的导航操作（后退/前进/首页/刷新）
/// </summary>
public partial class ExplorerControlConfigurator : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;
    /// <summary>动作配置器引用（预留，当前未使用）</summary>
    ActionConfigurator actionConfigurator;

    /// <summary>
    /// 构造函数：初始化界面并加载已有配置
    /// </summary>
    public ExplorerControlConfigurator(PluginAction pluginAction, ActionConfigurator actionConfigurator)
    {
        this.pluginAction = pluginAction;
        this.actionConfigurator = actionConfigurator;
        InitializeComponent();

        // 根据当前语言设置单选按键的显示文本
        this.lblAction.Text = PluginLanguageManager.PluginStrings.Action;
        this.radioBack.Text = PluginLanguageManager.PluginStrings.Back;
        this.radioForward.Text = PluginLanguageManager.PluginStrings.Forward;
        this.radioHome.Text = PluginLanguageManager.PluginStrings.Home;
        this.radioRefresh.Text = PluginLanguageManager.PluginStrings.Refresh;

        this.LoadConfig();
    }

    /// <summary>
    /// 保存配置：根据当前选中的单选按键将操作类型序列化为 JSON 并保存
    /// </summary>
    /// <returns>始终返回 true</returns>
    public override bool OnActionSave()
    {
        JObject jObject = new JObject();
        // 根据勾选的单选按键确定操作类型
        if (this.radioBack.Checked)
        {
            jObject["action"] = "back";
        }
        else if (this.radioForward.Checked)
        {
            jObject["action"] = "forward";
        }
        else if (this.radioHome.Checked)
        {
            jObject["action"] = "home";
        }
        else if (this.radioRefresh.Checked)
        {
            jObject["action"] = "refresh";
        }
        this.pluginAction.Configuration = jObject.ToString();
        this.pluginAction.ConfigurationSummary = jObject["action"].ToString();
        return true;
    }

    /// <summary>
    /// 从已保存配置中加载操作类型并勾选对应的单选按键
    /// </summary>
    private void LoadConfig()
    {
        if (this.pluginAction.Configuration != null && this.pluginAction.Configuration.Length > 0)
        {
            JObject jObject = JObject.Parse(this.pluginAction.Configuration);
            if (jObject != null)
            {
                // 根据保存的操作类型导航到对应的单选按键
                switch (jObject["action"].ToString())
                {
                    case "back":
                        this.radioBack.Checked = true;
                        break;
                    case "forward":
                        this.radioForward.Checked = true;
                        break;
                    case "home":
                        this.radioHome.Checked = true;
                        break;
                    case "refresh":
                        this.radioRefresh.Checked = true;
                        break;
                }
            }
        }
    }


}
