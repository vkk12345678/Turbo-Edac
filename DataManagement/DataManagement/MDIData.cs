using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataManagement
{
    public partial class MDIData : Form
    {
        private int childFormNumber = 0;

        public MDIData()
        {
            InitializeComponent();
        }

        private void mnuExcel_Click(object sender, EventArgs e)
        {
            frmExcel frm = new frmExcel();
            frm.ShowDialog(this);
           
            frm.Dispose(); 
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void mnuGen_Click(object sender, EventArgs e)
        {
            try
            {
                frmGen frm = new frmGen();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error Code:- 17017", ex.Message);
            }


        }

       
       

        private void mnuHelp_Click(object sender, EventArgs e)
        {

        }

       
        

    }
}
