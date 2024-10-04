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

public partial class MenuControl_SearchBox : System.Web.UI.UserControl
{
    public void Page_Load(object sender, EventArgs e)
    {
       
    }
    //[System.Web.Services.WebMethod]

    //public List<string> GetbrandName(string BrandName)
    //{
    //    List<string> empResult = new List<string>();
    //    using (SqlConnection con = BusinessTier.getConnection())
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.CommandText = "select distinct(brand) from MasterProducts where brand LIKE ''+@SearchbrandName+'%'";
    //            cmd.Connection = con;
    //            con.Open();
    //            cmd.Parameters.AddWithValue("@SearchbrandName", BrandName);
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                empResult.Add(dr["brand"].ToString());
    //            }
    //            con.Close();
    //            return empResult;
    //        }
    //    }
    //}
    public void btnSearch_OnClick(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            Response.Redirect("Search.aspx?Param=" + txtSearch.Text.ToString(), false);
        }
    }
}