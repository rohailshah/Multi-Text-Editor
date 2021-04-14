
namespace MDIDemo
{
    partial class formWhiteboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureCanvas = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCanvas
            // 
            this.pictureCanvas.BackColor = System.Drawing.Color.White;
            this.pictureCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureCanvas.Location = new System.Drawing.Point(0, 0);
            this.pictureCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureCanvas.Name = "pictureCanvas";
            this.pictureCanvas.Size = new System.Drawing.Size(384, 261);
            this.pictureCanvas.TabIndex = 0;
            this.pictureCanvas.TabStop = false;
            this.pictureCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Repaint);
            this.pictureCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseButtonDown);
            this.pictureCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.pictureCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseButtonUp);
            // 
            // formWhiteboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.pictureCanvas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formWhiteboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rohail\'s Whiteboard";
            this.Load += new System.EventHandler(this.FileNew);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCanvas;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

