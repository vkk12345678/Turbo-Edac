using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; 
using MySql.Data.MySqlClient;
using Rd_Gantner;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using MicroLibrary;
using Advantech.Adam;


namespace Logger
{
	public partial class frmScrII : Form
	{
        private int FixHeight = 1920, FixWidth = 1080;
        
        public static InPutV.IPVal[] InV = new InPutV.IPVal[80];
        private readonly MicroLibrary.MicroTimer _microTimer;
        public static int ReadChannel = 0;
        //int index;
        Double Value;
        //int HONLCONNECTION = -1;
        //*********************
        public static Thread FASTLOGThread;
        public static Thread GantnerThread;
        public static Thread ADAM6018Thread;
        public static Thread ADAM6017Thread;

        public static string m_IP18;
        public static string m_IP17;
        public static int m_iPort; //, m_iCount;
        public static int m_iStart1, m_iLength1;
        public static int m_iStart2, m_iLength2;
        public static bool m_bRegister1; //, m_bStart1;
        public static bool m_bRegister2; //, m_bStart2;	
        public static AdamSocket adamTCP1;
        public static AdamSocket adamTCP2;
      

        Task t1, t2, t3, t4, t5;
        private Boolean flg_Showlim = false;
        private string[] ViewNo = new string[22];
        public static frmMain main = new frmMain(); 
        
       

        //****************
		
		public frmScrII()
		{
			InitializeComponent();
            // Instantiate new MicroTimer and add event handler
            _microTimer = new MicroLibrary.MicroTimer();
            _microTimer.MicroTimerElapsed +=
                new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
		}

		private void showOnMonitor(int showOnMonitor)
		{
			Screen[] sc;
			sc = Screen.AllScreens;
			if (showOnMonitor >= sc.Length)
			{
				showOnMonitor = 0;
			}


			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);			
			this.WindowState = FormWindowState.Maximized;
		}

       

		private void LoadParameter_Arr()
		{

			int I = 0;

			InV[0] = ipVal1;
			InV[1] = ipVal2;
			InV[2] = ipVal3;
			InV[3] = ipVal4;
			InV[4] = ipVal5;
			InV[5] = ipVal6;
			InV[6] = ipVal7;
			InV[7] = ipVal8;
			InV[8] = ipVal9;
			InV[9] = ipVal10;
			InV[10] = ipVal11;
			InV[11] = ipVal12;
			InV[12] = ipVal13;
			InV[13] = ipVal14;
			InV[14] = ipVal15;
			InV[15] = ipVal16;
			InV[16] = ipVal17;
			InV[17] = ipVal18;
			InV[18] = ipVal19;
			InV[19] = ipVal20;
			InV[20] = ipVal21;
			InV[21] = ipVal22;
			InV[22] = ipVal23;
			InV[23] = ipVal24;
			InV[24] = ipVal25;
			InV[25] = ipVal26;
			InV[26] = ipVal27;
			InV[27] = ipVal28;
			InV[28] = ipVal29;
			InV[29] = ipVal30;
			InV[30] = ipVal31;
			InV[31] = ipVal32;
			InV[32] = ipVal33;
			InV[33] = ipVal34;
			InV[34] = ipVal35;
			InV[35] = ipVal36;
			InV[36] = ipVal37;
			InV[37] = ipVal38;
			InV[38] = ipVal39;
			InV[39] = ipVal40;
			InV[40] = ipVal41;
			InV[41] = ipVal42;
			InV[42] = ipVal43;
			InV[43] = ipVal44;
			InV[44] = ipVal45;
			InV[45] = ipVal46;
			InV[46] = ipVal47;
			InV[47] = ipVal48;
			//InV[48] = ipVal36;
			//InV[49] = ipVal37;
			//InV[50] = ipVal38;
			//InV[51] = ipVal39;
			//InV[52] = ipVal40;
			//InV[53] = ipVal41;
			//InV[54] = ipVal42;
			//InV[55] = ipVal56;
			//InV[56] = ipVal57;
			//InV[57] = ipVal58;
			//InV[58] = ipVal59;
			//InV[59] = ipVal60;
			//InV[60] = ipVal61;
			//InV[61] = ipVal62;
			//InV[62] = ipVal63;
			//InV[63] = ipVal64;
			//InV[64] = ipVal65;
			//InV[65] = ipVal66;
			//InV[66] = ipVal67;
			//InV[67] = ipVal68;
			//InV[68] = ipVal69;
			//InV[69] = ipVal70;


			try
			{
				Global.Rd_Confg();				
				Global.Open_Connection("gen_db", "con");
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_scrn ORDER BY N", Global.con);
				MySqlDataReader Rd = cmd.ExecuteReader();

				int x = 0;
				while (Rd.Read())
				{
					if (x > 47) break;
					Global.scrn_Par[x] = Rd.GetValue(1).ToString();
					x += 1;
				}
				Rd.Close();
				Global.con.Close();

                


				for (I = 0; I <= 47; I++)
				{
					InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(Global.scrn_Par[I])].ToString()));
                                  if (InV[I].P_Name.Substring(0, 1) == "P")   InV[I].Invoke(new Action(() => InV[I].BackColor = Color.DarkGray));
                                  else if ((InV[I].P_Name.Substring(0, 1) == "T")|| (InV[I].P_Name.Substring(0, 1) == "R"))  InV[I].Invoke(new Action(() => InV[I].BackColor = Color.DarkGray));
                                  else  InV[I].Invoke(new Action(() => InV[I].BackColor = Color.DarkGray));
                    //InV[I].Invoke(new Action(() => InV[I].BackColor = Color.Gainsboro));
					
