
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
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectionResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseSelectionResultDataGridView
            // 
            this._courseSelectionResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseSelectionResultDataGridView.Location = new System.Drawing.Point(0, 0);
            this._courseSelectionResultDataGridView.Name = "_courseSelectionResultDataGridView";
            this._courseSelectionResultDataGridView.RowHeadersWidth = 51;
            this._courseSelectionResultDataGridView.RowTemplate.Height = 27;
            this._courseSelectionResultDataGridView.Size = new System.Drawing.Size(1406, 567);
            this._courseSelectionResultDataGridView.TabIndex = 0;
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
    }
}