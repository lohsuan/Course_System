
namespace CourseSystem
{
    partial class StartUpForm
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
            this._courseSelectingSystemButton = new System.Windows.Forms.Button();
            this._courseManagementSystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _courseSelectingSystemButton
            // 
            this._courseSelectingSystemButton.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._courseSelectingSystemButton.Location = new System.Drawing.Point(12, 12);
            this._courseSelectingSystemButton.Name = "_courseSelectingSystemButton";
            this._courseSelectingSystemButton.Size = new System.Drawing.Size(776, 165);
            this._courseSelectingSystemButton.TabIndex = 0;
            this._courseSelectingSystemButton.Text = "Course Selecting System";
            this._courseSelectingSystemButton.UseVisualStyleBackColor = true;
            this._courseSelectingSystemButton.Click += new System.EventHandler(this.OpenCourseSelectingSystem);
            // 
            // _courseManagementSystemButton
            // 
            this._courseManagementSystemButton.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._courseManagementSystemButton.Location = new System.Drawing.Point(12, 185);
            this._courseManagementSystemButton.Name = "_courseManagementSystemButton";
            this._courseManagementSystemButton.Size = new System.Drawing.Size(776, 165);
            this._courseManagementSystemButton.TabIndex = 1;
            this._courseManagementSystemButton.Text = "Course Management System";
            this._courseManagementSystemButton.UseVisualStyleBackColor = true;
            this._courseManagementSystemButton.Click += new System.EventHandler(this.OpenCourseManagementSystem);
            // 
            // _exitButton
            // 
            this._exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._exitButton.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exitButton.Location = new System.Drawing.Point(595, 362);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(184, 75);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.Exit);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._courseManagementSystemButton);
            this.Controls.Add(this._courseSelectingSystemButton);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _courseSelectingSystemButton;
        private System.Windows.Forms.Button _courseManagementSystemButton;
        private System.Windows.Forms.Button _exitButton;
    }
}