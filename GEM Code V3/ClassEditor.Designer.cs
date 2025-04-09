namespace GEM_Code_V3
{
    partial class ClassEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassEditor));
            this.lb_Classes = new System.Windows.Forms.ListBox();
            this.tb_ClassName = new System.Windows.Forms.TextBox();
            this.lbl_ClassName = new System.Windows.Forms.Label();
            this.num_IncidentModifier = new System.Windows.Forms.NumericUpDown();
            this.lbl_IncidentRangeModifier = new System.Windows.Forms.Label();
            this.lbl_DNFModifier = new System.Windows.Forms.Label();
            this.num_DNFModifier = new System.Windows.Forms.NumericUpDown();
            this.lbl_StintRanges = new System.Windows.Forms.Label();
            this.lbl_StintRangeIncident = new System.Windows.Forms.Label();
            this.lbl_StintRangeHigh = new System.Windows.Forms.Label();
            this.lbl_StintRangeLow = new System.Windows.Forms.Label();
            this.num_StintRangeIncident = new System.Windows.Forms.NumericUpDown();
            this.num_StintRangeHigh = new System.Windows.Forms.NumericUpDown();
            this.num_StintRangeLow = new System.Windows.Forms.NumericUpDown();
            this.btn_SelectClass = new System.Windows.Forms.Button();
            this.btn_CreateClass = new System.Windows.Forms.Button();
            this.btn_UpdateClass = new System.Windows.Forms.Button();
            this.btn_DeleteClass = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.num_MinOVR = new System.Windows.Forms.NumericUpDown();
            this.num_MaxOVR = new System.Windows.Forms.NumericUpDown();
            this.lbl_MinOVR = new System.Windows.Forms.Label();
            this.lbl_MaxOVR = new System.Windows.Forms.Label();
            this.num_WECDTP = new System.Windows.Forms.NumericUpDown();
            this.num_IMSADTP = new System.Windows.Forms.NumericUpDown();
            this.num_LapDTP = new System.Windows.Forms.NumericUpDown();
            this.lbl_WECBased = new System.Windows.Forms.Label();
            this.lbl_IMSABased = new System.Windows.Forms.Label();
            this.lbl_LapCount = new System.Windows.Forms.Label();
            this.lbl_DistanceToStop = new System.Windows.Forms.Label();
            this.num_ClassIndex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_IncidentModifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DNFModifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeIncident)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinOVR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxOVR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WECDTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_IMSADTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_LapDTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ClassIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Classes
            // 
            this.lb_Classes.FormattingEnabled = true;
            this.lb_Classes.ItemHeight = 16;
            this.lb_Classes.Location = new System.Drawing.Point(25, 25);
            this.lb_Classes.Name = "lb_Classes";
            this.lb_Classes.Size = new System.Drawing.Size(120, 132);
            this.lb_Classes.TabIndex = 0;
            // 
            // tb_ClassName
            // 
            this.tb_ClassName.Location = new System.Drawing.Point(155, 45);
            this.tb_ClassName.Name = "tb_ClassName";
            this.tb_ClassName.Size = new System.Drawing.Size(235, 22);
            this.tb_ClassName.TabIndex = 1;
            // 
            // lbl_ClassName
            // 
            this.lbl_ClassName.AutoSize = true;
            this.lbl_ClassName.Location = new System.Drawing.Point(155, 25);
            this.lbl_ClassName.Name = "lbl_ClassName";
            this.lbl_ClassName.Size = new System.Drawing.Size(83, 17);
            this.lbl_ClassName.TabIndex = 2;
            this.lbl_ClassName.Text = "Class Name";
            // 
            // num_IncidentModifier
            // 
            this.num_IncidentModifier.Location = new System.Drawing.Point(320, 75);
            this.num_IncidentModifier.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.num_IncidentModifier.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.num_IncidentModifier.Name = "num_IncidentModifier";
            this.num_IncidentModifier.Size = new System.Drawing.Size(70, 22);
            this.num_IncidentModifier.TabIndex = 3;
            // 
            // lbl_IncidentRangeModifier
            // 
            this.lbl_IncidentRangeModifier.AutoSize = true;
            this.lbl_IncidentRangeModifier.Location = new System.Drawing.Point(155, 75);
            this.lbl_IncidentRangeModifier.Name = "lbl_IncidentRangeModifier";
            this.lbl_IncidentRangeModifier.Size = new System.Drawing.Size(157, 17);
            this.lbl_IncidentRangeModifier.TabIndex = 4;
            this.lbl_IncidentRangeModifier.Text = "Incident Range Modifier";
            // 
            // lbl_DNFModifier
            // 
            this.lbl_DNFModifier.AutoSize = true;
            this.lbl_DNFModifier.Location = new System.Drawing.Point(155, 105);
            this.lbl_DNFModifier.Name = "lbl_DNFModifier";
            this.lbl_DNFModifier.Size = new System.Drawing.Size(90, 17);
            this.lbl_DNFModifier.TabIndex = 6;
            this.lbl_DNFModifier.Text = "DNF Modifier";
            // 
            // num_DNFModifier
            // 
            this.num_DNFModifier.Location = new System.Drawing.Point(320, 105);
            this.num_DNFModifier.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_DNFModifier.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.num_DNFModifier.Name = "num_DNFModifier";
            this.num_DNFModifier.Size = new System.Drawing.Size(70, 22);
            this.num_DNFModifier.TabIndex = 5;
            // 
            // lbl_StintRanges
            // 
            this.lbl_StintRanges.AutoSize = true;
            this.lbl_StintRanges.Location = new System.Drawing.Point(400, 25);
            this.lbl_StintRanges.Name = "lbl_StintRanges";
            this.lbl_StintRanges.Size = new System.Drawing.Size(89, 17);
            this.lbl_StintRanges.TabIndex = 7;
            this.lbl_StintRanges.Text = "Stint Ranges";
            // 
            // lbl_StintRangeIncident
            // 
            this.lbl_StintRangeIncident.AutoSize = true;
            this.lbl_StintRangeIncident.Location = new System.Drawing.Point(400, 110);
            this.lbl_StintRangeIncident.Name = "lbl_StintRangeIncident";
            this.lbl_StintRangeIncident.Size = new System.Drawing.Size(57, 17);
            this.lbl_StintRangeIncident.TabIndex = 8;
            this.lbl_StintRangeIncident.Text = "Incident";
            // 
            // lbl_StintRangeHigh
            // 
            this.lbl_StintRangeHigh.AutoSize = true;
            this.lbl_StintRangeHigh.Location = new System.Drawing.Point(400, 80);
            this.lbl_StintRangeHigh.Name = "lbl_StintRangeHigh";
            this.lbl_StintRangeHigh.Size = new System.Drawing.Size(83, 17);
            this.lbl_StintRangeHigh.TabIndex = 9;
            this.lbl_StintRangeHigh.Text = "Range High";
            // 
            // lbl_StintRangeLow
            // 
            this.lbl_StintRangeLow.AutoSize = true;
            this.lbl_StintRangeLow.Location = new System.Drawing.Point(400, 50);
            this.lbl_StintRangeLow.Name = "lbl_StintRangeLow";
            this.lbl_StintRangeLow.Size = new System.Drawing.Size(79, 17);
            this.lbl_StintRangeLow.TabIndex = 10;
            this.lbl_StintRangeLow.Text = "Range Low";
            // 
            // num_StintRangeIncident
            // 
            this.num_StintRangeIncident.Location = new System.Drawing.Point(510, 110);
            this.num_StintRangeIncident.Maximum = new decimal(new int[] {
            395,
            0,
            0,
            0});
            this.num_StintRangeIncident.Name = "num_StintRangeIncident";
            this.num_StintRangeIncident.Size = new System.Drawing.Size(70, 22);
            this.num_StintRangeIncident.TabIndex = 11;
            // 
            // num_StintRangeHigh
            // 
            this.num_StintRangeHigh.Location = new System.Drawing.Point(510, 80);
            this.num_StintRangeHigh.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_StintRangeHigh.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_StintRangeHigh.Name = "num_StintRangeHigh";
            this.num_StintRangeHigh.Size = new System.Drawing.Size(70, 22);
            this.num_StintRangeHigh.TabIndex = 12;
            this.num_StintRangeHigh.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // num_StintRangeLow
            // 
            this.num_StintRangeLow.Location = new System.Drawing.Point(510, 50);
            this.num_StintRangeLow.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_StintRangeLow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_StintRangeLow.Name = "num_StintRangeLow";
            this.num_StintRangeLow.Size = new System.Drawing.Size(70, 22);
            this.num_StintRangeLow.TabIndex = 13;
            this.num_StintRangeLow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btn_SelectClass
            // 
            this.btn_SelectClass.Location = new System.Drawing.Point(25, 160);
            this.btn_SelectClass.Name = "btn_SelectClass";
            this.btn_SelectClass.Size = new System.Drawing.Size(120, 40);
            this.btn_SelectClass.TabIndex = 14;
            this.btn_SelectClass.Text = "Select Class";
            this.btn_SelectClass.UseVisualStyleBackColor = true;
            this.btn_SelectClass.Click += new System.EventHandler(this.btn_SelectClass_Click);
            // 
            // btn_CreateClass
            // 
            this.btn_CreateClass.Location = new System.Drawing.Point(25, 205);
            this.btn_CreateClass.Name = "btn_CreateClass";
            this.btn_CreateClass.Size = new System.Drawing.Size(120, 40);
            this.btn_CreateClass.TabIndex = 15;
            this.btn_CreateClass.Text = "Create Class";
            this.btn_CreateClass.UseVisualStyleBackColor = true;
            this.btn_CreateClass.Click += new System.EventHandler(this.btn_CreateClass_Click);
            // 
            // btn_UpdateClass
            // 
            this.btn_UpdateClass.Location = new System.Drawing.Point(25, 250);
            this.btn_UpdateClass.Name = "btn_UpdateClass";
            this.btn_UpdateClass.Size = new System.Drawing.Size(120, 40);
            this.btn_UpdateClass.TabIndex = 16;
            this.btn_UpdateClass.Text = "Update Class";
            this.btn_UpdateClass.UseVisualStyleBackColor = true;
            this.btn_UpdateClass.Click += new System.EventHandler(this.btn_UpdateClass_Click);
            // 
            // btn_DeleteClass
            // 
            this.btn_DeleteClass.Location = new System.Drawing.Point(155, 205);
            this.btn_DeleteClass.Name = "btn_DeleteClass";
            this.btn_DeleteClass.Size = new System.Drawing.Size(120, 40);
            this.btn_DeleteClass.TabIndex = 17;
            this.btn_DeleteClass.Text = "Delete Class";
            this.btn_DeleteClass.UseVisualStyleBackColor = true;
            this.btn_DeleteClass.Click += new System.EventHandler(this.btn_DeleteClass_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(155, 250);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(120, 40);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // num_MinOVR
            // 
            this.num_MinOVR.Location = new System.Drawing.Point(320, 150);
            this.num_MinOVR.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MinOVR.Name = "num_MinOVR";
            this.num_MinOVR.Size = new System.Drawing.Size(70, 22);
            this.num_MinOVR.TabIndex = 22;
            // 
            // num_MaxOVR
            // 
            this.num_MaxOVR.Location = new System.Drawing.Point(320, 180);
            this.num_MaxOVR.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MaxOVR.Name = "num_MaxOVR";
            this.num_MaxOVR.Size = new System.Drawing.Size(70, 22);
            this.num_MaxOVR.TabIndex = 21;
            // 
            // lbl_MinOVR
            // 
            this.lbl_MinOVR.AutoSize = true;
            this.lbl_MinOVR.Location = new System.Drawing.Point(155, 150);
            this.lbl_MinOVR.Name = "lbl_MinOVR";
            this.lbl_MinOVR.Size = new System.Drawing.Size(64, 17);
            this.lbl_MinOVR.TabIndex = 20;
            this.lbl_MinOVR.Text = "Min OVR";
            // 
            // lbl_MaxOVR
            // 
            this.lbl_MaxOVR.AutoSize = true;
            this.lbl_MaxOVR.Location = new System.Drawing.Point(155, 180);
            this.lbl_MaxOVR.Name = "lbl_MaxOVR";
            this.lbl_MaxOVR.Size = new System.Drawing.Size(67, 17);
            this.lbl_MaxOVR.TabIndex = 19;
            this.lbl_MaxOVR.Text = "Max OVR";
            // 
            // num_WECDTP
            // 
            this.num_WECDTP.Location = new System.Drawing.Point(510, 175);
            this.num_WECDTP.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_WECDTP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_WECDTP.Name = "num_WECDTP";
            this.num_WECDTP.Size = new System.Drawing.Size(70, 22);
            this.num_WECDTP.TabIndex = 29;
            this.num_WECDTP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_IMSADTP
            // 
            this.num_IMSADTP.Location = new System.Drawing.Point(510, 205);
            this.num_IMSADTP.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_IMSADTP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_IMSADTP.Name = "num_IMSADTP";
            this.num_IMSADTP.Size = new System.Drawing.Size(70, 22);
            this.num_IMSADTP.TabIndex = 28;
            this.num_IMSADTP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_LapDTP
            // 
            this.num_LapDTP.Location = new System.Drawing.Point(510, 235);
            this.num_LapDTP.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_LapDTP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_LapDTP.Name = "num_LapDTP";
            this.num_LapDTP.Size = new System.Drawing.Size(70, 22);
            this.num_LapDTP.TabIndex = 27;
            this.num_LapDTP.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lbl_WECBased
            // 
            this.lbl_WECBased.AutoSize = true;
            this.lbl_WECBased.Location = new System.Drawing.Point(400, 175);
            this.lbl_WECBased.Name = "lbl_WECBased";
            this.lbl_WECBased.Size = new System.Drawing.Size(83, 17);
            this.lbl_WECBased.TabIndex = 26;
            this.lbl_WECBased.Text = "WEC Based";
            // 
            // lbl_IMSABased
            // 
            this.lbl_IMSABased.AutoSize = true;
            this.lbl_IMSABased.Location = new System.Drawing.Point(400, 205);
            this.lbl_IMSABased.Name = "lbl_IMSABased";
            this.lbl_IMSABased.Size = new System.Drawing.Size(84, 17);
            this.lbl_IMSABased.TabIndex = 25;
            this.lbl_IMSABased.Text = "ISMA Based";
            // 
            // lbl_LapCount
            // 
            this.lbl_LapCount.AutoSize = true;
            this.lbl_LapCount.Location = new System.Drawing.Point(400, 235);
            this.lbl_LapCount.Name = "lbl_LapCount";
            this.lbl_LapCount.Size = new System.Drawing.Size(76, 17);
            this.lbl_LapCount.TabIndex = 24;
            this.lbl_LapCount.Text = "Lap Based";
            // 
            // lbl_DistanceToStop
            // 
            this.lbl_DistanceToStop.AutoSize = true;
            this.lbl_DistanceToStop.Location = new System.Drawing.Point(400, 150);
            this.lbl_DistanceToStop.Name = "lbl_DistanceToStop";
            this.lbl_DistanceToStop.Size = new System.Drawing.Size(111, 17);
            this.lbl_DistanceToStop.TabIndex = 23;
            this.lbl_DistanceToStop.Text = "Distance To Pits";
            // 
            // num_ClassIndex
            // 
            this.num_ClassIndex.Location = new System.Drawing.Point(320, 250);
            this.num_ClassIndex.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_ClassIndex.Name = "num_ClassIndex";
            this.num_ClassIndex.Size = new System.Drawing.Size(70, 22);
            this.num_ClassIndex.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Class Index";
            // 
            // ClassEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 313);
            this.Controls.Add(this.num_ClassIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_WECDTP);
            this.Controls.Add(this.num_IMSADTP);
            this.Controls.Add(this.num_LapDTP);
            this.Controls.Add(this.lbl_WECBased);
            this.Controls.Add(this.lbl_IMSABased);
            this.Controls.Add(this.lbl_LapCount);
            this.Controls.Add(this.lbl_DistanceToStop);
            this.Controls.Add(this.num_MinOVR);
            this.Controls.Add(this.num_MaxOVR);
            this.Controls.Add(this.lbl_MinOVR);
            this.Controls.Add(this.lbl_MaxOVR);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_DeleteClass);
            this.Controls.Add(this.btn_UpdateClass);
            this.Controls.Add(this.btn_CreateClass);
            this.Controls.Add(this.btn_SelectClass);
            this.Controls.Add(this.num_StintRangeLow);
            this.Controls.Add(this.num_StintRangeHigh);
            this.Controls.Add(this.num_StintRangeIncident);
            this.Controls.Add(this.lbl_StintRangeLow);
            this.Controls.Add(this.lbl_StintRangeHigh);
            this.Controls.Add(this.lbl_StintRangeIncident);
            this.Controls.Add(this.lbl_StintRanges);
            this.Controls.Add(this.lbl_DNFModifier);
            this.Controls.Add(this.num_DNFModifier);
            this.Controls.Add(this.lbl_IncidentRangeModifier);
            this.Controls.Add(this.num_IncidentModifier);
            this.Controls.Add(this.lbl_ClassName);
            this.Controls.Add(this.tb_ClassName);
            this.Controls.Add(this.lb_Classes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClassEditor";
            this.Text = "Class Editor - GEM V3";
            ((System.ComponentModel.ISupportInitialize)(this.num_IncidentModifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DNFModifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeIncident)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StintRangeLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinOVR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxOVR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WECDTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_IMSADTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_LapDTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ClassIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Classes;
        private System.Windows.Forms.TextBox tb_ClassName;
        private System.Windows.Forms.Label lbl_ClassName;
        private System.Windows.Forms.NumericUpDown num_IncidentModifier;
        private System.Windows.Forms.Label lbl_IncidentRangeModifier;
        private System.Windows.Forms.Label lbl_DNFModifier;
        private System.Windows.Forms.NumericUpDown num_DNFModifier;
        private System.Windows.Forms.Label lbl_StintRanges;
        private System.Windows.Forms.Label lbl_StintRangeIncident;
        private System.Windows.Forms.Label lbl_StintRangeHigh;
        private System.Windows.Forms.Label lbl_StintRangeLow;
        private System.Windows.Forms.NumericUpDown num_StintRangeIncident;
        private System.Windows.Forms.NumericUpDown num_StintRangeHigh;
        private System.Windows.Forms.NumericUpDown num_StintRangeLow;
        private System.Windows.Forms.Button btn_SelectClass;
        private System.Windows.Forms.Button btn_CreateClass;
        private System.Windows.Forms.Button btn_UpdateClass;
        private System.Windows.Forms.Button btn_DeleteClass;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.NumericUpDown num_MinOVR;
        private System.Windows.Forms.NumericUpDown num_MaxOVR;
        private System.Windows.Forms.Label lbl_MinOVR;
        private System.Windows.Forms.Label lbl_MaxOVR;
        private System.Windows.Forms.NumericUpDown num_WECDTP;
        private System.Windows.Forms.NumericUpDown num_IMSADTP;
        private System.Windows.Forms.NumericUpDown num_LapDTP;
        private System.Windows.Forms.Label lbl_WECBased;
        private System.Windows.Forms.Label lbl_IMSABased;
        private System.Windows.Forms.Label lbl_LapCount;
        private System.Windows.Forms.Label lbl_DistanceToStop;
        private System.Windows.Forms.NumericUpDown num_ClassIndex;
        private System.Windows.Forms.Label label1;
    }
}