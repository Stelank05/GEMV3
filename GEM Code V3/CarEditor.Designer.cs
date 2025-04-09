namespace GEM_Code_V3
{
    partial class CarEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarEditor));
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_UpdateCar = new System.Windows.Forms.Button();
            this.btn_DeleteCar = new System.Windows.Forms.Button();
            this.btn_CreateCar = new System.Windows.Forms.Button();
            this.lbl_Reliability = new System.Windows.Forms.TextBox();
            this.tb_Reliability = new System.Windows.Forms.TextBox();
            this.lbl_BOP = new System.Windows.Forms.TextBox();
            this.tb_BOP = new System.Windows.Forms.TextBox();
            this.lbl_CarClass = new System.Windows.Forms.TextBox();
            this.cb_Classes = new System.Windows.Forms.ComboBox();
            this.lbl_OVR = new System.Windows.Forms.TextBox();
            this.tb_OVR = new System.Windows.Forms.TextBox();
            this.tb_TNL = new System.Windows.Forms.TextBox();
            this.tb_CN = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btnLocateFile = new System.Windows.Forms.Button();
            this.lb_ChooseCar = new System.Windows.Forms.ListBox();
            this.FileLocator = new System.Windows.Forms.OpenFileDialog();
            this.tb_Manufacturer = new System.Windows.Forms.TextBox();
            this.lbl_Manufacturer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(240, 275);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 35);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_UpdateCar
            // 
            this.btn_UpdateCar.Location = new System.Drawing.Point(240, 234);
            this.btn_UpdateCar.Name = "btn_UpdateCar";
            this.btn_UpdateCar.Size = new System.Drawing.Size(110, 35);
            this.btn_UpdateCar.TabIndex = 7;
            this.btn_UpdateCar.Text = "Update Car";
            this.btn_UpdateCar.UseVisualStyleBackColor = true;
            this.btn_UpdateCar.Click += new System.EventHandler(this.btn_UpdateCar_Click);
            // 
            // btn_DeleteCar
            // 
            this.btn_DeleteCar.Location = new System.Drawing.Point(360, 275);
            this.btn_DeleteCar.Name = "btn_DeleteCar";
            this.btn_DeleteCar.Size = new System.Drawing.Size(90, 35);
            this.btn_DeleteCar.TabIndex = 25;
            this.btn_DeleteCar.Text = "Delete Car";
            this.btn_DeleteCar.UseVisualStyleBackColor = true;
            this.btn_DeleteCar.Click += new System.EventHandler(this.btn_DeleteCar_Click);
            // 
            // btn_CreateCar
            // 
            this.btn_CreateCar.Location = new System.Drawing.Point(360, 234);
            this.btn_CreateCar.Name = "btn_CreateCar";
            this.btn_CreateCar.Size = new System.Drawing.Size(90, 35);
            this.btn_CreateCar.TabIndex = 8;
            this.btn_CreateCar.Text = "Create Car";
            this.btn_CreateCar.UseVisualStyleBackColor = true;
            this.btn_CreateCar.Click += new System.EventHandler(this.btn_CreateCar_Click);
            // 
            // lbl_Reliability
            // 
            this.lbl_Reliability.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Reliability.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Reliability.Location = new System.Drawing.Point(240, 170);
            this.lbl_Reliability.Name = "lbl_Reliability";
            this.lbl_Reliability.ReadOnly = true;
            this.lbl_Reliability.Size = new System.Drawing.Size(100, 15);
            this.lbl_Reliability.TabIndex = 18;
            this.lbl_Reliability.Text = "Car Reliability:";
            // 
            // tb_Reliability
            // 
            this.tb_Reliability.Location = new System.Drawing.Point(350, 170);
            this.tb_Reliability.Name = "tb_Reliability";
            this.tb_Reliability.Size = new System.Drawing.Size(100, 22);
            this.tb_Reliability.TabIndex = 5;
            // 
            // lbl_BOP
            // 
            this.lbl_BOP.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_BOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_BOP.Location = new System.Drawing.Point(240, 140);
            this.lbl_BOP.Name = "lbl_BOP";
            this.lbl_BOP.ReadOnly = true;
            this.lbl_BOP.Size = new System.Drawing.Size(100, 15);
            this.lbl_BOP.TabIndex = 16;
            this.lbl_BOP.Text = "Car BoP:";
            // 
            // tb_BOP
            // 
            this.tb_BOP.Location = new System.Drawing.Point(350, 140);
            this.tb_BOP.Name = "tb_BOP";
            this.tb_BOP.Size = new System.Drawing.Size(100, 22);
            this.tb_BOP.TabIndex = 4;
            // 
            // lbl_CarClass
            // 
            this.lbl_CarClass.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CarClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_CarClass.Location = new System.Drawing.Point(240, 200);
            this.lbl_CarClass.Name = "lbl_CarClass";
            this.lbl_CarClass.ReadOnly = true;
            this.lbl_CarClass.Size = new System.Drawing.Size(100, 15);
            this.lbl_CarClass.TabIndex = 11;
            this.lbl_CarClass.Text = "Car Class:";
            // 
            // cb_Classes
            // 
            this.cb_Classes.FormattingEnabled = true;
            this.cb_Classes.Location = new System.Drawing.Point(350, 200);
            this.cb_Classes.Name = "cb_Classes";
            this.cb_Classes.Size = new System.Drawing.Size(100, 24);
            this.cb_Classes.TabIndex = 6;
            // 
            // lbl_OVR
            // 
            this.lbl_OVR.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_OVR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_OVR.Location = new System.Drawing.Point(240, 110);
            this.lbl_OVR.Name = "lbl_OVR";
            this.lbl_OVR.ReadOnly = true;
            this.lbl_OVR.Size = new System.Drawing.Size(100, 15);
            this.lbl_OVR.TabIndex = 14;
            this.lbl_OVR.Text = "Car OVR:";
            // 
            // tb_OVR
            // 
            this.tb_OVR.Location = new System.Drawing.Point(350, 110);
            this.tb_OVR.Name = "tb_OVR";
            this.tb_OVR.Size = new System.Drawing.Size(100, 22);
            this.tb_OVR.TabIndex = 3;
            // 
            // tb_TNL
            // 
            this.tb_TNL.BackColor = System.Drawing.SystemColors.Control;
            this.tb_TNL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_TNL.Location = new System.Drawing.Point(240, 30);
            this.tb_TNL.Name = "tb_TNL";
            this.tb_TNL.ReadOnly = true;
            this.tb_TNL.Size = new System.Drawing.Size(100, 15);
            this.tb_TNL.TabIndex = 13;
            this.tb_TNL.Text = "Car Name:";
            // 
            // tb_CN
            // 
            this.tb_CN.Location = new System.Drawing.Point(240, 50);
            this.tb_CN.Name = "tb_CN";
            this.tb_CN.Size = new System.Drawing.Size(210, 22);
            this.tb_CN.TabIndex = 1;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(161, 275);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(64, 35);
            this.btn_Clear.TabIndex = 12;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btnLocateFile
            // 
            this.btnLocateFile.Location = new System.Drawing.Point(25, 275);
            this.btnLocateFile.Name = "btnLocateFile";
            this.btnLocateFile.Size = new System.Drawing.Size(130, 35);
            this.btnLocateFile.TabIndex = 15;
            this.btnLocateFile.Text = "Locate File";
            this.btnLocateFile.UseVisualStyleBackColor = true;
            this.btnLocateFile.Click += new System.EventHandler(this.btnLocateFile_Click);
            // 
            // lb_ChooseCar
            // 
            this.lb_ChooseCar.FormattingEnabled = true;
            this.lb_ChooseCar.ItemHeight = 16;
            this.lb_ChooseCar.Location = new System.Drawing.Point(25, 25);
            this.lb_ChooseCar.Name = "lb_ChooseCar";
            this.lb_ChooseCar.Size = new System.Drawing.Size(200, 244);
            this.lb_ChooseCar.TabIndex = 17;
            this.lb_ChooseCar.SelectedIndexChanged += new System.EventHandler(this.lb_ChooseCar_SelectedIndexChanged);
            // 
            // FileLocator
            // 
            this.FileLocator.FileName = "File Locator";
            // 
            // tb_Manufacturer
            // 
            this.tb_Manufacturer.Location = new System.Drawing.Point(350, 80);
            this.tb_Manufacturer.Name = "tb_Manufacturer";
            this.tb_Manufacturer.Size = new System.Drawing.Size(100, 22);
            this.tb_Manufacturer.TabIndex = 2;
            // 
            // lbl_Manufacturer
            // 
            this.lbl_Manufacturer.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Manufacturer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Manufacturer.Location = new System.Drawing.Point(240, 80);
            this.lbl_Manufacturer.Name = "lbl_Manufacturer";
            this.lbl_Manufacturer.ReadOnly = true;
            this.lbl_Manufacturer.Size = new System.Drawing.Size(100, 15);
            this.lbl_Manufacturer.TabIndex = 30;
            this.lbl_Manufacturer.Text = "Manufacturer:";
            // 
            // CarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 333);
            this.Controls.Add(this.lbl_Manufacturer);
            this.Controls.Add(this.tb_Manufacturer);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_UpdateCar);
            this.Controls.Add(this.btn_DeleteCar);
            this.Controls.Add(this.btn_CreateCar);
            this.Controls.Add(this.lbl_Reliability);
            this.Controls.Add(this.tb_Reliability);
            this.Controls.Add(this.lbl_BOP);
            this.Controls.Add(this.tb_BOP);
            this.Controls.Add(this.lbl_CarClass);
            this.Controls.Add(this.cb_Classes);
            this.Controls.Add(this.lbl_OVR);
            this.Controls.Add(this.tb_OVR);
            this.Controls.Add(this.tb_TNL);
            this.Controls.Add(this.tb_CN);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btnLocateFile);
            this.Controls.Add(this.lb_ChooseCar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CarEditor";
            this.Text = "Car Editor - GEM V3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_UpdateCar;
        private System.Windows.Forms.Button btn_DeleteCar;
        private System.Windows.Forms.Button btn_CreateCar;
        private System.Windows.Forms.TextBox lbl_Reliability;
        private System.Windows.Forms.TextBox tb_Reliability;
        private System.Windows.Forms.TextBox lbl_BOP;
        private System.Windows.Forms.TextBox tb_BOP;
        private System.Windows.Forms.TextBox lbl_CarClass;
        private System.Windows.Forms.ComboBox cb_Classes;
        private System.Windows.Forms.TextBox lbl_OVR;
        private System.Windows.Forms.TextBox tb_OVR;
        private System.Windows.Forms.TextBox tb_TNL;
        private System.Windows.Forms.TextBox tb_CN;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btnLocateFile;
        private System.Windows.Forms.ListBox lb_ChooseCar;
        private System.Windows.Forms.OpenFileDialog FileLocator;
        private System.Windows.Forms.TextBox tb_Manufacturer;
        private System.Windows.Forms.TextBox lbl_Manufacturer;
    }
}