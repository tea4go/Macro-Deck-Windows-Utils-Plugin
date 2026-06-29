
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
        components = new System.ComponentModel.Container();
        textBox = new RoundedTextBox();
        btnAddVariable = new ButtonPrimary();
        variablesContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
        SuspendLayout();
        // 
        // textBox
        // 
        textBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        textBox.Cursor = System.Windows.Forms.Cursors.Hand;
        textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
        textBox.Icon = null;
        textBox.Location = new System.Drawing.Point(19, 15);
        textBox.MaxCharacters = 32767;
        textBox.Multiline = true;
        textBox.Name = "textBox";
        textBox.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        textBox.PasswordChar = false;
        textBox.PlaceHolderColor = System.Drawing.Color.Gray;
        textBox.PlaceHolderText = "Type text here";
        textBox.ReadOnly = false;
        textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
        textBox.SelectionStart = 0;
        textBox.Size = new System.Drawing.Size(675, 123);
        textBox.TabIndex = 0;
        textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // btnAddVariable
        // 
        btnAddVariable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnAddVariable.BorderRadius = 8;
        btnAddVariable.Cursor = System.Windows.Forms.Cursors.Hand;
        btnAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAddVariable.Font = new System.Drawing.Font("微软雅黑", 9.75F);
        btnAddVariable.ForeColor = System.Drawing.Color.White;
        btnAddVariable.HoverColor = System.Drawing.Color.FromArgb(0, 89, 184);
        btnAddVariable.Icon = null;
        btnAddVariable.Location = new System.Drawing.Point(476, 156);
        btnAddVariable.Name = "btnAddVariable";
        btnAddVariable.Progress = 0;
        btnAddVariable.ProgressColor = System.Drawing.Color.FromArgb(0, 46, 94);
        btnAddVariable.Size = new System.Drawing.Size(218, 41);
        btnAddVariable.TabIndex = 1;
        btnAddVariable.Text = "Add variable";
        btnAddVariable.UseVisualStyleBackColor = true;
        btnAddVariable.UseWindowsAccentColor = true;
        btnAddVariable.WriteProgress = true;
        btnAddVariable.Click += BtnAddVariable_Click;
        // 
        // variablesContextMenu
        // 
        variablesContextMenu.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        variablesContextMenu.Font = new System.Drawing.Font("微软雅黑", 12F);
        variablesContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
        variablesContextMenu.Name = "variablesContextMenu";
        variablesContextMenu.ShowImageMargin = false;
        variablesContextMenu.Size = new System.Drawing.Size(36, 4);
        // 
        // TextSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(btnAddVariable);
        Controls.Add(textBox);
        Name = "TextSelector";
        Size = new System.Drawing.Size(709, 216);
        ResumeLayout(false);

    }

    #endregion

    // 字段声明：文本选择器的所有UI控件
    private RoundedTextBox textBox;  // 文本输入框（多行）
    private ButtonPrimary btnAddVariable;  // 添加变量按钮
    private System.Windows.Forms.ContextMenuStrip variablesContextMenu;  // 变量右键菜单
}
