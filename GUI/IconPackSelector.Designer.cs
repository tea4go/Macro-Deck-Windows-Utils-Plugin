
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
        // 创建图标包选择对话框的界面控件
        this.iconPacks = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
        this.btnOk = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // iconPacks - 图标包下拉选择框
        //
        this.iconPacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.iconPacks.Cursor = System.Windows.Forms.Cursors.Hand;
        this.iconPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  // 只允许从列表中选择
        this.iconPacks.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.iconPacks.Icon = null;
        this.iconPacks.Location = new System.Drawing.Point(9, 20);
        this.iconPacks.Name = "iconPacks";
        this.iconPacks.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        this.iconPacks.SelectedIndex = -1;  // 无默认选中项
        this.iconPacks.SelectedItem = null;
        this.iconPacks.Size = new System.Drawing.Size(308, 30);
        this.iconPacks.TabIndex = 2;
        //
        // btnOk - 确认按钮
        //
        this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnOk.BorderRadius = 8;  // 圆角边框
        this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnOk.ForeColor = System.Drawing.Color.White;  // 白色前景文字
        this.btnOk.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));  // 悬停时的颜色
        this.btnOk.Icon = null;
        this.btnOk.Location = new System.Drawing.Point(271, 65);
        this.btnOk.Name = "btnOk";
        this.btnOk.Progress = 0;
        this.btnOk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnOk.Size = new System.Drawing.Size(75, 25);
        this.btnOk.TabIndex = 3;
        this.btnOk.Text = "Ok";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);  // 确认按钮点击事件
        //
        // IconPackSelector - 图标包选择器主对话框
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(363, 108);  // 设置对话框尺寸
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.iconPacks);
        this.Name = "IconPackSelector";
        this.Text = "IconPackSelector";
        this.Controls.SetChildIndex(this.iconPacks, 0);  // 调整子控件层级
        this.Controls.SetChildIndex(this.btnOk, 0);
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置

    }

    #endregion

    // 字段声明：图标包选择器的所有UI控件
    private RoundedComboBox iconPacks;  // 图标包下拉选择框
    private ButtonPrimary btnOk;  // 确认按钮
}