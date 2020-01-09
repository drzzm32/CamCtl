namespace CamCtl
{
    partial class Histogram
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
            this.histoGramBox = new AForge.Controls.Histogram();
            this.SuspendLayout();
            // 
            // histoGramBox
            // 
            this.histoGramBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.histoGramBox.Location = new System.Drawing.Point(12, 12);
            this.histoGramBox.Name = "histoGramBox";
            this.histoGramBox.Size = new System.Drawing.Size(232, 232);
            this.histoGramBox.TabIndex = 0;
            this.histoGramBox.Values = null;
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.histoGramBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(256, 256);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "Histogram";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Histogram";
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.Histogram histoGramBox;
    }
}