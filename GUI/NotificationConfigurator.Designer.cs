using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class NotificationConfigurator
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
        title = new RoundedTextBox();
        message = new RoundedTextBox();
        lblTitle = new System.Windows.Forms.Label();
        lblMessage = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // title
        // 
        title.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        title.Cursor = System.Windows.Forms.Cursors.Hand;
        title.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);
        title.Icon = null;
        title.Location = new System.Drawing.Point(229, 79);
        title.Margin = new System.Windows.Forms.Padding(4);
        title.MaxCharacters = 32767;
        title.Multiline = false;
        title.Name = "title";
        title.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        title.PasswordChar = false;
        title.PlaceHolderColor = System.Drawing.Color.Gray;
        title.PlaceHolderText = "Title";
        title.ReadOnly = false;
        title.ScrollBars = System.Windows.Forms.ScrollBars.None;
        title.SelectionStart = 0;
        title.Size = new System.Drawing.Size(641, 36);
        title.TabIndex = 5;
        title.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // message
        // 
        message.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        message.Cursor = System.Windows.Forms.Cursors.Hand;
        message.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);
        message.Icon = null;
        message.Location = new System.Drawing.Point(229, 135);
        message.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        message.MaxCharacters = 32767;
        message.Multiline = true;
        message.Name = "message";
        message.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        message.PasswordChar = false;
        message.PlaceHolderColor = System.Drawing.Color.Gray;
        message.PlaceHolderText = "Message";
        message.ReadOnly = false;
        message.ScrollBars = System.Windows.Forms.ScrollBars.None;
        message.SelectionStart = 0;
        message.Size = new System.Drawing.Size(641, 94);
        message.TabIndex = 8;
        message.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblTitle.Location = new System.Drawing.Point(0, 79);
        lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(218, 36);
        lblTitle.TabIndex = 9;
        lblTitle.Text = "Title:";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblMessage
        // 
        lblMessage.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMessage.Location = new System.Drawing.Point(0, 135);
        lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new System.Drawing.Size(218, 94);
        lblMessage.TabIndex = 10;
        lblMessage.Text = "Message:";
        lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // NotificationConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
        Controls.Add(lblMessage);
        Controls.Add(lblTitle);
        Controls.Add(message);
        Controls.Add(title);
        Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        Name = "NotificationConfigurator";
        Size = new System.Drawing.Size(1071, 530);
        ResumeLayout(false);
    }

    #endregion

    // 字段声明：通知配置器的所有UI控件
    private MacroDeck.GUI.CustomControls.RoundedTextBox title;  // 通知标题输入框
    private MacroDeck.GUI.CustomControls.RoundedTextBox message;  // 通知内容输入框（多行）
    private System.Windows.Forms.Label lblTitle;  // 标题标签
    private System.Windows.Forms.Label lblMessage;  // 消息内容标签
}