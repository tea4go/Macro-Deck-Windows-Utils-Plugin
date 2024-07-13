﻿
namespace SuchByte.WindowsUtils.GUI;

partial class FileFolderSelector
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
        this.btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.lblPath = new System.Windows.Forms.Label();
        this.path = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.lblChoose = new System.Windows.Forms.Label();
        this.SuspendLayout();
        //
        // btnBrowse
        //
        this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnBrowse.BorderRadius = 8;
        this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBrowse.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnBrowse.ForeColor = System.Drawing.Color.White;
        this.btnBrowse.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));
        this.btnBrowse.Icon = null;
        this.btnBrowse.Location = new System.Drawing.Point(584, 121);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Progress = 0;
        this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnBrowse.Size = new System.Drawing.Size(38, 29);
        this.btnBrowse.TabIndex = 5;
        this.btnBrowse.Text = "...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
        //
        // lblPath
        //
        this.lblPath.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblPath.Location = new System.Drawing.Point(3, 121);
        this.lblPath.Name = "lblPath";
        this.lblPath.Size = new System.Drawing.Size(83, 29);
        this.lblPath.TabIndex = 4;
        this.lblPath.Text = "Path:";
        this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // path
        //
        this.path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.path.Cursor = System.Windows.Forms.Cursors.Hand;
        this.path.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.path.Icon = null;
        this.path.Location = new System.Drawing.Point(92, 121);
        this.path.Multiline = false;
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
        // lblChoose
        //
        this.lblChoose.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblChoose.Location = new System.Drawing.Point(3, 184);
        this.lblChoose.Name = "lblChoose";
        this.lblChoose.Size = new System.Drawing.Size(709, 64);
        this.lblChoose.TabIndex = 6;
        this.lblChoose.Text = "Choose a file or drag and drop it here";
        this.lblChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // FileFolderSelector
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.lblChoose);
        this.Controls.Add(this.btnBrowse);
        this.Controls.Add(this.lblPath);
        this.Controls.Add(this.path);
        this.Name = "FileFolderSelector";
        this.ResumeLayout(false);

    }

    #endregion

    private MacroDeck.GUI.CustomControls.ButtonPrimary btnBrowse;
    private System.Windows.Forms.Label lblPath;
    private MacroDeck.GUI.CustomControls.RoundedTextBox path;
    private System.Windows.Forms.Label lblChoose;
}
