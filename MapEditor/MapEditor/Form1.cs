using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapEditor
{
    // Map Editor
    public partial class Form1 : Form
    {
        PictureBox[] platformStuff = new PictureBox[1000];
        PictureBox[] longPlatStuff = new PictureBox[1000];
        PictureBox[] vinesStuff = new PictureBox[1000];
        PictureBox[] charStuff = new PictureBox[1000];
        PictureBox[] basicStuff = new PictureBox[1000];
        PictureBox[] homingStuff = new PictureBox[1000];

        //attributes
        private int currentXB, currentYB;
        private bool isDragging = false;
        private PictureBox curBox = null;
        private bool isPressedD = false;
        private bool isPressedF = false;
        private bool isPressedB = false;
        private bool isPressedC = false;
        Image image;
        int p = 0;
        int l = 0;
        int v = 0;
        int c = 0;
        int b = 0;
        int h = 0;

        public Form1()
        {
            InitializeComponent();
            // new mouse events
            this.MouseDown += new MouseEventHandler(mouseDown);
            this.MouseUp += new MouseEventHandler(mouseUp);
            this.MouseMove += new MouseEventHandler(mouseMove);
            this.KeyDown += new KeyEventHandler(keyDown);
            this.KeyUp += new KeyEventHandler(keyUp);
            this.KeyPress += new KeyPressEventHandler(keyPress);
            this.KeyPreview = true;
            this.Size = new System.Drawing.Size(1280, 800);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            foreach (PictureBox picP in platformStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                    if (e.KeyCode == Keys.C)
                    {
                        isPressedC = true;
                    }
                }
            }
            foreach (PictureBox picL in longPlatStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                    if (e.KeyCode == Keys.C)
                    {
                        isPressedC = true;
                    }
                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                }
            }
            foreach (PictureBox picC in charStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                var mouseLocation = Cursor.Position;

                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = true;
                    }
                    // true if F key is down
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = true;
                    }
                    // true if B key is down
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = true;
                    }
                }
            }

        }
        private void keyUp(object sender, KeyEventArgs e)
        {
            foreach (PictureBox picP in platformStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                    if (e.KeyCode == Keys.C)
                    {
                        isPressedC = false;
                    }
                }
            }
            foreach (PictureBox picL in longPlatStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                    if (e.KeyCode == Keys.C)
                    {
                        isPressedC = false;
                    }
                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                }
            }
            foreach (PictureBox picC in charStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is up
                    if (e.KeyCode == Keys.D)
                    {
                        isPressedD = false;
                    }
                    // true if F key is up
                    if (e.KeyCode == Keys.F)
                    {
                        isPressedF = false;
                    }
                    // true if B key is up
                    if (e.KeyCode == Keys.B)
                    {
                        isPressedB = false;
                    }
                }
            }
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            foreach (PictureBox picP in platformStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picP.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picP.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picP.SendToBack();
                    }
                    if (isPressedC)
                    {
                        if (charStuff[0] != null)
                        {
                            charStuff[0].Location = new Point(picP.Location.X, picP.Location.Y - charStuff[0].Size.Height);
                        }
                    }
                }
            }
            foreach (PictureBox picL in longPlatStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picL.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picL.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picL.SendToBack();
                    }
                    if (isPressedC)
                    {
                        if (charStuff[0] != null)
                        {
                            charStuff[0].Location = new Point(picL.Location.X, picL.Location.Y - charStuff[0].Size.Height);
                        }
                    }
                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picV.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picV.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picV.SendToBack();
                    }
                }
            }
            foreach (PictureBox picC in charStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picC.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picC.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picC.SendToBack();
                    }
                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picB.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picB.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picB.SendToBack();
                    }
                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    // if D key is pressed hides
                    // the pictureBox from the user
                    if (isPressedD)
                    {
                        picH.Hide();
                    }
                    // if F key is pressed brings
                    // pictureBox to front
                    if (isPressedF)
                    {
                        picH.BringToFront();
                    }
                    // if B key is pressed brings
                    // pictureBox to the back
                    if (isPressedB)
                    {
                        picH.SendToBack();
                    }
                }
            }
        }
        private void mouseDown(object sender, MouseEventArgs e)
        {
            // loops through platform
            // which is an array of
            // picuterboxes
            foreach (PictureBox picP in platformStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picP;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
            // loops through long platform
            // which is an array of
            // picuterboxes
            foreach (PictureBox picL in longPlatStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picL;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picV;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
            foreach (PictureBox picC in charStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picC;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picB;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                // gets the mouse pointer position
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the picturebox
                // if there is an image, it checks to see if mouse button
                // is pressed
                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    // true if left mouse button is down
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = true;
                        curBox = picH;
                        currentXB = e.X;
                        currentYB = e.Y;
                    }
                }
            }
        }
        private void mouseUp(object sender, MouseEventArgs e)
        {
            // loops through  platformStuff array
            foreach (PictureBox picP in platformStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
            // loops through  platformStuff array
            foreach (PictureBox picL in longPlatStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
            foreach (PictureBox picC in charStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // will stop moving the pictureBox
                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragging = false;
                        curBox = null;
                    }

                }
            }
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            // loops through platformStuff
            foreach (PictureBox picP in platformStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picP != null && picP.ClientRectangle.Contains(picP.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picP == curBox)
                        {
                            picP.BringToFront();
                            picP.Top = picP.Top + (e.Y - currentYB);
                            picP.Left = picP.Left + (e.X - currentXB);
                        }
                    }
                }
            }
            // loops through platformStuff
            foreach (PictureBox picL in longPlatStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picL != null && picL.ClientRectangle.Contains(picL.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picL == curBox)
                        {
                            picL.BringToFront();
                            picL.Top = picL.Top + (e.Y - currentYB);
                            picL.Left = picL.Left + (e.X - currentXB);
                        }
                    }
                }
            }
            foreach (PictureBox picV in vinesStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picV != null && picV.ClientRectangle.Contains(picV.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picV == curBox)
                        {
                            picV.BringToFront();
                            picV.Top = picV.Top + (e.Y - currentYB);
                            picV.Left = picV.Left + (e.X - currentXB);
                        }
                    }
                }
            }
            foreach (PictureBox picC in charStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picC != null && picC.ClientRectangle.Contains(picC.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picC == curBox)
                        {
                            picC.BringToFront();
                            picC.Top = picC.Top + (e.Y - currentYB);
                            picC.Left = picC.Left + (e.X - currentXB);
                        }
                    }
                }
            }
            foreach (PictureBox picB in basicStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picB != null && picB.ClientRectangle.Contains(picB.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picB == curBox)
                        {
                            picB.BringToFront();
                            picB.Top = picB.Top + (e.Y - currentYB);
                            picB.Left = picB.Left + (e.X - currentXB);
                        }
                    }
                }
            }
            foreach (PictureBox picH in homingStuff)
            {
                // gets position of mouse
                var mouseLocation = Cursor.Position;

                // checks to see if there is an image in the pictureBox
                if (picH != null && picH.ClientRectangle.Contains(picH.PointToClient(Control.MousePosition)))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // moves the pictureBox with the mouse
                        if (isDragging && picH == curBox)
                        {
                            picH.BringToFront();
                            picH.Top = picH.Top + (e.Y - currentYB);
                            picH.Left = picH.Left + (e.X - currentXB);
                        }
                    }
                }
            }
        }

        private void platButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the platformStuff array
            platformStuff[p] = new PictureBox();
            platformStuff[p].Visible = true;
            platformStuff[p].Name = "platforms" + p;
            // sets the image to the pictureBox
            image = Properties.Resources.Platform;
            platformStuff[p].Image = image;
            platformStuff[p].Size = new System.Drawing.Size(image.Width, image.Height);
            platformStuff[p].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            platformStuff[p].Location = new Point(1, 1);
            // mouseEvents
            platformStuff[p].MouseDown += new MouseEventHandler(this.mouseDown);
            platformStuff[p].MouseUp += new MouseEventHandler(this.mouseUp);
            platformStuff[p].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(platformStuff[p]);
            p++;
        }


        StreamWriter output = null;

        private string fileName = "";

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Map File (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                try
                {
                    // create the streamwriter object
                    output = new StreamWriter(fileName);
                    int t = 0;
                    int u = 0;
                    int v = 0;
                    // finds all the platformStuff pictureBoxes
                    foreach (PictureBox picP in platformStuff)
                    {

                        if (picP != null && picP.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: platforms " + t + "," + " X Coord, " + picP.Left + ", Y Coord, " + picP.Top + ", Width, " + picP.Width + " , Height, " + picP.Height);
                            string P = "Type: platforms  " + t + "," + " X Coord, " + picP.Left + ", Y Coord, " + picP.Top + ", Width, " + picP.Width + " , Height, " + picP.Height;
                            //string[] plat = P.Split(',');
                        }
                        t++;
                    }
                    foreach (PictureBox picL in longPlatStuff)
                    {
                        if (picL != null && picL.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: long platform " + u + "," + " X Coord, " + picL.Left + ", Y Coord, " + picL.Top + ", Width, " + picL.Width + " , Height, " + picL.Height);
                            string L = "Type: long platform " + u + "," + " X Coord, " + picL.Left + ", Y Coord, " + picL.Top + ", Width, " + picL.Width + " , Height, " + picL.Height;
                            //string[] longP = L.Split(',');
                        }
                        u++;
                    }
                    foreach (PictureBox picV in vinesStuff)
                    {
                        if (picV != null && picV.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: vines " + v + "," + " X Coord, " + picV.Left + ", Y Coord, " + picV.Top + ", Width, " + picV.Width + " , Height, " + picV.Height);
                            string V = "Type: vines " + v + "," + " X Coord, " + picV.Left + ", Y Coord, " + picV.Top + ", Width, " + picV.Width + " , Height, " + picV.Height;
                            //string[] vine = V.Split(',');
                        }
                        v++;
                    }
                    foreach (PictureBox picC in charStuff)
                    {
                        if (picC != null && picC.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: char " + c + "," + " X Coord, " + picC.Left + ", Y Coord, " + picC.Top + ", Width, " + picC.Width + " , Height, " + picC.Height);
                            string C = "Type: char " + c + "," + " X Coord, " + picC.Left + ", Y Coord, " + picC.Top + ", Width, " + picC.Width + " , Height, " + picC.Height;
                            //string[] vine = V.Split(',');
                        }
                        c++;
                    }
                    foreach (PictureBox picB in basicStuff)
                    {
                        if (picB != null && picB.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: basic " + b + "," + " X Coord, " + picB.Left + ", Y Coord, " + picB.Top + ", Width, " + picB.Width + " , Height, " + picB.Height);
                            string B = "Type: basic " + b + "," + " X Coord, " + picB.Left + ", Y Coord, " + picB.Top + ", Width, " + picB.Width + " , Height, " + picB.Height;
                            //string[] vine = V.Split(',');
                        }
                        b++;
                    }
                    foreach (PictureBox picH in homingStuff)
                    {
                        if (picH != null && picH.Visible == true)
                        {
                            // writes the type of image, the x and y coordinates with the width and height
                            output.WriteLine("Type: homing " + h + "," + " X Coord, " + picH.Left + ", Y Coord, " + picH.Top + ", Width, " + picH.Width + " , Height, " + picH.Height);
                            string H = "Type: homin " + h + "," + " X Coord, " + picH.Left + ", Y Coord, " + picH.Top + ", Width, " + picH.Width + " , Height, " + picH.Height;
                            //string[] vine = V.Split(',');
                        }
                        h++;
                    }
                    output.Close();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Output Message: " + ioe.Message);
                    Console.WriteLine("Output StackTrace: " + ioe.StackTrace);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Map File (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader input = null;

                try
                {
                    // open file for reading
                    input = new StreamReader(openFileDialog.FileName);

                    // read and list all of the data
                    string text = "";
                    while ((text = input.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                        string[] ls = text.Split(',');

                        // loads all the platform objects
                        if (ls[0].Contains("platforms"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the platformStuff array
                            platformStuff[p] = new PictureBox();
                            platformStuff[p].Visible = true;
                            platformStuff[p].Name = "platforms" + p;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Platform;
                            platformStuff[p].Image = image;
                            platformStuff[p].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            platformStuff[p].Location = new Point(x, y);
                            // mouseEvents
                            platformStuff[p].MouseDown += new MouseEventHandler(this.mouseDown);
                            platformStuff[p].MouseUp += new MouseEventHandler(this.mouseUp);
                            platformStuff[p].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(platformStuff[p]);
                            platformStuff[p].BackColor = Color.Transparent;
                            p++;
                        }
                        if (ls[0].Contains("long platform"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the platformStuff array
                            longPlatStuff[l] = new PictureBox();
                            longPlatStuff[l].Visible = true;
                            longPlatStuff[l].Name = "long platform" + l;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Long_Platform;
                            longPlatStuff[l].Image = image;
                            longPlatStuff[l].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            longPlatStuff[l].Location = new Point(x, y);
                            // mouseEvents
                            longPlatStuff[l].MouseDown += new MouseEventHandler(this.mouseDown);
                            longPlatStuff[l].MouseUp += new MouseEventHandler(this.mouseUp);
                            longPlatStuff[l].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(longPlatStuff[l]);
                            longPlatStuff[l].BackColor = Color.Transparent;
                            l++;
                        }
                        if (ls[0].Contains("vines"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the vinesStuff array
                            vinesStuff[v] = new PictureBox();
                            vinesStuff[v].Visible = true;
                            vinesStuff[v].Name = "vines" + v;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Vines;
                            vinesStuff[v].Image = image;
                            vinesStuff[v].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            vinesStuff[v].Location = new Point(x, y);
                            // mouseEvents
                            vinesStuff[v].MouseDown += new MouseEventHandler(this.mouseDown);
                            vinesStuff[v].MouseUp += new MouseEventHandler(this.mouseUp);
                            vinesStuff[v].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(vinesStuff[v]);
                            vinesStuff[v].BackColor = Color.Transparent;
                            v++;
                        }
                        if (ls[0].Contains("char"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the charStuff array
                            charStuff[c] = new PictureBox();
                            charStuff[c].Visible = true;
                            charStuff[c].Name = "char" + v;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Haruka;
                            charStuff[c].Image = image;
                            charStuff[c].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            charStuff[c].Location = new Point(x, y);
                            // mouseEvents
                            charStuff[c].MouseDown += new MouseEventHandler(this.mouseDown);
                            charStuff[c].MouseUp += new MouseEventHandler(this.mouseUp);
                            charStuff[c].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(charStuff[c]);
                            charStuff[c].BackColor = Color.Transparent;
                            c++;
                        }
                        if (ls[0].Contains("basic"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the basicStuff array
                            basicStuff[b] = new PictureBox();
                            basicStuff[b].Visible = true;
                            basicStuff[b].Name = "char" + b;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Basic_Samurai;
                            basicStuff[b].Image = image;
                            basicStuff[b].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            basicStuff[b].Location = new Point(x, y);
                            // mouseEvents
                            basicStuff[b].MouseDown += new MouseEventHandler(this.mouseDown);
                            basicStuff[b].MouseUp += new MouseEventHandler(this.mouseUp);
                            basicStuff[b].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(basicStuff[b]);
                            basicStuff[b].BackColor = Color.Transparent;
                            b++;
                        }
                        if (ls[0].Contains("homing"))
                        {
                            int x;
                            Boolean parsed = int.TryParse(ls[2], out x);
                            int y;
                            parsed = int.TryParse(ls[4], out y);
                            // creates a new picturebox and puts
                            // it into the homingStuff array
                            homingStuff[h] = new PictureBox();
                            homingStuff[h].Visible = true;
                            homingStuff[h].Name = "homing" + h;
                            // sets the image to the pictureBox
                            image = Properties.Resources.Homing_Samurai;
                            homingStuff[h].Image = image;
                            homingStuff[h].Size = new System.Drawing.Size(image.Width, image.Height);
                            // puts the pictureBox in the top left corner
                            homingStuff[h].Location = new Point(x, y);
                            // mouseEvents
                            homingStuff[h].MouseDown += new MouseEventHandler(this.mouseDown);
                            homingStuff[h].MouseUp += new MouseEventHandler(this.mouseUp);
                            homingStuff[h].MouseMove += new MouseEventHandler(this.mouseMove);
                            // adds pictureBox to form
                            this.Controls.Add(homingStuff[h]);
                            homingStuff[h].BackColor = Color.Transparent;
                            h++;
                        }
                    }
                    input.Close();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Input Message: " + ioe.Message);
                    Console.WriteLine("Input Stack Trace: " + ioe.StackTrace);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picP in platformStuff)
            {
                if (picP != null)
                {
                    picP.Image = null;
                    picP.Controls.Clear();
                    picP.Dispose();
                }
            }

            for (int i = 0; i < platformStuff.Length; ++i)
            {
                platformStuff[i] = null;
            }

            foreach (PictureBox picL in longPlatStuff)
            {
                if (picL != null)
                {
                    picL.Image = null;
                    picL.Controls.Clear();
                    picL.Dispose();
                }
            }

            for (int i = 0; i < longPlatStuff.Length; ++i)
            {
                longPlatStuff[i] = null;
            }

            foreach (PictureBox picV in vinesStuff)
            {
                if (picV != null)
                {
                    picV.Image = null;
                    picV.Controls.Clear();
                    picV.Dispose();
                }
            }

            for (int i = 0; i < vinesStuff.Length; ++i)
            {
                vinesStuff[i] = null;
            }
            foreach (PictureBox picC in charStuff)
            {
                if (picC != null)
                {
                    picC.Image = null;
                    picC.Controls.Clear();
                    picC.Dispose();
                }
            }

            for (int i = 0; i < charStuff.Length; ++i)
            {
                charStuff[i] = null;
            }
            foreach (PictureBox picB in basicStuff)
            {
                if (picB != null)
                {
                    picB.Image = null;
                    picB.Controls.Clear();
                    picB.Dispose();
                }
            }

            for (int i = 0; i < basicStuff.Length; ++i)
            {
                basicStuff[i] = null;
            }
            foreach (PictureBox picH in homingStuff)
            {
                if (picH != null)
                {
                    picH.Image = null;
                    picH.Controls.Clear();
                    picH.Dispose();
                }
            }

            for (int i = 0; i < homingStuff.Length; ++i)
            {
                homingStuff[i] = null;
            }
        }

        private void longPlatButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the platformStuff array
            longPlatStuff[l] = new PictureBox();
            longPlatStuff[l].Visible = true;
            longPlatStuff[l].Name = "long platform" + l;
            // sets the image to the pictureBox
            image = Properties.Resources.Long_Platform;
            longPlatStuff[l].Image = image;
            longPlatStuff[l].Size = new System.Drawing.Size(image.Width, image.Height);
            longPlatStuff[l].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            longPlatStuff[l].Location = new Point(1, 1);
            // mouseEvents
            longPlatStuff[l].MouseDown += new MouseEventHandler(this.mouseDown);
            longPlatStuff[l].MouseUp += new MouseEventHandler(this.mouseUp);
            longPlatStuff[l].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(longPlatStuff[l]);
            l++;
        }

        private void vinesButton_Click(object sender, EventArgs e)
        {
        }

        private void vinesButton_Click_1(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the vinesStuff array
            vinesStuff[v] = new PictureBox();
            vinesStuff[v].Visible = true;
            vinesStuff[v].Name = "vines" + v;
            // sets the image to the pictureBox
            image = Properties.Resources.Vines;
            vinesStuff[v].Image = image;
            vinesStuff[v].Size = new System.Drawing.Size(image.Width, image.Height);
            vinesStuff[v].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            vinesStuff[v].Location = new Point(1, 1);
            // mouseEvents
            vinesStuff[v].MouseDown += new MouseEventHandler(this.mouseDown);
            vinesStuff[v].MouseUp += new MouseEventHandler(this.mouseUp);
            vinesStuff[v].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(vinesStuff[v]);
            v++;
        }

        private void charButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the basicStuff array
            charStuff[c] = new PictureBox();
            charStuff[c].Visible = true;
            charStuff[c].Name = "char" + v;
            // sets the image to the pictureBox
            image = Properties.Resources.Haruka;
            charStuff[c].Image = image;
            charStuff[c].Size = new System.Drawing.Size(image.Width, image.Height);
            charStuff[c].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            charStuff[c].Location = new Point(1, 1);
            // mouseEvents
            charStuff[c].MouseDown += new MouseEventHandler(this.mouseDown);
            charStuff[c].MouseUp += new MouseEventHandler(this.mouseUp);
            charStuff[c].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(charStuff[c]);
            c++;
        }

        private void basicButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the basicStuff array
            basicStuff[b] = new PictureBox();
            basicStuff[b].Visible = true;
            basicStuff[b].Name = "basic" + b;
            // sets the image to the pictureBox
            image = Properties.Resources.Basic_Samurai;
            basicStuff[b].Image = image;
            basicStuff[b].Size = new System.Drawing.Size(image.Width, image.Height);
            basicStuff[b].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            basicStuff[b].Location = new Point(1, 1);
            // mouseEvents
            basicStuff[b].MouseDown += new MouseEventHandler(this.mouseDown);
            basicStuff[b].MouseUp += new MouseEventHandler(this.mouseUp);
            basicStuff[b].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(basicStuff[b]);
            b++;
        }

        private void homingButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the basicStuff array
            homingStuff[h] = new PictureBox();
            homingStuff[h].Visible = true;
            homingStuff[h].Name = "homing" + h;
            // sets the image to the pictureBox
            image = Properties.Resources.Homing_Samurai;
            homingStuff[h].Image = image;
            homingStuff[h].Size = new System.Drawing.Size(image.Width, image.Height);
            homingStuff[h].BackColor = Color.Transparent;
            // puts the pictureBox in the top left corner
            homingStuff[h].Location = new Point(1, 1);
            // mouseEvents
            homingStuff[h].MouseDown += new MouseEventHandler(this.mouseDown);
            homingStuff[h].MouseUp += new MouseEventHandler(this.mouseUp);
            homingStuff[h].MouseMove += new MouseEventHandler(this.mouseMove);
            // adds pictureBox to form
            this.Controls.Add(homingStuff[h]);
            h++;
        }
    }
}
