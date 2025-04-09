namespace GEM_Code_V3
{
    partial class DeleteCrews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteCrews));
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_DeleteSelected = new System.Windows.Forms.Button();
            this.btn_DeleteAll = new System.Windows.Forms.Button();
            this.lb_Entrants = new System.Windows.Forms.ListBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.lb_Classes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(165, 260);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(250, 40);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "Save Entrants";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_DeleteSelected
            // 
            this.btn_DeleteSelected.Location = new System.Drawing.Point(25, 170);
            this.btn_DeleteSelected.Name = "btn_DeleteSelected";
            this.btn_DeleteSelected.Size = new System.Drawing.Size(120, 40);
            this.btn_DeleteSelected.TabIndex = 10;
            this.btn_DeleteSelected.Text = "Delete Crew";
            this.btn_DeleteSelected.UseVisualStyleBackColor = true;
            this.btn_DeleteSelected.Click += new System.EventHandler(this.btn_DeleteSelected_Click);
            // 
            // btn_DeleteAll
            // 
            this.btn_DeleteAll.Location = new System.Drawing.Point(25, 215);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(120, 40);
            this.btn_DeleteAll.TabIndex = 9;
            this.btn_DeleteAll.Text = "Delete All";
            this.btn_DeleteAll.UseVisualStyleBackColor = true;
            this.btn_DeleteAll.Click += new System.EventHandler(this.btn_DeleteAll_Click);
            // 
            // lb_Entrants
            // 
            this.lb_Entrants.FormattingEnabled = true;
            this.lb_Entrants.ItemHeight = 16;
            this.lb_Entrants.Location = new System.Drawing.Point(165, 25);
            this.lb_Entrants.Name = "lb_Entrants";
            this.lb_Entrants.Size = new System.Drawing.Size(250, 228);
            this.lb_Entrants.TabIndex = 8;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(25, 260);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(120, 40);
            this.btn_Select.TabIndex = 7;
            this.btn_Select.Text = "Select Class";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // lb_Classes
            // 
            this.lb_Classes.FormattingEnabled = true;
            this.lb_Classes.ItemHeight = 16;
            this.lb_Classes.Location = new System.Drawing.Point(25, 25);
            this.lb_Classes.Name = "lb_Classes";
            this.lb_Classes.Size = new System.Drawing.Size(120, 132);
            this.lb_Classes.TabIndex = 6;
            // 
            // DeleteCrews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 323);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_DeleteSelected);
            this.Controls.Add(this.btn_DeleteAll);
            this.Controls.Add(this.lb_Entrants);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.lb_Classes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteCrews";
            this.Text = "Delete Crews - GEM V3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_DeleteSelected;
        private System.Windows.Forms.Button btn_DeleteAll;
        private System.Windows.Forms.ListBox lb_Entrants;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ListBox lb_Classes;
    }
}