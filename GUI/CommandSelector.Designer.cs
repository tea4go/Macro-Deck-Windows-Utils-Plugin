
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
        // 创建命令行执行动作的配置界面控件
        this.workingDirectory = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.lblWorkingDirectory = new System.Windows.Forms.Label();
        this.lblCommand = new System.Windows.Forms.Label();
        this.command = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.checkSaveVariable = new System.Windows.Forms.CheckBox();
        this.variableName = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.variableType = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // workingDirectory - 工作目录输入框
        //
        this.workingDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.workingDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
        this.workingDirectory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.workingDirectory.Icon = null;
        this.workingDirectory.Location = new System.Drawing.Point(183, 144);
        this.workingDirectory.Multiline = false;
        this.workingDirectory.Name = "workingDirectory";
        this.workingDirectory.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.workingDirectory.PasswordChar = false;
        this.workingDirectory.PlaceHolderColor = System.Drawing.Color.Gray;
        this.workingDirectory.PlaceHolderText = "(Optional) Select or drag and drop";
        this.workingDirectory.ReadOnly = false;
        this.workingDirectory.SelectionStart = 0;
        this.workingDirectory.Size = new System.Drawing.Size(469, 29);
        this.workingDirectory.TabIndex = 8;
        this.workingDirectory.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // lblWorkingDirectory - 工作目录标签
        //
        this.lblWorkingDirectory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblWorkingDirectory.Location = new System.Drawing.Point(3, 144);
        this.lblWorkingDirectory.Name = "lblWorkingDirectory";
        this.lblWorkingDirectory.Size = new System.Drawing.Size(174, 29);
        this.lblWorkingDirectory.TabIndex = 7;
        this.lblWorkingDirectory.Text = "Working directory:";
        this.lblWorkingDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblWorkingDirectory.Click += new System.EventHandler(this.lblWorkingDirectory_Click);
        //
        // lblCommand - 命令行标签
        //
        this.lblCommand.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblCommand.Location = new System.Drawing.Point(3, 63);
        this.lblCommand.Name = "lblCommand";
        this.lblCommand.Size = new System.Drawing.Size(174, 75);
        this.lblCommand.TabIndex = 6;
        this.lblCommand.Text = "Command:";
        this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // command - 命令行输入框（支持多行）
        //
        this.command.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.command.Cursor = System.Windows.Forms.Cursors.Hand;
        this.command.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.command.Icon = null;
        this.command.Location = new System.Drawing.Point(183, 63);
        this.command.Multiline = true;  // 支持多行输入
        this.command.Name = "command";
        this.command.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.command.PasswordChar = false;
        this.command.PlaceHolderColor = System.Drawing.Color.Gray;
        this.command.PlaceHolderText = "";
        this.command.ReadOnly = false;
        this.command.SelectionStart = 0;
        this.command.Size = new System.Drawing.Size(513, 75);
        this.command.TabIndex = 5;
        this.command.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // btnBrowse - 浏览按钮
        //
        this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnBrowse.BorderRadius = 8;  // 圆角边框
        this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBrowse.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnBrowse.ForeColor = System.Drawing.Color.White;  // 白色前景文字
        this.btnBrowse.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));  // 悬停时的颜色
        this.btnBrowse.Icon = null;
        this.btnBrowse.Location = new System.Drawing.Point(658, 144);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Progress = 0;
        this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnBrowse.Size = new System.Drawing.Size(38, 29);
        this.btnBrowse.TabIndex = 9;
        this.btnBrowse.Text = "...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
        //
        // checkSaveVariable - 保存到变量的复选框
        //
        this.checkSaveVariable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkSaveVariable.Location = new System.Drawing.Point(3, 180);
        this.checkSaveVariable.Name = "checkSaveVariable";
        this.checkSaveVariable.Size = new System.Drawing.Size(174, 49);
        this.checkSaveVariable.TabIndex = 10;
        this.checkSaveVariable.AutoSize = true;  // 自动调整大小
        this.checkSaveVariable.Text = "Save output to variable";
        this.checkSaveVariable.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkSaveVariable.UseVisualStyleBackColor = true;
        this.checkSaveVariable.CheckedChanged += new System.EventHandler(this.CheckSaveVariable_CheckedChanged);  // 勾选状态变更事件
        //
        // variableName - 变量名输入框（默认隐藏）
        //
        this.variableName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.variableName.Cursor = System.Windows.Forms.Cursors.Hand;
        this.variableName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.variableName.Icon = null;
        this.variableName.Location = new System.Drawing.Point(183, 179);
        this.variableName.Multiline = false;
        this.variableName.Name = "variableName";
        this.variableName.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.variableName.PasswordChar = false;
        this.variableName.PlaceHolderColor = System.Drawing.Color.Gray;
        this.variableName.PlaceHolderText = "Variable name";
        this.variableName.ReadOnly = false;
        this.variableName.SelectionStart = 0;
        this.variableName.Size = new System.Drawing.Size(386, 29);
        this.variableName.TabIndex = 11;
        this.variableName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        this.variableName.Visible = false;  // 初始隐藏，勾选复选框后显示
        //
        // variableType - 变量类型下拉框（默认隐藏）
        //
        this.variableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.variableType.Cursor = System.Windows.Forms.Cursors.Hand;
        this.variableType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  // 只允许选择，不允许输入
        this.variableType.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.variableType.Icon = null;
        this.variableType.Location = new System.Drawing.Point(575, 180);
        this.variableType.Name = "variableType";
        this.variableType.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        this.variableType.SelectedIndex = -1;  // 无默认选中项
        this.variableType.SelectedItem = null;
        this.variableType.Size = new System.Drawing.Size(121, 28);
        this.variableType.TabIndex = 12;
        this.variableType.Visible = false;  // 初始隐藏，勾选复选框后显示
        //
        // CommandSelector - 命令行选择器主控件
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.variableType);
        this.Controls.Add(this.variableName);
        this.Controls.Add(this.checkSaveVariable);
        this.Controls.Add(this.btnBrowse);
        this.Controls.Add(this.workingDirectory);
        this.Controls.Add(this.lblWorkingDirectory);
        this.Controls.Add(this.lblCommand);
        this.Controls.Add(this.command);
        this.Name = "CommandSelector";
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置

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
