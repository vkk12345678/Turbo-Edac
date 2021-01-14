using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;





namespace Editor
{
    internal class Common
    {
        public static string PATH = Application.StartupPath + "\\";
        public static MySqlConnection con = new MySqlConnection();
        public static MySqlConnection conLim = new MySqlConnection();
        public static MySqlConnection conSeq = new MySqlConnection();
        public static MySqlConnection conData = new MySqlConnection();
        public static MySqlConnection conMES = new MySqlConnection();
        public static MySqlConnection conLog = new MySqlConnection();
        public static string DataPath;
      
        public static void Open_Connection(String db, String conNm)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);    //dcpl

                conn.Open();

                if (conNm == "con")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        con = conn;
                    }
                }
                if (conNm == "conLim")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conLim.Close();
                        conLim = conn;
                    }
                }
                if (conNm == "conSeq")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conSeq.Close();
                        conSeq = conn;
                    }
                }
                if (conNm == "conMES")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conMES.Close();
                        conMES = conn;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15008", ex.Message);
            }

        }
        public static void FormatCombo(ComboBox cmb)
        {
            cmb.Text = cmb.Text.Replace(".", "");
            cmb.Text = cmb.Text.Replace("!", "");
            cmb.Text = cmb.Text.Replace("'", "");
            cmb.Text = cmb.Text.Replace("[", "");
            cmb.Text = cmb.Text.Replace("]", "");
            cmb.Text = cmb.Text.Replace("'", "");
            cmb.Text = cmb.Text.Replace("-", "");
            cmb.Text = cmb.Text.Replace("$", "");
            cmb.Text = cmb.Text.Replace(" ", "");
            cmb.Text = cmb.Text.Replace("#", "");
            cmb.Text = cmb.Text.Replace("*", "");
            cmb.Text = cmb.Text.Replace("&", "");
            cmb.Text = cmb.Text.Replace("@", "");
            cmb.Text = cmb.Text.Replace("+", "");
            cmb.Text = cmb.Text.Replace("(", "");
            cmb.Text = cmb.Text.Replace(")", "");
            cmb.Text = cmb.Text.Replace("%", "");
            cmb.Text = cmb.Text.Replace("=", "");
            cmb.Text = cmb.Text.Replace("^", "");
            cmb.Text = cmb.Text.Replace("?", "");
            cmb.Text = cmb.Text.Replace(",", "");
            cmb.Text = cmb.Text.Replace("{", "");
            cmb.Text = cmb.Text.Replace("}", "");
            cmb.Text = cmb.Text.Replace("~", "");
            cmb.Text = cmb.Text.Replace("`", "");

        }

        public static void Create_OnLog(String Str, String Msg)//,int Icon)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                String OnLog_Editor = "OnLogEditor_" + DateTime.Now.ToString("ddMMMyy");

                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data");
                }
                if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Editor + ".txt") == false)
                {
                    System.IO.File.Create("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Editor + ".txt");
                }

                Global.I_Tm = System.DateTime.Now.ToString("hh:mm:ss tt");
                String strData = Global.I_Tm + " ,     " + Str + " ,          " + Msg;

                String filePath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Editor + ".txt";
                using (StreamWriter sw = File.AppendText(filePath))
                    sw.WriteLine(strData); ;
            }
            catch (Exception ex)
            {
                return;
                //Global.Global.Create_OnLog("Alart",ex.Message + " :  Load In Cell....", false);  
                //MessageBox.Show("Error Code:- 15007", ex.Message);
            }

        }

        public static void Read_SqlTable(string TbNm, string ColNm, string flNm)
        {
            for (int i = 0; i <= 199; i++) Global.arr[i] = null; 
            Common.Open_Connection("gen_db", "con");
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + TbNm + " where " + ColNm + " = '" + flNm +  "'", Common.con);
            MySqlDataReader Rd = cmd.ExecuteReader();


            Int16 x = 0;
            while (Rd.Read())
            {
                for (x = 0; x <= (Rd.FieldCount - 1); x++)
                {
                   Global.arr[x] = Rd.GetValue(x).ToString();                  
                }
            }
            cmd.Dispose();
            Common.con.Close();
        }
        public static void Del_SqlTable(string TbNm, string flNm)
        {
            MySqlCommand cDelete = new MySqlCommand();
            cDelete.CommandText = "DELETE FROM " + TbNm + " where FileName = '" + flNm +  "'";
            Common.Open_Connection("gen_db", "con");
            cDelete.Connection = Common.con;
            cDelete.ExecuteNonQuery();
        }

    }
}
