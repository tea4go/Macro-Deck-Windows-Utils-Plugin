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

public class NotificationAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionNotification;

    public override string Description => PluginLanguageManager.PluginStrings.ActionNotificationDescription;

    public override bool CanConfigure => true;

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

                // Workaround to bypass macro deck's notification limit. Probably not the best but it works.
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

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new NotificationConfigurator(this);
    }
}
