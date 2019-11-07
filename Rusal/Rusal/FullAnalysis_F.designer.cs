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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ListArgumnts_CB = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TypeArgument_CB = new System.Windows.Forms.ComboBox();
            this.Exit_B = new System.Windows.Forms.Button();
            this.Export_B = new System.Windows.Forms.Button();
            this.Show_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.FirstDate_CM = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.SecondDate_CM = new System.Windows.Forms.MonthCalendar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(532, 412);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "DateFormation";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "Параметр #1";
            this.Column1.MinimumWidth = 70;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "SumWeight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FillWeight = 70F;
            this.Column2.HeaderText = "Параметр #2";
            this.Column2.MinimumWidth = 70;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "AccumulationWeight";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 70F;
            this.Column3.HeaderText = "Параметр #3";
            this.Column3.MinimumWidth = 70;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "DiameterWeight";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "Параметр #4";
            this.Column4.MinimumWidth = 70;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "AccumulationDiameter";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.FillWeight = 61.93124F;
            this.Column5.HeaderText = "Параметр #5";
            this.Column5.MinimumWidth = 70;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView1.Location = new System.Drawing.Point(0, 0);
            this.plotView1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(585, 284);
            this.plotView1.TabIndex = 1;
            this.plotView1.TabStop = false;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotView2
            // 
            this.plotView2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plotView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView2.Location = new System.Drawing.Point(0, 0);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(585, 342);
            this.plotView2.TabIndex = 13;
            this.plotView2.TabStop = false;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
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
            this.splitContainer1.TabIndex = 63;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 3);
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 185);
            this.tableLayoutPanel3.TabIndex = 66;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.ListArgumnts_CB, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TypeArgument_CB, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.Exit_B, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.Export_B, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.Show_B, 0, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 7;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(192, 185);
            this.tableLayoutPanel6.TabIndex = 65;
            // 
            // ListArgumnts_CB
            // 
            this.ListArgumnts_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListArgumnts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListArgumnts_CB.FormattingEnabled = true;
            this.ListArgumnts_CB.Location = new System.Drawing.Point(5, 68);
            this.ListArgumnts_CB.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.ListArgumnts_CB.Name = "ListArgumnts_CB";
            this.ListArgumnts_CB.Size = new System.Drawing.Size(187, 21);
            this.ListArgumnts_CB.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(2, 50);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Аргумент";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(2, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Параметр";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeArgument_CB
            // 
            this.TypeArgument_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeArgument_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeArgument_CB.FormattingEnabled = true;
            this.TypeArgument_CB.Location = new System.Drawing.Point(5, 21);
            this.TypeArgument_CB.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.TypeArgument_CB.Name = "TypeArgument_CB";
            this.TypeArgument_CB.Size = new System.Drawing.Size(187, 21);
            this.TypeArgument_CB.TabIndex = 1;
            this.TypeArgument_CB.SelectedIndexChanged += new System.EventHandler(this.TypeArgument_CB_SelectedIndexChanged);
            // 
            // Exit_B
            // 
            this.Exit_B.BackColor = System.Drawing.Color.White;
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Exit_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_B.Location = new System.Drawing.Point(5, 157);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 5);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(187, 23);
            this.Exit_B.TabIndex = 7;
            this.Exit_B.Text = "Закрыть";
            this.Exit_B.UseVisualStyleBackColor = false;
            // 
            // Export_B
            // 
            this.Export_B.BackColor = System.Drawing.Color.White;
            this.Export_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Export_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_B.Location = new System.Drawing.Point(5, 127);
            this.Export_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.Export_B.Name = "Export_B";
            this.Export_B.Size = new System.Drawing.Size(187, 24);
            this.Export_B.TabIndex = 6;
            this.Export_B.Text = "Экспорт";
            this.Export_B.UseVisualStyleBackColor = false;
            this.Export_B.Click += new System.EventHandler(this.Export_B_Click);
            // 
            // Show_B
            // 
            this.Show_B.BackColor = System.Drawing.Color.White;
            this.Show_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Show_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_B.Location = new System.Drawing.Point(5, 97);
            this.Show_B.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.Show_B.Name = "Show_B";
            this.Show_B.Size = new System.Drawing.Size(187, 24);
            this.Show_B.TabIndex = 5;
            this.Show_B.Text = "Сформировать";
            this.Show_B.UseVisualStyleBackColor = false;
            this.Show_B.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(2, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Начало  периода";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstDate_CM
            // 
            this.FirstDate_CM.Location = new System.Drawing.Point(5, 21);
            this.FirstDate_CM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.FirstDate_CM.MaxSelectionCount = 1;
            this.FirstDate_CM.Name = "FirstDate_CM";
            this.FirstDate_CM.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label10, 0, 0);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(2, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Конец  периода";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SecondDate_CM
            // 
            this.SecondDate_CM.Location = new System.Drawing.Point(5, 21);
            this.SecondDate_CM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SecondDate_CM.MaxSelectionCount = 1;
            this.SecondDate_CM.Name = "SecondDate_CM";
            this.SecondDate_CM.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F);
            this.label11.Location = new System.Drawing.Point(5, 231);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(528, 31);
            this.label11.TabIndex = 64;
            this.label11.Text = "Результат";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F);
            this.label12.Location = new System.Drawing.Point(5, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(528, 31);
            this.label12.TabIndex = 48;
            this.label12.Text = "Параметры";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 685);
            this.tableLayoutPanel1.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F);
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(587, 31);
            this.label13.TabIndex = 64;
            this.label13.Text = "Диаграмма";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(5, 46);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.plotView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.plotView2);
            this.splitContainer2.Size = new System.Drawing.Size(587, 634);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 65;
            // 
            // FullAnalysis_F
            // 
            this.AcceptButton = this.Exit_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 687);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1094, 705);
            this.Name = "FullAnalysis_F";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расширенный анализ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FullAnalysis_F_FormClosing);
            this.Load += new System.EventHandler(this.FullAnalysis_F_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullAnalysis_F_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        public OxyPlot.WindowsForms.PlotView plotView1;
        public OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        public System.Windows.Forms.ComboBox ListArgumnts_CB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox TypeArgument_CB;
        private System.Windows.Forms.Button Exit_B;
        public System.Windows.Forms.Button Export_B;
        private System.Windows.Forms.Button Show_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.MonthCalendar FirstDate_CM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.MonthCalendar SecondDate_CM;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}