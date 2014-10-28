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

        //attributes
        private int currentXB, currentYB;
        private bool isDragging = false;
        private PictureBox curBox = null;
        private bool isPressedD = false;
        private bool isPressedF = false;
        private bool isPressedB = false;
        Image image;
        int p = 0;

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
        }

        private void platButton_Click(object sender, EventArgs e)
        {
            // creates a new picturebox and puts
            // it into the platformStuff array
            platformStuff[p] = new PictureBox();
            platformStuff[p].Visible = true;
            platformStuff[p].Name = "platform" + p;
            // sets the image to the pictureBox
            image = Properties.Resources.Platform;
            platformStuff[p].Image = image;
            platformStuff[p].Size = new System.Drawing.Size(image.Width, image.Height);
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
            fileName = "map.txt";

            try
            {
                // create the streamwriter object
                output = new StreamWriter(fileName);

                // finds all the platformStuff pictureBoxes
                foreach (PictureBox picP in platformStuff)
                {
                    if (picP != null && picP.Visible == true)
                    {
                        // writes the type of image, the x and y coordinates with the width and height
                        output.WriteLine("Type: platform," + " X Coord, " + picP.Left + ", Y Coord, " + picP.Top + ", Width, " + picP.Width + " ,Height, " + picP.Height);
                        string P = "Type: platform, " + " X Coord, " + picP.Left + ", Y Coord, " + picP.Top + ", Width, " + picP.Width + " ,Height, " + picP.Height;
                        string[] plat = P.Split(',');
                    }
                }
                output.Close();
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Output Message: " + ioe.Message);
                Console.WriteLine("Output StackTrace: " + ioe.StackTrace);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            StreamReader input = null;

            try
            {
                // open file for reading
                input = new StreamReader("map.txt");

                // read and list all of the data
                string text = "";
                while ((text = input.ReadLine()) != null)
                {
                    Console.WriteLine(text);
                    string[] ls = text.Split(',');

                    // loads all the platform objects
                    if (ls[0].Contains("platform"))
                    {
                        int x;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        int y;
                        parsed = int.TryParse(ls[4], out y);
                        // creates a new picturebox and puts
                        // it into the platformStuff array
                        platformStuff[p] = new PictureBox();
                        platformStuff[p].Visible = true;
                        platformStuff[p].Name = "platform" + p;
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
                        p++;
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picP in platformStuff)
            {
                if (picP != null)
                {
                    picP.Image = null;
                }
            }
        }
    }
}
