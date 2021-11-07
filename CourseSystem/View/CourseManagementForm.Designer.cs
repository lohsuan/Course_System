
namespace CourseSystem
{
    partial class CourseManagementForm
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._courseManageTabPage = new System.Windows.Forms.TabPage();
            this._saveButton = new System.Windows.Forms.Button();
            this._addCourseButton = new System.Windows.Forms.Button();
            this._editCourseGroupBox = new System.Windows.Forms.GroupBox();
            this._class = new System.Windows.Forms.Label();
            this._hour = new System.Windows.Forms.Label();
            this._syllabusTextBox = new System.Windows.Forms.TextBox();
            this._syllabus = new System.Windows.Forms.Label();
            this._languageTextBox = new System.Windows.Forms.TextBox();
            this._language = new System.Windows.Forms.Label();
            this._teacherAssistantTextBox = new System.Windows.Forms.TextBox();
            this._teacherAssistant = new System.Windows.Forms.Label();
            this._requireType = new System.Windows.Forms.Label();
            this._teacherTextBox = new System.Windows.Forms.TextBox();
            this._teacher = new System.Windows.Forms.Label();
            this._creditTextBox = new System.Windows.Forms.TextBox();
            this._credit = new System.Windows.Forms.Label();
            this._stageTextBox = new System.Windows.Forms.TextBox();
            this._stage = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._name = new System.Windows.Forms.Label();
            this._numberTextBox = new System.Windows.Forms.TextBox();
            this._number = new System.Windows.Forms.Label();
            this._classComboBox = new System.Windows.Forms.ComboBox();
            this._hourComboBox = new System.Windows.Forms.ComboBox();
            this._requireTypeComboBox = new System.Windows.Forms.ComboBox();
            this._courseStatusComboBox = new System.Windows.Forms.ComboBox();
            this._classTimeDataGridView = new System.Windows.Forms.DataGridView();
            this._hourOfClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseListBox = new System.Windows.Forms.ListBox();
            this._classManageTabPage = new System.Windows.Forms.TabPage();
            this._importClassButton = new System.Windows.Forms.Button();
            this._tabControl.SuspendLayout();
            this._courseManageTabPage.SuspendLayout();
            this._editCourseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._classTimeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._courseManageTabPage);
            this._tabControl.Controls.Add(this._classManageTabPage);
            this._tabControl.Location = new System.Drawing.Point(7, 7);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1277, 673);
            this._tabControl.TabIndex = 0;
            // 
            // _courseManageTabPage
            // 
            this._courseManageTabPage.Controls.Add(this._importClassButton);
            this._courseManageTabPage.Controls.Add(this._saveButton);
            this._courseManageTabPage.Controls.Add(this._addCourseButton);
            this._courseManageTabPage.Controls.Add(this._editCourseGroupBox);
            this._courseManageTabPage.Controls.Add(this._courseListBox);
            this._courseManageTabPage.Location = new System.Drawing.Point(4, 25);
            this._courseManageTabPage.Name = "_courseManageTabPage";
            this._courseManageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._courseManageTabPage.Size = new System.Drawing.Size(1269, 644);
            this._courseManageTabPage.TabIndex = 0;
            this._courseManageTabPage.Text = "課程管理";
            this._courseManageTabPage.UseVisualStyleBackColor = true;
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(1020, 580);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(153, 53);
            this._saveButton.TabIndex = 3;
            this._saveButton.Text = "儲存";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _addCourseButton
            // 
            this._addCourseButton.Location = new System.Drawing.Point(14, 580);
            this._addCourseButton.Name = "_addCourseButton";
            this._addCourseButton.Size = new System.Drawing.Size(123, 53);
            this._addCourseButton.TabIndex = 2;
            this._addCourseButton.Text = "新增課程";
            this._addCourseButton.UseVisualStyleBackColor = true;
            this._addCourseButton.Click += new System.EventHandler(this.ClickAddCourseButton);
            // 
            // _editCourseGroupBox
            // 
            this._editCourseGroupBox.Controls.Add(this._class);
            this._editCourseGroupBox.Controls.Add(this._hour);
            this._editCourseGroupBox.Controls.Add(this._syllabusTextBox);
            this._editCourseGroupBox.Controls.Add(this._syllabus);
            this._editCourseGroupBox.Controls.Add(this._languageTextBox);
            this._editCourseGroupBox.Controls.Add(this._language);
            this._editCourseGroupBox.Controls.Add(this._teacherAssistantTextBox);
            this._editCourseGroupBox.Controls.Add(this._teacherAssistant);
            this._editCourseGroupBox.Controls.Add(this._requireType);
            this._editCourseGroupBox.Controls.Add(this._teacherTextBox);
            this._editCourseGroupBox.Controls.Add(this._teacher);
            this._editCourseGroupBox.Controls.Add(this._creditTextBox);
            this._editCourseGroupBox.Controls.Add(this._credit);
            this._editCourseGroupBox.Controls.Add(this._stageTextBox);
            this._editCourseGroupBox.Controls.Add(this._stage);
            this._editCourseGroupBox.Controls.Add(this._nameTextBox);
            this._editCourseGroupBox.Controls.Add(this._name);
            this._editCourseGroupBox.Controls.Add(this._numberTextBox);
            this._editCourseGroupBox.Controls.Add(this._number);
            this._editCourseGroupBox.Controls.Add(this._classComboBox);
            this._editCourseGroupBox.Controls.Add(this._hourComboBox);
            this._editCourseGroupBox.Controls.Add(this._requireTypeComboBox);
            this._editCourseGroupBox.Controls.Add(this._courseStatusComboBox);
            this._editCourseGroupBox.Controls.Add(this._classTimeDataGridView);
            this._editCourseGroupBox.Location = new System.Drawing.Point(286, 15);
            this._editCourseGroupBox.Name = "_editCourseGroupBox";
            this._editCourseGroupBox.Size = new System.Drawing.Size(920, 559);
            this._editCourseGroupBox.TabIndex = 1;
            this._editCourseGroupBox.TabStop = false;
            this._editCourseGroupBox.Text = "編輯課程";
            // 
            // _class
            // 
            this._class.AutoSize = true;
            this._class.Location = new System.Drawing.Point(252, 211);
            this._class.Name = "_class";
            this._class.Size = new System.Drawing.Size(54, 15);
            this._class.TabIndex = 23;
            this._class.Text = "班級(*)";
            // 
            // _hour
            // 
            this._hour.AutoSize = true;
            this._hour.Location = new System.Drawing.Point(39, 211);
            this._hour.Name = "_hour";
            this._hour.Size = new System.Drawing.Size(54, 15);
            this._hour.TabIndex = 22;
            this._hour.Text = "時數(*)";
            // 
            // _syllabusTextBox
            // 
            this._syllabusTextBox.Location = new System.Drawing.Point(101, 165);
            this._syllabusTextBox.Name = "_syllabusTextBox";
            this._syllabusTextBox.Size = new System.Drawing.Size(795, 25);
            this._syllabusTextBox.TabIndex = 21;
            this._syllabusTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            // 
            // _syllabus
            // 
            this._syllabus.AutoSize = true;
            this._syllabus.Location = new System.Drawing.Point(51, 172);
            this._syllabus.Name = "_syllabus";
            this._syllabus.Size = new System.Drawing.Size(37, 15);
            this._syllabus.TabIndex = 20;
            this._syllabus.Text = "備註";
            // 
            // _languageTextBox
            // 
            this._languageTextBox.Location = new System.Drawing.Point(546, 118);
            this._languageTextBox.Name = "_languageTextBox";
            this._languageTextBox.Size = new System.Drawing.Size(350, 25);
            this._languageTextBox.TabIndex = 19;
            this._languageTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            // 
            // _language
            // 
            this._language.AutoSize = true;
            this._language.Location = new System.Drawing.Point(473, 124);
            this._language.Name = "_language";
            this._language.Size = new System.Drawing.Size(67, 15);
            this._language.TabIndex = 18;
            this._language.Text = "授課語言";
            // 
            // _teacherAssistantTextBox
            // 
            this._teacherAssistantTextBox.Location = new System.Drawing.Point(101, 119);
            this._teacherAssistantTextBox.Name = "_teacherAssistantTextBox";
            this._teacherAssistantTextBox.Size = new System.Drawing.Size(337, 25);
            this._teacherAssistantTextBox.TabIndex = 17;
            this._teacherAssistantTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            // 
            // _teacherAssistant
            // 
            this._teacherAssistant.AutoSize = true;
            this._teacherAssistant.Location = new System.Drawing.Point(27, 125);
            this._teacherAssistant.Name = "_teacherAssistant";
            this._teacherAssistant.Size = new System.Drawing.Size(67, 15);
            this._teacherAssistant.TabIndex = 16;
            this._teacherAssistant.Text = "教學助理";
            // 
            // _requireType
            // 
            this._requireType.AutoSize = true;
            this._requireType.Location = new System.Drawing.Point(777, 30);
            this._requireType.Name = "_requireType";
            this._requireType.Size = new System.Drawing.Size(39, 15);
            this._requireType.TabIndex = 15;
            this._requireType.Text = "修(*)";
            // 
            // _teacherTextBox
            // 
            this._teacherTextBox.Location = new System.Drawing.Point(546, 71);
            this._teacherTextBox.Name = "_teacherTextBox";
            this._teacherTextBox.Size = new System.Drawing.Size(350, 25);
            this._teacherTextBox.TabIndex = 14;
            this._teacherTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            // 
            // _teacher
            // 
            this._teacher.AutoSize = true;
            this._teacher.Location = new System.Drawing.Point(486, 77);
            this._teacher.Name = "_teacher";
            this._teacher.Size = new System.Drawing.Size(54, 15);
            this._teacher.TabIndex = 13;
            this._teacher.Text = "教師(*)";
            // 
            // _creditTextBox
            // 
            this._creditTextBox.Location = new System.Drawing.Point(321, 73);
            this._creditTextBox.Name = "_creditTextBox";
            this._creditTextBox.Size = new System.Drawing.Size(118, 25);
            this._creditTextBox.TabIndex = 12;
            this._creditTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            this._creditTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberInput);
            // 
            // _credit
            // 
            this._credit.AutoSize = true;
            this._credit.Location = new System.Drawing.Point(253, 79);
            this._credit.Name = "_credit";
            this._credit.Size = new System.Drawing.Size(54, 15);
            this._credit.TabIndex = 11;
            this._credit.Text = "學分(*)";
            // 
            // _stageTextBox
            // 
            this._stageTextBox.Location = new System.Drawing.Point(101, 73);
            this._stageTextBox.Name = "_stageTextBox";
            this._stageTextBox.Size = new System.Drawing.Size(118, 25);
            this._stageTextBox.TabIndex = 10;
            this._stageTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            this._stageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberInput);
            // 
            // _stage
            // 
            this._stage.AutoSize = true;
            this._stage.Location = new System.Drawing.Point(41, 78);
            this._stage.Name = "_stage";
            this._stage.Size = new System.Drawing.Size(54, 15);
            this._stage.TabIndex = 9;
            this._stage.Text = "階段(*)";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(546, 25);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(220, 25);
            this._nameTextBox.TabIndex = 8;
            this._nameTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            // 
            // _name
            // 
            this._name.AutoSize = true;
            this._name.Location = new System.Drawing.Point(456, 32);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(84, 15);
            this._name.TabIndex = 7;
            this._name.Text = "課程名稱(*)";
            // 
            // _numberTextBox
            // 
            this._numberTextBox.Location = new System.Drawing.Point(320, 28);
            this._numberTextBox.Name = "_numberTextBox";
            this._numberTextBox.Size = new System.Drawing.Size(118, 25);
            this._numberTextBox.TabIndex = 6;
            this._numberTextBox.TextChanged += new System.EventHandler(this.EditedTextBox);
            this._numberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberInput);
            // 
            // _number
            // 
            this._number.AutoSize = true;
            this._number.Location = new System.Drawing.Point(253, 32);
            this._number.Name = "_number";
            this._number.Size = new System.Drawing.Size(54, 15);
            this._number.TabIndex = 5;
            this._number.Text = "課號(*)";
            // 
            // _classComboBox
            // 
            this._classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classComboBox.FormattingEnabled = true;
            this._classComboBox.Location = new System.Drawing.Point(325, 208);
            this._classComboBox.Name = "_classComboBox";
            this._classComboBox.Size = new System.Drawing.Size(121, 23);
            this._classComboBox.TabIndex = 4;
            this._classComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedComboBoxSelectedIndex);
            // 
            // _hourComboBox
            // 
            this._hourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._hourComboBox.FormattingEnabled = true;
            this._hourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._hourComboBox.Location = new System.Drawing.Point(101, 208);
            this._hourComboBox.Name = "_hourComboBox";
            this._hourComboBox.Size = new System.Drawing.Size(121, 23);
            this._hourComboBox.TabIndex = 3;
            this._hourComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedComboBoxSelectedIndex);
            // 
            // _requireTypeComboBox
            // 
            this._requireTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._requireTypeComboBox.FormattingEnabled = true;
            this._requireTypeComboBox.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._requireTypeComboBox.Location = new System.Drawing.Point(823, 26);
            this._requireTypeComboBox.Name = "_requireTypeComboBox";
            this._requireTypeComboBox.Size = new System.Drawing.Size(73, 23);
            this._requireTypeComboBox.TabIndex = 2;
            this._requireTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedComboBoxSelectedIndex);
            // 
            // _courseStatusComboBox
            // 
            this._courseStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseStatusComboBox.FormattingEnabled = true;
            this._courseStatusComboBox.Items.AddRange(new object[] {
            "開課",
            "停開"});
            this._courseStatusComboBox.Location = new System.Drawing.Point(99, 30);
            this._courseStatusComboBox.Name = "_courseStatusComboBox";
            this._courseStatusComboBox.Size = new System.Drawing.Size(121, 23);
            this._courseStatusComboBox.TabIndex = 1;
            this._courseStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedComboBoxSelectedIndex);
            // 
            // _classTimeDataGridView
            // 
            this._classTimeDataGridView.AllowUserToAddRows = false;
            this._classTimeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._classTimeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._classTimeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._hourOfClass,
            this._sunday,
            this._monday,
            this._tuesday,
            this._wednesday,
            this._thursday,
            this._friday,
            this._saturday});
            this._classTimeDataGridView.Location = new System.Drawing.Point(25, 251);
            this._classTimeDataGridView.Name = "_classTimeDataGridView";
            this._classTimeDataGridView.RowHeadersVisible = false;
            this._classTimeDataGridView.RowHeadersWidth = 51;
            this._classTimeDataGridView.RowTemplate.Height = 27;
            this._classTimeDataGridView.Size = new System.Drawing.Size(869, 300);
            this._classTimeDataGridView.TabIndex = 0;
            this._classTimeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckClassTimeDataGridView);
            // 
            // _hourOfClass
            // 
            this._hourOfClass.HeaderText = "節數";
            this._hourOfClass.MinimumWidth = 6;
            this._hourOfClass.Name = "_hourOfClass";
            this._hourOfClass.ReadOnly = true;
            // 
            // _sunday
            // 
            this._sunday.HeaderText = "日";
            this._sunday.MinimumWidth = 6;
            this._sunday.Name = "_sunday";
            // 
            // _monday
            // 
            this._monday.HeaderText = "一";
            this._monday.MinimumWidth = 6;
            this._monday.Name = "_monday";
            // 
            // _tuesday
            // 
            this._tuesday.HeaderText = "二";
            this._tuesday.MinimumWidth = 6;
            this._tuesday.Name = "_tuesday";
            // 
            // _wednesday
            // 
            this._wednesday.HeaderText = "三";
            this._wednesday.MinimumWidth = 6;
            this._wednesday.Name = "_wednesday";
            // 
            // _thursday
            // 
            this._thursday.HeaderText = "四";
            this._thursday.MinimumWidth = 6;
            this._thursday.Name = "_thursday";
            // 
            // _friday
            // 
            this._friday.HeaderText = "五";
            this._friday.MinimumWidth = 6;
            this._friday.Name = "_friday";
            // 
            // _saturday
            // 
            this._saturday.HeaderText = "六";
            this._saturday.MinimumWidth = 6;
            this._saturday.Name = "_saturday";
            // 
            // _courseListBox
            // 
            this._courseListBox.FormattingEnabled = true;
            this._courseListBox.ItemHeight = 15;
            this._courseListBox.Location = new System.Drawing.Point(11, 15);
            this._courseListBox.Name = "_courseListBox";
            this._courseListBox.Size = new System.Drawing.Size(265, 559);
            this._courseListBox.TabIndex = 0;
            this._courseListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeCourseListBoxIndex);
            // 
            // _classManageTabPage
            // 
            this._classManageTabPage.Location = new System.Drawing.Point(4, 25);
            this._classManageTabPage.Name = "_classManageTabPage";
            this._classManageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._classManageTabPage.Size = new System.Drawing.Size(1269, 644);
            this._classManageTabPage.TabIndex = 1;
            this._classManageTabPage.Text = "班級管理";
            this._classManageTabPage.UseVisualStyleBackColor = true;
            // 
            // _importClassButton
            // 
            this._importClassButton.Location = new System.Drawing.Point(143, 580);
            this._importClassButton.Name = "_importClassButton";
            this._importClassButton.Size = new System.Drawing.Size(129, 52);
            this._importClassButton.TabIndex = 4;
            this._importClassButton.Text = "匯入資工系全部課程";
            this._importClassButton.UseVisualStyleBackColor = true;
            this._importClassButton.Click += new System.EventHandler(this.OpenImportCourseProgressForm);
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 684);
            this.Controls.Add(this._tabControl);
            this.Name = "CourseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseManagementForm";
            this._tabControl.ResumeLayout(false);
            this._courseManageTabPage.ResumeLayout(false);
            this._editCourseGroupBox.ResumeLayout(false);
            this._editCourseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._classTimeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _courseManageTabPage;
        private System.Windows.Forms.GroupBox _editCourseGroupBox;
        private System.Windows.Forms.ListBox _courseListBox;
        private System.Windows.Forms.TabPage _classManageTabPage;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _addCourseButton;
        private System.Windows.Forms.ComboBox _requireTypeComboBox;
        private System.Windows.Forms.ComboBox _courseStatusComboBox;
        private System.Windows.Forms.DataGridView _classTimeDataGridView;
        private System.Windows.Forms.ComboBox _classComboBox;
        private System.Windows.Forms.ComboBox _hourComboBox;
        private System.Windows.Forms.Label _number;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.TextBox _numberTextBox;
        private System.Windows.Forms.Label _class;
        private System.Windows.Forms.Label _hour;
        private System.Windows.Forms.TextBox _syllabusTextBox;
        private System.Windows.Forms.Label _syllabus;
        private System.Windows.Forms.TextBox _languageTextBox;
        private System.Windows.Forms.Label _language;
        private System.Windows.Forms.TextBox _teacherAssistantTextBox;
        private System.Windows.Forms.Label _teacherAssistant;
        private System.Windows.Forms.Label _requireType;
        private System.Windows.Forms.TextBox _teacherTextBox;
        private System.Windows.Forms.Label _teacher;
        private System.Windows.Forms.TextBox _creditTextBox;
        private System.Windows.Forms.Label _credit;
        private System.Windows.Forms.TextBox _stageTextBox;
        private System.Windows.Forms.Label _stage;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _hourOfClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn _sunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _saturday;
        private System.Windows.Forms.Button _importClassButton;
    }
}