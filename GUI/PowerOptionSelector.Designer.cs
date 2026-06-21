using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.GUI;

partial class PowerOptionSelector
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        powerOption = new RoundedComboBox();
        lblPowerOption = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // powerOption
        // 
        powerOption.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        powerOption.Cursor = System.Windows.Forms.Cursors.Hand;
        powerOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        powerOption.Font = new System.Drawing.Font("Tahoma", 9.75F);
        powerOption.Icon = null;
        powerOption.Location = new System.Drawing.Point(183, 63);
        powerOption.Name = "powerOption";
        powerOption.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        powerOption.SelectedIndex = -1;
        powerOption.SelectedItem = null;
        powerOption.Size = new System.Drawing.Size(250, 28);
        powerOption.TabIndex = 12;
        // 
        // lblPowerOption
        // 
        lblPowerOption.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblPowerOption.Location = new System.Drawing.Point(0, 63);
        lblPowerOption.Name = "lblPowerOption";
        lblPowerOption.Size = new System.Drawing.Size(174, 29);
        lblPowerOption.TabIndex = 8;
        lblPowerOption.Text = "Power option:";
        lblPowerOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // PowerOptionSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(lblPowerOption);
        Controls.Add(powerOption);
        Name = "PowerOptionSelector";
        ResumeLayout(false);
    }

    private MacroDeck.GUI.CustomControls.RoundedComboBox roundedComboBox1;
    private MacroDeck.GUI.CustomControls.RoundedComboBox powerOption;
    private System.Windows.Forms.Label lblPowerOption;
}
