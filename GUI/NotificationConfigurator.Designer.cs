using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class NotificationConfigurator
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

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
        title.Location = new System.Drawing.Point(183, 63);
        title.MaxCharacters = 32767;
        title.Multiline = false;
        title.Name = "title";
        title.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        title.PasswordChar = false;
        title.PlaceHolderColor = System.Drawing.Color.Gray;
        title.PlaceHolderText = "Title";
        title.ReadOnly = false;
        title.ScrollBars = System.Windows.Forms.ScrollBars.None;
        title.SelectionStart = 0;
        title.Size = new System.Drawing.Size(469, 29);
        title.TabIndex = 5;
        title.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // message
        // 
        message.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        message.Cursor = System.Windows.Forms.Cursors.Hand;
        message.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);
        message.Icon = null;
        message.Location = new System.Drawing.Point(183, 98);
        message.MaxCharacters = 32767;
        message.Multiline = true;
        message.Name = "message";
        message.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        message.PasswordChar = false;
        message.PlaceHolderColor = System.Drawing.Color.Gray;
        message.PlaceHolderText = "Message";
        message.ReadOnly = false;
        message.ScrollBars = System.Windows.Forms.ScrollBars.None;
        message.SelectionStart = 0;
        message.Size = new System.Drawing.Size(513, 75);
        message.TabIndex = 8;
        message.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblTitle.Location = new System.Drawing.Point(0, 63);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(174, 29);
        lblTitle.TabIndex = 9;
        lblTitle.Text = "Title:";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblMessage
        // 
        lblMessage.Font = new System.Drawing.Font("Tahoma", 11.25F);
        lblMessage.Location = new System.Drawing.Point(0, 98);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new System.Drawing.Size(174, 75);
        lblMessage.TabIndex = 10;
        lblMessage.Text = "Message:";
        lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // NotificationConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        Controls.Add(lblMessage);
        Controls.Add(lblTitle);
        Controls.Add(message);
        Controls.Add(title);
        Name = "NotificationConfigurator";
        ResumeLayout(false);
    }

    private MacroDeck.GUI.CustomControls.RoundedTextBox title;
    private MacroDeck.GUI.CustomControls.RoundedTextBox message;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblMessage;
}