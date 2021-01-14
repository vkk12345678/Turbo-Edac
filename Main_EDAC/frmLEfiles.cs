using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;  
using System.Windows.Forms;

namespace Logger
{
    public partial class frmLEfiles : Form
    {
        public frmLEfiles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmLEfiles_Load(object sender, EventArgs e)
        {
            try
            {
            if (Global.Prj[3] == null) 
            {
                MessageBox.Show ( "Error :  Please. Select the Project ....");
                return;
            }
            else
            {
                label3.Text = Global.Prj[3];
                Global.Open_Connection("lim_db", "ConLim");
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.Prj[3], Global.conLim);
                DataSet  ds  = new DataSet();
                adp.Fill(ds);
                //LimGV.ColumnCount = ds.Tables[0].Columns.Count;

                LimGV.DataSource = ds.Tables[0];
                LimGV.Columns[0].Width = 30;
                LimGV.Columns[1].Width = 100;
                LimGV.Columns[2].Width = 80;
                LimGV.Columns[3].Width = 80;
                LimGV.Columns[4].Width = 80;
                LimGV.Columns[5].Width = 80;
                LimGV.Columns[6].Width = 80;
                LimGV.Columns[7].Width = 80;
                LimGV.Columns[8].Width = 80;
              
                LimGV.DefaultCellStyle.ForeColor = Color.Blue;
                LimGV.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
                LimGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));   
                adp.Dispose();
                ds.Dispose();
                Global.conLim.Close(); 
                foreach (DataGridViewColumn colm in LimGV.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
             if (Global.Prj[1] == null)
             {
                MessageBox.Show("Error :  Please. Select the Project ....");
                return;
             }
             else
             {
                label5.Text = Global.Prj[2];
                label2.Text = Global.Prj[1];
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblEngine WHERE EngineFile = '" + Global.Prj[1] + "'", Global.con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                EngGV.DataSource = ds.Tables[0];
                EngGV.DefaultCellStyle.ForeColor = Color.Blue;
                EngGV.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F);
                EngGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
                adp.Dispose();
                ds.Dispose();
                Global.con.Close();  
                foreach (DataGridViewColumn colm in EngGV.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                } 
             } 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code: -6001 " + ex.Message);
            }
        }

    }
}
