/* Author: Rohail Shah
 * Last Modified: April 13, 2021
 * Description:
 * An MDI application that will be to be able to open, close, edit, save, save as, and create new files (.txt). 
 * The application will also have the ability to copy, cut, and paste text.
 */

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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a new Text Editor window instance as a child window.
        /// </summary>
        private void FileNew(object sender, EventArgs e)
        {
            formTextEditor texteditorInstance = new formTextEditor();
            texteditorInstance.MdiParent = this;
            texteditorInstance.Show();
        }

        /// <summary>
        /// Opens a new Text Editor window instance as a child window and opens an existing text file with it.
        /// </summary>
        private void FileOpen(object sender, EventArgs e)
        {
            // If there's at least one MdiChild.
            if (this.MdiChildren.Length > 0)
            {
                // If current window is a text editor window.
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // Cast the active window to a texteditor window.
                    formTextEditor texteditorInstance = (formTextEditor)this.ActiveMdiChild;
                    // Call the active window's open operation.
                    texteditorInstance.FileOpen(sender, e);
                }
                // The current window is not a textedtor window. Report that.
                else
                {
                    MessageBox.Show("Open is not supported for the current active window.", "Open Not Suported");
                }
            }
            // There is no child window. Report that.
            else
            {
                formTextEditor texteditorInstance = new formTextEditor();
                texteditorInstance.MdiParent = this;
                texteditorInstance.Show();
                // Cast the active window to a whiteboard window.
                formTextEditor texteditorInstance2 = (formTextEditor)this.ActiveMdiChild;
                // Call the active window's copy operation.
                texteditorInstance2.FileOpen(sender, e);
            }
        }

        /// <summary>
        /// Saves the file if the path is known, or calls "Save As" if it is not known.
        /// </summary>
        private void FileSave(object sender, EventArgs e)
        {
            // If there's at least one MdiChild.
            if (this.MdiChildren.Length > 0)
            {
                // If current window is a text editor window.
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // Cast the active window to a texteditor window.
                    formTextEditor texteditorInstance = (formTextEditor)this.ActiveMdiChild;
                    // Call the active window's save operation.
                    texteditorInstance.FileSave(sender, e);
                }
                // The current window is not a textedtor window. Report that.
                else
                {
                    MessageBox.Show("Save is not supported for the current active window.", "Save Not Suported");
                }
            }
            else
            {
                MessageBox.Show("You must select a window that allows save to file.", "Save Not Supported");
            }
        }

        /// <summary>
        /// Open a save dialog and save the file to the location chosen by the user.
        /// </summary>
        private void FileSaveAs(object sender, EventArgs e)
        {
            // Check if windows are actually open.
            if (this.MdiChildren.Length > 0)
            {
                // If the selected window is a whiteboard window.
                if (this.ActiveMdiChild.GetType() == typeof(formWhiteboard))
                {
                    // Call the whiteboard window's Save As function.
                    formWhiteboard whiteboardInstance = (formWhiteboard)this.ActiveMdiChild;
                    whiteboardInstance.FileSaveAs(sender, e);
                }
                // If the selected window is a text edtior window.
                else if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // Cast the active window to a texteditor window.
                    formTextEditor texteditorInstance = (formTextEditor)this.ActiveMdiChild;
                    // Call the active window's save operation.
                    texteditorInstance.FileSaveAs(sender, e);
                }
                // Otherwise, this is some other window that doesn't allow saving. Report error.
                else
                {
                    MessageBox.Show("This window type does not support saving.", "Save As Not Supported");
                }
            }
            // No child windows are open. Report an error.
            else
            {
                MessageBox.Show("You need to have an open window to save.", "Save As Not Supported");
            }

        }

        /// <summary>
        /// Close the current active window.
        /// </summary>
        private void FileClose(object sender, EventArgs e)
        {
            // If there are active MdiChild windows.
            if (this.MdiChildren.Length > 0)
            {
                // Confirm close then close it.
                if (MessageBox.Show("Are you sure you want to close the current window?", "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.ActiveMdiChild.Close();
                }
            }
            // If there are NO active MdiChildren.
            else
            {
                // Confirm if the user wants to close the whole application, then clsoe it.
                if (MessageBox.Show("Do you want to exit the application?", "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void FileExit(object sender, EventArgs e)
        {
            // Confirm if the user wants to close the whole application, then clsoe it.
            if (MessageBox.Show("Do you want to exit the application?", "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Detect the window type,; if it supports copy, call that window's copy operation.
        /// </summary>
        private void EditCopy(object sender, EventArgs e)
        {
            // If there's at least one MdiChild.
            if (this.MdiChildren.Length > 0)
            {
                // If current window is a whiteboard window.
                if (this.ActiveMdiChild.GetType() == typeof(formWhiteboard))
                {
                    // Cast the active window to a whiteboard window.
                    formWhiteboard whiteboardInstance = (formWhiteboard) this.ActiveMdiChild;
                    // Call the active window's copy operation.
                    whiteboardInstance.EditCopy(sender, e);
                }
                // If current window is a text editor window.
                else if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // Cast the active window to a whiteboard window.
                    formTextEditor texteditorInstance = (formTextEditor)this.ActiveMdiChild;
                    // Call the active window's copy operation.
                    texteditorInstance.EditCopy(sender, e);
                }
                // The current window is not a whiteboard window. Report that.
                else
                {
                    MessageBox.Show("Copy is not supported for the current active window.", "Copy Not Suported");
                }
            }
            // There is no child window. Report that.
            else
            {
                MessageBox.Show("You must select a window that allows copying to copy.", "Copy Not Supported");
            }
        }

        /// <summary>
        /// Detect the window type,; if it supports paste, call that window's paste operation.
        /// </summary>
        private void EditPaste(object sender, EventArgs e)
        {
            // If there's at least one MdiChild.
            if (this.MdiChildren.Length > 0)
            {
                // If current window is a whiteboard window.
                if (this.ActiveMdiChild.GetType() == typeof(formWhiteboard))
                {
                    // Cast the active window to a whiteboard window.
                    formWhiteboard whiteboardInstance = (formWhiteboard) this.ActiveMdiChild;
                    // Call the active window's paste operation.
                    whiteboardInstance.EditPaste(sender, e);
                }
                // If current window is a whiteboard window.
                else if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // Cast the active window to a whiteboard window.
                    formTextEditor texteditorInstance = (formTextEditor)this.ActiveMdiChild;
                    // Call the active window's paste operation.
                    texteditorInstance.EditPaste(sender, e);
                }
                // The current window is not a whiteboard window. Report that.
                else
                {
                    MessageBox.Show("Paste is not supported for the current active window.", "Paste Not Suported");
                }
            }
            // There is no child window. Report that.
            else
            {
                MessageBox.Show("You must select a window that allows paste to do that.", "Paste Not Supported");
            }
        }

        /// <summary>
        /// Set the window layout to tile horizontal.
        /// </summary>
        private void WindowTileHorizontal(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Set the window layout to tile vertical.
        /// </summary>
        private void WindowTileVertical(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Set the window layout to cascade.
        /// </summary>
        private void WindowCascade(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Opens a new Whiteboard window instance as a child window.
        /// </summary>
        private void WindowNewWhiteboard(object sender, EventArgs e)
        {
            formWhiteboard whiteboardInstance = new formWhiteboard();
            whiteboardInstance.MdiParent = this;
            whiteboardInstance.Show();
        }

        /// <summary>
        /// This assigns the instance property of the new child form to a variable called entryInstance, sets it as an MDI child and displays it.
        /// </summary>
        private void WindowNewCustomerEntry(object sender, EventArgs e)
        {
            // Create or call instance of the child below.
            formCustomerEntry entryInstance = formCustomerEntry.Instance;

            // Assign this child window an MdiParent
            entryInstance.MdiParent = this;

            // Display this instance and if it's already visible put focus on it.
            entryInstance.Show();
            entryInstance.Focus();
        }

        /// <summary>
        /// Displays a little message about this application.
        /// </summary>
        private void HelpAbout(object sender, EventArgs e)
        {
            MessageBox.Show("Multi-Functional Text Editor Tool\n" + "By Rohail Shah\n\n" + "For NETD 2202\n" + "March-April 2021", "About This Application");
        }
    }
}
