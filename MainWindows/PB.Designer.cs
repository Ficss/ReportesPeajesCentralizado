namespace MainWindows
{
    partial class PB
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
            frm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbUpdate = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbUpdate
            // 
            this.pbUpdate.Location = new System.Drawing.Point(0, 0);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(250, 23);
            this.pbUpdate.Step = 1;
            this.pbUpdate.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbUpdate.TabIndex = 2;
            // 
            // PB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 23);
            this.Controls.Add(this.pbUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PB";
            this.Text = "PB";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar pbUpdate;
    }
}