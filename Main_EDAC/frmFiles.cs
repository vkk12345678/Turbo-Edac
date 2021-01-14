using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Logger
{
    public partial class frmFiles : Form
    {        
        private string str = "";
        public Process p = new Process();

       

        public frmFiles()
        {
            InitializeComponent();
        }

        private void frmFiles_Load(object sender, EventArgs e)
        {       
            Load_ProjectTV();
        }

        //private void Fill_Engine_DetailsLB()
        //{
        //    try
        //    {              

        //        Global.Open_Connection("gen_db", "con");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblengine ORDER BY EngineFile", Global.con);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        listBox1.Items.Add("Engine File Details");
        //        listBox1.Items.Add("-------------------");
        //        //listBox2.Items.Add(" \r"); 
               
        //        while (Rd.Read())
        //        {
        //           listBox1.Items.Add (Rd.GetValue(0).ToString());                    
        //        }

        //        Rd.Close();
        //        cmd.Dispose();
        //        Global.con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " : Check Fill Combo Function ...", "Alert");
        //        return;
        //    }

        //}

        //private void Fill_SequenceLB()
        //{
        //    try
        //    {
        //        Global.Open_Connection("seq_db", "conSeq");
        //        MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='seq_db'", Global.conSeq);
        //        using (MySqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            listBox2.Items.Add("Sequence File Details");
        //            listBox2.Items.Add("-------------------");                        
        //            //listBox2.Items.Add("\r"); 
        //            while (reader.Read())
                   
        //                listBox2.Items.Add(reader.GetValue(0).ToString());
        //            reader.Close();
        //        }
        //        cmd.Dispose();
        //        Global.con.Close();
                

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " : Check Fill Combo Function ...", "Alert");
        //        return;
        //        //MessageBox.Show("Check Fill combo  Function :  Error Code :Error Code :- 13002 " + ex.Message);

        //    }

        //}
        //private void Fill_LimitLB()
        //{
        //    try
        //    {
        //        Global.Open_Connection("lim_db", "conLim");
        //        MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='lim_db'", Global.conLim);

        //        using (MySqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            listBox3.Items.Add("Limit File Details");
        //            listBox3.Items.Add("-------------------");
        //            //listBox3.Items.Add(" \r");
        //            while (reader.Read())
        //            {
        //                treeView1.Nodes["R1"].Nodes.Add("R1", reader.GetValue(0).ToString());
        //                //listBox3 .Items.Add((string)reader["TABLE_NAME"]);
        //            }
        //            reader.Dispose();
        //        }

        //        cmd.Dispose();
        //        Global.con.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Fill_ListBox @ Error Code: 12004 " + '\n' + ex.Message, "Limit File",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void Load_PassoutLB()
        {


            Global.Open_Connection("gen_db", "con");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblpassout ORDER BY FileName", Global.con);
            MySqlDataReader Rd = cmd.ExecuteReader();
            listBox4.Items.Add("PassOut File Details");
            listBox4.Items.Add("-------------------");
            //listBox4.Items.Add(" \r");
            while (Rd.Read())
            {
               
                listBox4.Items.Add(Rd.GetValue(0).ToString());
            }

            Rd.Close();
           
        }
        private void Load_ProjectTV()
        {
            treeView1.Nodes.Clear(); //  .Items.Clear();
            treeView1.Nodes.Add("R", "Project Files");
            treeView1.Nodes["R"].Tag = "R";
            treeView1.Nodes.Add("R1", "Engine Files");
            treeView1.Nodes["R1"].Tag = "R1";
            treeView1.Nodes.Add("R2", "Sequence Files");
            treeView1.Nodes["R2"].Tag = "R2";
            treeView1.Nodes.Add("R3", "Limit Files");
            treeView1.Nodes["R3"].Tag = "R3"; 

           


            Global.Open_Connection("gen_db", "con");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblproject ORDER BY ProjectFile", Global.con);
            MySqlDataReader Rd = cmd.ExecuteReader();
     
            while (Rd.Read())
                  treeView1.Nodes["R"].Nodes.Add("R", Rd.GetValue(0).ToString());
            Rd.Close();
            cmd.Dispose();
            Global.con.Close();

            //*********************
            Global.Open_Connection("gen_db", "con");
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblengine ORDER BY EngineFile", Global.con);
            MySqlDataReader Rd1 = cmd1.ExecuteReader();

            while (Rd1.Read())
                treeView1.Nodes["R1"].Nodes.Add("R1", Rd1.GetValue(0).ToString());
            Rd1.Close();
            cmd1.Dispose();
            Global.con.Close();

            //*********************
            Global.Open_Connection("seq_db", "conSeq");
            MySqlCommand cmd2 = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='seq_db'", Global.conSeq);
            using (MySqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                    treeView1.Nodes["R2"].Nodes.Add("R2", reader.GetValue(0).ToString());
                reader.Close();                  
            }
            cmd1.Dispose();
            Global.con.Close();
            //****************************
            Global.Open_Connection("lim_db", "conLim");
            MySqlCommand cmd3 = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='lim_db'", Global.conLim);
            using (MySqlDataReader reader = cmd3.ExecuteReader())
            {
                while (reader.Read())
                    treeView1.Nodes["R3"].Nodes.Add("R3", reader.GetValue(0).ToString());
                reader.Close();
            }
            cmd3.Dispose();
            Global.con.Close();


            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
            treeView1.Select();

            treeView1.ExpandAll();

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            string str1 = treeView1.SelectedNode.Text;
            if (Global.flg_viewFls == true)
            {
                if ((str1.Substring(0, 4).ToLower() == "prj_"))
                    read_Project(str1);
                else if (str1.Substring(0, 4).ToLower() == "lim_")
                    read_Limit(str1);
                else if ((str1.Substring(0, 4).ToLower() == "seq_"))
                    read_Prog(str1);
                else if ((str1.Substring(0, 4).ToLower() == "eng_"))
                    read_Engine(str1);
                else
                    MessageBox.Show("Invalid File Selected \n\n" + "Please select Proper File");
            }
        }
        private void Load_InCell(string str1)
        {
            try
            {
                str1 = treeView1.SelectedNode.Text;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblproject WHERE ProjectFile ='" + str1 + "'", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x < (Rd.FieldCount - 1); x++)
                    {
                        btnProject.Text = Rd.GetValue(1).ToString();
                        btnSeq.Text = Rd.GetValue(3).ToString();
                        btnLimit.Text = Rd.GetValue(2).ToString();
                    }

                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error Code:-11002 " + ex.Message + " :  Load In Cell....", "Alert");
            }
        }
        private void read_Engine(string Str)
        {


            DgView1.Refresh();
            DgView1.Visible = true;
            DgView.Visible = false;
            Global.Open_Connection("gen_db", "Con");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblengine WHERE EngineFile ='" + Str + "'", Global.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DgView1.RowCount = 32;
            DgView1.ColumnCount = 3;
            DgView1.Columns[0].Name = "Sn";
            DgView1.Columns[1].Name = "Parameter Name";
            DgView1.Columns[2].Name = "Parameter Value";
            for (int x = 0; x <= 31; x++)
            {
                DgView1.Rows[x].Height = 24;
                DgView1[0, x].Value = x + 1; //.DataSource = ds.Tables[0];
                DgView1[1, x].Value = ds.Tables[0].Columns[x].ColumnName;
                DgView1[2, x].Value = ds.Tables[0].Rows[0].ItemArray[x].ToString();
            }
            //DgView1.ColumnHeadersVisible = false;
            //DgView1.RowHeadersVisible = false;
            DgView1.Columns[0].Width = 100;
            DgView1.Columns[1].Width = 250;
            DgView1.Columns[2].Width = 250;

            DgView1.DefaultCellStyle.ForeColor = Color.Blue;
            DgView1.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
            DgView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));

            btnProject.Text = treeView1.SelectedNode.Text;
            DgView1[2, 3].Value.ToString();
            btnSeq.Text = DgView1[2, 3].Value.ToString();
            btnLimit.Text = DgView1[2, 2].Value.ToString();

        }


        private void read_Project(string Str)
        {

           
            DgView1.Refresh();
            DgView1.Visible = true;
            DgView.Visible = false;
            Global.Open_Connection("gen_db", "Con");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblproject WHERE ProjectFile ='" + Str + "'", Global.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DgView1.RowCount = 16;
            DgView1.ColumnCount = 3;
            DgView1.Columns[0].Name = "Sn";
            DgView1.Columns[1].Name = "Parameter Name";
            DgView1.Columns[2].Name = "Parameter Value";
            for (int x = 0; x <= 15; x++)
            {
                DgView1.Rows[x].Height = 24;
                DgView1[0, x].Value = x + 1; //.DataSource = ds.Tables[0];
                DgView1[1, x].Value = ds.Tables[0].Columns[x].ColumnName;
                DgView1[2, x].Value = ds.Tables[0].Rows[0].ItemArray[x].ToString();
            }
            //DgView1.ColumnHeadersVisible = false;
            //DgView1.RowHeadersVisible = false;
            DgView1.Columns[0].Width = 100;
            DgView1.Columns[1].Width = 250;
            DgView1.Columns[2].Width = 250;

            btnProject.Text = DgView1[2, 0].Value.ToString();
            btnSeq.Text = DgView1[2, 3].Value.ToString();
            btnLimit.Text = DgView1[2, 2].Value.ToString();
            btnEngine.Text = DgView1[2, 1].Value.ToString();

            DgView1.DefaultCellStyle.ForeColor = Color.Blue;
            DgView1.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
            DgView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));

            btnProject.Text = treeView1.SelectedNode.Text;
            DgView1[2, 3].Value.ToString();
            btnSeq.Text = DgView1[2, 3].Value.ToString();
            btnLimit.Text = DgView1[2, 2].Value.ToString();

        }

         //DgView.Refresh();
         //   Global.Open_Connection("seq_db", "ConSeq");
         //   MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Seq, Global.conSeq);
         //   DataSet ds = new DataSet();
         //   adp.Fill(ds);


         //   DgView.DataSource = ds.Tables[0];

         //   DgView.DefaultCellStyle.ForeColor = Color.Blue;
         //   DgView.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
         //   DgView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
         //   adp.Dispose();
         //   ds.Dispose();
         //   Global.conSeq.Close();
         //   foreach (DataGridViewColumn colm in DgView.Columns)
         //   {
         //       colm.SortMode = DataGridViewColumnSortMode.NotSortable;
         //   }

         //   DgView.ReadOnly = true;
   


        /*

        private void Load_InCell(string str)
        {
            try
            {
                str = treeView1.SelectedNode.Text; // label8.Text; // lstBox.SelectedItem.ToString();
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblproject WHERE ProjectFile ='" + str + "'", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int x = 0;

                while (Rd.Read())
                {

                    for (x = 0; x < (Rd.FieldCount - 1); x++)
                    {

                        ComboBox2.Text = Rd.GetValue(1).ToString();
                        ComboBox3.Text = Rd.GetValue(2).ToString();
                        ComboBox4.Text = Rd.GetValue(3).ToString();
                        ComboBox5.Text = Rd.GetValue(4).ToString();
                        ComboBox6.Text = Rd.GetValue(5).ToString();

                        DGPrj[1, 0].Value = Rd.GetValue(6).ToString();
                        DGPrj[1, 1].Value = Rd.GetValue(7).ToString();
                        DGPrj[1, 2].Value = Rd.GetValue(8).ToString();
                        DGPrj[1, 3].Value = Rd.GetValue(9).ToString();
                        DGPrj[1, 4].Value = Rd.GetValue(10).ToString();
                        DGPrj[1, 5].Value = Rd.GetValue(11).ToString();
                        DGPrj[1, 6].Value = Rd.GetValue(12).ToString();
                        DGPrj[1, 7].Value = Rd.GetValue(13).ToString();
                        DGPrj[1, 8].Value = Rd.GetValue(14).ToString();
                        DGPrj[1, 9].Value = Rd.GetValue(15).ToString();
                        DGPrj[1, 10].Value = Rd.GetValue(16).ToString();
                        DGPrj[1, 11].Value = Rd.GetValue(17).ToString();
                        DGPrj[1, 12].Value = Rd.GetValue(18).ToString();
                        DGPrj[1, 13].Value = Rd.GetValue(19).ToString();
                        //DGPrj[1, 14].Value = Rd.GetValue(20).ToString();
                        if (Rd.GetValue(20).ToString() == "1") checkBox1.CheckState = CheckState.Checked; else checkBox1.CheckState = CheckState.Unchecked;
                        if (Rd.GetValue(21).ToString() == "1") checkBox2.CheckState = CheckState.Checked; else checkBox2.CheckState = CheckState.Unchecked;
                        if (Rd.GetValue(22).ToString() == "1") checkBox3.CheckState = CheckState.Checked; else checkBox3.CheckState = CheckState.Unchecked;
                        if (Rd.GetValue(23).ToString() == "1") checkBox4.CheckState = CheckState.Checked; else checkBox4.CheckState = CheckState.Unchecked;
                        if (Rd.GetValue(24).ToString() == "1") checkBox5.CheckState = CheckState.Checked; else checkBox5.CheckState = CheckState.Unchecked;
                        if (Rd.GetValue(25).ToString() == "1") checkBox6.CheckState = CheckState.Checked; else checkBox6.CheckState = CheckState.Unchecked;
                    }

                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error Code:-11002 " + ex.Message + " :  Load In Cell....", "Alert");
            }
        }*/



        private void read_Prog(String Seq)
        {
            DgView.Refresh();
            DgView1.SendToBack();
            DgView.BringToFront();
            DgView1.Visible = false;
            DgView.Visible = true;           
            Global.Open_Connection("seq_db", "ConSeq");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Seq, Global.conSeq);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DgView.DataSource = ds.Tables[0];
            DgView.DefaultCellStyle.ForeColor = Color.Blue;
            DgView.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
            DgView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
           
            adp.Dispose();
            ds.Dispose();
            Global.conSeq.Close();
            foreach (DataGridViewColumn colm in DgView.Columns)
            {
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DgView.ReadOnly = true;
        }

        //private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
           
        //}

        //private void read_Eng(string Eng)
        //{
        //    Eng = listBox1.Text;
        //    DgView.Refresh();
        //    Global.Open_Connection("gen_db", "con");
        //    MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblEngine WHERE EngineFile = '" + Eng + "'", Global.con);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    DgView.DataSource = ds.Tables[0];
        //    DgView.DefaultCellStyle.ForeColor = Color.Blue;
        //    DgView.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);
        //    DgView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
        //    adp.Dispose();
        //    ds.Dispose();
        //    Global.con.Close();
        //    foreach (DataGridViewColumn colm in DgView.Columns)
        //    {
        //        colm.SortMode = DataGridViewColumnSortMode.NotSortable;
        //    }

        //}

        private void read_Limit(String Lim)
        {
            int i = 0;
            DgView1.Visible = false;
            DgView.Visible = true;
            DgView.Refresh();
            Global.Open_Connection("lim_db", "ConLim");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Lim, Global.conLim);
            DataSet ds = new DataSet();
            adp.Fill(ds);


            DgView.DataSource = ds.Tables[0];

            DgView.DefaultCellStyle.ForeColor = Color.Blue;
            DgView.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);
            DgView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
            adp.Dispose();
            ds.Dispose();
            Global.conSeq.Close();
            foreach (DataGridViewColumn colm in DgView.Columns)
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (DgView[1, i].Value.ToString() == "Not_Prog")
                    DgView.Rows[i].Visible = false;
                else
                    DgView.Rows[i].Visible = true;
            }
            DgView.ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //frmMain frm = new frmMain();
            //frm.ShowDialog(this);
            //frm.Dispose();
        }

        private void mnuEditor_Click(object sender, EventArgs e)
        {
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editor.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }


      
        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void treeView1_MouseHover(object sender, EventArgs e)
        {
            textBox2.Text = "Existing Project Files.\r\n" +
                            "It Contains. \r\n \r\n" +
                            " 1) Engine Files.\r\n\r\n" +
                            " 2) Sequence file.\r\n\r\n" +
                            " 3) Limit File\r\n \r\n" +
                            " 4) Engine Details :All Engine Details are Included in these files like. \r\n \r\n" +
                            "       1) Rated Power, Max Torque, FlyUp Rpm, Idle Rpm.\r\n\r\n" +
                            "       2) Engine Stroke, Engine Cyclinders, Bore Diameter .\r\n\r\n" +
                            "       3) These files are required for calculations like Fuel Delivery, etc.";    

        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {
           
        }       
       
        private void listBox3_MouseHover(object sender, EventArgs e)
        {
            textBox2.Text = "Existing Engine Test Limit Files .\r\n\r\n" + 
                            "During engine testing Limits can be applied to each input parameters.\r\n\r\n" +
                            "If input value exceed given limit .\r\n\r\n"+ 
                            "This file is a pre-programmed, Either It will be indicated on Screen or Engine will be at Idle or ignition made off \r\n";
                          
        }

       

        private void listBox3_Click(object sender, EventArgs e)
        {
            //DgView1.SendToBack();
            //DgView.BringToFront(); 
            //DgView.Refresh();
            //String Str1 = listBox3.GetItemText(listBox3.SelectedItem);
            //read_Limit(Str1);
        }

        //private void listBox1_Click(object sender, EventArgs e)
        //{
        //    DgView.Visible = false;
        //    DgView1.Refresh();            
        //    DgView1.Visible = true;
        //    DgView.SendToBack();
        //    DgView1.BringToFront(); 
        //    Global.Open_Connection("gen_db", "Con");
        //    MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblengine WHERE EngineFile ='" + Str1 + "'", Global.con);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    DgView1.RowCount = 12;
        //    DgView1.ColumnCount = 3;
        //    for (int x = 0; x <= 11; x++)
        //    {
        //        DgView1.Rows[x].Height = 30;
        //        DgView1[0, x].Value = x + 1; //.DataSource = ds.Tables[0];
        //        DgView1[1, x].Value = ds.Tables[0].Columns[x].ColumnName;
        //        DgView1[2, x].Value = ds.Tables[0].Rows[0].ItemArray[x].ToString();
        //    }
        //    DgView1.ColumnHeadersVisible = false;
        //    DgView1.RowHeadersVisible = false;
        //    DgView1.Columns[0].Width = 60;
        //    DgView1.Columns[1].Width = 200;
        //    DgView1.Columns[2].Width = 200;

        //    DgView1.DefaultCellStyle.ForeColor = Color.Blue;
        //    DgView1.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
        //    DgView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
               
          
            
        //    //DgView.Refresh();
        //    //String Str1 = listBox1.GetItemText(listBox1.SelectedItem);
        //    //read_Eng(Str1);
           
        //}

        private void mnuView_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            //frmMain frm = new frmMain();
            //frm.ShowDialog(this);
            //frm.Dispose();
        }

        private void mnuCreate_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
            //comboBox1.SelectedIndex = 1;
            //textBox1.Text = "";
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            //DgView1.SendToBack();
            //DgView.BringToFront(); 
            //DgView.Refresh();
            //String Str1 = listBox2.GetItemText(listBox2.SelectedItem);
            //read_Prog(Str1);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(13, 2);
            Global.flg_create = true;
            Global.flg_Service = false;
            Login frm = new Login();
            frm.ShowDialog(this);
            frm.Dispose(); 
        } 

        private void listBox2_MouseHover(object sender, EventArgs e)
        {
            textBox2.Text = "Existing Engine Test Sequence Files .\r\n\r\n" + // "All Engine Details are Included in these files like.  \r\n" +
                          "Test Sequence of different engine categories like .\r\n\r\n" +
                          "1) Constant Speed (Genset Engines) .\r\n\r\n" +
                          "2) Constant Torque / Automotive Engines  (Petrol Engines) .\r\n\r\n" +
                          "3) Low Speed & High Torque (Tractor Engines) .\r\n";

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Existing Engine Test Sequence Files .\r\n\r\n" + // "All Engine Details are Included in these files like.  \r\n" +
                          "Test Sequence of different engine categories like .\r\n\r\n" +
                          "1) Constant Speed (Genset Engines) .\r\n\r\n" +
                          "2) Constant Torque / Automotive Engines  (Petrol Engines) .\r\n\r\n" +
                          "3) Low Speed & High Torque (Tractor Engines) .\r\n";


        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnCreate_MouseHover(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSeq_Click(object sender, EventArgs e)
        {
            read_Prog(btnSeq.Text);
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            read_Limit(btnLimit.Text);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        Global.Open_Connection("gen_db", "con");
        //        MySqlCommand cmd = new MySqlCommand("Select Passw from Sec where TokenNo= '" + comboBox1.Text + "'", Global.con);
        //        MySqlDataReader rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            str = rd.GetValue(0).ToString();
        //        }
        //        Global.con.Close();
        //        if ((str == textBox1.Text.Trim()) && (comboBox1.Text.Trim() == "Supervisor"))
        //        {
        //           btnUpdate.Enabled = true;
        //           btnSaveAs.Enabled = true;
        //           panel1.Visible = false; 
        //            MessageBox.Show(" Do you want to Edit Existing file or Create a new file",,MessageBoxButtons.)  
        //        }
        //        else if ((str == textBox1.Text.Trim()) && (comboBox1.Text.Trim() == "Service"))
        //        {
        //            Global.flg_Log_service = true;
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Password is wrong", "Dynalec Controls Pvt Ltd.",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //MessageBox.Show("Password is wrong ");
        //            textBox1.Text = "";
        //            comboBox1.Text = "";
        //            comboBox1.Focus();
        //            //Global.flg_Log_supervisor = false;
        //            //Global.flg_Log_service = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show("Error Code:- 16002", ex.Message);
        //        MessageBox.Show("Error Code:- 16002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Global.Create_OnLog("Check Password", "Alert"); //  button1_Click");
        //    }
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {


        }

        private void btnCreate_Click_2(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          //treeView1.SelectedNode.
            string str1 = treeView1.SelectedNode.Text;
            if ((str1.Substring(0, 4) == "prj_"))
                read_Project(str1);
            else if (str1.Substring(0, 4) == "lim_")
                read_Limit(str1);
            else if ((str1.Substring(0, 4) == "seq_"))
                read_Prog(str1);
            else if ((str1.Substring(0, 4) == "eng_"))
                read_Engine(str1);
            else
                MessageBox.Show("Invalid File Selected \n\n" + "Please select Proper File");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Enabled = true;
            panel2.Location = new Point(13, 2);           
            Global.flg_viewFls = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Global.flg_Service = true;
            Global.flg_create = false;
            Login frm = new Login();
            frm.ShowDialog(this);
            frm.Dispose();
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmMain frm3 = new frmMain();
            frm3.ShowDialog();
            frm3.Dispose();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      
        
      
       




      
    //*************************************   
    }
}
