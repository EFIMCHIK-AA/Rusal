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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Form_B = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 186);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(497, 535);
            this.dataGridView1.TabIndex = 0;
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(576, 39);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(653, 326);
            this.plotView1.TabIndex = 1;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Exit_B
            // 
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Location = new System.Drawing.Point(1132, 698);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(97, 23);
            this.Exit_B.TabIndex = 7;
            this.Exit_B.Text = "Закрыть";
            this.Exit_B.UseVisualStyleBackColor = true;
            // 
            // Export_B
            // 
            this.Export_B.Location = new System.Drawing.Point(1029, 698);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(97, 23);
            this.Export_B.TabIndex = 6;
            this.Export_B.Text = "Export";
            this.Export_B.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(218, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(400, 12);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // Form_B
            // 
            this.Form_B.Location = new System.Drawing.Point(576, 12);
            this.Form_B.Name = "Form_B";
            this.Form_B.Size = new System.Drawing.Size(159, 23);
            this.Form_B.TabIndex = 11;
            this.Form_B.Text = "Сформировать";
            this.Form_B.UseVisualStyleBackColor = true;
            this.Form_B.Click += new System.EventHandler(this.Button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 21);
            this.comboBox2.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "DateCreate";
            this.Column1.HeaderText = "Дата";
            this.Column1.Name = "Column1";
            this.Column1.Width = 58;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SumWeight";
            this.Column2.HeaderText = "Брак, тонн";
            this.Column2.Name = "Column2";
            this.Column2.Width = 86;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "AccumulationWeight";
            this.Column3.HeaderText = "Накопление брак, тонн";
            this.Column3.Name = "Column3";
            this.Column3.Width = 116;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiameterWeight";
            this.Column4.HeaderText = "Диаметр брак, тонн";
            this.Column4.Name = "Column4";
            this.Column4.Width = 102;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "AccumulationDiameter";
            this.Column5.HeaderText = "Накопление диаметр, тонн";
            this.Column5.Name = "Column5";
            this.Column5.Width = 133;
            // 
            // plotView2
            // 
            this.plotView2.Location = new System.Drawing.Point(576, 366);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(653, 326);
            this.plotView2.TabIndex = 13;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // FullAnalysis_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 733);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Form_B);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Exit_B);
            this.Controls.Add(this.Export_B);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullAnalysis_F";
            this.ShowInTaskbar = false;
            this.Text = "FullAnalysis_F";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Exit_B;
        public System.Windows.Forms.Button Export_B;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Form_B;
        private System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public OxyPlot.WindowsForms.PlotView plotView1;
        public OxyPlot.WindowsForms.PlotView plotView2;
    }
}