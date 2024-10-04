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
using System.Net.Mail;
using System.Text;

public partial class Signup : System.Web.UI.Page
{
    public DataTable dtMenuItems = new DataTable();

    public DataTable dtSubMenuItems = new DataTable();

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
            Response.Write("<script>window.open('https://www.m.easybuybye.com/register','_self');</script>");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            txtEmail.Attributes.Add("autocomplete", "off");
            txtPassword.Attributes.Add("autocomplete", "off");  
            
            //ddldate();
            FillCapctha();
        }
        if (IsPostBack)
        {
            if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
            {
                txtPassword.Attributes["value"] = txtPassword.Text;
                txtRetypePassword.Attributes["value"] = txtRetypePassword.Text;
            }
        }

        SqlConnection con = BusinessTier.getConnection();
        string customerid = "";       
        try
        {
            if (Request.Cookies["CustomerID"].Value.ToString() != "0")
            {
                customerid = Request.Cookies["CustomerID"].Value.ToString();
                string name = BusinessTier.GetFixedLengthString(Request.Cookies["Name"].Value.ToString(), 10);
                lblName.Text = (name.PadRight(12, '.')) + "'s Account";
                lblLog.Text = "Logout";
            }
            else
            {
                lblName.Text = "My Account";
                lblLog.Text = "Login";
                customerid = "";
            }
            con.Open();
            SqlDataReader readerMenulist = BusinessTier.getMenuList1(con);
            dtMenuItems.Load(readerMenulist);
            BusinessTier.DisposeReader(readerMenulist);
           
        }
        catch (Exception ex)
        {
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "0";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);

            HttpCookie Cart = new HttpCookie("Cart");
            Cart.Value = "";
            Cart.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Set(CustomerID);
            Response.Cookies.Set(Name);
            Response.Cookies.Set(Cart);

            Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }

    void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "23456789ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
            captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            //HttpCookie Cpt = new HttpCookie("Cpt");
            //Cpt.Value = captcha.ToString();
            //Cpt.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Set(Cpt);
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }

        catch
        {
            throw;
        }

    }

    private string ValidateNull()
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        Regex urlRegex = new Regex(@"\b(ht|f)tp(s?)://\S+");
        string strRet = "";
        Regex charregex = new Regex(@"[^a-zA-Z0-9\s]");
        if (txtName.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Valid Name **";
        else if ((charregex.IsMatch(txtName.Text.ToString().Trim())))
            strRet = "** Special Characters are Not Allowed in Name **";
        //else if (cboGender.SelectedItem.Text.ToString().Trim() == "Select Gender")
        //    strRet = "** Please Select Valid Gender **";        
        //else if (cboDate.SelectedItem.Text.ToString().Trim() == "Date")
        //    strRet = "** Please Select Valid Date **";
        //else if (cboMonth.SelectedItem.Text.ToString().Trim() == "Month")
        //    strRet = "** Please Select Valid Month **";
        //else if (cboYear.SelectedItem.Text.ToString().Trim() == "Year")
            //strRet = "** Please Select Valid Year **";
        else if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
            strRet = "** Please Enter Email **";
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            strRet = "** Invalid Email Address **";
        else if (txtPassword.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Password **";
        else if (txtRetypePassword.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Retype Password **";
        else if (txtPassword.Text.ToString().Trim() != txtRetypePassword.Text.ToString().Trim())
            strRet = "** Please Re-Enter Same Password **";
        else
            strRet = "Y";
        return strRet;
    }

    //private void ddldate()
    //{

    //    /****************** For Year ddl Load *****************/

    //    int year = DateTime.Now.AddYears(0).Year;
    //    int year1 = DateTime.Now.AddYears(-80).Year;

    //    BusinessTier.PageLoad_ddlYear(cboYear, year1, year);

    //    /****************** For Date ddl Load *****************/

    //    BusinessTier.PageLoad_ddlDate(cboDate);

    //    /****************** For Date ddl Load *****************/

    //    BusinessTier.PageLoad_ddlMonth(cboMonth);

    //}

    protected void btnsumit_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
          
            string val = ValidateNull();
            if (val == "Y")
            {
                string sql = "select * from BusinessRegister where Email ='" + txtEmail.Text.ToString().Trim() + "' and deleted=0";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblStatus.Text = "** Email Address Already Exists Try Another Email **";
                    //DivInfo.Visible = true;
                    return;
                }

                BusinessTier.DisposeReader(reader);

                if (Session["captcha"].ToString().Trim() == txtCaptcha.Text.ToString().Trim())
                {
                    //string dob = cboDate.Text.ToString() + "/" + cboMonth.Text.ToString() + "/" + cboYear.Text.ToString();
                    string dob = "01/Jan/1900";
                    //int flg = 2;
                    int flg = BusinessTier.BusinessRegister(conn, 1, "", "", txtName.Text.ToString().Trim(), "", txtContact.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), "", txtPassword.Text.ToString().Trim(), "", "", "", "", "", 0, "", "", "", "", "", "", "", "Malaysia", 0, 006, "Buyer", "", "", dob.ToString(), "1", "N");
                    BusinessTier.DisposeConnection(conn);
                    if (flg >= 1)
                    {
                        //<h4>PROMO CODE<br>#easyfirst</h4> 

                        BusinessTier.SendMail(txtEmail.Text.ToString(), "Welcome to EasyBuyBye!", BusinessTier.GetMsg(txtName.Text.ToString(), txtEmail.Text.ToString()), 1);

                        lblStatus.Text = "** You have Successfully Registered! Please go to your registered email address and click the given link **";
                        lblStatus.ForeColor = Color.Green;
                       // DivInsert.Visible = true;
                        FillCapctha();
                        Response.Redirect("SignupSuccess.aspx", false);
                    }
                }
                else
                {
                    lblStatus.Text = "** Invalid Captcha Try again **";
                    lblStatus.ForeColor = Color.Red;

                    //FillCapctha();
                    //DivInfo.Visible = true;
                }
            }
            else
            {
                lblStatus.Text = val.ToString();
                lblStatus.ForeColor = Color.Blue;
                //DivInfo.Visible = true;

            }
            BusinessTier.DisposeConnection(conn);
           
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Signup", "btnsumit_OnClick", ex.ToString(), "Audit");
            BusinessTier.SendMail("arivu@e-serbadk.com", "Signup----btnsumit_OnClick", ex.ToString(), 0);
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        if (lblLog.Text == "Logout")
        {
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "0";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);

            HttpCookie Cart = new HttpCookie("Cart");
            Cart.Value = "";
            Cart.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Set(CustomerID);
            Response.Cookies.Set(Name);
            Response.Cookies.Set(Cart);

            Response.Redirect("index.aspx", false);
        }
        else
        {
            Response.Redirect("Login.aspx?param=0", false);
        }
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }
}