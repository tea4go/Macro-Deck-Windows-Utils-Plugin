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
        // 创建电源选项选择器的配置界面控件
        powerOption = new RoundedComboBox();
        lblPowerOption = new System.Windows.Forms.Label();
        SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // powerOption - 电源选项下拉选择框
        //
        powerOption.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);  // 深色背景
        powerOption.Cursor = System.Windows.Forms.Cursors.Hand;
        powerOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  // 只允许从列表中选择
        powerOption.Font = new System.Drawing.Font("Tahoma", 9.75F);
        powerOption.Icon = null;
        powerOption.Location = new System.Drawing.Point(183, 63);
        powerOption.Name = "powerOption";
        powerOption.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        powerOption.SelectedIndex = -1;  // 无默认选中项
        powerOption.SelectedItem = null;
        powerOption.Size = new System.Drawing.Size(250, 28);
        powerOption.TabIndex = 12;
        //
        // lblPowerOption - 电源选项标签
        //
        lblPowerOption.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblPowerOption.Location = new System.Drawing.Point(0, 63);
        lblPowerOption.Name = "lblPowerOption";
        lblPowerOption.Size = new System.Drawing.Size(174, 29);
        lblPowerOption.TabIndex = 8;
        lblPowerOption.Text = "Power option:";
        lblPowerOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;  // 左对齐居中显示
        //
        // PowerOptionSelector - 电源选项选择器主控件
        //
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(lblPowerOption);
        Controls.Add(powerOption);
        Name = "PowerOptionSelector";
        ResumeLayout(false);  // 恢复布局，应用所有属性设置
    }

    #endregion

    // 字段声明：电源选项选择器的所有UI控件
    private MacroDeck.GUI.CustomControls.RoundedComboBox powerOption;  // 电源选项下拉选择框
    private System.Windows.Forms.Label lblPowerOption;  // 电源选项标签
}
