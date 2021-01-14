using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Automation.BDaq; 
using System.Windows.Forms;
using System.Threading.Tasks; 
using System.Threading;
using System.Globalization;
using System.IO.Ports;
using System.Net;
//using Rd_Gantner;
using System.Net.Sockets;
using System.Text.RegularExpressions;





namespace Logger
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// /////socket declaration
        //public  Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //public  IPAddress clientIP = IPAddress.Parse("192.168.1.98");
        //public  IPEndPoint clientEP = new IPEndPoint(IPAddress.Parse("192.168.1.98"), 1001);
        /// </summary>
        /// 
        

        public Process p = new Process();
		private int FixHeight = 1920, FixWidth = 1080;   // 1366, FixWidth = 768; //, FixWidth =  FixWidth = 768;    
       // public modbus modb = new modbus(); 
        System.Windows.Forms.Button[] ArrBut = new
        System.Windows.Forms.Button[50];
        System.Windows.Forms.TextBox[] ArrVal = new
        System.Windows.Forms.TextBox[50];
        System.Windows.Forms.Label[] ArrUnit = new
        System.Windows.Forms.Label[50];
        private InPutV.IPVal[] InV = new InPutV.IPVal[80];
        private String[] scrn_Cal = new String[80];
        private String[] view = new String[150];

        //*****************************
        ////public static String[] GenData = new String[50];
        //public static int ReadChannel = 0;       
        //int index;
        //Double Value;
        //int HONLCONNECTION = -1;
        ////public static Boolean flg_ONOFF = true;


        ////*********************

       
        
        double[] dataScaled = new double[2];
        public double stopsec = 20;
        private String[] PmData = new String[20];
       
        private String[] EngData = new String[30];

        private double Buf1 = 0;
        private double Buf2 = 0;
        private string OutBuf = "";
        private String TolT = "00:00:00";
        private int R_Cnt = 0;

        private int AdamCnt6018 = 0;
        private int AdamCnt6017 = 0;
        private int iIdxT = 0;
        private int iIdxP = 0;
       

        private String[] IData = new String[151];
        public static SerialPort PIDPORT = new SerialPort();
       
        //********************
        double[] m_frequecy; // selected counter channel' frequency.
        bool m_isCounterReseted = true;
        int m_channelCount = 2;
        int m_index = 1;
        //**********************

        public Double minLp = 0;
        public Double maxVal = 10000;
        public int LimCnt = 0;
        private int SockT = 0;
		

		string SFCType = "";

        private Double Lower1, Lower2, Lower3, Lower4, Lower5;
        private Double High1, High2, High3, High4, High5;
        private String Ds_Pos;
        private int cntDSafty = 0;
        private String AMSt = "1";

        //public static Thread FASTLOGThread;
        //public static Thread GantnerThread;
        //public static Thread ADAM6018Thread;
        //public static Thread ADAM6017Thread;

        public static Thread TimeThread;



		public static Thread InputValueThread;

		//public static Thread FASTLOGThread;
		//public static Thread RINSTThread_RT;

		private Stopwatch st = new Stopwatch();

        public static  Boolean f_Found = false;

        private Boolean flg_ProgEnd = false;
        private Boolean flg_Showlim = false;

        private String MSt = "1";
        private int RMP1 = 0;
        private int RMP2 = 0;
        private int RMP = 0;
        private Boolean flg_M_Ramp = false;
        private Point MouseDownLocation;
          
        private int wPCnt = 0;
        private int fPCnt = 0;
        private int lPCnt = 0;
        private int wTCnt = 0;
        private int lTCnt = 0;
        private int wrtCnt = 0;
        private int Srloop = 0;
        private int Erloop = 0;
        private int CntReset = 0;
        private int LogCnt = 0;
        public Boolean Auto_SmkRd = false;

        public static long TmrCnt = 0;
        public static long StpCnt = 0;

       

        public static int RcNt = 0;
        public int Sn = 0;
        private Int16  C_Hours;
        private Int16 C_Minutes;
        private Int16 C_Seconds;
        public TimeSpan t;
        public  string answer;
        public TimeSpan t11;
        public string answer11;
        public TimeSpan t12;
        public string answer12;
        //SeqFile
        //private String SetPt1 = "0";

        private int TmR1 = 0;
        private int TmR = 1;
        //private String SetPt2 = "0";
        private int TmR2 = 0;
        private int Tstb = 0;
        private int Tstd = 0;
        private int Tstp = 0;
        private Boolean flg_SaveData = false;
        private Boolean flg_PerStep = false;
        private Boolean flg_Instat = false;
        private Boolean flg_Avg = false;
        private Boolean flg_flyUp = false;
        private Boolean flg_Idle = false;
        private int LogT = 0;
        private int DataCnt = 5;
        private Boolean flg_Ramp = false;
        private Boolean flg_Stb = false;
        private Boolean flg_Std = false;
        private Boolean flg_ProgOut = false;
        private Boolean flg_AnaOut = false;
        
        private Boolean flg_WtrTemp = false;
        private Boolean flg_WtrPress = false;
        private Boolean flg_OliTemp = false;
        private Boolean flg_OilPress = false;
        private Boolean flg_FuelPress = false;
        private Boolean flg_dynaSafety = false;
        private Boolean flg_addPlCAlarm = true;
        private Boolean flg_addwtrpres = true;
        private Boolean flg_addfuelpres = true;
        private Boolean flg_addLuboillpres = true;
        private Boolean flg_addwtrtemp = true;
        private Boolean flg_addLuboilTemp = true;
        private Boolean flg_EngRd = false;
        public TimeSpan s;
        
        public Boolean Auto_Hold = false;        
        public Double Baro = 1.005;
        public Double DryT = 31.2;
        public int rcount = 0;

        private const int DO_portCountShow = 2;
        //private Label[] m_portNum;
        //private Label[] m_portHex;
        public TextBox[,] Do_TextBox;
        Task t1, t2, t3, t4, t5;
		//public static frmsc
		//*****************
        //public string m_IP18;
        //public string m_IP17;
        //public int m_iCount, m_iPort;
        //public int m_iStart1, m_iLength1;
        //public int m_iStart2, m_iLength2;
        //public bool m_bRegister1, m_bStart1;
        //public bool m_bRegister2, m_bStart2;
        ////private Stopwatch st = new Stopwatch();
        ////private System.Windows.Forms.Timer timer1;
        ////private ColumnHeader columnHeaderValFloat;
        //public AdamSocket adamTCP1;
        //public AdamSocket adamTCP2;
        //public Random rand1 = new Random();
        //public static Thread RdADAMThread;

		//************************





		//private static readonly Random random = new Random();
		//public SerialPort PIDPORT = new SerialPort();

        public static frmScrII frmPar = new frmScrII();
        public static frmSmoke frmsmk = new frmSmoke(); 




		public frmMain()
        {
            InitializeComponent();           
            Global.Rd_System();
            Global.ConfigDevice();           
        }

        private void Init_Counter()
        {

            if (m_isCounterReseted == true)
            {
                try
                {
                    if (freqMeterCtrl1.Initialized && freqMeterCtrl1.Channel != -1)
                    {
                        freqMeterCtrl1.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    //ShowErrorMessage(ex);
                }
                m_frequecy = new double[0];

            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {  
                Resolution.CResolution ChangeRes = new Resolution.CResolution(FixHeight, FixWidth);
                    lblLog.BringToFront();
                    AddListItem("Main Function started...", "Normal");
                    Global.Rd_Confg();
                    Load_Arr();
                    PBar1.Value = 1;
                    PBar2.Value = 1;
                    PBar3.Value = 1;
                    Update_Tss1(0);
                    //Init_Gantner();                   
                    Process[] prs = Process.GetProcesses();                     
                    foreach (Process pr in prs)
                    {
                        //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                        if (pr.ProcessName == "Editors") pr.Kill();                      
                        if (pr.ProcessName == "EXCEL") pr.Kill();
                        if (pr.ProcessName == "EXCEL") pr.Kill();
                    }
                    //Configur_Gantner();

                    //Init_TCP_Port();

                    frmPar.Show();  
				 
               ///*******************
              
                  Init_Counter();  
                //******************

                  //tmrfData.Start();
                  //t1 = Task.Run(() => { clsADAM6000.Read_AdamValues6018(); });
                  //t2 = Task.Run(() => { clsADAM6000.Read_AdamValues6017(); }); 
                

			   	tmrRead.Enabled = true;


                
                    Global.Rd_System();
                    Global.SFC_msg = "SFC Status .....";


                   
                    this.Meter1.MinValue = 0;
                    this.Meter1.MaxValue = float.Parse(Global.sysIn[11]);
                  

                   
                    this.Meter2.MinValue = 0;
                    this.Meter2.MaxValue = float.Parse(Global.sysIn[12]);
                   

                    Global.Make_mdb(Global.DataPath);                                     
                    flg_AnaOut = true;
                    //////

                    if (Global.sysIn[17].ToString() == "TRUE") Ds_Pos = "1"; else Ds_Pos = "0";
                    Global.flg_prjOn = false;
                    Global.Rd_COM_Confg(); 

                    //Tss9.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //  Global.InstantAO.SelectedDevice = new Automation.BDaq.DeviceInformation(0);
                    //instantAoCtrl1.SelectedDevice = new Automation.BDaq.DeviceInformation(1);
                    //if (Global.msPort.IsOpen == false) Global.Init_SrPort();
                    //if (Global.RTPort.IsOpen == false) Global.Init_RTPort();
                    //Global.Mode_Out(1, 0, 0);
                    Global.AnaOut1 = 0.01;
                    Global.AnaOut2 = 0.01;

                    init_ReadyStatus();
                    //GridSeq.RowCount = 20;
                    //LoadDgView(); 
                    tmrWrite.Start(); 
                    ResetOutPut();

                    panel6.Visible = false; 




				//**********************
			}
			catch (Exception ex)
            {
                MessageBox.Show("Error in frmmain _Load",ex.Message);

                Login frm = new Login();
                frm.ShowDialog();
                frm.Dispose();
                if (Global.flg_Log_service == true)
                {
                    //frmSysP frm1 = new frmSysP();
                    //frm1.ShowDialog();
                    //frm1.Dispose();
                }
            }
        }

        //****************************

        //private void Init_Gantner()
        //{
        //    int HONLCLIENT = -1, HONLCONNECTION = -1;
        //    int ret = 0;
        //    int ChannelCount = 0;
        //    double info1 = 0;
        //    byte[] baTempInfo = new byte[1024];
        //    string strTempString = "";
        //    double outValue = 0;

        //    string IP = "192.168.1.28";
        //    //*******************
        //    ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Address, 0, ref info1, baTempInfo);
        //    ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Type, 0, ref info1, baTempInfo);
        //    ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.SampleRate, 0, ref info1, null);

        //    HSP._CD_eGateHighSpeedPort_GetNumberOfChannels(HONLCONNECTION, (int)HSP.DATADIRECTION.InputOutput, ref ChannelCount);

        //}

        //private void Online(string IP)
        //{
        //    try
        //    {
        //        int HONLCLIENT = -1, HONLCONNECTION = -1;
        //        int ret = 0;
        //        double info1 = 0;
        //        byte[] baTempInfo = new byte[1024];

        //        double outValue = -1;

        //        ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);
        //        HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
        //        //Global.GenData[ReadChannel + 26] = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.0000");      //outValue.ToString("##0.0");
        //        Global.GenData[ReadChannel + 26] = (Global.RandomNumberBetween((outValue + 0.5), (outValue - 0.7))).ToString("000.00000");

        //        if (ReadChannel <= 20)               
        //            ReadChannel++; 
        //        else
        //            ReadChannel = 0;

        //        //HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
        //        //Global.GenData[ReadChannel + 26] = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.0000");      //outValue.ToString("##0.0");
        //        //Global.GenData[ReadChannel + 26] = outValue.ToString("000.0000");
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //private static void ConvertZeroTerminatedByteArray2String(out string Destination, byte[] Source)
        //{
        //    int i, MaxIndex;

        //    MaxIndex = Source.GetUpperBound(0);
        //    Destination = "";
        //    i = Source.GetLowerBound(0);
        //    while ((Source[i] != 0) && (i <= MaxIndex))
        //    {
        //        Destination += (char)Source[i];
        //        i++;
        //    }
        //    Destination = Destination.Trim();
        //}


    

        ////****************************

        //public void Init_TCP_Port()
        //{
        //    clsADAM6000.m_bRegister1 = true;        // set to true to read the register, otherwise, read the coil
        //    clsADAM6000.m_bRegister2 = true;       // set to true to read the register, otherwise, read the coil
        //    clsADAM6000.m_IP18 = "192.168.1.241"; // "172.18.3.243";	// modbus slave IP address
        //    clsADAM6000.m_IP17 = "192.168.1.242";  //modbus slave IP address
        //    clsADAM6000.m_iPort = 502;              // modbus TCP port is 502
        //    clsADAM6000.m_iStart1 = 1;              // modbus starting address
        //    clsADAM6000.m_iLength1 = 8;
        //    clsADAM6000.m_iStart2 = 1;              // modbus starting address
        //    clsADAM6000.m_iLength2 = 8; // modbus reading length
        //    clsADAM6000.adamTCP1 = new AdamSocket();
        //    clsADAM6000.adamTCP2 = new AdamSocket();
        //    clsADAM6000.adamTCP1.SetTimeout(1000, 1000, 1000); // set timeout for TCP
        //    clsADAM6000.adamTCP2.SetTimeout(1000, 1000, 1000); // set timeout for TCP

        //}

		private void Init_PIDPORT()
        {
            try
            {
                PIDPORT.PortName = "COM3";
                if (PIDPORT.IsOpen == true) PIDPORT.Dispose(); // .Close();
                PIDPORT.BaudRate = int.Parse("9600");
                PIDPORT.DataBits = int.Parse("8");
                PIDPORT.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                PIDPORT.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (PIDPORT.IsOpen == false)
                {
                    PIDPORT.Dispose();
                    PIDPORT.PortName = "COM3";   //sysIn[20];
                    PIDPORT.Open();
                }

            }
            catch
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
                return;
            }
        }
        //*****************************************
        //private void Read_AdamValues6018()
        //{
        //    try
        //    {
        //        int iIdx;
        //        int[] iData;

        //        while (true)
        //        {
        //            if (m_bRegister1) // Read registers (4X references)
        //            {
        //                adamTCP1.Connect(m_IP18, ProtocolType.Tcp, m_iPort);
        //                if (adamTCP1.Modbus().ReadHoldingRegs(m_iStart1, m_iLength1, out iData))
        //                {
        //                    for (iIdx = 0; iIdx < m_iLength1; iIdx++)
        //                    {
        //                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 1370) / 65535) * 1000;
        //                        Global.GenData[10 + iIdx] = (Global.RandomNumberBetween((ValF + 0.5), (ValF - 0.7)) / 1000).ToString("000.00000");
        //                    }                                             
        //                }
        //            }                 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //private void Read_AdamValues6017()
        //{
        //    try
        //    {
        //        int iIdx = 0;
        //        int[] iData;

        //        while (true)
        //        {
        //            if (m_bRegister2) 
        //            {
        //                adamTCP2.Connect(m_IP17, ProtocolType.Tcp, m_iPort);
        //                if (adamTCP2.Modbus().ReadHoldingRegs(m_iStart2, m_iLength2, out iData))
        //                {
        //                    for (iIdx = 0; iIdx < m_iLength2; iIdx++)
        //                    {
        //                        Double V = (Double.Parse(Global.PMax[18 + iIdx]) - Double.Parse(Global.PMin[18 + iIdx])) / 16;
        //                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 16) / 65535) * 1000;
        //                        Global.GenData[18 + iIdx] = ((Global.RandomNumberBetween((ValF + 0.5), (ValF - 0.7)) * V / 1000) + Double.Parse(Global.PMin[18 + iIdx])).ToString("000.00000");
        //                    }
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}



        //public void ADAM6018_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {

        //            clsADAM6000.Read_AdamValues6018();
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
        //            clsADAM6000.Read_AdamValues6017(); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //public void Gantner_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {                   
        //            string controllerIP = "192.168.1.28";
        //            Online(controllerIP);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

      


        //public void fLog_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            Thread.Sleep(9);
        //            LogfData();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}
        //public void RINST_RT_Thread()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            Thread.Sleep(80);
        //            Global.Rd_SerialPort_RT(); // Read_ECUValues();
        //            Tss5.Text = Global.bufftss8;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}






        private void Load_Arr()
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
			//// Second Page
			//InV[28] = ipVal29;
			//InV[29] = ipVal30;
			//InV[30] = ipVal31;
			//InV[31] = ipVal32;
			//InV[32] = ipVal33;
			//InV[33] = ipVal34;
			//InV[34] = ipVal35;

			//InV[35] = ipVal36;
			//InV[36] = ipVal37;
			//InV[37] = ipVal38;
			//InV[38] = ipVal39;
			//InV[39] = ipVal40;
			//InV[40] = ipVal41;
			//InV[41] = ipVal42;
			//InV[42] = ipVal31;
			//InV[43] = ipVal32;
			//InV[44] = ipVal33;
			//InV[45] = ipVal34;
			//InV[46] = ipVal35;
			//InV[47] = ipVal48;
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
                //Global.Configure_Gantner(); 
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_calpar ORDER BY N ", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();

                int x = 0;
				while (Rd.Read())
				{
					if (x > 27) break;
					scrn_Cal[x] = Rd.GetValue(1).ToString();
					x += 1;
				}
				Rd.Close();
                Global.con.Close();

                for (I = 0; I <= 27; I++)
                {
					InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(scrn_Cal[I])].ToString()));

					InV[I].Invoke(new Action(() => InV[I].BackColor =   Color.DarkGray));
                    InV[I].Invoke(new Action(() => InV[I].P_Color = Color.Navy));
					InV[I].Invoke(new Action(() => InV[I].U_Color = Color.Black));
					InV[I].Invoke(new Action(() => InV[I].colFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
					InV[I].Invoke(new Action(() => InV[I].P_Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
					InV[I].Invoke(new Action(() => InV[I].U_Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));

					if (InV[I].P_Name == "Not_Prog")
					{
						InV[I].P_Name = "";
						InV[I].P_Unit = "";
						InV[I].Invoke(new Action(() => InV[I].colFillColor = Color.LightGray));
						InV[I].Invoke(new Action(() => InV[I].colForeColor = Color.LightGray));
					}
					else
					{
						InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(scrn_Cal[I])]));

						InV[I].Invoke(new Action(() => InV[I].P_Unit = Global.PUnit[int.Parse(scrn_Cal[I])].ToString()));


                        InV[I].colFillColor = Color.Teal; 
						InV[I].colForeColor = Color.White;
					}

				}
                Global.Create_OnLog("Load_Arr()", "Normal ");
               

                if (Global.InstantDI.Initialized) tmrWrite.Enabled = true;

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Load_Arr()", "Alart"); 
                //MessageBox.Show("Error in frmMain: Load_Arr():  " + ex.Message);
            }
        }
		
        public int randomvalue(int min,int max)
        {
            Random rnd = new Random();
            return rnd.Next(min,max);

        }
		//*************************

        //private void write_InputValues()
        //{
        //    try
        //    {
        //        string pr;
        //        for (int i = 0; i < 48; i++)
        //        {
        //            pr = Global.scrn_Par[i];                   
        //            frmScrII.InV[i].P_Value = Global.GenData[int.Parse(pr)];  //str;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //*********************


        private void Write_Cal_Values()
        {
            int i;
            String sg = null;
            try
            {
                String str;
                tmrRead.Interval = 100;
                //Global.Corfact = 1.0572;
                           
                Global.GenData[105] = Global.Corfact.ToString("0.0000");

                Global.GenData[111] = (Global.VarPowkW * Global.Corfact).ToString("00.00");
                Global.GenData[116] = (Global.VarPowHp * Global.Corfact).ToString("00.0");
                Global.GenData[121] = Global.Data[121];
                Global.GenData[122] = Global.Data[122];
                Global.GenData[123] = Global.Data[123];
                Global.GenData[124] = Global.Data[124]; 
            
                for (i = 0; i < 27; i++)
                {
                    sg = scrn_Cal[i];
                        
                        //(i + 101).ToString();
                    str = Global.GenData[int.Parse(sg)];
                    InV[i].P_Value = string.Format("{0:00.000}", str);     // string.Format("{0:000.000}", str); 
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //private void DisplayLimits()
        //{
        //    try
        //    {
        //        int i;
        //        String sg = null;
        //        String str;
        //        if (InV[i].P_Name != "Not_Prog")
        //        {
        //            if ((Global.GenData[int.Parse(sg)] != null) && (Global.PSName[int.Parse(sg)] != "Not_Prog")) 
        //            {
        //                str = Global.GenData[int.Parse(sg)];
                   
        //                    if (Global.BufLim[int.Parse(sg)] == "O")
        //                    {
        //                        InV[i].colFillColor = Color.Blue;
        //                        Tss3.Text = "Engine Off : " + Global.PSName[i];
        //                        Tss3.BackColor = Color.Red;
        //                        Tss3.ForeColor = Color.Yellow;
        //                        //stopEngine(); 
                               
        //                    }
        //                    else if (Global.BufLim[int.Parse(sg)] == "I")
        //                    {
        //                        if (InV[i].colFillColor == Color.Green)
        //                        {
        //                            InV[i].colFillColor = Color.Yellow;
        //                            InV[i].colForeColor = Color.Red;
        //                            Tss3.Text = "Engine IDLE : " + Global.PSName[i];
        //                            Tss3.BackColor = Color.Red;
        //                            Tss3.ForeColor = Color.Yellow;
        //                        }                                   
        //                        else
        //                        {
        //                            InV[i].colFillColor = Color.ForestGreen;
        //                            InV[i].colForeColor = Color.White;                                        
        //                        }

        //                        }
        //                    else if (Global.BufLim[int.Parse(sg)] == "A") //&& (Global.flg_LimitON == true))
        //                    {
        //                        if (InV[i].colFillColor == Color.Green)
        //                        {
        //                            InV[i].colFillColor = Color.Red;
        //                            InV[i].colForeColor = Color.Yellow;

        //                            }
        //                        else if (InV[i].colFillColor == Color.Red)
        //                        {
        //                            InV[i].colFillColor = Color.ForestGreen;
        //                            InV[i].colForeColor = Color.White;
        //                        }

        //                        }
        //                    else if (Global.BufLim[int.Parse(sg)] == "N")
        //                    {

        //                            InV[i].colFillColor = Color.ForestGreen;
        //                            InV[i].colForeColor = Color.White;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        //                    }
        //                }
        //                else if (int.Parse(sg) > 100)
        //                {
        //                    InV[i].colFillColor = Color.ForestGreen;
        //                    InV[i].colForeColor = Color.White;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));                      
        //                }
        //            }
        //        }
        //        else
        //        {
        //            InV[i].Text = "";
        //            //    }



        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }

        //}



                //{
            //   
            //    if (InV[i].P_Name != "Not_Prog")
            //    {
            //        if ((Global.GenData[int.Parse(sg)] != null) && (Global.PSName[int.Parse(sg)] != "Not_Prog")) // && (int.Parse(sg) <= 120))
            //        {  
            //            str = Global.GenData[int.Parse(sg)];

                //            InV[i].P_Value = str;    // string.Format("{0:##0.0##}", str); 

                //            if (int.Parse(sg) <= 28)
            //            {
            //                if (Global.BufLim[int.Parse(sg)] == "O")
            //                {
            //                    InV[i].colFillColor = Color.Blue;
            //                    Tss3.Text = "Engine Off : " + Global.PSName[i];
            //                    Tss3.BackColor = Color.Red;
            //                    Tss3.ForeColor = Color.Yellow;
            //                    //stopEngine(); 
            //                    break;
            //                }
            //                else if (Global.BufLim[int.Parse(sg)] == "I")
            //                {
            //                    if (InV[i].colFillColor == Color.Green)
            //                    {
            //                        InV[i].colFillColor = Color.Yellow;
            //                        InV[i].colForeColor = Color.Red;
            //                        Tss3.Text = "Engine IDLE : " + Global.PSName[i];
            //                        Tss3.BackColor = Color.Red;
            //                        Tss3.ForeColor = Color.Yellow;
            //                    }                                   
            //                    else
            //                    {
            //                        InV[i].colFillColor = Color.ForestGreen;
            //                        InV[i].colForeColor = Color.White;                                        
            //                    }

                //                }
            //                else if (Global.BufLim[int.Parse(sg)] == "A") //&& (Global.flg_LimitON == true))
            //                {
            //                    if (InV[i].colFillColor == Color.Green)
            //                    {
            //                        InV[i].colFillColor = Color.Red;
            //                        InV[i].colForeColor = Color.Yellow;

                //                    }
            //                    else if (InV[i].colFillColor == Color.Red)
            //                    {
            //                        InV[i].colFillColor = Color.ForestGreen;
            //                        InV[i].colForeColor = Color.White;
            //                    }

                //                }
            //                else if (Global.BufLim[int.Parse(sg)] == "N")
            //                {

                //                    InV[i].colFillColor = Color.ForestGreen;
            //                    InV[i].colForeColor = Color.White;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            //                }
            //            }
            //            else if (int.Parse(sg) > 100)
            //            {
            //                InV[i].colFillColor = Color.ForestGreen;
            //                InV[i].colForeColor = Color.White;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));                      
            //            }
            //        }
            //    }
            //    else
            //    {
            //        InV[i].Text = "";
            //        //    }


        //            double r = double.Parse(Global.GenData[0]);
            //            if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
            //            Global.varRPM = (Int16)r;  
            //            double n = double.Parse(Global.GenData[1]);
            //            if (Global.GenData[1] != null) lblTrq.Text = n.ToString("000.0"); else lblTrq.Text = "000.0";
            //            Global.varTRQ = n; 

        //        //Global.varRPM = Int16.Parse(Global.GenData[0]);
            //        //Global.varTRQ = Double.Parse(lblTrq.Text);             
            //        //label4.Text = Global.GenData[7];                
            //        //label5.Text = Global.GenData[10];
            //        //label6.Text = Global.GenData[13];
            //        //label7.Text = Global.GenData[22]; 

        //       
            //        }
            //        flg_Showlim = false;
            //        for ( i = 0; i <= 50; i++)
            //        {
            //            if (Global.BufLim[i] == "A")
            //            {
            //                flg_Showlim = true;                        
            //                break;
            //            }
            //        }
            //        if ((flg_Showlim == true) && (Global.varRPM  >= 650)) //(Global.flg_EngStart = true)) 
            //        {
            //            Tss3.BackColor = Color.Red;
            //            Tss3.ForeColor = Color.Yellow;
            //            Tss3.Text = "Check Alarm : " + Global.PSName[i]; 
            //        }
            //        else
            //        {
            //            Tss3.BackColor = Color.Gainsboro;
            //            Tss3.ForeColor = Color.Red;
            //            Tss3.Text = "Alarm Status..."; 
            //        }
            //}

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show("Error in frmMain: WriteValues():  " + ex.Message);
        //        Global.Create_OnLog("Error In writeValue Function......", "Alart");
        //        return;
        //    }
        //}
        public void servicelog()
        {
            mnusyspara.Enabled  = true;
        }
        public void supervisorlog()
        {
            mnuEditor.Enabled = true;
            mnuProject.Enabled = true; 
        }
        public void disable_log()
        {
            mnusyspara.Enabled = false;
            mnuEditor.Enabled = false;
            mnuProject.Enabled = false; 
        }

      
       private void tmrWrite_Tick(object sender, EventArgs e)
        {
            try
            {                  
                if (wrtCnt >= 8) wrtCnt = 0; else wrtCnt += 1;
                if (Global.flg_SFCStart == true) 
                    Read_SFC();
                Tss1.Text = Global.SFC_msg; //  +" : " + Global.SFC_Msg_from_Inst;
                if (flg_AnaOut == true)
                {
                    if (Global.flg_Smt_Changeover == true) Fun_AnalogOut_SmoothChangeover();
                    if (Global.flg_Std_Changeover == true) Fun_AnalogOut_StandardChangeover();

                }
                    
                
                   
                //if ( freqMeterCtrl1.Value < 6500)
                //     Global.GenData[0] = freqMeterCtrl1.Value.ToString("0000.0");  
                Write_Cal_Values();
				//******************************************
                //Global.flg_simulateRPM = true;

				if (Global.flg_simulateRPM == true)
                {                  
                     if (int.Parse(Global.C_Mode) >= 5)
                        {
                            Global.S_pt2 = (int)(Global.AnaOut2 * Global.AnaOut1 * 6);
                            Global.S_pt1 = (int)(Global.AnaOut1 * 1000);
                        }
                        else
                        {
                            Global.S_pt2 = (int)(Global.AnaOut2 * 25);
                            Global.S_pt1 = (int)(Global.AnaOut1 * 1000);
                        }



                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        if (Global.S_pt1 <= 800) Global.S_pt1 = 800;
                        if (Global.S_pt2 <= 0.10) Global.S_pt2 = 0.1;
                        int t = (int)Global.S_pt1;
                        Global.GenData[0] = RandomNumber(t - 1, t + 1).ToString("0000");
                        Global.varRPM = Convert.ToInt16(Global.GenData[0]);
                        lblRPM.Text = Global.varRPM.ToString("0000");

                        Double X = (Double)Global.S_pt2;
                        if (X >= 400) X = 400;
                        Global.GenData[1] = Global.RandomNumberBetween((X + 0.2), (X - 0.1)).ToString("000.0");
                        Global.varTRQ = Convert.ToDouble(Global.GenData[1]);
                        lblTrq.Text = Global.varTRQ.ToString("000.0");



                        X = 00.0;
                        X = 22;
                        X = double.Parse(textBox1.Text); 
                        Global.GenData[18] = Global.RandomNumberBetween((X + 0.011), (X - 0.02)).ToString("0.000");
                        lblLuboil.Text = Global.GenData[18];
                        PrgLub.Value = (int)((Convert.ToDouble(Global.GenData[18]) * 100)) ; 
                       
                        X = double.Parse(textBox2.Text); 
                        Global.GenData[42] = Global.RandomNumberBetween((X + 0.1), (X - 0.02)).ToString("000");
                       
                        X = double.Parse(textBox3.Text); 
                        Global.GenData[34] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("000.0");

                        X = double.Parse(textBox7.Text); 
                        Global.GenData[35] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("000.0");

                        X = double.Parse(textBox16.Text);
                         Global.GenData[12] = Global.RandomNumberBetween((X + 2), (X - 3)).ToString("000.0");
                        /* X = 80;
                         Global.GenData[26] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("000.0");
                         X = 63;
                         Global.GenData[28] = Global.RandomNumberBetween((X + 0.2), (X - 0.3)).ToString("000.0");
                         X = 77;
                         Global.GenData[29] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                         //X = double.Parse(textBox1.Text);  // 78;
                         //Global.GenData[30] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                         X = 41;
                         Global.GenData[31] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                         //X = double.Parse(textBox10.Text);  // 78;
                         Global.GenData[49] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                         //X = double.Parse(textBox11.Text);  // 78;
                         Global.GenData[50] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");

                         X = 72;
                         Global.GenData[32] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                         X = double.Parse(textBox3.Text);  // 78;    635;   // 1255;
                         Global.GenData[36] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                         X = 112;
                         Global.GenData[37] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("0000");
                         X = 165;   // 1322;
                         Global.GenData[38] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                         X = 220; // double.Parse(textBox3.Text);  // 78;    635;   // 1255;
                         Global.GenData[39] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                         X = 62;
                         Global.GenData[40] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");

                         X = 35.2; // 822;
                         Global.GenData[41] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 822; //0.990; //
                         Global.GenData[42] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 63.2; // 822;
                         Global.GenData[43] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = double.Parse(textBox2.Text);

                         Global.GenData[44] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 1.352; // 822;
                         Global.GenData[45] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 1.234; // 605;
                         Global.GenData[46] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 1.8;
                         Global.GenData[47] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 0.52;
                         Global.GenData[48] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 1.8;
                         Global.GenData[52] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         X = 3.5;
                         Global.GenData[54] = Global.RandomNumberBetween((X + 0.01), (X - 0.02)).ToString("0.000");
                         */
                        //X = Double.Parse(Global.GenData[0]) / 600; // Vardouble.Parse(textBox7.Text);
                        //Global.GenData[71] = Global.RandomNumberBetween((X + 0.001), (X - 0.002)).ToString("0.000");

                        //double r = double.Parse(Global.GenData[0]);
                        //if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";

                        //double l = double.Parse(Global.GenData[1]);
                        //if (Global.GenData[1] != null) lblTrq.Text = l.ToString("000.0"); else lblTrq.Text = "000.0";

                        //double p = double.Parse(Global.GenData[44]);
                        //if (Global.GenData[44] != null) lblLubOil.Text = p.ToString("0.000"); else lblLubOil.Text = "0.000";
                        ////Meter3.Value = int.Parse(lblLubOil.Text);  


                    }
                  
                else
                {
					
					if (Global.GenData[0] != null)
                    {
                        double r = double.Parse(Global.GenData[0]);
                        if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                        Double l = Double.Parse(Global.GenData[0]);
                        Global.varRPM = Int16.Parse(l.ToString("0000"));
                    }
                    else lblRPM.Text = Global.varRPM.ToString("0000");
                    if (Global.GenData[1] != null)
                    {
                        double n = double.Parse(Global.GenData[1]);
                        if (Global.GenData[1] != null) lblTrq.Text = n.ToString("000.0"); else lblTrq.Text = "000.0";
                        Double l = Double.Parse(Global.GenData[1]);
                        Global.varTRQ = Math.Abs(Double.Parse(l.ToString("000.0")));
                        lblTrq.Text = Global.varTRQ.ToString("000.0");
                    }
                    else lblTrq.Text = Global.varTRQ.ToString("000.0");
                    if (Global.GenData[9] != null)
                    {
                        double m = double.Parse(Global.GenData[9]); 
                        Int16 n = Convert.ToInt16    (m * 100);
                        PrgLub.Value = n;
                    }
                }
               // ******************************************   
 

                          
                switch (wrtCnt) 
                {
                    case 1:
                        //if (flg_ProgOut == true) Fun_ProgOut();
                        if (Global.Flg_Ready == true)
                        {
                            if (Global.flg_Auto == true)
                            {
                                RdProg();
                                Btn21.Enabled = true;
                                BtnSA .Enabled = false;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Auto = false;
                                Global.Flg_Ready = false;
                            }
                            else if (Global.flg_Manual == true)
                            {
                                Btn21.Enabled = false;
                                BtnSA.Enabled = true;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Manual = false;
                                Global.Flg_Ready = false;
                            }
                        }
                        Tss8.Text = DateTime.Now.ToString("hh:mm:ss"); //     .ToShortTimeString("");                        
                        break;
                    case 2:
                        
                        Check_ReadyDyno();
                     
                        if ((Global.varRPM >= 650) && (Global.flg_CycleStarted == true))
                        {                            
                            ChkFuelP();
                            ChkLubP();
                            ChkWtrT();
                            ChkLubT();
                        }
                        break;
                    case 3:
                        if (Global.flg_Log_service == true) servicelog(); else if (Global.flg_Log_supervisor == true) supervisorlog(); else disable_log();
                       
                         Meter1.Value = float.Parse(Global.GenData[0]);
                         Meter2.Value = float.Parse(Global.GenData[1]);

                        break;
                    case 4:
                        if (Global.StpN > 1) clsLimit.Check_Limit(); else clsLimit.Check_Limit_Standby(); 
                        string Buff = "";
                        if ( (Global.flg_smk = true) && (Global.smkPort.IsOpen == true))
                        {
                            Buff = Global.smkPort.ReadExisting();
                            Tss5.Text = Buff.Substring(7, 1);
                            if (Buff.Substring(7, 1) == "0")
                            {
                                //Tss5.Text = (Buff.Substring(7, 1); // Buff.Substring(9, 5);
                                Global.SmkVal = Convert.ToDouble(Buff.Substring(9, 5)); //Tss5.Text;  
                            }
                        }                                          
                        break;                    
                    case 5:
                        if (Global.varRPM >= 600) ctlLED1.tmron = true; else ctlLED1.tmron = false;   
                        break;
                    case 6:
						Global.ReadAnalog();


						if (Tss3.Text != "SFC Status .....")
						{
                            //if (Tss3.BackColor == Color.Gainsboro)
                            //{
                            //    Tss3.BackColor = Color.Red;
                            //    Tss3.ForeColor = Color.Yellow;
                            //}
                            //else if (Tss3.BackColor == Color.Red)
                            //{
                            //    Tss3.BackColor = Color.Gainsboro;
                            //    Tss3.ForeColor = Color.Yellow;
                            //}
						}
						else
						{
                            Tss3.BackColor = Color.Gainsboro;
                            Tss3.ForeColor = Color.WhiteSmoke;
						}
						break;
                    case 7:
                        if  (Global.varRPM >= 650)
                        {
                            C_Hours = Int16.Parse(Tss2.Text.Substring(0, 4));
                            C_Minutes = Int16.Parse(Tss2.Text.Substring(5, 2));
                            C_Seconds = Int16.Parse(Tss2.Text.Substring(8, 2));
                            clsFun.TmCounter(C_Hours, C_Minutes, C_Seconds, true);
                            Tss2.Text = clsFun.cummbuff; 
                        }
                        else
                        {
                            //TextBox1.Text = "0000:00:00";
                        }
                        break;
                    case 8:
                         //Write_Cal_Values();
                        //Tss8.Text = DateTime.Now.ToShortTimeString(); 
                        Global.VarPowkW  = clsFun.kW_Power(Global.varRPM, Global.varTRQ);
                        Global.VarPowHp  = clsFun.HP_Power(Global.varRPM, Global.varTRQ);

                        Double P1 = Convert.ToDouble(Global.GenData[Global.fxd[10]]); //Global.Atp; // 
                        Double D1 = Convert.ToDouble(Global.GenData[Global.fxd[8]]) + 4; //.Global.Drb; //
                        Double W1 =Convert.ToDouble(Global.GenData[Global.fxd[9]]);  //  Global.Web; // Convert.ToDouble(Global.GenData[Global.fxd[9]]);

                        Global.Rel_Hum = clsFun.Cal_Rel_Humid(P1, D1, W1);
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0") ;
                        if (Global.Prj[4] == "CF_DIN")
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);
                        else if (Global.Prj[4] == "CF_IS_10003")
                            Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                        else
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

                        if ((Global.Corfact > 1.2) || (Global.Corfact < 0.8)) Global.Corfact = 1.00000;

                       Global.GenData[105]  = Global.Corfact.ToString("0.0000");   

                        Global.varbmep = clsFun.Cal_bmep(Global.varTRQ, Double.Parse(Global.Svol));
                        Global.C_VarPowkW = Global.VarPowkW * Global.Corfact;
                        Global.C_VarPowHp = Global.VarPowHp * Global.Corfact; 

                        //TextBox2.Text = Global.VarPowHp.ToString();

                        //TextBox3.Text = Global.Corfact.ToString();
                        if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;

                        Global.GenData[101] = Global.SmkVal.ToString() ; //     SmkVal;
                        Global.GenData[105] = Global.Corfact.ToString("0.0000");       
                        Global.GenData[106] = Global.varTRQ.ToString("00.0");
                        Global.GenData[107] = Global.VarPowkW.ToString("00.0");                                         
                        Global.GenData[110] = ((Global.Corfact) * (Global.varTRQ)).ToString("00.0");
                        Global.GenData[111] = ((Global.Corfact) * (Global.VarPowkW)).ToString("00.0");
                        Global.GenData[115] = Global.VarPowHp.ToString("00.0");
                        Global.GenData[116] = ((Global.VarPowHp) * (Global.Corfact)).ToString("00.0");
                        Global.GenData[119] = Global.varbmep.ToString();
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0");
                        Global.GenData[123] = Tss2.Text; 
                        break;

                }
              
            }
               
            catch (Exception ex)
            {
            //    MessageBox.Show("Error in frmMain: tmrWrite_Tick():  " + ex.Message);
            //    Global.Create_OnLog(ex.Message);
                return;
            }

        }

        private void init_ReadyStatus()
        {
            try
            {
                if (Global.sysIn[20] == "FALSE")
                {
                    checkBox3.CheckState = CheckState.Unchecked;
                    checkBox3.Text = "ENG. WATER PRESS NOT CHECKED.....";                   
                }
                else
                {
                    checkBox3.CheckState = CheckState.Indeterminate;
                    Lower1 = double.Parse(Global.sysIn[21]);
                    High1 = double.Parse(Global.sysIn[22]);
                    checkBox3.Text = "ENG. WATER PRESS : " + Lower1 + " ~ " + High1;                    
                }


                if (Global.sysIn[23] == "FALSE")
                {
                    checkBox4.CheckState = CheckState.Unchecked;
                    checkBox4.Text = "ENG.FUEL PRESS NOT CHECKED.....";                   
                }
                else
                {
                    checkBox4.CheckState = CheckState.Indeterminate;
                    Lower2 = double.Parse(Global.sysIn[24]);
                    High2 = double.Parse(Global.sysIn[25]);
                    checkBox4.Text = "ENG. FUEL PRESS : " + Lower2 + " ~ " + High2;                   
                }

                if (Global.sysIn[26] == "FALSE")
                {
                    checkBox5.CheckState = CheckState.Unchecked;
                    checkBox5.Text = "ENG. LOIL PRESS NOT CHECKED......";                   
                }
                else
                {
                    checkBox5.CheckState = CheckState.Indeterminate;
                    Lower3 = double.Parse(Global.sysIn[27]);
                    High3 = double.Parse(Global.sysIn[28]);
                    checkBox5.Text = "ENG. LOIL PRESS : " + Lower3 + " ~ " + High3;                  
                }

                if (Global.sysIn[29] == "FALSE")
                {
                    checkBox6.CheckState = CheckState.Unchecked;
                    checkBox6.Text = "ENG. WTR_OUT TEMP NOT CHECKED....";                   
                }
                else
                {
                    checkBox6.CheckState = CheckState.Indeterminate;
                    Lower4 = double.Parse(Global.sysIn[30]);
                    High4 = double.Parse(Global.sysIn[31]);
                    checkBox6.Text = "ENG WTROUT TEMP : " + Lower4 + " ~ " + High4;
                    
                }

                if (Global.sysIn[32] == "FALSE")
                {
                    checkBox7.CheckState = CheckState.Unchecked;
                    checkBox7.Text = "ENG. LOIL TEMP NOT CHECKED.....";                   
                }
                else
                {
                    checkBox7.CheckState = CheckState.Indeterminate;
                    Lower5 = double.Parse(Global.sysIn[33]);
                    High5 = double.Parse(Global.sysIn[34]);
                    checkBox7.Text = "ENG. LOIL TEMP: " + Lower5 + " ~ " + High5;                    
                }
                //if (Global.flg_Radiator == true)
                //{
                //    checkBox16.Text = "REDIATOR CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Indeterminate  ;
                //    checkBox16.ForeColor = Color.MediumBlue; 
                //}
                //else
                //{
                //    checkBox16.Text = "REDIATOR NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox16.ForeColor = Color.Red;  
                //}
                //if (Global.flg_Fan == true)
                //{
                //    checkBox17.Text = "COOLING FAN CONNECTED ........";
                //    checkBox17.CheckState = CheckState.Indeterminate;
                //    //checkBox17.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox17.Text = "COOLING FAN  NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox17.ForeColor = Color.Red;
                //}
                //if (Global.flg_AirCln == true)
                //{
                //    checkBox18.Text = "AIR CLEANER CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Indeterminate;
                //    //checkBox18.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox18.Text = "AIR CLEANER NOT CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Unchecked; 
                //    //checkBox18.ForeColor = Color.Red;
                //}
                //if (Global.flg_Silincer == true)
                //{
                //    checkBox19.Text = "SILINCER CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Indeterminate;
                //    //checkBox19.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox19.Text = "SILINCER NOT CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Unchecked; 
                //    //checkBox19.ForeColor = Color.Red;
                //}


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Init_ReadyStatus():", "Alart"); 
                //MessageBox.Show("E""rror in frmMain: Init_ReadyStatus():  " + ex.Message);
            }
        }


        private void Check_ReadyDyno()
        {
            try
            {
				if (Global.DigIn[0] !=  1)  //Global.flg_VolActive)
                {
                    UpdateCheckBox(checkBox2, 0);
                    checkBox2.Text = " NO SYSTEM - ALARM .....";                
                    cntDSafty = 0;
                   
                    flg_ProgEnd = false;
                    flg_dynaSafety = false;
                    flg_addPlCAlarm = true;
                }
                else
                {
                    UpdateCheckBox(checkBox2, 1);
                    checkBox2.Text = " CHECK SYSTEM-ALARM...ENG. NOT READY";
                    if ((Global.varRPM > 600) && (Global.flg_CycleStarted == true))
                    {
                        if (cntDSafty < 3) cntDSafty += 1;
                        if (cntDSafty == 3)
                        {
                            if (flg_addPlCAlarm == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox2.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox2.Text + " at RPM :" + Global.varRPM,"Alart"); 
                                flg_addPlCAlarm = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;
                           cntDSafty = cntDSafty + 1;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_ReadyDyno():", "Alart"); 
                //MessageBox.Show("Error in Check_ReadyDyno(): " + ex.Message);
            }
        }

        private void Check_wtrPress()
        {
            try
            {
                if (checkBox3.CheckState == CheckState.Indeterminate)
                {

                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[2]]);
                    if ((l > Lower1) && (l < High1))
                    {
                        UpdateCheckBox(checkBox3, 0);
                        checkBox3.Text = "ENG. Wtr PRESS : " + Lower1 + "~" + High1;
                         wPCnt = 0;
                        flg_ProgEnd = false;
                        flg_WtrPress  = false;
                        flg_addwtrpres  = true;
                    }
                    else
                    {
                        if (flg_addwtrpres  == true) UpdateCheckBox(checkBox3, 1);
                        checkBox3.Text = "Check Engine Wtr Press...";
                        if (wPCnt < 3) wPCnt += 1; else wPCnt = 4;
                        if (wPCnt == 3)
                        {
                            if (flg_addwtrpres  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox3.Text + " at RPM :" + Global.varRPM, 9);
                               Global.Create_OnLog("Engine is @ idle due to " + checkBox3.Text + " at RPM :" + Global.varRPM,"Alart"); 
                                flg_addwtrpres  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_WtrPress():", "Alart"); 
                //MessageBox.Show("Error in Check_WtrPress(): " + ex.Message);
            }

        }

        private void ChkFuelP()
        {
            try
            {
                if (checkBox4.CheckState == CheckState.Indeterminate)
                {
                 
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[3]]);
                    if ((l > Lower2) && (l < High2))
                    {
                        UpdateCheckBox(checkBox4, 0);
                        checkBox4.Text = "ENG. FUEL PRESS : " + Lower2 + "~" + High2;
                        fPCnt = 0;
                        flg_ProgEnd = false;
                        flg_FuelPress = false;
                        flg_addfuelpres = true;
                    }
                    else
                    {
                        if (flg_addfuelpres == true) UpdateCheckBox(checkBox4, 1);                       
                        checkBox4.Text ="Check Engine Fuel Press...";
                        if (fPCnt < 3)  fPCnt += 1;else fPCnt = 4;
                        if(fPCnt == 3)
                        {
                             if (flg_addfuelpres  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM,"Alart");
                                 flg_addfuelpres  = true;
                            }

                           if(Global.flg_EngStart == true )  tmrEnd.Enabled = true;
                         
                        }
                    }
                        
                }
               
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check WtrPress():", "Alart"); 
                //MessageBox.Show("Error in ChkFuelP(): " + ex.Message);
            }
        }

        private void ChkLubP()
        {
            try
            {
                if (checkBox5.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[4]]);
                    if ((l > Lower3) && (l < High3))
                    {
                        UpdateCheckBox(checkBox5, 0);                       
                        checkBox5.Text = "ENG. LubOil PRESS : " + Lower3 + "~" + High3;
                        lPCnt = 0;
                        flg_ProgEnd = false;
                        flg_OilPress = false;
                        flg_addLuboillpres = true;

                    }
                    else
                    {
                        if (flg_addLuboillpres == true) UpdateCheckBox(checkBox5, 1);
                        checkBox5.Text = "Check Engine Luboil Press...";

                        if (lPCnt < 3) lPCnt += 1; else lPCnt = 4;
                        if (lPCnt == 3)
                        {
                            if (flg_addLuboillpres  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox5.Text + " at RPM :" + Global.varRPM, 9);
                                flg_addLuboillpres  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChkLub():", "Alart"); 
                //MessageBox.Show("Error in ChkLubP(): " + ex.Message);
            }
        }

        private void ChkWtrT()
        {
            try
            {

                if (checkBox6.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[5]]);
                    if ((l > Lower4) && (l < High4))
                    {
                        UpdateCheckBox(checkBox6, 0);
                        checkBox6.Text = "ENG. Wtr Temp : " + Lower4 + "~" + High4;
                        wTCnt  = 0;
                        flg_ProgEnd = false;
                        flg_WtrTemp  = false;
                        flg_addwtrtemp  = true;

                    }
                    else
                    {
                        if (flg_addwtrtemp  == true) UpdateCheckBox(checkBox6, 1);
                        checkBox6.Text = "Check Engine Wtr Temp...";
                        if (wTCnt < 3) wTCnt  += 1; else wTCnt = 4;
                        if (wTCnt  == 3)
                        {
                            if (flg_addwtrtemp  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox6.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM,"Alart");
                                flg_addwtrtemp  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }

                    }
                }
               
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChkWtrT():", "Alart"); 
                //MessageBox.Show("Error in ChkWtrT(): " + ex.Message);
            }
        }

        private void ChkLubT()
        {
            try
            {

                if (checkBox7.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[6]]);
                    if ((l > Lower5) && (l < High5))
                    {
                        UpdateCheckBox(checkBox7, 0);
                        checkBox7.Text = "ENG. LubOil Temp : " + Lower5 + "~" + High5;
                        lTCnt = 0;
                        flg_ProgEnd = false;
                        flg_OliTemp = false;
                        flg_addLuboilTemp = true;

                    }
                    else
                    {
                        if (flg_addLuboilTemp == true) UpdateCheckBox(checkBox7, 1);
                        checkBox7.Text = "Check Engine LubOil Temp...";
                        if (lTCnt < 3) lTCnt += 1; else lTCnt = 4;
                        if (lTCnt == 3)
                        {
                            if (flg_addLuboilTemp == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM,"Alart");
                                flg_addLuboilTemp = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChkLubT():", "Alart"); 
                //MessageBox.Show("Error ChkLubT() : " + ex.Message);
            }
        }

        private void Update_Tss1(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                    Tss1.Text = Global.SFC_msg; 
                }
                else if (Stus == 1)
                {
                    if (Tss1.BackColor == Color.Gainsboro)
                    {
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                    }
                    else if (Tss1.BackColor == Color.Red)
                    {
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.Brown;
                    }

                }
            }
            catch (Exception ex)
            {
                return;//MessageBox.Show("Error in frmMain: update_tss11():  " + ex.Message);
            }
        }

       

        private void Update_Hold(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                }
                else if (Stus == 1)
                {
                    if (Tss1.BackColor == Color.Gainsboro)
                    {
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                    }
                    else if (Tss1.BackColor == Color.Red)
                    {
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.Brown;
                    }

                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error in frmMain: update_Hold():  " + ex.Message);
            }
        }



        private void UpdateCheckBox(CheckBox Chk, int Stt)
        {
            try
            {
                if (Stt == 0)
                {
                    Chk.ForeColor = Color.Navy ;
                    Chk.BackColor = Color.Gainsboro;
                    //groupBox4.SendToBack();  
                }
                else if (Stt == 1)
                {
                    //groupBox4.BringToFront();  
                    switch (Chk.Name)
                    {
                        //case "checkBox1":
                        //    if (checkBox1.BackColor == Color.Gainsboro)
                        //    {
                        //        checkBox1.BackColor = Color.Red;
                        //        checkBox1.ForeColor = Color.Yellow;
                        //    }

                        //    else if (checkBox1.BackColor == Color.Red)
                        //    {
                        //        checkBox1.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                        //        checkBox1.ForeColor = Color.Navy;
                        //    }
                        //    break;
                        case "checkBox2":
                            if (checkBox2.BackColor == Color.Gainsboro)
                            {
                                //flg_addPlCAlarm = false;
                                checkBox2.BackColor = Color.Red;
                                checkBox2.ForeColor = Color.Yellow;
                            }

                            else if (checkBox2.BackColor == Color.Red)
                            {
                                checkBox2.BackColor = Color.Gainsboro;  //
                                checkBox2.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox3":
                            if (checkBox3.BackColor == Color.Gainsboro)
                            {
                                flg_addwtrpres = false;
                                checkBox3.BackColor = Color.Red;
                                checkBox3.ForeColor = Color.Yellow;
                            }
                            else if (checkBox3.BackColor == Color.Red)
                            {
                                checkBox3.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox3.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox4":
                            if (checkBox4.BackColor == Color.Gainsboro)
                            {
                                flg_addfuelpres = false;
                                checkBox4.BackColor = Color.Red;
                                checkBox4.ForeColor = Color.Yellow;

                            }
                            else if (checkBox4.BackColor == Color.Red)
                            {
                                checkBox4.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox4.ForeColor = Color.Navy;
                            }

                            break;
                        case "checkBox5":
                            if (checkBox5.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboillpres = false;
                                checkBox5.BackColor = Color.Red;
                                checkBox5.ForeColor = Color.Yellow;
                            }
                            else if (checkBox5.BackColor == Color.Red)
                            {
                                checkBox5.BackColor = Color.Gainsboro;
                                checkBox5.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox6":
                            if (checkBox6.BackColor == Color.Gainsboro)  //SystemColors.ButtonFace)
                            {
                                flg_addwtrtemp = false;
                                checkBox6.BackColor = Color.Red;
                                checkBox6.ForeColor = Color.Yellow;
                            }
                            else if (checkBox6.BackColor == Color.Red)
                            {
                                checkBox6.BackColor =Color.Gainsboro;  // SystemColors.ButtonFace;
                                checkBox6.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox7":
                            if (checkBox7.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboilTemp = false;
                                checkBox7.BackColor = Color.Red;
                                checkBox7.ForeColor = Color.Yellow;
                            }
                            else if (checkBox7.BackColor == Color.Red)
                            {
                                checkBox7.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox7.ForeColor = Color.Navy;
                            }
                            break;

                    }
                }
               
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: UpdateChexkbox():  " + ex.Message);
            }
        }
        private void Show_Dialog()
        {
            if ((flg_WtrPress == true) || (flg_dynaSafety == true) || (flg_WtrTemp == true) || (flg_EngRd == true)
                        || (flg_OliTemp == true) || (flg_FuelPress == true) || (flg_OilPress == true))
            {

               
                //groupBox1.BringToFront();
                //groupBox1.Visible = true;
            }
            else
            {
               
                //groupBox1.BringToFront();
                //groupBox1.Visible = false;
            }
        }

        
       
           //***********************
        public void Load_ProgStep()
        {
            try
            {
                String T = "0";
                String D = "0";
                String CH = "0";
                Global.SmkVal = 0.00;
                Global.L_Mode = Global.C_Mode;

                Global.S_StartTime = System.DateTime.Now.ToString("hh:mm:ss tt"); 
                if (tmrAvg.Enabled == true)
                {
                    tmrAvg.Stop();
                    AddListItem("Averaging Intrrupted for SFC....", "Normal");
                }
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("DELETE FROM avgTemp", Global.con);
                cmd.ExecuteNonQuery();               

                if (Global.StpN >= 1)
                {
                    clsLimit.Read_Limfl();
                }              

                if ((Global.StpN + 1) > (GridSeq.RowCount - 1))
                {
                    stopEngine();
                    AddListItem("Program Over.....", "Normal");
                }

                AddListItem((Global.StpN + 1) + " : Prog.Step Started", "Alart");
                txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                Global.flg_RLoop = false;
                Global.StNo = (Global.StpN + 1);
                Global.LastAna1 = Double.Parse(Global.SetPtOut1);
                Global.LastAna2 = Double.Parse(Global.SetPtOut2);

                GridSeq.Rows[Global.StpN].Selected = true;
                if (Global.StpN >= 4) GridSeq.FirstDisplayedScrollingRowIndex = (Global.StpN - 1);

                if (GridSeq[0, Global.StpN].Value != null)
                {
                    Global.C_Mode = GridSeq.Rows[Global.StpN].Cells[1].Value.ToString();
                    T = GridSeq.Rows[Global.StpN].Cells[3].Value.ToString();
                    TmR1 = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    if (TmR1 <= 1) TmR1 = 1;
                    T = GridSeq.Rows[Global.StpN].Cells[5].Value.ToString();
                    TmR2 = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    if (TmR2 <= 1) TmR2 = 1;


                    T = GridSeq.Rows[Global.StpN].Cells[6].Value.ToString();
                    Tstb = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));

                    T = GridSeq.Rows[Global.StpN].Cells[7].Value.ToString();
                    Tstd = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    SockT = Tstd;
                   
                    

                    T = GridSeq.Rows[Global.StpN].Cells[8].Value.ToString();
                    Tstp = ((int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2)));

                    T = GridSeq.Rows[Global.StpN].Cells[10].Value.ToString();
                    CH = T.Substring(0, 1);
                    switch (CH)
                    {
                        case "Y":
                            LogT = 5;
                            flg_PerStep = true;
                            flg_Instat = false;
                            flg_Avg = false;
                            flg_SaveData = true;
                            break;
                        case "H":
                            LogT = 5;
                            flg_flyUp = true;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "L":
                            LogT = 5;
                            flg_Idle = true;
                            flg_flyUp = false;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "I":
                            LogT = (int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2));
                            flg_PerStep = false;
                            flg_Instat = true;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        case "A":
                            LogT = (int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2));
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = true;
                            DataCnt = LogT;
                            break;
                        case "N":
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        default:
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                    }
                    if (GridSeq.Rows[Global.StpN].Cells[11].Value.ToString() == "True")
                    {
                        Global.flg_SMK415_S = true;
                        Global.flg_smokeStart = true;
                    }

                    T = GridSeq.Rows[Global.StpN].Cells[13].Value.ToString();

                    int fc = int.Parse(T);

                    if (GridSeq.Rows[Global.StpN].Cells[14].Value.ToString() == "True")
                    {
                        //Global.flg_fastlog = true;
                        //Global.flg_flog = true;
                        ////Global.log_freq = fc;
                        //AddListItem("Fast Logging Started .......", "Normal"); 
                    }
                    else
                    {
                        //Global.flg_fastlog = false;
                        //Global.flg_flog = false;
                        //Global.log_freq = 0;
                        //AddListItem("No Fast Logging Data .......", "Normal"); 
                    }
                   


                    //Global.Ex_Bk = Convert.ToDouble(GridSeq.Rows[Global.StpN].Cells[13].Value);
                    //if (GridSeq.Rows[Global.StpN].Cells[15].Value.ToString() == "True")
                    //{
                    //    flg_ExBkP = true;
                    //    if ((Global.Ex_Bk >= 10) && (flg_ExBkP == true))
                    //    {
                    //        //textBox23.Text = Global.Ex_Bk.ToString();
                    //        //Global.Dig_OutBit(0, 0, true);
                    //        //Global.Dig_OutBit(0, 1, true);
                    //        //button51.PerformClick();
                    //    }
                    //}
                    //else
                    //{
                    //    Global.Dig_OutBit(0, 0, false);
                    //}

                    //if ((Convert.ToBoolean(GridSeq.Rows[Global.StpN].Cells[14].Value.ToString() == true)) && (IC <= 10)) Global.Write_SetValue(16, IC);
                    //M_Trq = GridSeq.Rows[Global.StpN].Cells[15].Value.ToString();
                    

                    if (GridSeq.Rows[Global.StpN].Cells[16].Value.ToString() == "True")
                    {
                        Global.Auto_SFC = true;
                        rcount = 0;
                    }
                    else
                        Global.Auto_SFC = false;

                    TolT = GridSeq.Rows[Global.StpN].Cells[18].Value.ToString();

                    //Global.MinPow = GridSeq.Rows[Global.StpN].Cells[19].Value.ToString();
                    //DGLim[1, 0].Value = Global.MinPow;
                    //Global.MaxSmoke = GridSeq.Rows[Global.StpN].Cells[20].Value.ToString();
                    //DGLim[1, 1].Value = Global.MaxSmoke;
                    //Global.MaxFD = GridSeq.Rows[Global.StpN].Cells[21].Value.ToString();
                    //DGLim[1, 2].Value = Global.MaxFD;

                    //Global.SPARE_1 = GridSeq.Rows[Global.StpN].Cells[22].Value.ToString();
                    //DGPassLim[1, 3].Value = Global.SPARE_1 + "  <>"; ;
                    //Global.SPARE_2 = GridSeq.Rows[Global.StpN].Cells[23].Value.ToString();
                    //DGPassLim[1, 4].Value = Global.SPARE_2 + "  <>";
                    //Global.SPARE_3 = GridSeq.Rows[Global.StpN].Cells[24].Value.ToString();
                    //DGPassLim[1, 5].Value = Global.SPARE_3 + "  <>"; ;
                    //Global.SPARE_4 = GridSeq.Rows[Global.StpN].Cells[25].Value.ToString();
                    //DGPassLim[1, 6].Value = Global.SPARE_4 + "  <>";
                    //Global.SPARE_5 = GridSeq.Rows[Global.StpN].Cells[26].Value.ToString();
                    //DGPassLim[1, 7].Value = Global.SPARE_5 + "  <>";




                    //M_Trq = GridSeq.Rows[Global.StpN].Cells[15].Value.ToString();
                    //if (M_Trq == "MT") Global.Mx_Trq = true; else Global.Mx_Trq = false;
                    //E_Hld = GridSeq.Rows[Global.StpN].Cells[16].Value.ToString();
                    //if (E_Hld == "HC") Auto_Hold = true; else Auto_Hold = false;



                    //**********************************
                    int pos1 = 0;
                    string str1 = "";
                    int pos2 = 0;
                    string str2 = "";

                    //*************For Regular  Change Over
                    if (Global.flg_Std_Changeover == true)
                    {
                        switch (Global.C_Mode)
                        {
                            case "6":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "5":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);

                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(D)) / 10).ToString();
                                break;
                            case "4":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "3":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "2":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;
                            default:
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;

                        }
                    }

                    //*************For Smooth Change Over
                    else if (Global.flg_Smt_Changeover == true)
                    {
                        Double Y = 0;
                        switch (Global.C_Mode)
                        {
                            case "6":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "5":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                Double x = (Double.Parse(D) * (Global.Max_Trq)) / 100;
                                Global.SetPtOut2 = ((x * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                label10.Text = "%T";
                                //Global.SetPtOut2 = ((Double.Parse(D)) / 10).ToString();
                                break;
                            case "4":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "3":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "%R";
                                Global.SetPtOut1 = ((Double.Parse(D) * 100) / Global.F_Rpm).ToString();

                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "2":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%T";
                                Y = double.Parse(T) * (Global.Max_Trq) / 100;
                                Global.SetPtOut2 = ((Y * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();

                                //Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Global.Max_Trq)).ToString();                           
                                break;
                            default:
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;
                        }
                    }
                    else
                    {
                        switch (Global.C_Mode)
                        {
                            case "6":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "5":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);

                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(D)) / 10).ToString();
                                break;
                            case "4":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "3":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "T";
                                Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "2":
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "R";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;
                            default:
                                str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label10.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;

                        }
                    }
                    Global.LastT = Convert.ToDouble(T);
                    Global.LastD = Convert.ToDouble(D);

                    //***********************
                    if ((int.Parse(Global.L_Mode) <= 4) && (int.Parse(Global.C_Mode) >= 5))
                    {
                        Global.AnaOut1 = double.Parse(Global.SetPtOut1);
                        TmR1 = 1;
                    }

                    if (TmR1 <= 1) TmR1 = 1;
                    if (TmR2 <= 1) TmR2 = 1;

                    if (TmR1 > TmR2) TmR = TmR1; TmR = TmR2;
                    PBar3.Maximum = TmR + 1;

                    int A = TmR1 * 9;
                    int B = TmR2 * 9;

                    //TmR1 = 
                    //TmR2 = TmR2 * 9;
                   
                    Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / A;
                    Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / B;
                    ///////////////////// 
                    Global.Create_OnLog("Step Started :" + Global.StNo, "Normal");
                    PBar1.Maximum = 10000;
                    PBar2.Maximum = 10000;
 
                    //st.Start();

                }
                //else
                //{
                //    Btn22.PerformClick();

                //}
            }
            catch
            {
                Global.Create_OnLog("Error in frmMain: Load_ProgStep():  ","Alart"); //  + ex.Message);
               
            }
        }   
      
        public  void Load_Gridseq_header()
        {
            try
            {
                GridSeq.ColumnCount = 20;
                if (GridSeq.RowCount < 10) GridSeq.RowCount = 10; 
                foreach (DataGridViewColumn colm in GridSeq.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                GridSeq.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                GridSeq.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                GridSeq.Columns[0].Width = 40;
                GridSeq.Columns[0].HeaderText = "Sn";
                GridSeq.Columns[1].Width = 40;
                GridSeq.Columns[1].HeaderText = "MD";
                GridSeq.Columns[2].Width = 60;  //
                GridSeq.Columns[2].HeaderText = "SetPt-1  (rpm)";
                GridSeq.Columns[3].Width = 60;  //
                GridSeq.Columns[3].HeaderText = "RmT-1  (mm:ss)";
                GridSeq.Columns[4].Width = 60;  //
                GridSeq.Columns[4].HeaderText = "SetPt-2 (%)";
                GridSeq.Columns[5].Width = 60;  //
                GridSeq.Columns[5].HeaderText = "RmT-2 (mm:ss)";
                GridSeq.Columns[6].Width = 60;  //
                GridSeq.Columns[6].HeaderText = "T_Stb  (mm:ss)";
                GridSeq.Columns[7].Width = 60;  //
                GridSeq.Columns[7].HeaderText = "T_Std  (mm:ss)";
                GridSeq.Columns[8].Width = 60;  //
                GridSeq.Columns[8].HeaderText = "Stop  (mm:ss)";
                GridSeq.Columns[9].Width = 90;
                GridSeq.Columns[9].HeaderText = "Repeat   (" + Global.loopcount + " )";
                GridSeq.Columns[10].Width = 60;  //
                GridSeq.Columns[10].HeaderText = "LogData     (" + LogT + ")";
                //txtrepeate.Text = Global.loopcount.ToString();
                //txtlog.Text = LogT.ToString();
                GridSeq.Columns[11].Visible = Visible;
                GridSeq.Columns[11].Width = 40;  //
                GridSeq.Columns[11].HeaderText = "SFC  (G/V)";
                GridSeq.Columns[12].Visible = false;
                GridSeq.Columns[12].Width = 90;  //
                GridSeq.Columns[12].HeaderText = "MinLP (bar)";
                GridSeq.Columns[13].Visible = false;   
                GridSeq.Columns[13].Width = 90;  //60;
                GridSeq.Columns[13].HeaderText = "MaxVal ";
                GridSeq.Columns[14].Visible = false;
                GridSeq.Columns[14].Width = 90;  //50;
                GridSeq.Columns[14].HeaderText = "Dwtr";
                GridSeq.Columns[15].Visible = false;
                GridSeq.Columns[15].Width = 90;  //50;
                GridSeq.Columns[15].HeaderText = "D1";
                GridSeq.Columns[16].Visible = false;
                GridSeq.Columns[16].Width = 90;  //30;h
                GridSeq.Columns[16].HeaderText = "D2";
                GridSeq.Columns[17].Visible = false;
                GridSeq.Columns[17].Width = 90;  //40;
                GridSeq.Columns[17].HeaderText = "D3";
                GridSeq.Columns[18].Width = 60;  //80;
                GridSeq.Columns[18].HeaderText = "Tm";
                GridSeq.Columns[19].Width = 235;  //80;
                GridSeq.Columns[19].HeaderText = "Step Name";

                Global.Create_OnLog("Load _Grid Sequence SuccessFull:  ", "Normal");
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Load_Gridseq_header():  ","Alart");
            }
          
        }
        //public void Check_Limit()
        //{
        //    Int16 L = 0;
        //    String A1, B1, C1, D1;
        //    String A2 = "";
        //    String B2 = "";
        //    String C2 = "";
        //    String D2 = "";
        //    Double InVal = 0;

        //    try
        //    {
                
        //        for (L = 0; L <= 95; L++)
        //        {
        //            if (L == 2) L = 6;                  
        //                A1 = Global.LL1[L].Substring(0, 1);
        //                B1 = Global.L1[L].Substring(0, 1);
        //                C1 = Global.H1[L].Substring(0, 1);
        //                D1 = Global.HH1[L].Substring(0, 1);

        //                if (Global.LL1[L].Substring(1) != String.Empty) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                if (Global.L1[L].Substring(1) != String.Empty) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                if (Global.H1[L].Substring(1) != String.Empty) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                if (Global.HH1[L].Substring(1) != String.Empty) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];
        //            //}
        //            InVal = Double.Parse(Global.GenData[L]);
        //            Global.StrAlarm = "";
        //            if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Double.Parse(D2))))
        //            {
        //                Global.Flg_AList = true;
        //                if ((Global.Flg_AList == true) && (Global.arrLim[L] == "") || (Global.arrLim[L] == "A"))
        //                {
        //                    Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "0";      //if (ViewGrid[2, L].Style.BackColor == Color.Green) 
        //                    Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L]);
        //                    Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];  
        //                    btnAlarm.Text ="Engine ShutOFF: " + Global.PSName[L];
        //                    AddListItem("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal, 2);
        //                    //Global.Create_OnLog("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal);
        //                    LogData();
        //                    stopEngine();
        //                    return;
        //                }
        //            }
        //            else if (((A1 == "I") && (InVal < double.Parse(A2))) || ((D1 == "I") && (InVal > Double.Parse(D2))))
        //            {
        //               Global.Flg_AList = true;
        //                if ((Global.Flg_AList == true) &&   (Global.BufLim[L] != "I"))    //(ViewGrid[2, L].Style.BackColor == Color.Gainsboro))
        //                {
        //                    Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "I";    //if (ViewGrid[2, L].Style.BackColor == Color.Blue)
        //                    Global.Create_OnLog("Idle  : " + Global.PSName[L]);
        //                    Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];  
        //                    btnAlarm.Text ="Engine @ Idle:" + Global.PSName[L];
        //                    AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal,10);
        //                    //Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal);
        //                    LogData();
        //                    IdelEng(); 
        //                    return;
        //                }
        //            }
        //            else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //            {
        //                Global.Flg_AList = true;
                      
        //                if ((Global.Flg_AList == true) && ((Global.arrLim[L] == "") || (Global.arrLim[L] == null)))    //A : " + Global.PSName[L] + " ";
        //                {
        //                    Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "A";  //if (ViewGrid[2, L].Style.BackColor == Color.Red)
        //                    AddListItem("Alarm  : " + Global.PSName[L], 4);
        //                    //Global.Create_OnLog("Alarm  : " + Global.PSName[L]);                          
        //                    btnAlarm.Text = "Check Engine Alarm..";
        //                }
                      
        //            }
                   
        //            else
        //            {
                        
        //                Global.arrLim[L] = "";
        //                Global.BufLim[L] = "N";
                       
        //            }
        //            for (int k = 0; k <= 95; k++)
        //            {
        //                Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                if (Global.StrAlarm == "") btnAlarm.Text = "Engine Is Running.....";
   
        //            }
        //        }


        //    }
        //    catch 
        //    {

        //        //MessageBox.Show("Error Check_Limit :" + L + " : " + InVal + ex.Message);
        //        //AddListItem("En Check_Limit :" + L + " : " + InVal, 10);
        //        Global.Create_OnLog("En Check_Limit :" + L + " : " + InVal);  
        //    }
        //}
        public void Check_Limit_Standby()
        {
            Int16 L = 0;
            String B1, C1;
            String B2 = "";
            String C2 = "";
            Double InVal = 0;
           
                for (L = 0; L <= 95; L++)
                {
                    if (L == 2) L = 6;                    
                    B1 = Global.Ls[L].Substring(0, 1);
                    C1 = Global.Hs[L].Substring(0, 1);
                    if (Global.Ls[L].Substring(1) != String.Empty) B2 = Global.Ls[L].Substring(1); else B2 = Global.PMin[L];
                    if (Global.Hs[L].Substring(1) != String.Empty) C2 = Global.Hs[L].Substring(1); else C2 = Global.PMax[L];

                    InVal = Convert.ToDouble(Global.GenData[L]);
                    Global.StrAlarm = "";
                    if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                    {
                        Global.BufLim[L] = "A";                       
                    }
                    else
                    {                       
                        Global.BufLim[L] = "N";
                    }
                }
        }
        private void Check_Limit()
        {
          Int16 L = 0;
          String A1 = "";
          String B1 = "";
          String C1 = "";
          String D1 = "";

          String A2 = "";
          String B2 = "";
          String C2 = "";
          String D2 = "";
          Double InVal = 0;

          try
          {
              for (L = 0; L <= 95; L++)
              {
                  if (L == 2) L = 6;
                  if (Global.PSName[L] != "Not_Prog")
                  {
                      if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
                      if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
                      if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
                      if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

                      if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
                      if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
                      if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
                      if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

                      if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
                      Global.StrAlarm = "";
                      if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Convert.ToDouble(D2))))
                      {
                          Global.Flg_AList = true;
                          if ((Global.Flg_AList == true))
                          {
                              Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
                              Global.BufLim[L] = "O";     
                              Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L],"Alart");
                              Global.StrAlarm = "Engine 'OFF'" + Global.arrLim[L];
                              AddListItem("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal,"Alart");
                              LogData();
                              stopEngine();
                              return;
                          }
                      }
                      else if (((A1 == "I") && (InVal < Convert.ToDouble(A2))) || ((D1 == "I") && (InVal > Convert.ToDouble(D2))))
                      {
                          Global.Flg_AList = true;

                          if (Global.LimNo[L] <= 2)
                          {
                              Global.LimNo[L] += 1;
                              //AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], 6);
                              Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal,"Alart");
                          }
                          if (Global.LimNo[L] > 2)
                          {
                              if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))   
                              {
                                  Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
                                  Global.BufLim[L] = "I";                                  
                                  Global.StrAlarm = "Engine @ Idle " + " : " + InVal;
                                  AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal, "Alart");
                                  LogData();
                                  IdleEng();
                                  return;
                              }
                          }
                          //return;
                      }
                      //Global.StrAlarm = "";
                      else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                      {                          
                          if (Global.BufLim[L] == "N")
                          {
                              Global.BufLim[L] = "A";
                              Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
                              AddListItem("Alarm  : " + Global.PSName[L], "Alart");
                          }
                      }
                      else
                      {
                          Global.BufLim[L] = "N";
                      }                      
                  }
              }
                for (int k = 0; k <= 95; k++)
                {
                  Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
                }
              }
          catch (Exception ex)
          {
              Global.Create_OnLog("Error in frmMain: Error Check_Limit : " + InVal, "Alart");
              //Global.Create_OnLog("Error Check_Limit :" + L + " : " + InVal + ex.Message,false);
          }
        }


        public void AddListItem(string message, string str)
        {
            try
            {
                if (Global.varRPM >= 600)
                {
                    string[] arr = new string[4];
                    ListViewItem itm;


                    arr[0] = Global.L_Cn.ToString("0000");
                    arr[1] = System.DateTime.Now.ToString("hh:mm:ss");
                    arr[2] = message;
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);




                    //listView1.Items.Add(new ListViewItem((Global.L_Cn).ToString("0000")));
                    //listView1.Items[Global.L_Cn].SubItems.Add(System.DateTime.Now.ToString("hh:mm:ss"));
                    //listView1.Items[Global.L_Cn].SubItems.Add(message);

                    if (str == "Alart")
                    {
                        listView1.Items[Global.L_Cn].SubItems[1].ForeColor = Color.Red;
                        listView1.Items[Global.L_Cn].SubItems[2].ForeColor = Color.Red;
                    }
                    else
                    {
                        listView1.Items[Global.L_Cn].SubItems[1].ForeColor = Color.Blue;
                        listView1.Items[Global.L_Cn].SubItems[2].ForeColor = Color.Blue;
                    }
                    
                    listView1.EnsureVisible(listView1.Items.Count - 1);

                    if (message.StartsWith(Global.StNo + ": Step Started") == false)
                    {                        
                        Global.Create_OnLog(message,str);
                    }
                    Global.L_Cn++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: AddListItem():  " + ex.Message);
            }
        }
        public void Check_Necessary_Files()
        {
            try
            {
                if (System.IO.Directory.Exists(Global.PATH) == false)
                {

                    MessageBox.Show(Global.PATH + " folder does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "General.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " General.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Data.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Data.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Limit.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Limit.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Sequence.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Sequence.accdb does not exist!!! Can not start Application.");

                }

                if (System.IO.File.Exists(Global.PATH + "Log.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " Log.accdb does not exist!!! Can not start Application.");
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_Necessary_Files() : ", "Alart");
                MessageBox.Show("Error in frmMain: Check_Necessary_Files():  " + ex.Message);
                
            }
        }

        private void Fun_ProgOut()
        {
            string str;
            try
            {

                if (TmR > 0)
                {
                    //lblStatus.Text = "RAMP TIME:";
                    PBar3.Caption = "RAMP TIME:";
                    GridSeq.Enabled = false;
                    flg_Ramp = true;
                    flg_Stb = false;
                    flg_Std = false;
                    //lblStatus.ForeColor = Color.Red; 
                    TmR = TmR - 1;
                    if (TmR1 > 0) TmR1 = (TmR1 - 1);
                    if (TmR2 > 0) TmR2 = (TmR2 - 1);
                    if (TmR1 <= 0)
                    {
                        TmR1 = 0;
                        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        if((Global.C_Mode =="1")||(Global.C_Mode =="3")  )
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("0000");
                        else
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    }
                    if (TmR2 <= 0)
                    {
                        TmR2 = 0;
                        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        if ((Global.C_Mode == "1") || (Global.C_Mode == "2") || (Global.C_Mode == "5"))
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("000.0");
                        else
                            txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                    }
                    t = TimeSpan.FromSeconds(TmR);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", TmR);
                    settimefor_gridseq();
                    PBar3.Value = TmR;

                    if (TmR <= 0)
                    {
                        TmR = 0;
                        //Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        //Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        //lblStatus.Text = "STABILISATION TIME:";
                        PBar3.Caption = "STABILISATION TIME:";
                        GridSeq.Enabled = true;
                        //lblStatus.ForeColor = Color.Green;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        //txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();
                        PBar3.Maximum = Tstb;
                        flg_Ramp = false;
                        flg_Stb = true;
                        flg_Std = false;

                    }
                }
                else if (Tstb > 0)
                {
                    Tstb = (Tstb - 1);
                    t = TimeSpan.FromSeconds(Tstb);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    settimefor_gridseq();
                    PBar3.Value = Tstb;
                    if (Tstb <= 0)
                    {
                        Tstb = 0;                       
                        PBar3.Caption = "STEADY TIME:";
                        GridSeq.Enabled = true;
                        //lblStatus.ForeColor = Color.Blue;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        // txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();

                        if (PBar3.Caption == "STEADY TIME:")                       
                            PBar3.Maximum = Tstd;
                        if (Global.flg_smokeStart == true)
                        {
                            //Global.flg_smokeStart = true;
                            Global.S_Add = 0;
                            tmrSmk.Start(); 
                            //frmsmk.button3.PerformClick();
                            //Global.flg_smokeStart = false;
                        }
                        if (Global.Auto_SFC == true)
                        {
                            Global.SFC_Reset = true;
                            Global.flg_SFC = false;
                            Global.flg_SFCStart = true;
                            Global.flg_DataSave = true;
                        }
                        flg_Ramp = false;
                        flg_Stb = false;
                        flg_Std = true;                      
                    }
                }
                else if (Tstd > 0)
                {
                    Tstd = Tstd - 1;
                    t = TimeSpan.FromSeconds(Tstd);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds );
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", Tstd);  
                    settimefor_gridseq();
                    PBar3.Value = Tstd;
                    if (Tstd <= 0)
                    {
                        Tstd = 0;
                        PBar3.Caption = "RAMP TIME:";
                        GridSeq.Enabled = false;
                        ////////////////////////////////////////////////////////

                        if (GridSeq.Rows[Global.StpN].Cells[9].Value != DBNull.Value)
                        {

                            str = GridSeq.Rows[Global.StpN].Cells[9].Value.ToString();
                            if (str.Substring(3, 1).ToString() == "R")
                            {
                                Global.flg_RLoop = true;
                                Srloop = int.Parse(str.Substring(0, 3).ToString());
                                Erloop = int.Parse(str.Substring(4).ToString());
                                if ((Global.flg_RLoop == true) && (Erloop > Global.loopcount))// (int.Parse(str.Substring(pos + 1)))))
                                {
                                    Global.loopcount += 1;
                                    Global.Create_OnLog("Repeat  (" + Global.loopcount + ")","Normal");
                                    GridSeq.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";
                                    Global.StpN = Srloop - 1;// int.Parse(str.Substring(0, pos)) - 1;
                                    Global.StNo = Global.StpN + 1;
                                }
                                else
                                {
                                    Global.loopcount = 0;
                                    GridSeq.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";

                                    Global.StpN = Global.StpN + 1;
                                    txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                                    Global.StNo = (Global.StpN + 1);
                                }
                            }
                            else
                            {
                                Global.flg_RLoop = false;
                                Global.StpN = Global.StpN + 1;
                                Global.StNo = (Global.StpN + 1);

                            }
                        }
                      /////////////////////////////////////////////////

                        //StpN = StpN + 1;
                        Load_ProgStep();
                        flg_Ramp = true;
                        flg_Stb = false;
                        flg_Std = false;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChFun_ProgOut() : ", "Alart");
                //MessageBox.Show("Error in frmMain: Fun_ProgOut():  " + ex.Message);
            }
           
        }
        private void Hold_Cycle(Boolean flg_Hold)
        {
            try
            {
                if (flg_Hold == true) 
                {
                    Auto_Hold = false;
                    if (Btn24.Text  == "Cycle_Hold")
                   {
                        Btn24.Text = "Cycle_Resume";
                        Global.Create_OnLog("Cycle Hold.....","Normal"); 
                        flg_ProgOut = false;
                        Global.SFC_msg = "Cycle Is on Hold ...";
                        Update_Hold(1); 
                   }                
                   else if (Btn24.Text == "Cycle_Resume")
                   {
                        Btn24.Text = "Cycle_Hold";
                        Global.Create_OnLog("Cycle Resume.....", "Normal");
                        Update_Tss1(0);
                        Global.SFC_msg = "Cycle Is Running...";
                        flg_ProgOut = true;
                        flg_AnaOut = true; 
                        Auto_Hold = false;
                        Global.Auto_SFC = false;
                        Update_Hold(0); 
                   }
                }
                if (Btn24.Text == "Step_Resume")
                {
                    Load_ProgStep();
                    Btn24.Text = "Cycle_Hold";
                    flg_ProgOut = true;
                    flg_AnaOut = true; 
                    for (int i = 0; i <= 68; i++)
                    {
                        InV[i].colFillColor = Color.ForestGreen;
                        InV[i].colForeColor = Color.White;
                    }
                }
            }                           
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Hold_Cycle():  " + ex.Message);
            }
        }

        public void Create_FileName(String ENo)
        {
            try
            {
                String Str = null;
                int pos1 = 1;
                int pos2 = 2;
                int pos3 = 1;
                String Dt = DateTime.Now.ToString("ddMMMyyyy");
                ENo = Global.EngNo;
                ENo = Global.EngNo.Replace(" ", "");
                ENo = ENo.Replace(".", "");
                ENo = ENo.Replace("!", "");
                ENo = ENo.Replace("'", "");
                ENo = ENo.Replace("[]", "");
                ENo = ENo.Replace("_", "");
                ENo = ENo.Replace("-", "");

                //******************************
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblLastFl", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    Str = Rd.GetValue(0).ToString();
                }
                Rd.Close();
                Global.con.Close();  
                if (Global.flg_NewFile == true)
                {
                    pos1 = Str.IndexOf("_", 0);
                    pos2 = Str.IndexOf("_", (pos1 + 1));
                    pos3 = Str.IndexOf("_", (pos2 + 1));

                    int T = int.Parse(Str.Substring(pos3 + 1)) + 1;
                    String Ct = T.ToString("00");
                    String Tp = "";
                    if (Global.TestTyp == "PERFORMANCE") Tp = "Perf_";
                    else if (Global.TestTyp == "ENDURANCE") Tp = "Endu_";
                    else if (Global.TestTyp == "PRODUCTION") Tp = "Prod_";


                    if (Dt == Str.Substring(pos1 + 1, 9))
                    {
                        Global.Eng_FileNm = Tp + Dt + "_" + ENo + "_" + Ct;
                    }
                    else
                    {
                        Global.Eng_FileNm = Tp + Dt + "_" + ENo + "_01";
                    }                   
                    if (Global.Eng_FileNm == String.Empty) Global.Eng_FileNm = Tp + "Manual_Data";

                    Global.Open_Connection("gen_db", "con");
                    cmd = new MySqlCommand("Update tblLastFl SET " +
                        " AutoFile = '" + Global.Eng_FileNm + "'", Global.con);
                    cmd.ExecuteNonQuery();
					//*******************************
					Global.Eng_fData_FileNm = "fData" + (Global.Eng_FileNm.Substring(4));
					Global.Eng_Error_FileNm = "LogErr" + (Global.Eng_FileNm.Substring(4));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(4));
                   
                    checkBox1.Text = Global.Eng_FileNm;                    
                    checkBox8.Text = Global.PrjNm;
                    checkBox13.Text = Global.PrjNm;

                    Create_Table();
					Create_fLogData_Table();
                    ////if (Global.Dly_cnt <= 1000)
                    ////{
                    ////    frmPar.btnStart.Enabled = true;
                    ////    frmPar.btnStop.Enabled = true;
                    ////}
                    ////else
                    ////{
                    ////    frmPar.btnStart.Enabled = false;
                    ////    frmPar.btnStop.Enabled = false;
                    ////}
                    //frmPar.frqVal.Text = Global.HzLog;   

					if (Global.flg_RecorsPmData == true) Create_PMTable();

                    //checkBox15.Text = Global.Eng_FileNm;

                }
                else if (Global.flg_OldFile == true)
                {
                    Global.Eng_FileNm = Str;

                    Global.Eng_Error_FileNm = "LogErr" + (Global.Eng_FileNm.Substring(4));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(4));
                   
                  

                    checkBox13.Text = Global.EngNo;
                    //checkBox15.Text = Global.Eng_FileNm;
                    checkBox8.Text = Global.PrjNm;
                    //checkBox15.Text = Global.Eng_FileNm;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_FileName():  " + ex.Message);

            }
        }

      

        private void Create_Table()
        {
            try
            {
                int i = 0;
                String StrTb = null;
                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " TEXT, ";
                }


                if (System.IO.File.Exists(Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
                Global.Create_OnLog("Alart", ex.Message + ": Create_Table");
            }
        }

       //private void Create_fLogData_Table()
       // {
       //     try
       //     {
       //         int i = 0;
       //         String StrTb = null;
       //         for (i = 0; i <= 49; i++)
       //         {
       //             Global.PSName[i] = Global.PSName[i].Replace(" ", "");
       //             Global.PSName[i] = Global.PSName[i].Replace(".", "");
       //             Global.PSName[i] = Global.PSName[i].Replace("!", "");
       //             Global.PSName[i] = Global.PSName[i].Replace("'", "");
       //             Global.PSName[i] = Global.PSName[i].Replace("[]", "");
       //             StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " VARCHAR(8), ";
                                      
       //         }
       //         StrTb = StrTb + ("050") + Global.PSName[50] + " VARCHAR(8) "; 
       //         Global.Open_DataConn("fData", "fconData");
       //         MySqlCommand cmdTb = new MySqlCommand();
       //         String StrTb1 = "Sn VARCHAR(15)  primary key," + StrTb;     // 
                         

                              

       //         cmdTb.CommandText = "CREATE TABLE " + Global.Eng_fData_FileNm + " (" + StrTb1 + ")";
       //         cmdTb.Connection = Global.fconData;
       //         cmdTb.ExecuteNonQuery();
       //         Global.fconData.Close();
       //     }
       //     catch (Exception ex)
       //     {
       //         MessageBox.Show("Error Code :- 13016 " + ex.Message);
       //     }
       //}
           


        private void Create_fLogData_Table()
        {
            try
            {
                int i = 0;
                String StrTb = null;
                StrTb = "000 Time" + ",";
                //StrTb = StrTb + "001 RPM" + ",";
                //StrTb = StrTb + "002 Torque" + ",";

                for (i = 0; i <= 19; i++)
                {
                    //Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    //Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    StrTb = StrTb + ((i + 1).ToString("000")) + Global.PSName[i+26] + "," ; // + " TEXT, ";
                }
                StrTb = StrTb  + "Blowby_Value" + "," + "Turbospeed" + "," ;


                if (System.IO.File.Exists(Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
                Global.Create_OnLog("Alart", ex.Message + ": Create_Table");
            }
        }


		private void Create_PMTable()
        {
            try
            {
                int i = 0;
                Boolean flg_Filefound = false;
                String StrTb = null;

                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    Global.PSName[i] = Global.PSName[i].Replace("-", "");
                    //StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " TEXT, ";
                }

                StrTb = "TM Date ***, 00RPM rpm, ";
                for (i = 1; i <= 11; i++)
                {
                    //string X = i.ToString("000");
                    StrTb += Global.PSName[Global.Pm_PNo[i]] + " " + Global.PUnit[Global.Pm_PNo[i]] + ", ";
                }
                StrTb = StrTb + "Alarm,";
                if (System.IO.File.Exists(Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in frmMain: Create_Table():  ");
            }
        }


        //public void Make_mdb(String mdbPath)
        //{
        //    try
        //    {
        //        Global.Data_Dir = DateTime.Now.ToString("MMMyy");
        //        String OnLog_Data = "OnLog_" + DateTime.Now.ToString("ddMMMyy");
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo) == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo);
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir) == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data");
        //        }
        //        //if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data") == false)
        //        //{
        //        //    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data");
        //        //}
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data");
        //        }
        //        if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data" + OnLog_Data + ".txt") == false)
        //        {
        //            System.IO.File.Create("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Data + ".txt");
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error:Problem in creating data base ...");
        //    }

        //}

        private void CapturePMData()
        {
            try
            {
                int i = 0;
                int t = 0;
                PmData[0] = DateTime.Now.ToString("hh:mm:ss tt");
                //PmData[1] = Global.varRPM.ToString();

                for (i = 0; i <= 12; i++)
                {
                    t = Global.Pm_PNo[i];
                    PmData[i+1] = Global.GenData[t];
                }
                if (( Global.StrAlarm == null )||( Global.StrAlarm =="" ))   PmData[13] = "****"; else PmData[13] = Global.StrAlarm;

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("PM Data Not Captured.....", "Alart");
                return;

                //MessageBox.Show("Error in CapturePMData():" + ex.Message);
            }
        }
        private void RecordPMData()
        {
            int i = 0;
            CapturePMData();
            String Str = String.Empty;
            String Str1 = String.Empty;
            for (i = 0; i <= 12; i++)
            {
                if (PmData[i] == null)
                {
                    PmData[i] = "0.0";
                }
                Str = Str + PmData[i] + ", ";

            }
            Str = Str + "***" + ",\n";
            var filePath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";

            using (var wr = new StreamWriter(filePath, true))
            {
                var row = new List<string> { Str.Substring(0, Str.Length - 1) };
                var sb = new StringBuilder();
                foreach (string value in row)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(value);
                }
                wr.WriteLine(sb.ToString());
            }
            int linecount = File.ReadAllLines(filePath).Count();
            if (linecount >= 120)
            {
                var file = new List<string>(System.IO.File.ReadAllLines(filePath));
                file.RemoveAt(1);
                File.WriteAllLines(filePath, file.ToArray());
            }
        }

        //public void LogfData()
        //{
        //    try
        //    {				
        //        int i = 0;
        //        Global.Capture_fData();				
        //        String strData = null;               
        //        for (i = 0; i <= 44; i++)
        //        {
        //            if (Global.Data[i] == null) Global.Data[i] = "0.0";
        //            //Global.Data[i] = Global.GenData[i]; 
        //            strData = strData +  Global.Data[i] + ", ";
        //        }
        //        strData = strData +  Global.Data[45] + "\n";
				
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

		public void LogData()
        {
            try
            {
                if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                int i = 0;
                Global.Capture_Data(Global.flg_SFCStart);                
                Global.Sn += 1;
                String strData = String.Empty;
                String strData1 = String.Empty;
                String strData2 = String.Empty;
                String strData3 = String.Empty;
               
                for (i = 0; i < 60; i++)
                {
                    if (Global.Data[i] == null) Global.Data[i] = "000.000";
                    strData1 = strData1 + Global.Data[i] + ", ";
                }
                for (i = 60; i < 100; i++)
                {
                    if (Global.Data[i] == null) Global.Data[i] = "000.000"; 
                    strData2 = strData2 + Global.Data[i] + ", ";
                }
                for (i = 0; i <= 25; i++)
                {
                    if (Global.Data[i + 100] == null) Global.Data[i + 100] = "000.000";
                    strData3 = strData3 + Global.Data[i + 100] + ", ";
                }
                strData = strData1 + strData2 + strData3;
  


                strData = strData + Global.StrAlarm + ", " + Global.Sn + ",\n";
                var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
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
                ////*****************************
               
                flg_SaveData = false;
                frmPar.Update_ViewData(); // Update_ViewData();
                //Global.flg_UpdateViewData = true;

                lblLog.Text = Global.Sn.ToString("000");
                AddListItem("Data Logged... ", "Normal");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in LogData() :" + ex.Message);
                Global.Create_OnLog("Data Log Problem... ", "Normal");
                Global.flg_SFCStart = false;
            }

        }

       
       
        //private void MakeAVGData()
        //{
        //    try
        //    {
        //        String Str = String.Empty;
        //        int i = 0;
        //        int sn1 = 0;
        //        int sn2 = 0;
        //        Global.Open_Connection("gen_db", "con");
        //        SqlDataAdapter Adp = new SqlDataAdapter("SELECT * FROM AvgTemp", Global.con);
        //        DataSet ds = new DataSet();
        //        Adp.Fill(ds);

        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            Str = "SELECT ";
        //            for (i = 0; i < 95; i++)
        //            {
        //                if ((i != 2) && (i != 3) && (i != 4))
        //                {
        //                    if (i == 94)
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
        //                    }
        //                    else
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
        //                    }
        //                }
        //            }

        //            Str = Str + "from AvgTemp";
        //            SqlCommand AVGcmd = new SqlCommand(Str, Global.con);
        //            AVGcmd.ExecuteNonQuery();
        //            SqlDataReader Rd = AVGcmd.ExecuteReader();
                                      
        //            i = 0;
        //            while (Rd.Read())
        //            {
        //                for (i = 0; i < 92; i++)
        //                {
        //                  if (i == 3) Global.ArrData[3] = Global.GenData[3];
        //                  if (i == 4) Global.ArrData[4] = Global.GenData[4];
                           
                           
        //                    Global.ArrData[i] = Rd.GetValue(i).ToString();
                           
        //                    if (Global.ArrData[i] == null)
        //                    {
        //                        Global.ArrData[i] = "0.0";
        //                    }
        //                }
        //            }
        //            Global.con.Close();  
        //            Double T = 0;
        //            T = Double.Parse(Global.ArrData[0]);
        //            Global.ArrData[0] = T.ToString("0000");

        //            Global.AvgRpm = int.Parse(Global.ArrData[0]);
        //            Global.AvgTrq = Convert.ToDouble(Global.ArrData[1]);

        //            if (Convert.ToString(Global.AvgRpm) == null) Global.AvgRpm = Global.varRPM;
        //            if (Convert.ToString(Global.AvgTrq) == null) Global.AvgTrq  = Global.varTRQ;
        //            Double P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
        //            Global.AvgPowPs = Convert.ToDouble(P.ToString("00.00"));
        //            P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
        //            Global.AvgPowkW = Convert.ToDouble(P.ToString("00.00"));
                    
        //            if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
        //            if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;
                   

        //            for (i = 0; i < 92; i++)
        //            {
        //                if (i == Global.fxd[11]) Global.ArrData[11] = Global.GenData[3].ToString();
        //                else if (i == Global.fxd[12]) Global.ArrData[12] = Global.GenData[4].ToString();
        //                else
        //                {
        //                    Double l = Double.Parse(Global.ArrData[i]);
        //                    if (Global.PMax[i].Substring(1, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("0.000");
        //                    }
        //                    else if (Global.PMax[i].Substring(2, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("00.00");
        //                    }
        //                    else if (Global.PMax[i].Substring(3, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("000.0");

        //                    }
        //                    else
        //                    {
        //                        Global.ArrData[i] = l.ToString("0000");
        //                    }
        //                }
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();
        //            int t = 100;
        //            if (Global.flg_SFCStart == true)
        //            {
        //                Global.Data[3] = Global.ArrData[11];
        //                Global.Data[4] = Global.ArrData[12];
        //                Global.Data[t + 1] = Global.SmkVal.ToString();
        //                Global.Data[t + 2] = Global.BlBy.ToString();
        //                Global.Data[t + 3] = Global.ArrData[11].ToString();
        //                Global.Data[t + 4] = Global.ArrData[12].ToString();

        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = Global.SFCVal.ToString("000.0");
        //                Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0"); 
        //                Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) / Global.Corfact).ToString("00.0");
        //                Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //                Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //                Global.Data[t + 15] =  Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = ((Global.SFCVal) / 0.735).ToString("000.0");
        //                Global.Data[t + 18] = ((Global.SFCVal) / (0.735 * Global.Corfact)).ToString("000.0");
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                         
        //            }
        //            else 
        //            {
        //                Global.Data[3] = "00.00";
        //                Global.Data[4] = "00.00";
        //                Global.Data[t + 1] = "00.00";
        //                Global.Data[t + 2] = "00.00";
        //                Global.Data[t + 3] = "00.00";
        //                Global.Data[t + 4] = "00.00";
        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = "00.00";
        //                Global.Data[t + 9] = "00.00";
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 12] = "00.00";
        //                Global.Data[t + 13] = "00.00";
        //                Global.Data[t + 14] = "00.00";
        //                Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = "00.00";
        //                Global.Data[t + 18] = "00.00";
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                       
        //            }
        //            Global.Data[122] = Global.Prj[5]; // +", " + Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //            Global.Data[123] = Global.StpTm;
        //            Global.Data[124] = Global.cumhours;   //Global.Data[124] = "***"; // Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //                if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
        //                Global.Data[125] = Global.StrAlarm;
                   
        //            Global.Open_Connection("gen_db", "Con");
        //            SqlCommand cmd = new SqlCommand("DELETE * FROM AVGTemp", Global.con);
        //            cmd.ExecuteNonQuery();
        //            Global.con.Close ();
        //            for (int k = 0; k < 125; k++)
        //            {
        //                Global.GenData[k] = Global.Data[k];   
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();

        //            Sn += 1;
        //            String strData = null;
        //            for (i = 0; i <= 125; i++)
        //            {
        //                if (Global.GenData[i] == null) Global.GenData[i] = "0.0";
        //                strData = strData + Global.GenData[i] + "', '";
        //            }


        //            Global.Open_DataConn("Data", "conData");
        //            SqlDataAdapter adpFilenm = new SqlDataAdapter("SELECT * FROM " + Global.Eng_FileNm, Global.conData);
        //            DataSet ds4 = new DataSet();
        //            adpFilenm.Fill(ds4);
                 
        //            if (ds4.Tables[0].Rows.Count != 0)
        //            {
                       
        //                SqlCommand cmd4 = new SqlCommand("SELECT MAX(Pn)FROM " + Global.Eng_FileNm, Global.conData);
        //                SqlDataReader rd4 = cmd4.ExecuteReader();
        //                while (rd4.Read())
        //                {

        //                    sn1 = int.Parse(rd4.GetValue(0).ToString());
        //                }
        //            }
        //            else
        //            {
        //                sn1 = 0;
        //            }
        //            sn2 = sn1 + 1;


        //            cmd = new SqlCommand();
        //            cmd.CommandText = "INSERT INTO " + Global.Eng_FileNm + " VALUES ('" + strData + Global.Eng_FileNm + "', '" + sn2 + "')";
        //            cmd.Connection = Global.conData;
        //            cmd.ExecuteNonQuery();
        //            txtlog.Text = Sn.ToString();
        //            Global.conData.Close();  
                                  
        //        }
        //        tmrLog.Enabled = true; 
        //            Global.flg_SFCStart = false;
        //    }

        //    catch (Exception ex)
        //    {
        //        //AddListItem("Error in Make avg ", 6);
        //        Global.Create_OnLog("Error in Make avg "+ex.Message );  
        //        return;
        //    }

            //******************************

        //}

        
        private void RdProg()
        {
            try
            {
                String A = "rpm";
                String B = "Nm";
                String C = "%"; 

                Global.Open_Connection("seq_db", "conSeq");
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.Prj[2] + " ORDER BY StepNo", Global.conSeq);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                Int16 x = 0;
                Int16 y = 0;
                string st = "";
                GridSeq.RowCount = (ds.Tables[0].Rows.Count + 1);

                for (x = 0; x <= (ds.Tables[0].Rows.Count - 1); x++)
                {
                    for (y = 0; y < (ds.Tables[0].Columns.Count); y++)
                    {
                        String T = "0";
                        switch (y)
                        {
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                                T = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                int TR = ((int.Parse(T.Substring(0, 2)) * 60) + int.Parse(T.Substring(3, 2)));
                                if (TR <= 1) TR = 1;
                                TimeSpan t = TimeSpan.FromSeconds(TR);
                                GridSeq[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            case 11:
                            case 14:
                            case 15:
                            case 16:
                            case 27:
                                if (ds.Tables[0].Rows[x].ItemArray[y].ToString() == "Y")
                                    GridSeq[y, x].Value = true;
                                else 
                                    GridSeq[y, x].Value = false;
                                break;

                            case 18:
                                Int16 Ts = Convert.ToInt16(ds.Tables[0].Rows[x].ItemArray[18]);
                                t = TimeSpan.FromSeconds(Ts);

                                GridSeq[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            default:
                                GridSeq[y, x].Value = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                break;
                        }
                    }
                    Int16 Q = Convert.ToInt16(GridSeq[1, x].Value);
                    switch (Q)
                    {
                        case 1:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + C + ")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + C + ")";
                            break; 
                        case 2:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + A + ")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + C + B + ")";
                            break;
                        case 3:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + C + A +")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + B + ")";
                            break;
                        case 4:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + A + ")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + B + ")";
                            break;
                        case 5:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + A + ")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + C + B + ")";
                            break;
                        case 6:
                            GridSeq[2, x].Value = GridSeq[2, x].Value + " (" + A + ")";
                            GridSeq[4, x].Value = GridSeq[4, x].Value + " (" + B + ")";
                            break;
                    }                   
                                       
                }                
                Global.conSeq.Close();
                Global.Create_OnLog("Prog File Read SUCCESSFULLY....", "Normal");             
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Prog File not nRead SUCCESSFULLY....", "Alart");
                Global.Create_OnLog("Error in Main: Rd_Prog() : ", "Alart");
                return;
            }
        }
       

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //private static double RandomNumber2(double min, double max)
        //{
        //    Random random = new Random();
        //    return random.NextDouble(min + 0.2,) * (min);
        //}

        //private static double RandomNumberBetween(double minValue, double maxValue)
        //{
        //    var next = Global.random.NextDouble();
        //    return minValue + (next * (maxValue - minValue));
        //}
        private void Fun_AnalogOut_SmoothChangeover()
        {
            try
            {
                Tss10.Text = Global.C_Mode;
                if (PBar3.Caption == "RAMP TIME:")
                {
                    flg_Ramp = true;
                    clsFun.MODE_TO_MODE_Smooth(); //MODE_TO_MODE(); // 
                    tmrWrite.Interval = 100;

                    //switch (Global.C_Mode)
                    //{
                    //    case "0":
                    //    case "1":
                    //        txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                    //        txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                    //        break;
                    //    case "2":
                    //        txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    //        txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                    //        break;
                    //    case "3":
                    //        txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                    //        txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                    //        break;
                    //    case "4":
                    //        txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    //        txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                    //        break;
                    //    case "5":
                    //        txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                    //        txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    //        break;
                    //    case "6":
                    //        txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                    //        txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    //        break;
                    //}
                }

                else if ((PBar3.Caption == "STEADY TIME:") || (PBar3.Caption == "STABILISATION TIME:"))
                {

                    flg_Ramp = false;
                    switch (int.Parse(Global.C_Mode))
                    {
                        case 1:
                            Global.Mode_Out(1, 0, 0);
                            break;
                        case 2:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 3:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 4:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 5:
                            Global.Mode_Out(0, 1, 1);
                            break;
                        case 6:
                            Global.Mode_Out(0, 1, 1);
                            break;
                    }
                    Tss7.Text = Global.AnaOut2.ToString("0.000");
                    tmrWrite.Interval = 100;
                    switch (Global.C_Mode)
                    {
                        case "2":
                        case "4":
                        case "5":
                        case "6":
                            if (Global.sysIn[13] == "TRUE")
                            {
                                int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));
                                if ((rDiff <= 60) && (rDiff >= 4))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                                }
                                else if ((rDiff >= -60) && (rDiff <= -4))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                                }
                            }
                            break;
                        default:
                            Tss6.Text = Global.AnaOut1.ToString("0.000");
                            Tss7.Text = Global.AnaOut2.ToString("0.000");
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString();
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString();
                            break;
                    }
                }
                //Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);               

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        PBar1.Value = (int)(Global.AnaOut1 * 1000);
                        PBar2.Value = (int)(Global.AnaOut2 * 1000);
                        break;
                    case 5:
                    case 6:
                        PBar1.Value = (int)(Global.AnaOut2 * 1000);
                        PBar2.Value = (int)(Global.AnaOut1 * 1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alart");
                MessageBox.Show("Error in frmMain: Fun_AnalogOut():  " + ex.Message);
            }
        }

        private void Fun_AnalogOut_StandardChangeover()
        {
            try
            {
                Tss10.Text = Global.C_Mode;
                if (PBar3.Caption == "RAMP TIME:")
                {
                    flg_Ramp = true;
                    clsFun.MODE_TO_MODE_Std(); 
                    tmrWrite.Interval = 100;
                 
                    switch (Global.C_Mode)
                    {
                        case "0":
                        case "1":
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            break;
                        case "2":
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            break;
                        case "3":
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                            txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            break;
                        case "4":
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            break;
                        case "5":
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            break;
                        case "6":
                            txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            break;
                    }
                    //if (TmR  == 0)
                    //{
                    //    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    //    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                    //}

                }

                else if ((PBar3.Caption == "STEADY TIME:") || (PBar3.Caption == "STABILISATION TIME:"))
                {

                    flg_Ramp = false;
                    //switch (int.Parse(Global.C_Mode))
                    //{
                    //    case 1:
                    //        Global.Mode_Out(1, 0, 0);
                    //        break;
                    //    case 2:
                    //        Global.Mode_Out(0, 1, 0);
                    //        break;
                    //    case 3:
                    //        Global.Mode_Out(1, 1, 0);
                    //        break;
                    //    case 4:
                    //        Global.Mode_Out(0, 0, 1);
                    //        break;
                    //    case 5:
                    //        Global.Mode_Out(1, 0, 1);
                    //        break;
                    //    case 6:
                    //        Global.Mode_Out(0, 1, 1);
                    //        break;
                    //}
                    Tss7.Text = Global.AnaOut2.ToString("0.000");
                    tmrWrite.Interval = 100;
                    switch (Global.C_Mode)
                    {
                        case "2":
                        case "4":
                        case "5":
                        case "6":
                            if (Global.sysIn[13] == "TRUE")
                            {
                                int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));
                                if ((rDiff <= 60) && (rDiff >= 4))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                                }
                                else if ((rDiff >= -60) && (rDiff <= -4))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                                }
                            }
                            break;
                        default:
                            Tss6.Text = Global.AnaOut1.ToString("0.000");
                            Tss7.Text = Global.AnaOut2.ToString("0.000");
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString();
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString();
                            break;
                    }
                }
                //Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);               

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        PBar1.Value = (int)(Global.AnaOut1 * 1000);
                        PBar2.Value = (int)(Global.AnaOut2 * 1000);
                        break;
                    case 5:
                    case 6:
                        PBar1.Value = (int)(Global.AnaOut2 * 1000);
                        PBar2.Value = (int)(Global.AnaOut1 * 1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alart");
                MessageBox.Show("Error in frmMain: Fun_AnalogOut():  " + ex.Message);
            }
        }

        
       
       
        private void tmrEnd_Tick(object sender, EventArgs e)
        {
            try
            {              

                flg_AnaOut = false;
                flg_ProgOut = false;               
                stopsec = stopsec - 1; //(seconds / 10);
                if (stopsec <= 0) stopsec = 0; 
                t = TimeSpan.FromSeconds(stopsec);

                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;

                settimefor_gridseq();
                PBar1.Value =(int)(Global.AnaOut1*1000);
                PBar2.Value = (int)(Global.AnaOut2*1000);  
               
                PBar3.Maximum = 100;
                PBar3.Value = (int)(stopsec);
                if (PBar3.Value == 0)
                    PBar3.Value = 0; 
                if (int.Parse(Global.C_Mode) <= 4)
                {
                    if ((Global.AnaOut2 > 0.1) && (Global.AnaOut1 >= 0.81))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0) Global.Edif1 = 0;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);

                    }
                    else
                    {
                        Global.AnaOut1 = 001;
                        Global.AnaOut2 = 001;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);
                        Global.Mode_Out(1, 0, 0);
                        ResetOutPut();                       
                        tmrEnd.Enabled = false;
                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
                else if (int.Parse(Global.C_Mode) >= 5)
                {
                    if ((Global.AnaOut2 > 0.1))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.8) Global.Edif1 = 0;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    }
                    else
                    {
                        Global.AnaOut1 = 0.8;
                        Global.AnaOut2 = 0.01;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Global.Mode_Out(1, 0, 0);
                      
                        tmrEnd.Enabled = false;
                        ResetOutPut();
                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose(); 
                    }
                }
                Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);                
                Global.flg_EngStart = false;
                Global.Sn = 0;
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Problem In Engine Stop.....", "Alart");

                //MessageBox.Show("Error in frmMain: tmrEnd_Tick():  " + ex.Message);
            }
        }
        public void Log_InstData()
        {
            try
            {
                int t1 = 0;
                if (Global.Eng_Inst_FileNm == "") Global.Eng_Inst_FileNm = "Inst_Man";
                int i = 0;
                Global.Capture_Data(Global.flg_SFCStart);
                Global.ISn += 1;
                String InstData = null;
                InstData = IData[0] = DateTime.Now.ToString() + ", "; ;

                for (i = 0; i <= Global.vIdNo - 3; i++)
                {
                    t1 = Global.vId[i];
                    IData[i + 1] = Global.GenData[t1];
                    if (IData[i + 1] == null) IData[i + 1] = "0.0";
                    InstData = InstData + IData[i + 1] + ", ";
                }
                InstData = InstData + Global.ISn + ",\n";
                var filePath = Global.DataPath + "Inst_Data\\" + Global.Eng_Inst_FileNm + ".csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { InstData.Substring(0, InstData.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Inst_LogData() :" + ex.Message);
            }
        }


        private void tmrLog_Tick(object sender, EventArgs e)
        {
            try
            {
                if (flg_ProgOut == true) Fun_ProgOut();   
                          
                if (Global.flg_RecorsPmData == true) RecordPMData();
                            if (flg_PerStep == true)
                            {
                                if (SockT >= 44)
                                {                                    

                                    if (((Tstd == 35) || (Tstd == 34)) && (flg_PerStep == true))
                                    {  
                                        GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                        Tss9.Text = "Averaging Started.....";
                                        Tss9.BackColor = Color.Red;
                                        Tss9.ForeColor = Color.Yellow;
                                        tmrAvg.Start();
                                    }
                                    else
                                        if ((Tstd == 5) ||((Tstd == 4)) && (flg_SaveData == true))
                                        {
                                            tmrAvg.Stop();
                                            Tss9.Text = "Data Logged.....";
                                            Tss9.BackColor = Color.Silver;
                                            Tss9.ForeColor = Color.Blue;
                                            MakeAVGData();
                                        }
                                }
                                else
                                {
                                    GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                    if ((flg_Std == true) && ((Tstd == 5) || ((Tstd == 4))) && (flg_SaveData == true))
                                    {
                                        LogData();                                       
                                        flg_PerStep = false;
                                    }
                                }
                            }
                            if (flg_Instat == true)
                            {
                                GridSeq.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";

                                if ((flg_Std == true) && (SockT > 45))
                                {
                                    if (DataCnt <= -1)
                                    {
                                        DataCnt = LogT;
                                        flg_SaveData = true;
                                    }
                                    else DataCnt -= 1;

                                    if (LogT >= 44)
                                    {
                                        if (((DataCnt == 35) || (DataCnt == 34)) && (flg_Instat == true))
                                        {
                                            Tss9.Text = "Averaging Started.....";
                                            Tss9.BackColor = Color.Red;
                                            Tss9.ForeColor = Color.Yellow;
                                            tmrAvg.Start();

                                        }
                                        else if (((DataCnt == 5) || (DataCnt == 4)) && (flg_SaveData == true))
                                        {
                                            tmrAvg.Stop();
                                            Tss9.Text = "Data Logged.....";
                                            Tss9.BackColor = Color.Silver;
                                            Tss9.ForeColor = Color.Blue;
                                            MakeAVGData();
                                        }


                                    }                              
                                    else
                                    {
                                        if ((flg_Instat == true) && (flg_Std == true) && (SockT < 45))
                                        {
                                            if (DataCnt == 5)
                                            {
                                                LogData();
                                                GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                                flg_PerStep = false;
                                            }                                          
                                        }

                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Error Code:10740  " + ex.Message);
                            AddListItem("Error TmrLog Data", "Alart");
                            return;
                        }
            }
           
        private void MakeAVGData()
        {
            try
            {
                String Str = String.Empty;
                int i = 0;
                //Global.Sn++;
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter Adp = new MySqlDataAdapter("SELECT * FROM AvgTemp", Global.con);
                DataSet ds = new DataSet();
                Adp.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                  
                    Str = "SELECT ";
                    for (i = 0; i <= 59; i++)
                    {
                        if ((i != 2) || (i != 3) || (i != 4) || (i != 5))
                        {
                            if (i == 59)
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
                            }
                            else
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
                            }
                        }

                    }
                    string Str1 = Str + "from AvgTemp";
                    MySqlCommand AVGcmd = new MySqlCommand(Str1, Global.con);
                    AVGcmd.ExecuteNonQuery();
                    MySqlDataReader Rd = AVGcmd.ExecuteReader();
                    i = 0;
                    Double M = 0;
                    while (Rd.Read())
                    {
                        for (i = 0; i < 60; i++)
                        {

                            M = Double.Parse(Rd.GetValue(i).ToString());
                            if ((Global.PUnit[i] == "Nm") || (Global.PUnit[i] == "°C") || (Global.PUnit[i] == "%"))
                                Global.ArrData[i] = M.ToString("000.0");
                            else if ((Global.PUnit[i] == "bar"))
                                Global.ArrData[i] = M.ToString("0.000");
                            else if ((Global.PUnit[i] == "rpm") || (Global.PUnit[i] == "r/min") || (Global.PUnit[i] == "mbar") || (Global.PUnit[i] == "lpm"))
                                Global.ArrData[i] = M.ToString("0000");
                            else
                                Global.ArrData[i] = M.ToString("##0.0##");

                            if (Global.ArrData[i] == null) Global.ArrData[i] = "0.0";

                            if (Global.ArrData[i] == null)
                            {
                                Global.ArrData[i] = "0.0";
                            }
                        }
                    }
                    Rd.Close(); 
                    Global.con.Close();
                    Double T = 0;
                    T = Double.Parse(Global.ArrData[0]);
                    //Global.ArrData[0] = T.ToString("0000");
                    Global.AvgRpm = int.Parse(Global.ArrData[0]);
                    Global.AvgTrq = Double.Parse(Global.ArrData[1]);
                    if (Global.AvgRpm <= 0) Global.AvgRpm = 0.1;
                    if (Global.AvgTrq <= 0) Global.AvgTrq = 0.1;
                    Double P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
                    Global.AvgPowPs = Double.Parse(P.ToString("00.00"));
                    P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
                    Global.AvgPowkW = Double.Parse(P.ToString("00.00"));
                    if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
                    if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;

                    if ((Global.AvgRpm >= 1000) && (Global.AvgTrq >= 10))
                    {
                        //Double SFC = (Convert.ToDouble(Global.ArrData[89]) * 1000 / Global.AvgPowPs);

                        //if (SFC >= 1000)
                        //{
                        //    Global.ArrData[108] = "999";
                        //    Global.SFCVal = 999;
                        //}
                        //else
                        //{
                        //    Global.ArrData[108] = SFC.ToString("000.0");
                        //    Global.SFCVal = SFC;
                        //}
                    }
                    else
                        //Global.SFCVal = 00.0;

                    for (i = 0; i < 60; i++)
                    {
                        if (Global.ArrData[i] == null)
                        {
                            Global.ArrData[i] = "0.00";
                        }
                        Global.Data[i] = Global.ArrData[i];
                    }
                    
                       
                    
                    int t = 100;
                    Global.Data[t + 1] = Global.SmkVal.ToString();
                    Global.Data[t + 2] = "00.0";  // Global.Blow_by.ToString();
                    Global.Data[t + 3] = Global.SFCwt.ToString("##0.0");
                    Global.Data[t + 4] = Global.SFCTm.ToString("##0.0"); 
                    if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
                    Global.Data[t + 5] = Global.Corfact.ToString("0.00000");  //
                    Global.Data[t + 6] = Global.varTRQ.ToString("000.0");
                    Global.Data[t + 7] = Global.VarPowkW.ToString("000.0");
                    Global.Data[t + 8] = (Global.SFCValkW).ToString("000.0");
                    Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
                    Global.Data[t + 10] = (Global.AvgTrq * Global.Corfact).ToString("00.00");
                    Global.Data[t + 11] = (Global.VarPowkW * Global.Corfact).ToString("00.0");
                    Global.Data[t + 12] = (Global.SFCValkW / Global.Corfact).ToString("00.0");

                    Global.Data[t + 13] = "00.0"; // (Double.Parse(Double.Parse(Global.Data[103]) / Double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
                    Global.Data[t + 14] = "00.0"; //(Double.Parse((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
                    Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
                    Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
                    Global.Data[t + 17] = Global.SFCValPs.ToString("000.0");
                    Global.Data[t + 18] = ((Global.SFCValPs) / (Global.Corfact)).ToString("000.0");
                    Global.Data[t + 19] = Global.varbmep.ToString("0.000");
                    Global.Data[t + 20] = Global.Rel_Hum.ToString("00.0");

                    //string l = DateTime.Now.ToString("dd/MM/yyyy");
                    //if (Global.OperatorNm == null) Global.OperatorNm = "OpName";
                    //if (Global.TKnNo == null) Global.TKnNo = "TNo";
                    //if (Global.EngMd == null) Global.EngMd = "EngMd";
                                      
                   
                    Global.Data[121] = System.DateTime.Now.ToString("hh:mm:ss tt");
                    Global.Data[122] = Global.S_StartTime;
                    Global.Data[123] = Global.cumhours;
                    if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
                    Global.Data[124] = "*****";
                    //Global.Data[125] = l + ", " + Global.Shift + ", " + Global.T_CellNo + ", " + Global.OperatorNm + ", " + Global.TKnNo + ", " + Global.EngNo + ", " + Global.EngMd + ", " + Global.FipNo;
                    //*****************************
                    if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                    if (Global.flg_DataSave == true)
                    {
                        i = 0;
                        //if (Global.Sn == 0) fill_Engine_Details();
                        Global.Sn += 1;

                        String strData = null;
                        //for (i = 0; i <= 124; i++)
                        //{
                        //    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                        //    strData = strData + Global.Data[i] + ", ";
                        //}

                        for (i = 0; i < 60; i++)
                        {
                            if (Global.Data[i] == null) Global.Data[i] = "000.000";
                            strData = strData + Global.Data[i] + ", ";
                        }
                        for (i = 60; i < 100; i++) if (Global.Data[i] == null) Global.Data[i] = "000.000";
                        for (i = 0; i <= 25; i++)
                        {
                            if (Global.Data[i + 100] == null) Global.Data[i + 100] = "000.000";
                            strData = strData + Global.Data[i+60] + ", ";
                        }
                        strData = strData + Global.StrAlarm + ", " + Global.Sn + ",\n";
                        var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
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
                            Global.flg_DataSave = false;
                        }

                    }
                    //***********************
                }
                st.Start();
                tmrLog.Enabled = true;
                Global.flg_SFCStart = false;

                //Global.flg_UpdateViewData = true;
                frmPar.Update_ViewData();
                flg_SaveData = false;
                lblLog.Text = Global.Sn.ToString("000");
                AddListItem("Avg-Data Logged... ", "Normal");
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in Make Data avg ", "Alart") ; // + ex.Message);
                return;
            }
            //******************************
        }




       

       


        public  void ResetOutPut()
        {
            try
            {
                flg_AnaOut = true;
                Global.C_Mode = "1";
                Tss10.Text = Global.C_Mode;
                Global.Mode_Out(1, 0, 0);
                Global.SetPtOut1 = "0";
                Global.SetPtOut2 = "0";
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                Global.AnaOut1 = 0.01;
                Global.AnaOut2 = 0.01;
                Global.C_Mode = "1";
                 flg_AnaOut = false;
                 Global.flg_RunStart = false;
                 //btn25.Enabled = true;
                 Btn25.Enabled = false;

                 mnuRunStatus.Enabled = true;
                 //mnuSemAuto.Enabled = true;
                 Btn21.Enabled = false;
                 BtnSA.Enabled = false; 

                t = TimeSpan.FromSeconds(0);
                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;
                //txtPStatus.Text = "000";
                settimefor_gridseq();
                tmrLog.Enabled = false;
                LogT = 0;
                //checkBox16.Text = "000";
                PBar3.Value = 1;
                //Btn21.Enabled = true;
                Btn22.Enabled = false;              
                Btn24.Enabled = false;
                lblLog.Text = "000"; 
                
                GridSeq.Rows.Clear();
                GridSeq.RowCount = 10; 
                Global.Rd_Confg();                
                Load_Arr();
                Global.Prj[3] = "Lim_STANDBY";               
                clsLimit.Read_LimtStandby();
                Global.SFC_msg = "SFC Status .....";
                //if  (Global.flg_smk = true) Global.Init_SmokePort();
                Global.Create_OnLog("SYSTEM RESETED SUCCESSFULLY.....", "Normal");


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("PROBLEM IN ResetOutPut.....", "Alart");

                MessageBox.Show("Error in frmMain: ResetOutPut():  " + ex.Message);
            }
        }
        public void IdleEng()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;

                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / (10);
                Global.Edif2 = (Global.AnaOut2) / (10);
                stopsec = 100;
                tmrIdel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: IdelEng():  " + ex.Message);
            }
        }

        public void stopEngine()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;
                Global.flg_LimitON = false;
                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / 20;
                Global.Edif2 = (Global.AnaOut2) / 10;
                stopsec = 100;
                Global.Open_Connection("gen_db", "con");
                string h = Tss2.Text.Substring(0, 4);
                string m = Tss2.Text.Substring(5, 2);
                string hm = h + "." + m;
                MySqlCommand cmd = new MySqlCommand("Update tblProject SET  C_Time = '" + hm + "' where ProjectFile= '" + Global.PrjNm + "'", Global.con);
                cmd.ExecuteNonQuery();
                Global.con.Close();
                tmrEnd.Enabled = true;
                Global.Create_OnLog("ENGINE STOPPED SUCCESSFULLY.....", "Normal");

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Problem in StopEngine.....", "Alart");

                MessageBox.Show("Error in StopEng function", ex.Message);
            }
        }



        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (flg_ProgOut == true)
                {
                    frmLEfiles frm = new frmLEfiles();
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn1_Click():  " + ex.Message);
            }
        }



       

      
       
        public void settimefor_gridseq()
        {
            if (PBar3.Caption == "RAMP TIME:")
            {

                GridSeq.Columns[3].HeaderText = " RmT-1 (" + txtPStatus.Text + ")";
                GridSeq.Columns[5].HeaderText = " RmT-2 (" + txtPStatus.Text + ")";
            }
            if (PBar3.Caption == "STABILISATION TIME:")
            {
                GridSeq.Columns[6].HeaderText = " T_Stb (" + txtPStatus.Text + ")";

            }
            if (PBar3.Caption == "STEADY TIME:")
            {
                GridSeq.Columns[7].HeaderText = " T_Std (" + txtPStatus.Text + ")";

            }
        }

        private void tmrIdel_Tick(object sender, EventArgs e)
        {
            try
            {
                flg_AnaOut = false;
                flg_ProgOut = false;
                 //(seconds / 10);
               
                if (stopsec <= 0)
                    stopsec = 0;
                else
                {
                    stopsec = stopsec - 1;
                    PBar3.Value = (int)(stopsec);
                    t = TimeSpan.FromSeconds(stopsec);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                }
                if (int.Parse(Global.C_Mode) <= 4)
                {
                    if ((Global.AnaOut2 > 0) || (Global.AnaOut1 > 0))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0) Global.Edif1 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    }
                    else
                    {
                        Global.AnaOut1 = 0.01;
                        Global.AnaOut2 = 00.01;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Btn24.Text = "Step_Resume";
                        tmrIdel.Stop(); 

                    }
                }
                else if (int.Parse(Global.C_Mode) >= 5)
                {
                    if ((Global.AnaOut2 > 0))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.8) Global.Edif1 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);

                    }
                    else
                    {
                        Global.AnaOut1 = 1;
                        Global.AnaOut2 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Btn24.Text = "Step_Resume";
                        tmrIdel.Stop(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Timer Idle Problem.....", "Alart");

            }
        }
       
      
     
     
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login ();
            frm.ShowDialog(this);
            frm.Dispose();
        }     
        
        private void eDITORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            //Process pr = new Process(); 
            foreach (Process pr in prs)
            {
                //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                if (pr.ProcessName == "Editors") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
                //if (pr.ProcessName == "DataAppliacation") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editors.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal ;
            p.Start();
        }
      

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPATH + "Help.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        private void mnuSystem_MouseMove(object sender, MouseEventArgs e)
        {
            mnusyspara.ForeColor = Color.White;
        }

        private void mnuSystem_MouseLeave(object sender, EventArgs e)
        {
            mnusyspara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        }

        private void mnuChannel_MouseMove(object sender, MouseEventArgs e)
        {
            mnuChannel.ForeColor = Color.White;  

        }

        private void mnuChannel_MouseLeave(object sender, EventArgs e)
        {
            mnuChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));   
        }

       

       
        public  DateTime Eng_Start_DelaySc(int nSeconds)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, nSeconds, 0);
                System.DateTime AfterWards = ThisMoment.Add(duration);
               
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                    Btn21.Enabled = false;
                    if (Global.varRPM >= Global.S_Rpm)
                    {
                        return System.DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016", ex.Message);
                Global.Create_OnLog("Error in frmMain: Eng_Start Delay() : ", "Alart");
            }
            return System.DateTime.Now;
        }

        private void Btn21_Click(object sender, EventArgs e)
        {            
            try
            {
                if ((Global.EngNo == null) || (Global.PrjNm == null))
                {
                    EngDialog1 frm = new EngDialog1();
                    frm.ShowDialog(this);
                    frm.Dispose();
                    return;
                }
                int c = 0;
                Global.StpN = 0;
                Sn = 0;
                Global.Dig_OutBit(0, 7, true);
                BtnSA.Enabled = false;
                Global.flg_Auto = true;
                Btn21.Enabled = false;
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                RdProg();
                Load_ProgStep();
                init_ReadyStatus();
                if (Global.varRPM <= Global.S_Rpm)
                {
                    Tss1.Text = "Wait For RunningIn signal ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Btn21.Enabled = false;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;


                    Global.Dig_OutBit(0, 7, true);  //Ingnition on
                    Thread.Sleep(500); 
                    Global.Dig_OutBit(1, 0, true);  //Eng start Pulse
                    Thread.Sleep(500);
                    Global.Dig_OutBit(1, 0, false);//Eng start Pulse false
                    
                    
                    Tss1.Text = "Satrt the Engine....";
                    Eng_Start_DelaySc(3);


                    if (Global.varRPM >= Global.S_Rpm) //Convert.ToInt16(Global.Prj[12]))
                    {
                        Tss2.Text = Global.cumhours;
                        Global.flg_CycleStarted = true;
                        Tss1.Text = "Engine Started ......";
                        Update_Tss1(1);
                        Thread.Sleep(500);
                        Tss1.Text = "Engine Is Running ......";                      
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                        //AddListItem("Engine Is Running ......", "Normal");
                        //AddListItem(Global.Prj[0], "Normal");
                        //AddListItem(Global.Prj[1], "Normal");
                        //AddListItem(Global.Prj[2], "Normal");
                        //AddListItem(Global.Prj[3], "Normal");

                        //AddListItem("Engine Is Running ......", 5);
                        Btn25.Enabled = true;
                        mnuRunStatus.Enabled = true;
                        flg_AnaOut = true;
                        flg_ProgOut = true;
                        Global.Make_mdb(Global.DataPath);
                        tmrLog.Enabled = true;
                        Create_FileName(Global.EngNo);

                        Btn21.Enabled = false;
                        Btn22.Enabled = true;
                        Btn23.Enabled = true;
                        Btn24.Enabled = true;
                        Btn25.Enabled = true;
                        Btn26.Enabled = true;                       
                        mnuRunStatus.Enabled = true;
                        Global.flg_EngStart = true;
                        Global.flg_CylStart = true;
                        Global.flg_CycleStarted = true;
                        AddListItem("Engine Started .......", "Normal");
                        AddListItem("Engine Is Running ......", "Normal");
                        AddListItem(Global.Prj[0], "Normal");
                        AddListItem(Global.Prj[1], "Normal");
                        AddListItem(Global.Prj[2], "Normal");
                        AddListItem(Global.Prj[3], "Normal");
                      
                    }
                    else
                    {
                        Tss1.Text = "Wait For Engine Running signal ......";
                    a: DialogResult result1 = MessageBox.Show("Wait For Engine Running signal ......" + c, "Engine Message", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {
                            if (Global.varRPM >= Global.S_Rpm) //Convert.ToInt16(Global.Prj[12]))
                            {
                                Create_FileName(Global.EngNo);
                                Tss2.Text = Global.cumhours;
                                Global.flg_CycleStarted = true;
                                Tss1.Text = "Engine Started ......";
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                Thread.Sleep(500);                               
                                Tss1.Text = "Engine Is Running ......";
                                //st.Start();
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                AddListItem("Engine Is Running ......", "Normal");
                                Global.Create_OnLog("Engine Started ..... ", "Normal");
                                AddListItem("Engine Is Running ......", "Normal");
                                AddListItem(Global.Prj[0], "Normal");
                                AddListItem(Global.Prj[1], "Normal");
                                AddListItem(Global.Prj[2], "Normal");
                                AddListItem(Global.Prj[3], "Normal");
                                flg_AnaOut = true;
                                flg_ProgOut = true;
                                Global.Make_mdb(Global.DataPath);
                                //Create_FileName(Global.EngNo);
                                tmrWrite.Start();
                                tmrLog.Start();
                                Btn21.Enabled = false;
                                Btn22.Enabled = true;
                                Btn23.Enabled = true;
                                Btn24.Enabled = true;
                                Btn25.Enabled = true;
                                Btn26.Enabled = true;
                                //frmPar.btnStart.Enabled = true;
                                //frmPar.btnStop.Enabled = true;
                               
                                mnuRunStatus.Enabled = true;
                                Global.flg_EngStart = true;
                                Global.flg_CylStart = true;
                                //Btn21.Enabled = false;
                                //mnuLogData.Enabled = true;
                                //mnuRunStatus.Enabled = true;
                                ////Btn21.Enabled = false;                               
                                //Btn22.Enabled = true;
                                //Global.flg_EngStart = true;
                               
                                
                            }
                            else
                            {
                                c += 1;
                                Thread.Sleep(3000); 
                                if (c >= 3)
                                {                                    
                                    Btn21.Enabled = true;
                                    Btn22.Enabled = false;
                                    Btn23.Enabled = false;
                                    Btn24.Enabled = false;
                                    Btn25.Enabled = false;
                                    Btn26.Enabled = false;
                                   
                                    mnuRunStatus.Enabled = false;
                                    Tss1.Text = "Engine Not Started ......";
                                    //frmPar.btnStart.Enabled = false;
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;

                                    Tss1.Text = "Engine Not Started ......";
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;
                                }
                                else
                                {
                                    Tss1.Text = "Wait For Engine Start....";
                                    Thread.Sleep(500); 
                                    Eng_Start_DelaySc(3);
                                    goto a;
                                }
                            }
                        }
                        else
                        {
                            Btn21.Enabled = true;
                            Btn22.Enabled = false;
                            Btn23.Enabled = false;
                            Btn24.Enabled = false;
                            Btn25.Enabled = false;
                            Btn26.Enabled = false;
                          
                            mnuRunStatus.Enabled = false;
                            Tss1.Text = "Engine Not Started ......";
                            Tss1.BackColor = Color.Gainsboro;
                            MessageBox.Show("Engine Not Started. Try Again ......");
                            //frmPar.btnStart.Enabled = false;
                            //frmPar.btnStop.Enabled = false;
                    
                        }
                    }
                }
                else if (Global.varRPM >= Global.S_Rpm) //Convert.ToInt16(Global.Prj[12])))// && (Global.DigIn[6] == 0))
                {
                    Create_FileName(Global.EngNo);
                    Tss2.Text = Global.cumhours;
                    Tss1.Text = "Engine Started ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Global.flg_CycleStarted = true;
                    Thread.Sleep(500); 
                    Tss1.Text = "Engine Is Running ......";
                    //st.Start();
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    //AddListItem("Engine Is Running ......", 5);
                    AddListItem("Engine Is Running ......", "Normal");
                    AddListItem(Global.Prj[0], "Normal");
                    AddListItem(Global.Prj[1], "Normal");
                    AddListItem(Global.Prj[2], "Normal");
                    AddListItem(Global.Prj[3], "Normal");
                    flg_AnaOut = true;
                    flg_ProgOut = true;
                    Global.Make_mdb(Global.DataPath);
                    tmrWrite.Start();
                    tmrLog.Start();
                    Btn25.Enabled = true;
                    mnuRunStatus.Enabled = true;
                    //Create_FileName(Global.EngNo);
                    Btn21.Enabled = false;
                    Btn22.Enabled = true;
                    Btn23.Enabled = true;
                    Btn24.Enabled = true;
                    Btn25.Enabled = true;
                    Btn26.Enabled = true;
                    mnuRunStatus.Enabled = true;

                    Global.flg_EngStart = true;
                    Global.flg_CylStart = true;
                }
                else if (Global.varRPM < Global.S_Rpm) //Convert.ToInt16(Global.Prj[12])))  // && (Global.DigIn[6] == 0))
                {
                    Btn21.Enabled = true;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;
                   
                    mnuRunStatus.Enabled = false;
                    Tss1.Text = "Engine Not Started ......";
                    Tss1.BackColor = Color.Gainsboro;
                    MessageBox.Show("Engine is Not ready.");

                }
                Global.CStrtTm = DateTime.Now.ToString("hh:mm:ss tt");              
               
            }
            catch (Exception ex)
            {
                AddListItem("Engine Start Problem  .....", "Alart");                
            }
        }



        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog(this);
            frm.Dispose();

        }
        private void mnuLogData_Click(object sender, EventArgs e)
        {
            LogData(); 
        }

       
        private void mnuSystem_Click(object sender, EventArgs e)
        {
            //    frmSysP frm = new frmSysP();
            //    frm.ShowDialog(this);
            //    frm.Dispose();
        }



        private void mnuEditor_Click(object sender, EventArgs e)
        {
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editor.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        private void mnuProject_Click(object sender, EventArgs e)
        {
            frmProject frm = new frmProject();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuShowValues_Click(object sender, EventArgs e)
        {
            frmInOut frm = new frmInOut();
            frm.ShowDialog(this);
        }

       
        private void mnuGraph_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                OnLineGraph frm = new OnLineGraph();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {               
                MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;               
            }
        }

        //private void mnuReset_Click(object sender, EventArgs e)
        //{
        //    ResetOutPut();
        //    EngDialog frm = new EngDialog(this);
        //    frm.ShowDialog(this);
        //    frm.Dispose(); 
        //}

      
#region read sfc
        public void Read_SFC()
        {
            try
            {
                
                switch (Global.SFC_Msg_from_Inst)
                {
                    case "_OVER_":

                        if (Global.SFC_msg == "SFC ON")
                        {
                            Global.SFC_msg = "_OVER_";
                            tmrSFC.Enabled = false;
                            AddListItem("SFC OVER.....", "Normal");

                           Thread.Sleep(500);
                            Calculate_SFC();
                            LogData();
                            Update_Tss1(0);
                            Tss1.BackColor = Color.Silver;
                            Tss1.ForeColor = Color.Black;  
                            Global.flg_SFC = false;
                        }
                        break;

                    case "_RESET": //   '"_RESET"                        
                        Global.SFC_msg = "SFC RESET";                       
                        Update_Tss1(0);
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                        Global.flg_SFC = true;
                        //AddListItem("SFC RESET.....", "Normal");

                        break;
                    case "SFC_ON": //  '"SFC_ON"
                        if (Global.SFC_msg != "SFC ON")
                        {
                            AddListItem(" SFC ON ...... ", "Normal");
                            //tmrAvg.Start();
                            Tss9.Text = "Averaging Started.....";
                            Global.SFC_msg = "SFC ON";
                            //Global.flg_SFC = true;
                            Tss1.BackColor = Color.Red;
                            Tss1.ForeColor = Color.Yellow;
                        }
                        tmrSFC.Enabled = true;
                        break;
                }

            }
            catch (Exception ex)
            {
                AddListItem("PROBLEM IN SFC REDAING.....", "Alart");
            }
        }


        public void Calculate_SFC()
        {
            try
            {                
                int r;               
                int N;

               Global.SGrv = "0.835";
               if(Global.E_Pow <= 1) Global.E_Pow  = 1;
               N = int.Parse(Global.NCyl);
               if (N <= 0) N = 3;
               r = int.Parse(Global.varRPM.ToString ());

               Global.SFCwt = 50; // double.Parse(Global.GenData[103]);

               Global.SFCTm = double.Parse(Global.GenData[4]); 
               
                Global.SFCValkW = clsFun.Cal_SFC_G(Global.VarPowkW, Global.SFCwt, Global.SFCTm);
                Global.SFCValPs = clsFun.Cal_SFC_G(Global.VarPowHp, Global.SFCwt, Global.SFCTm);

                Global.fl_Rate = clsFun.Flow_Rate(Global.SFCwt, Global.SFCTm);
                Global.Bi_Val = clsFun.Fuel_Del(Global.SFCwt, Global.SFCTm,r,N);
             
                Double P1 = Global.Atp;
                Double D1 = Global.Drb; 
                Double W1 = Global.Web;
                Double S1 = Convert.ToDouble(Global.Svol);


                if (Global.Prj[4] == "IS_1585_NA")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_1585_TC")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_NA")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_TC")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "CF_DIN")
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);
                else if (Global.Prj[4] == "CF_IS_10003")
                    Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                else
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

               
                Global.C_SFCValkW = Global.SFCValkW / Global.Corfact;
                Global.C_SFCValPs  = Global.SFCValPs / Global.Corfact;
               
                Global.GenData[103] = Global.SFCwt.ToString("000");
                Global.GenData[104] = Global.SFCTm.ToString("000.0"); ;
                Global.GenData[105] = Global.Corfact.ToString("0.0000"); ;
                Global.GenData[108] = Global.SFCValkW.ToString("00.0"); ;
                Global.GenData[109] = Global.Bi_Val.ToString("00.0"); ;
                Global.GenData[112] = Global.C_SFCValkW.ToString("00.0"); ;
                Global.GenData[113] = Global.fl_Rate.ToString("00.00"); ;
                Global.GenData[117] = Global.SFCValPs.ToString("00.0"); ;
                Global.GenData[118] = Global.C_SFCValPs.ToString("00.0"); ; 

               
                Global.SFC_msg = "SFC Status .....";
                flg_ProgOut = true;
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Cal_SFC() : ", "Alart");
                return;
                //Global.Create_OnLog(ex.Message,false);
            }
        }





