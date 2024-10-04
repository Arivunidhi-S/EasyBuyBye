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

public partial class index : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public DataTable dtRecentitems1 = new DataTable();

    public DataTable dtRecentitems2 = new DataTable();

    public DataTable dtRecentitems3 = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_PreInit(object sender, EventArgs e)
    {
        string strUA = Request.UserAgent.Trim().ToLower();
        bool isMobile = false;
        if (strUA.Contains("ipod") || strUA.Contains("iphone"))
            isMobile = true;

        if (strUA.Contains("android"))
            isMobile = true;

        if (strUA.Contains("opera mobi"))
            isMobile = true;

        if (strUA.Contains("windows phone os") && strUA.Contains("iemobile"))
            isMobile = true;

        if (strUA.Contains("palm"))
            isMobile = true;

        bool MobileDevice = Request.Browser.IsMobileDevice;
        if (isMobile == true && MobileDevice == true)
        {
            Response.Write("<script>window.open('http://m.easybuybye.com','_self');</script>");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = BusinessTier.getConnection();
        //BusinessTier.GetIPLocation(HttpContext.Current.Request.UserHostAddress);       
        try
        {
            con.Open();

            SqlDataReader rdRecentitems = BusinessTier.getFeatureitems(con);
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);

            string HannaRauda = "2368, 2367, 2366, 2369, 2353, 2352, 2351, 2350, 2344, 2343, 2342, 2341, 2322, 2328, 2326, 2327";
            string SKMall = "2613, 2612, 2611, 2610, 2544, 2543, 2542, 2545, 2593, 2592, 2591, 2590, 2576, 2573, 2572, 2575";
            string Molecule = "2244, 2243, 2242, 2241, 2235, 2233, 2231, 2240, 2245, 2236, 2239, 2238";

            //string HannaRauda = "44 , 47";
            //string SKMall = "38, 39 , 40 ,49";
            //string Molecule = "24";

            SqlDataReader rdRecentitems1 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion2"].ToString());
            dtRecentitems1.Load(rdRecentitems1);
            BusinessTier.DisposeReader(rdRecentitems1);

            SqlDataReader rdRecentitems2 = BusinessTier.getitemswithpid(con, HannaRauda.ToString());//BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion3"].ToString());
            dtRecentitems2.Load(rdRecentitems2);
            BusinessTier.DisposeReader(rdRecentitems2);

            SqlDataReader rdRecentitems3 = BusinessTier.getitemswithpid(con, Molecule.ToString());
            dtRecentitems3.Load(rdRecentitems3);
            BusinessTier.DisposeReader(rdRecentitems3);


            //SqlDataReader rdRecentitems1 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion2"].ToString());
            //dtRecentitems1.Load(rdRecentitems1);
            //BusinessTier.DisposeReader(rdRecentitems1);

            //SqlDataReader rdRecentitems2 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion1"].ToString());//BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion3"].ToString());
            //dtRecentitems2.Load(rdRecentitems2);
            //BusinessTier.DisposeReader(rdRecentitems2);

            //SqlDataReader rdRecentitems3 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexMenFashion1"].ToString());
            //dtRecentitems3.Load(rdRecentitems3);
            //BusinessTier.DisposeReader(rdRecentitems3);
            //if (!IsPostBack)
            //{
            //    if (Request.Cookies["CustomerID"].Value.ToString() == "0")
            //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "pgload();", true);
            //}

        }
        catch (Exception ex)
        {
            con.Close();
            //Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }

    //protected void btnRegSave_OnClick(object sender, EventArgs e)
    //{

    //    SqlConnection con = BusinessTier.getConnection();
    //    try
    //    {          
    //        string val = ValidateNull();
    //        if (val == "Y")
    //        {
    //            con.Open();
    //            BusinessTier.NewUser(con, txtName.Text.ToString(), txtEmail.Text.ToString(), "1");
    //            lblmsg.Text = "** Thank you for Subscribe **";
    //            lblmsg.ForeColor = Color.Green;
    //            lblmsg.Attributes.Add("class", "Popuplabel");
    //        }
    //        else
    //        {
    //            lblmsg.Text = val.ToString();
    //            lblmsg.ForeColor = Color.Blue;
    //            lblmsg.Attributes.Add("class", "Popuplabel");
    //        }
    //        if (Request.Cookies["CustomerID"].Value.ToString() == "0")
    //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "pgload();", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        BusinessTier.InsertLogAuditTrial(con, "1", "btnRegSave_OnClick", "index", ex.ToString(), "Audit");
    //    }
    //    finally
    //    {
    //        BusinessTier.DisposeConnection(con);

    //    }
    //}

    //protected void btnclose_Click(object sender, EventArgs e)
    //{
    //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "pgunload();", true);
    //}

    //private string ValidateNull()
    //{
    //    Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
    //    string strRet = "";
    //    if (txtName.Text.ToString().Trim() == string.Empty)
    //        strRet = "** Please Enter Name **";
    //    else if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
    //        strRet = "** Please Enter Email **";
    //    else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
    //        strRet = "** Invalid Email Address **";
    //    else if (BusinessTier.Findnull("BusinessRegister", "Email", "Email", txtEmail.Text.ToString().Trim()) == txtEmail.Text.ToString().Trim())
    //        strRet = "** Email Address Already Exists **";
    //    else if (BusinessTier.Findnull("NewUser", "Email", "Email", txtEmail.Text.ToString().Trim()) == txtEmail.Text.ToString().Trim())
    //        strRet = "** Email Address Already Exists **";
    //    else
    //        strRet = "Y";
    //    return strRet;
    //}
}