using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; 
using System.Diagnostics; 
using System.Windows.Forms;
//using Microsoft.Office.Interop;
//using Excel = Microsoft.Office.Interop.Excel;      

namespace Logger
{
    public partial class EngOK : Form
    {
        private frmMain main = new frmMain();
        private String[] EngData = new String[30];
        public EngOK()
        {
            InitializeComponent();
        }

        private void EngOK_Load(object sender, EventArgs e)
        {
            try
            {                      
                MSFG.RowCount = 20;
                MSFG.ColumnCount = 2;
                String Str = "";
                foreach (DataGridViewColumn colm in MSFG.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = 1000; i <= 1018; i++)
                {
                    MSFG.Rows[i - 1000].Cells[0].Value = i;
                }

                MSFG.Rows[0].Cells[1].Value = "Low Oil Pressure";
                MSFG.Rows[1].Cells[1].Value = "Clutch Plate Damage";
                MSFG.Rows[2].Cells[1].Value = "Cylinder Head gasket leakage";
                MSFG.Rows[3].Cells[1].Value = "Rear Oil Seal Leak";
                MSFG.Rows[4].Cells[1].Value = "Oil Filter Leak";
                MSFG.Rows[5].Cells[1].Value = "Dip stick Holder Leak";
                MSFG.Rows[6].Cells[1].Value = "Head Cover Leakage";
                MSFG.Rows[7].Cells[1].Value = "Cam Oil seal Leakage";
                MSFG.Rows[8].Cells[1].Value = "High Blowby";
                MSFG.Rows[9].Cells[1].Value = "Water Pump Leakage";
                MSFG.Rows[10].Cells[1].Value = "Rear Cover Leakage";
                MSFG.Rows[11].Cells[1].Value = "Front Cover Leakage";
                MSFG.Rows[12].Cells[1].Value = "Tappet noise";
                MSFG.Rows[13].Cells[1].Value = "Abnormal Noise from Head";
                MSFG.Rows[14].Cells[1].Value = "Abnormal Noise from Block";
                MSFG.Rows[15].Cells[1].Value = "Timer Belt Noise";
                MSFG.Rows[16].Cells[1].Value = "Oil Sump Leak";
                MSFG.Rows[17].Cells[1].Value = "Low Power";
                MSFG.Rows[18].Cells[1].Value = "Injector Leakage";
                lblDfMatrix.Text = "";

                //******************

               
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Fill Engine Details....", "Alart");  
                //MessageBox.Show("ErrorCode :- 2001", ex.Message);
            }
        }

       //private void fill_Engine_Details() 
       //{

       //    String Str = "";
       //    Global.CStopTm = DateTime.Now.ToString("hh:mm:ss tt");

       //    for (int x = 0; x <= 19; x++) EngData[x] = null;
       //    //string  Str = null;
       //    EngData[0] = Global.Eng_FileNm;
       //    EngData[1] = Global.EngType;
       //    EngData[2] = Global.TestRef;
       //    EngData[3] = Global.FipNo;
       //    EngData[4] = Global.EngNo;
       //    EngData[5] = Global.NCyl;
       //    EngData[6] = Global.Bor;
       //    EngData[7] = Global.Strk;
       //    EngData[8] = Global.Svol;

       //    if (Global.flg_Radiator == true) EngData[9] = "YES"; else EngData[9] = "NO";
       //    if (Global.flg_Fan == true) EngData[10] = "YES"; else EngData[10] = "NO";
       //    if (Global.flg_AirCln == true) EngData[11] = "YES"; else EngData[11] = "NO";
       //    if (Global.flg_Silincer == true) EngData[12] = "YES"; else EngData[12] = "NO";

       //    EngData[13] = "EDB- 200";
       //    EngData[14] = Global.OperatorNm;
       //    EngData[15] = Global.EnginerNm; 
       //    EngData[16] = Global.T_CellNo;
       //    EngData[17] = Global.CStrtTm;
       //    EngData[18] = Global.CStopTm;
       //    if (Global.ErrorMatrix == null) Global.ErrorMatrix = "*******";
       //    EngData[19] = Global.ErrorMatrix;

