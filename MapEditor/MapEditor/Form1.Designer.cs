namespace MapEditor
{
    partial class Form1
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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.vinesButton = new System.Windows.Forms.Button();
            this.longPlatButton = new System.Windows.Forms.Button();
            this.platButton = new System.Windows.Forms.Button();
            this.charButton = new System.Windows.Forms.Button();
            this.basicButton = new System.Windows.Forms.Button();
            this.homingButton = new System.Windows.Forms.Button();
            this.endbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(617, 704);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(729, 704);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(487, 704);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vines";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // vinesButton
            // 
            this.vinesButton.BackgroundImage = global::MapEditor.Properties.Resources.Vines;
            this.vinesButton.Location = new System.Drawing.Point(269, 693);
            this.vinesButton.Name = "vinesButton";
            this.vinesButton.Size = new System.Drawing.Size(69, 44);
            this.vinesButton.TabIndex = 5;
            this.vinesButton.Text = "Vines";
            this.vinesButton.UseVisualStyleBackColor = true;
            this.vinesButton.Click += new System.EventHandler(this.vinesButton_Click_1);
            // 
            // longPlatButton
            // 
            this.longPlatButton.BackgroundImage = global::MapEditor.Properties.Resources.Long_Platform;
            this.longPlatButton.Location = new System.Drawing.Point(146, 693);
            this.longPlatButton.Name = "longPlatButton";
            this.longPlatButton.Size = new System.Drawing.Size(69, 44);
            this.longPlatButton.TabIndex = 4;
            this.longPlatButton.Text = "Long Platform";
            this.longPlatButton.UseVisualStyleBackColor = true;
            this.longPlatButton.Click += new System.EventHandler(this.longPlatButton_Click);
            // 
            // platButton
            // 
            this.platButton.BackgroundImage = global::MapEditor.Properties.Resources.Platform;
            this.platButton.Location = new System.Drawing.Point(26, 693);
            this.platButton.Name = "platButton";
            this.platButton.Size = new System.Drawing.Size(69, 44);
            this.platButton.TabIndex = 0;
            this.platButton.Text = "Platform";
            this.platButton.UseVisualStyleBackColor = true;
            this.platButton.Click += new System.EventHandler(this.platButton_Click);
            // 
            // charButton
            // 
            this.charButton.BackgroundImage = global::MapEditor.Properties.Resources.Haruka;
            this.charButton.Location = new System.Drawing.Point(369, 693);
            this.charButton.Name = "charButton";
            this.charButton.Size = new System.Drawing.Size(69, 44);
            this.charButton.TabIndex = 6;
            this.charButton.Text = "Character";
            this.charButton.UseVisualStyleBackColor = true;
            this.charButton.Click += new System.EventHandler(this.charButton_Click);
            // 
            // basicButton
            // 
            this.basicButton.BackgroundImage = global::MapEditor.Properties.Resources.Basic_Samurai;
            this.basicButton.Location = new System.Drawing.Point(26, 643);
            this.basicButton.Name = "basicButton";
            this.basicButton.Size = new System.Drawing.Size(69, 44);
            this.basicButton.TabIndex = 7;
            this.basicButton.Text = "Basic";
            this.basicButton.UseVisualStyleBackColor = true;
            this.basicButton.Click += new System.EventHandler(this.basicButton_Click);
            // 
            // homingButton
            // 
            this.homingButton.BackgroundImage = global::MapEditor.Properties.Resources.Homing_Samurai;
            this.homingButton.Location = new System.Drawing.Point(117, 627);
            this.homingButton.Name = "homingButton";
            this.homingButton.Size = new System.Drawing.Size(69, 44);
            this.homingButton.TabIndex = 8;
            this.homingButton.Text = "Homing";
            this.homingButton.UseVisualStyleBackColor = true;
            this.homingButton.Click += new System.EventHandler(this.homingButton_Click);
            // 
            // endbutton
            // 
            this.endbutton.BackgroundImage = global::MapEditor.Properties.Resources.End;
            this.endbutton.Location = new System.Drawing.Point(221, 627);
            this.endbutton.Name = "endbutton";
            this.endbutton.Size = new System.Drawing.Size(69, 44);
            this.endbutton.TabIndex = 9;
            this.endbutton.Text = "End";
            this.endbutton.UseVisualStyleBackColor = true;
            this.endbutton.Click += new System.EventHandler(this.endbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MapEditor.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.endbutton);
            this.Controls.Add(this.homingButton);
            this.Controls.Add(this.basicButton);
            this.Controls.Add(this.charButton);
            this.Controls.Add(this.vinesButton);
            this.Controls.Add(this.longPlatButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.platButton);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button platButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button longPlatButton;
        private System.Windows.Forms.Button vinesButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button charButton;
        private System.Windows.Forms.Button basicButton;
        private System.Windows.Forms.Button homingButton;
        private System.Windows.Forms.Button endbutton;
    }
}

