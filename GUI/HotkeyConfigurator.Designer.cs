
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
        checkCtrl = new System.Windows.Forms.CheckBox();
        checkShift = new System.Windows.Forms.CheckBox();
        checkAlt = new System.Windows.Forms.CheckBox();
        key = new RoundedComboBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        lblDetails = new System.Windows.Forms.LinkLabel();
        checkLCtrl = new System.Windows.Forms.CheckBox();
        checkRCtrl = new System.Windows.Forms.CheckBox();
        checkLShift = new System.Windows.Forms.CheckBox();
        checkRShift = new System.Windows.Forms.CheckBox();
        checkLAlt = new System.Windows.Forms.CheckBox();
        checkRAlt = new System.Windows.Forms.CheckBox();
        checkRWin = new System.Windows.Forms.CheckBox();
        checkLWin = new System.Windows.Forms.CheckBox();
        label4 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // checkCtrl
        // 
        checkCtrl.AutoSize = true;
        checkCtrl.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkCtrl.Location = new System.Drawing.Point(163, 124);
        checkCtrl.Name = "checkCtrl";
        checkCtrl.Size = new System.Drawing.Size(81, 31);
        checkCtrl.TabIndex = 0;
        checkCtrl.Text = "CTRL";
        checkCtrl.UseVisualStyleBackColor = true;
        // 
        // checkShift
        // 
        checkShift.AutoSize = true;
        checkShift.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkShift.Location = new System.Drawing.Point(271, 124);
        checkShift.Name = "checkShift";
        checkShift.Size = new System.Drawing.Size(77, 31);
        checkShift.TabIndex = 1;
        checkShift.Text = "Shift";
        checkShift.UseVisualStyleBackColor = true;
        // 
        // checkAlt
        // 
        checkAlt.AutoSize = true;
        checkAlt.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkAlt.Location = new System.Drawing.Point(374, 124);
        checkAlt.Name = "checkAlt";
        checkAlt.Size = new System.Drawing.Size(60, 31);
        checkAlt.TabIndex = 2;
        checkAlt.Text = "Alt";
        checkAlt.UseVisualStyleBackColor = true;
        // 
        // key
        // 
        key.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
        key.Cursor = System.Windows.Forms.Cursors.Hand;
        key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        key.Font = new System.Drawing.Font("微软雅黑", 12F);
        key.Icon = null;
        key.Location = new System.Drawing.Point(460, 120);
        key.Margin = new System.Windows.Forms.Padding(4);
        key.Name = "key";
        key.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
        key.SelectedIndex = -1;
        key.SelectedItem = null;
        key.Size = new System.Drawing.Size(200, 39);
        key.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("微软雅黑", 12F);
        label1.Location = new System.Drawing.Point(241, 127);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(27, 27);
        label1.TabIndex = 4;
        label1.Text = "+";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new System.Drawing.Font("微软雅黑", 12F);
        label2.Location = new System.Drawing.Point(344, 127);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(27, 27);
        label2.TabIndex = 5;
        label2.Text = "+";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new System.Drawing.Font("微软雅黑", 12F);
        label3.Location = new System.Drawing.Point(430, 127);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(27, 27);
        label3.TabIndex = 6;
        label3.Text = "+";
        // 
        // lblDetails
        // 
        lblDetails.ActiveLinkColor = System.Drawing.Color.Silver;
        lblDetails.AutoSize = true;
        lblDetails.Font = new System.Drawing.Font("微软雅黑", 12F);
        lblDetails.LinkColor = System.Drawing.Color.Silver;
        lblDetails.Location = new System.Drawing.Point(671, 126);
        lblDetails.Name = "lblDetails";
        lblDetails.Size = new System.Drawing.Size(80, 27);
        lblDetails.TabIndex = 7;
        lblDetails.TabStop = true;
        lblDetails.Text = "-=？=-";
        lblDetails.VisitedLinkColor = System.Drawing.Color.Silver;
        lblDetails.LinkClicked += LblDetails_LinkClicked;
        // 
        // checkLCtrl
        // 
        checkLCtrl.AutoSize = true;
        checkLCtrl.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkLCtrl.Location = new System.Drawing.Point(163, 97);
        checkLCtrl.Name = "checkLCtrl";
        checkLCtrl.Size = new System.Drawing.Size(91, 31);
        checkLCtrl.TabIndex = 8;
        checkLCtrl.Text = "LCTRL";
        checkLCtrl.UseVisualStyleBackColor = true;
        // 
        // checkRCtrl
        // 
        checkRCtrl.AutoSize = true;
        checkRCtrl.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkRCtrl.Location = new System.Drawing.Point(163, 151);
        checkRCtrl.Name = "checkRCtrl";
        checkRCtrl.Size = new System.Drawing.Size(94, 31);
        checkRCtrl.TabIndex = 9;
        checkRCtrl.Text = "RCTRL";
        checkRCtrl.UseVisualStyleBackColor = true;
        // 
        // checkLShift
        // 
        checkLShift.AutoSize = true;
        checkLShift.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkLShift.Location = new System.Drawing.Point(271, 97);
        checkLShift.Name = "checkLShift";
        checkLShift.Size = new System.Drawing.Size(87, 31);
        checkLShift.TabIndex = 10;
        checkLShift.Text = "LShift";
        checkLShift.UseVisualStyleBackColor = true;
        // 
        // checkRShift
        // 
        checkRShift.AutoSize = true;
        checkRShift.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkRShift.Location = new System.Drawing.Point(271, 151);
        checkRShift.Name = "checkRShift";
        checkRShift.Size = new System.Drawing.Size(90, 31);
        checkRShift.TabIndex = 11;
        checkRShift.Text = "RShift";
        checkRShift.UseVisualStyleBackColor = true;
        // 
        // checkLAlt
        // 
        checkLAlt.AutoSize = true;
        checkLAlt.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkLAlt.Location = new System.Drawing.Point(374, 97);
        checkLAlt.Name = "checkLAlt";
        checkLAlt.Size = new System.Drawing.Size(70, 31);
        checkLAlt.TabIndex = 12;
        checkLAlt.Text = "LAlt";
        checkLAlt.UseVisualStyleBackColor = true;
        // 
        // checkRAlt
        // 
        checkRAlt.AutoSize = true;
        checkRAlt.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkRAlt.Location = new System.Drawing.Point(374, 151);
        checkRAlt.Name = "checkRAlt";
        checkRAlt.Size = new System.Drawing.Size(73, 31);
        checkRAlt.TabIndex = 13;
        checkRAlt.Text = "RAlt";
        checkRAlt.UseVisualStyleBackColor = true;
        // 
        // checkRWin
        // 
        checkRWin.AutoSize = true;
        checkRWin.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkRWin.Location = new System.Drawing.Point(55, 137);
        checkRWin.Name = "checkRWin";
        checkRWin.Size = new System.Drawing.Size(89, 31);
        checkRWin.TabIndex = 17;
        checkRWin.Text = "RWIN";
        checkRWin.UseVisualStyleBackColor = true;
        // 
        // checkLWin
        // 
        checkLWin.AutoSize = true;
        checkLWin.Font = new System.Drawing.Font("微软雅黑", 12F);
        checkLWin.Location = new System.Drawing.Point(55, 110);
        checkLWin.Name = "checkLWin";
        checkLWin.Size = new System.Drawing.Size(86, 31);
        checkLWin.TabIndex = 16;
        checkLWin.Text = "LWIN";
        checkLWin.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new System.Drawing.Font("微软雅黑", 12F);
        label4.Location = new System.Drawing.Point(133, 128);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(27, 27);
        label4.TabIndex = 15;
        label4.Text = "+";
        // 
        // HotkeyConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(checkRWin);
        Controls.Add(checkLWin);
        Controls.Add(label4);
        Controls.Add(checkRAlt);
        Controls.Add(checkLAlt);
        Controls.Add(checkRShift);
        Controls.Add(checkLShift);
        Controls.Add(checkRCtrl);
        Controls.Add(checkLCtrl);
        Controls.Add(lblDetails);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(key);
        Controls.Add(checkAlt);
        Controls.Add(checkShift);
        Controls.Add(checkCtrl);
        Name = "HotkeyConfigurator";
        ResumeLayout(false);
        PerformLayout();

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
