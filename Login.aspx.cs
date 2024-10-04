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

using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;


public partial class Login : System.Web.UI.Page
{
   
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
            Response.Write("<script>window.open('http://m.easybuybye.com/login','_self');</script>");
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        lnkstatus.Visible = false;
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alretmsg()", true);
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "FBLogout", "fbLogout()", true);
        dvmsg.Visible = false;        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string @Param = string.Empty;
        @Param = Request.QueryString.Get("param").ToString();
        if (@Param == "1")
        {
            dvmsg.Visible = true;
        }
        string addcart = Session["AddCart"].ToString();
        if (string.IsNullOrEmpty(addcart))
        {
            Panel2.Visible = false;
           // Response.Redirect("index.aspx", false);
        }
        else
        {
            Panel2.Visible = true;
          //  Response.Redirect("Preview.aspx?Param=" + Session["AddCart"].ToString(), false);
        }
    }

    protected void Alret_click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alretmsg()", true);     
    }

    protected void ExpressBuy_OnClick(object sender, EventArgs e)
    {
        //Response.Redirect("ExpressBuy.aspx", false);
        //Response.Redirect("ExpressBuy.aspx?Param=" + Session["AddCart"].ToString() + "&Param1=" + Session["pricingid"].ToString(), false);
        Response.Redirect("Addcart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString() + "&Param2=" + Request.Cookies["BDID"].Value.ToString().ToString(), false);
    }

    protected void btnSignin_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        try
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string vinaval = "SELECT * from BusinessRegister WHERE Email = '" + txtUserID.Text.ToString() + "' and Password = '" + txtPassword.Text.ToString() + "' and Deleted=0 ";
            SqlCommand katalai = new SqlCommand(vinaval, conn);
            SqlDataReader padipan = katalai.ExecuteReader();
            if (padipan.Read())
            {
                string EmailVerification = padipan["EmailVerification"].ToString();
                lnkstatus.ToolTip = padipan["Name"].ToString();
                if (EmailVerification == "False")
                {
                    BusinessTier.DisposeReader(padipan);
                    lnkstatus.Visible = true;
                    //string patch = "<a style='text-decoration:underline; color:Blue' href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "EmailVerification.aspx?Param=" + txtUserID.Text.ToString().Trim() + "> Click here to resend the validation request to your email address </a>  ** <br>";
                    //lblStatus.Text = "** Validation required." + patch;
                    return;
                }
            }
            BusinessTier.DisposeReader(padipan);

            SqlDataReader reader1 = BusinessTier.VaildateUserLogin(conn, txtUserID.Text.ToString(), txtPassword.Text.ToString(), "", "Customer");
            if (reader1.Read())
            {
                int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());
                string CID = string.Empty;
                HttpCookie Name = new HttpCookie("Name");
                Name.Value = reader1["Name"].ToString();
                Name.Expires = DateTime.Now.AddDays(expire);
                Response.Cookies.Add(Name);

                HttpCookie CustomerID = new HttpCookie("CustomerID");
                CustomerID.Value = reader1["BusinessID"].ToString();
                CID = reader1["BusinessID"].ToString();
                CustomerID.Expires = DateTime.Now.AddDays(expire);
                Response.Cookies.Add(CustomerID);

                String today = DateTime.Now.ToString();
                DateTime dtinsDate = DateTime.Parse(today);
                today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

                BusinessTier.DisposeReader(reader1);
                string sql = "select count(*) as Cart  from AddCartMaster where DELETED=0 and buy=0 and Customerid='" + CustomerID.Value.ToString() + "' and CREATED_DATE='" + today.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    HttpCookie Cart = new HttpCookie("Cart");
                    Cart.Value = reader["Cart"].ToString();
                    CustomerID.Expires = DateTime.Now.AddDays(expire);
                    Response.Cookies.Add(Cart);
                    Session["Cart"] = reader["Cart"].ToString();
                }
                BusinessTier.DisposeReader(reader);
               

                string addcart = Session["AddCart"].ToString();
                if (string.IsNullOrEmpty(addcart))
                {
                    BusinessTier.DisposeConnection(conn);
                    Response.Redirect("index.aspx", false);
                }
                else
                {
                    BusinessTier.AddCart_CustomerID_Update(conn, Request.Cookies["BDID"].Value.ToString().ToString(), CID);
                    BusinessTier.DisposeConnection(conn);
                    Response.Redirect("Addcart.aspx?Param=" + CID.ToString() + "&Param2=" + Request.Cookies["BDID"].Value.ToString().ToString(), false);
                   // Response.Redirect("Preview.aspx?Param=" + Session["AddCart"].ToString(), false);
                }
            }
            else
            {
                lblStatus.Text = "** Login Failed. Invalid Username (or) Password **";
            }
        }
        catch (Exception ex)
        {
            //lblStatus.Text = ex.ToString();
            InsertLogAuditTrail("1", "Login", "btnSignin_OnClick", ex.ToString(), "Audit");
        }
    }

    protected void lnkstatus_OnClick(object sender, EventArgs e) 
    {
        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alerts", "javascript:alert('Successfull email sent!')", true);
        BusinessTier.SendMail(txtUserID.Text.ToString(), "EasyBuyBye Email Validation Request", BusinessTier.GetMsg(lnkstatus.ToolTip.ToString(), txtUserID.Text.ToString()), 1);
        lblStatus.Text = "** Successfully email sent! ** </br>";
        lnkstatus.Visible = false;
        lblStatus.ForeColor = Color.Green;
    }

    //public static void btnGoogleSignin_OnClick( ) 
    //{
    //    try
    //    {
    //        SqlConnection conn = BusinessTier.getConnection();
    //        conn.Open();
    //        SqlDataReader reader1 = BusinessTier.VaildateUserLogin(conn, lblGmail.Text.ToString(), "", "", "Google");
    //        if (reader1.Read())
    //        {
    //            BusinessTier.DisposeReader(reader1);
    //        }
    //        else 
    //        {
    //            BusinessTier.DisposeReader(reader1);
    //        }

    //        int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    //        HttpCookie Name = new HttpCookie("Name");
    //        Name.Value = reader1["Name"].ToString();
    //        Name.Expires = DateTime.Now.AddDays(expire);
    //        Response.Cookies.Add(Name);

    //        HttpCookie CustomerID = new HttpCookie("CustomerID");
    //        CustomerID.Value = reader1["BusinessID"].ToString();
    //        CustomerID.Expires = DateTime.Now.AddDays(expire);
    //        Response.Cookies.Add(CustomerID);

    //        String today = DateTime.Now.ToString();
    //        DateTime dtinsDate = DateTime.Parse(today);
    //        today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

    //        BusinessTier.DisposeReader(reader1);
    //        string sql = "select count(*) as Cart  from AddCartMaster where DELETED=0 and buy=0 and Customerid='" + CustomerID.Value.ToString() + "' and CREATED_DATE='" + today.ToString() + "'";
    //        SqlCommand cmd = new SqlCommand(sql, conn);
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        if (reader.Read())
    //        {
    //            HttpCookie Cart = new HttpCookie("Cart");
    //            Cart.Value = reader["Cart"].ToString();
    //            CustomerID.Expires = DateTime.Now.AddDays(expire);
    //            Response.Cookies.Add(Cart);
    //            Session["Cart"] = reader["Cart"].ToString();
    //        }
    //        BusinessTier.DisposeReader(reader);
    //        BusinessTier.DisposeConnection(conn);
    //        Response.Redirect("index.aspx", false);
    //    }
    //    catch (Exception ex)
    //    {
    //        InsertLogAuditTrail("1", "Login", "btnGoogleSignin_OnClick", ex.ToString(), "Audit");
    //    }
    //}   

    protected void btnForgetPassword_OnClick(object sender, EventArgs e)
    {
        string strLink = "ForgetPassword.aspx?param=b";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(600/2);var Mtop = (screen.height/2)-(300/2);window.open( '" + strLink + "', null, 'width=500,height=200,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenNewTab", "window.open('" + strLink + "','_blank','status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,width=500,height=200');", true);
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }
   
   }