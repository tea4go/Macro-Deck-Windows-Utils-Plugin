using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.GUI;

partial class WindowSwitchConfigurator
{
    /// <summary>
    /// 必需的窗体设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 释放正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，则为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region 组件设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改此方法的内容。
    /// </summary>
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
        lblPattern.Location = new System.Drawing.Point(0, 79);
        lblPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblPattern.Name = "lblPattern";
        lblPattern.Size = new System.Drawing.Size(218, 36);
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
        pattern.Location = new System.Drawing.Point(229, 79);
        pattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        pattern.MaxCharacters = 32767;
        pattern.Multiline = false;
        pattern.Name = "pattern";
        pattern.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        pattern.PasswordChar = false;
        pattern.PlaceHolderColor = System.Drawing.Color.Gray;
        pattern.PlaceHolderText = "Pattern";
        pattern.ReadOnly = false;
        pattern.ScrollBars = System.Windows.Forms.ScrollBars.None;
        pattern.SelectionStart = 0;
        pattern.Size = new System.Drawing.Size(586, 36);
        pattern.TabIndex = 10;
        pattern.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblMatchMode
        // 
        lblMatchMode.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMatchMode.Location = new System.Drawing.Point(0, 135);
        lblMatchMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblMatchMode.Name = "lblMatchMode";
        lblMatchMode.Size = new System.Drawing.Size(218, 36);
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
        matchMode.Location = new System.Drawing.Point(229, 135);
        matchMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        matchMode.Name = "matchMode";
        matchMode.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
        matchMode.SelectedIndex = -1;
        matchMode.SelectedItem = null;
        matchMode.Size = new System.Drawing.Size(586, 31);
        matchMode.TabIndex = 13;
        // 
        // caseSensitive
        // 
        caseSensitive.AutoSize = true;
        caseSensitive.Checked = true;
        caseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
        caseSensitive.Font = new System.Drawing.Font("Tahoma", 11.25F);
        caseSensitive.Location = new System.Drawing.Point(0, 193);
        caseSensitive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        caseSensitive.Name = "caseSensitive";
        caseSensitive.Size = new System.Drawing.Size(147, 27);
        caseSensitive.TabIndex = 15;
        caseSensitive.Text = "Case sensitive";
        caseSensitive.UseVisualStyleBackColor = true;
        // 
        // WindowSwitchConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
        Controls.Add(caseSensitive);
        Controls.Add(matchMode);
        Controls.Add(lblMatchMode);
        Controls.Add(pattern);
        Controls.Add(lblPattern);
        Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        Name = "WindowSwitchConfigurator";
        Size = new System.Drawing.Size(1071, 530);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    // 字段声明：窗口切换配置器的所有UI控件
    private System.Windows.Forms.Label lblPattern;  // 窗口标题匹配模式标签
    private RoundedTextBox pattern;  // 匹配模式输入框
    private System.Windows.Forms.Label lblMatchMode;  // 匹配模式标签
    private RoundedComboBox matchMode;  // 匹配模式下拉选择框
    private System.Windows.Forms.CheckBox caseSensitive;  // 大小写敏感复选框
}
