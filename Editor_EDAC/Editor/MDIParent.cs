using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Editor
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        string NodeT;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void Refresh_form()
        {
            //if (Application.OpenForms.OfType<frmEngine>().Count() == 1)
            //    Application.OpenForms.OfType<frmEngine>().First().Close();
            //if (Application.OpenForms.OfType<frmLimit_01>().Count() == 1)
            //    Application.OpenForms.OfType<frmLimit_01>().First().Close();
            if (Application.OpenForms.OfType<frmLimit>().Count() == 1)
                Application.OpenForms.OfType<frmLimit>().First().Close();
            if (Application.OpenForms.OfType<frmSeq>().Count() == 1)
                Application.OpenForms.OfType<frmSeq>().First().Close();
            //if (Application.OpenForms.OfType<frmSeq>().Count() == 1)
            //    Application.OpenForms.OfType<frmSeq>().First().Close();
            if (Application.OpenForms.OfType<frmPass>().Count() == 1)
                Application.OpenForms.OfType<frmPass>().First().Close();
            if (Application.OpenForms.OfType<frmPrint>().Count() == 1)
                Application.OpenForms.OfType<frmPrint>().First().Close();
            //if (Application.OpenForms.OfType<frmPassOut>().Count() == 1)
            //    Application.OpenForms.OfType<frmPassOut>().First().Close();
            if (Application.OpenForms.OfType<frmProject>().Count() == 1)
                Application.OpenForms.OfType<frmProject>().First().Close();

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
           
            Form childForm = new Form();

            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
      
        private void MDIParent_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Size.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Size.Height) / 2;
            Read_SystemFl();
           
        }
       
        
        private void MDIParent_Shown(object sender, EventArgs e)
        {
            //Tss1.Text = "'Make Project File..' Editor Open ........";
            //frmPassOut frm = new frmPassOut();
            //frm.Show(); 
            //frmSeqV frm = new frmSeqV();
            //frm.Show(); 
            //Tss1.Text = "'Make Project File..' Editor Open ........";
            //frmProject frm = new frmProject();
            //frm.Show(); 
            //frmProject frm = new frmProject();
            //frm.Show();
            //Tss2.Text = System.DateTime.Today.ToString("dd : MMMM : yyyy");
        }

      
        private void Read_SystemFl()
        {
            Common.Open_Connection("gen_db", "con");
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbsys where FileName = '08_SystemPara'", Common.con);
            MySqlDataReader Rd = cmd.ExecuteReader(); 

           
            Int16 x = 0;
            while (Rd.Read())
            {
                for (x = 0; x <= (Rd.FieldCount - 1); x++)
                {
                    Global.sysIn[x] = Rd.GetValue(x).ToString();
                }
            }

            Global.T_CellNo = Global.sysIn[9];

            cmd.Dispose();
            Common.con.Close();

        }
        
       

        private void printFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Print Format Editor Opened.....", "Alert");
            Tss1.Text = "'Make Print Format File..' Editor Open ........";
            frmPrint frm = new frmPrint();
            frm.Show();
        }

        private void mnuProject_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Project Editor Opened.....", "Alert");
            Tss1.Text = "'Make Project File..' Editor Open ........";
            frmProject frm = new frmProject();
            frm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_form();
            this.Close(); 
        }

        private void mnuEngine_Click(object sender, EventArgs e)
        {
            //Refresh_form();
            //Global.Create_OffLog(" Engine Editor Opened.....", "Alert");
            //Tss1.Text = "'Make Engine File..' Editor Open ........";
            //frmEngine frm = new frmEngine();
            //frm.Show();
        }

        private void mnuPassOfLimit_Click(object sender, EventArgs e)
        {
            //Refresh_form();
            //Global.Create_OffLog(" Pass Of Noms Editor Opened.....", "Alert");
            //Tss1.Text = "'Make Pass Of Limits File..' Editor Open ........";
            //frmPassOut  frm = new frmPassOut();
            //frm.Show();
        }

        private void mnuLimit_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Limit File Editor Opened.....", "Alert");
            Tss1.Text = "'Limits File..' Editor Open ........";
            frmLimit  frm = new frmLimit();
            frm.Show();

        }

        private void mnuSequence_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Sequence File Editor Opened.....", "Alert");
            Tss1.Text = "'Sequence File..' Editor Open ........";
            frmSeq frm = new frmSeq();
            frm.Show();
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Password File Editor Opened.....", "Alert");
            Tss1.Text = "'Change Password File..' Editor Open ........";
            frmPass frm = new frmPass();
            frm.Show();
        }
       
        private void mnuManual_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Sequence File Editor Opened.....", "Alert");
            Tss1.Text = "'Sequence File..' Editor Open ........";
            frmSeq frm = new frmSeq();
            frm.Show();
        }

        private void mnuAuto_Click(object sender, EventArgs e)
        {
            Refresh_form();
            Global.Create_OffLog(" Sequence File Editor Opened.....", "Alert");
            Tss1.Text = "'Sequence File..' Editor Open ........";
            frmSeq frm = new frmSeq(); 
           // frmCSpSeq frm = new frmCSpSeq();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close ();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Refresh_form();
            if (rdEngine.Checked == true)
            {
                frmEngine frm = new frmEngine();
                frm.Show();
            }
            else if (rdLimit.Checked == true)
            {               
                frmLimit frm = new frmLimit();
                frm.Show();
            }
            else if (rdProject.Checked == true)
            {
                frmProject frm = new frmProject();
                frm.Show();
            }
            //else if (rdSeqC.Checked == true)
            //{
            //    frmSeq frm = new frmSeq();
            //    frm.Show();
            //}
            else if (rdSeqV.Checked == true)
            {
                frmSeq frm = new frmSeq();
                frm.Show();
            }
            else if (rdFormat.Checked == true)
            {
                frmPrint frm = new frmPrint();
                frm.Show();
            }
            else if (rdPassword.Checked == true)
            {
                frmPass frm = new  frmPass();
                frm.Show();
            }

        }

        private void rdEngine_CheckedChanged(object sender, EventArgs e)
        {
           if (rdEngine.Checked == true)
           {
               rdEngine.BackColor = Color.White;
               rdEngine.ForeColor = Color.DimGray;
           }
           else
           {
               rdEngine.BackColor = Color.SteelBlue;
               rdEngine.ForeColor = Color.White;
           }

        }

        private void rdLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLimit.Checked == true)
            {
                rdLimit.BackColor = Color.White;
                rdLimit.ForeColor = Color.DimGray;
            }
            else
            {
                rdLimit.BackColor = Color.SteelBlue;
                rdLimit.ForeColor = Color.White;
            }
        }

        private void rdPassNorms_CheckedChanged(object sender, EventArgs e)
        {
            if (rdProject.Checked == true)
            {
                rdProject.BackColor = Color.White;
                rdProject.ForeColor = Color.DimGray;
            }
            else
            {
                rdProject.BackColor = Color.SteelBlue;
                rdProject.ForeColor = Color.White;
            }
        }

        private void rdSeqC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSeqC.Checked == true)
            {
                rdSeqC.BackColor = Color.White;
                rdSeqC.ForeColor = Color.DimGray;
            }
            else
            {
                rdSeqC.BackColor = Color.SteelBlue;
                rdSeqC.ForeColor = Color.White;
            }
        }

        private void rdSeqV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSeqV.Checked == true)
            {
                rdSeqV.BackColor = Color.White;
                rdSeqV.ForeColor = Color.DimGray;
            }
            else
            {
                rdSeqV.BackColor = Color.SteelBlue;
                rdSeqV.ForeColor = Color.White;
            }
        }

        private void rdFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFormat.Checked == true)
            {
                rdFormat.BackColor = Color.White;
                rdFormat.ForeColor = Color.DimGray;
            }
            else
            {
                rdFormat.BackColor = Color.SteelBlue;
                rdFormat.ForeColor = Color.White;
            }
        }

        private void rdPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPassword.Checked == true)
            {
                rdPassword.BackColor = Color.White;
                rdPassword.ForeColor = Color.DimGray;
            }
            else
            {
                rdPassword.BackColor = Color.SteelBlue;
                rdPassword.ForeColor = Color.White;
            }

        }

      
      
      


		
	}
}
