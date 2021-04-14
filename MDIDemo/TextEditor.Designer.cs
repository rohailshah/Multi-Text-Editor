
namespace MDIDemo
{
    partial class formTextEditor
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
            this.components = new System.ComponentModel.Container();
            this.textBoxEditor = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBoxEditor
            // 
            this.textBoxEditor.AcceptsTab = true;
            this.textBoxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEditor.Location = new System.Drawing.Point(0, 0);
            this.textBoxEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxEditor.Multiline = true;
            this.textBoxEditor.Name = "textBoxEditor";
            this.textBoxEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEditor.Size = new System.Drawing.Size(584, 361);
            this.textBoxEditor.TabIndex = 0;
            this.textBoxEditor.TextChanged += new System.EventHandler(this.TextModified);
            // 
            // formTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.textBoxEditor);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "formTextEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rohail\'s Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitingApp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEditor;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

