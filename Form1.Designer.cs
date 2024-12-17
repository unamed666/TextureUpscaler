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
            SuspendLayout();
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(167, 24);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(484, 45);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "SELECT FILE (PNG/DDS)";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += BtnSelectImage_Click;
            // 
            // btnResize
            // 
            btnResize.Location = new Point(167, 93);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(177, 23);
            btnResize.TabIndex = 1;
            btnResize.Text = "RESIZE";
            btnResize.UseVisualStyleBackColor = true;
            btnResize.Click += BtnResize_Click;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(405, 94);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(100, 23);
            txtWidth.TabIndex = 2;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(551, 94);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 3;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Bottom;
            txtLog.Location = new Point(0, 324);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(800, 126);
            txtLog.TabIndex = 4;
            txtLog.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDifuse
            // 
            btnDifuse.Location = new Point(180, 254);
            btnDifuse.Name = "btnDifuse";
            btnDifuse.Size = new Size(75, 23);
            btnDifuse.TabIndex = 13;
            btnDifuse.Text = "DIFUSE";
            btnDifuse.Click += BtnDifuse_Click;
            // 
            // btnLinear
            // 
            btnLinear.Location = new Point(324, 254);
            btnLinear.Name = "btnLinear";
            btnLinear.Size = new Size(75, 23);
            btnLinear.TabIndex = 12;
            btnLinear.Text = "LINEAR";
            btnLinear.Click += BtnLinear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(370, 97);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "W =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(516, 97);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 6;
            label2.Text = "H =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 224);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 7;
            label3.Text = "Convert to DDS";
            // 
            // btnUpscale
            // 
            btnUpscale.Location = new Point(167, 150);
            btnUpscale.Name = "btnUpscale";
            btnUpscale.Size = new Size(177, 23);
            btnUpscale.TabIndex = 8;
            btnUpscale.Text = "UPSCALE";
            btnUpscale.UseVisualStyleBackColor = true;
            btnUpscale.Click += BtnUpscale_Click;
            // 
            // radX2
            // 
            radX2.AutoSize = true;
            radX2.Checked = true;
            radX2.Location = new Point(405, 154);
            radX2.Name = "radX2";
            radX2.Size = new Size(38, 19);
            radX2.TabIndex = 9;
            radX2.TabStop = true;
            radX2.Text = "X2";
            radX2.UseVisualStyleBackColor = true;
            radX2.CheckedChanged += RadX2_CheckedChanged;
            // 
            // radX3
            // 
            radX3.AutoSize = true;
            radX3.Location = new Point(505, 154);
            radX3.Name = "radX3";
            radX3.Size = new Size(38, 19);
            radX3.TabIndex = 10;
            radX3.TabStop = true;
            radX3.Text = "X3";
            radX3.UseVisualStyleBackColor = true;
            radX3.CheckedChanged += RadX3_CheckedChanged;
            // 
            // radX4
            // 
            radX4.AutoSize = true;
            radX4.Location = new Point(613, 154);
            radX4.Name = "radX4";
            radX4.Size = new Size(38, 19);
            radX4.TabIndex = 11;
            radX4.TabStop = true;
            radX4.Text = "X4";
            radX4.UseVisualStyleBackColor = true;
            radX4.CheckedChanged += RadX4_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radX4);
            Controls.Add(radX3);
            Controls.Add(radX2);
            Controls.Add(btnUpscale);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLinear);
            Controls.Add(btnDifuse);
            Controls.Add(txtLog);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(btnResize);
            Controls.Add(btnSelectImage);
            Name = "Form1";
            Text = "Form1";
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
    }
}
