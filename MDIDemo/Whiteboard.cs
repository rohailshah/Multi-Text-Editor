// Project:     Whiteboard (2021 C# version)
// Author:      Rohail Shah
// Start Date:  March 22, 2021
// Last Date:   March 25, 2021
// Description:
//  This application will allow very basic whiteboard
//  functionality including drawing, copying, pasting,
//  and some basic file management.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIDemo
{
    public partial class formWhiteboard : Form
    {
        // This variable indicates whether the mouse button is down.
        bool isPressed = false;
        // This is the filepath of the active file, if applicable.
        string filePath = String.Empty;
        // Current position of the mouse cursor.
        static int xValue = 0;
        static int yValue = 0;

        // Values related to the state of the brush.
        static int brushSize = 5;
        static Color brushColor = Color.Black;

        // This indicates the current region that is being drawn.
        Rectangle drawRegion = new Rectangle(xValue, yValue, brushSize, brushSize);

        // This is a container for the image itself.
        Bitmap bitmapInstance;
        // Used for access to the graphic class
        Graphics canvasGraphics;

        public formWhiteboard()
        {
            InitializeComponent();
            canvasGraphics = pictureCanvas.CreateGraphics();
        }

        #region "Functions"

        /// <summary>
        /// Save the current contents of the pictureBox (canvas) to a bitmap image file.
        /// </summary>
        /// <param name="path">A file path as a string</param>
        public void SaveImageFile(string path)
        {
            pictureCanvas.Image.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Update the form's title text to include an open file path if one exists.
        /// </summary>
        public void UpdateTitle()
        {
            this.Text = "Kyle's Whiteboard";

            if (filePath != String.Empty)
            {
                this.Text += " - " + filePath;
            }
        }

        #endregion
        #region "Event Handlers"

        /// <summary>
        /// Mouse button is released! Stop drawing.
        /// </summary>
        private void MouseButtonUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        /// <summary>
        /// Mouse button is down! Draw.
        /// </summary>
        private void MouseButtonDown(object sender, MouseEventArgs e)
        {
            isPressed = true;

            xValue = e.X;
            yValue = e.Y;

            drawRegion = new Rectangle(xValue, yValue, brushSize, brushSize);
            pictureCanvas.Invalidate(drawRegion);
        }

        // The mouse is moved. If the button is down, draw.
        private void MouseMoved(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                xValue = e.X;
                yValue = e.Y;

                drawRegion = new Rectangle(xValue, yValue, brushSize, brushSize);
                pictureCanvas.Invalidate(drawRegion);
            }
        }

        /// <summary>
        /// If an area of the canvas is invalidated, re-paint it with the current brush.
        /// </summary>
        private void Repaint(object sender, PaintEventArgs e)
        {
            if (isPressed)
            {
                Brush myBrush = new SolidBrush(brushColor);
                canvasGraphics.FillEllipse(myBrush, drawRegion);
            }
        }

        /// <summary>
        /// Copy the entire canvas to the clipboard.
        /// </summary>
        public void EditCopy(object sender, EventArgs e)
        {
            if (pictureCanvas.Image != null)
            {
                Clipboard.SetImage(pictureCanvas.Image);
            }
        }

        /// <summary>
        /// If the clipboard contains image or text data, paste it onto the canvas. If it's text do this at the current cursor location.
        /// </summary>
        public void EditPaste(object sender, EventArgs e)
        {
            // If the clipboard contains image data, paste it.
            if (Clipboard.ContainsImage())
            {
                pictureCanvas.Image = Clipboard.GetImage();
            }
            // If the clipboard contains text...
            else if (Clipboard.ContainsText())
            {
                // Draw the text onto the canvas at the current x and y value.
                canvasGraphics.DrawString(Clipboard.GetText(), DefaultFont, Brushes.Black, xValue, yValue);
                pictureCanvas.Invalidate(pictureCanvas.Region);
            }
        }

        /// <summary>
        /// Me close form.
        /// </summary>
        public void FileExit(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Blank the canvas to make a new image. This also initializes the canvas.
        /// </summary>
        public void FileNew(object sender, EventArgs e)
        {
            pictureCanvas.BackColor = Color.White;
            bitmapInstance = new Bitmap(pictureCanvas.Width, pictureCanvas.Height);

            pictureCanvas.Image = bitmapInstance;

            canvasGraphics = Graphics.FromImage(bitmapInstance);

            pictureCanvas.DrawToBitmap(bitmapInstance, pictureCanvas.ClientRectangle);

            filePath = String.Empty;
            UpdateTitle();
        }

        /// <summary>
        /// Calls a save dialog to save the image file to a specified location.
        /// </summary>
        public void FileSaveAs(object sender, EventArgs e)
        {
            // Create a new save dialog.
            SaveFileDialog saveFile = new SaveFileDialog();

            // Set the filter for the save dialog.
            saveFile.Filter = "Bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";

            // If the user selects a file and clicks OK
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Then set the new filepath and update the form title
                filePath = saveFile.FileName;
                UpdateTitle();

                // Save the actual image file!
                SaveImageFile(filePath);
            }
        }

        /// <summary>
        /// Saves the file if the path is known, or calls "Save As" if it isn't known.
        /// </summary>
        public void FileSave(object sender, EventArgs e)
        {
            // If there is not already a filepath...
            if (filePath == String.Empty)
            {
                // Then call the Save As... event handler!
                FileSaveAs(sender, e);
            }
            // If there IS a filepath...
            else
            {
                // Then save it.
                SaveImageFile(filePath);
            }
        }

        /// <summary>
        /// Displays a little message about this application.
        /// </summary>
        public void HelpAbout(object sender, EventArgs e)
        {
            MessageBox.Show("Whiteboard\n" + "By Rohail Shah\n\n" + "For NETD 2202\n" + "March 2021", "About This Application");
        }

        #endregion
    }
}
