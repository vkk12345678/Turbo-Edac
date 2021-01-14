using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rd_Gantner;
using System.Threading;  

namespace Rd_Gantner
{
    public partial class Form1 : Form
    {
        public static String[] GenData = new String[50];
        public static int ReadChannel = 0;
        private Random rand1 = new Random();
        int index;
        Double Value;
        int HONLCONNECTION = -1;
        public static Boolean flg_ONOFF = true;

        public Form1()
        {  
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int HONLCLIENT = -1, HONLCONNECTION = -1;
            int ret = 0;
            //double tempVal = 0;
            int ChannelCount = 0;
            double info1 = 0;
            //int ReadChannel = 0;
            byte[] baTempInfo = new byte[1024];
            //byte[] baChannelName = new byte[1024];
            string strTempString = "";
            //string strChannelName = "";
            double outValue = 0;
            dgView.RowCount = 22;
            //string controllerIP = "192.168.1.18";
            //int HONLCLIENT = -1, HONLCONNECTION = -1;
            string IP = "192.168.1.28";

            for (int i = 0; i <= 20; i++)
                dgView.Rows[i].Cells[0].Value = i;
//*******************
            ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);
        
            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Address, 0, ref info1, baTempInfo);
            ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Type, 0, ref info1, baTempInfo);
            ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);         
            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.SampleRate, 0, ref info1, null);

            HSP._CD_eGateHighSpeedPort_GetNumberOfChannels(HONLCONNECTION, (int)HSP.DATADIRECTION.InputOutput, ref ChannelCount);
           
            for (int i = 0; i <= 20; i++) //ChannelCount; i++)   //ChannelCount
            {
                ret = HSP._CD_eGateHighSpeedPort_GetChannelInfo_String(HONLCONNECTION, (int)HSP.CHANNELINFO.Name, (int)HSP.DATADIRECTION.InputOutput, i, baTempInfo);
                ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
                dgView.Rows[i].Cells[1].Value =  strTempString;    //(i + 1) + ". Channel: " +


                ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.CHANNELINFO.Unit, i, ref info1, baTempInfo);   // .DataDirection
                ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
                dgView.Rows[i].Cells[3].Value =  strTempString;

                ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.CHANNELINFO.DataDirection, i, ref info1, baTempInfo);   // .DataDirection
                ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
                dgView.Rows[i].Cells[4].Value = strTempString;

                ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.CHANNELINFO.DataDirection, i, ref info1, baTempInfo);   // .DataDirection
                ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
                dgView.Rows[i].Cells[4].Value = strTempString;
                

            }
//*****************
            timer1.Start(); 
          
           
        }

        private static void ConvertZeroTerminatedByteArray2String(out string Destination, byte[] Source) 
        {
            int i, MaxIndex;

            MaxIndex = Source.GetUpperBound(0);
            Destination = "";
            i = Source.GetLowerBound(0);
            while ((Source[i] != 0) && (i <= MaxIndex))
            {
                Destination += (char)Source[i];
                i++;
            }
            Destination = Destination.Trim();
        }

        

        private void Online(string IP)
        {
            try
            {
                int HONLCLIENT = -1, HONLCONNECTION = -1;
                int ret = 0;
                double info1 = 0;
                byte[] baTempInfo = new byte[1024];

                double outValue = -1;

                if (flg_ONOFF == false)
                {
                    ReadChannel = 0;
                    flg_ONOFF = true;
                }
                ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

                //ReadChannel = 0;

                if (ReadChannel <= 20)
                {
                    ReadChannel++;
                    label3.Text = ReadChannel.ToString();
                }
                else
                    ReadChannel = 0;

                HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
                //GenData[ReadChannel] = outValue.ToString("##0.0##");
                //dgView.Rows[ReadChannel].Cells[2].Value = GenData[ReadChannel];
                dgView.Rows[ReadChannel].Cells[2].Value = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.000");
                //DGView11[iIdx + 2, 0].Value = ((rand1.Next(((int)ValF - 1), ((int)ValF + 1))) / 1000.0).ToString("000.000");

            }
            catch (Exception ex)
            {
                return;
            }
                 
        }



       
        public static DateTime DelayMs(int nMs)
        {
            try
            {

                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
            return System.DateTime.Now;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int HONLCLIENT = -1, HONLCONNECTION = -1;
            string controllerIP = "192.168.1.28";
            Online(controllerIP);
            //richTextBox1.AppendText(System.DateTime.Now.ToString("hh:mm:ss:fff tt") +"\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // timer1.Stop();
            this.WindowState = FormWindowState.Minimized;  
        }



      
      
         #region WriteValues...
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flg_ONOFF = false;

                int HONLCLIENT = -1, HONLCONNECTION = -1;
                string controllerIP = "192.168.1.28";

                //timer1.Stop();

                double value;
               
                int ret = HSP._CD_eGateHighSpeedPort_Init(controllerIP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

                int.TryParse(textBox1.Text, out index);
                double.TryParse(textBox2.Text, out value);

                //Write_SetValue(int ch, double val);
                ret = HSP._CD_eGateHighSpeedPort_WriteOnline_Single_Immediate(HONLCONNECTION, index, value);
                //timer1.Start();
                //flg_ONOFF = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
           
        }

        public static void Write_SetValue(int ch, double val)
        {
            int HONLCLIENT = -1, HONLCONNECTION = -1;
            string controllerIP = "192.168.1.18";

            //int ret = HSP._CD_eGateHighSpeedPort_Init(controllerIP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

            int ret = HSP._CD_eGateHighSpeedPort_WriteOnline_Single_Immediate(HONLCONNECTION, ch, val);
        }
        

          # endregion

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

      
       
        
 
    }
}
