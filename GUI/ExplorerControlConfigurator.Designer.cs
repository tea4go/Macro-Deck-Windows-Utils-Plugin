
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
        // 创建资源管理器窗口控制动作的配置界面控件
        this.lblAction = new System.Windows.Forms.Label();
        this.radioBack = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioForward = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioHome = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioRefresh = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.SuspendLayout();  // 挂起布局，批量设置属性以提高性能
        //
        // lblAction - 操作类型标签
        //
        this.lblAction.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblAction.ForeColor = System.Drawing.Color.White;  // 白色前景文字，适配深色主题
        this.lblAction.Location = new System.Drawing.Point(185, 85);
        this.lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblAction.Name = "lblAction";
        this.lblAction.Size = new System.Drawing.Size(344, 23);
        this.lblAction.TabIndex = 5;
        this.lblAction.Text = "Action";
        this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;  // 居中显示
        //
        // radioBack - "后退"单选按钮（默认选中）
        //
        this.radioBack.Checked = true;  // 默认选中后退操作
        this.radioBack.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioBack.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioBack.Location = new System.Drawing.Point(102, 124);
        this.radioBack.Name = "radioBack";
        this.radioBack.Size = new System.Drawing.Size(120, 23);
        this.radioBack.TabIndex = 6;
        this.radioBack.TabStop = true;
        this.radioBack.Text = "Back";
        this.radioBack.UseVisualStyleBackColor = true;
        //
        // radioForward - "前进"单选按钮
        //
        this.radioForward.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioForward.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioForward.Location = new System.Drawing.Point(232, 124);
        this.radioForward.Name = "radioForward";
        this.radioForward.Size = new System.Drawing.Size(120, 23);
        this.radioForward.TabIndex = 7;
        this.radioForward.Text = "Forward";
        this.radioForward.UseVisualStyleBackColor = true;
        //
        // radioHome - "主页"单选按钮
        //
        this.radioHome.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioHome.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioHome.Location = new System.Drawing.Point(362, 124);
        this.radioHome.Name = "radioHome";
        this.radioHome.Size = new System.Drawing.Size(120, 23);
        this.radioHome.TabIndex = 8;
        this.radioHome.Text = "Home";
        this.radioHome.UseVisualStyleBackColor = true;
        //
        // radioRefresh - "刷新"单选按钮
        //
        this.radioRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioRefresh.Location = new System.Drawing.Point(492, 124);
        this.radioRefresh.Name = "radioRefresh";
        this.radioRefresh.Size = new System.Drawing.Size(120, 23);
        this.radioRefresh.TabIndex = 9;
        this.radioRefresh.Text = "Refresh";
        this.radioRefresh.UseVisualStyleBackColor = true;
        //
        // ExplorerControlConfigurator - 资源管理器控制配置器主控件
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.radioRefresh);
        this.Controls.Add(this.radioHome);
        this.Controls.Add(this.radioForward);
        this.Controls.Add(this.radioBack);
        this.Controls.Add(this.lblAction);
        this.Name = "ExplorerControlConfigurator";
        this.ResumeLayout(false);  // 恢复布局，应用所有属性设置

    }

    #endregion
    // 字段声明：资源管理器控制配置器的所有UI控件
    private System.Windows.Forms.Label lblAction;  // 操作类型标签
    private TabRadioButton radioBack;  // "后退"单选按钮
    private TabRadioButton radioForward;  // "前进"单选按钮
    private TabRadioButton radioHome;  // "主页"单选按钮
    private TabRadioButton radioRefresh;  // "刷新"单选按钮
}
