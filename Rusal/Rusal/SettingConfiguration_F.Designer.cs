namespace Rusal
{
    partial class SettingConfiguration_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingConfiguration_F));
            this.label17 = new System.Windows.Forms.Label();
            this.OK_B = new System.Windows.Forms.Button();
            this.Params_CB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Spisok_LB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Name = "label17";
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.White;
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.OK_B, "OK_B");
            this.OK_B.Name = "OK_B";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // Params_CB
            // 
            resources.ApplyResources(this.Params_CB, "Params_CB");
            this.Params_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Params_CB.FormattingEnabled = true;
            this.Params_CB.Name = "Params_CB";
            this.Params_CB.SelectedIndexChanged += new System.EventHandler(this.Params_CB_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.BackColor = System.Drawing.Color.White;
            this.Spisok_LB.DisplayMember = "Name";
            resources.ApplyResources(this.Spisok_LB, "Spisok_LB");
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.ValueMember = "Name";
            this.Spisok_LB.Click += new System.EventHandler(this.Spisok_LB_Click);
            this.Spisok_LB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Spisok_LB_DrawItem);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(162)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Add_B
            // 
            resources.ApplyResources(this.Add_B, "Add_B");
            this.Add_B.BackColor = System.Drawing.Color.White;
            this.Add_B.Name = "Add_B";
            this.Add_B.UseVisualStyleBackColor = false;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Change_B, "Change_B");
            this.Change_B.Name = "Change_B";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            this.Delete_B.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Delete_B, "Delete_B");
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.UseVisualStyleBackColor = false;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Params_CB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Spisok_LB, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.Add_B, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Change_B, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Delete_B, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.OK_B, 0, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // SettingConfiguration_F
            // 
            this.AcceptButton = this.OK_B;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingConfiguration_F";
            this.Load += new System.EventHandler(this.SettingConfiguration_F_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Button OK_B;
        public System.Windows.Forms.ComboBox Params_CB;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Add_B;
        public System.Windows.Forms.Button Change_B;
        public System.Windows.Forms.Button Delete_B;
        public System.Windows.Forms.ListBox Spisok_LB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}