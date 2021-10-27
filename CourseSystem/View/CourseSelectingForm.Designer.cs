
namespace CourseSystem
{
    partial class CourseSelectingForm
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
            this._firstTabDataGridView = new System.Windows.Forms.DataGridView();
            this._submitConfirmButton = new System.Windows.Forms.Button();
            this._viewOutcomeButton = new System.Windows.Forms.Button();
            this._courseTabControl = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._secondTabDataGridView = new System.Windows.Forms.DataGridView();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this._firstTabDataGridView)).BeginInit();
            this._courseTabControl.SuspendLayout();
            this._tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._secondTabDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _firstTabDataGridView
            // 
            this._firstTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._firstTabDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._firstTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._firstTabDataGridView.Location = new System.Drawing.Point(0, 0);
            this._firstTabDataGridView.Name = "_firstTabDataGridView";
            this._firstTabDataGridView.RowHeadersVisible = false;
            this._firstTabDataGridView.RowHeadersWidth = 51;
            this._firstTabDataGridView.RowTemplate.Height = 27;
            this._firstTabDataGridView.Size = new System.Drawing.Size(1408, 489);
            this._firstTabDataGridView.TabIndex = 6;
            this._firstTabDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewCellContent);
            // 
            // _submitConfirmButton
            // 
            this._submitConfirmButton.AutoSize = true;
            this._submitConfirmButton.Location = new System.Drawing.Point(958, 537);
            this._submitConfirmButton.Name = "_submitConfirmButton";
            this._submitConfirmButton.Size = new System.Drawing.Size(218, 70);
            this._submitConfirmButton.TabIndex = 3;
            this._submitConfirmButton.Text = "確認送出";
            this._submitConfirmButton.UseVisualStyleBackColor = true;
            this._submitConfirmButton.Click += new System.EventHandler(this.ConfirmAndSubmitCourse);
            // 
            // _viewOutcomeButton
            // 
            this._viewOutcomeButton.AutoSize = true;
            this._viewOutcomeButton.Location = new System.Drawing.Point(1193, 536);
            this._viewOutcomeButton.Name = "_viewOutcomeButton";
            this._viewOutcomeButton.Size = new System.Drawing.Size(211, 71);
            this._viewOutcomeButton.TabIndex = 4;
            this._viewOutcomeButton.Text = "查看選課結果";
            this._viewOutcomeButton.UseVisualStyleBackColor = true;
            this._viewOutcomeButton.Click += new System.EventHandler(this.OpenCourseSelectionResultForm);
            // 
            // _courseTabControl
            // 
            this._courseTabControl.Controls.Add(this._tabPage1);
            this._courseTabControl.Controls.Add(this._tabPage2);
            this._courseTabControl.Location = new System.Drawing.Point(0, 6);
            this._courseTabControl.Name = "_courseTabControl";
            this._courseTabControl.SelectedIndex = 0;
            this._courseTabControl.Size = new System.Drawing.Size(1414, 524);
            this._courseTabControl.TabIndex = 5;
            this._courseTabControl.SelectedIndexChanged += new System.EventHandler(this.ChangeTabIndex);
            // 
            // _tabPage1
            // 
            this._tabPage1.Controls.Add(this._firstTabDataGridView);
            this._tabPage1.Controls.Add(this._secondTabDataGridView);
            this._tabPage1.Location = new System.Drawing.Point(4, 25);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(1406, 495);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "tabPage1";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // _secondTabDataGridView
            // 
            this._secondTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._secondTabDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._secondTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._secondTabDataGridView.Location = new System.Drawing.Point(6, 0);
            this._secondTabDataGridView.Name = "_secondTabDataGridView";
            this._secondTabDataGridView.RowHeadersVisible = false;
            this._secondTabDataGridView.RowHeadersWidth = 51;
            this._secondTabDataGridView.RowTemplate.Height = 27;
            this._secondTabDataGridView.Size = new System.Drawing.Size(1459, 489);
            this._secondTabDataGridView.TabIndex = 2;
            // 
            // _tabPage2
            // 
            this._tabPage2.Location = new System.Drawing.Point(4, 25);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(1471, 495);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "tabPage2";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 617);
            this.Controls.Add(this._courseTabControl);
            this.Controls.Add(this._viewOutcomeButton);
            this.Controls.Add(this._submitConfirmButton);
            this.Name = "CourseSelectingForm";
            this.Text = "SelectCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this._firstTabDataGridView)).EndInit();
            this._courseTabControl.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._secondTabDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _firstTabDataGridView;
        private System.Windows.Forms.Button _submitConfirmButton;
        private System.Windows.Forms.Button _viewOutcomeButton;
        private System.Windows.Forms.TabControl _courseTabControl;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.DataGridView _secondTabDataGridView;
    }
}