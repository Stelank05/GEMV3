namespace GEM_Code_V3
{
    partial class SelectRace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRace));
            this.btn_ChooseRnd = new System.Windows.Forms.Button();
            this.lb_Calendar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_ChooseRnd
            // 
            this.btn_ChooseRnd.Location = new System.Drawing.Point(25, 275);
            this.btn_ChooseRnd.Name = "btn_ChooseRnd";
            this.btn_ChooseRnd.Size = new System.Drawing.Size(200, 40);
            this.btn_ChooseRnd.TabIndex = 3;
            this.btn_ChooseRnd.Text = "Select Race";
            this.btn_ChooseRnd.UseVisualStyleBackColor = true;
            this.btn_ChooseRnd.Click += new System.EventHandler(this.btn_ChooseRnd_Click);
            // 
            // lb_Calendar
            // 
            this.lb_Calendar.FormattingEnabled = true;
            this.lb_Calendar.ItemHeight = 16;
            this.lb_Calendar.Location = new System.Drawing.Point(25, 25);
            this.lb_Calendar.Name = "lb_Calendar";
            this.lb_Calendar.Size = new System.Drawing.Size(200, 244);
            this.lb_Calendar.TabIndex = 2;
            // 
            // SelectRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 338);
            this.Controls.Add(this.btn_ChooseRnd);
            this.Controls.Add(this.lb_Calendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectRace";
            this.Text = "Select Race - GEM V3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ChooseRnd;
        private System.Windows.Forms.ListBox lb_Calendar;
    }
}