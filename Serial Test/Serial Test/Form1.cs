using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading; 
using System.Text;
using System.IO.Ports;  
using System.Windows.Forms;

namespace Serial_Test
{
    public partial class Form1 : Form
    {
        private SerialPort msPort = new SerialPort();
        string[] ports = SerialPort.GetPortNames();
        private int I_Add = 0; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init_SrPort(); 
            timer1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();  
        }
        public void Init_SrPort()
        {
            try
            {
                msPort.PortName = cmbBox.Text; 
                if (msPort.IsOpen == true) msPort.Dispose(); // .Close();
                msPort.BaudRate = int.Parse("9600");
                msPort.DataBits = int.Parse("8");
                msPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                msPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (msPort.IsOpen == false)
                {
                    msPort.Dispose();
                    msPort.PortName = cmbBox.Text; 
                    msPort.Open();
                    //Global.Create_OnLog("MSport Opened '''", true);
                }
            }
            catch
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
                //Global.Create_OnLog("RTport Opened .....", false);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            cmbBox.Items.Add("COM");
            foreach (string port in ports)
            {
                cmbBox.Items.Add(port);               
            }
            dataGridView1.RowCount = 10; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msPort.Close();             
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rd_SerialPort();
        }
        private void Rd_SerialPort()
        {
            String buffer = "";
            string bufftss4;
            try
            {
                buffer = (msPort.ReadExisting());
                bufftss4 = buffer;
                int pos;
               
                if (I_Add <= 9)
                    dataGridView1[0, I_Add].Value = bufftss4;
                else if ((I_Add >= 10) && (I_Add < 20))
                    dataGridView1[1, I_Add - 10].Value = bufftss4;
                else if ((I_Add >= 20) && (I_Add < 30))
                    dataGridView1[2, I_Add - 20].Value = bufftss4;
                
                msPort.Close();
                Thread.Sleep(20);
                if (!msPort.IsOpen == true) msPort.Open();

                if (I_Add >= 30) I_Add = 0; else I_Add += 1;

                if (I_Add <= 9)
                {
                    msPort.Write("*0" + I_Add + "T%");
                }
                else
                {
                    msPort.Write("*" + I_Add + "T%");
                }

               
            }
            catch (Exception ex)
            {

                //msPort.Write("*00T%");
                //if (I_Add >= 21) I_Add = 0; else I_Add += 1;
                //I_Add += 1;
                //Global.Create_OnLog(ex.Message + "  : " + I_Add + " :  Read SerialPort()....", false);
                return;
                //MessageBox.Show("read serial Port String Not proper: " + I_Add + ":-" + buffer);
            }

        }





    }
}
