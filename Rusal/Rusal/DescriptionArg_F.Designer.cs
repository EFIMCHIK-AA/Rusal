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
            this.OK_B.Location = new System.Drawing.Point(31, 150);
            this.OK_B.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(159, 33);
            this.OK_B.TabIndex = 16;
            this.OK_B.Text = "ОК";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_B.Location = new System.Drawing.Point(201, 150);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(153, 33);
            this.Cancel_B.TabIndex = 15;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID в БД";
            // 
            // ID_TB
            // 
            this.ID_TB.Location = new System.Drawing.Point(108, 75);
            this.ID_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ID_TB.Name = "ID_TB";
            this.ID_TB.ReadOnly = true;
            this.ID_TB.Size = new System.Drawing.Size(245, 22);
            this.ID_TB.TabIndex = 18;
            // 
            // Value_TB
            // 
            this.Value_TB.Location = new System.Drawing.Point(108, 107);
            this.Value_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Value_TB.Name = "Value_TB";
            this.Value_TB.Size = new System.Drawing.Size(245, 22);
            this.Value_TB.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Значение";
            // 
            // Name_L
            // 
            this.Name_L.AutoSize = true;
            this.Name_L.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_L.Location = new System.Drawing.Point(63, 27);
            this.Name_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name_L.Name = "Name_L";
            this.Name_L.Size = new System.Drawing.Size(250, 25);
            this.Name_L.TabIndex = 43;
            this.Name_L.Text = "Добавление аргумента";
            // 
            // DescriptionArg_F
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(387, 208);
            this.Controls.Add(this.Name_L);
            this.Controls.Add(this.Value_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK_B);
            this.Controls.Add(this.Cancel_B);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label Name_L;
        public System.Windows.Forms.TextBox ID_TB;
        public System.Windows.Forms.TextBox Value_TB;
    }
}