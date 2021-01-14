using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Threading;
using System.Diagnostics; 
using System.Net.Sockets;

namespace Read_6018
{

    public partial class Form1 : Form
    {        
       private string m_IP18;
       private string m_IP17;
		private int m_iCount, m_iPort;
		private int m_iStart1, m_iLength1;
        private int m_iStart2, m_iLength2;
		private bool m_bRegister1, m_bStart1;
        private bool m_bRegister2, m_bStart2;
        private Stopwatch st = new Stopwatch();
        //private System.Windows.Forms.Timer timer1;
        //private ColumnHeader columnHeaderValFloat;
		private AdamSocket adamTCP1;
        private AdamSocket adamTCP2;
        private Random rand1 = new Random();
        public static Thread RdADAMThread;
        private int Nt = 0;
        private string  C;

        //int iIdx, iPos, iStart;
			
          

        public Form1()
        {
            InitializeComponent();
           	// *********************
            //int iIdx, iPos, iStart;
            
            m_bStart1 = false;			// the action stops at the beginning
			m_bRegister1 = true;		// set to true to read the register, otherwise, read the coil
            m_bStart2 = false;			// the action stops at the beginning
            m_bRegister2 = false;		// set to true to read the register, otherwise, read the coil
            m_IP18 = "192.168.1.241"; // "172.18.3.243";	// modbus slave IP address
            m_IP17 = "192.168.1.242";  //modbus slave IP address
			m_iPort = 502;				// modbus TCP port is 502
			m_iStart1 = 1;				// modbus starting address
			m_iLength1 = 8;
            m_iStart2 = 1;				// modbus starting address
            m_iLength2 = 8;	// modbus reading length
			adamTCP1 = new AdamSocket();
            adamTCP2 = new AdamSocket();
			adamTCP1.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            adamTCP2.SetTimeout(1000, 1000, 1000); // set timeout for TCP
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DGView11.RowCount = 5;
            DGView11[0, 0].Value = "ADAM-6018"; DGView11[1, 0].Value = "192.168.1.241";
            DGView11[0, 1].Value = "ADAM-6017"; DGView11[1, 1].Value = "192.168.1.242";
            //DGView11[0, 2].Value = "ADAM-6015"; DGView11[1, 2].Value = "192.168.1.243"; 
        }

      
        private void timer1_Tick(object sender, EventArgs e)
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
                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 1370) / 65535)*1000;
                        DGView11[iIdx + 2, 0].Value = ((rand1.Next(((int)ValF  - 1) ,((int)ValF  + 1)))/1000.0).ToString("000.000");
                    }
                }
                //m_bRegister1 = false;
                //m_bRegister2 = true;
            }
            //else if (m_bRegister2) // Read registers (4X references)
            //{               
            //    adamTCP2.Connect(m_IP17, ProtocolType.Tcp, m_iPort);
            //    if (adamTCP2.Modbus().ReadHoldingRegs(m_iStart2, m_iLength2, out iData))
            //    {                   
            //        for (iIdx = 0; iIdx < m_iLength2; iIdx++)
            //        {
            //            Double ValF = (Convert.ToDouble(iData[iIdx]));
            //            DGView11[iIdx + 2, 1].Value = ((rand1.Next(((int)ValF - 1), ((int)ValF + 1))) / 1000.0).ToString("000.000");
            //        }
            //    }
            //    m_bRegister2 = false;
            //    m_bRegister1 = true;
            //}
       }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Start(); 
            RdADAMThread = new Thread(new ThreadStart(RADAM_Thread));
            RdADAMThread.Start();
            st.Start();
            Nt = 0;
        }

        public void RADAM_Thread()
        {
            try
            {               
                while (true)
                {
                    //Thread.Sleep(40);
                    Read_AdamValues(); // Read_ECUValues();  
                    //Nt++;
                    //if (Nt >= 100)
                    //{
                    //    st.Stop();
                    //    C = st.ElapsedMilliseconds.ToString();
                    //}
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void Read_AdamValues()
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
                        DGView11[iIdx + 2, 0].Value = ((rand1.Next(((int)ValF - 10), ((int)ValF + 10))) / 1000.0).ToString("000.000");
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
                        Double ValF = ((Convert.ToDouble(iData[iIdx]) * 65535) / 16);
                        DGView11[iIdx + 2, 1].Value = ((rand1.Next(((int)ValF - 10), ((int)ValF + 10))) / 1000.0).ToString("000.000");
                    }
                }
                m_bRegister2 = false;
                m_bRegister1 = true;
            }

        }
            
	
        
    }
}
