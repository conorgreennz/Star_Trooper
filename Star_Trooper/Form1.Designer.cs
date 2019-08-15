namespace Star_Trooper
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtLives = new System.Windows.Forms.TextBox();
            this.LblPoints = new System.Windows.Forms.Label();
            this.LblPts = new System.Windows.Forms.Label();
            this.LblLives = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TmrGame = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Button1);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Controls.Add(this.TxtLives);
            this.panel1.Controls.Add(this.LblPoints);
            this.panel1.Controls.Add(this.LblPts);
            this.panel1.Controls.Add(this.LblLives);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Location = new System.Drawing.Point(835, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 510);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Papyrus", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(31, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 49);
            this.button2.TabIndex = 11;
            this.button2.Text = "High Score";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(31, 270);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(99, 49);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "Reset";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(31, 76);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 9;
            // 
            // TxtLives
            // 
            this.TxtLives.Location = new System.Drawing.Point(31, 150);
            this.TxtLives.Name = "TxtLives";
            this.TxtLives.Size = new System.Drawing.Size(100, 20);
            this.TxtLives.TabIndex = 8;
            // 
            // LblPoints
            // 
            this.LblPoints.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblPoints.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblPoints.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblPoints.Location = new System.Drawing.Point(31, 218);
            this.LblPoints.Name = "LblPoints";
            this.LblPoints.Size = new System.Drawing.Size(98, 28);
            this.LblPoints.TabIndex = 7;
            this.LblPoints.Text = "0";
            this.LblPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblPts
            // 
            this.LblPts.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblPts.Location = new System.Drawing.Point(31, 185);
            this.LblPts.Name = "LblPts";
            this.LblPts.Size = new System.Drawing.Size(58, 24);
            this.LblPts.TabIndex = 6;
            this.LblPts.Text = "Points";
            // 
            // LblLives
            // 
            this.LblLives.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLives.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblLives.Location = new System.Drawing.Point(31, 123);
            this.LblLives.Name = "LblLives";
            this.LblLives.Size = new System.Drawing.Size(103, 24);
            this.LblLives.TabIndex = 5;
            this.LblLives.Text = "Lives Count";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Papyrus", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Starship Troopers";
            // 
            // LblName
            // 
            this.LblName.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblName.Location = new System.Drawing.Point(31, 54);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(70, 24);
            this.LblName.TabIndex = 3;
            this.LblName.Text = "Name";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Black;
            this.PictureBox1.Location = new System.Drawing.Point(0, 27);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(835, 510);
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.StopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.StartToolStripMenuItem.Text = "Start";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.StopToolStripMenuItem.Text = "Stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // TmrGame
            // 
            this.TmrGame.Enabled = true;
            this.TmrGame.Tick += new System.EventHandler(this.TmrGame_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(993, 536);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtLives;
        private System.Windows.Forms.Label LblPoints;
        private System.Windows.Forms.Label LblPts;
        private System.Windows.Forms.Label LblLives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        private System.Windows.Forms.Timer TmrGame;
        private System.Windows.Forms.Button button2;
    }
}

