using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Editor
{
    public partial class frmEngine : Form
    {
        private int Rn = 0;
        private Boolean flg_New = false;
        public frmEngine()
        {
            InitializeComponent();
        }

        private void frmEngine_Load(object sender, EventArgs e)
        {
            try
            {
                int i;
                Load_Datagrid();               
                DataGrid.RowCount = (EngGView.ColumnCount);
                for (i = 1; i <= (EngGView.ColumnCount - 2); i++)
                {
                    DataGrid[0, i - 1].Value = EngGView.Columns[i].Name;
                }
                load_InCell(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEngine_Load @ Error Code:- 11001", ex.Message);
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = "";
            ComboBox1.Focus();
            flg_New = true;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox1.Text == "")
                {
                    Erp.SetError(ComboBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    return;
                }
                int x;
                for (x = 0; x <= (EngGView.RowCount - 1); x++)
                {
                    if (ComboBox1.Text == EngGView[0, x].Value.ToString())
                    {
                        flg_New = false;
                        break;
                    }
                    else
                    {
                        flg_New = true;
                    }
                }
                String strData = "";

                if (ComboBox1.Text == "") ComboBox1.Text = " ";



                strData = strData + ComboBox1.Text + "', '";
                strData = strData + "Diesel";
               

                for (x = 1; x <= (EngGView.Columns.Count - 2); x++)
                {
                    if ((DataGrid[1, x].Value) == null)
                    {
                        DataGrid[1, x].Value = "***";
                    }
                    strData = strData + "', '" + DataGrid[1, x].Value.ToString();
                }

                if (flg_New == false)
                {
                    Common.Del_SqlTable("systb", ComboBox1.Text);
                    //MySqlCommand cDelete = new MySqlCommand();
                    //cDelete.CommandText = "DELETE FROM tblEngine WHERE EngineFile = '" + ComboBox1.Text.ToLower()  + "'";
                    //Common.Open_Connection("gen_db", "con");
                    //cDelete.Connection = Common.con;
                    //cDelete.ExecuteNonQuery();
                }

                Common.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " INSERT INTO tblEngine VALUES ('" + strData + "')";
                cmd.Connection = Common.con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("File saved .....");
                Common.Create_OnLog("Normal", "Engine File Saved.....");
                Load_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuSave_Click @ Error Code:-11007 " + ex.Message);
                Common.Create_OnLog("Alart", "Engine File  not Saved.....");
            }


        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {


                Common.Del_SqlTable("tblEngine", ComboBox1.Text.ToLower());
                    //MySqlCommand cDelete = new MySqlCommand();
                //cDelete.CommandText = "DELETE FROM tblEngine WHERE EngineFile ='" + ComboBox1.Text.ToLower () + "'";

                //Common.Open_Connection("gen_db", "con");
                //cDelete.Connection = Common.con;
                //cDelete.ExecuteNonQuery();
                Common.Create_OnLog("Normal", "Engine File deleted Manually.....");

                MessageBox.Show("File Deleted .....");
                Load_Datagrid();
                load_InCell(0);
            }
            catch (Exception ex)
            {
                Common.Create_OnLog("Alart", "Engine File not deleted.....");
                MessageBox.Show("mnuDelete_Click @ Error Code:- 4006  " + ex.Message);
            }
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPath + "Engine.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("file not Found" + helpFilepath);
            }

        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Common.Create_OnLog("Normal", "Engine File closed.....");
            this.Close();
        }
        private void Load_Datagrid()
        {
            try
            {
                int MaxRow = 0;

                Common.Open_Connection("gen_db", "con");
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tblEngine order by EngineFile", Common.con);
                da.Fill(ds);               
                MaxRow = ds.Tables[0].Rows.Count;
                EngGView.DataSource = ds.Tables[0];

                foreach (DataGridViewColumn cln in EngGView.Columns)
                {
                    cln.Width = 60;
                    cln.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                EngGView.Columns[0].Width = 120;
                EngGView.Columns[5].Width = 100;
                ds.Dispose();
                da.Dispose();
                Common.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load_Datagrid @ Error Code:-11002 " + ex.Message);
            }
        }

        private void load_InCell(int Rw)
        {

            try
            {
                int i = 0;

                ComboBox1.Text = EngGView[0, Rw].Value.ToString();
                DataGrid.Rows[0].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[1].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[2].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[3].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[4].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[5].Cells[1].Style.BackColor = SystemColors.ActiveCaption;

                for (i = 1; i <= (EngGView.ColumnCount - 1); i++)
                {
                    DataGrid[1, i - 1].Value = EngGView[i, Rw].Value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load_InCell @ Error Code:- 11003" + ex.Message);
            }
        }

        private void EngGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rn = EngGView.CurrentRow.Index;
            load_InCell(Rn);
        }
        private void Key_Validation(int KeyAscii)
        {

            if ((((KeyAscii > 47) && (KeyAscii < 58)) || ((KeyAscii == 8) || (KeyAscii == 46))))
            {
                // Or KeyAscii = 45 Or'select only numbers, fullstop,backspace
                // EP.Clear()
            }
            else
            {
                SendKeys.Send(("{+}" + "{HOME}"));
                MessageBox.Show("Only Numbers are Allowed  & Not !!");
                SendKeys.Send("{BACKSPACE}");
            }
        }

        private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            //int columnIndex = 1;   // e.ColumnIndex;

            if (e.ColumnIndex == 1)
            {
                bool validation = true;
                if ((RowIndex <= 5) && (RowIndex > 1))

                    if (DataGrid.Rows[RowIndex].Cells[1].Value != null && DataGrid.Rows[RowIndex].Cells[1].Value.ToString().Trim() != "")
                    {
                        string DataToValidate = DataGrid.Rows[RowIndex].Cells[1].Value.ToString();
                        foreach (char c in DataToValidate)
                        {

                            if ((!char.IsDigit(c)) && (c != 46))
                            {
                                validation = false;
                                break;
                            }
                        }
                        if (validation == false)
                        {
                            DataGrid.Rows[RowIndex].Cells[1].ErrorText = "You Can Only Enter Number here ";
                            DataGrid.Rows[RowIndex].Cells[1].Value = "";
                        }
                        else
                        {
                            DataGrid.Rows[RowIndex].Cells[1].ErrorText = "";
                        }
                    }

            }
        }

        private void DataGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
               
                    Double l = Convert.ToDouble(DataGrid[1, 1].Value.ToString());
                    DataGrid[1, 1].Value = l.ToString("000.000");
                    l = Convert.ToDouble(DataGrid[1, 2].Value.ToString());
                    DataGrid[1, 2].Value = l.ToString("00");
                    l = Convert.ToDouble(DataGrid[1, 3].Value.ToString());
                    DataGrid[1, 3].Value = l.ToString("000.000");

                    double R = double.Parse(DataGrid[1, 1].Value.ToString());
                    double L = double.Parse(DataGrid[1, 2].Value.ToString());
                    double C = double.Parse(DataGrid[1, 3].Value.ToString());
                    DataGrid[1, 4].Value = Convert.ToString((0.003142 / 4000) * R * R * L * C);
                    mnuSave.Enabled = true;
                


            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox1.Text == "")
                {
                    Erp.SetError(ComboBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    return;
                }

                if (ComboBox1.Text.Length <= 4)
                {
                    Erp.SetError(ComboBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    ComboBox1.Focus();
                    ComboBox1.Text = "";
                    return;
                }

                Common.FormatCombo(ComboBox1);

                if (ComboBox1.Text.Length > 4)
                {
                    switch ((ComboBox1.Text.Substring(0, 4)))
                    {
                        case "ENG_":
                            ComboBox1.Text = "eng_" + (ComboBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        case "Eng_":
                            ComboBox1.Text = "eng_" + (ComboBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        case "eng_":
                            ComboBox1.Text = "eng_" + (ComboBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        default:
                            ComboBox1.Text = "eng_" + ComboBox1.Text.ToLower();
                            Erp.Clear();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComboBox1_Leave @ " + ex.Message);
            }

        }
    }
    
}