                    InV[I].Invoke(new Action(() => InV[I].P_Color = Color.Navy)); 
					InV[I].Invoke(new Action(() => InV[I].U_Color = Color.Black));
                    InV[I].Invoke(new Action(() => InV[I].colFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
					InV[I].Invoke(new Action(() => InV[I].P_Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
					InV[I].Invoke(new Action(() => InV[I].U_Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));

					if (InV[I].P_Name == "Not_Prog")
					{
						InV[I].P_Name = "";
						InV[I].P_Unit = "";
						InV[I].Invoke(new Action(() => InV[I].colFillColor = Color.LightGray));
						InV[I].Invoke(new Action(() => InV[I].colForeColor = Color.LightGray));
					}

                    else
					{
						InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(Global.scrn_Par[I])].ToString()));
						InV[I].Invoke(new Action(() => InV[I].P_Unit = Global.PUnit[int.Parse(Global.scrn_Par[I])].ToString()));

						InV[I].colFillColor = Color.Teal; //.DarkGreen;
						InV[I].colForeColor = Color.White;
					} 
				}



                //Init_Gantner();
                //Init_TCP_Port();
                ////t1 = Task.Run(() => { Global.Capture_fData(); });  
                ////t1 = Task.Run(() => { clsADAM6000.Read_AdamValues6018(); });
                ////t2 = Task.Run(() => { clsADAM6000.Read_AdamValues6017(); });


                //GantnerThread = new Thread(new ThreadStart(Gantner_Thread));
                //GantnerThread.Start();

                ////ADAM6018Thread = new Thread(new ThreadStart(ADAM6018_Thread));
                ////ADAM6018Thread.Start();

                ////ADAM6017Thread = new Thread(new ThreadStart(ADAM6017_Thread));
                ////ADAM6017Thread.Start();

                
 

				Global.Create_OnLog("Load_Arr()", "Normal ");

                LoadDgView();
                tmrRead.Start(); 

