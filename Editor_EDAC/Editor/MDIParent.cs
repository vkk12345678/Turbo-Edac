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

        public MDIParent()
        {
            InitializeComponent();
        }
       
            //if (Application.OpenForms.OfType<UpdateWindow>().Count() == 1)
            //    Application.OpenForms.OfType<UpdateWindow>().First().Close();
       

        //public void mdiChild(Form mdiParent, Form mdiChild)
        //{
        //    foreach (Form frm in mdiParent.MdiChildren)
        //    {               
        //        if (frm.Name == mdiChild.Name)
        //        {
        //            //close if found

        //            frm.Close();

        //            return;
        //        }
        //    }

           
        //}

        private void Close_forms()
        {
            if (Application.OpenForms.OfType<frmEngine> ().Count() == 1)
                Application.OpenForms.OfType<frmEngine>().First().Close();
            if (Application.OpenForms.OfType<frmLimit>().Count() == 1)
                Application.OpenForms.OfType<frmLimit>().First().Close();
            if (Application.OpenForms.OfType<frmSeq>().Count() == 1)
                Application.OpenForms.OfType<frmSeq>().First().Close();
            if (Application.OpenForms.OfType<frmPass>().Count() == 1)
                Application.OpenForms.OfType<frmPass>().First().Close();
            if (Application.OpenForms.OfType<frmPrint>().Count() == 1)
                Application.OpenForms.OfType<frmPrint>().First().Close();

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
            Read_SystemFl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Common.Create_OnLog("Alart", "Editor Closed.....");
            tmrLogin.Enabled = false;
            this.Close();
        
        }

        private void MDIParent_Shown(object sender, EventArgs e)
        {
            Close_forms();
            Tss1.Text = "'Make Engine File..' Editor Open ........";
            frmLimit frm = new frmLimit();
            frm.Show();
            Tss2.Text = System.DateTime.Today.ToString("dd : MMMM : yyyy");
        }

        //private void btnEngine_Click(object sender, EventArgs e)
        //{
        //    Close_forms();

        //    Common.Create_OnLog("Alart", "Engine Editor Opened.....");
        //    Tss1.Text = "'Make Engine File..' Editor Open ........";
        //    frmEngine frm = new frmEngine();
        //    frm.Show();

        //}

        private void btnLimit_Click(object sender, EventArgs e)
        {
            Close_forms();
            Common.Create_OnLog("Alart", "Limit Editor Opened.....");
            Tss1.Text = "'Make Limit File' Editor Open ........";
            tmrLogin.Enabled = false;
            frmLimit frm = new frmLimit();
            frm.Show();


        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            Close_forms();
            Common.Create_OnLog("Alart", "Sequence Editor Opened.....");
            Tss1.Text = "'Make Sequence File' Editor Open ........";
            tmrLogin.Enabled = false;
            frmSeq frm = new frmSeq();
            frm.Show();
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            Close_forms();
            Common.Create_OnLog("Alart", "File Format Editor Opened.....");
            Tss1.Text = "'Make File Format' Editor Open ........";
            tmrLogin.Enabled = false;
            frmPrint frm = new frmPrint();
            frm.Show();

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            Close_forms();
            Common.Create_OnLog("Alart", "Password Editor Opened.....");
            Tss1.Text = "'Make Pass word' Editor Open ........";
            tmrLogin.Enabled = false;
            frmPass frm = new frmPass();
            frm.Show();
        
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Common.Create_OnLog("Alart", "Help PDF Opened.....");
            string helpFilepath = @"" + Global.HelpPath + "Help.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        private void btnPassout_Click(object sender, EventArgs e)
        {
            Common.Create_OnLog("Alart", "Passout Editor Opened....."); 
        }

        private void btnPrj_Click(object sender, EventArgs e)
        {
            Common.Create_OnLog("Alart", "Project Editor Opened.....");
        }

        private void Read_SystemFl()
        {
            Common.Read_SqlTable("tbsys", "FileName", "SystemPara"); //  Read_SqlTable(string TbNm, string flNm)
            for (int i = 0; i <= Global.sysIn.Length-1   ; i++)  
                Global.sysIn[i] = Global.arr[i];  

        }

		
	}
}
