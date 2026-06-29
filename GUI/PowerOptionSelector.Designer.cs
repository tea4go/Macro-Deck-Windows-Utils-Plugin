using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.GUI;

partial class PowerOptionSelector
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
        powerOption.Location = new System.Drawing.Point(274, 97);
        powerOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        powerOption.Name = "powerOption";
        powerOption.Padding = new System.Windows.Forms.Padding(12, 3, 12, 3);
        powerOption.SelectedIndex = -1;
        powerOption.SelectedItem = null;
        powerOption.Size = new System.Drawing.Size(375, 38);
        powerOption.TabIndex = 12;
        // 
        // lblPowerOption
        // 
        lblPowerOption.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblPowerOption.Location = new System.Drawing.Point(0, 94);
        lblPowerOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblPowerOption.Name = "lblPowerOption";
        lblPowerOption.Size = new System.Drawing.Size(261, 44);
        lblPowerOption.TabIndex = 8;
        lblPowerOption.Text = "Power option:";
        lblPowerOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // PowerOptionSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
        Controls.Add(lblPowerOption);
        Controls.Add(powerOption);
        Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
        Name = "PowerOptionSelector";
        Size = new System.Drawing.Size(1286, 636);
        ResumeLayout(false);
    }

    #endregion

    // 字段声明：电源选项选择器的所有UI控件
    private MacroDeck.GUI.CustomControls.RoundedComboBox powerOption;  // 电源选项下拉选择框
    private System.Windows.Forms.Label lblPowerOption;  // 电源选项标签
}