       //    Str = "";
       //    for (int i = 0; i <= 18; i++)
       //    {
       //        if ((EngData[i] == null) || (EngData[i] == ""))
       //        {
       //            EngData[i] = "****";
       //        }
       //        Str = Str + EngData[i] + "', '";
       //    }
       //    Global.Open_DataConn("Data", "conData");
       //    SqlCommand cmd2 = new SqlCommand("Insert into EngDetails values('" + Str + EngData[19] + "' )", Global.conData);
       //    cmd2.ExecuteNonQuery();
       //    Global.conData.Close(); 

       //}
      
        private void ExportData()
        {
            try
            {
                if (Global.flg_RecorsPmData == true)
                {
                    Global.Open_PMConn(Global.CDate,  "conPM");
                    MySqlDataAdapter adp = new MySqlDataAdapter("select * from "+ Global.Eng_PMFileNm  , Global.conPM );
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    prgT.Maximum = ds.Tables[0].Rows.Count - 1;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count-1; i++)
                        {
                            prgT.Value = i;
                            string str = "";
                            string str1 = "'" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                            for (int j = 1; j <= ds.Tables[0].Columns.Count-2; j++)
                            {
                                str = str + ds.Tables[0].Rows[i].ItemArray[j].ToString() + ", ";
                            }

                            string str2 = "'" + ds.Tables[0].Rows[i].ItemArray[13].ToString() + "'";

                     
                            MySqlCommand cmd = new MySqlCommand("Insert into " + Global.Eng_PMFileNm + "values(" + str1 + "," + str + "" + str2 + " )", Global.conPM);
                            cmd.ExecuteNonQuery();
                     
                        }
                        Global.conPM.Close();                     
                        MessageBox.Show("Data Transfer Over");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Data ......");
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-15006", ex.Message);
                Global.Create_OnLog(ex.Message + " :  Export Data....", "Alart");  
                this.Close();
            }

        }

