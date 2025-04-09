namespace GEM_Code_V3
{
    partial class StartWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.btn_SelectRace = new System.Windows.Forms.Button();
            this.btn_EditCalendar = new System.Windows.Forms.Button();
            this.btn_CreateCrew = new System.Windows.Forms.Button();
            this.btn_DeleteCrew = new System.Windows.Forms.Button();
            this.btn_EditCars = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_ClassEditor = new System.Windows.Forms.Button();
            this.btn_CreateStandings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SelectRace
            // 
            this.btn_SelectRace.Location = new System.Drawing.Point(25, 25);
            this.btn_SelectRace.Name = "btn_SelectRace";
            this.btn_SelectRace.Size = new System.Drawing.Size(150, 40);
            this.btn_SelectRace.TabIndex = 0;
            this.btn_SelectRace.Text = "Select Race";
            this.btn_SelectRace.UseVisualStyleBackColor = true;
            this.btn_SelectRace.Click += new System.EventHandler(this.btn_SelectRace_Click);
            // 
            // btn_EditCalendar
            // 
            this.btn_EditCalendar.Location = new System.Drawing.Point(25, 70);
            this.btn_EditCalendar.Name = "btn_EditCalendar";
            this.btn_EditCalendar.Size = new System.Drawing.Size(150, 40);
            this.btn_EditCalendar.TabIndex = 1;
            this.btn_EditCalendar.Text = "Edit Calendar";
            this.btn_EditCalendar.UseVisualStyleBackColor = true;
            this.btn_EditCalendar.Click += new System.EventHandler(this.btn_EditCalendar_Click);
            // 
            // btn_CreateCrew
            // 
            this.btn_CreateCrew.Location = new System.Drawing.Point(180, 25);
            this.btn_CreateCrew.Name = "btn_CreateCrew";
            this.btn_CreateCrew.Size = new System.Drawing.Size(150, 40);
            this.btn_CreateCrew.TabIndex = 2;
            this.btn_CreateCrew.Text = "Create Crew";
            this.btn_CreateCrew.UseVisualStyleBackColor = true;
            this.btn_CreateCrew.Click += new System.EventHandler(this.btn_CreateCrew_Click);
            // 
            // btn_DeleteCrew
            // 
            this.btn_DeleteCrew.Location = new System.Drawing.Point(180, 70);
            this.btn_DeleteCrew.Name = "btn_DeleteCrew";
            this.btn_DeleteCrew.Size = new System.Drawing.Size(150, 40);
            this.btn_DeleteCrew.TabIndex = 3;
            this.btn_DeleteCrew.Text = "Delete Crew";
            this.btn_DeleteCrew.UseVisualStyleBackColor = true;
            this.btn_DeleteCrew.Click += new System.EventHandler(this.btn_DeleteCrew_Click);
            // 
            // btn_EditCars
            // 
            this.btn_EditCars.Location = new System.Drawing.Point(25, 160);
            this.btn_EditCars.Name = "btn_EditCars";
            this.btn_EditCars.Size = new System.Drawing.Size(150, 40);
            this.btn_EditCars.TabIndex = 4;
            this.btn_EditCars.Text = "Edit Cars";
            this.btn_EditCars.UseVisualStyleBackColor = true;
            this.btn_EditCars.Click += new System.EventHandler(this.btn_EditCars_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(180, 160);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(150, 40);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close Program";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_ClassEditor
            // 
            this.btn_ClassEditor.Location = new System.Drawing.Point(25, 115);
            this.btn_ClassEditor.Name = "btn_ClassEditor";
            this.btn_ClassEditor.Size = new System.Drawing.Size(150, 40);
            this.btn_ClassEditor.TabIndex = 6;
            this.btn_ClassEditor.Text = "Edit Classes";
            this.btn_ClassEditor.UseVisualStyleBackColor = true;
            this.btn_ClassEditor.Click += new System.EventHandler(this.btn_ClassEditor_Click);
            // 
            // btn_CreateStandings
            // 
            this.btn_CreateStandings.Location = new System.Drawing.Point(180, 115);
            this.btn_CreateStandings.Name = "btn_CreateStandings";
            this.btn_CreateStandings.Size = new System.Drawing.Size(150, 40);
            this.btn_CreateStandings.TabIndex = 7;
            this.btn_CreateStandings.Text = "Create Standings";
            this.btn_CreateStandings.UseVisualStyleBackColor = true;
            this.btn_CreateStandings.Click += new System.EventHandler(this.btn_CreateStandings_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 223);
            this.Controls.Add(this.btn_CreateStandings);
            this.Controls.Add(this.btn_ClassEditor);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_EditCars);
            this.Controls.Add(this.btn_DeleteCrew);
            this.Controls.Add(this.btn_CreateCrew);
            this.Controls.Add(this.btn_EditCalendar);
            this.Controls.Add(this.btn_SelectRace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartWindow";
            this.Text = "Start Window - GEM V3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectRace;
        private System.Windows.Forms.Button btn_EditCalendar;
        private System.Windows.Forms.Button btn_CreateCrew;
        private System.Windows.Forms.Button btn_DeleteCrew;
        private System.Windows.Forms.Button btn_EditCars;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_ClassEditor;
        private System.Windows.Forms.Button btn_CreateStandings;
    }
}