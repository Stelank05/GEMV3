namespace GEM_Code_V3
{
    partial class ViewClassOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewClassOrder));
            this.cb_Overall = new System.Windows.Forms.CheckBox();
            this.btn_CloseAll = new System.Windows.Forms.Button();
            this.btn_LoadAll = new System.Windows.Forms.Button();
            this.btn_LoadSelected = new System.Windows.Forms.Button();
            this.lb_Classes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cb_Overall
            // 
            this.cb_Overall.Location = new System.Drawing.Point(30, 150);
            this.cb_Overall.Name = "cb_Overall";
            this.cb_Overall.Size = new System.Drawing.Size(100, 40);
            this.cb_Overall.TabIndex = 18;
            this.cb_Overall.Text = "Load Top 8 Overall";
            this.cb_Overall.UseVisualStyleBackColor = true;
            // 
            // btn_CloseAll
            // 
            this.btn_CloseAll.Location = new System.Drawing.Point(30, 310);
            this.btn_CloseAll.Name = "btn_CloseAll";
            this.btn_CloseAll.Size = new System.Drawing.Size(100, 50);
            this.btn_CloseAll.TabIndex = 17;
            this.btn_CloseAll.Text = "Close All Classes";
            this.btn_CloseAll.UseVisualStyleBackColor = true;
            this.btn_CloseAll.Click += new System.EventHandler(this.btn_CloseAll_Click);
            // 
            // btn_LoadAll
            // 
            this.btn_LoadAll.Location = new System.Drawing.Point(30, 255);
            this.btn_LoadAll.Name = "btn_LoadAll";
            this.btn_LoadAll.Size = new System.Drawing.Size(100, 50);
            this.btn_LoadAll.TabIndex = 16;
            this.btn_LoadAll.Text = "Load All Classes";
            this.btn_LoadAll.UseVisualStyleBackColor = true;
            this.btn_LoadAll.Click += new System.EventHandler(this.btn_LoadAll_Click);
            // 
            // btn_LoadSelected
            // 
            this.btn_LoadSelected.Location = new System.Drawing.Point(30, 200);
            this.btn_LoadSelected.Name = "btn_LoadSelected";
            this.btn_LoadSelected.Size = new System.Drawing.Size(100, 50);
            this.btn_LoadSelected.TabIndex = 15;
            this.btn_LoadSelected.Text = "Load Selected";
            this.btn_LoadSelected.UseVisualStyleBackColor = true;
            this.btn_LoadSelected.Click += new System.EventHandler(this.btn_LoadSelected_Click);
            // 
            // lb_Classes
            // 
            this.lb_Classes.FormattingEnabled = true;
            this.lb_Classes.ItemHeight = 16;
            this.lb_Classes.Location = new System.Drawing.Point(30, 25);
            this.lb_Classes.Name = "lb_Classes";
            this.lb_Classes.Size = new System.Drawing.Size(100, 116);
            this.lb_Classes.TabIndex = 14;
            // 
            // ViewClassOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 383);
            this.Controls.Add(this.cb_Overall);
            this.Controls.Add(this.btn_CloseAll);
            this.Controls.Add(this.btn_LoadAll);
            this.Controls.Add(this.btn_LoadSelected);
            this.Controls.Add(this.lb_Classes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewClassOrder";
            this.Text = "View Class Top 8 - GEM V3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Overall;
        private System.Windows.Forms.Button btn_CloseAll;
        private System.Windows.Forms.Button btn_LoadAll;
        private System.Windows.Forms.Button btn_LoadSelected;
        private System.Windows.Forms.ListBox lb_Classes;
    }
}