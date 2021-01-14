namespace Editor
{
    partial class frmEngine
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.DataGrid = new System.Windows.Forms.DataGridView();
			this.EngGView = new System.Windows.Forms.DataGridView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuLabel = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.Erp = new System.Windows.Forms.ErrorProvider(this.components);
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EngGView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Erp)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGrid
			// 
			this.DataGrid.AllowUserToAddRows = false;
			this.DataGrid.AllowUserToDeleteRows = false;
			this.DataGrid.AllowUserToResizeColumns = false;
			this.DataGrid.AllowUserToResizeRows = false;
			this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGrid.ColumnHeadersHeight = 30;
			this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.DataGrid.EnableHeadersVisualStyles = false;
			this.DataGrid.GridColor = System.Drawing.Color.Silver;
			this.DataGrid.Location = new System.Drawing.Point(9, 162);
			this.DataGrid.Margin = new System.Windows.Forms.Padding(4);
			this.DataGrid.MultiSelect = false;
			this.DataGrid.Name = "DataGrid";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Cyan;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkBlue;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.DataGrid.RowHeadersVisible = false;
			this.DataGrid.RowHeadersWidth = 4;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.DataGrid.RowTemplate.Height = 25;
			this.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.DataGrid.Size = new System.Drawing.Size(275, 652);
			this.DataGrid.TabIndex = 64;
			this.DataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellEndEdit);
			this.DataGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellLeave);
			// 
			// EngGView
			// 
			this.EngGView.AllowUserToAddRows = false;
			this.EngGView.AllowUserToDeleteRows = false;
			this.EngGView.AllowUserToResizeColumns = false;
			this.EngGView.AllowUserToResizeRows = false;
			this.EngGView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.EngGView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.EngGView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MidnightBlue;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.EngGView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.EngGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Aqua;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.EngGView.DefaultCellStyle = dataGridViewCellStyle7;
			this.EngGView.EnableHeadersVisualStyles = false;
			this.EngGView.GridColor = System.Drawing.Color.Silver;
			this.EngGView.Location = new System.Drawing.Point(294, 107);
			this.EngGView.MultiSelect = false;
			this.EngGView.Name = "EngGView";
			this.EngGView.ReadOnly = true;
			this.EngGView.RowHeadersVisible = false;
			this.EngGView.RowHeadersWidth = 4;
			this.EngGView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Aqua;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
			this.EngGView.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.EngGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.EngGView.Size = new System.Drawing.Size(1200, 780);
			this.EngGView.TabIndex = 62;
			this.EngGView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EngGView_CellClick);
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.cmdDelete.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDelete.ForeColor = System.Drawing.Color.Navy;
			this.cmdDelete.Location = new System.Drawing.Point(645, -85);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(99, 29);
			this.cmdDelete.TabIndex = 59;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.UseVisualStyleBackColor = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLabel,
            this.mnuNew,
            this.mnuSave,
            this.mnuDelete,
            this.mnuHelp,
            this.mnuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(1850, 25);
			this.menuStrip1.TabIndex = 65;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuLabel
			// 
			this.mnuLabel.AutoSize = false;
			this.mnuLabel.Name = "mnuLabel";
			this.mnuLabel.Size = new System.Drawing.Size(200, 21);
			this.mnuLabel.Text = "File name ";
			// 
			// mnuNew
			// 
			this.mnuNew.ForeColor = System.Drawing.Color.MediumBlue;
			this.mnuNew.Name = "mnuNew";
			this.mnuNew.Size = new System.Drawing.Size(69, 21);
			this.mnuNew.Text = "New File";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.ForeColor = System.Drawing.Color.MediumBlue;
			this.mnuSave.Name = "mnuSave";
			this.mnuSave.Size = new System.Drawing.Size(47, 21);
			this.mnuSave.Text = "Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.ForeColor = System.Drawing.Color.MediumBlue;
			this.mnuDelete.Name = "mnuDelete";
			this.mnuDelete.Size = new System.Drawing.Size(57, 21);
			this.mnuDelete.Text = "Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.ForeColor = System.Drawing.Color.MediumBlue;
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(47, 21);
			this.mnuHelp.Text = "Help";
			this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
			// 
			// mnuClose
			// 
			this.mnuClose.ForeColor = System.Drawing.Color.Red;
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.Size = new System.Drawing.Size(52, 21);
			this.mnuClose.Text = "Close";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// Erp
			// 
			this.Erp.ContainerControl = this;
			// 
			// ComboBox1
			// 
			this.ComboBox1.BackColor = System.Drawing.Color.Blue;
			this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			this.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBox1.ForeColor = System.Drawing.Color.White;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Location = new System.Drawing.Point(7, 1);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(197, 24);
			this.ComboBox1.TabIndex = 66;
			this.ComboBox1.Leave += new System.EventHandler(this.ComboBox1_Leave);
			// 
			// Column1
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lavender;
			this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column1.Frozen = true;
			this.Column1.HeaderText = "Parameter Name";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 150;
			// 
			// Column2
			// 
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
			dataGridViewCellStyle3.Format = "N2";
			dataGridViewCellStyle3.NullValue = null;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
			this.Column2.HeaderText = " Value";
			this.Column2.Name = "Column2";
			this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// frmEngine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1850, 980);
			this.Controls.Add(this.ComboBox1);
			this.Controls.Add(this.DataGrid);
			this.Controls.Add(this.EngGView);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(320, 25);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmEngine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frmEngine_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EngGView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Erp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridView EngGView;
        internal System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ErrorProvider Erp;
        private System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuLabel;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
	}
}

