
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SuchByte.MacroDeck.GUI.CustomControls
{
    partial class RoundedNumericUpDown
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

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
            numericUpDown1 = new NumericUpDown();
            ((ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            //
            // numericUpDown1
            //
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.BackColor = Color.FromArgb(65, 65, 65);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.Font = new Font("Tahoma", 9F);
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(4, 4);
            numericUpDown1.Margin = new Padding(0);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(240, 30);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Tag = "no-font";
            numericUpDown1.TextAlign = HorizontalAlignment.Left;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            numericUpDown1.Enter += NumericUpDown1_Enter;
            numericUpDown1.GotFocus += NumericUpDown1_GotFocus;
            numericUpDown1.KeyPress += NumericUpDown1_KeyPress;
            numericUpDown1.LostFocus += NumericUpDown1_LostFocus;
            numericUpDown1.Click += NumericUpDown1_Click;
            //
            // RoundedNumericUpDown
            //
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(65, 65, 65);
            Controls.Add(numericUpDown1);
            Font = new Font("Tahoma", 9F);
            Name = "RoundedNumericUpDown";
            Size = new Size(250, 38);
            ((ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDown1;
    }
}