                timer1.Start();  
			}
			catch (Exception ex)
			{
				Global.Create_OnLog("Load_Arr()", "Alart");
				//MessageBox.Show("Error in frmMain: Load_Arr():  " + ex.Message);
			}
		}

        //****************************
        public void Init_TCP_Port()
        {
            m_bRegister1 = true;        // set to true to read the register, otherwise, read the coil
            m_bRegister2 = true;       // set to true to read the register, otherwise, read the coil
            m_IP18 = "192.168.1.241"; // "172.18.3.243";	// modbus slave IP address
            m_IP17 = "192.168.1.242";  //modbus slave IP address
            m_iPort = 502;              // modbus TCP port is 502
            m_iStart1 = 1;              // modbus starting address
            m_iLength1 = 8;
            m_iStart2 = 1;              // modbus starting address
            m_iLength2 = 8; // modbus reading length
            adamTCP1 = new AdamSocket();
            adamTCP2 = new AdamSocket();
            adamTCP1.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            adamTCP2.SetTimeout(1000, 1000, 1000); // set timeout for TCP

        }
        private void Init_Gantner()
        {
            int HONLCLIENT = -1, HONLCONNECTION = -1;
            int ret = 0;
            int ChannelCount = 0;
            double info1 = 0;
            byte[] baTempInfo = new byte[1024];
            string strTempString = "";
            double outValue = 0;

            string IP = "192.168.1.28";
            //*******************
            ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Address, 0, ref info1, baTempInfo);
            ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Type, 0, ref info1, baTempInfo);
            ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
            ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.SampleRate, 0, ref info1, null);

            HSP._CD_eGateHighSpeedPort_GetNumberOfChannels(HONLCONNECTION, (int)HSP.DATADIRECTION.InputOutput, ref ChannelCount);

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

                ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);
                HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
                //Global.GenData[ReadChannel + 26] = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.0000");      //outValue.ToString("##0.0");
                Global.GenData[ReadChannel + 25] = outValue.ToString("000.00000"); // (Global.RandomNumberBetween((outValue + 0.00000), (outValue - 0.00000))).ToString("000.0000");  // outValue.ToString("000.000"); //

                if (ReadChannel < 20)
                    ReadChannel++;
                else
                    ReadChannel = 1;              
            }
            catch (Exception ex)
            {
                return;
            }
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




        //****************************
        public void Gantner_Thread()
        {
            try
            {
                while (true)
                {
                    string controllerIP = "192.168.1.28";
                    Online(controllerIP);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void OnTimedEvent(object sender,
                                 MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            // Do something small that takes significantly less time than Interval.
            // BeginInvoke executes on the UI thread but this calling thread does not
            //  wait for completion before continuing (i.e. it executes asynchronously)
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    LogfData(); 
                 
                });


            }
        }

        //public static void fLog_Thread()
        //{
        //    try
        //    {
               
        //            while (true)
        //            {
        //                if (Global.flg_fastlog == true)
        //                {
        //                    Thread.Sleep(Global.Dly_cnt);
        //                    LogfData();
        //                }
        //            }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}
        ////**********************
        //public static void LogfData()
        //{
        //    try
        //    {
        //        int i = 0;
        //        Global.Capture_fData();
        //        String strData = null;
        //        for (i = 0; i <= 55; i++)
        //        {
        //            if (Global.fData[i] == null) Global.fData[i] = "0.0";
        //            strData = strData + Global.fData[i] + ", ";
        //        }
        //        strData = strData + Global.fData[56] + "\n";

        //        var filePath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
        //        using (var wr = new StreamWriter(filePath, true))
        //        {
        //            var row = new List<string> { strData.Substring(0, strData.Length - 1) };
        //            var sb = new StringBuilder();
        //            foreach (string value in row)
        //            {
        //                if (sb.Length > 0)
        //                    sb.Append(",");
        //                sb.Append(value);
        //            }
        //            wr.WriteLine(sb.ToString());
        //        }
        //        //*****************************
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Data fast Log Problem... ", "Alart");
        //        Global.flg_SFCStart = false;
        //    }
        //}
        //************************
        //public static void LogfData()
        //{
        //    try
        //    {
        //        int i = 0;
        //        Global.Capture_fData();
        //        String strData = null;
        //        for (i = 0; i <= 40; i++)
        //        {
        //            if (Global.fData[i] == null) Global.fData[i] = "0.0";
        //            strData = strData + Global.fData[i] + ", ";
        //        }
        //        strData = strData + Global.fData[40] + "\n";

        //        var filePath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
        //        using (var wr = new StreamWriter(filePath, true))
        //        {
        //            var row = new List<string> { strData.Substring(0, strData.Length - 1) };
        //            var sb = new StringBuilder();
        //            foreach (string value in row)
        //            {
        //                if (sb.Length > 0)
        //                    sb.Append(",");
        //                sb.Append(value);
        //            }
        //            wr.WriteLine(sb.ToString());
        //        }
        //        //*****************************
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Data fast Log Problem... ", "Alart");
        //        Global.flg_SFCStart = false;
        //    }
        //}
        ////***************************

        /// <summary>
