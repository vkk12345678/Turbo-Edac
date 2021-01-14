namespace Logger
{
    partial class EngDialog1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgEngDetails = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnMSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnASave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rd_standard = new System.Windows.Forms.RadioButton();
            this.rd_smooth = new System.Windows.Forms.RadioButton();
            this.rd_Last = new System.Windows.Forms.RadioButton();
            this.rd_New = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TextBox10 = new System.Windows.Forms.TextBox();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.HzCombo = new System.Windows.Forms.ComboBox();
            this.PrjCombo = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtengineer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtoperator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgEngDetails)).BeginInit();
            this.Panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEngDetails
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEngDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEngDetails.ColumnHeadersHeight = 40;
            this.dgEngDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgEngDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEngDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgEngDetails.EnableHeadersVisualStyles = false;
            this.dgEngDetails.Location = new System.Drawing.Point(19, 12);
            this.dgEngDetails.Name = "dgEngDetails";
            this.dgEngDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgEngDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgEngDetails.Size = new System.Drawing.Size(354, 696);
            this.dgEngDetails.TabIndex = 1;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Parameter Names";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Parameter Details";
            this.Column2.Name = "Column2";
            this.Column2.Width = 160;
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnMSave);
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Controls.Add(this.btnASave);
            this.Panel1.Location = new System.Drawing.Point(531, 573);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(196, 129);
            this.Panel1.TabIndex = 61;
            // 
            // btnMSave
            // 
            this.btnMSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnMSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMSave.Location = new System.Drawing.Point(24, 46);
            this.btnMSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSave.Name = "btnMSave";
            this.btnMSave.Size = new System.Drawing.Size(145, 30);
            this.btnMSave.TabIndex = 3;
            this.btnMSave.Text = "&Start Manual";
            this.btnMSave.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnClose.Location = new System.Drawing.Point(24, 88);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnASave
            // 
            this.btnASave.BackColor = System.Drawing.SystemColors.Control;
            this.btnASave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnASave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnASave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnASave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnASave.Location = new System.Drawing.Point(24, 10);
            this.btnASave.Margin = new System.Windows.Forms.Padding(4);
            this.btnASave.Name = "btnASave";
            this.btnASave.Size = new System.Drawing.Size(145, 28);
            this.btnASave.TabIndex = 1;
            this.btnASave.Text = "&Start Auto";
            this.btnASave.UseVisualStyleBackColor = false;
            this.btnASave.Click += new System.EventHandler(this.btnASave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rd_standard);
            this.groupBox3.Controls.Add(this.rd_smooth);
            this.groupBox3.Location = new System.Drawing.Point(394, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 80);
            this.groupBox3.TabIndex = 441;
            this.groupBox3.TabStop = false;
            // 
            // rd_standard
            // 
            this.rd_standard.AutoSize = true;
            this.rd_standard.BackColor = System.Drawing.Color.Transparent;
            this.rd_standard.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_standard.ForeColor = System.Drawing.Color.Navy;
            this.rd_standard.Location = new System.Drawing.Point(12, 43);
            this.rd_standard.Name = "rd_standard";
            this.rd_standard.Size = new System.Drawing.Size(296, 22);
            this.rd_standard.TabIndex = 437;
            this.rd_standard.Text = "Standard  Mode Change Over ";
            this.rd_standard.UseVisualStyleBackColor = false;
            // 
            // rd_smooth
            // 
            this.rd_smooth.AutoSize = true;
            this.rd_smooth.BackColor = System.Drawing.Color.Transparent;
            this.rd_smooth.Checked = true;
            this.rd_smooth.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_smooth.ForeColor = System.Drawing.Color.Navy;
            this.rd_smooth.Location = new System.Drawing.Point(12, 12);
            this.rd_smooth.Name = "rd_smooth";
            this.rd_smooth.Size = new System.Drawing.Size(256, 22);
            this.rd_smooth.TabIndex = 436;
            this.rd_smooth.TabStop = true;
            this.rd_smooth.Text = "Smoth Mode Change Over ";
            this.rd_smooth.UseVisualStyleBackColor = false;
            // 
            // rd_Last
            // 
            this.rd_Last.AutoSize = true;
            this.rd_Last.BackColor = System.Drawing.Color.Transparent;
            this.rd_Last.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Last.ForeColor = System.Drawing.Color.Navy;
            this.rd_Last.Location = new System.Drawing.Point(12, 47);
            this.rd_Last.Name = "rd_Last";
            this.rd_Last.Size = new System.Drawing.Size(256, 22);
            this.rd_Last.TabIndex = 443;
            this.rd_Last.Text = "Continue with Last File";
            this.rd_Last.UseVisualStyleBackColor = false;
            // 
            // rd_New
            // 
            this.rd_New.AutoSize = true;
            this.rd_New.BackColor = System.Drawing.Color.Transparent;
            this.rd_New.Checked = true;
            this.rd_New.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_New.ForeColor = System.Drawing.Color.Navy;
            this.rd_New.Location = new System.Drawing.Point(12, 19);
            this.rd_New.Name = "rd_New";
            this.rd_New.Size = new System.Drawing.Size(176, 22);
            this.rd_New.TabIndex = 442;
            this.rd_New.TabStop = true;
            this.rd_New.Text = "Create New File";
            this.rd_New.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AllowDrop = true;
            this.checkBox1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBox1.Location = new System.Drawing.Point(463, 48);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(232, 24);
            this.checkBox1.TabIndex = 444;
            this.checkBox1.Text = "Read Smoke Value";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TextBox10
            // 
            this.TextBox10.BackColor = System.Drawing.Color.Silver;
            this.TextBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox10.ForeColor = System.Drawing.Color.Red;
            this.TextBox10.Location = new System.Drawing.Point(645, 13);
            this.TextBox10.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.ReadOnly = true;
            this.TextBox10.Size = new System.Drawing.Size(43, 26);
            this.TextBox10.TabIndex = 448;
            // 
            // txtDt
            // 
            this.txtDt.BackColor = System.Drawing.Color.Silver;
            this.txtDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDt.ForeColor = System.Drawing.Color.Red;
            this.txtDt.Location = new System.Drawing.Point(462, 13);
            this.txtDt.Margin = new System.Windows.Forms.Padding(4);
            this.txtDt.Name = "txtDt";
            this.txtDt.ReadOnly = true;
            this.txtDt.Size = new System.Drawing.Size(99, 26);
            this.txtDt.TabIndex = 447;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label12.Location = new System.Drawing.Point(408, 16);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(47, 18);
            this.Label12.TabIndex = 446;
            this.Label12.Text = "Date :";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label13.Location = new System.Drawing.Point(592, 14);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(45, 18);
            this.Label13.TabIndex = 445;
            this.Label13.Text = "Shift :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(466, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 125);
            this.groupBox1.TabIndex = 449;
            this.groupBox1.TabStop = false;
            // 
            // textBox13
            // 
            this.textBox13.AllowDrop = true;
            this.textBox13.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.ForeColor = System.Drawing.Color.Maroon;
            this.textBox13.Location = new System.Drawing.Point(180, 85);
            this.textBox13.Margin = new System.Windows.Forms.Padding(4);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(54, 27);
            this.textBox13.TabIndex = 465;
            this.textBox13.Text = "150";
            // 
            // textBox8
            // 
            this.textBox8.AllowDrop = true;
            this.textBox8.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Maroon;
            this.textBox8.Location = new System.Drawing.Point(180, 49);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(54, 27);
            this.textBox8.TabIndex = 464;
            this.textBox8.Text = "2800";
            // 
            // textBox7
            // 
            this.textBox7.AllowDrop = true;
            this.textBox7.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.Maroon;
            this.textBox7.Location = new System.Drawing.Point(180, 14);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(54, 27);
            this.textBox7.TabIndex = 463;
            this.textBox7.Text = "750";
            // 
            // label14
            // 
            this.label14.AllowDrop = true;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label14.Location = new System.Drawing.Point(31, 92);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 16);
            this.label14.TabIndex = 462;
            this.label14.Text = "Max. Torque (Nm):";
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(31, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 16);
            this.label10.TabIndex = 461;
            this.label10.Text = "Engine FlyUp RPM:";
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(39, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 460;
            this.label7.Text = "Engine IDle RPM:";
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(383, 350);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 17);
            this.label11.TabIndex = 453;
            this.label11.Text = "Fast Log Int :";
            // 
            // HzCombo
            // 
            this.HzCombo.BackColor = System.Drawing.Color.Teal;
            this.HzCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HzCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HzCombo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HzCombo.ForeColor = System.Drawing.Color.White;
            this.HzCombo.Items.AddRange(new object[] {
            "None",
            "100 Hz",
            "080 Hz",
            "060 Hz",
            "050 Hz",
            "040 Hz",
            "020 Hz",
            "010 Hz",
            "001 Hz"});
            this.HzCombo.Location = new System.Drawing.Point(524, 344);
            this.HzCombo.Name = "HzCombo";
            this.HzCombo.Size = new System.Drawing.Size(205, 27);
            this.HzCombo.TabIndex = 452;
            // 
            // PrjCombo
            // 
            this.PrjCombo.BackColor = System.Drawing.Color.Teal;
            this.PrjCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrjCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PrjCombo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrjCombo.ForeColor = System.Drawing.Color.White;
            this.PrjCombo.Location = new System.Drawing.Point(525, 302);
            this.PrjCombo.Name = "PrjCombo";
            this.PrjCombo.Size = new System.Drawing.Size(204, 27);
            this.PrjCombo.TabIndex = 451;
            // 
            // Label8
            // 
            this.Label8.AllowDrop = true;
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(401, 307);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(116, 17);
            this.Label8.TabIndex = 450;
            this.Label8.Text = "Select Prj :";
            // 
            // ep
            // 
            this.ep.BlinkRate = 200;
            this.ep.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rd_New);
            this.groupBox2.Controls.Add(this.rd_Last);
            this.groupBox2.Location = new System.Drawing.Point(394, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 80);
            this.groupBox2.TabIndex = 454;
            this.groupBox2.TabStop = false;
            // 
            // txtengineer
            // 
            this.txtengineer.AllowDrop = true;
            this.txtengineer.BackColor = System.Drawing.Color.Gainsboro;
            this.txtengineer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtengineer.ForeColor = System.Drawing.Color.Maroon;
            this.txtengineer.Location = new System.Drawing.Point(551, 83);
            this.txtengineer.Margin = new System.Windows.Forms.Padding(4);
            this.txtengineer.Name = "txtengineer";
            this.txtengineer.Size = new System.Drawing.Size(173, 27);
            this.txtengineer.TabIndex = 465;
            this.txtengineer.Text = "Engineer ";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(411, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 464;
            this.label1.Text = "Engineer Name :";
            // 
            // txtoperator
            // 
            this.txtoperator.AllowDrop = true;
            this.txtoperator.BackColor = System.Drawing.Color.Gainsboro;
            this.txtoperator.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoperator.ForeColor = System.Drawing.Color.Maroon;
            this.txtoperator.Location = new System.Drawing.Point(551, 123);
            this.txtoperator.Margin = new System.Windows.Forms.Padding(4);
            this.txtoperator.Name = "txtoperator";
            this.txtoperator.Size = new System.Drawing.Size(173, 27);
            this.txtoperator.TabIndex = 467;
            this.txtoperator.Text = "Operator";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(443, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 466;
            this.label2.Text = "Tested By :";
            // 
            // EngDialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 720);
            this.Controls.Add(this.txtoperator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtengineer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.HzCombo);
            this.Controls.Add(this.PrjCombo);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextBox10);
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.dgEngDetails);
            this.Name = "EngDialog1";
            this.Text = "EngDialog1";
            this.Load += new System.EventHandler(this.EngDialog1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEngDetails)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEngDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnMSave;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnASave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rd_standard;
        private System.Windows.Forms.RadioButton rd_smooth;
        private System.Windows.Forms.RadioButton rd_Last;
        private System.Windows.Forms.RadioButton rd_New;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.TextBox TextBox10;
        internal System.Windows.Forms.TextBox txtDt;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label13;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox textBox13;
        internal System.Windows.Forms.TextBox textBox8;
        internal System.Windows.Forms.TextBox textBox7;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox HzCombo;
        private System.Windows.Forms.ComboBox PrjCombo;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txtoperator;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtengineer;
        internal System.Windows.Forms.Label label1;
    }
}