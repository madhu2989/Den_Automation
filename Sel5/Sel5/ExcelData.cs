using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Sel5
{


    public class ExcelData
    {
        string Con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\NewExcel.xlsx;Extended Properties='Excel 12.0 Macro;HDR=Yes';";
        program prog = new program();



        public void ExcelSheetData()
        {
            using (OleDbConnection connection = new OleDbConnection(Con))
            {
                connection.Open();
                DataSet excel = new DataSet();

                string query = string.Format("select * from [Sheet1$]");


                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(excel);


                //var excelApp = new Application();
                ////excelApp.Visible = true;

                //Excel.Workbooks wb = excelApp.Workbooks; ;
                //Excel.Workbook sheet = wb.Open(@"D:\NewExcel.xlsx");


                ////Login to Den
                prog.DenLogin();

                List<string> list = new List<string>();

                foreach (DataRow dr in excel.Tables[0].Rows)
                {
                    list.Add(Convert.ToString(dr["CardNumber"]));
                }


                //var duplicates = list.Where(item => !myhash.Add(item)).ToList().Distinct().ToList();
                List<string> listDistinct = list.Distinct().ToList();

                int countDistinctList = listDistinct.Count();
                int i = 0;

                for (i = 0; i <= countDistinctList - 1; i++)
                {

                    string number = listDistinct[i].ToString();
                    if(number=="")
                    {
                        continue;
                    }
                    else
                    {
                        string FinalNum = number.Replace(" ", string.Empty);
                        prog.ViewCustomer(FinalNum);
                        Console.WriteLine(i);
                    }
                   
                    Thread.Sleep(2000);
                }

                //prog.LogoutDen();
                connection.Close();

                //return excel;
            }
        }



    }
}