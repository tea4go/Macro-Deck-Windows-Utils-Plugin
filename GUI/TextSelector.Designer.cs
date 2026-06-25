
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class TextSelector
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
        // 创建文本输入动作的配置界面控件
        this.components = new System.ComponentModel.Container();
        this.textBox = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.btnAddVariable = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.variablesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // textBox - 文本输入框（多行）
        //
        this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.textBox.Cursor = System.Windows.Forms.Cursors.Hand;
        this.textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.textBox.Icon = null;
        this.textBox.Location = new System.Drawing.Point(19, 56);
        this.textBox.MaxCharacters = 32767;  // 最大字符数限制
        this.textBox.Multiline = true;  // 支持多行输入
        this.textBox.Name = "textBox";
        this.textBox.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.textBox.PasswordChar = false;
        this.textBox.PlaceHolderColor = System.Drawing.Color.Gray;
        this.textBox.PlaceHolderText = "Type text here";  // 占位提示文字
        this.textBox.ReadOnly = false;
        this.textBox.SelectionStart = 0;
        this.textBox.Size = new System.Drawing.Size(675, 123);
        this.textBox.TabIndex = 0;
        this.textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // btnAddVariable - 添加变量按钮
        //
        this.btnAddVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnAddVariable.BorderRadius = 8;  // 圆角边框
        this.btnAddVariable.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAddVariable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnAddVariable.ForeColor = System.Drawing.Color.White;  // 白色前景文字
        this.btnAddVariable.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));  // 悬停时的颜色
        this.btnAddVariable.Icon = null;
        this.btnAddVariable.Location = new System.Drawing.Point(556, 185);
        this.btnAddVariable.Name = "btnAddVariable";
        this.btnAddVariable.Progress = 0;
        this.btnAddVariable.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnAddVariable.Size = new System.Drawing.Size(140, 30);
        this.btnAddVariable.TabIndex = 1;
        this.btnAddVariable.Text = "Add variable";
        this.btnAddVariable.UseVisualStyleBackColor = true;
        this.btnAddVariable.Click += new System.EventHandler(this.BtnAddVariable_Click);  // 添加变量按钮点击事件
        //
        // variablesContextMenu - 变量右键菜单
        //
        this.variablesContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));  // 深色背景
        this.variablesContextMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.variablesContextMenu.Name = "variablesContextMenu";
        this.variablesContextMenu.ShowImageMargin = false;  // 不显示图片边距
        this.variablesContextMenu.Size = new System.Drawing.Size(36, 4);
        //
        // TextSelector - 文本输入选择器主控件
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.btnAddVariable);
        this.Controls.Add(this.textBox);
        this.Name = "TextSelector";
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置

    }

    #endregion

    // 字段声明：文本选择器的所有UI控件
    private RoundedTextBox textBox;  // 文本输入框（多行）
    private ButtonPrimary btnAddVariable;  // 添加变量按钮
    private System.Windows.Forms.ContextMenuStrip variablesContextMenu;  // 变量右键菜单
}
