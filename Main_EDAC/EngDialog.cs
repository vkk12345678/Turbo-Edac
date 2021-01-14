using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class EngDialog : Form
    {
        private Boolean f_Found = false;

        private frmMain main = new frmMain();

        public EngDialog(frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {            
            Global.flg_prjOn = true; 
            this.Close();
        }
        private void EngDialog_Load(object sender, EventArgs e)
        {
            try
            {
                TextBox1.Text = String.Empty;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'EngNo'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();

                while (Rd1.Read())
                {

                    TextBox1.Text = DateTime.Now.ToString("dd_MM_yyyy"); //Rd1.GetValue(1).ToString();
                    TextBox2.Text = Rd1.GetValue(2).ToString();
                    TextBox3.Text = Rd1.GetValue(3).ToString();
                    TextBox4.Text = Rd1.GetValue(4).ToString();
                    TextBox5.Text = Rd1.GetValue(5).ToString();
                    TextBox6.Text = Rd1.GetValue(6).ToString();
                    PrjCombo.Text = Rd1.GetValue(7).ToString();
                    
                    if (Rd1.GetValue(8).ToString() == "True") checkBox1.CheckState = CheckState.Checked; else checkBox1.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(9).ToString() == "True") checkBox2.CheckState = CheckState.Checked; else checkBox2.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(10).ToString() == "True") checkBox3.CheckState = CheckState.Checked; else checkBox3.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(11).ToString() == "True") checkBox4.CheckState = CheckState.Checked; else checkBox4.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(12).ToString() == "True") checkBox5.CheckState = CheckState.Checked; else checkBox5.CheckState = CheckState.Unchecked;

                    if (Rd1.GetValue(13).ToString() == "True") rd_New.Checked = true; else rd_New.Checked = false;
                    if (Rd1.GetValue(14).ToString() == "True") rd_Last.Checked = true; else rd_Last.Checked = false;
                    if (Rd1.GetValue(15).ToString() == "True") rd_smooth.Checked = true; else rd_smooth.Checked = false;
                    if (Rd1.GetValue(16).ToString() == "True") rd_standard.Checked = true; else rd_standard.Checked = false;

                    textBox7.Text = Rd1.GetValue(17).ToString();
                    textBox8.Text = Rd1.GetValue(18).ToString();
                    textBox13.Text = Rd1.GetValue(19).ToString();
                    HzCombo.Text = Rd1.GetValue(20).ToString();


                   
                    TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    string ST = (Global.sysIn[10]);
                    long Mn = (Convert.ToInt32(ST.Substring(0, 1)) * 60) + Convert.ToInt32(ST.Substring(2));
                    long Tm;
                    Tm = (Convert.ToInt16(DateTime.Now.Hour.ToString()) * 60) + Convert.ToInt16(DateTime.Now.Minute.ToString());

                    if ((Tm > Mn) && (Tm <= (Mn + 480))) TextBox10.Text = "A";
                    else if ((Tm > (Mn + 480)) && (Tm <= (Mn + 960))) TextBox10.Text = "B";
                    else TextBox10.Text = "C";
                }
                Rd1.Close(); 
                Global.con.Close();
                Fill_Combo();
               
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  EngDialog_Load....", "Alart"); 
            }
        }

        private void Fill_Combo()
        {
            try
            {               
                PrjCombo.Items.Clear();
                PrjCombo.BackColor = Color.Green;
                PrjCombo.ForeColor = Color.Yellow;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    PrjCombo.Items.Add(Rd.GetValue(0).ToString());
                }
                Rd.Close();
                Global.con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in EngDialog: Fill_Combo:  " + ex.Message);
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
          
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    checkBox1.CheckState = CheckState.Checked;                   
                }
                else
                {
                    checkBox1.CheckState = CheckState.Unchecked;                   
                }  
        }

      
     

        private void Check_File_Validation()
        {
            try
            {

                if (Global.EngNo == String.Empty)
                    MessageBox.Show("Engine No. Not Entered ......., ");
                else
                {
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", Global.con);
                    MySqlDataReader Rd = cmd.ExecuteReader();
                    int x = 0;
                    while (Rd.Read())
                    {
                        for (x = 0; x < (Rd.FieldCount - 1); x++) Global.Prj[x] = Rd.GetValue(x).ToString();
                    }

                    Global.TestTyp = Global.Prj[5];
                    Global.cumhours = "0000.00.00";
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblEngine", Global.con);
                    MySqlDataReader Rd1 = cmd1.ExecuteReader();
                    x = 0;
                    while (Rd1.Read())
                    {
                        if (Global.Prj[1] == Rd1.GetValue(0).ToString())
                        {
                            f_Found = true;
                            break;
                        }
                        x += 1;
                        Rd1.Close();

                    }
                    if (f_Found == false)
                    {
                        MessageBox.Show("Engine File  Not Found ....... ");
                        return;
                    }
                    Global.con.Close();
                    //  **************************
                    x = 0;
                    Global.Open_Connection("lim_db", "conLim");
                    MySqlCommand cmd2 = new MySqlCommand("SELECT TABLE_NAME FROM lim_db.INFORMATION_SCHEMA.TABLES", Global.conLim);
                    using (MySqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (Global.Prj[3] == ((string)reader["TABLE_NAME"]))
                        {
                            f_Found = true;
                        }
                        x += 1;
                        reader.Close();
                    }
                    if (f_Found == false)
                    {
                        MessageBox.Show("Limit File  Not Found ....... ");
                        return;
                    }

                    cmd2.Dispose();
                    Global.conLim.Close();
                    //********************************** 
                    x = 0;
                    Global.Open_Connection("seq_db", "conSeq");
                    MySqlCommand cmd3 = new MySqlCommand("SELECT TABLE_NAME FROM seq_db.INFORMATION_SCHEMA.TABLES", Global.conSeq);
                    using (MySqlDataReader reader = cmd3.ExecuteReader())
                    {
                        if (Global.Prj[2] == ((string)reader["TABLE_NAME"]))
                        {
                            f_Found = true;
                        }
                        x += 1;
                        reader.Close();
                    }
                    if (f_Found == false)
                    {
                        MessageBox.Show("Sequence File  Not Found ....... ");
                        return;
                    }
                    cmd3.Dispose();
                    Global.conSeq.Close();
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Check Validation EngDialog....", "Alart");               
            }

        }

       private void btnMSave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {
                   //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }

               if (TextBox1.Text == String.Empty) // "")
               {
                   MessageBox.Show("Please Type Engine No. ...... ");
                   TextBox1.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                   MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }
               else if ((textBox7.Text == String.Empty) || (textBox8.Text == String.Empty) || (textBox13.Text == String.Empty))
               {
                   Erp1.SetError(groupBox2, "Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");

                   MessageBox.Show("Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");
                   groupBox2.Focus();
               }
               else
               {
                   Global.EngNo = TextBox1.Text;
                   Global.EngineNo = TextBox1.Text;
                   Global.FipNo = TextBox2.Text;
                   Global.EngMd = TextBox3.Text;
                   Global.OperatorNm = TextBox4.Text;
                   Global.EnginerNm = TextBox5.Text;
                   Global.TestRef = TextBox6.Text;
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   Global.HzLog = HzCombo.Text;
                     
                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;
                  
                   String X = textBox7.Text;
                   Global.S_Rpm = int.Parse(X); 
                   Global.I_Rpm = (int.Parse(X) + int.Parse(X) / 10);

                   String Y = textBox8.Text;
                   Global.F_Rpm = (int.Parse(Y) + int.Parse(Y) / 10);

                   String Z = textBox13.Text;
                   Global.Max_Trq = (Double.Parse(Z) + (Double.Parse(Z) / 10));

                   Global.Open_Connection("gen_db", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE TbSys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.FipNo + "'," +
                                " CH3 = '" + Global.EngMd + "'," +
                                " CH4 = '" + Global.OperatorNm + "'," +
                                " CH5 = '" + Global.TKnNo + "'," +
                                " CH6 = '" + Global.TestRef + "'," +
                                " CH7 = '" + Global.PrjNm + "'," +
                                " CH8 = '" + Global.flg_smk + "'," +
                                " CH9 = '" + Global.flg_Radiator + "'," +
                                " CH10 = '" + Global.flg_Fan + "'," +
                                " CH11 = '" + Global.flg_AirCln + "'," +
                                " CH12 = '" + Global.flg_Silincer + "'," +
                                " CH13 = '" + Global.flg_NewFile + "'," +
                                " CH14 = '" + Global.flg_OldFile + "'," +
                                " CH15 = '" + Global.flg_Smt_Changeover + "'," +
                                " CH16 = '" + Global.flg_Std_Changeover + "'," +
                                " CH17 = '" + X + "'," +
                                " CH18 = '" + Y + "'," +
                                " CH19 = '" + Z + "'," +
                                " CH20 = '" + Global.HzLog + "'" +
                                " WHERE FileName = 'EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   Global.Rd_System();
                   Global.PrjNm = PrjCombo.Text;
                   Check_File_Validation();
                   Global.flg_Auto = false;
                   Global.flg_Manual = true;
                   Global.Read_Eng();
                   clsLimit.Read_Limfl();
                   Global.Flg_Ready = true;
                   Global.main.BtnSA.Enabled = true;
                   Global.main.Btn21.Enabled = false;
                   Global.flg_Semi_Auto = true;

                   switch (HzCombo.Text)
                   {
                       case "100 Hz":
                           Global.Dly_cnt = 10000;
                           break;
                       case "080 Hz":
                           Global.Dly_cnt = 12500;
                           break;
                       case "060 Hz":
                           Global.Dly_cnt = 16667;
                           break;
                       case "050 Hz":
                           Global.Dly_cnt = 20000;
                           break;
                       case "040 Hz":
                           Global.Dly_cnt = 25000;
                           break;
                       case "020 Hz":
                           Global.Dly_cnt = 50000;
                           break;
                       case "010 Hz":
                           Global.Dly_cnt = 100000;
                           break;
                       case "001 Hz":
                           Global.Dly_cnt = 1000000;
                           break;
                       default:
                           Global.Dly_cnt = 1000000;
                           break;
                   }

                 
                   this.Close();
               }
           }
           catch (Exception ex)
           {
               Global.Create_OnLog(ex.Message + " :  Engine Dialog Save Man File....", "Alart"); 
           }

       }

       private void btnASave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {
                   //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }

               if (TextBox1.Text == String.Empty) // "")
               {
                   MessageBox.Show("Please Type Engine No. ...... ");
                   TextBox1.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                   MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }
               else if ((textBox7.Text == String.Empty) || (textBox8.Text == String.Empty)||(textBox13.Text == String.Empty))
               {
                   Erp1.SetError(groupBox2, "Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");

                   MessageBox.Show("Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");
                   groupBox2.Focus();
               }
               else
               {
                   Global.EngNo = TextBox1.Text;
                   Global.EngineNo = TextBox1.Text;
                   Global.FipNo = TextBox2.Text;
                   Global.EngMd = TextBox3.Text;
                   Global.OperatorNm = TextBox4.Text;
                   Global.EnginerNm = TextBox5.Text;
                   Global.TestRef = TextBox6.Text;
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   Global.HzLog = HzCombo.Text;

                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;
                   if (rd_smooth.Checked == true) Global.flg_Smt_Changeover = true; else Global.flg_Smt_Changeover = false;
                   if (rd_standard.Checked == true) Global.flg_Std_Changeover = true; else Global.flg_Std_Changeover = false;


                   String X = textBox7.Text;
                   Global.S_Rpm = int.Parse(X); 
                   Global.I_Rpm = (int.Parse(X) + int.Parse(X) / 10);

                   String Y = textBox8.Text;
                   Global.F_Rpm = (int.Parse(Y) + int.Parse(Y) / 10);

                   String Z = textBox13.Text;
                   Global.Max_Trq = (Double.Parse(Z) + (Double.Parse(Z) / 10));


                   Global.Open_Connection("gen_db", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE TbSys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.FipNo + "'," +
                                " CH3 = '" + Global.EngMd + "'," +
                                " CH4 = '" + Global.OperatorNm + "'," +
                                " CH5 = '" + Global.TKnNo + "'," +
                                " CH6 = '" + Global.TestRef + "'," +
                                " CH7 = '" + Global.PrjNm + "'," +
                                " CH8 = '" + Global.flg_smk + "'," +
                                " CH9 = '" + Global.flg_Radiator + "'," +
                                " CH10 = '" + Global.flg_Fan + "'," +
                                " CH11 = '" + Global.flg_AirCln + "'," +
                                " CH12 = '" + Global.flg_Silincer + "'," +
                                " CH13 = '" + Global.flg_NewFile + "'," +
                                " CH14 = '" + Global.flg_OldFile + "'," +
                                " CH15 = '" + Global.flg_Smt_Changeover + "'," +
                                " CH16 = '" + Global.flg_Std_Changeover + "'," +
                                " CH17 = '" + X + "'," +
                                " CH18 = '" + Y + "'," +
                                " CH19 = '" + Z + "'," +
                                " CH20 = '" + Global.HzLog + "'" +
                                " WHERE FileName = 'EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   Global.Rd_System();
                   Global.PrjNm = PrjCombo.Text;
                   Check_File_Validation();
                   Global.flg_Auto = true;
                   Global.flg_Manual = false;
                   Global.Read_Eng();
                   clsLimit.Read_Limfl();
                   Global.Flg_Ready = true;
                   Global.main.BtnSA.Enabled = false;
                   Global.main.Btn21.Enabled = true;
                   Global.flg_Semi_Auto = false;

                   switch (HzCombo.Text)
                   {
                       case "100 Hz":
                           Global.Dly_cnt = 10000;
                           break;
                       case "080 Hz":
                           Global.Dly_cnt = 12500;
                           break;
                       case "060 Hz":
                           Global.Dly_cnt = 16667;
                           break;
                       case "050 Hz":
                           Global.Dly_cnt = 20000;
                           break;
                       case "040 Hz":
                           Global.Dly_cnt = 25000;
                           break;
                       case "020 Hz":
                           Global.Dly_cnt = 50000;
                           break;
                       case "010 Hz":
                           Global.Dly_cnt = 100000;
                           break;
                       case "001 Hz":
                           Global.Dly_cnt = 1000000;
                           break;
                       default:
                           Global.Dly_cnt = 1000000;
                           break;
                   }
                   //Global.flg_RunStart = true;
                   this.Close();
               }
           }
           catch (Exception ex)
           {
               Global.Create_OnLog(ex.Message + " : Engine Dialog  Save Auto File....", "Alart");  
               
           }

       }

       private void button1_Click(object sender, EventArgs e)
       {
           panel2.Visible=true;
           panel2.BringToFront();
           dgEngDetails.RowCount = 41;
           dgEngDetails[0, 0].Value = "CUSTOMER";
           dgEngDetails[0, 1].Value = "ENGINE TYPE";
           dgEngDetails[0, 2].Value = "ENGINE RATING";
           dgEngDetails[0, 3].Value = "ENGINE SL.NO";
           dgEngDetails[0, 4].Value = "NUMBER OF CYL";
           dgEngDetails[0, 5].Value = "ARR OF CYL";
           dgEngDetails[0, 6].Value = "BORE(mm)";
           dgEngDetails[0, 7].Value = "STROKE(mm)";
           dgEngDetails[0, 8].Value = "SWEPT VOL.(L)";
           dgEngDetails[0, 9].Value = "NOZZLE SIZE(mm)";
           dgEngDetails[0, 10].Value = "COMPRESSION RATIO";
           dgEngDetails[0, 11].Value = "FUEL INJECTION TIME";
           dgEngDetails[0, 12].Value = "FIRING ORDER";
           dgEngDetails[0, 13].Value = "IDLING SPEED(rpm)";
           dgEngDetails[0, 14].Value = "FUEL INJECTION PUMP";
           dgEngDetails[0, 15].Value = "F.I.P.S.No.";
           dgEngDetails[0, 16].Value = "INJECTION PR.(bar)";
           dgEngDetails[0, 17].Value = "FIP NOZZLE TYPE";
           dgEngDetails[0, 18].Value = "SPRAY HOLE CONFIG";
           dgEngDetails[0, 19].Value = "EGR CONNECTION";
           dgEngDetails[0, 20].Value = "FUEL";
           dgEngDetails[0, 21].Value = "SP.G.OF FUEL";
           dgEngDetails[0, 22].Value = "ENGINE LUB OIL";
           dgEngDetails[0, 23].Value = "TC MODEL";
           dgEngDetails[0, 24].Value = "TC SPECIFICATION";
           dgEngDetails[0, 25].Value = "TC PART NUMBER";
           dgEngDetails[0, 26].Value = "TC SERIAL NUMBER";
           dgEngDetails[0, 27].Value = "TC AFTER COOLER";
           dgEngDetails[0, 28].Value = "AIR FILTER";
           dgEngDetails[0, 29].Value = "DYNO.TYPE";
           dgEngDetails[0, 30].Value = "REMARKS";
           dgEngDetails[0, 31].Value = "CELL NO";
           dgEngDetails[0, 32].Value = "EWO NO";
           dgEngDetails[0, 33].Value = "TEST NAME";
           dgEngDetails[0, 34].Value = "AIR COMPRESSOR";
           dgEngDetails[0, 35].Value = "ALTERNATOR";
           dgEngDetails[0, 36].Value = "COOLING FAN";
           dgEngDetails[0, 37].Value = "POWER STEERING PUMP";
           dgEngDetails[0, 38].Value = "DATE OF TEST";
           dgEngDetails[0, 39].Value = "TESTED BY";
           dgEngDetails[0, 40].Value = "ENGINEER";

       }

       private void toolStripStatusLabel2_Click(object sender, EventArgs e)
       {
           panel2.Visible = false;
           panel2.SendToBack();
       }

       private void toolStripStatusLabel1_Click(object sender, EventArgs e)
       {

       }

      

		//***************
	}
}
