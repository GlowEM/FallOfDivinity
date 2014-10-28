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
            this.platButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // platButton
            // 
            this.platButton.BackgroundImage = global::MapEditor.Properties.Resources.Platform;
            this.platButton.Location = new System.Drawing.Point(71, 398);
            this.platButton.Name = "platButton";
            this.platButton.Size = new System.Drawing.Size(69, 44);
            this.platButton.TabIndex = 0;
            this.platButton.Text = "Platform";
            this.platButton.UseVisualStyleBackColor = true;
            this.platButton.Click += new System.EventHandler(this.platButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 481);
            this.Controls.Add(this.platButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button platButton;
    }
}

