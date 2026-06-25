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
        // 创建通知动作的配置界面控件
        title = new RoundedTextBox();
        message = new RoundedTextBox();
        lblTitle = new System.Windows.Forms.Label();
        lblMessage = new System.Windows.Forms.Label();
        SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // title - 通知标题输入框
        //
        title.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);  // 深色背景
        title.Cursor = System.Windows.Forms.Cursors.Hand;
        title.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);  // 斜体字体
        title.Icon = null;
        title.Location = new System.Drawing.Point(183, 63);
        title.MaxCharacters = 32767;  // 最大字符数限制
        title.Multiline = false;  // 单行输入
        title.Name = "title";
        title.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        title.PasswordChar = false;
        title.PlaceHolderColor = System.Drawing.Color.Gray;
        title.PlaceHolderText = "Title";  // 占位提示文字
        title.ReadOnly = false;
        title.ScrollBars = System.Windows.Forms.ScrollBars.None;
        title.SelectionStart = 0;
        title.Size = new System.Drawing.Size(469, 29);
        title.TabIndex = 5;
        title.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // message - 通知内容输入框（多行）
        //
        message.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);  // 深色背景
        message.Cursor = System.Windows.Forms.Cursors.Hand;
        message.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);  // 斜体字体
        message.Icon = null;
        message.Location = new System.Drawing.Point(183, 98);
        message.MaxCharacters = 32767;  // 最大字符数限制
        message.Multiline = true;  // 支持多行输入
        message.Name = "message";
        message.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        message.PasswordChar = false;
        message.PlaceHolderColor = System.Drawing.Color.Gray;
        message.PlaceHolderText = "Message";  // 占位提示文字
        message.ReadOnly = false;
        message.ScrollBars = System.Windows.Forms.ScrollBars.None;
        message.SelectionStart = 0;
        message.Size = new System.Drawing.Size(513, 75);
        message.TabIndex = 8;
        message.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // lblTitle - 标题标签
        //
        lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblTitle.Location = new System.Drawing.Point(0, 63);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(174, 29);
        lblTitle.TabIndex = 9;
        lblTitle.Text = "Title:";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;  // 左对齐居中显示
        //
        // lblMessage - 消息内容标签
        //
        lblMessage.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMessage.Location = new System.Drawing.Point(0, 98);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new System.Drawing.Size(174, 75);
        lblMessage.TabIndex = 10;
        lblMessage.Text = "Message:";
        lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;  // 左对齐居中显示
        //
        // NotificationConfigurator - 通知配置器主控件
        //
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(lblMessage);
        Controls.Add(lblTitle);
        Controls.Add(message);
        Controls.Add(title);
        Name = "NotificationConfigurator";
        ResumeLayout(false);  // 恢复布局，应用所有属性设置
    }

    #endregion

    // 字段声明：通知配置器的所有UI控件
    private MacroDeck.GUI.CustomControls.RoundedTextBox title;  // 通知标题输入框
    private MacroDeck.GUI.CustomControls.RoundedTextBox message;  // 通知内容输入框（多行）
    private System.Windows.Forms.Label lblTitle;  // 标题标签
    private System.Windows.Forms.Label lblMessage;  // 消息内容标签
}