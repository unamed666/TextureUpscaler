namespace ImageScaler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectImage = new Button();
            btnResize = new Button();
            txtWidth = new TextBox();
            txtHeight = new TextBox();
            txtLog = new TextBox();
            btnDifuse = new Button();
            btnLinear = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnUpscale = new Button();
            radX2 = new RadioButton();
            radX3 = new RadioButton();
            radX4 = new RadioButton();
            BtnSwap1 = new Button();
            BtnSwap2 = new Button();
            panelResize = new Panel();
            panelUpscale = new Panel();
            label4 = new Label();
            checkSound = new CheckBox();
            checkTemp = new CheckBox();
            linkLabel1 = new LinkLabel();
            CheckTop = new CheckBox();
            BtnOpen = new Button();
            panelResize.SuspendLayout();
            panelUpscale.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectImage
            // 
            btnSelectImage.Anchor = AnchorStyles.Top;
            btnSelectImage.BackColor = Color.Black;
            btnSelectImage.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSelectImage.ForeColor = Color.Transparent;
            btnSelectImage.Location = new Point(9, 117);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(239, 45);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "SELECT FILE (PNG/DDS)";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += BtnSelectImage_Click;
            // 
            // btnResize
            // 
            btnResize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnResize.BackColor = Color.Black;
            btnResize.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResize.ForeColor = Color.Transparent;
            btnResize.Location = new Point(9, 22);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(223, 38);
            btnResize.TabIndex = 1;
            btnResize.Text = "RESIZE";
            btnResize.UseVisualStyleBackColor = false;
            btnResize.Click += BtnResize_Click;
            // 
            // txtWidth
            // 
            txtWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWidth.Font = new Font("Tahoma", 12F);
            txtWidth.Location = new Point(545, 3);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(231, 27);
            txtWidth.TabIndex = 2;
            // 
            // txtHeight
            // 
            txtHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHeight.Font = new Font("Tahoma", 12F);
            txtHeight.Location = new Point(545, 40);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(231, 27);
            txtHeight.TabIndex = 3;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.BackColor = Color.Black;
            txtLog.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.ForeColor = Color.Yellow;
            txtLog.Location = new Point(-7, 336);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(829, 120);
            txtLog.TabIndex = 4;
            txtLog.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDifuse
            // 
            btnDifuse.Anchor = AnchorStyles.Top;
            btnDifuse.BackColor = Color.Black;
            btnDifuse.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.Location = new Point(144, 279);
            btnDifuse.Name = "btnDifuse";
            btnDifuse.Size = new Size(117, 38);
            btnDifuse.TabIndex = 13;
            btnDifuse.Text = "DIFUSE";
            btnDifuse.UseVisualStyleBackColor = false;
            btnDifuse.Click += BtnDifuse_Click;
            // 
            // btnLinear
            // 
            btnLinear.Anchor = AnchorStyles.Top;
            btnLinear.BackColor = Color.Black;
            btnLinear.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.Location = new Point(282, 279);
            btnLinear.Name = "btnLinear";
            btnLinear.Size = new Size(115, 38);
            btnLinear.TabIndex = 12;
            btnLinear.Text = "LINEAR";
            btnLinear.UseVisualStyleBackColor = false;
            btnLinear.Click += BtnLinear_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(472, 7);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 5;
            label1.Text = "Width =";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(469, 44);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 6;
            label2.Text = "Height =";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Times New Roman", 12F);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(11, 289);
            label3.Name = "label3";
            label3.Size = new Size(116, 19);
            label3.TabIndex = 7;
            label3.Text = "Convert to DDS :";
            // 
            // btnUpscale
            // 
            btnUpscale.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUpscale.BackColor = Color.Black;
            btnUpscale.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.Location = new Point(9, 22);
            btnUpscale.Name = "btnUpscale";
            btnUpscale.Size = new Size(177, 38);
            btnUpscale.TabIndex = 8;
            btnUpscale.Text = "UPSCALE";
            btnUpscale.UseVisualStyleBackColor = false;
            btnUpscale.Click += BtnUpscale_Click;
            // 
            // radX2
            // 
            radX2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radX2.AutoSize = true;
            radX2.BackColor = Color.Black;
            radX2.Checked = true;
            radX2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            radX2.ForeColor = Color.Transparent;
            radX2.Location = new Point(472, 29);
            radX2.Name = "radX2";
            radX2.Size = new Size(51, 26);
            radX2.TabIndex = 9;
            radX2.TabStop = true;
            radX2.Text = "X2";
            radX2.UseVisualStyleBackColor = false;
            radX2.CheckedChanged += RadX2_CheckedChanged;
            // 
            // radX3
            // 
            radX3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radX3.AutoSize = true;
            radX3.BackColor = Color.Black;
            radX3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            radX3.ForeColor = Color.Transparent;
            radX3.Location = new Point(572, 29);
            radX3.Name = "radX3";
            radX3.Size = new Size(51, 26);
            radX3.TabIndex = 10;
            radX3.TabStop = true;
            radX3.Text = "X3";
            radX3.UseVisualStyleBackColor = false;
            radX3.CheckedChanged += RadX3_CheckedChanged;
            // 
            // radX4
            // 
            radX4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radX4.AutoSize = true;
            radX4.BackColor = Color.Black;
            radX4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            radX4.ForeColor = Color.Transparent;
            radX4.Location = new Point(680, 29);
            radX4.Name = "radX4";
            radX4.Size = new Size(51, 26);
            radX4.TabIndex = 11;
            radX4.TabStop = true;
            radX4.Text = "X4";
            radX4.UseVisualStyleBackColor = false;
            radX4.CheckedChanged += RadX4_CheckedChanged;
            // 
            // BtnSwap1
            // 
            BtnSwap1.Anchor = AnchorStyles.Top;
            BtnSwap1.BackColor = Color.Black;
            BtnSwap1.FlatStyle = FlatStyle.Flat;
            BtnSwap1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            BtnSwap1.ForeColor = Color.Transparent;
            BtnSwap1.Location = new Point(410, 117);
            BtnSwap1.Name = "BtnSwap1";
            BtnSwap1.Size = new Size(180, 45);
            BtnSwap1.TabIndex = 14;
            BtnSwap1.Text = "RESIZE";
            BtnSwap1.UseVisualStyleBackColor = false;
            BtnSwap1.Click += BtnSwap1_Click;
            // 
            // BtnSwap2
            // 
            BtnSwap2.Anchor = AnchorStyles.Top;
            BtnSwap2.BackColor = Color.Black;
            BtnSwap2.FlatStyle = FlatStyle.Popup;
            BtnSwap2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            BtnSwap2.ForeColor = Color.Transparent;
            BtnSwap2.Location = new Point(596, 117);
            BtnSwap2.Name = "BtnSwap2";
            BtnSwap2.Size = new Size(180, 45);
            BtnSwap2.TabIndex = 15;
            BtnSwap2.Text = "UPSCALE";
            BtnSwap2.UseVisualStyleBackColor = false;
            BtnSwap2.Click += BtnSwap2_Click;
            // 
            // panelResize
            // 
            panelResize.Anchor = AnchorStyles.Top;
            panelResize.Controls.Add(btnResize);
            panelResize.Controls.Add(txtWidth);
            panelResize.Controls.Add(txtHeight);
            panelResize.Controls.Add(label1);
            panelResize.Controls.Add(label2);
            panelResize.Location = new Point(0, 168);
            panelResize.Name = "panelResize";
            panelResize.Size = new Size(801, 78);
            panelResize.TabIndex = 16;
            panelResize.Paint += panel1_Paint;
            // 
            // panelUpscale
            // 
            panelUpscale.Anchor = AnchorStyles.Top;
            panelUpscale.Controls.Add(btnUpscale);
            panelUpscale.Controls.Add(radX2);
            panelUpscale.Controls.Add(radX4);
            panelUpscale.Controls.Add(radX3);
            panelUpscale.Location = new Point(0, 168);
            panelUpscale.Name = "panelUpscale";
            panelUpscale.Size = new Size(755, 78);
            panelUpscale.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Monotype Corsiva", 27.75F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(261, 28);
            label4.Name = "label4";
            label4.Size = new Size(262, 45);
            label4.TabIndex = 17;
            label4.Text = "Texture Upscaler";
            // 
            // checkSound
            // 
            checkSound.Anchor = AnchorStyles.Top;
            checkSound.AutoSize = true;
            checkSound.Checked = true;
            checkSound.CheckState = CheckState.Checked;
            checkSound.ForeColor = Color.Lime;
            checkSound.Location = new Point(11, 24);
            checkSound.Name = "checkSound";
            checkSound.Size = new Size(60, 19);
            checkSound.TabIndex = 18;
            checkSound.Text = "Sound";
            checkSound.UseVisualStyleBackColor = true;
            checkSound.CheckedChanged += checkSound_CheckedChanged;
            // 
            // checkTemp
            // 
            checkTemp.Anchor = AnchorStyles.Top;
            checkTemp.AutoSize = true;
            checkTemp.Checked = true;
            checkTemp.CheckState = CheckState.Checked;
            checkTemp.ForeColor = Color.Lime;
            checkTemp.Location = new Point(11, 49);
            checkTemp.Name = "checkTemp";
            checkTemp.Size = new Size(145, 19);
            checkTemp.TabIndex = 19;
            checkTemp.Text = "Save Temporary Image";
            checkTemp.UseVisualStyleBackColor = true;
            checkTemp.CheckedChanged += checkTemp_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Yellow;
            linkLabel1.Location = new Point(682, 28);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(94, 15);
            linkLabel1.TabIndex = 20;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "By: UNAMED666";
            linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // CheckTop
            // 
            CheckTop.Anchor = AnchorStyles.Top;
            CheckTop.AutoSize = true;
            CheckTop.ForeColor = Color.Lime;
            CheckTop.Location = new Point(11, 74);
            CheckTop.Name = "CheckTop";
            CheckTop.Size = new Size(104, 19);
            CheckTop.TabIndex = 21;
            CheckTop.Text = "Always On Top";
            CheckTop.UseVisualStyleBackColor = true;
            CheckTop.CheckedChanged += CheckTop_CheckedChanged;
            // 
            // BtnOpen
            // 
            BtnOpen.Anchor = AnchorStyles.Top;
            BtnOpen.BackColor = Color.Black;
            BtnOpen.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.Location = new Point(599, 279);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(177, 38);
            BtnOpen.TabIndex = 7;
            BtnOpen.Text = "OPEN FILE LOCATION";
            BtnOpen.UseVisualStyleBackColor = false;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnOpen);
            Controls.Add(CheckTop);
            Controls.Add(linkLabel1);
            Controls.Add(checkTemp);
            Controls.Add(checkSound);
            Controls.Add(label4);
            Controls.Add(BtnSwap2);
            Controls.Add(BtnSwap1);
            Controls.Add(label3);
            Controls.Add(btnLinear);
            Controls.Add(btnDifuse);
            Controls.Add(txtLog);
            Controls.Add(btnSelectImage);
            Controls.Add(panelResize);
            Controls.Add(panelUpscale);
            ForeColor = Color.Transparent;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Texture Upscaler";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            panelResize.ResumeLayout(false);
            panelResize.PerformLayout();
            panelUpscale.ResumeLayout(false);
            panelUpscale.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectImage;
        private Button btnResize;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private TextBox txtLog;
        private Button btnDifuse;
        private Button btnLinear;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnUpscale;
        private RadioButton radX2;
        private RadioButton radX3;
        private RadioButton radX4;
        private Button BtnSwap1;
        private Button BtnSwap2;
        private Panel panelResize;
        private Panel panelUpscale;
        private Label label4;
        private CheckBox checkSound;
        private CheckBox checkTemp;
        private LinkLabel linkLabel1;
        private CheckBox CheckTop;
        private Button BtnOpen;
    }
}
