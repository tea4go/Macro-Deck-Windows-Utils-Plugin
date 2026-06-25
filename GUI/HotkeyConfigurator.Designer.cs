
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class HotkeyConfigurator
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
        // 创建热键配置器的界面控件（支持左右区分修饰键 + Win键 + 主键选择）
        this.checkCtrl = new System.Windows.Forms.CheckBox();
        this.checkShift = new System.Windows.Forms.CheckBox();
        this.checkAlt = new System.Windows.Forms.CheckBox();
        this.key = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.lblDetails = new System.Windows.Forms.LinkLabel();
        this.checkLCtrl = new System.Windows.Forms.CheckBox();
        this.checkRCtrl = new System.Windows.Forms.CheckBox();
        this.checkLShift = new System.Windows.Forms.CheckBox();
        this.checkRShift = new System.Windows.Forms.CheckBox();
        this.checkLAlt = new System.Windows.Forms.CheckBox();
        this.checkRAlt = new System.Windows.Forms.CheckBox();
        this.checkRWin = new System.Windows.Forms.CheckBox();
        this.checkLWin = new System.Windows.Forms.CheckBox();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // checkCtrl - "CTRL"修饰键复选框（简单模式）
        //
        this.checkCtrl.AutoSize = true;  // 自动调整大小
        this.checkCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkCtrl.Location = new System.Drawing.Point(163, 124);
        this.checkCtrl.Name = "checkCtrl";
        this.checkCtrl.Size = new System.Drawing.Size(66, 23);
        this.checkCtrl.TabIndex = 0;
        this.checkCtrl.Text = "CTRL";
        this.checkCtrl.UseVisualStyleBackColor = true;
        //
        // checkShift - "Shift"修饰键复选框（简单模式）
        //
        this.checkShift.AutoSize = true;
        this.checkShift.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkShift.Location = new System.Drawing.Point(271, 124);
        this.checkShift.Name = "checkShift";
        this.checkShift.Size = new System.Drawing.Size(60, 23);
        this.checkShift.TabIndex = 1;
        this.checkShift.Text = "Shift";
        this.checkShift.UseVisualStyleBackColor = true;
        //
        // checkAlt - "Alt"修饰键复选框（简单模式）
        //
        this.checkAlt.AutoSize = true;
        this.checkAlt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkAlt.Location = new System.Drawing.Point(374, 124);
        this.checkAlt.Name = "checkAlt";
        this.checkAlt.Size = new System.Drawing.Size(48, 23);
        this.checkAlt.TabIndex = 2;
        this.checkAlt.Text = "Alt";
        this.checkAlt.UseVisualStyleBackColor = true;
        //
        // key - 主键选择下拉框
        //
        this.key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.key.Cursor = System.Windows.Forms.Cursors.Hand;
        this.key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  // 只允许从列表中选择
        this.key.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.key.Icon = null;
        this.key.Location = new System.Drawing.Point(460, 120);
        this.key.Name = "key";
        this.key.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        this.key.SelectedIndex = -1;  // 无默认选中项
        this.key.SelectedItem = null;
        this.key.Size = new System.Drawing.Size(200, 31);
        this.key.TabIndex = 3;
        //
        // label1 - "+"分隔符（CTRL与Shift之间）
        //
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label1.Location = new System.Drawing.Point(241, 127);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(21, 19);
        this.label1.TabIndex = 4;
        this.label1.Text = "+";
        //
        // label2 - "+"分隔符（Shift与Alt之间）
        //
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label2.Location = new System.Drawing.Point(344, 127);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(21, 19);
        this.label2.TabIndex = 5;
        this.label2.Text = "+";
        //
        // label3 - "+"分隔符（Alt与主键之间）
        //
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label3.Location = new System.Drawing.Point(430, 127);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(21, 19);
        this.label3.TabIndex = 6;
        this.label3.Text = "+";
        //
        // lblDetails - 帮助链接标签
        //
        this.lblDetails.ActiveLinkColor = System.Drawing.Color.Silver;  // 点击时的链接颜色
        this.lblDetails.AutoSize = true;
        this.lblDetails.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblDetails.LinkColor = System.Drawing.Color.Silver;  // 默认链接颜色
        this.lblDetails.Location = new System.Drawing.Point(666, 126);
        this.lblDetails.Name = "lblDetails";
        this.lblDetails.Size = new System.Drawing.Size(15, 18);
        this.lblDetails.TabIndex = 7;
        this.lblDetails.TabStop = true;
        this.lblDetails.Text = "-=？=-";
        this.lblDetails.VisitedLinkColor = System.Drawing.Color.Silver;  // 访问后的链接颜色
        this.lblDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblDetails_LinkClicked);  // 点击查看详细说明
        //
        // checkLCtrl - 左CTRL复选框（高级模式）
        //
        this.checkLCtrl.AutoSize = true;
        this.checkLCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkLCtrl.Location = new System.Drawing.Point(163, 97);
        this.checkLCtrl.Name = "checkLCtrl";
        this.checkLCtrl.Size = new System.Drawing.Size(74, 23);
        this.checkLCtrl.TabIndex = 8;
        this.checkLCtrl.Text = "LCTRL";
        this.checkLCtrl.UseVisualStyleBackColor = true;
        //
        // checkRCtrl - 右CTRL复选框（高级模式）
        //
        this.checkRCtrl.AutoSize = true;
        this.checkRCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkRCtrl.Location = new System.Drawing.Point(163, 151);
        this.checkRCtrl.Name = "checkRCtrl";
        this.checkRCtrl.Size = new System.Drawing.Size(76, 23);
        this.checkRCtrl.TabIndex = 9;
        this.checkRCtrl.Text = "RCTRL";
        this.checkRCtrl.UseVisualStyleBackColor = true;
        //
        // checkLShift - 左Shift复选框（高级模式）
        //
        this.checkLShift.AutoSize = true;
        this.checkLShift.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkLShift.Location = new System.Drawing.Point(271, 97);
        this.checkLShift.Name = "checkLShift";
        this.checkLShift.Size = new System.Drawing.Size(68, 23);
        this.checkLShift.TabIndex = 10;
        this.checkLShift.Text = "LShift";
        this.checkLShift.UseVisualStyleBackColor = true;
        //
        // checkRShift - 右Shift复选框（高级模式）
        //
        this.checkRShift.AutoSize = true;
        this.checkRShift.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkRShift.Location = new System.Drawing.Point(271, 151);
        this.checkRShift.Name = "checkRShift";
        this.checkRShift.Size = new System.Drawing.Size(70, 23);
        this.checkRShift.TabIndex = 11;
        this.checkRShift.Text = "RShift";
        this.checkRShift.UseVisualStyleBackColor = true;
        //
        // checkLAlt - 左Alt复选框（高级模式）
        //
        this.checkLAlt.AutoSize = true;
        this.checkLAlt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkLAlt.Location = new System.Drawing.Point(374, 97);
        this.checkLAlt.Name = "checkLAlt";
        this.checkLAlt.Size = new System.Drawing.Size(56, 23);
        this.checkLAlt.TabIndex = 12;
        this.checkLAlt.Text = "LAlt";
        this.checkLAlt.UseVisualStyleBackColor = true;
        //
        // checkRAlt - 右Alt复选框（高级模式）
        //
        this.checkRAlt.AutoSize = true;
        this.checkRAlt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkRAlt.Location = new System.Drawing.Point(374, 151);
        this.checkRAlt.Name = "checkRAlt";
        this.checkRAlt.Size = new System.Drawing.Size(58, 23);
        this.checkRAlt.TabIndex = 13;
        this.checkRAlt.Text = "RAlt";
        this.checkRAlt.UseVisualStyleBackColor = true;
        //
        // checkRWin - 右Win键复选框（高级模式）
        //
        this.checkRWin.AutoSize = true;
        this.checkRWin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkRWin.Location = new System.Drawing.Point(55, 137);
        this.checkRWin.Name = "checkRWin";
        this.checkRWin.Size = new System.Drawing.Size(69, 23);
        this.checkRWin.TabIndex = 17;
        this.checkRWin.Text = "RWIN";
        this.checkRWin.UseVisualStyleBackColor = true;
        //
        // checkLWin - 左Win键复选框（高级模式）
        //
        this.checkLWin.AutoSize = true;
        this.checkLWin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkLWin.Location = new System.Drawing.Point(55, 110);
        this.checkLWin.Name = "checkLWin";
        this.checkLWin.Size = new System.Drawing.Size(67, 23);
        this.checkLWin.TabIndex = 16;
        this.checkLWin.Text = "LWIN";
        this.checkLWin.UseVisualStyleBackColor = true;
        //
        // label4 - "+"分隔符（Win键与修饰键之间）
        //
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label4.Location = new System.Drawing.Point(133, 128);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(21, 19);
        this.label4.TabIndex = 15;
        this.label4.Text = "+";
        //
        // HotkeyConfigurator - 热键配置器主控件
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.checkRWin);
        this.Controls.Add(this.checkLWin);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.checkRAlt);
        this.Controls.Add(this.checkLAlt);
        this.Controls.Add(this.checkRShift);
        this.Controls.Add(this.checkLShift);
        this.Controls.Add(this.checkRCtrl);
        this.Controls.Add(this.checkLCtrl);
        this.Controls.Add(this.lblDetails);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.key);
        this.Controls.Add(this.checkAlt);
        this.Controls.Add(this.checkShift);
        this.Controls.Add(this.checkCtrl);
        this.Name = "HotkeyConfigurator";
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置
        this.PerformLayout();  // 强制立即布局计算

    }

    #endregion

    // 字段声明：热键配置器的所有UI控件
    private System.Windows.Forms.CheckBox checkCtrl;  // 简单模式CTRL复选框
    private System.Windows.Forms.CheckBox checkShift;  // 简单模式Shift复选框
    private System.Windows.Forms.CheckBox checkAlt;  // 简单模式Alt复选框
    private RoundedComboBox key;  // 主键选择下拉框
    private System.Windows.Forms.Label label1;  // "+"分隔符（CTRL与Shift之间）
    private System.Windows.Forms.Label label2;  // "+"分隔符（Shift与Alt之间）
    private System.Windows.Forms.Label label3;  // "+"分隔符（Alt与主键之间）
    private System.Windows.Forms.LinkLabel lblDetails;  // 帮助链接标签
    private System.Windows.Forms.CheckBox checkLCtrl;  // 左CTRL复选框（高级模式）
    private System.Windows.Forms.CheckBox checkRCtrl;  // 右CTRL复选框（高级模式）
    private System.Windows.Forms.CheckBox checkLShift;  // 左Shift复选框（高级模式）
    private System.Windows.Forms.CheckBox checkRShift;  // 右Shift复选框（高级模式）
    private System.Windows.Forms.CheckBox checkLAlt;  // 左Alt复选框（高级模式）
    private System.Windows.Forms.CheckBox checkRAlt;  // 右Alt复选框（高级模式）
    private System.Windows.Forms.CheckBox checkRWin;  // 右Win键复选框（高级模式）
    private System.Windows.Forms.CheckBox checkLWin;  // 左Win键复选框（高级模式）
    private System.Windows.Forms.Label label4;  // "+"分隔符（Win键与修饰键之间）
}
