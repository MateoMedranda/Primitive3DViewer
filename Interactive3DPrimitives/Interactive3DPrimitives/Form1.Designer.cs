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
            label5 = new Label();
            lbFigure = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            FusionButton = new FontAwesome.Sharp.IconButton();
            picColor = new PictureBox();
            btnFigureColor = new FontAwesome.Sharp.IconButton();
            lbMode = new Label();
            label3 = new Label();
            btnRotate = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            picCanvas = new PictureBox();
            panel4 = new Panel();
            label2 = new Label();
            btnCone = new FontAwesome.Sharp.IconButton();
            btnCilinder = new FontAwesome.Sharp.IconButton();
            btnSphere = new FontAwesome.Sharp.IconButton();
            btnCube = new FontAwesome.Sharp.IconButton();
            figureColor = new ColorDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picColor).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbFigure);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1239, 107);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(19, 65);
            label5.Name = "label5";
            label5.Size = new Size(105, 35);
            label5.TabIndex = 7;
            label5.Text = "Figura: ";
            // 
            // lbFigure
            // 
            lbFigure.AutoSize = true;
            lbFigure.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            lbFigure.ForeColor = SystemColors.Control;
            lbFigure.Location = new Point(130, 68);
            lbFigure.Name = "lbFigure";
            lbFigure.Size = new Size(144, 35);
            lbFigure.TabIndex = 7;
            lbFigure.Text = "- - - - - - - -";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(478, 12);
            label1.Name = "label1";
            label1.Size = new Size(346, 44);
            label1.TabIndex = 0;
            label1.Text = "Primitive 3D Viewer";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 107);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(1239, 642);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(FusionButton);
            panel3.Controls.Add(picColor);
            panel3.Controls.Add(btnFigureColor);
            panel3.Controls.Add(lbMode);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnRotate);
            panel3.Controls.Add(iconButton2);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(11, 545);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1217, 84);
            panel3.TabIndex = 1;
            // 
            // FusionButton
            // 
            FusionButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            FusionButton.Cursor = Cursors.Hand;
            FusionButton.Font = new Font("Segoe UI", 12F);
            FusionButton.IconChar = FontAwesome.Sharp.IconChar.ObjectUngroup;
            FusionButton.IconColor = Color.FromArgb(64, 64, 0);
            FusionButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            FusionButton.IconSize = 40;
            FusionButton.ImageAlign = ContentAlignment.MiddleLeft;
            FusionButton.Location = new Point(966, 10);
            FusionButton.Margin = new Padding(3, 4, 3, 4);
            FusionButton.Name = "FusionButton";
            FusionButton.Size = new Size(248, 57);
            FusionButton.TabIndex = 5;
            FusionButton.Text = "Fusionar Figuras";
            FusionButton.UseVisualStyleBackColor = true;
            FusionButton.Click += iconButton1_Click;
            // 
            // picColor
            // 
            picColor.BackColor = Color.Transparent;
            picColor.BorderStyle = BorderStyle.FixedSingle;
            picColor.Location = new Point(597, 12);
            picColor.Margin = new Padding(3, 4, 3, 4);
            picColor.Name = "picColor";
            picColor.Size = new Size(19, 55);
            picColor.TabIndex = 8;
            picColor.TabStop = false;
            // 
            // btnFigureColor
            // 
            btnFigureColor.IconChar = FontAwesome.Sharp.IconChar.Palette;
            btnFigureColor.IconColor = Color.Black;
            btnFigureColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFigureColor.IconSize = 32;
            btnFigureColor.Location = new Point(539, 12);
            btnFigureColor.Margin = new Padding(3, 4, 3, 4);
            btnFigureColor.Name = "btnFigureColor";
            btnFigureColor.Size = new Size(50, 56);
            btnFigureColor.TabIndex = 7;
            btnFigureColor.UseVisualStyleBackColor = true;
            btnFigureColor.Click += btnFigureColor_Click;
            // 
            // lbMode
            // 
            lbMode.AutoSize = true;
            lbMode.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            lbMode.ForeColor = SystemColors.Control;
            lbMode.Location = new Point(736, 16);
            lbMode.Name = "lbMode";
            lbMode.Size = new Size(97, 35);
            lbMode.TabIndex = 6;
            lbMode.Text = "Estático";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(642, 16);
            label3.Name = "label3";
            label3.Size = new Size(94, 35);
            label3.TabIndex = 5;
            label3.Text = "Modo: ";
            // 
            // btnRotate
            // 
            btnRotate.Cursor = Cursors.Hand;
            btnRotate.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnRotate.IconColor = Color.Black;
            btnRotate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRotate.IconSize = 30;
            btnRotate.Location = new Point(90, 16);
            btnRotate.Margin = new Padding(3, 4, 3, 4);
            btnRotate.Name = "btnRotate";
            btnRotate.Size = new Size(64, 49);
            btnRotate.TabIndex = 1;
            btnRotate.UseVisualStyleBackColor = true;
            btnRotate.Click += btnRotate_Click;
            // 
            // iconButton2
            // 
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.UpDownLeftRight;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 30;
            iconButton2.Location = new Point(8, 16);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(64, 49);
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
            tableLayoutPanel1.Location = new Point(11, 13);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(1217, 616);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picCanvas
            // 
            picCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picCanvas.BorderStyle = BorderStyle.Fixed3D;
            picCanvas.Location = new Point(3, 4);
            picCanvas.Margin = new Padding(3, 4, 3, 4);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(967, 608);
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            picCanvas.SizeChanged += picCanvas_SizeChanged;
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(btnCone);
            panel4.Controls.Add(btnCilinder);
            panel4.Controls.Add(btnSphere);
            panel4.Controls.Add(btnCube);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(976, 4);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(238, 608);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(255, 192, 128);
            label2.Location = new Point(54, -8);
            label2.Name = "label2";
            label2.Size = new Size(137, 46);
            label2.TabIndex = 4;
            label2.Text = "Figuras";
            // 
            // btnCone
            // 
            btnCone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCone.Cursor = Cursors.Hand;
            btnCone.Font = new Font("Segoe UI", 12F);
            btnCone.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnCone.IconColor = Color.FromArgb(64, 64, 0);
            btnCone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCone.IconSize = 40;
            btnCone.ImageAlign = ContentAlignment.MiddleLeft;
            btnCone.Location = new Point(15, 372);
            btnCone.Margin = new Padding(3, 4, 3, 4);
            btnCone.Name = "btnCone";
            btnCone.Size = new Size(202, 57);
            btnCone.TabIndex = 3;
            btnCone.Text = "Cono";
            btnCone.UseVisualStyleBackColor = true;
            btnCone.Click += btnCone_Click;
            // 
            // btnCilinder
            // 
            btnCilinder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCilinder.Cursor = Cursors.Hand;
            btnCilinder.Font = new Font("Segoe UI", 12F);
            btnCilinder.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnCilinder.IconColor = Color.FromArgb(64, 0, 64);
            btnCilinder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCilinder.IconSize = 40;
            btnCilinder.ImageAlign = ContentAlignment.MiddleLeft;
            btnCilinder.Location = new Point(15, 277);
            btnCilinder.Margin = new Padding(3, 4, 3, 4);
            btnCilinder.Name = "btnCilinder";
            btnCilinder.Size = new Size(202, 57);
            btnCilinder.TabIndex = 2;
            btnCilinder.Text = "Cilindro";
            btnCilinder.UseVisualStyleBackColor = true;
            btnCilinder.Click += btnCilinder_Click;
            // 
            // btnSphere
            // 
            btnSphere.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSphere.Cursor = Cursors.Hand;
            btnSphere.Font = new Font("Segoe UI", 12F);
            btnSphere.IconChar = FontAwesome.Sharp.IconChar.Circle;
            btnSphere.IconColor = Color.FromArgb(0, 0, 64);
            btnSphere.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSphere.IconSize = 40;
            btnSphere.ImageAlign = ContentAlignment.MiddleLeft;
            btnSphere.Location = new Point(15, 192);
            btnSphere.Margin = new Padding(3, 4, 3, 4);
            btnSphere.Name = "btnSphere";
            btnSphere.Size = new Size(202, 57);
            btnSphere.TabIndex = 1;
            btnSphere.Text = "Esfera";
            btnSphere.UseVisualStyleBackColor = true;
            btnSphere.Click += btnSphere_Click;
            // 
            // btnCube
            // 
            btnCube.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCube.Cursor = Cursors.Hand;
            btnCube.Font = new Font("Segoe UI", 12F);
            btnCube.IconChar = FontAwesome.Sharp.IconChar.Cube;
            btnCube.IconColor = Color.FromArgb(0, 64, 64);
            btnCube.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCube.IconSize = 40;
            btnCube.ImageAlign = ContentAlignment.MiddleLeft;
            btnCube.Location = new Point(15, 104);
            btnCube.Margin = new Padding(3, 4, 3, 4);
            btnCube.Name = "btnCube";
            btnCube.Size = new Size(202, 57);
            btnCube.TabIndex = 0;
            btnCube.Text = "Cubo";
            btnCube.UseVisualStyleBackColor = true;
            btnCube.Click += btnCube_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1239, 749);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(774, 646);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picColor).EndInit();
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
        private FontAwesome.Sharp.IconButton btnCone;
        private FontAwesome.Sharp.IconButton btnCilinder;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnRotate;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label3;
        private Label lbMode;
        private Label label5;
        private Label lbFigure;
        private FontAwesome.Sharp.IconButton btnFigureColor;
        private ColorDialog figureColor;
        private PictureBox picColor;
        private FontAwesome.Sharp.IconButton FusionButton;
    }
}
