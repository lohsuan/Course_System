
namespace CourseSystem
{
    partial class CourseSelectionResultForm
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
            this._courseSelectionResultDataGridView = new System.Windows.Forms.DataGridView();
            this._number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._requireType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTimeSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numberOfStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numberOfDropStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._teacherAssistant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._syllabus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._audit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._experiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectionResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseSelectionResultDataGridView
            // 
            this._courseSelectionResultDataGridView.AllowUserToAddRows = false;
            this._courseSelectionResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._courseSelectionResultDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._courseSelectionResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseSelectionResultDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._number,
            this._name,
            this._stage,
            this._credit,
            this._hour,
            this._requireType,
            this._teacher,
            this._classTimeSunday,
            this._classTimeMonday,
            this._classTimeTuesday,
            this._classTimeWednesday,
            this._classTimeThursday,
            this._classTimeFriday,
            this._classTimeSaturday,
            this._classroom,
            this._numberOfStudent,
            this._numberOfDropStudent,
            this._teacherAssistant,
            this._language,
            this._note,
            this._syllabus,
            this._audit,
            this._experiment});
            this._courseSelectionResultDataGridView.Location = new System.Drawing.Point(0, 0);
            this._courseSelectionResultDataGridView.Name = "_courseSelectionResultDataGridView";
            this._courseSelectionResultDataGridView.RowHeadersVisible = false;
            this._courseSelectionResultDataGridView.RowHeadersWidth = 51;
            this._courseSelectionResultDataGridView.RowTemplate.Height = 27;
            this._courseSelectionResultDataGridView.Size = new System.Drawing.Size(1406, 567);
            this._courseSelectionResultDataGridView.TabIndex = 0;
            this._courseSelectionResultDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewCellContent);
            // 
            // _number
            // 
            this._number.HeaderText = "課號";
            this._number.MinimumWidth = 6;
            this._number.Name = "_number";
            this._number.ReadOnly = true;
            this._number.Width = 66;
            // 
            // _name
            // 
            this._name.HeaderText = "課程名稱";
            this._name.MinimumWidth = 6;
            this._name.Name = "_name";
            this._name.ReadOnly = true;
            this._name.Width = 96;
            // 
            // _stage
            // 
            this._stage.HeaderText = "階段";
            this._stage.MinimumWidth = 6;
            this._stage.Name = "_stage";
            this._stage.ReadOnly = true;
            this._stage.Width = 66;
            // 
            // _credit
            // 
            this._credit.HeaderText = "學分";
            this._credit.MinimumWidth = 6;
            this._credit.Name = "_credit";
            this._credit.ReadOnly = true;
            this._credit.Width = 66;
            // 
            // _hour
            // 
            this._hour.HeaderText = "時數";
            this._hour.MinimumWidth = 6;
            this._hour.Name = "_hour";
            this._hour.ReadOnly = true;
            this._hour.Width = 66;
            // 
            // _requireType
            // 
            this._requireType.HeaderText = "修";
            this._requireType.MinimumWidth = 6;
            this._requireType.Name = "_requireType";
            this._requireType.ReadOnly = true;
            this._requireType.Width = 51;
            // 
            // _teacher
            // 
            this._teacher.HeaderText = "教師";
            this._teacher.MinimumWidth = 6;
            this._teacher.Name = "_teacher";
            this._teacher.ReadOnly = true;
            this._teacher.Width = 66;
            // 
            // _classTimeSunday
            // 
            this._classTimeSunday.HeaderText = "日";
            this._classTimeSunday.MinimumWidth = 6;
            this._classTimeSunday.Name = "_classTimeSunday";
            this._classTimeSunday.Width = 51;
            // 
            // _classTimeMonday
            // 
            this._classTimeMonday.HeaderText = "一";
            this._classTimeMonday.MinimumWidth = 6;
            this._classTimeMonday.Name = "_classTimeMonday";
            this._classTimeMonday.ReadOnly = true;
            this._classTimeMonday.Width = 51;
            // 
            // _classTimeTuesday
            // 
            this._classTimeTuesday.HeaderText = "二";
            this._classTimeTuesday.MinimumWidth = 6;
            this._classTimeTuesday.Name = "_classTimeTuesday";
            this._classTimeTuesday.ReadOnly = true;
            this._classTimeTuesday.Width = 51;
            // 
            // _classTimeWednesday
            // 
            this._classTimeWednesday.HeaderText = "三";
            this._classTimeWednesday.MinimumWidth = 6;
            this._classTimeWednesday.Name = "_classTimeWednesday";
            this._classTimeWednesday.ReadOnly = true;
            this._classTimeWednesday.Width = 51;
            // 
            // _classTimeThursday
            // 
            this._classTimeThursday.HeaderText = "四";
            this._classTimeThursday.MinimumWidth = 6;
            this._classTimeThursday.Name = "_classTimeThursday";
            this._classTimeThursday.ReadOnly = true;
            this._classTimeThursday.Width = 51;
            // 
            // _classTimeFriday
            // 
            this._classTimeFriday.HeaderText = "五";
            this._classTimeFriday.MinimumWidth = 6;
            this._classTimeFriday.Name = "_classTimeFriday";
            this._classTimeFriday.ReadOnly = true;
            this._classTimeFriday.Width = 51;
            // 
            // _classTimeSaturday
            // 
            this._classTimeSaturday.HeaderText = "六";
            this._classTimeSaturday.MinimumWidth = 6;
            this._classTimeSaturday.Name = "_classTimeSaturday";
            this._classTimeSaturday.ReadOnly = true;
            this._classTimeSaturday.Width = 51;
            // 
            // _classroom
            // 
            this._classroom.HeaderText = "教室";
            this._classroom.MinimumWidth = 6;
            this._classroom.Name = "_classroom";
            this._classroom.ReadOnly = true;
            this._classroom.Width = 66;
            // 
            // _numberOfStudent
            // 
            this._numberOfStudent.HeaderText = "人";
            this._numberOfStudent.MinimumWidth = 6;
            this._numberOfStudent.Name = "_numberOfStudent";
            this._numberOfStudent.ReadOnly = true;
            this._numberOfStudent.Width = 51;
            // 
            // _numberOfDropStudent
            // 
            this._numberOfDropStudent.HeaderText = "撤";
            this._numberOfDropStudent.MinimumWidth = 6;
            this._numberOfDropStudent.Name = "_numberOfDropStudent";
            this._numberOfDropStudent.ReadOnly = true;
            this._numberOfDropStudent.Width = 51;
            // 
            // _teacherAssistant
            // 
            this._teacherAssistant.HeaderText = "教學助理";
            this._teacherAssistant.MinimumWidth = 6;
            this._teacherAssistant.Name = "_teacherAssistant";
            this._teacherAssistant.ReadOnly = true;
            this._teacherAssistant.Width = 96;
            // 
            // _language
            // 
            this._language.HeaderText = "授課語言";
            this._language.MinimumWidth = 6;
            this._language.Name = "_language";
            this._language.ReadOnly = true;
            this._language.Width = 96;
            // 
            // _note
            // 
            this._note.HeaderText = "教學大綱與進度表";
            this._note.MinimumWidth = 6;
            this._note.Name = "_note";
            this._note.ReadOnly = true;
            this._note.Width = 102;
            // 
            // _syllabus
            // 
            this._syllabus.HeaderText = "備註";
            this._syllabus.MinimumWidth = 6;
            this._syllabus.Name = "_syllabus";
            this._syllabus.ReadOnly = true;
            this._syllabus.Width = 62;
            // 
            // audit
            // 
            this._audit.HeaderText = "隨班附讀";
            this._audit.MinimumWidth = 6;
            this._audit.Name = "audit";
            this._audit.ReadOnly = true;
            this._audit.Width = 75;
            // 
            // _experiment
            // 
            this._experiment.HeaderText = "實驗實習";
            this._experiment.MinimumWidth = 6;
            this._experiment.Name = "_experiment";
            this._experiment.ReadOnly = true;
            this._experiment.Width = 75;
            // 
            // CourseSelectionResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 569);
            this.Controls.Add(this._courseSelectionResultDataGridView);
            this.Name = "CourseSelectionResultForm";
            this.Text = "CourseSelectionResultForm";
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectionResultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseSelectionResultDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _number;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn _requireType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeSunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numberOfStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numberOfDropStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn _teacherAssistant;
        private System.Windows.Forms.DataGridViewTextBoxColumn _language;
        private System.Windows.Forms.DataGridViewTextBoxColumn _note;
        private System.Windows.Forms.DataGridViewTextBoxColumn _syllabus;
        private System.Windows.Forms.DataGridViewTextBoxColumn _audit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _experiment;
    }
}