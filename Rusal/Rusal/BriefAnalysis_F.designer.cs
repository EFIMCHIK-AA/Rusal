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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pv = new OxyPlot.WindowsForms.PlotView();
            this.label3 = new System.Windows.Forms.Label();
            this.DGV_Brief = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeArgumnts_CB = new System.Windows.Forms.ComboBox();
            this.Show_B = new System.Windows.Forms.Button();
            this.Export_B = new System.Windows.Forms.Button();
            this.Exit_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstDate_CM = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.SecondDate_CM = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Brief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pv
            // 
            this.pv.BackColor = System.Drawing.Color.White;
            this.pv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pv.Location = new System.Drawing.Point(5, 46);
            this.pv.Margin = new System.Windows.Forms.Padding(5);
            this.pv.Name = "pv";
            this.pv.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pv.Size = new System.Drawing.Size(587, 634);
            this.pv.TabIndex = 3;
            this.pv.Text = "pv";
            this.pv.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pv.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pv.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(528, 31);
            this.label3.TabIndex = 48;
            this.label3.Text = "Параметры";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DGV_Brief
            // 
            this.DGV_Brief.AllowUserToAddRows = false;
            this.DGV_Brief.AllowUserToDeleteRows = false;
            this.DGV_Brief.AllowUserToResizeColumns = false;
            this.DGV_Brief.AllowUserToResizeRows = false;
            this.DGV_Brief.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Brief.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Brief.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.DGV_Brief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Brief.Location = new System.Drawing.Point(5, 272);
            this.DGV_Brief.Margin = new System.Windows.Forms.Padding(5);
            this.DGV_Brief.Name = "DGV_Brief";
            this.DGV_Brief.ReadOnly = true;
            this.DGV_Brief.RowHeadersVisible = false;
            this.DGV_Brief.RowHeadersWidth = 51;
            this.DGV_Brief.Size = new System.Drawing.Size(528, 408);
            this.DGV_Brief.TabIndex = 61;
            this.DGV_Brief.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_Brief_CellFormatting);
            this.DGV_Brief.SelectionChanged += new System.EventHandler(this.DGV_Brief_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Name";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Параметр #1";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "Параметр #2";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1143, 687);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 62;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Brief, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(538, 685);
            this.tableLayoutPanel2.TabIndex = 63;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 185);
            this.tableLayoutPanel3.TabIndex = 65;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TypeArgumnts_CB, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.Show_B, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.Export_B, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.Exit_B, 0, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(192, 185);
            this.tableLayoutPanel6.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(2, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Вид анализа";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeArgumnts_CB
            // 
            this.TypeArgumnts_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeArgumnts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeArgumnts_CB.FormattingEnabled = true;
            this.TypeArgumnts_CB.Location = new System.Drawing.Point(5, 21);
            this.TypeArgumnts_CB.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.TypeArgumnts_CB.Name = "TypeArgumnts_CB";
            this.TypeArgumnts_CB.Size = new System.Drawing.Size(187, 21);
            this.TypeArgumnts_CB.TabIndex = 56;
            // 
            // Show_B
            // 
            this.Show_B.BackColor = System.Drawing.Color.White;
            this.Show_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Show_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_B.Location = new System.Drawing.Point(5, 50);
            this.Show_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 5);
            this.Show_B.Name = "Show_B";
            this.Show_B.Size = new System.Drawing.Size(187, 27);
            this.Show_B.TabIndex = 57;
            this.Show_B.Text = "Сформировать";
            this.Show_B.UseVisualStyleBackColor = false;
            this.Show_B.Click += new System.EventHandler(this.Show_B_Click);
            // 
            // Export_B
            // 
            this.Export_B.BackColor = System.Drawing.Color.White;
            this.Export_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Export_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_B.Location = new System.Drawing.Point(5, 85);
            this.Export_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 5);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(187, 27);
            this.Export_B.TabIndex = 4;
            this.Export_B.Text = "Экспорт";
            this.Export_B.UseVisualStyleBackColor = false;
            this.Export_B.Click += new System.EventHandler(this.Export_B_Click);
            // 
            // Exit_B
            // 
            this.Exit_B.BackColor = System.Drawing.Color.White;
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Exit_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_B.Location = new System.Drawing.Point(5, 155);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(187, 27);
            this.Exit_B.TabIndex = 5;
            this.Exit_B.Text = "Закрыть";
            this.Exit_B.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.FirstDate_CM, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(192, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(173, 185);
            this.tableLayoutPanel4.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Начало  периода";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstDate_CM
            // 
            this.FirstDate_CM.Location = new System.Drawing.Point(5, 21);
            this.FirstDate_CM.Margin = new System.Windows.Forms.Padding(5);
            this.FirstDate_CM.MaxSelectionCount = 1;
            this.FirstDate_CM.Name = "FirstDate_CM";
            this.FirstDate_CM.TabIndex = 54;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.SecondDate_CM, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(365, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(173, 185);
            this.tableLayoutPanel5.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(2, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Конец  периода";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SecondDate_CM
            // 
            this.SecondDate_CM.Location = new System.Drawing.Point(5, 21);
            this.SecondDate_CM.Margin = new System.Windows.Forms.Padding(5);
            this.SecondDate_CM.MaxSelectionCount = 1;
            this.SecondDate_CM.Name = "SecondDate_CM";
            this.SecondDate_CM.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F);
            this.label6.Location = new System.Drawing.Point(5, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(528, 31);
            this.label6.TabIndex = 64;
            this.label6.Text = "Результат";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pv, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 685);
            this.tableLayoutPanel1.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(587, 31);
            this.label4.TabIndex = 64;
            this.label4.Text = "Диаграмма";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BriefAnalysis_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 687);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "BriefAnalysis_F";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стандартный анализ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BriefAnalysis_F_FormClosing);
            this.Load += new System.EventHandler(this.BriefAnalysis_F_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BriefAnalysis_F_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Brief)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public OxyPlot.WindowsForms.PlotView pv;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView DGV_Brief;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox TypeArgumnts_CB;
        private System.Windows.Forms.Button Show_B;
        public System.Windows.Forms.Button Export_B;
        private System.Windows.Forms.Button Exit_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MonthCalendar FirstDate_CM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.MonthCalendar SecondDate_CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}