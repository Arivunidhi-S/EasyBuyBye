using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;
using System.Net.Mail;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Data.Common;
using System.IO.MemoryMappedFiles;
using System.Web.Configuration;

public partial class ReturnForm : System.Web.UI.Page
{
    public DataTable dtreport = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        string param1 = "";
        param1 = Request.QueryString.Get("param1").ToString();
        string param2 = "";
        param2 = Request.QueryString.Get("param2").ToString();
        string sql = "select InvoiceNo,convert(varchar,ReturnDate, 103) as rndate,OrderNo,Name,Address1,Address2,PostCode,City,State,Country,Mobile,Brand,Model,ReturnReason from Vw_ReturnForm where OrderNo='" + param1.ToString() + "' and RunningNo='" + param2.ToString() + "'";

        SqlCommand cmd = new SqlCommand(sql, connMenu);
        SqlDataReader reader = cmd.ExecuteReader();
        dtreport.Load(reader);
        BusinessTier.DisposeReader(reader);

        BusinessTier.DisposeConnection(connMenu);

        //if (srtParamval2 == "Delivery")
        //{
        //    lbltitle.Text = "DELIVERY REPORT";
        //}
        //else
        //{
        //    lbltitle.Text = "TAX INVOICE";
        //}
    }
}