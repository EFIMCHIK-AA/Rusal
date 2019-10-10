namespace Rusal
{
    partial class DescriptionArg_F
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
            this.OK_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_TB = new System.Windows.Forms.TextBox();
            this.Value_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_L = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_B.Location = new System.Drawing.Point(23, 122);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(119, 27);
            this.OK_B.TabIndex = 16;
            this.OK_B.Text = "ОК";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_B.Location = new System.Drawing.Point(151, 122);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(115, 27);
            this.Cancel_B.TabIndex = 15;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID в БД";
            // 
            // ID_TB
            // 
            this.ID_TB.Location = new System.Drawing.Point(81, 61);
            this.ID_TB.Name = "ID_TB";
            this.ID_TB.ReadOnly = true;
            this.ID_TB.Size = new System.Drawing.Size(185, 20);
            this.ID_TB.TabIndex = 18;
            // 
            // Value_TB
            // 
            this.Value_TB.Location = new System.Drawing.Point(81, 87);
            this.Value_TB.Name = "Value_TB";
            this.Value_TB.Size = new System.Drawing.Size(185, 20);
            this.Value_TB.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Значение";
            // 
            // Name_L
            // 
            this.Name_L.AutoSize = true;
            this.Name_L.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_L.Location = new System.Drawing.Point(47, 22);
            this.Name_L.Name = "Name_L";
            this.Name_L.Size = new System.Drawing.Size(201, 18);
            this.Name_L.TabIndex = 43;
            this.Name_L.Text = "Добавление аргумента";
            // 
            // DescriptionArg_F
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(290, 169);
            this.Controls.Add(this.Name_L);
            this.Controls.Add(this.Value_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK_B);
            this.Controls.Add(this.Cancel_B);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DescriptionArg_F";
            this.ShowInTaskbar = false;
            this.Text = "Аргумент";
            this.Load += new System.EventHandler(this.DescriptionArg_F_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button OK_B;
        public System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID_TB;
        private System.Windows.Forms.TextBox Value_TB;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label Name_L;
    }
}