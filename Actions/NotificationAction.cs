using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using Newtonsoft.Json.Linq;
using System;
using SuchByte.MacroDeck.Notifications;
using SuchByte.MacroDeck.Logging;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 发送通知动作：将配置的标题和消息以系统通知的形式显示给用户
/// </summary>
public class NotificationAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionNotification;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionNotificationDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置并通过 Macro Deck 通知系统发送通知
    /// 采用“发送并立即移除”的变通方式绕过 Macro Deck 的通知数量限制
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        MacroDeckLogger.Info(Main.Instance, $"NotificationAction triggered. hasConfiguration={!string.IsNullOrWhiteSpace(this.Configuration)}");
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var title = configurationObject["title"].ToString();
                var message = configurationObject["message"].ToString();
                MacroDeckLogger.Info(Main.Instance, $"NotificationAction parsed configuration. title='{title}', messageLength={message?.Length ?? 0}");

                // 变通方案：先发送通知，立刻再将其从通知列表中移除，
                // 这样可以绕过 Macro Deck 内部对同一插件的通知数量限制
                string notifId = NotificationManager.Notify(Main.Instance, title, message, true);
                NotificationManager.RemoveNotification(notifId);
                MacroDeckLogger.Info(Main.Instance, $"NotificationAction completed. notificationId={notifId}");
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance, $"NotificationAction failed: {e.Message}{Environment.NewLine}{e.StackTrace}");
            }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new NotificationConfigurator(this);
    }
}
