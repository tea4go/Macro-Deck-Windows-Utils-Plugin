
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
        // 创建文件/文件夹路径选择器的配置界面控件
        this.btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.lblPath = new System.Windows.Forms.Label();
        this.path = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.lblChoose = new System.Windows.Forms.Label();
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
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
        this.btnBrowse.Location = new System.Drawing.Point(584, 121);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Progress = 0;
        this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnBrowse.Size = new System.Drawing.Size(38, 29);
        this.btnBrowse.TabIndex = 5;
        this.btnBrowse.Text = "...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);  // 浏览按钮点击事件
        //
        // lblPath - 路径标签
        //
        this.lblPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblPath.Location = new System.Drawing.Point(3, 121);
        this.lblPath.Name = "lblPath";
        this.lblPath.Size = new System.Drawing.Size(83, 29);
        this.lblPath.TabIndex = 4;
        this.lblPath.Text = "Path:";
        this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // path - 路径输入框
        //
        this.path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.path.Cursor = System.Windows.Forms.Cursors.Hand;
        this.path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.path.Icon = null;
        this.path.Location = new System.Drawing.Point(92, 121);
        this.path.Multiline = false;  // 单行输入
        this.path.Name = "path";
        this.path.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.path.PasswordChar = false;
        this.path.PlaceHolderColor = System.Drawing.Color.Gray;
        this.path.PlaceHolderText = "";
        this.path.ReadOnly = false;
        this.path.SelectionStart = 0;
        this.path.Size = new System.Drawing.Size(486, 29);
        this.path.TabIndex = 3;
        this.path.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        //
        // lblChoose - 拖拽提示标签
        //
        this.lblChoose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblChoose.Location = new System.Drawing.Point(3, 184);
        this.lblChoose.Name = "lblChoose";
        this.lblChoose.Size = new System.Drawing.Size(709, 64);
        this.lblChoose.TabIndex = 6;
        this.lblChoose.Text = "Choose a file or drag and drop it here";
        this.lblChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;  // 居中提示文字
        //
        // FileFolderSelector - 文件/文件夹选择器主控件
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.lblChoose);
        this.Controls.Add(this.btnBrowse);
        this.Controls.Add(this.lblPath);
        this.Controls.Add(this.path);
        this.Name = "FileFolderSelector";
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置

    }

    #endregion

    // 字段声明：文件/文件夹选择器的所有UI控件
    private MacroDeck.GUI.CustomControls.ButtonPrimary btnBrowse;  // 浏览按钮
    private System.Windows.Forms.Label lblPath;  // 路径标签
    private MacroDeck.GUI.CustomControls.RoundedTextBox path;  // 路径输入框
    private System.Windows.Forms.Label lblChoose;  // 拖拽提示标签
}
