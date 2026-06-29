
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class CommandSelector
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
        workingDirectory = new RoundedTextBox();
        lblWorkingDirectory = new System.Windows.Forms.Label();
        lblCommand = new System.Windows.Forms.Label();
        command = new RoundedTextBox();
        btnBrowse = new ButtonPrimary();
        checkSaveVariable = new System.Windows.Forms.CheckBox();
        variableName = new RoundedTextBox();
        variableType = new RoundedComboBox();
        SuspendLayout();
        // 
        // workingDirectory
        // 
        workingDirectory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        workingDirectory.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        workingDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
        workingDirectory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Italic);
        workingDirectory.Icon = null;
        workingDirectory.Location = new System.Drawing.Point(267, 144);
        workingDirectory.MaxCharacters = 32767;
        workingDirectory.Multiline = false;
        workingDirectory.Name = "workingDirectory";
        workingDirectory.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        workingDirectory.PasswordChar = false;
        workingDirectory.PlaceHolderColor = System.Drawing.Color.Gray;
        workingDirectory.PlaceHolderText = "(Optional) Select or drag and drop";
        workingDirectory.ReadOnly = false;
        workingDirectory.ScrollBars = System.Windows.Forms.ScrollBars.None;
        workingDirectory.SelectionStart = 0;
        workingDirectory.Size = new System.Drawing.Size(716, 44);
        workingDirectory.TabIndex = 8;
        workingDirectory.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblWorkingDirectory
        // 
        lblWorkingDirectory.Font = new System.Drawing.Font("微软雅黑", 12F);
        lblWorkingDirectory.Location = new System.Drawing.Point(8, 144);
        lblWorkingDirectory.Name = "lblWorkingDirectory";
        lblWorkingDirectory.Size = new System.Drawing.Size(174, 29);
        lblWorkingDirectory.TabIndex = 7;
        lblWorkingDirectory.Text = "Working directory:";
        lblWorkingDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        lblWorkingDirectory.Click += lblWorkingDirectory_Click;
        // 
        // lblCommand
        // 
        lblCommand.Font = new System.Drawing.Font("微软雅黑", 12F);
        lblCommand.Location = new System.Drawing.Point(8, 31);
        lblCommand.Name = "lblCommand";
        lblCommand.Size = new System.Drawing.Size(174, 75);
        lblCommand.TabIndex = 6;
        lblCommand.Text = "Command:";
        lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // command
        // 
        command.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        command.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        command.Cursor = System.Windows.Forms.Cursors.Hand;
        command.Font = new System.Drawing.Font("微软雅黑", 12F);
        command.Icon = null;
        command.Location = new System.Drawing.Point(267, 31);
        command.MaxCharacters = 32767;
        command.Multiline = true;
        command.Name = "command";
        command.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        command.PasswordChar = false;
        command.PlaceHolderColor = System.Drawing.Color.Gray;
        command.PlaceHolderText = "";
        command.ReadOnly = false;
        command.ScrollBars = System.Windows.Forms.ScrollBars.None;
        command.SelectionStart = 0;
        command.Size = new System.Drawing.Size(760, 75);
        command.TabIndex = 5;
        command.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // btnBrowse
        // 
        btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnBrowse.BorderRadius = 8;
        btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
        btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBrowse.Font = new System.Drawing.Font("微软雅黑", 9.75F);
        btnBrowse.ForeColor = System.Drawing.Color.White;
        btnBrowse.HoverColor = System.Drawing.Color.FromArgb(0, 89, 184);
        btnBrowse.Icon = null;
        btnBrowse.Location = new System.Drawing.Point(989, 144);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Progress = 0;
        btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(0, 46, 94);
        btnBrowse.Size = new System.Drawing.Size(41, 38);
        btnBrowse.TabIndex = 9;
        btnBrowse.Text = "...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.UseWindowsAccentColor = true;
        btnBrowse.WriteProgress = true;
        btnBrowse.Click += BtnBrowse_Click;
        // 
        // checkSaveVariable
        // 
        checkSaveVariable.AutoSize = true;
        checkSaveVariable.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkSaveVariable.Location = new System.Drawing.Point(8, 214);
        checkSaveVariable.Name = "checkSaveVariable";
        checkSaveVariable.Size = new System.Drawing.Size(306, 35);
        checkSaveVariable.TabIndex = 10;
        checkSaveVariable.Text = "Save output to variable";
        checkSaveVariable.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        checkSaveVariable.UseVisualStyleBackColor = true;
        checkSaveVariable.CheckedChanged += CheckSaveVariable_CheckedChanged;
        // 
        // variableName
        // 
        variableName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        variableName.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        variableName.Cursor = System.Windows.Forms.Cursors.Hand;
        variableName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Italic);
        variableName.Icon = null;
        variableName.Location = new System.Drawing.Point(267, 213);
        variableName.MaxCharacters = 32767;
        variableName.Multiline = false;
        variableName.Name = "variableName";
        variableName.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        variableName.PasswordChar = false;
        variableName.PlaceHolderColor = System.Drawing.Color.Gray;
        variableName.PlaceHolderText = "Variable name";
        variableName.ReadOnly = false;
        variableName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        variableName.SelectionStart = 0;
        variableName.Size = new System.Drawing.Size(633, 42);
        variableName.TabIndex = 11;
        variableName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        variableName.Visible = false;
        // 
        // variableType
        // 
        variableType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        variableType.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        variableType.Cursor = System.Windows.Forms.Cursors.Hand;
        variableType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        variableType.Font = new System.Drawing.Font("微软雅黑", 9.75F);
        variableType.Icon = null;
        variableType.Location = new System.Drawing.Point(906, 214);
        variableType.Margin = new System.Windows.Forms.Padding(0);
        variableType.Name = "variableType";
        variableType.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        variableType.SelectedIndex = -1;
        variableType.SelectedItem = null;
        variableType.Size = new System.Drawing.Size(121, 39);
        variableType.TabIndex = 12;
        variableType.Visible = false;
        // 
        // CommandSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(variableType);
        Controls.Add(variableName);
        Controls.Add(checkSaveVariable);
        Controls.Add(btnBrowse);
        Controls.Add(workingDirectory);
        Controls.Add(lblWorkingDirectory);
        Controls.Add(lblCommand);
        Controls.Add(command);
        Name = "CommandSelector";
        Size = new System.Drawing.Size(1055, 424);
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    // 字段声明：命令行选择器的所有UI控件
    private MacroDeck.GUI.CustomControls.RoundedTextBox workingDirectory;  // 工作目录输入框
    private System.Windows.Forms.Label lblWorkingDirectory;  // 工作目录标签
    private System.Windows.Forms.Label lblCommand;  // 命令行标签
    private MacroDeck.GUI.CustomControls.RoundedTextBox command;  // 命令行输入框
    private MacroDeck.GUI.CustomControls.ButtonPrimary btnBrowse;  // 浏览按钮
    private System.Windows.Forms.CheckBox checkSaveVariable;  // 保存到变量复选框
    private MacroDeck.GUI.CustomControls.RoundedTextBox variableName;  // 变量名输入框
    private RoundedComboBox variableType;  // 变量类型下拉选择框
}
