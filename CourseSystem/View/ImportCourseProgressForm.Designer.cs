
namespace CourseSystem
{
    partial class ImportCourseProgressForm
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
            this._importClassLabel = new System.Windows.Forms.Label();
            this._importClassProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _importClassLabel
            // 
            this._importClassLabel.AutoSize = true;
            this._importClassLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._importClassLabel.Location = new System.Drawing.Point(23, 37);
            this._importClassLabel.Name = "_importClassLabel";
            this._importClassLabel.Size = new System.Drawing.Size(128, 15);
            this._importClassLabel.TabIndex = 0;
            this._importClassLabel.Text = "正在匯入課程...0%";
            // 
            // _importClassProgressBar
            // 
            this._importClassProgressBar.ForeColor = System.Drawing.Color.LightSkyBlue;
            this._importClassProgressBar.Location = new System.Drawing.Point(17, 64);
            this._importClassProgressBar.Name = "_importClassProgressBar";
            this._importClassProgressBar.Size = new System.Drawing.Size(374, 47);
            this._importClassProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._importClassProgressBar.TabIndex = 1;
            // 
            // ImportCourseProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 156);
            this.Controls.Add(this._importClassProgressBar);
            this.Controls.Add(this._importClassLabel);
            this.Name = "ImportCourseProgressForm";
            this.Text = "ImportCourseProgressForm";
            this.Shown += new System.EventHandler(this.LoadClasses);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _importClassLabel;
        private System.Windows.Forms.ProgressBar _importClassProgressBar;
    }
}