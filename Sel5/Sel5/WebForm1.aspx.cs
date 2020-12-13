using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sel5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        program prog = new program();
        ExcelData exceldata = new ExcelData();

        protected void Page_Load(object sender, EventArgs e)
        {
           exceldata.ExcelSheetData();
            
            //prog.Execute();
            //prog.ExecuteKsrtcApp();
        }
    }
}