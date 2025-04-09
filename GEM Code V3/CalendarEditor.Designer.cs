namespace GEM_Code_V3
{
    partial class CalendarEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarEditor));
            this.lb_Calendar = new System.Windows.Forms.ListBox();
            this.btn_SelectRace = new System.Windows.Forms.Button();
            this.tb_RoundName = new System.Windows.Forms.TextBox();
            this.lbl_RoundName = new System.Windows.Forms.Label();
            this.lbl_LengthType = new System.Windows.Forms.Label();
            this.cb_LengthTypes = new System.Windows.Forms.ComboBox();
            this.num_RaceLength = new System.Windows.Forms.NumericUpDown();
            this.lbl_RaceLength = new System.Windows.Forms.Label();
            this.lbl_RoundNo = new System.Windows.Forms.Label();
            this.num_RoundNo = new System.Windows.Forms.NumericUpDown();
            this.lbl_DNFMod = new System.Windows.Forms.Label();
            this.num_DNFModifier = new System.Windows.Forms.NumericUpDown();
            this.cb_C1Racing = new System.Windows.Forms.CheckBox();
            this.lbl_ClassesRacing = new System.Windows.Forms.Label();
            this.cb_C8Racing = new System.Windows.Forms.CheckBox();
            this.cb_C7Racing = new System.Windows.Forms.CheckBox();
            this.cb_C6Racing = new System.Windows.Forms.CheckBox();
            this.cb_C5Racing = new System.Windows.Forms.CheckBox();
            this.cb_C4Racing = new System.Windows.Forms.CheckBox();
            this.cb_C3Racing = new System.Windows.Forms.CheckBox();
            this.cb_C2Racing = new System.Windows.Forms.CheckBox();
            this.btn_UpdateRace = new System.Windows.Forms.Button();
            this.btn_CreateRace = new System.Windows.Forms.Button();
            this.btn_DeleteRace = new System.Windows.Forms.Button();
            this.btn_Sort = new System.Windows.Forms.Button();
            this.btn_SaveCalendar = new System.Windows.Forms.Button();
            this.lbl_IncidentModifier = new System.Windows.Forms.Label();
            this.num_IncidentModifier = new System.Windows.Forms.NumericUpDown();
            this.btn_SelectAllClasses = new System.Windows.Forms.Button();
            this.cb_IsTest = new System.Windows.Forms.CheckBox();
            this.cb_QualifyingFormat = new System.Windows.Forms.ComboBox();
            this.lbl_QualifyingFormat = new System.Windows.Forms.Label();
            this.cb_PointsSystem = new System.Windows.Forms.ComboBox();
            this.lbl_PointsSystem = new System.Windows.Forms.Label();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_RaceLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RoundNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DNFModifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_IncidentModifier)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Calendar
            // 
            this.lb_Calendar.FormattingEnabled = true;
            this.lb_Calendar.ItemHeight = 16;
            this.lb_Calendar.Location = new System.Drawing.Point(25, 25);
            this.lb_Calendar.Name = "lb_Calendar";
            this.lb_Calendar.Size = new System.Drawing.Size(200, 260);
            this.lb_Calendar.TabIndex = 1;
            this.lb_Calendar.SelectedIndexChanged += new System.EventHandler(this.lb_Calendar_SelectedIndexChanged);
            // 
            // btn_SelectRace
            // 
            this.btn_SelectRace.Location = new System.Drawing.Point(25, 290);
            this.btn_SelectRace.Name = "btn_SelectRace";
            this.btn_SelectRace.Size = new System.Drawing.Size(200, 40);
            this.btn_SelectRace.TabIndex = 2;
            this.btn_SelectRace.Text = "Select Race";
            this.btn_SelectRace.UseVisualStyleBackColor = true;
            this.btn_SelectRace.Click += new System.EventHandler(this.btn_SelectRace_Click);
            // 
            // tb_RoundName
            // 
            this.tb_RoundName.Location = new System.Drawing.Point(240, 45);
            this.tb_RoundName.Name = "tb_RoundName";
            this.tb_RoundName.Size = new System.Drawing.Size(220, 22);
            this.tb_RoundName.TabIndex = 3;
            // 
            // lbl_RoundName
            // 
            this.lbl_RoundName.AutoSize = true;
            this.lbl_RoundName.Location = new System.Drawing.Point(240, 25);
            this.lbl_RoundName.Name = "lbl_RoundName";
            this.lbl_RoundName.Size = new System.Drawing.Size(91, 17);
            this.lbl_RoundName.TabIndex = 40;
            this.lbl_RoundName.Text = "Round Name";
            // 
            // lbl_LengthType
            // 
            this.lbl_LengthType.AutoSize = true;
            this.lbl_LengthType.Location = new System.Drawing.Point(240, 80);
            this.lbl_LengthType.Name = "lbl_LengthType";
            this.lbl_LengthType.Size = new System.Drawing.Size(88, 17);
            this.lbl_LengthType.TabIndex = 40;
            this.lbl_LengthType.Text = "Length Type";
            // 
            // cb_LengthTypes
            // 
            this.cb_LengthTypes.FormattingEnabled = true;
            this.cb_LengthTypes.Location = new System.Drawing.Point(365, 80);
            this.cb_LengthTypes.Name = "cb_LengthTypes";
            this.cb_LengthTypes.Size = new System.Drawing.Size(95, 24);
            this.cb_LengthTypes.TabIndex = 4;
            this.cb_LengthTypes.SelectedIndexChanged += new System.EventHandler(this.cb_LengthTypes_SelectedIndexChanged);
            // 
            // num_RaceLength
            // 
            this.num_RaceLength.Location = new System.Drawing.Point(365, 115);
            this.num_RaceLength.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.num_RaceLength.Name = "num_RaceLength";
            this.num_RaceLength.Size = new System.Drawing.Size(95, 22);
            this.num_RaceLength.TabIndex = 5;
            // 
            // lbl_RaceLength
            // 
            this.lbl_RaceLength.AutoSize = true;
            this.lbl_RaceLength.Location = new System.Drawing.Point(240, 115);
            this.lbl_RaceLength.Name = "lbl_RaceLength";
            this.lbl_RaceLength.Size = new System.Drawing.Size(89, 17);
            this.lbl_RaceLength.TabIndex = 40;
            this.lbl_RaceLength.Text = "Race Length";
            // 
            // lbl_RoundNo
            // 
            this.lbl_RoundNo.AutoSize = true;
            this.lbl_RoundNo.Location = new System.Drawing.Point(240, 220);
            this.lbl_RoundNo.Name = "lbl_RoundNo";
            this.lbl_RoundNo.Size = new System.Drawing.Size(104, 17);
            this.lbl_RoundNo.TabIndex = 40;
            this.lbl_RoundNo.Text = "Round Number";
            // 
            // num_RoundNo
            // 
            this.num_RoundNo.Location = new System.Drawing.Point(365, 220);
            this.num_RoundNo.Name = "num_RoundNo";
            this.num_RoundNo.Size = new System.Drawing.Size(95, 22);
            this.num_RoundNo.TabIndex = 8;
            // 
            // lbl_DNFMod
            // 
            this.lbl_DNFMod.AutoSize = true;
            this.lbl_DNFMod.Location = new System.Drawing.Point(240, 185);
            this.lbl_DNFMod.Name = "lbl_DNFMod";
            this.lbl_DNFMod.Size = new System.Drawing.Size(90, 17);
            this.lbl_DNFMod.TabIndex = 40;
            this.lbl_DNFMod.Text = "DNF Modifier";
            // 
            // num_DNFModifier
            // 
            this.num_DNFModifier.Location = new System.Drawing.Point(365, 185);
            this.num_DNFModifier.Name = "num_DNFModifier";
            this.num_DNFModifier.Size = new System.Drawing.Size(95, 22);
            this.num_DNFModifier.TabIndex = 7;
            // 
            // cb_C1Racing
            // 
            this.cb_C1Racing.AutoSize = true;
            this.cb_C1Racing.Location = new System.Drawing.Point(475, 55);
            this.cb_C1Racing.Name = "cb_C1Racing";
            this.cb_C1Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C1Racing.TabIndex = 12;
            this.cb_C1Racing.Text = "Class 1 Racing";
            this.cb_C1Racing.UseVisualStyleBackColor = true;
            // 
            // lbl_ClassesRacing
            // 
            this.lbl_ClassesRacing.AutoSize = true;
            this.lbl_ClassesRacing.Location = new System.Drawing.Point(475, 25);
            this.lbl_ClassesRacing.Name = "lbl_ClassesRacing";
            this.lbl_ClassesRacing.Size = new System.Drawing.Size(105, 17);
            this.lbl_ClassesRacing.TabIndex = 40;
            this.lbl_ClassesRacing.Text = "Classes Racing";
            this.lbl_ClassesRacing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_C8Racing
            // 
            this.cb_C8Racing.AutoSize = true;
            this.cb_C8Racing.Location = new System.Drawing.Point(475, 300);
            this.cb_C8Racing.Name = "cb_C8Racing";
            this.cb_C8Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C8Racing.TabIndex = 19;
            this.cb_C8Racing.Text = "Class 8 Racing";
            this.cb_C8Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C7Racing
            // 
            this.cb_C7Racing.AutoSize = true;
            this.cb_C7Racing.Location = new System.Drawing.Point(475, 265);
            this.cb_C7Racing.Name = "cb_C7Racing";
            this.cb_C7Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C7Racing.TabIndex = 18;
            this.cb_C7Racing.Text = "Class 7 Racing";
            this.cb_C7Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C6Racing
            // 
            this.cb_C6Racing.AutoSize = true;
            this.cb_C6Racing.Location = new System.Drawing.Point(475, 230);
            this.cb_C6Racing.Name = "cb_C6Racing";
            this.cb_C6Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C6Racing.TabIndex = 17;
            this.cb_C6Racing.Text = "Class 6 Racing";
            this.cb_C6Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C5Racing
            // 
            this.cb_C5Racing.AutoSize = true;
            this.cb_C5Racing.Location = new System.Drawing.Point(475, 195);
            this.cb_C5Racing.Name = "cb_C5Racing";
            this.cb_C5Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C5Racing.TabIndex = 16;
            this.cb_C5Racing.Text = "Class 5 Racing";
            this.cb_C5Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C4Racing
            // 
            this.cb_C4Racing.AutoSize = true;
            this.cb_C4Racing.Location = new System.Drawing.Point(475, 160);
            this.cb_C4Racing.Name = "cb_C4Racing";
            this.cb_C4Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C4Racing.TabIndex = 15;
            this.cb_C4Racing.Text = "Class 4 Racing";
            this.cb_C4Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C3Racing
            // 
            this.cb_C3Racing.AutoSize = true;
            this.cb_C3Racing.Location = new System.Drawing.Point(475, 125);
            this.cb_C3Racing.Name = "cb_C3Racing";
            this.cb_C3Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C3Racing.TabIndex = 14;
            this.cb_C3Racing.Text = "Class 3 Racing";
            this.cb_C3Racing.UseVisualStyleBackColor = true;
            // 
            // cb_C2Racing
            // 
            this.cb_C2Racing.AutoSize = true;
            this.cb_C2Racing.Location = new System.Drawing.Point(475, 90);
            this.cb_C2Racing.Name = "cb_C2Racing";
            this.cb_C2Racing.Size = new System.Drawing.Size(124, 21);
            this.cb_C2Racing.TabIndex = 13;
            this.cb_C2Racing.Text = "Class 2 Racing";
            this.cb_C2Racing.UseVisualStyleBackColor = true;
            // 
            // btn_UpdateRace
            // 
            this.btn_UpdateRace.Location = new System.Drawing.Point(25, 335);
            this.btn_UpdateRace.Name = "btn_UpdateRace";
            this.btn_UpdateRace.Size = new System.Drawing.Size(105, 40);
            this.btn_UpdateRace.TabIndex = 23;
            this.btn_UpdateRace.Text = "Update Race";
            this.btn_UpdateRace.UseVisualStyleBackColor = true;
            this.btn_UpdateRace.Click += new System.EventHandler(this.btn_UpdateRace_Click);
            // 
            // btn_CreateRace
            // 
            this.btn_CreateRace.Location = new System.Drawing.Point(240, 380);
            this.btn_CreateRace.Name = "btn_CreateRace";
            this.btn_CreateRace.Size = new System.Drawing.Size(220, 40);
            this.btn_CreateRace.TabIndex = 22;
            this.btn_CreateRace.Text = "Create Race";
            this.btn_CreateRace.UseVisualStyleBackColor = true;
            this.btn_CreateRace.Click += new System.EventHandler(this.btn_CreateRace_Click);
            // 
            // btn_DeleteRace
            // 
            this.btn_DeleteRace.Location = new System.Drawing.Point(25, 380);
            this.btn_DeleteRace.Name = "btn_DeleteRace";
            this.btn_DeleteRace.Size = new System.Drawing.Size(105, 40);
            this.btn_DeleteRace.TabIndex = 24;
            this.btn_DeleteRace.Text = "Delete Race";
            this.btn_DeleteRace.UseVisualStyleBackColor = true;
            this.btn_DeleteRace.Click += new System.EventHandler(this.btn_DeleteRace_Click);
            // 
            // btn_Sort
            // 
            this.btn_Sort.Location = new System.Drawing.Point(140, 380);
            this.btn_Sort.Name = "btn_Sort";
            this.btn_Sort.Size = new System.Drawing.Size(85, 40);
            this.btn_Sort.TabIndex = 25;
            this.btn_Sort.Text = "Sort";
            this.btn_Sort.UseVisualStyleBackColor = true;
            this.btn_Sort.Click += new System.EventHandler(this.btn_Sort_Click);
            // 
            // btn_SaveCalendar
            // 
            this.btn_SaveCalendar.Location = new System.Drawing.Point(140, 335);
            this.btn_SaveCalendar.Name = "btn_SaveCalendar";
            this.btn_SaveCalendar.Size = new System.Drawing.Size(85, 40);
            this.btn_SaveCalendar.TabIndex = 26;
            this.btn_SaveCalendar.Text = "Save";
            this.btn_SaveCalendar.UseVisualStyleBackColor = true;
            this.btn_SaveCalendar.Click += new System.EventHandler(this.btn_SaveCalendar_Click);
            // 
            // lbl_IncidentModifier
            // 
            this.lbl_IncidentModifier.AutoSize = true;
            this.lbl_IncidentModifier.Location = new System.Drawing.Point(240, 150);
            this.lbl_IncidentModifier.Name = "lbl_IncidentModifier";
            this.lbl_IncidentModifier.Size = new System.Drawing.Size(111, 17);
            this.lbl_IncidentModifier.TabIndex = 40;
            this.lbl_IncidentModifier.Text = "Incident Modifier";
            // 
            // num_IncidentModifier
            // 
            this.num_IncidentModifier.Location = new System.Drawing.Point(365, 150);
            this.num_IncidentModifier.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_IncidentModifier.Name = "num_IncidentModifier";
            this.num_IncidentModifier.Size = new System.Drawing.Size(95, 22);
            this.num_IncidentModifier.TabIndex = 6;
            // 
            // btn_SelectAllClasses
            // 
            this.btn_SelectAllClasses.Location = new System.Drawing.Point(475, 335);
            this.btn_SelectAllClasses.Name = "btn_SelectAllClasses";
            this.btn_SelectAllClasses.Size = new System.Drawing.Size(125, 40);
            this.btn_SelectAllClasses.TabIndex = 20;
            this.btn_SelectAllClasses.Text = "Select All";
            this.btn_SelectAllClasses.UseVisualStyleBackColor = true;
            this.btn_SelectAllClasses.Click += new System.EventHandler(this.btn_SelectAllClasses_Click);
            // 
            // cb_IsTest
            // 
            this.cb_IsTest.AutoSize = true;
            this.cb_IsTest.Location = new System.Drawing.Point(240, 335);
            this.cb_IsTest.Name = "cb_IsTest";
            this.cb_IsTest.Size = new System.Drawing.Size(118, 21);
            this.cb_IsTest.TabIndex = 11;
            this.cb_IsTest.Text = "Round Is Test";
            this.cb_IsTest.UseVisualStyleBackColor = true;
            // 
            // cb_QualifyingFormat
            // 
            this.cb_QualifyingFormat.FormattingEnabled = true;
            this.cb_QualifyingFormat.Location = new System.Drawing.Point(365, 255);
            this.cb_QualifyingFormat.Name = "cb_QualifyingFormat";
            this.cb_QualifyingFormat.Size = new System.Drawing.Size(95, 24);
            this.cb_QualifyingFormat.TabIndex = 9;
            // 
            // lbl_QualifyingFormat
            // 
            this.lbl_QualifyingFormat.AutoSize = true;
            this.lbl_QualifyingFormat.Location = new System.Drawing.Point(240, 255);
            this.lbl_QualifyingFormat.Name = "lbl_QualifyingFormat";
            this.lbl_QualifyingFormat.Size = new System.Drawing.Size(119, 17);
            this.lbl_QualifyingFormat.TabIndex = 40;
            this.lbl_QualifyingFormat.Text = "Qualifying Format";
            // 
            // cb_PointsSystem
            // 
            this.cb_PointsSystem.FormattingEnabled = true;
            this.cb_PointsSystem.Location = new System.Drawing.Point(365, 290);
            this.cb_PointsSystem.Name = "cb_PointsSystem";
            this.cb_PointsSystem.Size = new System.Drawing.Size(95, 24);
            this.cb_PointsSystem.TabIndex = 10;
            // 
            // lbl_PointsSystem
            // 
            this.lbl_PointsSystem.AutoSize = true;
            this.lbl_PointsSystem.Location = new System.Drawing.Point(240, 290);
            this.lbl_PointsSystem.Name = "lbl_PointsSystem";
            this.lbl_PointsSystem.Size = new System.Drawing.Size(97, 17);
            this.lbl_PointsSystem.TabIndex = 40;
            this.lbl_PointsSystem.Text = "Points System";
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.Location = new System.Drawing.Point(475, 380);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(125, 40);
            this.btn_DeselectAll.TabIndex = 21;
            this.btn_DeselectAll.Text = "Deselect All";
            this.btn_DeselectAll.UseVisualStyleBackColor = true;
            this.btn_DeselectAll.Click += new System.EventHandler(this.btn_DeselectAll_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(375, 335);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(85, 40);
            this.btn_Clear.TabIndex = 35;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // CalendarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 443);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_DeselectAll);
            this.Controls.Add(this.cb_PointsSystem);
            this.Controls.Add(this.lbl_PointsSystem);
            this.Controls.Add(this.cb_QualifyingFormat);
            this.Controls.Add(this.lbl_QualifyingFormat);
            this.Controls.Add(this.cb_IsTest);
            this.Controls.Add(this.btn_SelectAllClasses);
            this.Controls.Add(this.lbl_IncidentModifier);
            this.Controls.Add(this.num_IncidentModifier);
            this.Controls.Add(this.btn_SaveCalendar);
            this.Controls.Add(this.btn_DeleteRace);
            this.Controls.Add(this.btn_Sort);
            this.Controls.Add(this.btn_CreateRace);
            this.Controls.Add(this.btn_UpdateRace);
            this.Controls.Add(this.cb_C2Racing);
            this.Controls.Add(this.cb_C3Racing);
            this.Controls.Add(this.cb_C4Racing);
            this.Controls.Add(this.cb_C5Racing);
            this.Controls.Add(this.cb_C6Racing);
            this.Controls.Add(this.cb_C7Racing);
            this.Controls.Add(this.cb_C8Racing);
            this.Controls.Add(this.lbl_ClassesRacing);
            this.Controls.Add(this.cb_C1Racing);
            this.Controls.Add(this.lbl_DNFMod);
            this.Controls.Add(this.num_DNFModifier);
            this.Controls.Add(this.lbl_RoundNo);
            this.Controls.Add(this.num_RoundNo);
            this.Controls.Add(this.lbl_RaceLength);
            this.Controls.Add(this.num_RaceLength);
            this.Controls.Add(this.cb_LengthTypes);
            this.Controls.Add(this.lbl_LengthType);
            this.Controls.Add(this.lbl_RoundName);
            this.Controls.Add(this.tb_RoundName);
            this.Controls.Add(this.btn_SelectRace);
            this.Controls.Add(this.lb_Calendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalendarEditor";
            this.Text = "Calendar Editor - GEM V3";
            ((System.ComponentModel.ISupportInitialize)(this.num_RaceLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RoundNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DNFModifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_IncidentModifier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Calendar;
        private System.Windows.Forms.Button btn_SelectRace;
        private System.Windows.Forms.TextBox tb_RoundName;
        private System.Windows.Forms.Label lbl_RoundName;
        private System.Windows.Forms.Label lbl_LengthType;
        private System.Windows.Forms.ComboBox cb_LengthTypes;
        private System.Windows.Forms.NumericUpDown num_RaceLength;
        private System.Windows.Forms.Label lbl_RaceLength;
        private System.Windows.Forms.Label lbl_RoundNo;
        private System.Windows.Forms.NumericUpDown num_RoundNo;
        private System.Windows.Forms.Label lbl_DNFMod;
        private System.Windows.Forms.NumericUpDown num_DNFModifier;
        private System.Windows.Forms.CheckBox cb_C1Racing;
        private System.Windows.Forms.Label lbl_ClassesRacing;
        private System.Windows.Forms.CheckBox cb_C8Racing;
        private System.Windows.Forms.CheckBox cb_C7Racing;
        private System.Windows.Forms.CheckBox cb_C6Racing;
        private System.Windows.Forms.CheckBox cb_C5Racing;
        private System.Windows.Forms.CheckBox cb_C4Racing;
        private System.Windows.Forms.CheckBox cb_C3Racing;
        private System.Windows.Forms.CheckBox cb_C2Racing;
        private System.Windows.Forms.Button btn_UpdateRace;
        private System.Windows.Forms.Button btn_CreateRace;
        private System.Windows.Forms.Button btn_DeleteRace;
        private System.Windows.Forms.Button btn_SaveCalendar;
        private System.Windows.Forms.Button btn_Sort;
        private System.Windows.Forms.Label lbl_IncidentModifier;
        private System.Windows.Forms.NumericUpDown num_IncidentModifier;
        private System.Windows.Forms.Button btn_SelectAllClasses;
        private System.Windows.Forms.CheckBox cb_IsTest;
        private System.Windows.Forms.ComboBox cb_QualifyingFormat;
        private System.Windows.Forms.Label lbl_QualifyingFormat;
        private System.Windows.Forms.ComboBox cb_PointsSystem;
        private System.Windows.Forms.Label lbl_PointsSystem;
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Button btn_Clear;
    }
}