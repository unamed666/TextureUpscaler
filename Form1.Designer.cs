using System;
using System.Windows.Forms;
using System.Drawing;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnDifuse = new System.Windows.Forms.Button();
            this.btnLinear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpscale = new System.Windows.Forms.Button();
            this.radX2 = new System.Windows.Forms.RadioButton();
            this.radX3 = new System.Windows.Forms.RadioButton();
            this.radX4 = new System.Windows.Forms.RadioButton();
            this.BtnSwap1 = new System.Windows.Forms.Button();
            this.BtnSwap2 = new System.Windows.Forms.Button();
            this.panelResize = new System.Windows.Forms.Panel();
            this.BtnOpen2 = new System.Windows.Forms.Button();
            this.panelUpscale = new System.Windows.Forms.Panel();
            this.btnDifuse2 = new System.Windows.Forms.Button();
            this.BtnOpen3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLinear2 = new System.Windows.Forms.Button();
            this.btnSelectImage2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkSound = new System.Windows.Forms.CheckBox();
            this.checkTemp = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkTop = new System.Windows.Forms.CheckBox();
            this.BtnSwap3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtData = new System.Windows.Forms.TextBox();
            this.radX3A = new System.Windows.Forms.RadioButton();
            this.radX4A = new System.Windows.Forms.RadioButton();
            this.radX2A = new System.Windows.Forms.RadioButton();
            this.btnUpscale2 = new System.Windows.Forms.Button();
            this.btnDifuse3 = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnLinear3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnOpen1 = new System.Windows.Forms.Button();
            this.pngCheck = new System.Windows.Forms.CheckBox();
            this.panelBatch = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.SRGBcheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelResize.SuspendLayout();
            this.panelUpscale.SuspendLayout();
            this.panelBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectImage.BackColor = System.Drawing.Color.Black;
            this.btnSelectImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelectImage.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelectImage.Location = new System.Drawing.Point(14, 16);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(214, 39);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "SELECT FILE (PNG/DDS)";
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.BtnSelectImage_Click);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.BackColor = System.Drawing.Color.Black;
            this.btnResize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.ForeColor = System.Drawing.Color.Transparent;
            this.btnResize.Location = new System.Drawing.Point(14, 78);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(214, 33);
            this.btnResize.TabIndex = 1;
            this.btnResize.Text = "RESIZE";
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.BtnResize_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtWidth.Location = new System.Drawing.Point(467, 62);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(199, 27);
            this.txtWidth.TabIndex = 2;
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHeight.Location = new System.Drawing.Point(467, 94);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(199, 27);
            this.txtHeight.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Yellow;
            this.txtLog.Location = new System.Drawing.Point(215, 390);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(490, 150);
            this.txtLog.TabIndex = 4;
            this.txtLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDifuse
            // 
            this.btnDifuse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDifuse.BackColor = System.Drawing.Color.Black;
            this.btnDifuse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnDifuse.ForeColor = System.Drawing.Color.Transparent;
            this.btnDifuse.Location = new System.Drawing.Point(128, 131);
            this.btnDifuse.Name = "btnDifuse";
            this.btnDifuse.Size = new System.Drawing.Size(100, 33);
            this.btnDifuse.TabIndex = 13;
            this.btnDifuse.Text = "SRGB ";
            this.toolTip1.SetToolTip(this.btnDifuse, "Difuse");
            this.btnDifuse.UseVisualStyleBackColor = false;
            this.btnDifuse.Click += new System.EventHandler(this.BtnDifuse_Click);
            // 
            // btnLinear
            // 
            this.btnLinear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLinear.BackColor = System.Drawing.Color.Black;
            this.btnLinear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLinear.ForeColor = System.Drawing.Color.Transparent;
            this.btnLinear.Location = new System.Drawing.Point(246, 131);
            this.btnLinear.Name = "btnLinear";
            this.btnLinear.Size = new System.Drawing.Size(99, 33);
            this.btnLinear.TabIndex = 12;
            this.btnLinear.Text = "LINEAR";
            this.toolTip1.SetToolTip(this.btnLinear, "Lightmap, etc");
            this.btnLinear.UseVisualStyleBackColor = false;
            this.btnLinear.Click += new System.EventHandler(this.BtnLinear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(405, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width =";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(402, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height =";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Convert to DDS :";
            // 
            // btnUpscale
            // 
            this.btnUpscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpscale.BackColor = System.Drawing.Color.Black;
            this.btnUpscale.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpscale.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpscale.Location = new System.Drawing.Point(14, 78);
            this.btnUpscale.Name = "btnUpscale";
            this.btnUpscale.Size = new System.Drawing.Size(214, 33);
            this.btnUpscale.TabIndex = 8;
            this.btnUpscale.Text = "UPSCALE";
            this.btnUpscale.UseVisualStyleBackColor = false;
            this.btnUpscale.Click += new System.EventHandler(this.BtnUpscale_Click);
            // 
            // radX2
            // 
            this.radX2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX2.AutoSize = true;
            this.radX2.BackColor = System.Drawing.Color.Black;
            this.radX2.Checked = true;
            this.radX2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX2.ForeColor = System.Drawing.Color.Transparent;
            this.radX2.Location = new System.Drawing.Point(405, 85);
            this.radX2.Name = "radX2";
            this.radX2.Size = new System.Drawing.Size(51, 26);
            this.radX2.TabIndex = 9;
            this.radX2.TabStop = true;
            this.radX2.Text = "X2";
            this.radX2.UseVisualStyleBackColor = false;
            this.radX2.CheckedChanged += new System.EventHandler(this.RadX2_CheckedChanged);
            // 
            // radX3
            // 
            this.radX3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX3.AutoSize = true;
            this.radX3.BackColor = System.Drawing.Color.Black;
            this.radX3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX3.ForeColor = System.Drawing.Color.Transparent;
            this.radX3.Location = new System.Drawing.Point(490, 85);
            this.radX3.Name = "radX3";
            this.radX3.Size = new System.Drawing.Size(51, 26);
            this.radX3.TabIndex = 10;
            this.radX3.TabStop = true;
            this.radX3.Text = "X3";
            this.radX3.UseVisualStyleBackColor = false;
            this.radX3.CheckedChanged += new System.EventHandler(this.RadX3_CheckedChanged);
            // 
            // radX4
            // 
            this.radX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX4.AutoSize = true;
            this.radX4.BackColor = System.Drawing.Color.Black;
            this.radX4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX4.ForeColor = System.Drawing.Color.Transparent;
            this.radX4.Location = new System.Drawing.Point(583, 85);
            this.radX4.Name = "radX4";
            this.radX4.Size = new System.Drawing.Size(51, 26);
            this.radX4.TabIndex = 11;
            this.radX4.TabStop = true;
            this.radX4.Text = "X4";
            this.radX4.UseVisualStyleBackColor = false;
            this.radX4.CheckedChanged += new System.EventHandler(this.RadX4_CheckedChanged);
            // 
            // BtnSwap1
            // 
            this.BtnSwap1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSwap1.BackColor = System.Drawing.Color.Black;
            this.BtnSwap1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.BtnSwap1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSwap1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSwap1.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSwap1.Location = new System.Drawing.Point(327, 101);
            this.BtnSwap1.Name = "BtnSwap1";
            this.BtnSwap1.Size = new System.Drawing.Size(97, 39);
            this.BtnSwap1.TabIndex = 14;
            this.BtnSwap1.Text = "RESIZE";
            this.BtnSwap1.UseVisualStyleBackColor = false;
            this.BtnSwap1.Click += new System.EventHandler(this.BtnSwap1_Click);
            // 
            // BtnSwap2
            // 
            this.BtnSwap2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSwap2.BackColor = System.Drawing.Color.Black;
            this.BtnSwap2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.BtnSwap2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSwap2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSwap2.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSwap2.Location = new System.Drawing.Point(429, 101);
            this.BtnSwap2.Name = "BtnSwap2";
            this.BtnSwap2.Size = new System.Drawing.Size(116, 39);
            this.BtnSwap2.TabIndex = 15;
            this.BtnSwap2.Text = "UPSCALE";
            this.BtnSwap2.UseVisualStyleBackColor = false;
            this.BtnSwap2.Click += new System.EventHandler(this.BtnSwap2_Click);
            // 
            // panelResize
            // 
            this.panelResize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelResize.Controls.Add(this.BtnOpen2);
            this.panelResize.Controls.Add(this.btnSelectImage);
            this.panelResize.Controls.Add(this.btnResize);
            this.panelResize.Controls.Add(this.txtWidth);
            this.panelResize.Controls.Add(this.txtHeight);
            this.panelResize.Controls.Add(this.label1);
            this.panelResize.Controls.Add(this.label2);
            this.panelResize.Controls.Add(this.btnDifuse);
            this.panelResize.Controls.Add(this.btnLinear);
            this.panelResize.Controls.Add(this.label3);
            this.panelResize.Location = new System.Drawing.Point(0, 146);
            this.panelResize.Name = "panelResize";
            this.panelResize.Size = new System.Drawing.Size(684, 223);
            this.panelResize.TabIndex = 16;
            // 
            // BtnOpen2
            // 
            this.BtnOpen2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOpen2.BackColor = System.Drawing.Color.Black;
            this.BtnOpen2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpen2.ForeColor = System.Drawing.Color.Transparent;
            this.BtnOpen2.Location = new System.Drawing.Point(490, 182);
            this.BtnOpen2.Name = "BtnOpen2";
            this.BtnOpen2.Size = new System.Drawing.Size(175, 33);
            this.BtnOpen2.TabIndex = 25;
            this.BtnOpen2.Text = "OPEN FILE LOCATION";
            this.BtnOpen2.UseVisualStyleBackColor = false;
            this.BtnOpen2.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // panelUpscale
            // 
            this.panelUpscale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelUpscale.Controls.Add(this.btnDifuse2);
            this.panelUpscale.Controls.Add(this.BtnOpen3);
            this.panelUpscale.Controls.Add(this.label5);
            this.panelUpscale.Controls.Add(this.btnLinear2);
            this.panelUpscale.Controls.Add(this.btnSelectImage2);
            this.panelUpscale.Controls.Add(this.btnUpscale);
            this.panelUpscale.Controls.Add(this.radX2);
            this.panelUpscale.Controls.Add(this.radX4);
            this.panelUpscale.Controls.Add(this.radX3);
            this.panelUpscale.Location = new System.Drawing.Point(0, 146);
            this.panelUpscale.Name = "panelUpscale";
            this.panelUpscale.Size = new System.Drawing.Size(684, 223);
            this.panelUpscale.TabIndex = 7;
            // 
            // btnDifuse2
            // 
            this.btnDifuse2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDifuse2.BackColor = System.Drawing.Color.Black;
            this.btnDifuse2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnDifuse2.ForeColor = System.Drawing.Color.Transparent;
            this.btnDifuse2.Location = new System.Drawing.Point(128, 131);
            this.btnDifuse2.Name = "btnDifuse2";
            this.btnDifuse2.Size = new System.Drawing.Size(100, 33);
            this.btnDifuse2.TabIndex = 25;
            this.btnDifuse2.Text = "SRGB ";
            this.toolTip1.SetToolTip(this.btnDifuse2, "Difuse");
            this.btnDifuse2.UseVisualStyleBackColor = false;
            this.btnDifuse2.Click += new System.EventHandler(this.BtnDifuse_Click);
            // 
            // BtnOpen3
            // 
            this.BtnOpen3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOpen3.BackColor = System.Drawing.Color.Black;
            this.BtnOpen3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpen3.ForeColor = System.Drawing.Color.Transparent;
            this.BtnOpen3.Location = new System.Drawing.Point(490, 182);
            this.BtnOpen3.Name = "BtnOpen3";
            this.BtnOpen3.Size = new System.Drawing.Size(175, 33);
            this.BtnOpen3.TabIndex = 25;
            this.BtnOpen3.Text = "OPEN FILE LOCATION";
            this.BtnOpen3.UseVisualStyleBackColor = false;
            this.BtnOpen3.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(14, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "Convert to DDS :";
            // 
            // btnLinear2
            // 
            this.btnLinear2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLinear2.BackColor = System.Drawing.Color.Black;
            this.btnLinear2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLinear2.ForeColor = System.Drawing.Color.Transparent;
            this.btnLinear2.Location = new System.Drawing.Point(246, 131);
            this.btnLinear2.Name = "btnLinear2";
            this.btnLinear2.Size = new System.Drawing.Size(99, 33);
            this.btnLinear2.TabIndex = 24;
            this.btnLinear2.Text = "LINEAR";
            this.toolTip1.SetToolTip(this.btnLinear2, "Lightmap, etc");
            this.btnLinear2.UseVisualStyleBackColor = false;
            this.btnLinear2.Click += new System.EventHandler(this.BtnLinear_Click);
            // 
            // btnSelectImage2
            // 
            this.btnSelectImage2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectImage2.BackColor = System.Drawing.Color.Black;
            this.btnSelectImage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelectImage2.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelectImage2.Location = new System.Drawing.Point(14, 16);
            this.btnSelectImage2.Name = "btnSelectImage2";
            this.btnSelectImage2.Size = new System.Drawing.Size(214, 39);
            this.btnSelectImage2.TabIndex = 26;
            this.btnSelectImage2.Text = "SELECT FILE (PNG/DDS)";
            this.btnSelectImage2.UseVisualStyleBackColor = false;
            this.btnSelectImage2.Click += new System.EventHandler(this.BtnSelectImage_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(224, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 45);
            this.label4.TabIndex = 17;
            this.label4.Text = "Texture Upscaler";
            // 
            // checkSound
            // 
            this.checkSound.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkSound.AutoSize = true;
            this.checkSound.Checked = true;
            this.checkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSound.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.checkSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkSound.ForeColor = System.Drawing.Color.Lime;
            this.checkSound.Location = new System.Drawing.Point(9, 21);
            this.checkSound.Name = "checkSound";
            this.checkSound.Size = new System.Drawing.Size(55, 17);
            this.checkSound.TabIndex = 18;
            this.checkSound.Text = "Sound";
            this.checkSound.UseVisualStyleBackColor = true;
            this.checkSound.CheckedChanged += new System.EventHandler(this.checkSound_CheckedChanged);
            // 
            // checkTemp
            // 
            this.checkTemp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkTemp.AutoSize = true;
            this.checkTemp.Checked = true;
            this.checkTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTemp.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.checkTemp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkTemp.ForeColor = System.Drawing.Color.Lime;
            this.checkTemp.Location = new System.Drawing.Point(9, 42);
            this.checkTemp.Name = "checkTemp";
            this.checkTemp.Size = new System.Drawing.Size(134, 17);
            this.checkTemp.TabIndex = 19;
            this.checkTemp.Text = "Save Temporary Image";
            this.checkTemp.UseVisualStyleBackColor = true;
            this.checkTemp.CheckedChanged += new System.EventHandler(this.checkTemp_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(580, 24);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(90, 13);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By: UNAMED666";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkTop
            // 
            this.checkTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkTop.AutoSize = true;
            this.checkTop.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.checkTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkTop.ForeColor = System.Drawing.Color.Lime;
            this.checkTop.Location = new System.Drawing.Point(9, 64);
            this.checkTop.Name = "checkTop";
            this.checkTop.Size = new System.Drawing.Size(96, 17);
            this.checkTop.TabIndex = 21;
            this.checkTop.Text = "Always On Top";
            this.checkTop.UseVisualStyleBackColor = true;
            this.checkTop.CheckedChanged += new System.EventHandler(this.CheckTop_CheckedChanged);
            // 
            // BtnSwap3
            // 
            this.BtnSwap3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSwap3.BackColor = System.Drawing.Color.Black;
            this.BtnSwap3.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.BtnSwap3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSwap3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSwap3.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSwap3.Location = new System.Drawing.Point(549, 101);
            this.BtnSwap3.Name = "BtnSwap3";
            this.BtnSwap3.Size = new System.Drawing.Size(116, 39);
            this.BtnSwap3.TabIndex = 22;
            this.BtnSwap3.Text = "BATCH";
            this.BtnSwap3.UseVisualStyleBackColor = false;
            this.BtnSwap3.Click += new System.EventHandler(this.BtnSwap3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "7"});
            this.comboBox1.Location = new System.Drawing.Point(57, 326);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(52, 24);
            this.comboBox1.TabIndex = 24;
            this.toolTip1.SetToolTip(this.comboBox1, "BC 1-3 = DX9+ game\r\nBC 7     = DX11+ game\r\n\r\nThis is just an overview and may not" +
        " always be accurate. Check your game forum to prevent conversion errors\r\n");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(14, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "BC :";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtData.BackColor = System.Drawing.Color.Black;
            this.txtData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.ForeColor = System.Drawing.Color.Yellow;
            this.txtData.Location = new System.Drawing.Point(-6, 390);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(240, 150);
            this.txtData.TabIndex = 28;
            this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radX3A
            // 
            this.radX3A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX3A.AutoSize = true;
            this.radX3A.BackColor = System.Drawing.Color.Black;
            this.radX3A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX3A.ForeColor = System.Drawing.Color.Transparent;
            this.radX3A.Location = new System.Drawing.Point(490, 85);
            this.radX3A.Name = "radX3A";
            this.radX3A.Size = new System.Drawing.Size(51, 26);
            this.radX3A.TabIndex = 10;
            this.radX3A.TabStop = true;
            this.radX3A.Text = "X3";
            this.radX3A.UseVisualStyleBackColor = false;
            this.radX3A.CheckedChanged += new System.EventHandler(this.RadX3_CheckedChanged);
            // 
            // radX4A
            // 
            this.radX4A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX4A.AutoSize = true;
            this.radX4A.BackColor = System.Drawing.Color.Black;
            this.radX4A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX4A.ForeColor = System.Drawing.Color.Transparent;
            this.radX4A.Location = new System.Drawing.Point(583, 85);
            this.radX4A.Name = "radX4A";
            this.radX4A.Size = new System.Drawing.Size(51, 26);
            this.radX4A.TabIndex = 11;
            this.radX4A.TabStop = true;
            this.radX4A.Text = "X4";
            this.radX4A.UseVisualStyleBackColor = false;
            this.radX4A.CheckedChanged += new System.EventHandler(this.RadX4_CheckedChanged);
            // 
            // radX2A
            // 
            this.radX2A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radX2A.AutoSize = true;
            this.radX2A.BackColor = System.Drawing.Color.Black;
            this.radX2A.Checked = true;
            this.radX2A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.radX2A.ForeColor = System.Drawing.Color.Transparent;
            this.radX2A.Location = new System.Drawing.Point(405, 85);
            this.radX2A.Name = "radX2A";
            this.radX2A.Size = new System.Drawing.Size(51, 26);
            this.radX2A.TabIndex = 9;
            this.radX2A.TabStop = true;
            this.radX2A.Text = "X2";
            this.radX2A.UseVisualStyleBackColor = false;
            this.radX2A.CheckedChanged += new System.EventHandler(this.RadX2_CheckedChanged);
            // 
            // btnUpscale2
            // 
            this.btnUpscale2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpscale2.BackColor = System.Drawing.Color.Black;
            this.btnUpscale2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpscale2.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpscale2.Location = new System.Drawing.Point(14, 78);
            this.btnUpscale2.Name = "btnUpscale2";
            this.btnUpscale2.Size = new System.Drawing.Size(214, 33);
            this.btnUpscale2.TabIndex = 8;
            this.btnUpscale2.Text = "BATCH UPSCALE";
            this.btnUpscale2.UseVisualStyleBackColor = false;
            this.btnUpscale2.Click += new System.EventHandler(this.btnUpscale2_Click);
            // 
            // btnDifuse3
            // 
            this.btnDifuse3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDifuse3.BackColor = System.Drawing.Color.Black;
            this.btnDifuse3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnDifuse3.ForeColor = System.Drawing.Color.Transparent;
            this.btnDifuse3.Location = new System.Drawing.Point(128, 131);
            this.btnDifuse3.Name = "btnDifuse3";
            this.btnDifuse3.Size = new System.Drawing.Size(100, 33);
            this.btnDifuse3.TabIndex = 25;
            this.btnDifuse3.Text = "SRGB ";
            this.toolTip1.SetToolTip(this.btnDifuse3, "Difuse");
            this.btnDifuse3.UseVisualStyleBackColor = false;
            this.btnDifuse3.Click += new System.EventHandler(this.btnDifuse3_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectFolder.BackColor = System.Drawing.Color.Black;
            this.btnSelectFolder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelectFolder.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelectFolder.Location = new System.Drawing.Point(14, 16);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(214, 39);
            this.btnSelectFolder.TabIndex = 26;
            this.btnSelectFolder.Text = "SELECT FOLDER";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnLinear3
            // 
            this.btnLinear3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLinear3.BackColor = System.Drawing.Color.Black;
            this.btnLinear3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLinear3.ForeColor = System.Drawing.Color.Transparent;
            this.btnLinear3.Location = new System.Drawing.Point(246, 131);
            this.btnLinear3.Name = "btnLinear3";
            this.btnLinear3.Size = new System.Drawing.Size(99, 33);
            this.btnLinear3.TabIndex = 24;
            this.btnLinear3.Text = "LINEAR";
            this.toolTip1.SetToolTip(this.btnLinear3, "Lightmap, etc");
            this.btnLinear3.UseVisualStyleBackColor = false;
            this.btnLinear3.Click += new System.EventHandler(this.btnLinear3_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(14, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Convert to DDS :";
            // 
            // BtnOpen1
            // 
            this.BtnOpen1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOpen1.BackColor = System.Drawing.Color.Black;
            this.BtnOpen1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpen1.ForeColor = System.Drawing.Color.Transparent;
            this.BtnOpen1.Location = new System.Drawing.Point(490, 182);
            this.BtnOpen1.Name = "BtnOpen1";
            this.BtnOpen1.Size = new System.Drawing.Size(175, 33);
            this.BtnOpen1.TabIndex = 24;
            this.BtnOpen1.Text = "OPEN FOLDER LOCATION";
            this.BtnOpen1.UseVisualStyleBackColor = false;
            this.BtnOpen1.Click += new System.EventHandler(this.BtnOpen1_Click);
            // 
            // pngCheck
            // 
            this.pngCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pngCheck.AutoSize = true;
            this.pngCheck.BackColor = System.Drawing.Color.Black;
            this.pngCheck.Checked = true;
            this.pngCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pngCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pngCheck.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pngCheck.ForeColor = System.Drawing.Color.Lime;
            this.pngCheck.Location = new System.Drawing.Point(237, 183);
            this.pngCheck.Name = "pngCheck";
            this.pngCheck.Size = new System.Drawing.Size(12, 11);
            this.pngCheck.TabIndex = 24;
            this.pngCheck.UseVisualStyleBackColor = false;
            this.pngCheck.CheckedChanged += new System.EventHandler(this.pngCheck_CheckedChanged);
            // 
            // panelBatch
            // 
            this.panelBatch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBatch.BackColor = System.Drawing.Color.Transparent;
            this.panelBatch.Controls.Add(this.label9);
            this.panelBatch.Controls.Add(this.btnDifuse3);
            this.panelBatch.Controls.Add(this.pngCheck);
            this.panelBatch.Controls.Add(this.BtnOpen1);
            this.panelBatch.Controls.Add(this.label6);
            this.panelBatch.Controls.Add(this.btnLinear3);
            this.panelBatch.Controls.Add(this.btnSelectFolder);
            this.panelBatch.Controls.Add(this.btnUpscale2);
            this.panelBatch.Controls.Add(this.radX2A);
            this.panelBatch.Controls.Add(this.radX4A);
            this.panelBatch.Controls.Add(this.radX3A);
            this.panelBatch.Location = new System.Drawing.Point(0, 146);
            this.panelBatch.Name = "panelBatch";
            this.panelBatch.Size = new System.Drawing.Size(684, 223);
            this.panelBatch.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(124, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "Save PNG Files";
            // 
            // SRGBcheck
            // 
            this.SRGBcheck.AutoSize = true;
            this.SRGBcheck.BackColor = System.Drawing.Color.Black;
            this.SRGBcheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SRGBcheck.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.SRGBcheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SRGBcheck.ForeColor = System.Drawing.Color.Yellow;
            this.SRGBcheck.Location = new System.Drawing.Point(320, 235);
            this.SRGBcheck.Name = "SRGBcheck";
            this.SRGBcheck.Size = new System.Drawing.Size(12, 11);
            this.SRGBcheck.TabIndex = 29;
            this.toolTip1.SetToolTip(this.SRGBcheck, "Check the left LOG for more info");
            this.SRGBcheck.UseVisualStyleBackColor = false;
            this.SRGBcheck.CheckedChanged += new System.EventHandler(this.SRGBcheck_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(247, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "SRGB Status";
            this.toolTip1.SetToolTip(this.label8, "Check the left LOG for more info");
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Black;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(246, 172);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(420, 21);
            this.txtName.TabIndex = 31;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(686, 534);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SRGBcheck);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnSwap3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkTop);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkTemp);
            this.Controls.Add(this.checkSound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSwap2);
            this.Controls.Add(this.BtnSwap1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panelResize);
            this.Controls.Add(this.panelUpscale);
            this.Controls.Add(this.panelBatch);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Texture Upscaler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panelResize.ResumeLayout(false);
            this.panelResize.PerformLayout();
            this.panelUpscale.ResumeLayout(false);
            this.panelUpscale.PerformLayout();
            this.panelBatch.ResumeLayout(false);
            this.panelBatch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private CheckBox checkTop;
        private Button BtnSwap3;
        private Label label5;
        private Button btnLinear2;
        private Button btnSelectImage2;
        private Button btnDifuse2;
        private Button BtnOpen2;
        private Button BtnOpen3;
        private ComboBox comboBox1;
        private Label label7;
        private ToolTip toolTip1;
        private TextBox txtData;
        private RadioButton radX3A;
        private RadioButton radX4A;
        private RadioButton radX2A;
        private Button btnUpscale2;
        private Button btnDifuse3;
        private Button btnSelectFolder;
        private Button btnLinear3;
        private Label label6;
        private Button BtnOpen1;
        private CheckBox pngCheck;
        private Panel panelBatch;
        private CheckBox SRGBcheck;
        private Label label8;
        private TextBox txtName;
        private Label label9;
    }
}
