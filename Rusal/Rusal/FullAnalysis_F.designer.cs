namespace Rusal
{
    partial class FullAnalysis_F
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.Exit_B = new System.Windows.Forms.Button();
            this.Export_B = new System.Windows.Forms.Button();
            this.FirstDate_CM = new System.Windows.Forms.MonthCalendar();
            this.SecondDate_CM = new System.Windows.Forms.MonthCalendar();
            this.TypeArgument_CB = new System.Windows.Forms.ComboBox();
            this.Show_B = new System.Windows.Forms.Button();
            this.ListArgumnts_CB = new System.Windows.Forms.ComboBox();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(14, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(571, 434);
            this.dataGridView1.TabIndex = 0;
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plotView1.Location = new System.Drawing.Point(597, 69);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(650, 315);
            this.plotView1.TabIndex = 1;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Exit_B
            // 
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Location = new System.Drawing.Point(14, 207);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(230, 23);
            this.Exit_B.TabIndex = 7;
            this.Exit_B.Text = "Завершить просмотр";
            this.Exit_B.UseVisualStyleBackColor = true;
            // 
            // Export_B
            // 
            this.Export_B.Location = new System.Drawing.Point(14, 174);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(230, 27);
            this.Export_B.TabIndex = 6;
            this.Export_B.Text = "Экспорт";
            this.Export_B.UseVisualStyleBackColor = true;
            this.Export_B.Click += new System.EventHandler(this.Export_B_Click);
            // 
            // FirstDate_CM
            // 
            this.FirstDate_CM.Location = new System.Drawing.Point(256, 68);
            this.FirstDate_CM.MaxSelectionCount = 1;
            this.FirstDate_CM.Name = "FirstDate_CM";
            this.FirstDate_CM.TabIndex = 8;
            // 
            // SecondDate_CM
            // 
            this.SecondDate_CM.Location = new System.Drawing.Point(421, 68);
            this.SecondDate_CM.MaxSelectionCount = 1;
            this.SecondDate_CM.Name = "SecondDate_CM";
            this.SecondDate_CM.TabIndex = 9;
            // 
            // TypeArgument_CB
            // 
            this.TypeArgument_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeArgument_CB.FormattingEnabled = true;
            this.TypeArgument_CB.Location = new System.Drawing.Point(14, 69);
            this.TypeArgument_CB.Name = "TypeArgument_CB";
            this.TypeArgument_CB.Size = new System.Drawing.Size(230, 21);
            this.TypeArgument_CB.TabIndex = 10;
            this.TypeArgument_CB.SelectedIndexChanged += new System.EventHandler(this.TypeArgument_CB_SelectedIndexChanged);
            // 
            // Show_B
            // 
            this.Show_B.Location = new System.Drawing.Point(14, 141);
            this.Show_B.Name = "Show_B";
            this.Show_B.Size = new System.Drawing.Size(230, 27);
            this.Show_B.TabIndex = 11;
            this.Show_B.Text = "Сформировать";
            this.Show_B.UseVisualStyleBackColor = true;
            this.Show_B.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ListArgumnts_CB
            // 
            this.ListArgumnts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListArgumnts_CB.FormattingEnabled = true;
            this.ListArgumnts_CB.Location = new System.Drawing.Point(14, 114);
            this.ListArgumnts_CB.Name = "ListArgumnts_CB";
            this.ListArgumnts_CB.Size = new System.Drawing.Size(230, 21);
            this.ListArgumnts_CB.TabIndex = 12;
            // 
            // plotView2
            // 
            this.plotView2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plotView2.Location = new System.Drawing.Point(597, 390);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(650, 315);
            this.plotView2.TabIndex = 13;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(213, 243);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(176, 18);
            this.label21.TabIndex = 42;
            this.label21.Text = "Результаты анализа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Окончание периода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Начало  периода";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(195, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "Период и параметры анализа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Параметр";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Аргументы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(872, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 52;
            this.label6.Text = "Диаграммы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(862, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "по результатам анализа";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DateFormation";
            this.Column1.HeaderText = "Дата появления";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SumWeight";
            this.Column2.HeaderText = "Брак";
            this.Column2.Name = "Column2";
            this.Column2.Width = 57;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "AccumulationWeight";
            this.Column3.HeaderText = "Накопление брак";
            this.Column3.Name = "Column3";
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiameterWeight";
            this.Column4.HeaderText = "Диаметр брак";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "AccumulationDiameter";
            this.Column5.HeaderText = "Накопление диаметр";
            this.Column5.Name = "Column5";
            this.Column5.Width = 140;
            // 
            // FullAnalysis_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 721);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.ListArgumnts_CB);
            this.Controls.Add(this.Show_B);
            this.Controls.Add(this.TypeArgument_CB);
            this.Controls.Add(this.SecondDate_CM);
            this.Controls.Add(this.FirstDate_CM);
            this.Controls.Add(this.Exit_B);
            this.Controls.Add(this.Export_B);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullAnalysis_F";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FullAnalysis_F";
            this.Load += new System.EventHandler(this.FullAnalysis_F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Exit_B;
        public System.Windows.Forms.Button Export_B;
        private System.Windows.Forms.Button Show_B;
        public System.Windows.Forms.DataGridView dataGridView1;
        public OxyPlot.WindowsForms.PlotView plotView1;
        public OxyPlot.WindowsForms.PlotView plotView2;
        public System.Windows.Forms.ComboBox TypeArgument_CB;
        public System.Windows.Forms.ComboBox ListArgumnts_CB;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.MonthCalendar FirstDate_CM;
        public System.Windows.Forms.MonthCalendar SecondDate_CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}