namespace DuplexMemory
{
    partial class ScreenViewer
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
            this.ScreenBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenBox
            // 
            this.ScreenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenBox.Location = new System.Drawing.Point(0, 0);
            this.ScreenBox.Name = "ScreenBox";
            this.ScreenBox.Size = new System.Drawing.Size(550, 290);
            this.ScreenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenBox.TabIndex = 0;
            this.ScreenBox.TabStop = false;
            // 
            // ScreenViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 290);
            this.Controls.Add(this.ScreenBox);
            this.Name = "ScreenViewer";
            this.Text = "ScreenViewer";
            this.Load += new System.EventHandler(this.ScreenViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenBox;
    }
}