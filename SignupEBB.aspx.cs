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

public partial class SignupEBB : System.Web.UI.Page
{
    public DataTable dtMenuItems = new DataTable();

    public DataTable dtSubMenuItems = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ddldate();         
        //}
        SqlConnection con = BusinessTier.getConnection();
        string customerid = "";
        lblcart.Text = Request.Cookies["Cart"].Value.ToString();
        try
        {
            if (!(string.IsNullOrEmpty(Request.Cookies["CustomerID"].Value.ToString())))
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
            CustomerID.Value = "";
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

 

    private string ValidateNull()
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        Regex urlRegex = new Regex(@"\b(ht|f)tp(s?)://\S+");
        string strRet = "";
        Regex charregex = new Regex(@"[^a-zA-Z0-9\s]");
        if (txtName.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Valid Name **";
        //else if (cboGender.SelectedItem.Text.ToString().Trim() == "Select Gender")
        //    strRet = "** Please Select Valid Gender **";
        else if ((charregex.IsMatch(txtName.Text.ToString().Trim())))
            strRet = "** Special Characters Are Not Allowed In Name **";
        //else if (cboDate.SelectedItem.Text.ToString().Trim() == "Date")
        //    strRet = "** Please Select Valid Date **";
        //else if (cboMonth.SelectedItem.Text.ToString().Trim() == "Month")
        //    strRet = "** Please Select Valid Month **";
        //else if (cboYear.SelectedItem.Text.ToString().Trim() == "Year")
        //    strRet = "** Please Select Valid Year **";
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            strRet = "** Invalid Email Address **";
        else if (txtPassword.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Valid Password **";
        //else if (txtRetypePassword.Text.ToString().Trim() == string.Empty)
        //    strRet = "** Please Re-Enter The Password **";
        //else if (txtPassword.Text.ToString().Trim() != txtRetypePassword.Text.ToString().Trim())
        //    strRet = "** Please Re-Enter Same Password **";
        else
            strRet = "Y";
        return strRet;
    }  

    protected void btnsumit_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
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
            string val = ValidateNull();
            if (val == "Y")
            {
                string dob = string.Empty;// cboDate.Text.ToString() + "/" + cboMonth.Text.ToString() + "/" + cboYear.Text.ToString();
                    //int flg = 2;
                    int flg = BusinessTier.BusinessRegister(conn, 1, "", "", txtName.Text.ToString().Trim(), "", txtContact.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), "", txtPassword.Text.ToString().Trim(), "", "", "", "", "", 0, "", "", "", "", "", "", "", "Malaysia", 0, 006, "Buyer", "", "", dob.ToString(), "1", "N");
                    BusinessTier.DisposeConnection(conn);
                    if (flg >= 1)
                    {
                        string msg = string.Empty;
                        msg = "<font face='Cambria Math'>Dear " + txtName.Text.ToString() + ",<br><br>" + "You have Successfully Register with EasyBuyBye.<a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "EmailVerification.aspx?Param=" + txtEmail.Text.ToString().Trim() + ">Click Here</a> to validate your email and login.";
                        msg = msg + "<h4>Your Login Details:</h4> Username: <span style='background-color: #ffff42'>" + txtEmail.Text.ToString() + "</span><br> Password: <span style='background-color: #ffff42'>" + txtPassword.Text.ToString() + "</span><br><br>";
                        msg = msg + "Enjoy your Shopping at EasyBuyBye !!! <br><br> Thank you <br><br>  <b>Admin </b><br> <a href='https://easybuybye.com' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br>Malaysia<br></font>";

                        BusinessTier.SendMail(txtEmail.Text.ToString(), "Easybuybye Buyer Registration", msg, 1);

                        lblStatus.Text = "** You have Successfully Registered! Please go to your registered email address and click the given link **";
                        lblStatus.ForeColor = Color.Green;
                       // DivInsert.Visible = true;
                    }
                }                
            
            else
            {
                lblStatus.Text = val.ToString();
                //DivInfo.Visible = true;

            }
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "CustomerMaster", "btnAddCategory_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    protected void btnShopCart_Click(object sender, EventArgs e)
    {
        if (lblcart.Text != "0")
        {
            Response.Redirect("Addcart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString(), false);
        }
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        if (lblLog.Text == "Logout")
        {
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "";
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
            Response.Redirect("Login.aspx", false);
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