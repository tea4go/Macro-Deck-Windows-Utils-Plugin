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
        // 创建窗口切换动作的配置界面控件
        lblPattern = new System.Windows.Forms.Label();
        pattern = new RoundedTextBox();
        lblMatchMode = new System.Windows.Forms.Label();
        matchMode = new RoundedComboBox();
        caseSensitive = new System.Windows.Forms.CheckBox();
        SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // lblPattern - 窗口标题匹配模式标签
        //
        lblPattern.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblPattern.Location = new System.Drawing.Point(0, 63);
        lblPattern.Name = "lblPattern";
        lblPattern.Size = new System.Drawing.Size(174, 29);
        lblPattern.TabIndex = 9;
        lblPattern.Text = "Pattern:";
        lblPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;  // 左对齐居中显示
        //
        // pattern - 匹配模式输入框
        //
        pattern.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);  // 深色背景
        pattern.Cursor = System.Windows.Forms.Cursors.Hand;
        pattern.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);  // 斜体字体
        pattern.Icon = null;
        pattern.Location = new System.Drawing.Point(183, 63);
        pattern.MaxCharacters = 32767;  // 最大字符数限制
        pattern.Multiline = false;  // 单行输入
        pattern.Name = "pattern";
        pattern.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        pattern.PasswordChar = false;
        pattern.PlaceHolderColor = System.Drawing.Color.Gray;
        pattern.PlaceHolderText = "Pattern";  // 占位提示文字
        pattern.ReadOnly = false;
        pattern.ScrollBars = System.Windows.Forms.ScrollBars.None;
        pattern.SelectionStart = 0;
        pattern.Size = new System.Drawing.Size(469, 29);
        pattern.TabIndex = 10;
        pattern.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // lblMatchMode - 匹配模式标签
        //
        lblMatchMode.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMatchMode.Location = new System.Drawing.Point(0, 98);
        lblMatchMode.Name = "lblMatchMode";
        lblMatchMode.Size = new System.Drawing.Size(174, 29);
        lblMatchMode.TabIndex = 11;
        lblMatchMode.Text = "Match mode:";
        lblMatchMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;  // 左对齐居中显示
        //
        // matchMode - 匹配模式下拉选择框
        //
        matchMode.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);  // 深色背景
        matchMode.Cursor = System.Windows.Forms.Cursors.Hand;
        matchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  // 只允许从列表中选择
        matchMode.Font = new System.Drawing.Font("Tahoma", 9.75F);
        matchMode.Icon = null;
        matchMode.Location = new System.Drawing.Point(183, 98);
        matchMode.Name = "matchMode";
        matchMode.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        matchMode.SelectedIndex = -1;  // 无默认选中项
        matchMode.SelectedItem = null;
        matchMode.Size = new System.Drawing.Size(250, 28);
        matchMode.TabIndex = 13;
        //
        // caseSensitive - 大小写敏感复选框
        //
        caseSensitive.AutoSize = true;  // 自动调整大小
        caseSensitive.Checked = true;  // 默认勾选：大小写敏感
        caseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
        caseSensitive.Font = new System.Drawing.Font("Tahoma", 11.25F);
        caseSensitive.Location = new System.Drawing.Point(0, 133);
        caseSensitive.Name = "caseSensitive";
        caseSensitive.Size = new System.Drawing.Size(119, 22);
        caseSensitive.TabIndex = 15;
        caseSensitive.Text = "Case sensitive";
        caseSensitive.UseVisualStyleBackColor = true;
        //
        // WindowSwitchConfigurator - 窗口切换配置器主控件
        //
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(caseSensitive);
        Controls.Add(matchMode);
        Controls.Add(lblMatchMode);
        Controls.Add(pattern);
        Controls.Add(lblPattern);
        Name = "WindowSwitchConfigurator";
        ResumeLayout(false);  // 恢复布局，应用所有属性设置
        PerformLayout();  // 强制立即布局计算
    }

    #endregion

    // 字段声明：窗口切换配置器的所有UI控件
    private System.Windows.Forms.Label lblPattern;  // 窗口标题匹配模式标签
    private RoundedTextBox pattern;  // 匹配模式输入框
    private System.Windows.Forms.Label lblMatchMode;  // 匹配模式标签
    private RoundedComboBox matchMode;  // 匹配模式下拉选择框
    private System.Windows.Forms.CheckBox caseSensitive;  // 大小写敏感复选框
}
