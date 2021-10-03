
namespace CourseSystem
{
    partial class SelectCourseForm
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
            this._selectCourseDataGridView = new System.Windows.Forms.DataGridView();
            this._submitConfirmButton = new System.Windows.Forms.Button();
            this._viewOutcomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._selectCourseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _selectCourseDataGridView
            // 
            this._selectCourseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._selectCourseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._selectCourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._selectCourseDataGridView.Location = new System.Drawing.Point(1, 0);
            this._selectCourseDataGridView.Name = "_selectCourseDataGridView";
            this._selectCourseDataGridView.RowHeadersVisible = false;
            this._selectCourseDataGridView.RowHeadersWidth = 51;
            this._selectCourseDataGridView.RowTemplate.Height = 27;
            this._selectCourseDataGridView.Size = new System.Drawing.Size(1900, 505);
            this._selectCourseDataGridView.TabIndex = 2;
            this._selectCourseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectCourseDataGridViewCellContentClick);
            // 
            // _submitConfirmButton
            // 
            this._submitConfirmButton.AutoSize = true;
            this._submitConfirmButton.Location = new System.Drawing.Point(1431, 515);
            this._submitConfirmButton.Name = "_submitConfirmButton";
            this._submitConfirmButton.Size = new System.Drawing.Size(218, 70);
            this._submitConfirmButton.TabIndex = 3;
            this._submitConfirmButton.Text = "確認送出";
            this._submitConfirmButton.UseVisualStyleBackColor = true;
            // 
            // _viewOutcomeButton
            // 
            this._viewOutcomeButton.AutoSize = true;
            this._viewOutcomeButton.Location = new System.Drawing.Point(1666, 514);
            this._viewOutcomeButton.Name = "_viewOutcomeButton";
            this._viewOutcomeButton.Size = new System.Drawing.Size(211, 71);
            this._viewOutcomeButton.TabIndex = 4;
            this._viewOutcomeButton.Text = "查看選課結果";
            this._viewOutcomeButton.UseVisualStyleBackColor = true;
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 597);
            this.Controls.Add(this._viewOutcomeButton);
            this.Controls.Add(this._submitConfirmButton);
            this.Controls.Add(this._selectCourseDataGridView);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this._selectCourseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _selectCourseDataGridView;
        private System.Windows.Forms.Button _submitConfirmButton;
        private System.Windows.Forms.Button _viewOutcomeButton;
    }
}