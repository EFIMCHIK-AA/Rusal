namespace Rusal
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Show_B = new System.Windows.Forms.Button();
            this.TypeArgumnts_CB = new System.Windows.Forms.ComboBox();
            this.SecondDate_CM = new System.Windows.Forms.MonthCalendar();
            this.FirstDate_CM = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // pv
            // 
            this.pv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pv.Location = new System.Drawing.Point(613, 94);
            this.pv.Name = "pv";
            this.pv.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pv.Size = new System.Drawing.Size(691, 562);
            this.pv.TabIndex = 3;
            this.pv.Text = "pv";
            this.pv.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pv.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pv.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Export_B
            // 
            this.Export_B.Location = new System.Drawing.Point(17, 196);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(230, 27);
            this.Export_B.TabIndex = 4;
            this.Export_B.Text = "Экспорт";
            this.Export_B.UseVisualStyleBackColor = true;
            this.Export_B.Click += new System.EventHandler(this.Export_B_Click);
            // 
            // Exit_B
            // 
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Location = new System.Drawing.Point(17, 229);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(230, 27);
            this.Exit_B.TabIndex = 5;
            this.Exit_B.Text = "Закрыть";
            this.Exit_B.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(491, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "Результаты и диаграмма анализа";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 288);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 368);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(322, 288);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(280, 368);
            this.listBox2.TabIndex = 1;
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(16, 272);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(46, 13);
            this.label_x.TabIndex = 6;
            this.label_x.Text = "X_Label";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(319, 272);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(46, 13);
            this.label_y.TabIndex = 7;
            this.label_y.Text = "Y_Label";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Вид анализа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Конец периода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Начало  периода";
            // 
            // Show_B
            // 
            this.Show_B.Location = new System.Drawing.Point(17, 163);
            this.Show_B.Name = "Show_B";
            this.Show_B.Size = new System.Drawing.Size(230, 27);
            this.Show_B.TabIndex = 57;
            this.Show_B.Text = "Сформировать";
            this.Show_B.UseVisualStyleBackColor = true;
            this.Show_B.Click += new System.EventHandler(this.Show_B_Click);
            // 
            // TypeArgumnts_CB
            // 
            this.TypeArgumnts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeArgumnts_CB.FormattingEnabled = true;
            this.TypeArgumnts_CB.Location = new System.Drawing.Point(17, 94);
            this.TypeArgumnts_CB.Name = "TypeArgumnts_CB";
            this.TypeArgumnts_CB.Size = new System.Drawing.Size(230, 21);
            this.TypeArgumnts_CB.TabIndex = 56;
            this.TypeArgumnts_CB.SelectedIndexChanged += new System.EventHandler(this.TypeArgumnts_CB_SelectedIndexChanged);
            // 
            // SecondDate_CM
            // 
            this.SecondDate_CM.Location = new System.Drawing.Point(437, 94);
            this.SecondDate_CM.MaxSelectionCount = 1;
            this.SecondDate_CM.Name = "SecondDate_CM";
            this.SecondDate_CM.TabIndex = 55;
            // 
            // FirstDate_CM
            // 
            this.FirstDate_CM.Location = new System.Drawing.Point(259, 94);
            this.FirstDate_CM.MaxSelectionCount = 1;
            this.FirstDate_CM.Name = "FirstDate_CM";
            this.FirstDate_CM.TabIndex = 54;
            // 
            // BriefAnalysis_F
            // 
            this.AcceptButton = this.Exit_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 677);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Show_B);
            this.Controls.Add(this.TypeArgumnts_CB);
            this.Controls.Add(this.SecondDate_CM);
            this.Controls.Add(this.FirstDate_CM);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analysis_F";
            this.Load += new System.EventHandler(this.BriefAnalysis_F_Load);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Show_B;
        public System.Windows.Forms.ComboBox TypeArgumnts_CB;
        public System.Windows.Forms.MonthCalendar SecondDate_CM;
        public System.Windows.Forms.MonthCalendar FirstDate_CM;
    }
}