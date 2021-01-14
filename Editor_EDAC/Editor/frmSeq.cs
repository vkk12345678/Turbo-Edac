using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace Editor
{
   

    public partial class frmSeq : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter dAdapter = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        public TimeSpan t;
        public string answer;
        private int Rn = 0;
        private Boolean flg_new = false;

        public frmSeq()
        {
            InitializeComponent();
        }

        private void frmSeq_Load(object sender, EventArgs e)
        {
            try
            {
                flg_new = false;
                Common.Open_Connection("seq_db", "conSeq");
                fill_combo();
                Load_Grid();
                LoadInCell();
                txtMaxVal.SelectedIndex = 0;

                UPD.SelectedIndex = 4;   //.TabIndex = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check frmSeq_Load Function :  Error Code :- 13001", ex.Message);
            }
        }

        private void fill_combo()
        {
            try
            {
                Common.Open_Connection("seq_db", "conSeq");               
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='seq_db'", Common.conSeq);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbSeq.Items.Clear();
                    while (reader.Read())
                    {
                        cmbSeq.Items.Add((string)reader["TABLE_NAME"]);
                    }

                    reader.Close();
                }

                cmd.Dispose();
                Common.con.Close();
                cmbSeq.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Fill combo  Function :  Error Code :Error Code :- 13002 " + ex.Message);

            }
        }      
        private void Load_Grid()
        {

            DGSeq.Refresh();
            DGSeq.RowCount = 0;
            Common.Open_Connection("seq_db", "conSeq");
            cmd = new MySqlCommand("SELECT * FROM " + cmbSeq.Text.ToLower()  + " ORDER BY StepNo", Common.conSeq);
            MySqlDataReader rd = cmd.ExecuteReader();
            int Rw = 0;
            DGSeq.ColumnCount = 28;
            while (rd.Read())
            {
                try
                {

                    //if (Convert.ToBoolean(DGSeq[11, Rw].Value) == true) val1 = "Y"; else val1 = "N";
                    //if (Convert.ToBoolean(DGSeq[14, Rw].Value) == true) val2 = "Y"; else val2 = "N";
                    //if (Convert.ToBoolean(DGSeq[15, Rw].Value) == true) val3 = "Y"; else val3 = "N";
                    //if (Convert.ToBoolean(DGSeq[16, Rw].Value) == true) val4 = "Y"; else val4 = "N";
                    //if (Convert.ToBoolean(DGSeq[27, Rw].Value) == true) val5 = "Y"; else val5 = "N";


                    DGSeq.RowCount += 1;
                    DGSeq[0, Rw].Value = rd.GetValue(0).ToString();
                    DGSeq[1, Rw].Value = rd.GetValue(1).ToString();
                    DGSeq[2, Rw].Value = rd.GetValue(2).ToString();
                    DGSeq[3, Rw].Value = rd.GetValue(3).ToString();
                    DGSeq[4, Rw].Value = rd.GetValue(4).ToString();
                    DGSeq[5, Rw].Value = rd.GetValue(5).ToString();
                    DGSeq[6, Rw].Value = rd.GetValue(6).ToString();
                    DGSeq[7, Rw].Value = rd.GetValue(7).ToString();
                    DGSeq[8, Rw].Value = rd.GetValue(8).ToString();
                    DGSeq[9, Rw].Value = rd.GetValue(9).ToString();
                    DGSeq[10, Rw].Value = rd.GetValue(10).ToString();
                    if (rd.GetValue(11).ToString() == "Y") DGSeq[11, Rw].Value = true; else DGSeq[11, Rw].Value = false;                   
                    DGSeq[12, Rw].Value = rd.GetValue(12).ToString();
                    DGSeq[13, Rw].Value = rd.GetValue(13).ToString();
                    if (rd.GetValue(14).ToString() == "Y") DGSeq[14, Rw].Value = true; else DGSeq[14, Rw].Value = false;
                    if (rd.GetValue(15).ToString() == "Y") DGSeq[15, Rw].Value = true; else DGSeq[15, Rw].Value = false;
                    if (rd.GetValue(16).ToString() == "Y") DGSeq[16, Rw].Value = true; else DGSeq[16, Rw].Value = false;                   
                    DGSeq[17, Rw].Value = rd.GetValue(17).ToString();
                    DGSeq[18, Rw].Value = rd.GetValue(18).ToString();
                    DGSeq[19, Rw].Value = rd.GetValue(19).ToString();
                    DGSeq[20, Rw].Value = rd.GetValue(20).ToString();
                    DGSeq[21, Rw].Value = rd.GetValue(21).ToString();
                    DGSeq[22, Rw].Value = rd.GetValue(22).ToString();
                    DGSeq[23, Rw].Value = rd.GetValue(23).ToString();
                    DGSeq[24, Rw].Value = rd.GetValue(24).ToString();
                    DGSeq[25, Rw].Value = rd.GetValue(25).ToString();
                    DGSeq[26, Rw].Value = rd.GetValue(26).ToString();
                    if (rd.GetValue(27).ToString() == "Y") DGSeq[27, Rw].Value = true; else DGSeq[27, Rw].Value = false;

                    Rw += 1;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Check Load Gris Function :  Error Code :Error Code:- 13003" + ex.Message);
                }
            }
            Common.conSeq.Close();
        }

        private void LoadInCell()
        {
            try
            {
                Rn = DGSeq.CurrentRow.Index;

                switch (DGSeq[1, Rn].Value.ToString())
                {
                    case "1":
                        UPD.SelectedIndex = 0;
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = false;
                        break;
                    case "2":
                        UPD.SelectedIndex = 1;
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = false;
                        DOut4.Checked = true;
                        DOut5.Checked = false;
                        break;
                    case "3":
                        UPD.SelectedIndex = 2;
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = true;
                        DOut4.Checked = true;
                        DOut5.Checked = false;
                        break;
                    case "4":
                        UPD.SelectedIndex = 3;
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = false;
                        DOut4.Checked = false;
                        DOut5.Checked = true;
                        break;
                    case "5":
                        UPD.SelectedIndex = 4;
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = true;
                        break;
                    case "6":
                        UPD.SelectedIndex = 5;
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = false;
                        DOut4.Checked = true;
                        DOut5.Checked = true;
                        break;
                    case "7":
                        UPD.SelectedIndex = 6;
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = true;
                        break;
                    default:
                        UPD.SelectedIndex = 0;
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = false;
                        break;
                }

                lblStep.Text = (Rn + 1).ToString("000");
                txtSetpt4.Text = DGSeq[2, Rn].Value.ToString();
                txtSetpt2.Text = DGSeq[4, Rn].Value.ToString();

                txtRamp1.Text = DGSeq[3, Rn].Value.ToString();
                txtRamp2.Text = DGSeq[5, Rn].Value.ToString();

                txtStab.Text = DGSeq[6, Rn].Value.ToString();
                txtSteady.Text = DGSeq[7, Rn].Value.ToString();
                //Stop Time
                String Tx;
                Tx = DGSeq[8, Rn].Value.ToString();
                if (Tx.Substring(0, 1) == "S")
                {
                    chkStop.Checked = true;
                    txtStop.Text = (Tx.Substring(1, (Tx.Length - 1)));
                    lblStop.Enabled = true;
                    txtStop.Enabled = true;
                }
                else
                {
                    chkStop.Checked = false;
                    txtStop.Text = "00.00";
                    lblStop.Enabled = false;
                    txtStop.Enabled = false;
                }
                //Repeate Loop
                Tx = DGSeq[9, Rn].Value.ToString();
                if (Tx.Substring(3, 1).ToUpper() == "R")
                {
                    chkRepeat.Checked = true;
                    txtFrom.Text = Tx.Substring(0, 3);
                    txtLoops.Text = Tx.Substring(4, 3);
                    txtFrom.Enabled = true;
                    txtLoops.Enabled = true;
                    lblFromStep.Enabled = true;
                    lblNoLoop.Enabled = true;
                }
                else
                {
                    chkRepeat.Checked = false;
                    txtFrom.Text = "000";
                    txtLoops.Text = "000";
                    txtFrom.Enabled = false;
                    txtLoops.Enabled = false;
                    lblFromStep.Enabled = false;
                    lblNoLoop.Enabled = true;
                }
                //Log Reading
                Tx = DGSeq[10, Rn].Value.ToString();

                switch (Tx.Substring(0, 1).ToUpper())
                {
                    case "N":
                        Disable_LogOptions();
                        chkLog.Checked = false;
                        optStep.Checked = false;
                        optInst.Checked = false;
                        optFly.Checked = false;
                        optIdle.Checked = false;
                        optAvg.Checked = false;
                        break;
                    case "L":
                        chkLog.Checked = true;
                        optInst.Checked = false;
                        optStep.Checked = false;
                        optInst.Checked = false;
                        optFly.Checked = false;
                        optIdle.Checked = true;
                        optAvg.Checked = false;
                        break;
                    case "H":
                        chkLog.Checked = true;
                        optIdle.Enabled = false;
                        optInst.Checked = false;
                        optStep.Checked = false;
                        optInst.Checked = false;
                        optFly.Checked = true;
                        optAvg.Checked = false;
                        break;
                    case "Y":
                        chkLog.Checked = true;
                        optStep.Enabled = true;
                        optInst.Checked = false;
                        optStep.Checked = true;
                        optIdle.Checked = false;
                        optFly.Checked = false;
                        optAvg.Checked = false;
                        break;
                    case "I":
                        chkLog.Checked = true;
                        optInst.Checked = true;
                        optStep.Checked = false;
                        optIdle.Checked = false;
                        optFly.Checked = false;
                        optAvg.Checked = false;
                        break;
                    case "A":
                        chkLog.Checked = true;
                        optAvg.Checked = true;
                        optStep.Checked = false;
                        optIdle.Checked = false;
                        optFly.Checked = false;
                        optInst.Checked = false;
                        switch (Tx.Substring(1, (Tx.Length - 1)))
                        {
                            case "00.00":
                                txtPInst.Text = "00.00";
                                txtPInst.Enabled = false;
                                break;
                            default:
                                txtPInst.Text = Tx.Substring(1, (Tx.Length - 1));
                                txtPInst.Enabled = true;
                                break;
                        }
                        break;

                }

                //SFC 
                //Tx = DGSeq[11, Rn].Value.ToString();
                if (Convert.ToBoolean(DGSeq[11, Rn].Value) == true) chkSMK.Checked = true; else chkSMK.Checked = false;
                if (Convert.ToBoolean(DGSeq[16, Rn].Value) == true) chkSFC.Checked = true; else chkSFC.Checked = false;


                //        'MinSFC Time
                txtMinLub.Text = DGSeq[12, Rn].Value.ToString();
                //        'Min Power
                if (DGSeq[13, Rn].Value.ToString()  == "000")
                    txtMaxVal.Text = "None";
                else
                   txtMaxVal.Text = DGSeq[13, Rn].Value.ToString() + " " + "Hz";

                //        'Cold Water ON/OFF

                if (Convert.ToBoolean(DGSeq[14, Rn].Value) == true) DOut10.Checked = true; else DOut10.Checked = false;
                if (Convert.ToBoolean(DGSeq[15, Rn].Value) == true) DOut14.Checked = true; else DOut14.Checked = false;
                //if (Convert.ToBoolean(DGSeq[16, Rn].Value) == true) DOut15.Checked = true; else DOut15.Checked = false;
                txtComment.Text = (DGSeq[17, Rn].Value.ToString());

                int T = 0;
                Int32 Tc = 0;
                for (T = 0; T <= (Rn); T++)
                {
                    Tc = Tc + Convert.ToInt32(DGSeq[18, T].Value);
                }
                TimeSpan t = TimeSpan.FromSeconds(Tc);

                label13.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds);

                textBox1.Text = (DGSeq[19, Rn].Value.ToString());
                textBox2.Text = (DGSeq[20, Rn].Value.ToString());
                textBox3.Text = (DGSeq[21, Rn].Value.ToString());
                textBox4.Text = (DGSeq[22, Rn].Value.ToString());
                textBox5.Text = (DGSeq[23, Rn].Value.ToString());
                textBox6.Text = (DGSeq[24, Rn].Value.ToString());
                textBox7.Text = (DGSeq[25, Rn].Value.ToString());
                textBox8.Text = (DGSeq[26, Rn].Value.ToString());
                if (Convert.ToBoolean(DGSeq[27, Rn].Value) == true) checkBox1.Checked = true; else checkBox1.Checked = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Check Load Grid Function :  Error Code :Error Code 13005" + ex.Message);
            }
        }

        private void Disable_LogOptions()
        {
            txtPInst.Enabled = false;
            txtPInst.Text = "00.00";
            lblPInst.Enabled = false;



        }



        private Boolean Check_validity(String LTime1, String GTime2)
        {
            int T1, T2 = 0;
            int T3, T4 = 0;
            try
            {
                T1 = (Convert.ToInt16(LTime1.Substring(0, 2)));
                T2 = ((T1 * 60) + Convert.ToInt16(LTime1.Substring(3, 2)));

                T3 = (Convert.ToInt16(GTime2.Substring(0, 2)));
                T4 = ((T3 * 60) + Convert.ToInt16(GTime2.Substring(3, 2)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Cdoe:- 13006", ex.Message);
            }
            if (T2 > (T4 - 1))
            {
                return (false);
            }
            else
            {
                return (true);
            }


        }
        private Boolean Check_avgvalidity(String LTime1, String GTime2)
        {

            int T1 = 0;
            int T3, T4 = 0;
            try
            {
                T1 = Convert.ToInt16(LTime1);// (Convert.ToInt16(LTime1.Substring(0, 2)));
                // T2 = ((T1 * 60) + Convert.ToInt16(LTime1.Substring(3, 2)));

                T3 = (Convert.ToInt16(GTime2.Substring(0, 2)));
                T4 = ((T3 * 60) + Convert.ToInt16(GTime2.Substring(3, 2)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 13007", ex.Message);
            }
            if (T1 > (T4 - 1))
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mnuDeleteFile.Enabled = false;
            try
            {
                if (optInst.Checked == true)
                {
                    Boolean St;
                    St = Check_validity(txtPInst.Text, txtSteady.Text);
                    if (St == false)
                    {
                        Ep.SetError(txtSteady, "Average logging time should be less than Steady time");
                        txtSteady.Focus();
                        return;
                    }
                }

                Ep.Clear();
                Save_InGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-13008", ex.Message);
            }
        }


        private void Save_InGrid()
        {           
            String Repeat, STEPNO, Mode, chnl2, RTime1, chnl1, RTime2, StabTime, SteadyTime;
            String stopTime, PF, MinLubP, MaxValue, Comment, Tol_Time;
            Boolean SMK, SFC, D10, D14, pass_of_limits;
            string minPow, maxSmoke, maxBi, Spare1, Spare2, Spare3, Spare4, Spare5;
            //String str,FullStep;
            int IdleRPM = 700;
            try
            {
                if (cmbSeq.Text == null)
                {
                    Ep.SetError(cmbSeq, "Type first the desired Name of the Sequence File !!");
                    cmbSeq.Focus();
                    return;
                }
                else
                {
                    Ep.Clear();
                }
                STEPNO = lblStep.Text;
                Mode = UPD.Text.Substring(1, 1);

                switch (Mode)
                {
                    case "1":
                        if ((Convert.ToDouble(txtSetpt4.Text.Trim())) >= 100) txtSetpt4.Text = "99.99";
                        if ((Convert.ToDouble(txtSetpt2.Text.Trim())) >= 100) txtSetpt2.Text = "99.99";
                        break;
                    case "2":
                        if (int.Parse(txtSetpt4.Text) < IdleRPM)
                        {
                            Ep.SetError(txtSetpt4, "Value should be more then 'IDLE RPM' :" + IdleRPM);
                            txtSetpt4.Focus();
                            return;
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        if (int.Parse(txtSetpt4.Text) < IdleRPM)
                        {
                            Ep.SetError(txtSetpt4, "Value should be more then 'IDLE RPM' :" + IdleRPM);
                            txtSetpt4.Focus();
                            return;
                        }
                        break;
                    case "5":
                    case "6":
                    case "7":


                        if (int.Parse(txtSetpt4.Text) < IdleRPM)
                        {
                            Ep.SetError(txtSetpt4, "Value should be more then 'IDLE RPM' :" + IdleRPM);
                            txtSetpt4.Focus();
                            return;
                        }
                        break;
                }
                Ep.Clear();

                chnl1 = txtSetpt4.Text;
                chnl2 = txtSetpt2.Text;
                RTime1 = txtRamp1.Text;
                RTime2 = txtRamp2.Text;

                StabTime = String.Format(txtStab.Text, "00.00");
                SteadyTime = String.Format(txtSteady.Text, "00.00");
                //StabTime = txtStab.Text.ToString("00.00");
                //SteadyTime = txtSteady.Text.ToString("00.00");



                //Stop Time
                if (chkStop.Checked == true) stopTime = "S" + txtStop.Text.Trim() + " "; else stopTime = "N00.00 ";

                //Log Reading
                PF = "N00.00";
                if (chkLog.Checked == true)
                {
                    if (optStep.Checked == true) PF = "Y00.00";
                    else if (optInst.Checked == true) PF = "I" + txtPInst.Text;
                    else if (optAvg.Checked == true) PF = "A" + txtPAvg.Text;
                    else if (optFly.Checked == true) PF = "H00.00";
                    else if (optIdle.Checked == true) PF = "L00.00";
                    else PF = "N00.00";

                }

                int R1 = (Convert.ToInt16(RTime1.Substring(0, 2)) * 60) + Convert.ToInt16(RTime1.Substring(3, 2));
                int R2 = (Convert.ToInt16(RTime2.Substring(0, 2)) * 60) + Convert.ToInt16(RTime2.Substring(3, 2));
                int Sb = (Convert.ToInt16(StabTime.Substring(0, 2)) * 60) + Convert.ToInt16(StabTime.Substring(3, 2));
                int Sd = (Convert.ToInt16(SteadyTime.Substring(0, 2)) * 60) + Convert.ToInt16(SteadyTime.Substring(3, 2));
                int st = (Convert.ToInt16(stopTime.Substring(1, 2)) * 60) + Convert.ToInt16(stopTime.Substring(4, 2));
                int R = 0;
                if (R1 > R2) R = R1; else R = R2;

                Tol_Time = (R + Sb + Sd + st).ToString(); 



                //'Repeat Loop
                if (chkRepeat.Checked == true)
                {
                    Repeat = txtFrom.Text.Trim() + "R" + txtLoops.Text.Trim();
                }
                else
                {
                    Repeat = "000N000";
                }

                //SFC
                if (chkSFC.Checked == true)
                {
                    SFC = true;
                }
                else
                {
                    SFC = false;
                }
                if (chkSMK.Checked == true)
                {
                    SMK = true;
                }
                else
                {
                    SMK = false;
                }


                //'Min SFC Time for 100g
                MinLubP = txtMinLub.Text;

                //'Min Pow
                if (txtMaxVal.Text == "None")
                    MaxValue = "000";
                else
                    MaxValue = txtMaxVal.Text.Substring(0,3) ;

                //'Cold Water On/OFF
                if (DOut10.Checked == true) D10 = true; else D10 = false;
                if (DOut14.Checked == true) D14 = true; else D14 = false;
                //if (DOut15.Checked == true) D15 = true; else D15 = false;

                Comment = txtComment.Text;
                if (textBox1.Text == "") minPow = "NA"; else minPow = textBox1.Text;
                if (textBox2.Text == "") maxSmoke = "NA"; else maxSmoke = textBox2.Text;
                if (textBox3.Text == "") maxBi = "NA"; else maxBi = textBox3.Text;
                if (textBox4.Text == "") Spare1 = "NA"; else Spare1 = textBox4.Text;
                if (textBox5.Text == "") Spare2 = "NA"; else Spare2 = textBox5.Text;
                if (textBox6.Text == "") Spare3 = "NA"; else Spare3 = textBox6.Text;
                if (textBox7.Text == "") Spare4 = "NA"; else Spare4 = textBox7.Text;
                if (textBox8.Text == "") Spare5 = "NA"; else Spare5 = textBox8.Text;
                if (checkBox1.Checked == true) pass_of_limits = true; else pass_of_limits = false;
                if ((Mode == "5") || (Mode == "6") || (Mode == "2") || (Mode == "4"))
                {
                    DGSeq[0, Rn].Value = STEPNO;
                    DGSeq[1, Rn].Value = Mode;
                    DGSeq[2, Rn].Value = chnl1;
                    DGSeq[3, Rn].Value = RTime1;
                    DGSeq[4, Rn].Value = chnl2;
                    DGSeq[5, Rn].Value = RTime2;
                    DGSeq[6, Rn].Value = StabTime;
                    DGSeq[7, Rn].Value = SteadyTime;
                    DGSeq[8, Rn].Value = stopTime;
                    DGSeq[9, Rn].Value = Repeat;
                    DGSeq[10, Rn].Value = PF;
                    DGSeq[11, Rn].Value = SMK;
                    DGSeq[12, Rn].Value = MinLubP;
                    DGSeq[13, Rn].Value = MaxValue;
                    DGSeq[14, Rn].Value = D10;
                    DGSeq[15, Rn].Value = D14;
                    DGSeq[16, Rn].Value = SFC;
                    DGSeq[17, Rn].Value = Comment;
                    DGSeq[18, Rn].Value = Tol_Time;
                    DGSeq[19, Rn].Value = minPow;
                    DGSeq[20, Rn].Value = maxSmoke;
                    DGSeq[21, Rn].Value = maxBi;
                    DGSeq[22, Rn].Value = Spare1;
                    DGSeq[23, Rn].Value = Spare2;
                    DGSeq[24, Rn].Value = Spare3;
                    DGSeq[25, Rn].Value = Spare4;
                    DGSeq[26, Rn].Value = Spare5;
                    DGSeq[27, Rn].Value = pass_of_limits;

                }
                else
                {
                    DGSeq[0, Rn].Value = STEPNO;
                    DGSeq[1, Rn].Value = Mode;
                    DGSeq[2, Rn].Value = chnl1;
                    DGSeq[3, Rn].Value = RTime1;
                    DGSeq[4, Rn].Value = chnl2;
                    DGSeq[5, Rn].Value = RTime2;
                    DGSeq[6, Rn].Value = StabTime;
                    DGSeq[7, Rn].Value = SteadyTime;
                    DGSeq[8, Rn].Value = stopTime;
                    DGSeq[9, Rn].Value = Repeat;
                    DGSeq[10, Rn].Value = PF;
                    DGSeq[11, Rn].Value = SMK;
                    DGSeq[12, Rn].Value = MinLubP;
                    DGSeq[13, Rn].Value = MaxValue;
                    DGSeq[14, Rn].Value = D10;
                    DGSeq[15, Rn].Value = D14;
                    DGSeq[16, Rn].Value = SFC;
                    DGSeq[17, Rn].Value = Comment;
                    DGSeq[18, Rn].Value = Tol_Time;
                    DGSeq[19, Rn].Value = minPow;
                    DGSeq[20, Rn].Value = maxSmoke;
                    DGSeq[21, Rn].Value = maxBi;
                    DGSeq[22, Rn].Value = Spare1;
                    DGSeq[23, Rn].Value = Spare2;
                    DGSeq[24, Rn].Value = Spare3;
                    DGSeq[25, Rn].Value = Spare4;
                    DGSeq[26, Rn].Value = Spare5;
                    DGSeq[27, Rn].Value = pass_of_limits;
                }
                btnAdd.Enabled = true;

                if (DGSeq.CurrentRow.Index < (DGSeq.RowCount - 1))
                {
                    DGSeq.CurrentCell = DGSeq[0, (Rn + 1)];
                }
                else
                {
                    DGSeq.CurrentCell = DGSeq[0, Rn];
                }
                LoadInCell();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Save on gird Function :Error Code:- 13006 ", ex.Message);

            }


        }

        private void Key_Validation(int KeyAscii)
        {
            if ((((KeyAscii > 47) && (KeyAscii < 58)) || ((KeyAscii == 8) || (KeyAscii == 46))))
            {
                //  Or KeyAscii = 45 Or'select only numbers, fullstop,backspace
                // EP.Clear()
            }
            else
            {
                SendKeys.Send(("{+}" + "{HOME}"));
                MessageBox.Show("Only Numbers are Allowed  & Not !!");
                SendKeys.Send("{BACKSPACE}");
            }
        }

        private void txtRamp2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRamp2.Text != "")
                {
                    Ep.Clear();
                    String MyString, StrMM, StrSS;
                    Decimal l = Convert.ToDecimal(txtRamp2.Text);
                    MyString = l.ToString("00.00");
                    txtRamp2.Text = MyString;
                    StrMM = String.Format(MyString.Substring(0, 2), "00");
                    StrSS = String.Format(MyString.Substring(3, 2), "00");
                    if (int.Parse(StrSS) >= 60)
                    {
                        StrMM = (int.Parse(StrMM) + 1).ToString();
                        StrMM = String.Format(StrMM, "00");
                        StrSS = (int.Parse(StrSS) - 60).ToString();
                        StrSS = string.Format(StrSS, "00");
                    }
                    MyString = StrMM + "." + StrSS;
                    txtRamp2.Text = String.Format(MyString, "00.00");
                }
                else
                {
                    Ep.SetError(txtRamp2, "Emeter the value first Only in mm.ss");
                    txtRamp2.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("txtramp_leave  Error Code:- 13010 ", ex.Message);
            }

        }

        private void txtStab_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtStab.Text != "")
                {
                    String MyString, StrMM, StrSS;
                    Decimal l = Convert.ToDecimal(txtStab.Text);
                    //if ((int)l >= 100) l = 99;
                    MyString = l.ToString("00.00");
                    txtStab.Text = MyString;

                    StrMM = String.Format(MyString.Substring(0, 2), "00");
                    StrSS = String.Format(MyString.Substring(3, 2), "00");
                    if (int.Parse(StrSS) >= 60)
                    {
                        StrMM = (int.Parse(StrMM) + 1).ToString("00");
                        StrMM = String.Format(StrMM, "00");
                        StrSS = (int.Parse(StrSS) - 60).ToString();
                        StrSS = string.Format(StrSS, "00");
                    }
                    MyString = StrMM + "." + StrSS;
                    txtStab.Text = String.Format(MyString, "00.00");

                }
                else
                {
                    Ep.SetError(txtStab, " Enter the value first Only in mm.ss");
                    txtStab.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tsts Stab Leave @ Error Code:-13011", ex.Message);
            }

        }

        private void txtSteady_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtSteady.Text)))
                {
                    char[] chars = txtSteady.Text.ToCharArray();
                    for (int i = 0; i < txtSteady.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtSteady.Text = txtSteady.Text.Remove(i, 1);
                            txtSteady.SelectionStart = txtSteady.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 13026", ex.Message);
            }
        }

        private void txtSteady_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSteady.Text != "")
                {

                    String MyString, StrMM, StrSS;
                    Decimal l = Convert.ToDecimal(txtSteady.Text);
                    if ((int)l >= 100) l = 99;
                    MyString = l.ToString("00.00");
                    txtSteady.Text = MyString;

                    StrMM = String.Format(MyString.Substring(0, 2), "00");
                    StrSS = String.Format(MyString.Substring(3, 2), "00");
                    if (int.Parse(StrSS) >= 60)
                    {
                        StrMM = (int.Parse(StrMM) + 1).ToString("00");
                        StrMM = String.Format(StrMM, "00");
                        StrSS = (int.Parse(StrSS) - 60).ToString("00");
                        StrSS = string.Format(StrSS, "00");
                    }
                    MyString = StrMM + "." + StrSS;
                    txtSteady.Text = String.Format(MyString, "00.00");
                }
                else
                {
                    Ep.SetError(txtSteady, " Enter the value first Only in mm.ss");
                    txtSteady.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtSteady_Leave  Error Code:- 13012", ex.Message);
            }

        }

        private void txtStop_Layout(object sender, LayoutEventArgs e)
        {
           

        }

        private void optInst_CheckedChanged(object sender, EventArgs e)
        {
            if (optInst.Checked == true)
            {
                Disable_LogOptions();
                txtPInst.Enabled = true;
                txtPInst.Text = "00.00";
                txtPInst.Enabled = true;
                Ep.Clear();
            }
            if (optInst.Checked == true)
            {
                txtPInst.Enabled = true;
                txtPInst.Focus();
            }
            else
            {
                txtPInst.Enabled = false;
            }

        }

        private void optStep_CheckedChanged(object sender, EventArgs e)
        {
            if (optStep.Checked == true) Ep.Clear(); // Disable_Log
        }

        private void chkStop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStop.Checked == true)
            {
                txtStop.Enabled = true;
                txtStop.Text = "00.05";
                lblStop.Enabled = true;
            }
            else
            {
                txtStop.Enabled = false;
                txtStop.Text = "00.00";
                lblStop.Enabled = false;
            }
        }

        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepeat.Checked == true)
            {
                txtFrom.Enabled = true;
                txtLoops.Enabled = true;
                lblFromStep.Enabled = true;
                lblNoLoop.Enabled = true;
            }
            else
            {
                txtFrom.Enabled = false;
                txtLoops.Enabled = false;
                lblFromStep.Enabled = false;
                lblNoLoop.Enabled = false;
            }
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLog.Checked == true)
            {
                optStep.Enabled = true;
                optInst.Enabled = true;
                optAvg.Enabled = false;
                //optSingleAvg.Enabled = true;
                optFly.Enabled = true;
                optIdle.Enabled = true;
                optStep.Checked = true;
            }

            else
            {
                optStep.Enabled = false;
                optInst.Enabled = false;
                optAvg.Enabled = false;
                //optSingleAvg.Enabled = false;
                optFly.Enabled = false;
                optIdle.Enabled = false;
                optStep.Checked = false;
            }
        }

        public void Save()
        {
            try
            {
                String val1 = "0";
                String val2 = "0"; 
                String val3 = "0"; 
                String val4 = "0";
                String val5 = "0";

                Common.Open_Connection("seq_db", "conSeq");

                MySqlCommand cmdTb = new MySqlCommand();
                String StrTb = " StepNo Float primary key,Mode VARCHAR(2),SetPt1 VARCHAR(5), RTime1 VARCHAR(6)," +
                               " SetPt2 VARCHAR(5), RTime2 VARCHAR(6),StabTime VARCHAR(6),SteadyTime VARCHAR(6)," +
                               " StopTime VARCHAR(6), RepeatLoop VARCHAR(7),LogData VARCHAR(6),SMKEvents VARCHAR(1)," + // ,bit," + //VARCHAR(6)," +  /
                               " MinLubP VARCHAR(7), MaxVal VARCHAR(7),DO10  VARCHAR(1),DO14 VARCHAR(1),DO15 VARCHAR(1)," +
                               " Comments VARCHAR(30),TM_Step VARCHAR(8),Min_Pow VARCHAR(6),Max_SMK VARCHAR(6)," +
                               " Max_FD VARCHAR(6),Spare_1 VARCHAR(6),Spare_2 VARCHAR(6),Spare_3 VARCHAR(6),Spare_4 VARCHAR(6),Spare_5 VARCHAR(6), pass_of_limit  VARCHAR(1)";

                cmdTb.CommandText = "CREATE TABLE " + cmbSeq.Text.ToLower()  + "(" + StrTb + ")";
                cmdTb.Connection = Common.conSeq;
                cmdTb.ExecuteNonQuery();
                Common.conSeq.Close();
                int i = 0;
                Common.Open_Connection("seq_db", "conSeq");
                MySqlCommand cmd1 = new MySqlCommand();
                for (i = 0; i < (DGSeq.RowCount); i++)
                {
                    if (Convert.ToBoolean(DGSeq[11, i].Value) == true) val1 = "Y"; else val1 = "N";
                    if (Convert.ToBoolean(DGSeq[14, i].Value) == true) val2 = "Y"; else val2 = "N";
                    if (Convert.ToBoolean(DGSeq[15, i].Value) == true) val3 = "Y"; else val3 = "N";
                    if (Convert.ToBoolean(DGSeq[16, i].Value) == true) val4 = "Y"; else val4 = "N";
                    if (Convert.ToBoolean(DGSeq[27, i].Value) == true) val5 = "Y"; else val5 = "N";

                    cmd1.CommandText = "INSERT INTO " + cmbSeq.Text.ToLower()  + " VALUES ('" +
                        DGSeq[0, i].Value.ToString() + "','" +
                        DGSeq[1, i].Value.ToString() + "','" +
                        DGSeq[2, i].Value.ToString() + "','" +
                        DGSeq[3, i].Value.ToString() + "','" +
                        DGSeq[4, i].Value.ToString() + "','" +
                        DGSeq[5, i].Value.ToString() + "','" +
                        DGSeq[6, i].Value.ToString() + "','" +
                        DGSeq[7, i].Value.ToString() + "','" +
                        DGSeq[8, i].Value.ToString() + "','" +
                        DGSeq[9, i].Value.ToString() + "','" +
                        DGSeq[10, i].Value.ToString() + "','" +
                        val1.ToString() + "','" +
                        DGSeq[12, i].Value.ToString() + "','" +
                        DGSeq[13, i].Value.ToString() + "','" +
                        val2.ToString() + "','" +
                        val3.ToString() + "','" +
                        val4.ToString() + "','" +
                        DGSeq[17, i].Value.ToString() + "','" +
                        DGSeq[18, i].Value.ToString() + "','" +
                        DGSeq[19, i].Value.ToString() + "','" +
                        DGSeq[20, i].Value.ToString() + "','" +
                        DGSeq[21, i].Value.ToString() + "','" +
                        DGSeq[22, i].Value.ToString() + "','" +
                        DGSeq[23, i].Value.ToString() + "','" +
                        DGSeq[24, i].Value.ToString() + "','" +
                        DGSeq[25, i].Value.ToString() + "','" +
                        DGSeq[26, i].Value.ToString() + "','" +
                        val5.ToString() + "')";

                    cmd1.Connection = Common.conSeq;
                    cmd1.ExecuteNonQuery();
                }
                Common.conSeq.Close();
            }
            catch (Exception ex)
             {
                MessageBox.Show(" Check Save Function : Error Code:- 13017", ex.Message);
            }

        }

        private void txtSetpt2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSetpt2.Text != "")
                {
                    Ep.Clear();
                    switch (UPD.Text.Substring(1, 1))
                    {
                        case "1":
                        case "2":
                        case "5":
                            if (Convert.ToDecimal(txtSetpt2.Text) >= 100) txtSetpt2.Text = "99.99";
                            Double l = Convert.ToDouble(txtSetpt2.Text);
                            txtSetpt2.Text = l.ToString("00.00");
                            break;
                        case "3":
                        case "4":
                        case "6":
                            if (Convert.ToDecimal(txtSetpt2.Text) >= 1000) txtSetpt2.Text = "999.9";
                            l = Convert.ToDouble(txtSetpt2.Text);
                            txtSetpt2.Text = l.ToString("000.0");
                            break;
                    }
                }
                else
                {
                    Ep.SetError(txtSetpt2, " Enter the value first");
                    txtSetpt2.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 13019", ex.Message);
            }

        }

        private void txtSetpt4_Leave(object sender, EventArgs e)
        {
            if (txtSetpt4.Text == "")
            {
                Ep.SetError(txtSetpt4, " Enter the value first");
                txtSetpt4.Focus();
            }
            else
            {
                Ep.Clear();
            }
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            if (txtFrom.Text == "")
            {
                Ep.SetError(txtFrom, "enter the value first");
                txtFrom.Focus();
            }
            else
            {
                Double l = Convert.ToDouble(txtFrom.Text);
                txtFrom.Text = l.ToString("000");
                Ep.Clear();
            }
        }

        private void txtLoops_Leave(object sender, EventArgs e)
        {
            if (txtLoops.Text == "")
            {
                Ep.SetError(txtLoops, "Enter the value first");
                txtLoops.Focus();
            }
            else
            {
                Double l = Convert.ToDouble(txtLoops.Text);
                txtLoops.Text = l.ToString("000");
                Ep.Clear();
            }
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            if (txtComment.Text == "")
            {
                Ep.SetError(txtComment, "Enter the value first");
                txtComment.Focus();
            }
            else
            {
                Ep.Clear();
            }
        }

        private void txtRamp1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRamp1.Text != "")
                {
                    Ep.Clear();

                    String MyString, StrMM, StrSS;

                    Double l = Convert.ToDouble(txtRamp1.Text);
                    MyString = l.ToString("00.00");
                    txtRamp1.Text = String.Format(MyString, "00.00");
                    StrMM = String.Format(MyString.Substring(0, 2), "00");
                    StrSS = String.Format(MyString.Substring(3, 2), "00");
                    if (int.Parse(StrSS) >= 60)
                    {
                        StrMM = (int.Parse(StrMM) + 1).ToString();
                        StrMM = String.Format(StrMM, "00");
                        StrSS = (int.Parse(StrSS) - 60).ToString();
                        StrSS = string.Format(StrSS, "00");
                    }
                    MyString = StrMM + "." + StrSS;
                    txtRamp1.Text = String.Format(MyString, "00.00");
                }
                else
                {
                    Ep.SetError(txtRamp1, "Eneter the value first in mm:ss");
                    txtRamp1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 13020", ex.Message);
            }

        }

        private void txtRamp1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtRamp1.Text)))
                {
                    char[] chars = txtRamp1.Text.ToCharArray();
                    for (int i = 0; i < txtRamp1.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtRamp1.Text = txtRamp1.Text.Remove(i, 1);
                            txtRamp1.SelectionStart = txtRamp1.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txRamp1 Text changed  Error Code:- 13021", ex.Message);
            }
        }

        private void txtSetpt4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtSetpt4.Text)))
                {
                    char[] chars = txtSetpt4.Text.ToCharArray();
                    for (int i = 0; i < txtSetpt4.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtSetpt4.Text = txtSetpt4.Text.Remove(i, 1);
                            txtSetpt4.SelectionStart = txtSetpt4.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtSetpt4_TextChanged @ Error  Code:- 13022", ex.Message);
            }
        }

        private void txtSetpt2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtSetpt2.Text)))
                {
                    char[] chars = txtSetpt2.Text.ToCharArray();
                    for (int i = 0; i < txtSetpt2.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtSetpt2.Text = txtSetpt2.Text.Remove(i, 1);
                            txtSetpt2.SelectionStart = txtSetpt2.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtSetpt2_TextChanged @ Error Code:- 13023:", ex.Message);
            }

        }

        private void txtRamp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtRamp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtSetpt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtSetpt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtRamp2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtRamp2.Text)))
                {
                    char[] chars = txtRamp2.Text.ToCharArray();
                    for (int i = 0; i < txtRamp2.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtRamp2.Text = txtRamp2.Text.Remove(i, 1);
                            txtRamp2.SelectionStart = txtRamp2.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtsramp2 _Tex t Changed @ Error Code:- 12024:", ex.Message);
            }
        }

        private void txtStab_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtStab.Text)))
                {
                    char[] chars = txtStab.Text.ToCharArray();
                    for (int i = 0; i < txtStab.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtStab.Text = txtStab.Text.Remove(i, 1);
                            txtStab.SelectionStart = txtStab.Text.Length;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("txtStab_TextChanged @ Error  Code:- 13025", ex.Message);
            }

        }

        private void txtStop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtStop.Text)))
                {
                    char[] chars = txtStop.Text.ToCharArray();
                    for (int i = 0; i < txtStop.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtStop.Text = txtStop.Text.Remove(i, 1);
                            txtStop.SelectionStart = txtStop.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" txtStop_TextChanged @ Error Code:- 13030", ex.Message);
            }
        }

        private void txtLoops_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtLoops.Text)))
                {
                    char[] chars = txtLoops.Text.ToCharArray();
                    for (int i = 0; i < txtLoops.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48))))
                        {
                            txtLoops.Text = txtLoops.Text.Remove(i, 1);
                            txtLoops.SelectionStart = txtLoops.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtLoops_TextChanged @ Error Code:- 13031", ex.Message);
            }

        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPath + "Sequece.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        private void txtPInst_Leave(object sender, EventArgs e)
        {
            try
            {
                if (optInst.Checked == true)
                {
                    if ((txtPInst.Text != "") && (txtPInst.Text != "00.00"))
                    {
                        String MyString, StrMM, StrSS;
                        Decimal l = Convert.ToDecimal(txtPInst.Text);
                        if ((int)l >= 100) l = 99;
                        MyString = l.ToString("00.00");

                        StrMM = String.Format(MyString.Substring(0, 2), "00");
                        StrSS = String.Format(MyString.Substring(3, 2), "00");
                        if (int.Parse(StrSS) >= 60)
                        {
                            StrMM = (int.Parse(StrMM) + 1).ToString("00");
                            StrMM = String.Format(StrMM, "00");
                            StrSS = (int.Parse(StrSS) - 60).ToString("00");
                            StrSS = string.Format(StrSS, "00");
                        }
                        MyString = StrMM + "." + StrSS;
                        if (((Convert.ToInt16(StrMM) * 60) + Convert.ToInt16(StrSS)) < 35)
                        {
                            Ep.SetError(txtPInst, " Enter the value More then 35s for Avg OR Instantanious Data...");
                            return;
                        }
                        else
                            txtPInst.Text = String.Format(MyString, "00.00");
                    }
                    else
                    {
                        Ep.SetError(txtPInst, " Enter the value first More then 35s for Avg OR Instantanious Data...");
                    }
                }
                else
                    Ep.Clear(); // SetError(txtPInst, " Enter the value first More then 35s");
            }
            catch (Exception)
            {

               
                return;
            }
        }

        private void txtPInst_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtPInst.Text)))
                {
                    char[] chars = txtPInst.Text.ToCharArray();
                    for (int i = 0; i < txtPInst.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtPInst.Text = txtPInst.Text.Remove(i, 1);
                            txtPInst.SelectionStart = txtPInst.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" txtPInst_TextChanged @ Error Code:- 13032", ex.Message);
            }
        }

        private void txtPInst_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtPAvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }
        private void txtStop_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtLoops_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtSteady_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void txtStab_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Validation(e.KeyChar);
        }

        private void UPD_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {

                switch (UPD.Text.Substring(0, 2))
                {
                    case ("01"):
                        lblSetPt1.Text = "Throttle Position:";
                        lblSetPt2.Text = "Curr. Position.:";
                        txtSetpt4.Text = "00.00";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = false;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("02"):
                        lblSetPt1.Text = "Rpm By Throttle:";
                        lblSetPt2.Text = "Cur.Position:";
                        txtSetpt4.Text = "0000";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = false;
                        DOut4.Checked = true;
                        DOut5.Checked = false;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("03"):
                        lblSetPt1.Text = "Throttle Position:";
                        lblSetPt2.Text = "Trq.by Dyno.:";
                        txtSetpt4.Text = "00.00";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = true;
                        DOut4.Checked = true;
                        DOut5.Checked = false;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("04"):
                        lblSetPt1.Text = "Rpm By Throttle:";
                        lblSetPt2.Text = "Trq.by Dyno.:";
                        txtSetpt4.Text = "0000";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = true;
                        DOut4.Checked = true;
                        DOut5.Checked = false;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("05"):
                        lblSetPt1.Text = "Rpm By Dyno.:";
                        lblSetPt2.Text = "Throttle Position:";
                        txtSetpt4.Text = "1000";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = true;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("06"):
                        lblSetPt1.Text = "Rpm By Dyno.:";
                        lblSetPt2.Text = "Trq. by Throttle:";
                        txtSetpt4.Text = "1000";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "Nm";
                        DOut3.Checked = false;
                        DOut4.Checked = true;
                        DOut5.Checked = true;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    case ("07"):
                        lblSetPt1.Text = "Rpm By Dyno.:";
                        lblSetPt2.Text = "Torque In %:";
                        txtSetpt4.Text = "1000";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "rpm";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = true;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                    default:
                        lblSetPt1.Text = "Throttle Position:";
                        lblSetPt2.Text = "Curr. Position.:";
                        txtSetpt4.Text = "00.00";
                        txtSetpt2.Text = "00.00";
                        lblUnit1.Text = "%";
                        lblUnit2.Text = "%";
                        DOut3.Checked = true;
                        DOut4.Checked = false;
                        DOut5.Checked = false;
                        txtRamp1.Text = "00.10";
                        txtRamp2.Text = "00.10";
                        txtStab.Text = "00.10";
                        txtSteady.Text = "00.30";

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UPD_SelectedItemChanged @ Error Code:- 13037", ex.Message);
            }

        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                mnuDeleteFile.Enabled = false;
                int i, j = 0;
                DGSeq.RowCount = (DGSeq.RowCount + 1);
                int Rc = (DGSeq.RowCount - 1);
                Rn = DGSeq.CurrentRow.Index;
                while (Rc > Rn)
                {
                    for (j = 0; j < (DGSeq.Columns.Count); j++)
                    {
                        DGSeq[j, Rc].Value = DGSeq[j, (Rc - 1)].Value;
                    }
                    Rc -= 1;
                }
                for (i = 0; i <= (DGSeq.Rows.Count - 1); i++)
                {
                    DGSeq[0, i].Value = (i + 1).ToString("000");
                }
                Common.Create_OnLog("Normal", "Step Inserted in File .....");
            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuInsert _Click @ Error Code:- 13014", ex.Message);
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result1 = MessageBox.Show("Do you Want to Delete selected step ?", "Important Question", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {                 
                    int i, j;
                    Rn = DGSeq.CurrentRow.Index;
                    label3.Text = DGSeq.CurrentRow.Index.ToString();
                    for (i = Rn; i < DGSeq.Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= (DGSeq.Columns.Count - 2); j++)
                        {
                            DGSeq[j, i].Value = DGSeq[j, (i + 1)].Value;
                        }
                    }
                    DGSeq.RowCount = DGSeq.RowCount - 1;
                    for (i = 0; i <= (DGSeq.Rows.Count - 1); i++)
                    {
                        DGSeq[0, i].Value = (i + 1).ToString("000");
                    }
                    label3.Text = DGSeq.CurrentRow.Index.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuDelete_Click @ Error Code;- 13015", ex.Message); 
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            mnuDeleteFile.Enabled = false;
            try
            {
                if (cmbSeq.Text.ToLower()  == "")
                {
                    MessageBox.Show("Give the Name for New File....");
                    cmbSeq.Focus();
                    return;
                }
                //**********************
                Common.Open_Connection("seq_db", "conSeq");
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'seq_db'", Common.conSeq);               
                using (MySqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        if ((string)reader1["TABLE_NAME"] == cmbSeq.Text.ToLower()) 
                        {
                            reader1.Close();
                            MySqlCommand cmd1 = new MySqlCommand();
                            cmd1.CommandText = ("Drop table " + cmbSeq.Text.Trim());
                            cmd1.Connection = Common.conSeq;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                            Common.conSeq.Close();
                            break;
                        }
                    }

                }

                Save();
                MessageBox.Show("New File saved .....");
                Common.conSeq.Close();
                fill_combo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuSave_Click @ Error Code :- 13016 " + ex.Message);
            }


        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            flg_new = true;
            mnuDeleteFile.Enabled = false;
            cmbSeq.Text = "";
            cmbSeq.Focus();
            DGSeq.Rows.Clear();
            DGSeq.RowCount = 1;
            DGSeq.ColumnCount = 28;
            DGSeq[0, 0].Value = "1";
            DGSeq[1, 0].Value = "1";
            DGSeq[2, 0].Value = "00.00";
            DGSeq[3, 0].Value = "00.10";
            DGSeq[4, 0].Value = "00.00";
            DGSeq[5, 0].Value = "00.10";
            DGSeq[6, 0].Value = "00.10";
            DGSeq[7, 0].Value = "00.10";
            DGSeq[8, 0].Value = "N00.00";
            DGSeq[9, 0].Value = "000N000";
            DGSeq[10, 0].Value = "N00.00";
            DGSeq[11, 0].Value = false;
            DGSeq[12, 0].Value = "0.000";
            DGSeq[13, 0].Value = "00.00";
            DGSeq[14, 0].Value = true;
            DGSeq[15, 0].Value = false;
            DGSeq[16, 0].Value = false;
            DGSeq[17, 0].Value = "COMMENT";
            DGSeq[18, 0].Value = "30";
            DGSeq[19, 0].Value = "NA";
            DGSeq[20, 0].Value = "NA";
            DGSeq[21, 0].Value = "NA";
            DGSeq[22, 0].Value = "NA";
            DGSeq[23, 0].Value = "NA";
            DGSeq[24, 0].Value = "NA";
            DGSeq[25, 0].Value = "NA";
            DGSeq[26, 0].Value = "NA";
            DGSeq[27, 0].Value = false;

        }

        private void mnuDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result1 = MessageBox.Show("Do you Want to Delete ?", "Important Question", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    Common.Open_Connection("seq_db", "conSeq");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = ("Drop table " + cmbSeq.Text.ToLower().Trim());
                    cmd.Connection = Common.conSeq;
                    cmd.ExecuteNonQuery();
                    Common.conSeq.Close();  
                    MessageBox.Show(" Deleted");
                }
                else
                {
                    MessageBox.Show("file Dose not Deleted");
                }

                fill_combo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuDeleteFile_Click @ Error Code:- 13036", ex.Message);
            }



        }

        private void cmbSeq_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Grid();
            LoadInCell();
        }

        private void cmbSeq_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.FormatCombo(cmbSeq);
                if (cmbSeq.Text.Length <= 4)
                {
                    Ep.SetError(cmbSeq, "Type the File Name First..." +
                                          "Name Should Be More Than 5 Characters");
                    cmbSeq.Focus();
                    return;
                }
                if (cmbSeq.Text.Length > 4)
                {
                    switch ((cmbSeq.Text.Substring(0, 4)))
                    {
                        case "seq_":
                            cmbSeq.Text = "seq_" + cmbSeq.Text.Substring(4).ToLower();
                            Ep.Clear();
                            break;
                        case "Seq_":
                            cmbSeq.Text = "seq_" + cmbSeq.Text.Substring(4).ToLower();
                            Ep.Clear();
                            break;
                        case "sEQ_":
                            cmbSeq.Text = "seq_" + cmbSeq.Text.Substring(4).ToLower();
                            Ep.Clear();
                            break;
                        default:
                            cmbSeq.Text = "seq_" + (cmbSeq.Text.ToLower());
                            Ep.Clear();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbSeq_Leave @ Error Code:- 13018", ex.Message);
            }

        }

        private void cmbSeq_DropDown(object sender, EventArgs e)
        {
            mnuDeleteFile.Enabled = true;
        }

        private void optIdle_CheckedChanged(object sender, EventArgs e)
        {
            Ep.Clear();
        }

        private void chkSMK_CheckedChanged(object sender, EventArgs e)
        {
            Ep.Clear();
        }

        private void DGSeq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rn = DGSeq.CurrentRow.Index;
            LoadInCell();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void optAvg_CheckedChanged(object sender, EventArgs e)
        {
            if (optAvg.Checked == true)
            {
                txtPAvg.Enabled = true;
                txtPAvg.Focus();
            }
            else
            {
                txtPAvg.Enabled = false;
            }


        }

        private void txtPAvg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtPAvg.Text)))
                {
                    char[] chars = txtPAvg.Text.ToCharArray();
                    for (int i = 0; i < txtPAvg.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            txtPAvg.Text = txtPAvg.Text.Remove(i, 1);
                            txtPAvg.SelectionStart = txtPAvg.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtPAvg_TextChanged @ Error Code:- 13032", ex.Message);
            }
        }

        private void txtPAvg_Leave(object sender, EventArgs e)
        {
            try
            {
                if (optAvg.Checked == true)
                {
                    if ((txtPAvg.Text != "") && (txtPAvg.Text != "00.00"))
                    {
                        String MyString, StrMM, StrSS;
                        Decimal l = Convert.ToDecimal(txtPAvg.Text);
                        if ((int)l >= 100) l = 99;
                        MyString = l.ToString("00.00");

                        StrMM = String.Format(MyString.Substring(0, 2), "00");
                        StrSS = String.Format(MyString.Substring(3, 2), "00");
                        if (int.Parse(StrSS) >= 60)
                        {
                            StrMM = (int.Parse(StrMM) + 1).ToString("00");
                            StrMM = String.Format(StrMM, "00");
                            StrSS = (int.Parse(StrSS) - 60).ToString("00");
                            StrSS = string.Format(StrSS, "00");
                        }
                        MyString = StrMM + "." + StrSS;
                        if (((Convert.ToInt16(StrMM) * 60) + Convert.ToInt16(StrSS)) < 5)
                        {
                            Ep.SetError(txtPAvg, " Enter the value More then 5s for Instantanious Data...");
                            return;
                        }
                        else
                            txtPAvg.Text = String.Format(MyString, "00.00");
                    }
                    else
                    {
                        Ep.SetError(txtPAvg, " Enter the value first More then 5s for Instantanious Data...");
                    }
                }
                else
                    Ep.Clear(); // SetError(txtPInst, " Enter the value first More then 35s");
            }
            catch (Exception)
            {
                return;
            }

        }

        private void DGSeq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtStop_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtStop.Text != "")
                {
                    Ep.Clear();
                    String MyString, StrMM, StrSS;
                    Decimal l = Convert.ToDecimal(txtStop.Text);
                    if ((int)l >= 100) l = 99;
                    MyString = l.ToString("00.00");

                    StrMM = String.Format(MyString.Substring(0, 2), "00");
                    StrSS = String.Format(MyString.Substring(3, 2), "00");
                    if (int.Parse(StrSS) >= 60)
                    {
                        StrMM = (int.Parse(StrMM) + 1).ToString("00");
                        StrMM = String.Format(StrMM, "00");
                        StrSS = (int.Parse(StrSS) - 60).ToString("00");
                        StrSS = string.Format(StrSS, "00");
                    }
                    MyString = StrMM + "." + StrSS;
                    txtStop.Text = String.Format(MyString, "00.00");
                }
                else
                {
                    Ep.SetError(txtStop, "Emeter the value first");
                    txtStop.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("txtStop_Leave @  Error Code:- 13013", ex.Message);
            }


        }
    }
}
