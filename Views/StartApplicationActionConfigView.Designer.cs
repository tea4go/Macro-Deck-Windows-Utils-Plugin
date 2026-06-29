
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class StartApplicationActionConfigView
{
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
        path = new RoundedTextBox();
        lblPath = new System.Windows.Forms.Label();
        btnBrowse = new ButtonPrimary();
        lblArguments = new System.Windows.Forms.Label();
        arguments = new RoundedTextBox();
        checkRunAsAdmin = new System.Windows.Forms.CheckBox();
        label1 = new System.Windows.Forms.Label();
        method = new RoundedComboBox();
        checkSyncButtonState = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // path
        // 
        path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        path.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        path.Cursor = System.Windows.Forms.Cursors.Hand;
        path.Font = new System.Drawing.Font("微软雅黑", 14F);
        path.Icon = null;
        path.Location = new System.Drawing.Point(201, 19);
        path.MaxCharacters = 32767;
        path.Multiline = false;
        path.Name = "path";
        path.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        path.PasswordChar = false;
        path.PlaceHolderColor = System.Drawing.Color.Gray;
        path.PlaceHolderText = "";
        path.ReadOnly = false;
        path.ScrollBars = System.Windows.Forms.ScrollBars.None;
        path.SelectionStart = 0;
        path.Size = new System.Drawing.Size(396, 47);
        path.TabIndex = 1;
        path.TabStop = false;
        path.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblPath
        // 
        lblPath.AutoSize = true;
        lblPath.Font = new System.Drawing.Font("微软雅黑", 14F);
        lblPath.Location = new System.Drawing.Point(20, 28);
        lblPath.Name = "lblPath";
        lblPath.Size = new System.Drawing.Size(81, 36);
        lblPath.TabIndex = 1;
        lblPath.Text = "Path:";
        lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnBrowse
        // 
        btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnBrowse.BorderRadius = 8;
        btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
        btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBrowse.Font = new System.Drawing.Font("微软雅黑", 14F);
        btnBrowse.ForeColor = System.Drawing.Color.White;
        btnBrowse.HoverColor = System.Drawing.Color.FromArgb(0, 89, 184);
        btnBrowse.Icon = null;
        btnBrowse.Location = new System.Drawing.Point(603, 19);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Progress = 0;
        btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(0, 46, 94);
        btnBrowse.Size = new System.Drawing.Size(49, 47);
        btnBrowse.TabIndex = 2;
        btnBrowse.Text = "...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.UseWindowsAccentColor = true;
        btnBrowse.WriteProgress = true;
        btnBrowse.Click += BtnBrowse_Click;
        // 
        // lblArguments
        // 
        lblArguments.AutoSize = true;
        lblArguments.Font = new System.Drawing.Font("微软雅黑", 14F);
        lblArguments.Location = new System.Drawing.Point(20, 81);
        lblArguments.Name = "lblArguments";
        lblArguments.Size = new System.Drawing.Size(170, 36);
        lblArguments.TabIndex = 3;
        lblArguments.Text = "Arguments:";
        lblArguments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // arguments
        // 
        arguments.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        arguments.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        arguments.Cursor = System.Windows.Forms.Cursors.Hand;
        arguments.Font = new System.Drawing.Font("微软雅黑", 14F);
        arguments.Icon = null;
        arguments.Location = new System.Drawing.Point(201, 81);
        arguments.MaxCharacters = 32767;
        arguments.Multiline = false;
        arguments.Name = "arguments";
        arguments.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        arguments.PasswordChar = false;
        arguments.PlaceHolderColor = System.Drawing.Color.Gray;
        arguments.PlaceHolderText = "";
        arguments.ReadOnly = false;
        arguments.ScrollBars = System.Windows.Forms.ScrollBars.None;
        arguments.SelectionStart = 0;
        arguments.Size = new System.Drawing.Size(451, 47);
        arguments.TabIndex = 4;
        arguments.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // checkRunAsAdmin
        // 
        checkRunAsAdmin.AutoSize = true;
        checkRunAsAdmin.Font = new System.Drawing.Font("微软雅黑", 14F);
        checkRunAsAdmin.Location = new System.Drawing.Point(292, 224);
        checkRunAsAdmin.Name = "checkRunAsAdmin";
        checkRunAsAdmin.Size = new System.Drawing.Size(265, 40);
        checkRunAsAdmin.TabIndex = 8;
        checkRunAsAdmin.Text = "以管理员权限运行";
        checkRunAsAdmin.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("微软雅黑", 14F);
        label1.Location = new System.Drawing.Point(20, 155);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(71, 36);
        label1.TabIndex = 9;
        label1.Text = "模式";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // method
        // 
        method.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        method.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        method.Cursor = System.Windows.Forms.Cursors.Hand;
        method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        method.Font = new System.Drawing.Font("微软雅黑", 14F);
        method.Icon = null;
        method.Location = new System.Drawing.Point(201, 145);
        method.Name = "method";
        method.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        method.SelectedIndex = -1;
        method.SelectedItem = null;
        method.Size = new System.Drawing.Size(451, 48);
        method.TabIndex = 10;
        // 
        // checkSyncButtonState
        // 
        checkSyncButtonState.AutoSize = true;
        checkSyncButtonState.Font = new System.Drawing.Font("微软雅黑", 14F);
        checkSyncButtonState.Location = new System.Drawing.Point(20, 224);
        checkSyncButtonState.Name = "checkSyncButtonState";
        checkSyncButtonState.Size = new System.Drawing.Size(209, 40);
        checkSyncButtonState.TabIndex = 11;
        checkSyncButtonState.Text = "同步按钮状态";
        checkSyncButtonState.UseVisualStyleBackColor = true;
        // 
        // StartApplicationActionConfigView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(lblPath);
        Controls.Add(path);
        Controls.Add(btnBrowse);
        Controls.Add(checkSyncButtonState);
        Controls.Add(lblArguments);
        Controls.Add(method);
        Controls.Add(arguments);
        Controls.Add(label1);
        Controls.Add(checkRunAsAdmin);
        Name = "StartApplicationActionConfigView";
        Size = new System.Drawing.Size(682, 310);
        Load += StartApplicationActionConfigView_Load;
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private RoundedTextBox path;
    private System.Windows.Forms.Label lblPath;
    private ButtonPrimary btnBrowse;
    private System.Windows.Forms.Label lblArguments;
    private RoundedTextBox arguments;
    private System.Windows.Forms.CheckBox checkRunAsAdmin;
    private System.Windows.Forms.Label label1;
    private RoundedComboBox method;
    private System.Windows.Forms.CheckBox checkSyncButtonState;
}
