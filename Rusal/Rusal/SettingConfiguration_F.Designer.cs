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
            this.SuspendLayout();
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.OK_B, "OK_B");
            this.OK_B.Name = "OK_B";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // Params_CB
            // 
            this.Params_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Params_CB.FormattingEnabled = true;
            resources.ApplyResources(this.Params_CB, "Params_CB");
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
            this.Spisok_LB.FormattingEnabled = true;
            resources.ApplyResources(this.Spisok_LB, "Spisok_LB");
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Click += new System.EventHandler(this.Spisok_LB_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Add_B
            // 
            resources.ApplyResources(this.Add_B, "Add_B");
            this.Add_B.Name = "Add_B";
            this.Add_B.UseVisualStyleBackColor = true;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // Change_B
            // 
            resources.ApplyResources(this.Change_B, "Change_B");
            this.Change_B.Name = "Change_B";
            this.Change_B.UseVisualStyleBackColor = true;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            resources.ApplyResources(this.Delete_B, "Delete_B");
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.UseVisualStyleBackColor = true;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // SettingConfiguration_F
            // 
            this.AcceptButton = this.OK_B;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Add_B);
            this.Controls.Add(this.Change_B);
            this.Controls.Add(this.Delete_B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Spisok_LB);
            this.Controls.Add(this.Params_CB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK_B);
            this.Controls.Add(this.label17);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingConfiguration_F";
            this.Load += new System.EventHandler(this.SettingConfiguration_F_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}