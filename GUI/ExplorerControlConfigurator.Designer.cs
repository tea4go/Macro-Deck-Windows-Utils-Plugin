
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.GUI;

partial class ExplorerControlConfigurator
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
        lblAction = new System.Windows.Forms.Label();
        radioBack = new TabRadioButton();
        radioForward = new TabRadioButton();
        radioHome = new TabRadioButton();
        radioRefresh = new TabRadioButton();
        SuspendLayout();
        // 
        // lblAction
        // 
        lblAction.Font = new System.Drawing.Font("微软雅黑", 14.25F);
        lblAction.ForeColor = System.Drawing.Color.White;
        lblAction.Location = new System.Drawing.Point(185, 58);
        lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblAction.Name = "lblAction";
        lblAction.Size = new System.Drawing.Size(344, 50);
        lblAction.TabIndex = 5;
        lblAction.Text = "Action";
        lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // radioBack
        // 
        radioBack.Checked = true;
        radioBack.Cursor = System.Windows.Forms.Cursors.Hand;
        radioBack.Font = new System.Drawing.Font("微软雅黑", 12F);
        radioBack.Location = new System.Drawing.Point(102, 124);
        radioBack.Name = "radioBack";
        radioBack.Size = new System.Drawing.Size(120, 41);
        radioBack.TabIndex = 6;
        radioBack.TabStop = true;
        radioBack.Text = "Back";
        radioBack.UseVisualStyleBackColor = true;
        // 
        // radioForward
        // 
        radioForward.Cursor = System.Windows.Forms.Cursors.Hand;
        radioForward.Font = new System.Drawing.Font("微软雅黑", 12F);
        radioForward.Location = new System.Drawing.Point(232, 124);
        radioForward.Name = "radioForward";
        radioForward.Size = new System.Drawing.Size(120, 41);
        radioForward.TabIndex = 7;
        radioForward.Text = "Forward";
        radioForward.UseVisualStyleBackColor = true;
        // 
        // radioHome
        // 
        radioHome.Cursor = System.Windows.Forms.Cursors.Hand;
        radioHome.Font = new System.Drawing.Font("微软雅黑", 12F);
        radioHome.Location = new System.Drawing.Point(362, 124);
        radioHome.Name = "radioHome";
        radioHome.Size = new System.Drawing.Size(120, 41);
        radioHome.TabIndex = 8;
        radioHome.Text = "Home";
        radioHome.UseVisualStyleBackColor = true;
        // 
        // radioRefresh
        // 
        radioRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
        radioRefresh.Font = new System.Drawing.Font("微软雅黑", 12F);
        radioRefresh.Location = new System.Drawing.Point(492, 124);
        radioRefresh.Name = "radioRefresh";
        radioRefresh.Size = new System.Drawing.Size(120, 41);
        radioRefresh.TabIndex = 9;
        radioRefresh.Text = "Refresh";
        radioRefresh.UseVisualStyleBackColor = true;
        // 
        // ExplorerControlConfigurator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(radioRefresh);
        Controls.Add(radioHome);
        Controls.Add(radioForward);
        Controls.Add(radioBack);
        Controls.Add(lblAction);
        Name = "ExplorerControlConfigurator";
        ResumeLayout(false);

    }

    #endregion
    // 字段声明：资源管理器控制配置器的所有UI控件
    private System.Windows.Forms.Label lblAction;  // 操作类型标签
    private TabRadioButton radioBack;  // "后退"单选按钮
    private TabRadioButton radioForward;  // "前进"单选按钮
    private TabRadioButton radioHome;  // "主页"单选按钮
    private TabRadioButton radioRefresh;  // "刷新"单选按钮
}
