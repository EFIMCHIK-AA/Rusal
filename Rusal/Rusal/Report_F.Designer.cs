namespace Rusal
{
    partial class Report_F
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
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.First_MC = new System.Windows.Forms.MonthCalendar();
            this.Second_MC = new System.Windows.Forms.MonthCalendar();
            this.OK_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(133, 24);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(240, 25);
            this.label21.TabIndex = 42;
            this.label21.Text = "Формирование отчета";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Начало  периода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Окончание периода";
            // 
            // First_MC
            // 
            this.First_MC.BackColor = System.Drawing.SystemColors.Control;
            this.First_MC.Location = new System.Drawing.Point(39, 112);
            this.First_MC.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.First_MC.MaxSelectionCount = 1;
            this.First_MC.Name = "First_MC";
            this.First_MC.TabIndex = 121;
            this.First_MC.TrailingForeColor = System.Drawing.Color.Tomato;
            // 
            // Second_MC
            // 
            this.Second_MC.BackColor = System.Drawing.SystemColors.Control;
            this.Second_MC.Location = new System.Drawing.Point(267, 112);
            this.Second_MC.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Second_MC.MaxSelectionCount = 1;
            this.Second_MC.Name = "Second_MC";
            this.Second_MC.TabIndex = 122;
            this.Second_MC.TrailingForeColor = System.Drawing.Color.Tomato;
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_B.Location = new System.Drawing.Point(39, 347);
            this.OK_B.Margin = new System.Windows.Forms.Padding(4);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(206, 33);
            this.OK_B.TabIndex = 124;
            this.OK_B.Text = "ОК";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_B.Location = new System.Drawing.Point(253, 347);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(206, 33);
            this.Cancel_B.TabIndex = 123;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // Report_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 398);
            this.Controls.Add(this.OK_B);
            this.Controls.Add(this.Cancel_B);
            this.Controls.Add(this.Second_MC);
            this.Controls.Add(this.First_MC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report_F";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.MonthCalendar First_MC;
        public System.Windows.Forms.MonthCalendar Second_MC;
        public System.Windows.Forms.Button OK_B;
        public System.Windows.Forms.Button Cancel_B;
    }
}