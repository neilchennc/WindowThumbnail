
namespace WindowThumbnail
{
    partial class MainForm
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
            this.WindowListControl = new System.Windows.Forms.ComboBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ThumbnailControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailControl)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowListControl
            // 
            this.WindowListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowListControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowListControl.FormattingEnabled = true;
            this.WindowListControl.Location = new System.Drawing.Point(1, 1);
            this.WindowListControl.Name = "WindowListControl";
            this.WindowListControl.Size = new System.Drawing.Size(243, 23);
            this.WindowListControl.TabIndex = 0;
            this.WindowListControl.SelectedIndexChanged += new System.EventHandler(this.WindowListControl_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(245, 1);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ThumbnailControl
            // 
            this.ThumbnailControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThumbnailControl.Location = new System.Drawing.Point(0, 25);
            this.ThumbnailControl.Name = "ThumbnailControl";
            this.ThumbnailControl.Size = new System.Drawing.Size(320, 180);
            this.ThumbnailControl.TabIndex = 2;
            this.ThumbnailControl.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 205);
            this.Controls.Add(this.ThumbnailControl);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.WindowListControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window Thumbnail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox WindowListControl;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.PictureBox ThumbnailControl;
    }
}

