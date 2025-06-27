namespace Interactive3DPrimitives
{
    partial class Form1
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            trackBar1 = new TrackBar();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            picCanvas = new PictureBox();
            panel4 = new Panel();
            label2 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btnCilinder = new FontAwesome.Sharp.IconButton();
            btnSphere = new FontAwesome.Sharp.IconButton();
            btnCube = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1084, 53);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(392, 5);
            label1.Name = "label1";
            label1.Size = new Size(279, 35);
            label1.TabIndex = 0;
            label1.Text = "Primitive 3D Viewer";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 53);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1084, 560);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(trackBar1);
            panel3.Controls.Add(iconButton3);
            panel3.Controls.Add(iconButton2);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(10, 490);
            panel3.Name = "panel3";
            panel3.Size = new Size(1064, 60);
            panel3.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(162, 12);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(287, 45);
            trackBar1.TabIndex = 2;
            // 
            // iconButton3
            // 
            iconButton3.Cursor = Cursors.Hand;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 30;
            iconButton3.Location = new Point(79, 12);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(56, 37);
            iconButton3.TabIndex = 1;
            iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.UpDownLeftRight;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 30;
            iconButton2.Location = new Point(7, 12);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(56, 37);
            iconButton2.TabIndex = 0;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(picCanvas, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1064, 540);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picCanvas
            // 
            picCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picCanvas.BorderStyle = BorderStyle.Fixed3D;
            picCanvas.Location = new Point(3, 3);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(845, 534);
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(iconButton1);
            panel4.Controls.Add(btnCilinder);
            panel4.Controls.Add(btnSphere);
            panel4.Controls.Add(btnCube);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(854, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(207, 534);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(255, 192, 128);
            label2.Location = new Point(46, 33);
            label2.Name = "label2";
            label2.Size = new Size(110, 37);
            label2.TabIndex = 4;
            label2.Text = "Figuras";
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Play;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 40;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(13, 318);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(177, 43);
            iconButton1.TabIndex = 3;
            iconButton1.Text = "Cilindro";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnCilinder
            // 
            btnCilinder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCilinder.Cursor = Cursors.Hand;
            btnCilinder.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnCilinder.IconColor = Color.Black;
            btnCilinder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCilinder.IconSize = 40;
            btnCilinder.ImageAlign = ContentAlignment.MiddleLeft;
            btnCilinder.Location = new Point(13, 247);
            btnCilinder.Name = "btnCilinder";
            btnCilinder.Size = new Size(177, 43);
            btnCilinder.TabIndex = 2;
            btnCilinder.Text = "Cilindro";
            btnCilinder.UseVisualStyleBackColor = true;
            // 
            // btnSphere
            // 
            btnSphere.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSphere.Cursor = Cursors.Hand;
            btnSphere.IconChar = FontAwesome.Sharp.IconChar.Circle;
            btnSphere.IconColor = Color.Black;
            btnSphere.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSphere.IconSize = 40;
            btnSphere.ImageAlign = ContentAlignment.MiddleLeft;
            btnSphere.Location = new Point(13, 183);
            btnSphere.Name = "btnSphere";
            btnSphere.Size = new Size(177, 43);
            btnSphere.TabIndex = 1;
            btnSphere.Text = "Esfera";
            btnSphere.UseVisualStyleBackColor = true;
            // 
            // btnCube
            // 
            btnCube.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCube.Cursor = Cursors.Hand;
            btnCube.IconChar = FontAwesome.Sharp.IconChar.Cube;
            btnCube.IconColor = Color.Black;
            btnCube.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCube.IconSize = 40;
            btnCube.ImageAlign = ContentAlignment.MiddleLeft;
            btnCube.Location = new Point(13, 117);
            btnCube.Name = "btnCube";
            btnCube.Size = new Size(177, 43);
            btnCube.TabIndex = 0;
            btnCube.Text = "Cubo";
            btnCube.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1084, 613);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(680, 500);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private PictureBox picCanvas;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton btnSphere;
        private FontAwesome.Sharp.IconButton btnCube;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnCilinder;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TrackBar trackBar1;
    }
}
