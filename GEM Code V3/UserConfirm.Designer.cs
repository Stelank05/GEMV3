namespace GEM_Code_V3
{
    partial class UserConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserConfirm));
            this.btn_ChooseYes = new System.Windows.Forms.Button();
            this.btn_ChooseNo = new System.Windows.Forms.Button();
            this.tb_ShowMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ChooseYes
            // 
            this.btn_ChooseYes.Location = new System.Drawing.Point(25, 135);
            this.btn_ChooseYes.Name = "btn_ChooseYes";
            this.btn_ChooseYes.Size = new System.Drawing.Size(100, 40);
            this.btn_ChooseYes.TabIndex = 0;
            this.btn_ChooseYes.Text = "Yes I Am";
            this.btn_ChooseYes.UseVisualStyleBackColor = true;
            this.btn_ChooseYes.Click += new System.EventHandler(this.btn_ChooseYes_Click);
            // 
            // btn_ChooseNo
            // 
            this.btn_ChooseNo.Location = new System.Drawing.Point(140, 135);
            this.btn_ChooseNo.Name = "btn_ChooseNo";
            this.btn_ChooseNo.Size = new System.Drawing.Size(100, 40);
            this.btn_ChooseNo.TabIndex = 1;
            this.btn_ChooseNo.Text = "No I Am Not";
            this.btn_ChooseNo.UseVisualStyleBackColor = true;
            this.btn_ChooseNo.Click += new System.EventHandler(this.btn_ChooseNo_Click);
            // 
            // tb_ShowMessage
            // 
            this.tb_ShowMessage.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_ShowMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ShowMessage.Location = new System.Drawing.Point(25, 25);
            this.tb_ShowMessage.Multiline = true;
            this.tb_ShowMessage.Name = "tb_ShowMessage";
            this.tb_ShowMessage.Size = new System.Drawing.Size(215, 82);
            this.tb_ShowMessage.TabIndex = 2;
            this.tb_ShowMessage.Text = "The Default Class for the Chosen Car Model and Selected Competition Class don\'t m" +
    "atch, are you sure you want to continue?";
            this.tb_ShowMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 188);
            this.Controls.Add(this.tb_ShowMessage);
            this.Controls.Add(this.btn_ChooseNo);
            this.Controls.Add(this.btn_ChooseYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserConfirm";
            this.Text = "User Sure - GEM V3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ChooseYes;
        private System.Windows.Forms.Button btn_ChooseNo;
        private System.Windows.Forms.TextBox tb_ShowMessage;
    }
}