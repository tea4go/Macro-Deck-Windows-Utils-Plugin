
namespace SuchByte.WindowsUtils.GUI;

partial class FileFolderSelector
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
        btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        lblPath = new System.Windows.Forms.Label();
        path = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        lblChoose = new System.Windows.Forms.Label();
        SuspendLayout();
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
        btnBrowse.Location = new System.Drawing.Point(584, 121);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Progress = 0;
        btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(0, 46, 94);
        btnBrowse.Size = new System.Drawing.Size(50, 39);
        btnBrowse.TabIndex = 5;
        btnBrowse.Text = "...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.UseWindowsAccentColor = true;
        btnBrowse.WriteProgress = true;
        btnBrowse.Click += BtnBrowse_Click;
        // 
        // lblPath
        // 
        lblPath.Font = new System.Drawing.Font("微软雅黑", 12F);
        lblPath.Location = new System.Drawing.Point(3, 126);
        lblPath.Name = "lblPath";
        lblPath.Size = new System.Drawing.Size(83, 29);
        lblPath.TabIndex = 4;
        lblPath.Text = "Path:";
        lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // path
        // 
        path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        path.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        path.Cursor = System.Windows.Forms.Cursors.Hand;
        path.Font = new System.Drawing.Font("微软雅黑", 12F);
        path.Icon = null;
        path.Location = new System.Drawing.Point(92, 121);
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
        path.Size = new System.Drawing.Size(486, 42);
        path.TabIndex = 3;
        path.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblChoose
        // 
        lblChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        lblChoose.Font = new System.Drawing.Font("微软雅黑", 12F);
        lblChoose.Location = new System.Drawing.Point(3, 184);
        lblChoose.Name = "lblChoose";
        lblChoose.Size = new System.Drawing.Size(631, 64);
        lblChoose.TabIndex = 6;
        lblChoose.Text = "Choose a file or drag and drop it here";
        lblChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // FileFolderSelector
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(lblChoose);
        Controls.Add(btnBrowse);
        Controls.Add(lblPath);
        Controls.Add(path);
        Name = "FileFolderSelector";
        Size = new System.Drawing.Size(653, 424);
        ResumeLayout(false);

    }

    #endregion

    // 字段声明：文件/文件夹选择器的所有UI控件
    private MacroDeck.GUI.CustomControls.ButtonPrimary btnBrowse;  // 浏览按钮
    private System.Windows.Forms.Label lblPath;  // 路径标签
    private MacroDeck.GUI.CustomControls.RoundedTextBox path;  // 路径输入框
    private System.Windows.Forms.Label lblChoose;  // 拖拽提示标签
}
