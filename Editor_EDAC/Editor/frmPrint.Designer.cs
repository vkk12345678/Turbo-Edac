namespace Editor
{
    partial class frmPrint
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.DataGrid = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnhelp = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnNotProg = new System.Windows.Forms.Button();
			this.PrnDataGrid = new System.Windows.Forms.DataGridView();
			this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnClose = new System.Windows.Forms.Button();
			this.cmbPrint = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PrnDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGrid
			// 
			this.DataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
			this.DataGrid.GridColor = System.Drawing.Color.LightGray;
			this.DataGrid.Location = new System.Drawing.Point(114, 87);
			this.DataGrid.MultiSelect = false;
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.RowHeadersVisible = false;
			this.DataGrid.RowTemplate.ReadOnly = true;
			this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DataGrid.Size = new System.Drawing.Size(397, 575);
			this.DataGrid.TabIndex = 24;
			this.DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Pn";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 40;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Parameter Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Unit";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 60;
			// 
			// btnhelp
			// 
			this.btnhelp.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnhelp.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.btnhelp.FlatAppearance.BorderSize = 2;
			this.btnhelp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnhelp.ForeColor = System.Drawing.Color.Green;
			this.btnhelp.Location = new System.Drawing.Point(566, 295);
			this.btnhelp.Name = "btnhelp";
			this.btnhelp.Size = new System.Drawing.Size(107, 33);
			this.btnhelp.TabIndex = 23;
			this.btnhelp.Text = "&Help\r\n";
			this.btnhelp.UseVisualStyleBackColor = false;
			this.btnhelp.Click += new System.EventHandler(this.btnhelp_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Enabled = false;
			this.label3.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.label3.Location = new System.Drawing.Point(679, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 20);
			this.label3.TabIndex = 22;
			this.label3.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label2.Location = new System.Drawing.Point(832, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 20);
			this.label2.TabIndex = 21;
			this.label2.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Enabled = false;
			this.label1.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(757, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "0";
			// 
			// btnNotProg
			// 
			this.btnNotProg.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnNotProg.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.btnNotProg.FlatAppearance.BorderSize = 2;
			this.btnNotProg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNotProg.ForeColor = System.Drawing.Color.Maroon;
			this.btnNotProg.Location = new System.Drawing.Point(567, 347);
			this.btnNotProg.Name = "btnNotProg";
			this.btnNotProg.Size = new System.Drawing.Size(107, 33);
			this.btnNotProg.TabIndex = 19;
			this.btnNotProg.Text = "Not_Prog.";
			this.btnNotProg.UseVisualStyleBackColor = false;
			this.btnNotProg.Click += new System.EventHandler(this.btnNotProg_Click);
			// 
			// PrnDataGrid
			// 
			this.PrnDataGrid.AllowUserToAddRows = false;
			this.PrnDataGrid.AllowUserToDeleteRows = false;
			this.PrnDataGrid.AllowUserToResizeColumns = false;
			this.PrnDataGrid.AllowUserToResizeRows = false;
			this.PrnDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.PrnDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.PrnDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.PrnDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PrnDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn3,
            this.DataGridViewTextBoxColumn4});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.PrnDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
			this.PrnDataGrid.GridColor = System.Drawing.Color.LightGray;
			this.PrnDataGrid.Location = new System.Drawing.Point(769, 81);
			this.PrnDataGrid.MultiSelect = false;
			this.PrnDataGrid.Name = "PrnDataGrid";
			this.PrnDataGrid.RowHeadersVisible = false;
			this.PrnDataGrid.RowHeadersWidth = 4;
			this.PrnDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PrnDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.PrnDataGrid.Size = new System.Drawing.Size(473, 411);
			this.PrnDataGrid.TabIndex = 18;
			this.PrnDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrnDataGrid_CellClick);
			this.PrnDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrnDataGrid_CellContentClick);
			// 
			// DataGridViewTextBoxColumn1
			// 
			this.DataGridViewTextBoxColumn1.HeaderText = "Cn";
			this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
			this.DataGridViewTextBoxColumn1.ReadOnly = true;
			this.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DataGridViewTextBoxColumn1.Width = 40;
			// 
			// DataGridViewTextBoxColumn2
			// 
			this.DataGridViewTextBoxColumn2.HeaderText = "No";
			this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
			this.DataGridViewTextBoxColumn2.ReadOnly = true;
			this.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DataGridViewTextBoxColumn2.Width = 40;
			// 
			// DataGridViewTextBoxColumn3
			// 
			this.DataGridViewTextBoxColumn3.HeaderText = "Parameter Name";
			this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
			this.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DataGridViewTextBoxColumn3.Width = 150;
			// 
			// DataGridViewTextBoxColumn4
			// 
			this.DataGridViewTextBoxColumn4.HeaderText = "Unit";
			this.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
			this.DataGridViewTextBoxColumn4.ReadOnly = true;
			this.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DataGridViewTextBoxColumn4.Width = 60;
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.SystemColors.Control;
			this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.Maroon;
			this.btnClose.Location = new System.Drawing.Point(566, 399);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(107, 33);
			this.btnClose.TabIndex = 17;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// cmbPrint
			// 
			this.cmbPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmbPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPrint.FormattingEnabled = true;
			this.cmbPrint.Items.AddRange(new object[] {
            "01 PM Format",
            "02 Screen Format_Cal",
            "03 Screen Format_Par",
            "04 Performance",
            "05 Endurance",
            "06 Fixed Format",
            "07 View Format",
            "08 FTP Format"});
			this.cmbPrint.Location = new System.Drawing.Point(372, 25);
			this.cmbPrint.Name = "cmbPrint";
			this.cmbPrint.Size = new System.Drawing.Size(185, 27);
			this.cmbPrint.TabIndex = 16;
			this.cmbPrint.SelectedIndexChanged += new System.EventHandler(this.cmbPrint_SelectedIndexChanged);
			// 
			// frmPrint
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1864, 941);
			this.Controls.Add(this.DataGrid);
			this.Controls.Add(this.btnhelp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNotProg);
			this.Controls.Add(this.PrnDataGrid);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.cmbPrint);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Location = new System.Drawing.Point(320, 25);
			this.Name = "frmPrint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Print Formats";
			this.Load += new System.EventHandler(this.frmPrint_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PrnDataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.Button btnhelp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnNotProg;
        internal System.Windows.Forms.DataGridView PrnDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.ComboBox cmbPrint;
    }
}