#endregion

      
        private void Tss6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.AnaOut1 >= 9.999) Global.AnaOut1 = 9.999;
               
                    Automation.BDaq.ErrorCode err;
                    dataScaled[0] = Global.AnaOut1;
                    err = Global.InstantAO.Write(0, 1, dataScaled);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Tss5 :" + ex.Message);
            }
        }

        private void Tss7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.AnaOut2 >= 9.999) Global.AnaOut2 = 9.999;
               
                    Automation.BDaq.ErrorCode err;
                    dataScaled[1] = Global.AnaOut2;
                    err = Global.InstantAO.Write(0, 2, dataScaled);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in Tss6 :" + ex.Message);
            }
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
            Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);

          

        }  
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetOutPut();
            EngDialog1 frm= new EngDialog1();
            frm.ShowDialog(this);
            frm.Dispose(); 
        }

       
       
      

        private void mnuLimEngFile_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                frmLEfiles frm = new frmLEfiles();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }
        }

        private void tmrAvg_Tick(object sender, EventArgs e)
        {
            LogAVGData();
        }





        private void LogAVGData()
        {
            try
            {
                int i = 0;
                String strData = null;
                for (i = 0; i <= 59 ; i++)
                {
                    Global.Data[i] = Global.GenData[i];
                    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                    strData = strData + Global.Data[i] + "', '";
                }
                strData = strData + Global.Data[i];
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO AvgTemp VALUES ('" + strData + "'" + ")";
                cmd.Connection = Global.con;
                cmd.ExecuteNonQuery();
                Global.con.Close();
            }
            catch
            {
                Global.Create_OnLog("Error in Log Avg.....", "Alart");
                return;
            }
        }



        private void GridSeq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Lst = Global.StpN; 

            if (Btn24.Text == "Cycle_Resume")
            {
                Hold_Cycle(true);
            }
            int Ast = GridSeq.CurrentRow.Index + 1;
            if ((Ast <= -1) || (Ast >= GridSeq.RowCount)) // || (Ast == Lst))
            {
                MessageBox.Show("Invalid Selection of Step......");
                return;
            }
            else
            {
                if (MessageBox.Show("Do you Want to Select Step No. " + (Ast) + " ...?", "Step Change", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PBar3.Caption = "RAMP TIME:";
                    if (tmrAvg.Enabled == true)
                    {
                        tmrAvg.Stop();
                        Tss9.Text = "Avg inturrupted ";
                        Global.Open_Connection("gen_db", "con");
                        MySqlCommand cmd = new MySqlCommand ("DELETE * FROM AVGTemp", Global.con);
                        cmd.ExecuteNonQuery();
                        Global.con.Close();
                    }

                    Global.StpN = Ast - 1;
                    Load_ProgStep();
                    Hold_Cycle(false);
                }
            }

            //int Lst = Global.StpN;

            //if (Btn24.Text == "Cycle_Resume")
            //{
            //    Hold_Cycle(true);
            //}
            //int Ast = GridSeq.CurrentRow.Index;
            //if ((Ast <= -1) || (Ast >= GridSeq.RowCount) || (Ast == Lst))
            //{
            //    MessageBox.Show("Invalid Selection of Step......");
            //    return;
            //}
            //else
            //{
            //    if (MessageBox.Show("Do you Want to Select Step No. " + (Ast) + " ...?", "Step Change", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        //lblStatus.Text = "RAMP TIME:";
            //        PBar3.Caption = "RAMP TIME:";
            //        //GridSeq.Enabled = false;
            //        Global.LastAna1 = Double.Parse(Global.SetPtOut1);
            //        Global.LastAna2 = Double.Parse(Global.SetPtOut2);
            //        Global.StpN = Ast;
            //        Load_ProgStep();
            //        Hold_Cycle(false);
            //    }
            //}

        }

        private void BtnSA_Click(object sender, EventArgs e)
        {
            panel6.BringToFront();
            panel6.Visible = true;
           

            //radioButton1.BringToFront();
            //radioButton2.BringToFront();
            //radioButton3.BringToFront();
            //radioButton4.BringToFront();  

            comboBox2.SelectedIndex = 0; 
            Global.flg_Auto = false;
            Global.Make_mdb(Global.DataPath);

            Global.main.Create_FileName(Global.EngNo);
            Global.Sn = 0;
            checkBox13.Text = Global.EngNo;
            //checkBox15.Text = Global.Eng_FileNm;
            checkBox8.Text = Global.PrjNm;
            //LoadDgView();
           
        }

        private void Btn26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.flg_CycleStarted == true)
                {
                    if (tmrAvg.Enabled == true)
                    {
                        tmrAvg.Stop();
                        AddListItem("Averaging Intrrupted for SFC....", "Normal");
                    }
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM avgtemp", Global.con);
                    cmd.ExecuteNonQuery();

                    Global.flg_SFC = false;
                    Global.SFC_Reset = true;
                    Global.Auto_SFC = false;
                }
                else
                {                   
                    MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                    return;                            
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn13_Click():  " + ex.Message);
            }
        }

        private void Btn25_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                LogData(); 
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }          
          
        }

     
        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel6.Left = e.X + panel6.Left - MouseDownLocation.X;
                panel6.Top = e.Y + panel6.Top - MouseDownLocation.Y;
            }
        }
        
        private void valueout()
        {
            double T = 0;
            double D = 0;
            Global.LastRPM = ((Convert.ToDouble(Global.varRPM) * 10) / Convert.ToDouble(Global.sysIn[5]));
            Global.LastTrq = ((Convert.ToDouble(Global.varTRQ) * 10) / Convert.ToDouble(Global.sysIn[4]));

            Global.LastAna1 = double.Parse(Global.SetPtOut1);
            Global.LastAna2 = double.Parse(Global.SetPtOut2);



            MSt = comboBox2.Text.Substring(0, 1);
            Global.C_Mode = MSt;

            //***************** Standard Change over   


            //*************For Regular  Change Over
            if (Global.flg_Std_Changeover == true)
            {
                switch (Global.C_Mode)
                {
                    case "6":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "5":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);                      
                        Global.SetPtOut2 = (D / 10).ToString();
                        break;
                      
                    case "4":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                      
                    case "3":                       
                        T = Double.Parse(textBox6.Text);                       
                        Global.SetPtOut1 = (T / 10).ToString();
                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                       
                    case "2":
                        T = double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = double.Parse(textBox5.Text); 
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "1":
                        T = double.Parse(textBox6.Text);
                        Global.SetPtOut1 = (T / 10).ToString();
                        D = double.Parse(textBox5.Text); 
                        Global.SetPtOut2 = (D / 10).ToString();
                        break; 
                    default:
                        T = double.Parse(textBox6.Text);
                        Global.SetPtOut1 = (T / 10).ToString();
                        D = double.Parse(textBox5.Text); 
                        Global.SetPtOut2 = (D / 10).ToString();
                        break;
                }
            }

            else if ( Global.flg_Smt_Changeover == true)//***************** Smooth Change over 
            {
                switch (Global.C_Mode)
                {
                    case "6":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "5":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);
                        Double x = (D * (Global.Max_Trq)) / 100;
                        Global.SetPtOut2 = ((x * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "4":
                        T = Double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "3":
                        Global.I_Rpm = 0;
                        T = Double.Parse(textBox6.Text);
                        Double Y = (T * (Global.F_Rpm) / 100);
                        Global.SetPtOut1 = ((Y * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();

                        D = Double.Parse(textBox5.Text);
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    case "2":
                        T = double.Parse(textBox6.Text);
                        Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                        D = double.Parse(textBox5.Text) * (Global.Max_Trq) / 100;
                        Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                        break;
                    default:
                        Global.I_Rpm = 0;
                        Global.Mode_Out(1, 0, 0);
                        T = double.Parse(textBox6.Text);
                        Global.SetPtOut1 = (T / 10).ToString();
                        D = double.Parse(textBox5.Text);
                        Global.SetPtOut2 = (D / 10).ToString();
                        break;
                }
            }
            //***********************
            Global.SetRPM = textBox6.Text;
            Global.SetTRQ = textBox5.Text;

            //*********************
            RMP1 = int.Parse(textBox9.Text) * 9;
            RMP2 = int.Parse(textBox8.Text) * 9;
            if (RMP1 <= 1) RMP1 = 1;
            if (RMP2 <= 1) RMP2 = 1;
            if (RMP1 >= RMP2) RMP = RMP1; else RMP = RMP2;
            Global.LastT = Convert.ToDouble(T);
            Global.LastD = Convert.ToDouble(D);
            if ((int.Parse(Global.L_Mode) == 1) && (int.Parse(Global.C_Mode) >= 5))
            {
                Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                RMP1 = 1;
            }           
            Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / RMP1;
            Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / RMP2;
            PBar1.Maximum = 10000;
            PBar2.Maximum = 10000;
            flg_M_Ramp = true;
            tmrAnaOut.Start();
        }        
        


       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Double x = Double.Parse(textBox6.Text);
                Double y = Double.Parse(textBox5.Text);
                MSt = comboBox2.Text.Substring(0, 1);

                switch (MSt)
                {
                    case "1":
                        label13.Text = "%";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("00.00");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "2":
                        label13.Text = "R";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "3":
                        label13.Text = "%";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("00.00");
                        textBox5.Text = y.ToString("000.0");
                        break;
                    case "4":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("000.0");
                        break;
                    case "5":
                        label13.Text = "R";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "6":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("000.0");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tmrAnaOut_Tick(object sender, EventArgs e)
        {          
            //TmrCnt++;
            StpCnt++;


            //t11 = TimeSpan.FromSeconds(TmrCnt/10);
            //answer11 = string.Format("{0:D2}:{1:D2}:{2:D2}", t11.Hours, t11.Minutes, t11.Seconds);
            Tss301.Text = clsFun.cummbuff; // nswer11;

            t12 = TimeSpan.FromSeconds(StpCnt/10);
            answer12 = string.Format("{0:D2}:{1:D2}:{2:D2}", t12.Hours, t12.Minutes, t12.Seconds);
            Tss302.Text = answer12;

            lblrpmfb.Text = Global.GenData[0];
            lblTrqfb.Text = Global.GenData[1];

            Tss10.Text = Global.C_Mode;
           
           //if (Global.flg_Smt_Changeover == true)     
            
            if (flg_M_Ramp == true)
            {
                if (RMP1 <= 0)
                {
                    RMP1 = 0;
                    label33.Text = "sec";
                }
                else
                {
                    RMP1 -= 1;
                    label33.Text = RMP1.ToString();
                }
                if (RMP2 <= 0)
                {
                    RMP2 = 0;
                    label32.Text = "sec";
                }
                else
                {
                    RMP2 -= 1;
                    label32.Text = RMP2.ToString();
                }
                if (RMP <= 0)
                {
                    RMP = 0;
                    //tss2.Text = "00";
                    Global.L_Mode = Global.C_Mode;
                    flg_M_Ramp = false;
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                }
                else
                {
                    RMP -= 1;
                    Tss303.BackColor = Color.Red;
                    Tss303.Text = "Ramp-State  :" + RMP.ToString();
                    if (Global.flg_Smt_Changeover == true) clsFun.MODE_TO_MODE_Smooth();
                    if (Global.flg_Std_Changeover == true) clsFun.MODE_TO_MODE_Std();
                }
            }
            else
            {
                flg_M_Ramp = false;
                Tss303.BackColor = Color.Green;
                Tss303.Text = "Steady-State";
                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                        Global.Mode_Out(1, 0, 0);
                        break;
                    case 2:
                        Global.Mode_Out(0, 1, 0);
                        break;
                    case 3:
                        Global.Mode_Out(1, 1, 0);
                        break;
                    case 4:
                        Global.Mode_Out(0, 0, 1);
                        break;
                    case 5:
                        Global.Mode_Out(1, 0, 1);
                        break;
                    case 6:
                        Global.Mode_Out(0, 1, 1);
                        break;
                }

                switch (Global.C_Mode)
                {
                    case "2":
                    case "4":
                    case "5":
                    case "6":
                        if (Global.RcrOn == "TRUE")
                        {
                            int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));

                            if ((rDiff <= 60) && (rDiff >= 4))
                            {
                                Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                            }
                            else if ((rDiff >= -60) && (rDiff <= -4))
                            {
                                Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                            }
                        }
                        break;
                }
            }
        }
       
      

        private void mnuSimulate_Click(object sender, EventArgs e)
        {
            frmSimulation frm = new frmSimulation();
            frm.ShowDialog();
            frm.Dispose(); 

        }

        private void btrIdle_Click(object sender, EventArgs e)
        {
            tmrIdel.Start();
        }
       
       
        private void mnuClose_Click(object sender, EventArgs e)
        {
           
                Process[] prs = Process.GetProcesses();
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName == "Editors") pr.Kill();
                    if (pr.ProcessName == "EXCEL") pr.Kill();
                    if (pr.ProcessName == "Main_EDAC") pr.Kill();
                }              
                AddListItem("Fast Logging Stopped.....", "Normal");
                this.Close();
           
        }

        private void mnusyspara_Click(object sender, EventArgs e)
        {
            frmSysPara frm = new frmSysPara();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuChannel_Click(object sender, EventArgs e)
        {
            frmConf frm = new frmConf();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuComports_Click(object sender, EventArgs e)
        {
            frmSysCf frm = new frmSysCf();
            frm.ShowDialog(this);
            frm.Dispose();
        }

		private void Btn27_Click(object sender, EventArgs e)
		{
			IdleEng();
			AddListItem("Engine Stop By Operator .....", "Normal");
		}

		
		private void mnuShowData1_Click(object sender, EventArgs e)
		{
            if (Global.flg_CycleStarted == true)
            {
                frmRStatus frm = new frmRStatus();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }
		}
     
        private void mnuShowDataFiles_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "DataManagement") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "DataManagement.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start(); 
        }
       
       
        private void btnMclose_Click(object sender, EventArgs e)
        {
            IdleEng();  
            stopEngine();
            panel6.Visible = false;
            panel6.SendToBack();
        }

        private void btnMidle_Click(object sender, EventArgs e)
        {
            IdleEng(); 
        }

        private void btnDemand_Click(object sender, EventArgs e)
        {
            valueout();
            StpCnt = 0;
            Btn21.Enabled = false;
            Btn22.Enabled = true;
            Btn23.Enabled = true;
            Btn24.Enabled = true;
            Btn25.Enabled = true;
            Btn26.Enabled = true;
            //mnuRunData.Enabled = true;

            Double x = Double.Parse(textBox6.Text);
            Double y = Double.Parse(textBox5.Text);
            tmrLog.Start();
            timer1.Start();
            btnMclose.Enabled = true;
        }

        private void MlogTm_Leave(object sender, EventArgs e)
        {
            Double y = Double.Parse(MlogTm.Text);
            Global.LogTm = (int)y;
            Global.LTm = (int)y;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.CheckState == CheckState.Checked)
            {
                Global.flg_LogM = true;
                MlogTm.Enabled = true;
                Double y = Double.Parse(MlogTm.Text);
                Global.LogTm = (int)y;
                Global.LTm = (int)y;
            }
            else
            {
                Global.flg_LogM = false;
                MlogTm.Enabled = false;
            }
            
        }

       
        private void mnuRun_Status_Click(object sender, EventArgs e)
        {
            try
            {
                string ToDate = DateTime.Now.ToString("ddMMMyy");
                Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = Global.DataPath + "Log_Data\\OnLog_" + ToDate + ".txt";
                Process p = Process.Start("notepad.exe", strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12002", ex.Message);
            }

        }

       
        private void Btn22_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmrIdel.Enabled == true) tmrIdel.Enabled = false;
                Global.flg_fastlog = false;
                Global.flg_flog = false;
                //frmPar.btnStart.Enabled = true;
                //frmPar.btnStop.Enabled = true;
                AddListItem("Engine Stop By Operator .....", "Normal");
                AddListItem("Fast Logging Stopped.....", "Normal");
                stopEngine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn23_Click():  " + ex.Message);
            }
        }

        private void GridSeq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuE_Start_Click(object sender, EventArgs e)
        {
            if (Global.varRPM <= Global.S_Rpm)
            {
                Tss1.Text = "Wait For RunningIn signal ......";
                Tss1.BackColor = Color.Red;
                Tss1.ForeColor = Color.Yellow;
                Btn21.Enabled = false;
                Btn22.Enabled = false;
                Btn23.Enabled = false;
                Btn24.Enabled = false;
                Btn25.Enabled = false;
                Btn26.Enabled = false;

                Global.Dig_OutBit(0, 7, true);  //Ingnition on
                Thread.Sleep(500);
                Global.Dig_OutBit(1, 0, true);  //Eng start Pulse
                Thread.Sleep(500);
                Global.Dig_OutBit(1, 0, false);//Eng start Pulse false                    

                Tss1.Text = "Satrt the Engine....";
            }
        }

        private void Btn23_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                frmSmoke frm = new frmSmoke();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }          
        }

        private void Btn24_Click(object sender, EventArgs e)
        {
            Hold_Cycle(true);
            Auto_Hold = false;
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            Global.Rd_SerialPort_RT();
            Tss4.Text = Global.bufftss8;
           
        }

        private void tmrSmk_Tick(object sender, EventArgs e)
        {
            try
            {

                Global.S_Add++;
                Tss5.Text = Global.S_Add.ToString();
                if (Global.flg_smokeStart == true)
                {
                    if (Global.S_Add == 3)
                        Global.smkPort.Write(" SMES");
                    if (Global.S_Add >= 18)
                    {
                        Tss5.Text = "";
                        Global.smkPort.Write(" AFSN");
                        Thread.Sleep(200);
                        string buffer = (Global.smkPort.ReadExisting());
                        Global.smkbuffer = buffer;
                        Global.flg_smokeStart = false;
                        Global.GenData[101] = Global.smkbuffer.Substring((buffer.Length - 7), 6);
                        Global.SmkVal = Double.Parse(Global.GenData[101]);
                        Tss5.Text = Global.GenData[101];
                        Global.S_Add = 0;
                        tmrSmk.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }

      
     
      




    }
}
       

       
       

       

       
       
       
       

        

     

       

       
       
           

       

        
       
       

        
       
        

       

       


        

        
         
        
       
       

       
     
   

       

 
        
    

       