        private void MSFG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rw;
                rw = e.RowIndex;
                if (lblDfMatrix.Text == "")
                {
                    lblDfMatrix.Text = lblDfMatrix.Text + " " + MSFG.Rows[rw].Cells[1].Value.ToString();
                }
                else
                {
                    lblDfMatrix.Text =  lblDfMatrix.Text + ", " + MSFG.Rows[rw].Cells[1].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code :-2003", ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //DialogResult result1 = MessageBox.Show("Wait For Engine Running signal ......" + c, "Engine Message", MessageBoxButtons.YesNo);
                DialogResult Responce = MessageBox.Show("Is Engine Test Ok ?  ", "DYNALEC CONTROLS, Pune.", MessageBoxButtons.YesNo);

                switch (Responce)
                {
                    case DialogResult.Yes:
                        Global.ErrorMatrix = "";
                        Global.ErrorMatrix = Global.CStopTm + " " + lblDfMatrix.Text + ",  Test OK";                        
                        break;
                    case DialogResult.No:
                        Global.ErrorMatrix = "";
                        Global.ErrorMatrix = Global.CStopTm + " " + lblDfMatrix.Text + ",  Test NOT OK";                       
                        break;
                }
                Global.CStopTm = DateTime.Now.ToString("hh:mm:ss tt");
                //*************************
                Check_EngDetailsFile();
                fill_Engine_Details(); 
                //***********************
               
                main.Btn21.Enabled = false;
                this.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorCode :- 2002", ex.Message);
            }

        }
        private void fill_Engine_Details()
        {
            try
            {

                String Str = "";
                Global.CStopTm = DateTime.Now.ToString("hh:mm:ss tt");

                for (int x = 0; x <= 24; x++) EngData[x] = null;
                //string  Str = null;
                EngData[0] = Global.Eng_FileNm;
                EngData[1] = Global.EngType;
                EngData[2] = Global.TestRef;
                EngData[3] = Global.FipNo;
                EngData[4] = Global.EngNo;
                EngData[5] = Global.NCyl;
                EngData[6] = Global.Bor;
                EngData[7] = Global.Strk;
                EngData[8] = Global.Svol;

                if (Global.flg_Radiator == true) EngData[9] = "YES"; else EngData[9] = "NO";
                if (Global.flg_Fan == true) EngData[10] = "YES"; else EngData[10] = "NO";
                if (Global.flg_AirCln == true) EngData[11] = "YES"; else EngData[11] = "NO";
                if (Global.flg_Silincer == true) EngData[12] = "YES"; else EngData[12] = "NO";

                EngData[13] = "EDB- 200";
                EngData[14] = Global.OperatorNm;
                EngData[15] = Global.EnginerNm;
                EngData[16] = Global.T_CellNo;
                EngData[17] = Global.CStrtTm;
                EngData[18] = Global.CStopTm;
                if (Global.ErrorMatrix == null) Global.ErrorMatrix = "*******";
                EngData[19] = Global.ErrorMatrix;
                EngData[20] = "*******";
                EngData[21] = "*******";
                EngData[22] = "*******";
                EngData[23] = "*******";
                EngData[24] = "*******";
                Str = "";
                for (int i = 0; i <= 24; i++)
                {
                    if ((EngData[i] == null) || (EngData[i] == ""))
                    {
                        EngData[i] = "****";
                    }
                    Str = Str + EngData[i] + ", ";
                }
                Str = Str + "\n";
                var filePath = Global.DataPath + "Gen_Data\\EngDetails.csv";
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
                Global.Create_OnLog("Engine Details File Created...", "Normal");
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Engine Details File not Created...", "Alart");
                return;
            }
        }
        public void Check_EngDetailsFile()
        {

            if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data\\EngDetails.csv") == false)
            {
                string path = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data\\EngDetails.csv";
                using (StreamWriter sw = File.CreateText(path))
                {
                    String M = "FileName,Engine Type,Test ref,FIP No,Engine No,No of Cylinders,BoreDia,Stroke, Swept Vol,Radiator,Fan,AirCleaner,Silencer,Dynamometer,Operator, Engineer,Test CellNo,C_startTm,C_StopTm,Error Matricx,Spare1,Spare2, Spare3,Spare4,Spare5";
                    var row = new List<string> { M };
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

        //private void Create_Performance()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;

        //    Process[] prs = Process.GetProcesses();
        //    foreach (Process pr in prs)
        //    {
        //        if (pr.ProcessName == "EXCEL") pr.Kill();
        //    }
        //    try
        //    {
        //        String[] Perfno = new String[30];
        //        String[] Perfhead = new String[30];
        //        String[] Perfunit = new String[30];

        //        object misValue = System.Reflection.Missing.Value;
        //        int i, k;
        //        int j, rx;
        //        xlApp = new Excel.ApplicationClass();
        //        xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");
        //        xlWorkSheet.get_Range("B12", "X27").ClearContents(); // .Clear();
        //        xlWorkSheet.get_Range("B31", "M48").ClearContents();
        //        //-------------------------
        //        xlWorkSheet.Cells[3, 20] = DateTime.Now.ToString("dd/MM/yyyy");
        //        xlWorkSheet.Cells[5, 20] = "ECB - 200"; 
        //        xlWorkSheet.Cells[6, 20] = Global.OperatorNm ;
        //        xlWorkSheet.Cells[7, 20] = Global.EnginerNm; 
        //        xlWorkSheet.Cells[8, 20] = Global.T_CellNo;

        //        //-----------------------
        //        xlWorkSheet.Cells[5, 5] = Global.EngType;
        //        xlWorkSheet.Cells[6, 5] = Global.TestRef;
        //        xlWorkSheet.Cells[7, 5] = Global.FipNo;
        //        xlWorkSheet.Cells[8, 5] = Global.EngNo;
        //        ////----------------------------
        //        xlWorkSheet.Cells[5, 11] = Global.NCyl;
        //        xlWorkSheet.Cells[6, 11] = Global.Bor;
        //        xlWorkSheet.Cells[7, 11] = Global.Strk;
        //        xlWorkSheet.Cells[8, 11] = Global.Svol;
        //        //------------------------
        //        if (Global.flg_Radiator == true) xlWorkSheet.Cells[5, 16] = "YES"; else xlWorkSheet.Cells[5, 16] = "NO";
        //        if (Global.flg_Fan == true) xlWorkSheet.Cells[6, 16] = "YES"; else xlWorkSheet.Cells[6, 16] = "NO";
        //        if (Global.flg_AirCln == true) xlWorkSheet.Cells[7, 16] = "YES"; else xlWorkSheet.Cells[7, 16] = "NO";
        //        if (Global.flg_Silincer == true) xlWorkSheet.Cells[8, 16] = "YES"; else xlWorkSheet.Cells[8, 16] = "NO";
        //        ////-------------------------- 

        //        Global.Open_Connection("gen_db", "con");
        //        MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
        //        DataSet ds2 = new DataSet();
        //        adp2.Fill(ds2);
        //        prgT.Visible = true;
        //        prgT.Value = (int)1;
        //        prgT.Caption = "Wait Data For Transfer .......";

        //        k = ds2.Tables[0].Rows.Count;
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //            Perfhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            Perfunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //        }
        //        adp2.Dispose();
        //        ds2.Dispose();
        //        Global.con.Close();
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            xlWorkSheet.Cells[9, 2 + i] = Perfhead[i];
        //            xlWorkSheet.Cells[10, 2 + i] = Perfunit[i];
        //        }

        //        Global.Open_Connection("Data", "conData");
        //        MySqlDataAdapter adp1 = new MySqlDataAdapter("Select * from " + Global.Eng_FileNm + " Order by Pn", Global.conData);
        //        DataSet ds1 = new DataSet();
        //        adp1.Fill(ds1);
        //        rx = ds1.Tables[0].Rows.Count;
        //        if (rx >= 15) rx = 15; 

        //        prgT.Maximum = rx + 1;
        //        prgT.Value = (int)1;
        //        for (int m = 0; m <= rx - 1; m++)
        //        {
        //            prgT.Value = (int)(m + 1);
        //            for (i = 0; i <= k - 1; i++)
        //            {
        //                xlWorkSheet.Cells[m + 11, i + 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[i])].ToString();
        //            }
        //            //****************************************
        //            xlWorkSheet.Cells[m + 31, 2] = ds1.Tables[0].Rows[m].ItemArray[0].ToString();
        //            xlWorkSheet.Cells[m + 31, 3] = ds1.Tables[0].Rows[m].ItemArray[1].ToString();
        //            xlWorkSheet.Cells[m + 31, 4] = ds1.Tables[0].Rows[m].ItemArray[107].ToString();
        //            xlWorkSheet.Cells[m + 31, 5] = ds1.Tables[0].Rows[m].ItemArray[108].ToString();
        //            xlWorkSheet.Cells[m + 31, 6] = ds1.Tables[0].Rows[m].ItemArray[109].ToString();
        //            xlWorkSheet.Cells[m + 31, 7] = ds1.Tables[0].Rows[m].ItemArray[105].ToString();
        //            xlWorkSheet.Cells[m + 31, 8] = ds1.Tables[0].Rows[m].ItemArray[111].ToString();
        //            xlWorkSheet.Cells[m + 31, 9] = ds1.Tables[0].Rows[m].ItemArray[112].ToString();
        //            xlWorkSheet.Cells[m + 31, 10] = ds1.Tables[0].Rows[m].ItemArray[101].ToString();
        //            xlWorkSheet.Cells[m + 31, 11] = ds1.Tables[0].Rows[m].ItemArray[102].ToString();
        //            xlWorkSheet.Cells[m + 31, 12] = ds1.Tables[0].Rows[m].ItemArray[119].ToString();
        //            xlWorkSheet.Cells[m + 31, 13] = ds1.Tables[0].Rows[m].ItemArray[113].ToString();
        //            prgT.Value = m + 1;
        //        }
        //        xlWorkSheet.Cells[33, 17] = Global.CStrtTm;
        //        xlWorkSheet.Cells[35, 17] = Global.CStopTm;

        //        Global.conData.Close();
        //        prgT.Caption = "Data Transfer Over .......";
        //        xlWorkBook.SaveAs((object)(Global.DataPath + "Perf_" + Global.Eng_FileNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

        //        xlApp.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " :  Create Performance....", "Alart");  
        //        //MessageBox.Show("Error Code:- 17007", ex.Message);
        //    }



        //}

        //private void Create_Endurance()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    Process[] prs = Process.GetProcesses();
        //    foreach (Process pr in prs)
        //    {
        //        if (pr.ProcessName == "EXCEL") pr.Kill();
        //    }
        //    try
        //    {
        //        String[] Enduno = new String[30];
        //        String[] Enduhead = new String[30];
        //        String[] Enduunit = new String[30];
        //        string cell1, cell2;
        //        object misValue = System.Reflection.Missing.Value;
        //        int i, k;
        //        int j, rx;
        //        xlApp = new Excel.ApplicationClass();
        //        xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Endurance.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Endurance");
        //        xlWorkSheet.get_Range("B12", "U2000").Clear();
        //        //-------------------------
        //        xlWorkSheet.Cells[2, 19] = DateTime.Now.ToString("dd/MM/yyyy");
        //        xlWorkSheet.Cells[3, 19] = Global.T_CellNo;
        //        //-----------------------
        //        xlWorkSheet.Cells[4, 4] = Global.EngType;
        //        xlWorkSheet.Cells[5, 4] = Global.EngNo;
        //        xlWorkSheet.Cells[6, 4] = Global.Bor;
        //        xlWorkSheet.Cells[7, 4] = Global.Strk;
        //        xlWorkSheet.Cells[8, 4] = Global.NCyl;
        //        xlWorkSheet.Cells[9, 4] = Global.Svol;
        //        //------------------------
        //        xlWorkSheet.Cells[5, 8] = Global.EnginerNm;
        //        xlWorkSheet.Cells[6, 8] = Global.OperatorNm;
        //        xlWorkSheet.Cells[7, 8] = Global.TestRef;
        //        xlWorkSheet.Cells[8, 8] = Global.SGrv;

        //        //-------------------------- 
        //        //------------------------
        //        if (Global.flg_Radiator == true) xlWorkSheet.Cells[5, 12] = "YES"; else xlWorkSheet.Cells[5, 12] = "NO";
        //        if (Global.flg_Fan == true) xlWorkSheet.Cells[6, 12] = "YES"; else xlWorkSheet.Cells[6, 12] = "NO";
        //        if (Global.flg_AirCln == true) xlWorkSheet.Cells[7, 12] = "YES"; else xlWorkSheet.Cells[7, 12] = "NO";
        //        if (Global.flg_Silincer == true) xlWorkSheet.Cells[8, 12] = "YES"; else xlWorkSheet.Cells[8, 12] = "NO";
        //        ////-------------------------- 
        //        //----------------------------------
        //        xlWorkSheet.Cells[5, 16] = Global.CStrtTm;
        //        xlWorkSheet.Cells[6, 16] = Global.CStopTm;

        //        xlWorkSheet.Cells[8, 16] = Global.cumhours;


        //        Global.Open_Connection("gen_db", "con");
        //        MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Endu ", Global.con);
        //        DataSet ds2 = new DataSet();
        //        adp2.Fill(ds2);
        //        prgT.Visible = true;
        //        prgT.Value = (int)1;
        //        prgT.Caption = "Wait Data For Transfer .......";

        //        k = 20;
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            Enduno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //            Enduhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            xlWorkSheet.Cells[10, i + 2] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            Enduunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //            xlWorkSheet.Cells[11, i + 2] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //        }
        //        k = i;
        //        adp2.Dispose();
        //        ds2.Dispose();
        //        Global.con.Close();
        //        Global.Open_Connection("Data", "conData");
        //        MySqlDataAdapter adp1 = new MySqlDataAdapter("Select * from " + Global.Eng_FileNm + " Order by Pn", Global.conData);
        //        DataSet ds1 = new DataSet();
        //        adp1.Fill(ds1);
        //        rx = ds1.Tables[0].Rows.Count;

        //        prgT.Maximum = rx + 1;
        //        prgT.Value = (int)1;
        //        for (int m = 0; m <= rx - 1; m++)
        //        {
        //            prgT.Value = (int)(m + 1);
        //            for (int n = 0; n <= k - 1; n++)
        //            {
        //                xlWorkSheet.Cells[m + 12, n + 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Enduno[n])].ToString();
        //            }
        //            prgT.Value = m;
        //        }
        //        Global.conData.Close();

        //        prgT.Caption = "Data Transfer Over .......";
        //        //cell3 = "B8";
        //        //cell4 = "AB10";
        //        cell1 = "B12";
        //        cell2 = "U" + (rx + 12);
        //        xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
        //        xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
        //        xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Book Antiqua";
        //        xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
        //        xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //        xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
        //        //xlWorkSheet.get_Range(cell3, cell4).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Size = 11;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Bold = false;
        //        //xlWorkSheet.get_Range(cell3, cell4).Borders.ColorIndex = 15;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.ColorIndex = 9;
        //        ////xlWorkSheet.get_Range("B9", "W9").Font.ColorIndex = 5;
        //        //xlWorkSheet.get_Range("B10", "W10").Font.ColorIndex = 1;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Name = "Book Antiqua";
        //        //xlWorkSheet.get_Range(cell3, cell4).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);


        //        xlWorkBook.SaveAs((object)(Global.DataPath + "Endu_" + Global.Eng_FileNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

        //        xlApp.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " :  Create Endurance....", "Alart");  
        //        //MessageBox.Show("Error Code:- 17007", ex.Message);
        //    }

        //}



        

    }
}
