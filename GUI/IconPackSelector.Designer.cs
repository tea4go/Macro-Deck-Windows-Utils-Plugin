
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class IconPackSelector
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
        iconPacks = new RoundedComboBox();
        btnOk = new ButtonPrimary();
        SuspendLayout();
        // 
        // iconPacks
        // 
        iconPacks.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        iconPacks.Cursor = System.Windows.Forms.Cursors.Hand;
        iconPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        iconPacks.Font = new System.Drawing.Font("微软雅黑", 12F);
        iconPacks.Icon = null;
        iconPacks.Location = new System.Drawing.Point(9, 20);
        iconPacks.Margin = new System.Windows.Forms.Padding(4);
        iconPacks.Name = "iconPacks";
        iconPacks.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        iconPacks.SelectedIndex = -1;
        iconPacks.SelectedItem = null;
        iconPacks.Size = new System.Drawing.Size(333, 35);
        iconPacks.TabIndex = 2;
        // 
        // btnOk
        // 
        btnOk.BorderRadius = 8;
        btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
        btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnOk.Font = new System.Drawing.Font("微软雅黑", 9.75F);
        btnOk.ForeColor = System.Drawing.Color.White;
        btnOk.HoverColor = System.Drawing.Color.FromArgb(0, 89, 184);
        btnOk.Icon = null;
        btnOk.Location = new System.Drawing.Point(267, 81);
        btnOk.Name = "btnOk";
        btnOk.Progress = 0;
        btnOk.ProgressColor = System.Drawing.Color.FromArgb(0, 46, 94);
        btnOk.Size = new System.Drawing.Size(75, 39);
        btnOk.TabIndex = 3;
        btnOk.Text = "Ok";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.UseWindowsAccentColor = true;
        btnOk.WriteProgress = true;
        btnOk.Click += BtnOk_Click;
        // 
        // IconPackSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(363, 136);
        Controls.Add(btnOk);
        Controls.Add(iconPacks);
        Name = "IconPackSelector";
        Text = "IconPackSelector";
        ResumeLayout(false);

    }

    #endregion

    // 字段声明：图标包选择器的所有UI控件
    private RoundedComboBox iconPacks;  // 图标包下拉选择框
    private ButtonPrimary btnOk;  // 确认按钮
}