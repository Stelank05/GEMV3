
namespace GEM_Code_V3
{
    partial class CreateStandings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStandings));
            this.lb_Classes = new System.Windows.Forms.ListBox();
            this.btn_SelectClass = new System.Windows.Forms.Button();
            this.btn_CreateCrewStandings = new System.Windows.Forms.Button();
            this.btn_CreateTeamsStandings = new System.Windows.Forms.Button();
            this.btn_CreateManufacturersStandings = new System.Windows.Forms.Button();
            this.tb_SelectedClass = new System.Windows.Forms.TextBox();
            this.tb_DisplayClass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_Classes
            // 
            this.lb_Classes.FormattingEnabled = true;
            this.lb_Classes.ItemHeight = 16;
            this.lb_Classes.Location = new System.Drawing.Point(25, 55);
            this.lb_Classes.Name = "lb_Classes";
            this.lb_Classes.Size = new System.Drawing.Size(120, 132);
            this.lb_Classes.TabIndex = 0;
            this.lb_Classes.SelectedIndexChanged += new System.EventHandler(this.lb_Classes_SelectedIndexChanged);
            // 
            // btn_SelectClass
            // 
            this.btn_SelectClass.Location = new System.Drawing.Point(25, 195);
            this.btn_SelectClass.Name = "btn_SelectClass";
            this.btn_SelectClass.Size = new System.Drawing.Size(120, 40);
            this.btn_SelectClass.TabIndex = 1;
            this.btn_SelectClass.Text = "Select Class";
            this.btn_SelectClass.UseVisualStyleBackColor = true;
            this.btn_SelectClass.Click += new System.EventHandler(this.btn_SelectClass_Click);
            // 
            // btn_CreateCrewStandings
            // 
            this.btn_CreateCrewStandings.Location = new System.Drawing.Point(155, 55);
            this.btn_CreateCrewStandings.Name = "btn_CreateCrewStandings";
            this.btn_CreateCrewStandings.Size = new System.Drawing.Size(150, 50);
            this.btn_CreateCrewStandings.TabIndex = 2;
            this.btn_CreateCrewStandings.Text = "Create Crew Standings File";
            this.btn_CreateCrewStandings.UseVisualStyleBackColor = true;
            this.btn_CreateCrewStandings.Click += new System.EventHandler(this.btn_CreateCrewStandings_Click);
            // 
            // btn_CreateTeamsStandings
            // 
            this.btn_CreateTeamsStandings.Location = new System.Drawing.Point(155, 110);
            this.btn_CreateTeamsStandings.Name = "btn_CreateTeamsStandings";
            this.btn_CreateTeamsStandings.Size = new System.Drawing.Size(150, 50);
            this.btn_CreateTeamsStandings.TabIndex = 3;
            this.btn_CreateTeamsStandings.Text = "Create Teams Standings File";
            this.btn_CreateTeamsStandings.UseVisualStyleBackColor = true;
            this.btn_CreateTeamsStandings.Click += new System.EventHandler(this.btn_CreateTeamsStandings_Click);
            // 
            // btn_CreateManufacturersStandings
            // 
            this.btn_CreateManufacturersStandings.Location = new System.Drawing.Point(155, 165);
            this.btn_CreateManufacturersStandings.Name = "btn_CreateManufacturersStandings";
            this.btn_CreateManufacturersStandings.Size = new System.Drawing.Size(150, 70);
            this.btn_CreateManufacturersStandings.TabIndex = 4;
            this.btn_CreateManufacturersStandings.Text = "Create Manufacturers Standings File";
            this.btn_CreateManufacturersStandings.UseVisualStyleBackColor = true;
            this.btn_CreateManufacturersStandings.Click += new System.EventHandler(this.btn_CreateManufacturersStandings_Click);
            // 
            // tb_SelectedClass
            // 
            this.tb_SelectedClass.Location = new System.Drawing.Point(25, 25);
            this.tb_SelectedClass.Name = "tb_SelectedClass";
            this.tb_SelectedClass.Size = new System.Drawing.Size(120, 22);
            this.tb_SelectedClass.TabIndex = 5;
            this.tb_SelectedClass.Text = "Selected Class:";
            this.tb_SelectedClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_DisplayClass
            // 
            this.tb_DisplayClass.Location = new System.Drawing.Point(155, 25);
            this.tb_DisplayClass.Name = "tb_DisplayClass";
            this.tb_DisplayClass.Size = new System.Drawing.Size(150, 22);
            this.tb_DisplayClass.TabIndex = 6;
            this.tb_DisplayClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreateStandings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 253);
            this.Controls.Add(this.tb_DisplayClass);
            this.Controls.Add(this.tb_SelectedClass);
            this.Controls.Add(this.btn_CreateManufacturersStandings);
            this.Controls.Add(this.btn_CreateTeamsStandings);
            this.Controls.Add(this.btn_CreateCrewStandings);
            this.Controls.Add(this.btn_SelectClass);
            this.Controls.Add(this.lb_Classes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateStandings";
            this.Text = "Create Standings Files - GEM V3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Classes;
        private System.Windows.Forms.Button btn_SelectClass;
        private System.Windows.Forms.Button btn_CreateCrewStandings;
        private System.Windows.Forms.Button btn_CreateTeamsStandings;
        private System.Windows.Forms.Button btn_CreateManufacturersStandings;
        private System.Windows.Forms.TextBox tb_SelectedClass;
        private System.Windows.Forms.TextBox tb_DisplayClass;
    }
}