namespace Editor
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.Tss1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tss2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tss3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tmrLogin = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdProject = new System.Windows.Forms.RadioButton();
            this.rdSeqV = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rdPassword = new System.Windows.Forms.RadioButton();
            this.rdFormat = new System.Windows.Forms.RadioButton();
            this.rdSeqC = new System.Windows.Forms.RadioButton();
            this.rdLimit = new System.Windows.Forms.RadioButton();
            this.rdEngine = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tss1,
            this.Tss2,
            this.Tss3,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 714);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1370, 35);
            this.statusStrip.TabIndex = 2;
            // 
            // Tss1
            // 
            this.Tss1.AutoSize = false;
            this.Tss1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Tss1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.Tss1.Name = "Tss1";
            this.Tss1.Size = new System.Drawing.Size(500, 30);
            this.Tss1.Text = "*******";
            // 
            // Tss2
            // 
            this.Tss2.AutoSize = false;
            this.Tss2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Tss2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.Tss2.Name = "Tss2";
            this.Tss2.Size = new System.Drawing.Size(200, 30);
            this.Tss2.Text = "DDMMYYY";
            // 
            // Tss3
            // 
            this.Tss3.AutoSize = false;
            this.Tss3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Tss3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.Tss3.Name = "Tss3";
            this.Tss3.Size = new System.Drawing.Size(200, 30);
            this.Tss3.Text = "File Name";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 30);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tmrLogin
            // 
            this.tmrLogin.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.rdProject);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rdSeqV);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.rdPassword);
            this.panel1.Controls.Add(this.rdFormat);
            this.panel1.Controls.Add(this.rdSeqC);
            this.panel1.Controls.Add(this.rdLimit);
            this.panel1.Controls.Add(this.rdEngine);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(289, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 478);
            this.panel1.TabIndex = 14;
            // 
            // rdProject
            // 
            this.rdProject.BackColor = System.Drawing.Color.SteelBlue;
            this.rdProject.Checked = true;
            this.rdProject.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdProject.ForeColor = System.Drawing.Color.White;
            this.rdProject.Location = new System.Drawing.Point(27, 108);
            this.rdProject.Name = "rdProject";
            this.rdProject.Size = new System.Drawing.Size(402, 30);
            this.rdProject.TabIndex = 10;
            this.rdProject.TabStop = true;
            this.rdProject.Text = "Create/ Update Project  Files . . . . . . . ";
            this.rdProject.UseVisualStyleBackColor = false;
            this.rdProject.CheckedChanged += new System.EventHandler(this.rdPassNorms_CheckedChanged);
            // 
            // rdSeqV
            // 
            this.rdSeqV.BackColor = System.Drawing.Color.SteelBlue;
            this.rdSeqV.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeqV.ForeColor = System.Drawing.Color.White;
            this.rdSeqV.Location = new System.Drawing.Point(191, 312);
            this.rdSeqV.Name = "rdSeqV";
            this.rdSeqV.Size = new System.Drawing.Size(238, 30);
            this.rdSeqV.TabIndex = 8;
            this.rdSeqV.Text = "Variable Speed Engine . . . . . . . ";
            this.rdSeqV.UseVisualStyleBackColor = false;
            this.rdSeqV.CheckedChanged += new System.EventHandler(this.rdSeqV_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(461, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Silver;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOpen.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.Navy;
            this.btnOpen.Location = new System.Drawing.Point(461, 190);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(103, 39);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // rdPassword
            // 
            this.rdPassword.BackColor = System.Drawing.Color.SteelBlue;
            this.rdPassword.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPassword.ForeColor = System.Drawing.Color.White;
            this.rdPassword.Location = new System.Drawing.Point(27, 414);
            this.rdPassword.Name = "rdPassword";
            this.rdPassword.Size = new System.Drawing.Size(402, 30);
            this.rdPassword.TabIndex = 5;
            this.rdPassword.Text = "Change PassWord Files . . . . . . . ";
            this.rdPassword.UseVisualStyleBackColor = false;
            this.rdPassword.CheckedChanged += new System.EventHandler(this.rdPassword_CheckedChanged);
            // 
            // rdFormat
            // 
            this.rdFormat.BackColor = System.Drawing.Color.SteelBlue;
            this.rdFormat.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFormat.ForeColor = System.Drawing.Color.White;
            this.rdFormat.Location = new System.Drawing.Point(27, 363);
            this.rdFormat.Name = "rdFormat";
            this.rdFormat.Size = new System.Drawing.Size(402, 30);
            this.rdFormat.TabIndex = 4;
            this.rdFormat.Text = "Display Format Files . . . . . . . ";
            this.rdFormat.UseVisualStyleBackColor = false;
            this.rdFormat.CheckedChanged += new System.EventHandler(this.rdFormat_CheckedChanged);
            // 
            // rdSeqC
            // 
            this.rdSeqC.BackColor = System.Drawing.Color.SteelBlue;
            this.rdSeqC.Enabled = false;
            this.rdSeqC.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeqC.ForeColor = System.Drawing.Color.White;
            this.rdSeqC.Location = new System.Drawing.Point(191, 261);
            this.rdSeqC.Name = "rdSeqC";
            this.rdSeqC.Size = new System.Drawing.Size(238, 30);
            this.rdSeqC.TabIndex = 3;
            this.rdSeqC.Text = " Constant Speed Engine . . . . . . . ";
            this.rdSeqC.UseVisualStyleBackColor = false;
            this.rdSeqC.CheckedChanged += new System.EventHandler(this.rdSeqC_CheckedChanged);
            // 
            // rdLimit
            // 
            this.rdLimit.BackColor = System.Drawing.Color.SteelBlue;
            this.rdLimit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLimit.ForeColor = System.Drawing.Color.White;
            this.rdLimit.Location = new System.Drawing.Point(27, 210);
            this.rdLimit.Name = "rdLimit";
            this.rdLimit.Size = new System.Drawing.Size(402, 30);
            this.rdLimit.TabIndex = 2;
            this.rdLimit.Text = "Limit Parameter Files . . . . . . . ";
            this.rdLimit.UseVisualStyleBackColor = false;
            this.rdLimit.CheckedChanged += new System.EventHandler(this.rdLimit_CheckedChanged);
            // 
            // rdEngine
            // 
            this.rdEngine.BackColor = System.Drawing.Color.SteelBlue;
            this.rdEngine.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdEngine.ForeColor = System.Drawing.Color.White;
            this.rdEngine.Location = new System.Drawing.Point(27, 159);
            this.rdEngine.Name = "rdEngine";
            this.rdEngine.Size = new System.Drawing.Size(402, 30);
            this.rdEngine.TabIndex = 1;
            this.rdEngine.Text = "Engine Details Files . . . . . . . ";
            this.rdEngine.UseVisualStyleBackColor = false;
            this.rdEngine.CheckedChanged += new System.EventHandler(this.rdEngine_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.BlueViolet;
            this.label1.Location = new System.Drawing.Point(26, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open Editor :\r\n                        >  Edit Existing File \r\n\r\n                " +
    "        >  Create New File\r\n";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.BlueViolet;
            this.label2.Location = new System.Drawing.Point(24, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Test Program file :";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIParent";
            this.Text = "EDAC - Editors";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.Shown += new System.EventHandler(this.MDIParent_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Tss1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer tmrLogin;
        private System.Windows.Forms.ToolStripStatusLabel Tss2;
        private System.Windows.Forms.ToolStripStatusLabel Tss3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RadioButton rdPassword;
        private System.Windows.Forms.RadioButton rdFormat;
        private System.Windows.Forms.RadioButton rdSeqC;
        private System.Windows.Forms.RadioButton rdLimit;
        private System.Windows.Forms.RadioButton rdEngine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdSeqV;
        private System.Windows.Forms.RadioButton rdProject;
        private System.Windows.Forms.Label label2;
    }
}



