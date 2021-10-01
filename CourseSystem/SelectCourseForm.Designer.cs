
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.selectCourseDataGridView = new System.Windows.Forms.DataGridView();
            this.submissionConfirmButton = new System.Windows.Forms.Button();
            this.viewOutcomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selectCourseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(557, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // selectCourseDataGridView
            // 
            this.selectCourseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.selectCourseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.selectCourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectCourseDataGridView.Location = new System.Drawing.Point(1, 0);
            this.selectCourseDataGridView.Name = "selectCourseDataGridView";
            this.selectCourseDataGridView.RowHeadersVisible = false;
            this.selectCourseDataGridView.RowHeadersWidth = 51;
            this.selectCourseDataGridView.RowTemplate.Height = 27;
            this.selectCourseDataGridView.Size = new System.Drawing.Size(1900, 505);
            this.selectCourseDataGridView.TabIndex = 2;
            this.selectCourseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectCourseDataGridViewCellContentClick);
            // 
            // submissionConfirmButton
            // 
            this.submissionConfirmButton.AutoSize = true;
            this.submissionConfirmButton.Location = new System.Drawing.Point(1431, 515);
            this.submissionConfirmButton.Name = "submissionConfirmButton";
            this.submissionConfirmButton.Size = new System.Drawing.Size(218, 70);
            this.submissionConfirmButton.TabIndex = 3;
            this.submissionConfirmButton.Text = "確認送出";
            this.submissionConfirmButton.UseVisualStyleBackColor = true;
            // 
            // viewOutcomeButton
            // 
            this.viewOutcomeButton.AutoSize = true;
            this.viewOutcomeButton.Location = new System.Drawing.Point(1666, 514);
            this.viewOutcomeButton.Name = "viewOutcomeButton";
            this.viewOutcomeButton.Size = new System.Drawing.Size(211, 71);
            this.viewOutcomeButton.TabIndex = 4;
            this.viewOutcomeButton.Text = "查看選課結果";
            this.viewOutcomeButton.UseVisualStyleBackColor = true;
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 597);
            this.Controls.Add(this.viewOutcomeButton);
            this.Controls.Add(this.submissionConfirmButton);
            this.Controls.Add(this.selectCourseDataGridView);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.selectCourseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView selectCourseDataGridView;
        private System.Windows.Forms.Button submissionConfirmButton;
        private System.Windows.Forms.Button viewOutcomeButton;
    }
}