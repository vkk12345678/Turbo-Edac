using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace Logger
{
    public partial class frmSysCf : Form
    {
        MySqlDataAdapter Adp = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        int Rw = 0;
        String[] AdamArr = new string[20];
        string NodeT;
        public frmSysCf()
        {
            InitializeComponent();
        }

        private void SysCf_Load(object sender, EventArgs e)
        {
            int x = 0;
            LoadListboxes();
            dgPConf.RowCount = 16;
            dgPConf.ColumnCount = 10;

            dgPConf.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Global.Open_Connection("gen_db", "con");
            MySqlCommand cmd = new MySqlCommand("select * from tb_comPorts", Global.con);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                dgPConf[0, x].Value = rd.GetValue(0).ToString(); 
                dgPConf[1, x].Value = rd.GetValue(1).ToString();
                dgPConf[2, x].Value = rd.GetValue(2).ToString();
                dgPConf[3, x].Value = rd.GetValue(3).ToString();
                dgPConf[4, x].Value = rd.GetValue(4).ToString();
                dgPConf[5, x].Value = rd.GetValue(5).ToString();
                dgPConf[6, x].Value = rd.GetValue(6).ToString();
                dgPConf[7, x].Value = rd.GetValue(7).ToString();
                dgPConf[8, x].Value = rd.GetValue(8).ToString();
                dgPConf[9, x].Value = rd.GetValue(9).ToString();
                dgPConf[1, 14].Selected = true;  
                 x++;
            }

            loadInCell();
            //
            foreach (DataGridViewRow row in dgPConf.Rows)
            {
                Boolean st = Convert.ToBoolean(row.Cells[9].Value);
                //string RowType = row.Cells[0].Value.ToString();
                if (st == true)
                {
                    chkSelect.Text = "Selected";
                    chkSelect.CheckState = CheckState.Checked;
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
                else if (st == false)
                {
                    chkSelect.Text = "Not Selected";
                    chkSelect.CheckState = CheckState.Unchecked;
                    row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            tV1.ExpandAll(); 
            //DatagridIP.RowCount = 5;
            //DatagridIP[0, 0].Value = "ADAm-6018";
            //DatagridIP[0, 1].Value = "ADAm-6017";
            //DatagridIP[0, 2].Value = "Gantner Q-Gate";



        }
      
        private void loadInCell()
        {
            Rw = dgPConf.CurrentRow.Index;
            cmbDeviceName.Text = dgPConf[1, Rw].Value.ToString();
            cmbPort.Text = dgPConf[2, Rw].Value.ToString();
            cmbBaudRate.Text = dgPConf[3, Rw].Value.ToString();
            cmbParity.Text = dgPConf[4, Rw].Value.ToString();
            cmbStopBit.Text = dgPConf[5,Rw].Value.ToString();
            txtInstID.Text = dgPConf[6, Rw].Value.ToString();
            txtStartAdd.Text = dgPConf[7, Rw].Value.ToString();
            txtNReads.Text = dgPConf[8, Rw].Value.ToString();

            String st = dgPConf[9, Rw].Value.ToString();
            foreach (DataGridViewRow row in dgPConf.Rows)
            {
                if (st == "True")
                {
                    chkSelect.Text = "Selected";
                    chkSelect.CheckState = CheckState.Checked;
                    dgPConf.Rows[Rw].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
                else if (st == "False")
                {
                    chkSelect.Text = "Not Selected";
                    chkSelect.CheckState = CheckState.Unchecked;
                    dgPConf.Rows[Rw].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            switch (Rw)
            {

                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    panel2.Enabled = true;
                    panel3.Enabled = false;
                    break;
                case 1:
                    panel2.Enabled = false;
                    panel3.Enabled = true;                    
                    Global.Open_Connection("gen_db", "con");
                    int I = 0;
                    MySqlDataAdapter Dap = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = 'ADAMGroup01'", Global.con);
                    DataSet ds = new DataSet();
                    Dap.Fill(ds);

                    for (I = 0; I < 15; I++)
                    {
                        AdamArr[I] = ds.Tables[0].Rows[0].ItemArray[I + 1].ToString();
                    }
                    txtM1.Text = AdamArr[0];
                    ADAMType1.Text = AdamArr[1];
                    ADAMRange1.Text = AdamArr[2];
                    txtM2.Text = AdamArr[3];
                    ADAMType2.Text = AdamArr[4];
                    ADAMRange2.Text = AdamArr[5];
                    txtM3.Text = AdamArr[6];
                    ADAMType3.Text = AdamArr[7];
                    ADAMRange3.Text = AdamArr[8];
                    txtM4.Text = AdamArr[9];
                    ADAMType4.Text = AdamArr[10];
                    ADAMRange4.Text = AdamArr[11];
                    txtM5.Text = AdamArr[12];
                    ADAMType5.Text = AdamArr[13];
                    ADAMRange5.Text = AdamArr[14];
                    break;

                case 2:               
                    panel2.Enabled = false;
                    panel3.Enabled = true;
                    Global.Open_Connection("gen_db", "con");
                    int I1 = 0;
                    MySqlDataAdapter Dap1 = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = 'ADAMGroup02'", Global.con);
                    DataSet ds1 = new DataSet();
                    Dap1.Fill(ds1);

                    for (I1 = 0; I1 < 15; I1++)
                    {
                        AdamArr[I1] = ds1.Tables[0].Rows[0].ItemArray[I1 + 1].ToString();
                    }
                    txtM1.Text = AdamArr[0];
                    ADAMType1.Text = AdamArr[1];
                    ADAMRange1.Text = AdamArr[2];
                    txtM2.Text = AdamArr[3];
                    ADAMType2.Text = AdamArr[4];
                    ADAMRange2.Text = AdamArr[5];
                    txtM3.Text = AdamArr[6];
                    ADAMType3.Text = AdamArr[7];
                    ADAMRange3.Text = AdamArr[8];
                    txtM4.Text = AdamArr[9];
                    ADAMType4.Text = AdamArr[10];
                    ADAMRange4.Text = AdamArr[11];
                    txtM5.Text = AdamArr[12];
                    ADAMType5.Text = AdamArr[13];
                    ADAMRange5.Text = AdamArr[14];

                    break;
                default:
                    panel2.Enabled = false;
                    panel3.Enabled = false;
                    break;

            }
                



        }
        #region Load Listboxes
        private void LoadListboxes()
            {
           
            //1) Available Ports:',
                string[] ports = SerialPort.GetPortNames();
                cmbPort.Items.Add("COM");
                foreach (string port in ports)                
                    cmbPort.Items.Add(port);
                    cmbPort.SelectedIndex = 0;

            //2) Baudrates:
                string[] baudrates = {"9600","19200","38400","57600",  "115200", "230400"};
                foreach (string baudrate in baudrates)                
                    cmbBaudRate.Items.Add(baudrate);
                    cmbBaudRate.SelectedIndex = 0;

            //3) Parity:
            cmbParity.SelectedIndex = 0;
            //4) Stop Bit:
            cmbStopBit.SelectedIndex = 0;

        }

        #endregion
        
        private void btnSavePort_Click(object sender, EventArgs e)
        {
            try
            {
                int x = dgPConf.CurrentRow.Index;

                dgPConf[1, x].Value = cmbDeviceName.Text;
                dgPConf[2, x].Value = cmbPort.Text;
                dgPConf[3, x].Value = cmbBaudRate.Text;
                dgPConf[4, x].Value = cmbParity.Text;
                dgPConf[5, x].Value = cmbStopBit.Text;
                dgPConf[6, x].Value = txtInstID.Text;
                dgPConf[7, x].Value = txtStartAdd.Text;
                dgPConf[8, x].Value = txtNReads.Text;

                if (chkSelect.Text == "Selected")
                    dgPConf[9, x].Value = "True";
                else if (chkSelect.Text == "Not Selected")
                    dgPConf[9, x].Value = "False";


                //string S = dgPConf[9, x].Value; 
                Boolean st = Convert.ToBoolean(dgPConf[9, Rw].Value);
                foreach (DataGridViewRow row in dgPConf.Rows)
                {
                    if (st == true)
                    {
                        chkSelect.Text = "Selected";
                        chkSelect.CheckState = CheckState.Checked;
                        dgPConf.Rows[Rw].DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                    else if (st == false)
                    {
                        chkSelect.Text = "Not Selected";
                        chkSelect.CheckState = CheckState.Unchecked;
                        dgPConf.Rows[Rw].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }



                //----------------Save 
                int y = x + 1;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE tb_comports SET " +
                     " ComPorts  = '" + cmbPort.Text + "'," +
                     " BaudRates  = '" + cmbBaudRate.Text + "'," +
                     " Parity  = '" + cmbParity.Text + "'," +
                     " StopBit  = '" + cmbStopBit.Text + "'," +
                     " InstId  = '" + txtInstID.Text + "'," +
                     " StartAdd  = '" + txtStartAdd.Text + "'," +
                     " NReads  = '" + txtNReads.Text + "'," +
                     " State  = '" + st + "'" +
                     " WHERE DeviceNames =  '" + cmbDeviceName.Text + "'";
                cmd.Connection = Global.con;
                cmd.ExecuteNonQuery();

                if (Rw == 1)    // Save ADAM 1 CONFIGURATION
                {
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.CommandText = "UPDATE tbsys SET " +
                        " CH1  = '" + txtM1.Text + "'," + " CH2  = '" + ADAMType1.Text + "'," + " CH3  = '" + ADAMRange1.Text + "'," +
                        " CH4  = '" + txtM2.Text + "'," + " CH5  = '" + ADAMType2.Text + "'," + " CH6  = '" + ADAMRange2.Text + "'," +
                        " CH7  = '" + txtM3.Text + "'," + " CH8  = '" + ADAMType3.Text + "'," + " CH9  = '" + ADAMRange3.Text + "'," +
                        " CH10  = '" + txtM4.Text + "'," + " CH11  = '" + ADAMType4.Text + "'," + " CH12  = '" + ADAMRange4.Text + "'," +
                        " CH13  = '" + txtM5.Text + "'," + " CH14  = '" + ADAMType5.Text + "'," + " CH15  = '" + ADAMRange5.Text + "'" +
                        " WHERE FileName = 'ADAMGroup01'";
                    cmd1.Connection = Global.con;
                    cmd1.ExecuteNonQuery();
                }
                else if (Rw == 2)    // Save ADAM 2 CONFIGURATION
                {
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = "UPDATE tbsys SET " +
                        " CH1  = '" + txtM1.Text + "'," + " CH2  = '" + ADAMType1.Text + "'," + " CH3  = '" + ADAMRange1.Text + "'," +
                        " CH4  = '" + txtM2.Text + "'," + " CH5  = '" + ADAMType2.Text + "'," + " CH6  = '" + ADAMRange2.Text + "'," +
                        " CH7  = '" + txtM3.Text + "'," + " CH8  = '" + ADAMType3.Text + "'," + " CH9  = '" + ADAMRange3.Text + "'," +
                       " CH10  = '" + txtM4.Text + "'," + " CH11  = '" + ADAMType4.Text + "'," + " CH12  = '" + ADAMRange4.Text + "'," +
                       " CH13  = '" + txtM5.Text + "'," + " CH14  = '" + ADAMType5.Text + "'," + " CH15  = '" + ADAMRange5.Text + "'" +
                       " WHERE FileName = 'ADAMGroup02'";
                    cmd2.Connection = Global.con;
                    cmd2.ExecuteNonQuery();
                }
                Global.Create_OnLog("System Port Configuration File Is Saved Properly ", "Normal");
                loadInCell();
            }
          catch(Exception ex)
            {
                Global.Create_OnLog("System Port Configuration File Is not Saved Properly ", "Alart");
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPConf_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            loadInCell();
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.CheckState == CheckState.Checked)
                chkSelect.Text = "Selected";
            else
                chkSelect.Text = "Not Selected";  
        }

        private void Add_RangeList(String M_Type, int M_No)
        {
            try
            {
                String str = "";
                switch (M_Type)
                {
                    case "NONE":
                        str = "NONE";
                        break;
                    case "4018*8":
                        str = "K-Type,J-Type";
                        break;
                    case "4017*8":
                        str = "-10~+10V,4~20mA";
                        break;
                    case "4015*6":
                        str = "-50~150°C,0~200°C,0~400°C";
                        break;
                }

                string input = str;
                string pattern = @"(,)";
                Regex regex = new Regex(pattern);
                switch (M_No)
                {
                    case 1:
                        ADAMRange1.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ADAMRange1.Items.Add(result);
                        }
                        ADAMRange1.SelectedIndex = 0;
                        break;
                    case 2:
                        ADAMRange2.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ADAMRange2.Items.Add(result);
                        }
                        ADAMRange2.SelectedIndex = 0;
                        break;
                    case 3:
                        ADAMRange3.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ADAMRange3.Items.Add(result);
                        }
                        ADAMRange3.SelectedIndex = 0;
                        break;
                    case 4:
                        ADAMRange4.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ADAMRange4.Items.Add(result);
                        }
                        ADAMRange4.SelectedIndex = 0;
                        break;
                    case 5:
                        ADAMRange5.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ADAMRange5.Items.Add(result);
                        }
                        ADAMRange5.SelectedIndex = 0;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14002", ex.Message);
                Global.Create_OnLog(ex.Message, "Alart");
            }


        }

       

        private void ADAMType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ADAMType1.Text, 1);
        }

        private void ADAMType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ADAMType2.Text, 2);
        }

        private void ADAMType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ADAMType3.Text, 3);
        }

        private void ADAMType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ADAMType4.Text, 4);
        }

        private void ADAMType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ADAMType5.Text, 5);
        }

        private void tV1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeT = tV1.SelectedNode.Text;
            label9.Text = NodeT;

            switch (NodeT)
            {
                case  "ADAM-6018":
                {
                    txtIp.Text = "192.168.001.241";
                    txtParN.Text = "8";
                    break;
                }
                case "ADAM-6017":
                {
                    txtIp.Text = "192.168.001.242";
                    txtParN.Text = "8";
                    break;
                }
                case "Thr-104":
                {
                    txtIp.Text = "192.168.001.028";
                    txtParN.Text = "8";
                    break;
                }
                case "Rtd-107":
                {
                    txtIp.Text = "192.168.001.028";
                    txtParN.Text = "4";
                    break;
                }
                case "Press-108":
                {
                    txtIp.Text = "192.168.001.028";
                    txtParN.Text = "8";
                    break;
                }

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
