using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;

namespace SuchByte.WindowsUtils.GUI;

public partial class NotificationConfigurator : ActionConfigControl
{
    PluginAction pluginAction;

    public NotificationConfigurator(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        this.lblTitle.Text = PluginLanguageManager.PluginStrings.Title + ": ";
        this.lblMessage.Text = PluginLanguageManager.PluginStrings.Message + ": ";

        this.LoadConfig();
    }

    public override bool OnActionSave()
    {
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
        this.pluginAction.ConfigurationSummary = this.title.Text + (!String.IsNullOrWhiteSpace(this.message.Text) ? " - " + this.message.Text : "");
        return true;
    }

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