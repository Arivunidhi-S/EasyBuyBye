using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;


public partial class MenuControls : System.Web.UI.UserControl
{
    public DataTable dtBasicCategory = new DataTable();

    public DataTable dtSubCategory = new DataTable();

    public DataTable dtCategory = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = BusinessTier.getConnection();
        con.Open();
        try
        {
            SqlDataReader Menulist = BusinessTier.getBasicCategory(con);
            dtBasicCategory.Load(Menulist);
            BusinessTier.DisposeReader(Menulist);
            con.Close();
        }
        finally
        {
            BusinessTier.DisposeConnection(con);
        }
    }
}