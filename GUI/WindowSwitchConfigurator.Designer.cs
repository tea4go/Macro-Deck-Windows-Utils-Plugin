using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.GUI;

partial class WindowSwitchConfigurator
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
        lblPattern = new System.Windows.Forms.Label();
        pattern = new RoundedTextBox();
        lblMatchMode = new System.Windows.Forms.Label();
        matchMode = new RoundedComboBox();
        caseSensitive = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // lblPattern
        // 
        lblPattern.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblPattern.Location = new System.Drawing.Point(0, 63);
        lblPattern.Name = "lblPattern";
        lblPattern.Size = new System.Drawing.Size(174, 29);
        lblPattern.TabIndex = 9;
        lblPattern.Text = "Pattern:";
        lblPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // pattern
        // 
        pattern.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        pattern.Cursor = System.Windows.Forms.Cursors.Hand;
        pattern.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);
        pattern.Icon = null;
        pattern.Location = new System.Drawing.Point(183, 63);
        pattern.MaxCharacters = 32767;
        pattern.Multiline = false;
        pattern.Name = "pattern";
        pattern.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        pattern.PasswordChar = false;
        pattern.PlaceHolderColor = System.Drawing.Color.Gray;
        pattern.PlaceHolderText = "Pattern";
        pattern.ReadOnly = false;
        pattern.ScrollBars = System.Windows.Forms.ScrollBars.None;
        pattern.SelectionStart = 0;
        pattern.Size = new System.Drawing.Size(469, 29);
        pattern.TabIndex = 10;
        pattern.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblMatchMode
        // 
        lblMatchMode.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMatchMode.Location = new System.Drawing.Point(0, 98);
        lblMatchMode.Name = "lblMatchMode";
        lblMatchMode.Size = new System.Drawing.Size(174, 29);
        lblMatchMode.TabIndex = 11;
        lblMatchMode.Text = "Match mode:";
        lblMatchMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // matchMode
        // 
        matchMode.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        matchMode.Cursor = System.Windows.Forms.Cursors.Hand;
        matchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        matchMode.Font = new System.Drawing.Font("Tahoma", 9.75F);
        matchMode.Icon = null;
        matchMode.Location = new System.Drawing.Point(183, 98);
        matchMode.Name = "matchMode";
        matchMode.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        matchMode.SelectedIndex = -1;
        matchMode.SelectedItem = null;
        matchMode.Size = new System.Drawing.Size(250, 28);
        matchMode.TabIndex = 13;
        // 
        // caseSensitive
        // 
        caseSensitive.AutoSize = true;
        caseSensitive.Checked = true;
        caseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
        caseSensitive.Font = new System.Drawing.Font("Tahoma", 11.25F);
        caseSensitive.Location = new System.Drawing.Point(0, 133);
        caseSensitive.Name = "caseSensitive";
        caseSensitive.Size = new System.Drawing.Size(119, 22);
        caseSensitive.TabIndex = 15;
        caseSensitive.Text = "Case sensitive";
        caseSensitive.UseVisualStyleBackColor = true;
        // 
        // WindowSwitchConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(caseSensitive);
        Controls.Add(matchMode);
        Controls.Add(lblMatchMode);
        Controls.Add(pattern);
        Controls.Add(lblPattern);
        Name = "WindowSwitchConfigurator";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblPattern;
    private RoundedTextBox pattern;
    private System.Windows.Forms.Label lblMatchMode;
    private RoundedComboBox matchMode;
    private System.Windows.Forms.CheckBox caseSensitive;
}
