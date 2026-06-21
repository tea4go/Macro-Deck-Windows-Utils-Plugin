using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;

namespace SuchByte.WindowsUtils.GUI;

public partial class PowerOptionSelector : ActionConfigControl
{
    PluginAction pluginAction;

    PowerOptions selectedPowerOption; 

    public PowerOptionSelector(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();

        this.lblPowerOption.Text = PluginLanguageManager.PluginStrings.ActionPowerOption + ":";

        // Update the power options dynamically based on the PowerOptions enum
        var powerOptionValues = Enum.GetValues(typeof(PowerOptions));
        object[] powerOptionValuesObject = new object[powerOptionValues.Length];
        powerOptionValues.CopyTo(powerOptionValuesObject, 0);

        this.powerOption.Items.AddRange(powerOptionValuesObject);
        this.powerOption.SelectedIndex = 0;
        this.powerOption.Text = Enum.GetName(PowerOptions.Sleep);

        this.LoadConfig();
    }

    public override bool OnActionSave()
    {
        if (String.IsNullOrWhiteSpace(this.powerOption.Text))
        {
            return false;
        }

        this.selectedPowerOption = Enum.Parse<PowerOptions>(this.powerOption.Text);

        JObject configurationObject = JObject.FromObject(new
        {
            powerOption = this.selectedPowerOption
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        this.pluginAction.ConfigurationSummary = this.powerOption.Text;
        return true;
    }

    private void LoadConfig()
    {
        if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                PowerOptions savedPowerOption = Enum.Parse<PowerOptions>(configurationObject["powerOption"].ToString());
                this.powerOption.Text = Enum.GetName(savedPowerOption);
                this.powerOption.SelectedIndex = this.powerOption.Items.IndexOf(savedPowerOption);
            }
            catch { }
        }
    }
}

public enum PowerOptions
{
    Sleep,
    Hibernate,
    Shutdown,
    Restart
}