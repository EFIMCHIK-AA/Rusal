﻿namespace Rusal
{
    partial class BriefAnalysis_F
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pv = new OxyPlot.WindowsForms.PlotView();
            this.Export_B = new System.Windows.Forms.Button();
            this.Exit_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pv
            // 
            this.pv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pv.Location = new System.Drawing.Point(267, 54);
            this.pv.Name = "pv";
            this.pv.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pv.Size = new System.Drawing.Size(597, 397);
            this.pv.TabIndex = 3;
            this.pv.Text = "pv";
            this.pv.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pv.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pv.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Export_B
            // 
            this.Export_B.Location = new System.Drawing.Point(138, 428);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(120, 23);
            this.Export_B.TabIndex = 4;
            this.Export_B.Text = "Экспорт";
            this.Export_B.UseVisualStyleBackColor = true;
            this.Export_B.Click += new System.EventHandler(this.Export_B_Click);
            // 
            // Exit_B
            // 
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Location = new System.Drawing.Point(12, 428);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(120, 23);
            this.Exit_B.TabIndex = 5;
            this.Exit_B.Text = "Закрыть";
            this.Exit_B.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(294, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "Результаты и диаграмма анализа";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 368);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(138, 54);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 368);
            this.listBox2.TabIndex = 1;
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(9, 38);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(46, 13);
            this.label_x.TabIndex = 6;
            this.label_x.Text = "X_Label";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(135, 38);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(46, 13);
            this.label_y.TabIndex = 7;
            this.label_y.Text = "Y_Label";
            // 
            // BriefAnalysis_F
            // 
            this.AcceptButton = this.Exit_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 463);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.Exit_B);
            this.Controls.Add(this.Export_B);
            this.Controls.Add(this.pv);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BriefAnalysis_F";
            this.Text = "Analysis_F";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public OxyPlot.WindowsForms.PlotView pv;
        public System.Windows.Forms.Button Export_B;
        private System.Windows.Forms.Button Exit_B;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ListBox listBox2;
        public System.Windows.Forms.Label label_x;
        public System.Windows.Forms.Label label_y;
    }
}