//        /// /********************************************
        public static void LogfData()      //Only For Gantner
        {
            try
            {
                int i = 0;
                Global.Capture_fData();
                String strData = System.DateTime.Now.ToString("hh.mm.ss tt") + ", ";
                for (i = 1; i <= 22; i++)
                {
                    if (Global.fData[i] == null) Global.fData[i] = "0.0";
                    strData = strData + Global.fData[i] + ", ";
                }
                strData = strData + Global.Data[22] + "\n";

                var filePath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { strData.Substring(0, strData.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }
                //*****************************
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Data fast Log Problem... ", "Alart");
                Global.flg_SFCStart = false;
            }
        }
        //***************************************************
        /// </summary>
         private void DisplayLimits()
        {
                int i = 0;
                String sg = null;
                String str;
            for (i = 0; i < 48; i++)
            {
                if (InV[i].P_Name != "Not_Prog")
                {
                    sg = Global.scrn_Par[i].ToString(); 
                    if ((Global.PSName[int.Parse(sg)] != "Not_Prog"))  //(Global.GenData[int.Parse(sg)] != null) && 
                    {
                        str = Global.GenData[int.Parse(sg)];

                        if (Global.BufLim[int.Parse(sg)] == "O")
                        {
                            InV[i].colFillColor = Color.Blue;
                            mnuAlarm.Text = "Engine Off : " + Global.PSName[i];
                            mnuAlarm.BackColor = Color.Red;
                            mnuAlarm.ForeColor = Color.Yellow;
                        }
                        else if (Global.BufLim[int.Parse(sg)] == "I")
                        {
                            if (InV[i].colFillColor == Color.Teal)
                            {
                                InV[i].colFillColor = Color.Yellow;
                                InV[i].colForeColor = Color.Red;
                                mnuAlarm.Text = "Engine IDLE : " + Global.PSName[i];
                                mnuAlarm.BackColor = Color.Red;
                                mnuAlarm.ForeColor = Color.Yellow;
                            }
                            else
                            {
                                InV[i].colFillColor = Color.Teal;
                                InV[i].colForeColor = Color.White;
                            }

                        }
                        else if (Global.BufLim[int.Parse(sg)] == "A") //&& (Global.flg_LimitON == true))
                        {
                            if (InV[i].colFillColor == Color.Teal)
                            { 
                                InV[i].colFillColor = Color.Red;
                                InV[i].colForeColor = Color.White;

                            }
                            else if (InV[i].colFillColor == Color.Red)
                            {
                                InV[i].colFillColor = Color.Teal;
                                InV[i].colForeColor = Color.White;
                            }

                        }
                        else if (Global.BufLim[int.Parse(sg)] == "N")
                        {

                            InV[i].colFillColor = Color.Teal;
                            InV[i].colForeColor = Color.White;
                        }
                    }
                }
             }
         }
        
        private void timer1_Tick(object sender, EventArgs e)
         {

             if (Global.flg_fastlog == false)
             {
                 //FASTLOGThread = new Thread(new ThreadStart(fLog_Thread));
                 //FASTLOGThread.Abort();

                 Global.Create_OnLog("Fast Logging Stopped.....", "Normal");
                 frqVal.Text = "Fast log Stopped.............." + Global.HzLog;
                 frqVal.BackColor = Color.Gainsboro;
                 frqVal.ForeColor = Color.Blue;

             }

                 ////if (ADAM6018Thread.ThreadState == ThreadState.Aborted)
                 ////{
                 ////    ADAM6018Thread = new Thread(new ThreadStart(ADAM6018_Thread));
                 ////    ADAM6018Thread.Start();
                 ////}
                 ////if (ADAM6017Thread.ThreadState == ThreadState.Aborted)
                 ////{
                 ////    ADAM6017Thread = new Thread(new ThreadStart(ADAM6017_Thread));
                 ////    ADAM6017Thread.Start();
                 ////}
                 //if (GantnerThread.ThreadState == ThreadState.Aborted)
                 //{
                 //    GantnerThread = new Thread(new ThreadStart(Gantner_Thread));
                 //    GantnerThread.Start();
                 //}
                 //if (tmrRead.Enabled == false)
                 //{
                 //    tmrRead.Interval = 100;
                 //    tmrRead.Start();
                 //}
          
            
             

             DisplayLimits();
             flg_Showlim = false;
             int i = 0;
             for (i = 0; i <= 59; i++)
             {
                 if (Global.BufLim[i] == "A")
                 {
                     flg_Showlim = true;
                     break;
                 }
             }
             if ((flg_Showlim == true) && (Global.varRPM >= 650)) //(Global.flg_EngStart = true)) 
             {
                 mnuAlarm.BackColor = Color.Red;
                 mnuAlarm.ForeColor = Color.Yellow;
                 mnuAlarm.Text = "Check Alarm : " + Global.PSName[i];
             }
             else
             {
                 mnuAlarm.BackColor = Color.LightGray;
                 mnuAlarm.ForeColor = Color.Red;
                 mnuAlarm.Text = "Alarm Status...";
             }
             //if (Global.flg_UpdateViewData == true)
             
             //    //Update_ViewData();


         }

      
    //*******************************************************
        public void LoadDgView()
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from Tb_View Order By N", Global.con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DGView.ColumnCount = 23;
                if (DGView.RowCount >= 10)
                    DGView.RowCount = Global.Sn + 2;
                else
                    DGView.RowCount = 10;
                DGView.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                DGView.Columns[0].Width = 40;
                DGView.Columns[0].Name = "Sn";
                DGView.Columns[1].Width = 80;
                DGView.Columns[1].Name = "LogTime";
                for (int i = 0; i < 21; i++)
                {
                    DGView.Columns[i + 2].Width = 80;
                    ViewNo[i] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    DGView.Columns[i + 2].Name = Global.PSName[int.Parse(ViewNo[i])] + "    " + Global.PUnit[int.Parse(ViewNo[i])];
                }
            
                DGView.Columns[22].Width = 200;

                //DGView.Rows[Global.Sn].Cells[0].Value = Global.Sn;
                //DGView.Rows[Global.Sn].Cells[1].Value = Global.GenData[122];

                for (int i = 0; i < 23; i++)
                {
                    DGView.Rows[Global.Sn].Cells[i + 2].Value = Global.Data[int.Parse(ViewNo[i])];
                }
                if (Global.Sn >= 10)
                {
                    DGView.RowCount += 1;
                    DGView.FirstDisplayedScrollingRowIndex = (Global.Sn - 5);
                }
                DGView.Rows[Global.Sn].Selected = true;

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: DGView() : ", "Alart");
                return;//MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }

        public void Update_ViewData()
        {
            int i = 0;
            DGView.RowCount += 1;
            if (Global.Sn >= 8)
            {
                DGView.RowCount += 1;
                DGView.FirstDisplayedScrollingRowIndex = (Global.Sn - 7);
            }
            DGView[0, Global.Sn - 1].Value = Global.Sn;
            DGView[1, Global.Sn - 1].Value = System.DateTime.Now.ToString("hh:mm:ss  tt");
           

            for (i = 0; i < 20; i++)
            {
                DGView[i + 2, Global.Sn - 1].Value = Global.Data[int.Parse(ViewNo[i])];               
            }

            DGView.Rows[Global.Sn - 1].Selected = true;
            Global.flg_UpdateViewData = false;
            //Hold_Cycle(false);
        }

        //*****************************

        public static void Read_AdamValues6018()
        {
            try
            {
                int iIdx;
                int[] iData;

                while (true)
                {
                    if (m_bRegister1) // Read registers (4X references)
                    {
                        adamTCP1.Connect(m_IP18, ProtocolType.Tcp, m_iPort);
                        if (adamTCP1.Modbus().ReadHoldingRegs(m_iStart1, m_iLength1, out iData))
                        {
                            for (iIdx = 0; iIdx < m_iLength1; iIdx++)
                            {
                                Double ValF = ((Convert.ToDouble(iData[iIdx]) * 1370) / 65535) * 1000;
                                Global.GenData[10 + iIdx] = (Global.RandomNumberBetween((ValF + 0.0001), (ValF - 0.0002)) / 1000).ToString("000.0000");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static void Read_AdamValues6017()
        {
            try
            {
                int iIdx;
                int[] iData;

                while (true)
                {
                    if (m_bRegister2) // Read registers (4X references)
                    {
                        adamTCP2.Connect(m_IP17, ProtocolType.Tcp, m_iPort);
                        if (adamTCP2.Modbus().ReadHoldingRegs(m_iStart2, m_iLength2, out iData))
                        {
                            for (iIdx = 0; iIdx < m_iLength2; iIdx++)
                            {
                                Double V = (Double.Parse(Global.PMax[18 + iIdx]) - Double.Parse(Global.PMin[18 + iIdx])) / 16;
                                Double ValF = ((Convert.ToDouble(iData[iIdx]) * 16) / 65535) * 1000;
                                Global.GenData[18 + iIdx] = ((Global.RandomNumberBetween((ValF + 0.0001), (ValF - 0.0003)) * V / 1000) + Double.Parse(Global.PMin[18 + iIdx])).ToString("000.0000");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }



        //public void ADAM6018_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {

        //            Read_AdamValues6018();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}
        //public void ADAM6017_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            Read_AdamValues6017();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

     
        //*******************************

   
     
        private void frmScrII_Load(object sender, EventArgs e)
        {  
            showOnMonitor(0);
            //Resolution.CResolution ChangeRes = new Resolution.CResolution(FixHeight, FixWidth);
            LoadParameter_Arr();

        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
              try
              {
                  write_InputValues();
                 
              }
              catch (Exception ex)
              {
                  return;
              }  
        }

        private void write_InputValues()
        {
            try
            {
                string pr;
                for (int i = 0; i < 48; i++)
                {
                    pr = Global.scrn_Par[i];
                    frmScrII.InV[i].P_Value = Global.GenData[int.Parse(pr)]; 
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ADAM6018Thread.ThreadState == ThreadState.Running)
            {
                ADAM6018Thread.Interrupt();
                ADAM6018Thread.Abort();
            }
        }

       
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                if (btnStart.Text == "Start-FastLog Data")
                {
                    btnStart.Text = "Stop-FastLog Data";
                    Global.flg_fastlog = true;
                    Global.flg_fstart = true;
                    Global.flg_fstop = false;
                    Global.Create_OnLog("Fast Logging Staerted.....", "Alart");
                    frqVal.Text = "Fast log started...........    " + Global.HzLog;
                    frqVal.ForeColor = Color.Yellow;
                    frqVal.BackColor = Color.Red;                   
                    ctlLED1.tmron = true;
                    btnStart.BackColor = Color.Gray;
                    btnStart.ForeColor = Color.White;

                    long interval;

                    // Read interval from form

                    if (!long.TryParse(Global.Dly_cnt.ToString(), out interval))
                    {
                        return;
                    }

                    // Set timer interval
                    _microTimer.Interval = interval;

                    // Ignore event if late by half the interval
                    _microTimer.IgnoreEventIfLateBy = interval / 2;

                    // Start timer
                    _microTimer.Start();
                }
                else if (btnStart.Text == "Stop-FastLog Data")
                {
                    btnStart.Text = "Start-FastLog Data";
                    Global.flg_fastlog = false;
                    _microTimer.Stop();
                    ctlLED1.tmron = false;
                    Global.Create_OnLog("Fast Logging Stopped.....", "Alart");
                    Global.flg_fstart = false;
                    Global.flg_fstop = true;
                    frqVal.Text = "Fast log Stopped.............." + Global.HzLog;
                    frqVal.BackColor = Color.Gainsboro;
                    frqVal.ForeColor = Color.Blue;
                    btnStart.BackColor = Color.Gainsboro;
                    btnStart.ForeColor = Color.Blue;

                }
            }
            else
            {
                MessageBox.Show("First Start the cycle ..........", "Dynalec Cont5rols Pvt. ltd");               
                return;
            }

        }

        private void Tm6000_Tick(object sender, EventArgs e)
        {
            int iIdx;
            int[] iData;

            if (m_bRegister1) // Read registers (4X references)
            {
                adamTCP1.Connect(m_IP18, ProtocolType.Tcp, m_iPort);
                if (adamTCP1.Modbus().ReadHoldingRegs(m_iStart1, m_iLength1, out iData))
                { 
                    for (iIdx = 0; iIdx < m_iLength1; iIdx++)
                    {
                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 1370) / 65535) * 1000;
                        Global.GenData[10 + iIdx] =  (Global.RandomNumberBetween((ValF + 0.001), (ValF - 0.002)) / 1000).ToString("000.00000");
                    }
                }
                m_bRegister1 = false;
                m_bRegister2 = true;
            }
            else if (m_bRegister2) // Read registers (4X references)
            {
                adamTCP2.Connect(m_IP17, ProtocolType.Tcp, m_iPort);
                if (adamTCP2.Modbus().ReadHoldingRegs(m_iStart2, m_iLength2, out iData))
                {
                    for (iIdx = 0; iIdx < m_iLength2; iIdx++)
                    {
                        Double V = (Double.Parse(Global.PMax[18 + iIdx]) - Double.Parse(Global.PMin[18 + iIdx])) / 16;
                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 16) / 65535); //  *1000;
                        Global.GenData[18 + iIdx] = ((Global.RandomNumberBetween((ValF + 0.001), (ValF - 0.002)) * V / 1000) + Double.Parse(Global.PMin[18 + iIdx])).ToString("000.00000");
                    }
                   


                }
                m_bRegister2 = false;
                m_bRegister1 = true;
            }


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        //private void btnStop_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Global.flg_fastlog = false;
        //        _microTimer.Stop();
        //        ctlLED1.tmron = false;

        //        Global.Create_OnLog("Fast Logging Stopped.....", "Normal");
        //        frqVal.Text = "Fast log Stopped.............." + Global.HzLog;
        //        frqVal.BackColor = Color.Gainsboro;
        //        frqVal.ForeColor = Color.Blue;
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }

        //}

      

      
    

       

	}
}
