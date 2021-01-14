using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Logger
{
    public partial class EngDialog1 : Form
    {
        //private String[] arr = new string[50];
        public EngDialog1()
        {
            InitializeComponent();
        }

        private void btnASave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {

            for (int i = 0; i <= dgEngDetails.Rows.Count - 1; i++)
            {
                if (dgEngDetails[1, i].Value == null)
                {
                    dgEngDetails[1, i].Value = "***";
                    Global.RpArr[i] = "***";
                }
                else
                    Global.RpArr[i] = dgEngDetails[1, i].Value.ToString();
              
                try
                {
                    Global.EngNo = dgEngDetails[1, 3].Value.ToString();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
//*******************
                string Dt = txtDt.Text;
                Global.EnginerNm = txtengineer.Text;
                Global.OperatorNm = txtoperator.Text;
                Global.RpArr[39] = Dt;
                Global.RpArr[40] = Global.EnginerNm;
                Global.RpArr[41] = Global.OperatorNm;


                if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                String X = textBox7.Text;
                Global.S_Rpm = int.Parse(X);
                Global.I_Rpm = (int.Parse(X) + int.Parse(X) / 10);

                String Y = textBox8.Text;
                Global.F_Rpm = (int.Parse(Y) + int.Parse(Y) / 10);

                String Z = textBox13.Text;
                Global.Max_Trq = (Double.Parse(Z) + (Double.Parse(Z) / 10));

                Global.PrjNm = PrjCombo.Text;
                Global.HzLog = HzCombo.Text;

                if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;
                if (rd_smooth.Checked == true) Global.flg_Smt_Changeover = true; else Global.flg_Smt_Changeover = false;
                if (rd_standard.Checked == true) Global.flg_Std_Changeover = true; else Global.flg_Std_Changeover = false;

                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("UPDATE TbSys SET " +
                             " CH1 = '" + dgEngDetails[1, 0].Value.ToString() + "'," +
                             " CH2 = '" + dgEngDetails[1, 1].Value.ToString() + "'," +
                             " CH3 = '" + dgEngDetails[1, 2].Value.ToString() + "'," +
                             " CH4 = '" + dgEngDetails[1, 3].Value.ToString() + "'," +
                             " CH5 = '" + dgEngDetails[1, 4].Value.ToString() + "'," +
                             " CH6 = '" + dgEngDetails[1, 5].Value.ToString() + "'," +
                             " CH7 = '" + dgEngDetails[1, 6].Value.ToString() + "'," +
                             " CH8 = '" + dgEngDetails[1, 7].Value.ToString() + "'," +
                             " CH9 = '" + dgEngDetails[1, 8].Value.ToString() + "'," +
                             " CH10 = '" + dgEngDetails[1, 9].Value.ToString() + "'," +
                             " CH11 = '" + dgEngDetails[1, 10].Value.ToString() + "'," +
                             " CH12 = '" + dgEngDetails[1, 11].Value.ToString() + "'," +
                             " CH13 = '" + dgEngDetails[1, 12].Value.ToString() + "'," +
                             " CH14 = '" + dgEngDetails[1, 13].Value.ToString() + "'," +
                             " CH15 = '" + dgEngDetails[1, 14].Value.ToString() + "'," +
                             " CH16 = '" + dgEngDetails[1, 15].Value.ToString() + "'," +
                             " CH17 = '" + dgEngDetails[1, 16].Value.ToString() + "'," +
                             " CH18 = '" + dgEngDetails[1, 17].Value.ToString() + "'," +
                             " CH19 = '" + dgEngDetails[1, 18].Value.ToString() + "'," +
                             " CH20 = '" + dgEngDetails[1, 19].Value.ToString() + "'," +
                             " CH21 = '" + dgEngDetails[1, 20].Value.ToString() + "'," +
                             " CH22 = '" + dgEngDetails[1, 21].Value.ToString() + "'," +
                             " CH23 = '" + dgEngDetails[1, 22].Value.ToString() + "'," +
                             " CH24 = '" + dgEngDetails[1, 23].Value.ToString() + "'," +
                             " CH25 = '" + dgEngDetails[1, 24].Value.ToString() + "'," +
                             " CH26 = '" + dgEngDetails[1, 25].Value.ToString() + "'," +
                             " CH27 = '" + dgEngDetails[1, 26].Value.ToString() + "'," +
                             " CH28 = '" + dgEngDetails[1, 27].Value.ToString() + "'," +
                             " CH29 = '" + dgEngDetails[1, 28].Value.ToString() + "'," +
                             " CH30 = '" + dgEngDetails[1, 29].Value.ToString() + "'," +
                             " CH31 = '" + dgEngDetails[1, 30].Value.ToString() + "'," +
                             " CH32 = '" + dgEngDetails[1, 31].Value.ToString() + "'," +
                             " CH33 = '" + dgEngDetails[1, 32].Value.ToString() + "'," +
                             " CH34 = '" + dgEngDetails[1, 33].Value.ToString() + "'," +
                             " CH35 = '" + dgEngDetails[1, 34].Value.ToString() + "'," +
                             " CH36 = '" + dgEngDetails[1, 35].Value.ToString() + "'," +
                             " CH37 = '" + dgEngDetails[1, 36].Value.ToString() + "'," +
                             " CH38 = '" + dgEngDetails[1, 37].Value.ToString() + "'," +
                             " CH39 = '" + dgEngDetails[1, 38].Value.ToString() + "'," +
                             " CH40 = '" + Dt + "'," +
                             " CH41 = '" + Global.EnginerNm  + "'," +
                             " CH42 = '" + Global.OperatorNm + "'," +
                             " CH43 = '" + Global.flg_smk + "'," +                             
                             " CH44 = '" + X + "'," +
                             " CH45 = '" + Y + "'," +
                             " CH46 = '" + Z + "'," +
                             " CH47 = '" + PrjCombo.Text + "'," +
                             " CH48 = '" + Global.HzLog + "'," +
                             " CH49 = '" + Global.flg_NewFile + "'," +
                             " CH50 = '" + Global.flg_OldFile + "'," +
                             " CH51 = '" + Global.flg_Smt_Changeover + "'," +
                             " CH52 = '" + Global.flg_Std_Changeover + "'" +
                             " WHERE FileName = 'EngNo'", Global.con);
                cmd.ExecuteNonQuery();
                Global.con.Close();
                
            
           
            
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
        private void EngDialog1_Load(object sender, EventArgs e)
        {
            try
            {
                loadGrid();
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'EngNo'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();

                while (Rd1.Read())
                {
                    for (int x = 0; x <= 38; x++)
                    {
                        dgEngDetails[1, x].Value = Rd1.GetValue(x+1).ToString();
                    }

                    txtDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    string ST = (Global.sysIn[10]);
                    long Mn = (Convert.ToInt32(ST.Substring(0, 1)) * 60) + Convert.ToInt32(ST.Substring(2));
                    long Tm;
                    Tm = (Convert.ToInt16(DateTime.Now.Hour.ToString()) * 60) + Convert.ToInt16(DateTime.Now.Minute.ToString());

                    if ((Tm > Mn) && (Tm <= (Mn + 480))) TextBox10.Text = "A";
                    else if ((Tm > (Mn + 480)) && (Tm <= (Mn + 960))) TextBox10.Text = "B";
                    else TextBox10.Text = "C";
                    txtengineer.Text = Rd1.GetValue(41).ToString();
                    txtoperator.Text = Rd1.GetValue(42).ToString();
                    
                    if (Rd1.GetValue(43).ToString() == "True") checkBox1.CheckState = CheckState.Checked; else checkBox1.CheckState = CheckState.Unchecked;

                    textBox7.Text = Rd1.GetValue(44).ToString();
                    textBox8.Text = Rd1.GetValue(45).ToString();
                    textBox13.Text = Rd1.GetValue(46).ToString();
                    PrjCombo.Text = Rd1.GetValue(47).ToString();
                    HzCombo.Text = Rd1.GetValue(48).ToString();
                                       
                    if (Rd1.GetValue(49).ToString() == "True") rd_New.Checked = true; else rd_New.Checked = false;
                    if (Rd1.GetValue(50).ToString() == "True") rd_Last.Checked = true; else rd_Last.Checked = false;
                    if (Rd1.GetValue(51).ToString() == "True") rd_smooth.Checked = true; else rd_smooth.Checked = false;
                    if (Rd1.GetValue(52).ToString() == "True") rd_standard.Checked = true; else rd_standard.Checked = false;
                    
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

        private void  loadGrid()
        {

           dgEngDetails.RowCount = 39;
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
           dgEngDetails[0, 11].Value = "ENGINE COOLANT";
           dgEngDetails[0, 12].Value = "FUEL INJECTION TIME";
           dgEngDetails[0, 13].Value = "FIRING ORDER";
           dgEngDetails[0, 14].Value = "IDLING SPEED(rpm)";
           dgEngDetails[0, 15].Value = "FUEL INJECTION PUMP";
           dgEngDetails[0, 16].Value = "F.I.P.S.No.";
           dgEngDetails[0, 17].Value = "INJECTION PR.(bar)";
           dgEngDetails[0, 18].Value = "FIP NOZZLE TYPE";
           dgEngDetails[0, 19].Value = "SPRAY HOLE CONFIG";
           dgEngDetails[0, 20].Value = "EGR CONNECTION";
           dgEngDetails[0, 21].Value = "FUEL";
           dgEngDetails[0, 22].Value = "SP.G.OF FUEL";
           dgEngDetails[0, 23].Value = "ENGINE LUB OIL";
           dgEngDetails[0, 24].Value = "TC MODEL";
           dgEngDetails[0, 25].Value = "TC SPECIFICATION";
           dgEngDetails[0, 26].Value = "TC PART NUMBER";
           dgEngDetails[0, 27].Value = "TC SERIAL NUMBER";
           dgEngDetails[0, 28].Value = "TC AFTER COOLER";
           dgEngDetails[0, 29].Value = "AIR FILTER";
           dgEngDetails[0, 30].Value = "DYNO.TYPE";
           dgEngDetails[0, 31].Value = "REMARKS";
           dgEngDetails[0, 32].Value = "CELL NO";
           dgEngDetails[0, 33].Value = "EWO NO";
           dgEngDetails[0, 34].Value = "TEST NAME";
           dgEngDetails[0, 35].Value = "AIR COMPRESSOR";
           dgEngDetails[0, 36].Value = "ALTERNATOR";
           dgEngDetails[0, 37].Value = "COOLING FAN";
           dgEngDetails[0, 38].Value = "POWER STEERING PUMP";
        }
           

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
