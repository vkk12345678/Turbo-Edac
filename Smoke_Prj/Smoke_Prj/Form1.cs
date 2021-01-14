using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;  

namespace Smoke_Prj
{
    public partial class Form1 : Form
    {
        private SerialPort msPort = new SerialPort();
        string[] ports = SerialPort.GetPortNames();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBox.Items.Add("COM");
            foreach (string port in ports)
            {
                cmbBox.Items.Add(port);               
            }           

        }

        private void ChkBtn_Click(object sender, EventArgs e)
        {
            string Buf ;
           
            label1.Text = "";
            Init_SrPort();
            Thread.Sleep(1000);
            msPort.Write(" SREM");
            Buf = "";
            Thread.Sleep(200);
            Buf = msPort.ReadExisting();
             if (Buf == "")
                 label1.Text = "Select Another Port .......";
             else
                 label1.Text = "Smoke port Is : " + cmbBox.Text;  
 

 
        }
        public void Init_SrPort()
        {
            try
            {
                
                if (msPort.IsOpen == true) msPort.Close();
                msPort.PortName = cmbBox.Text;
                msPort.BaudRate = int.Parse("9600");
                msPort.DataBits = int.Parse("8");
                msPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                msPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (msPort.IsOpen == false)
                {
                    msPort.Dispose();
                    msPort.PortName = cmbBox.Text;
                    msPort.Open();
                    msPort.DiscardInBuffer();
                    msPort.DiscardOutBuffer();  
                   
                }
            }
            catch
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
                //Global.Create_OnLog("RTport Opened .....", false);
                return;
            }
        }


    }
}
