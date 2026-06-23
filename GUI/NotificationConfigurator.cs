using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 通知动作配置界面：输入通知的标题和消息内容
/// </summary>
public partial class NotificationConfigurator : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;

    /// <summary>
    /// 构造函数：初始化界面并加载已有配置
    /// </summary>
    public NotificationConfigurator(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        // 根据语言包设置标签文本
        this.lblTitle.Text = PluginLanguageManager.PluginStrings.Title + ": ";
        this.lblMessage.Text = PluginLanguageManager.PluginStrings.Message + ": ";

        this.LoadConfig();
    }

    /// <summary>
    /// 保存配置：校验标题和消息不能为空，然后将配置序列化为 JSON
    /// </summary>
    public override bool OnActionSave()
    {
        // 标题和消息均为必填项
        if (String.IsNullOrWhiteSpace(this.title.Text) || String.IsNullOrWhiteSpace(this.message.Text))
        {
            return false;
        }

        JObject configurationObject = JObject.FromObject(new
        {
            title = this.title.Text,
            message = this.message.Text
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        // 配置摘要：标题 - 消息（若消息不为空）
        this.pluginAction.ConfigurationSummary = this.title.Text + (!String.IsNullOrWhiteSpace(this.message.Text) ? " - " + this.message.Text : "");
        return true;
    }

    /// <summary>
    /// 从已保存配置中加载标题和消息并填充到界面控件
    /// 使用空先操作符 (?.) 安全读取，防止 JSON 字段不存在时抛异常
    /// </summary>
    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.title.Text = configurationObject["title"]?.ToString();
                this.message.Text = configurationObject["message"]?.ToString();
            }
            catch { }
        }
    }
}