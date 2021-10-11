
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
            this._comingSoonTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _comingSoonTextBox
            // 
            this._comingSoonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._comingSoonTextBox.Enabled = false;
            this._comingSoonTextBox.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comingSoonTextBox.Location = new System.Drawing.Point(0, 0);
            this._comingSoonTextBox.Name = "_comingSoonTextBox";
            this._comingSoonTextBox.ReadOnly = true;
            this._comingSoonTextBox.Size = new System.Drawing.Size(800, 78);
            this._comingSoonTextBox.TabIndex = 0;
            this._comingSoonTextBox.Text = "Coming soon";
            this._comingSoonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._comingSoonTextBox);
            this.Name = "CourseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseManagementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _comingSoonTextBox;
    }
}