using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label3.Left = (this.ClientSize.Width - label3.Size.Width) / 2;
            label5.Left = (this.ClientSize.Width - label5.Size.Width) / 2;
            //label6.Left = (this.ClientSize.Width - label6.Size.Width) / 2;
            //label4.Left = (this.ClientSize.Width - label2.Size.Width) / 2;
            //label2.Left = (this.ClientSize.Width - label2.Size.Width) / 2;  
            Load_Grid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           frmFiles frm2 = new  frmFiles(); 
          // frm2.Show();
            frm2.ShowDialog();
            //this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void Load_Grid()
        {
            DGf.RowCount = 15;
            DGf[0, 0].Value = 1;
            DGf[1, 0].Value = "Engine Speed Revolutions/min";
            DGf[2, 0].Value = "****";
            DGf[3, 0].Value = "rev/min";

            DGf[0, 1].Value = 2;
            DGf[1, 1].Value = "Engine Torque";
            DGf[2, 1].Value = "****";
            DGf[3, 1].Value = "Nm";

            DGf[0, 2].Value = 3;
            DGf[1, 2].Value = "Engine Rated Power @ rpm";
            DGf[2, 2].Value = "Engine rpm where Max Power is achieved.....";
            DGf[3, 2].Value = "Nm";

            DGf[0, 3].Value = 4;
            DGf[1, 3].Value = "Engine Max Torque  @ rpm";
            DGf[2, 3].Value = "Engine rpm where Max Torque is achieved.....";
            DGf[3, 3].Value = "Nm";

            DGf[0, 4].Value = 5;
            DGf[1, 4].Value = "Engine Power (kW) \n" +
                           "=  (N * T) / k";
            DGf[2, 4].Value = "(2 π N T/(60 * 1000) \n" +
                              "N = rpm \n" +
                              "T = Torque (Nm)\n" +
                              "k = (2 π) / (60 * 1000) =  9549.29";
            DGf[3, 4].Value = "kW";
            DGf.Rows[4].Height = 80;

            DGf[0, 5].Value = 6;
            DGf[1, 5].Value = "Engine Power (ps) \n" +
                              "=  (N * T) / k";
            DGf[2, 5].Value = "((2 π N T))/(4500 * 9.81)) \n " +
                              "N = rpm \n" + 
                              "T = Torque (Nm)\n" +
                              "k = (2 π) / (4500 * 9.81) =  7025.89";
            DGf[3, 5].Value = "PS";
            DGf.Rows[5].Height = 80;

           
            
            DGf[0, 6].Value = 7;
            DGf[1, 6].Value = "Fuel Consumption \n" +
                              "(g * 3600)/((power * t)) \n";
            DGf[2, 6].Value = "(g * 3600)/((power * t)) \n" + 
                              "g = fuel weight (gms) \n" +
                              "Power :  kW. \n" + 
                              "t = time in sec to consume g";
            DGf[3, 6].Value = "g/(kW*hr)";
            DGf.Rows[6].Height = 80;

            DGf[0, 7].Value = 8;
            DGf[1, 7].Value = "Fuel Consumption \n" +
                              "(g * 3600)/((power * t)) \n";
            DGf[2, 7].Value = "(g * 3600)/((power * t)) \n" + 
                              "g = fuel weight (gms) \n" + "Power :  PS. \n" + 
                              "t = time in sec to consume g";
            DGf[3, 7].Value = "g/(PS*hr)";
            DGf.Rows[7].Height = 80;
           
           
            DGf[0, 8].Value = 9;
            DGf[1, 8].Value = "Flow Rate \n g/s";
            DGf[2, 8].Value = "Fuel Consumption Rate (g/tm) \n" + 
                              "g: gms  \ntm : time (s)";
            DGf[3, 8].Value = "g/s";
            DGf.Rows[8].Height = 60;

            DGf[0, 9].Value = 10;
            DGf[1, 9].Value = "Fuel Delivery \n+ Bi - value";
            DGf[2, 9].Value = "(g * 2000 * 3600)/(60 * Tm * 0.835*rpm* C  \n" + 
                              "g : fuel weight (g)  \n" + 
                              "Tm = consumption time (s)  \n" + 
                              "Rpm : engine revolutions \nC : number of cylinders ";
            DGf[3, 9].Value = "mm^3/strk.cln";
            DGf.Rows[9].Height = 100;

            DGf[0, 10].Value = 11;
            DGf[1, 10].Value = "Corr.Factor  \nCF_DIN_70020";
            DGf[2, 10].Value = "(squre root[((273)+ dbt)/293]*(760/pb)  \n " +
                               "dbt : Dry bulb temp (Celsius) \n" +
                               "pb  : Barometric Pressure (mmHg)"; 
            DGf[3, 10].Value = "****";
            DGf.Rows[10].Height = 80;

            DGf[0, 11].Value = 12;
            DGf[1, 11].Value = "Corr.Factor  \n CF_BS_AU_141";
            DGf[2, 11].Value = "Pressure Correction = \n" +
                               "((fd / 0.834)^2.88) * (refAtms - (Pb * 750)) * 0.00000059 \n" +
                               "Temperature Corrections = \n" +
                               "((fd / 0.834), 1.76) * (T - refTemp) * 0.00012 \n" +
                               "fd = Fuel Delivery \n" +
                               "refTemp = 20 deg.c \n" +
                               "refAtms = 760 mmHg \n" +
                                " = (PC + TC + 100 ) / 100"; 
            DGf[3, 11].Value = "****";
            DGf.Rows[11].Height = 140;

            DGf[0, 12].Value = 13;
            DGf[1, 12].Value = "Corr.Factor  \n CF_ISO_1585_NA/TC";
            DGf[2, 12].Value = "fa〗^fm \n" +
                               "fa :  correction in Pressure \n" +
                               "fm :  correction in Temperature";                                
            DGf[3, 12].Value = "****";
            DGf.Rows[12].Height = 60;

            DGf[0, 13].Value = 14;
            DGf[1, 13].Value = "Corr.Factor  \n IS_14599_NA/TC";
            DGf[2, 13].Value = "fa〗^fm \n" +
                               "fa :  correction in Pressure \n" +
                               "fm :  correction in Temperature";
            DGf[3, 13].Value = "****";
            DGf.Rows[13].Height = 60;



            







        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain frm3 = new frmMain();
            // frm2.Show();
            frm3.ShowDialog();
            //this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }




        //********************
    }
}
