using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using static SuchByte.WindowsUtils.Utils.WindowActivator;

namespace SuchByte.WindowsUtils.GUI;

public partial class WindowSwitchConfigurator : ActionConfigControl
{
    PluginAction pluginAction;

    MatchMode selectedMatchMode = MatchMode.Full;

    public WindowSwitchConfigurator(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        this.lblPattern.Text = PluginLanguageManager.PluginStrings.Pattern + ": ";
        this.lblMatchMode.Text = PluginLanguageManager.PluginStrings.MatchMode + ": ";

        // Update the match modes dynamically based on the MatchMode enum
        var matchModeValues = Enum.GetValues(typeof(MatchMode));
        object[] matchModeValuesObject = new object[matchModeValues.Length];
        matchModeValues.CopyTo(matchModeValuesObject, 0);

        this.matchMode.Items.AddRange(matchModeValuesObject);
        this.matchMode.SelectedIndex = 0;
        this.matchMode.Text = Enum.GetName(MatchMode.Partial);

        this.caseSensitive.Text = PluginLanguageManager.PluginStrings.CaseSensitive;

        this.LoadConfig();
    }

    public override bool OnActionSave()
    {
        if (String.IsNullOrWhiteSpace(this.pattern.Text) || String.IsNullOrWhiteSpace(this.matchMode.Text) || String.IsNullOrWhiteSpace(this.caseSensitive.Checked.ToString()))
        {
            return false;
        }

        this.selectedMatchMode = Enum.Parse<MatchMode>(this.matchMode.Text);

        JObject configurationObject = JObject.FromObject(new
        {
            pattern = this.pattern.Text,
            matchMode = this.selectedMatchMode,
            caseSensitive = this.caseSensitive.Checked
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        string caseSensitiveText = this.caseSensitive.Checked ? "Case Sensitive" : "Case Insensitive";
        this.pluginAction.ConfigurationSummary = $"{this.selectedMatchMode.ToString()} Match ({caseSensitiveText}) - {this.pattern.Text}";
        return true;
    }

    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.pattern.Text = configurationObject["pattern"]?.ToString();

                MatchMode savedMatchMode = Enum.Parse<MatchMode>(configurationObject["matchMode"]?.ToString());
                this.matchMode.Text = Enum.GetName(savedMatchMode);
                this.matchMode.SelectedIndex = this.matchMode.Items.IndexOf(savedMatchMode);

                this.caseSensitive.Checked = configurationObject["caseSensitive"].ToObject<bool>();
            }
            catch { }
        }
    }
}
