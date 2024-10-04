using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

using System.Globalization;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;
using System.Drawing;

using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI.Calendar;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Net.Sockets;

public partial class SellatEBB : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            //txtName.ToolTip = BusinessTier.SellerID(conn);

            if (!IsPostBack)
            {
                FillCapctha();
            }
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            BusinessTier.DisposeConnection(conn);
            Response.Redirect("index.aspx", false);
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

            //HttpCookie Cpt = new HttpCookie("Cpt");
            //Cpt.Value = captcha.ToString(); 
            //Cpt.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Set(Cpt);

            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }

    protected void btnBusinessRegister_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            
            string val = ValidateNull();
            if (val == "Y")
            {
                if (chktc.Checked == false)
                {
                    lblStatus.Text = "** Please Check Terms & Conditions **";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Session["captcha"].ToString().Trim() == txtCaptcha.Text.ToString().Trim())
                {
                    string sql = "select * from SellerRegister where Email ='" + txtEmail.Text.ToString().Trim() + "' and deleted=0";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Text = "** Email Address Already Exists Try Another Email **";
                        return;
                    }

                    BusinessTier.DisposeReader(reader);

                    String path = string.Empty, path1 = string.Empty, DocFilePath1 = string.Empty, DocFilePath2 = string.Empty, DocFilePath3 = string.Empty, DocFilePath4 = string.Empty, DocFilePath5 = string.Empty, DocFilePath6 = string.Empty;
                    if (txtPostcode.Text.ToString().Trim() == string.Empty)
                        txtPostcode.Text = "0";

                    int flg = BusinessTier.SellerRegister(conn, 1, "", "", txtName.Text.ToString().Trim(), txtICnumber.Text.ToString().Trim(), txtContact.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtAddress.Text.ToString().Trim(), txtPassword.Text.ToString().Trim(), "", "", "", "", "0", 1, DocFilePath1.ToString(), DocFilePath2.ToString(), DocFilePath3.ToString(), DocFilePath4.ToString(), DocFilePath5.ToString(), DocFilePath6.ToString(), txtState.Text.ToString().Trim(), "Malaysia", Convert.ToInt32(txtPostcode.Text.ToString().Trim()), 006, ddlRegistrationType.SelectedItem.Value.ToString(), "", "", "", txtAboutProduct.Text.ToString(), "", "", txtPromoCode.Text.ToString(), txtCity.Text.ToString(), "1", "N");
                    if (flg >= 1)
                    {
                        string msg = string.Empty;

                        msg = "<font face='Cambria Math'>Dear " + txtName.Text.ToString() + ",<br><br>" + "You have successfully registering as seller with EasyBuyBye.<a href=" + ConfigurationManager.AppSettings["PagePath"].ToString() + "EmailVerification.aspx?Param=" + txtEmail.Text.ToString().Trim() + ">Click Here</a> to validate your email and login.";
                        msg = msg + "<h4>Your Login Details:</h4> Username: <span style='background-color: #ffff42'>" + txtEmail.Text.ToString() + "</span><br> Password: <span style='background-color: #ffff42'>" + txtPassword.Text.ToString() + "</span><br><br>";
                        msg = msg + "Enjoy your Shopping at EasyBuyBye !!! <br><br> Thank you <br><br>  <b>Admin </b><br> <a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br>Malaysia<br></font>";
                        BusinessTier.SendMail(txtEmail.Text.ToString(), "Business Seller Register Confirmation", msg, 1);
                        lblStatus.Text = "** You have Successfully Register! **";
                        lblStatus.ForeColor = Color.Green;                       
                        txtName.ToolTip = BusinessTier.SellerID(conn);
                    }
                    BusinessTier.DisposeConnection(conn);
                    Clear();
                    FillCapctha();
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "** Wrong Captcha Please Try again **";
                    //FillCapctha();
                }
            }
            else
            {
                lblStatus.Text = val.ToString();               
                lblStatus.ForeColor = Color.Blue;
            }
           
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail("1", "btnBusinessRegister_OnClick", "SellatEBB", ex.ToString(), "Audit");
            //lblStatus.Text = "** Invalid Captcha Please Try again **";
            lblStatus.Text = "";
            BusinessTier.SendMail("arivu@e-serbadk.com", "SellatEBB----btnBusinessRegister_OnClick", ex.ToString(), 0);
            //lblStatus.Text = ex.Message.ToString();
            //DivInfo.Visible = true;
            lblStatus.ForeColor = Color.Blue;
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    private string ValidateNull()
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        string strRet = "";
        if (txtName.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Contact Name **";
        else if (txtICnumber.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter IC No/Passport Number **";
        else if (txtContact.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Mobile Number **";
        else if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
            strRet = "** Please Enter Email **";
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            strRet = "** Invalid Email Address **";
        else if (ddlRegistrationType.SelectedItem.Text.ToString().Trim() == "Select Registration Type")
            strRet = "** Please Choose Any Registration Type **";      
        else if (string.IsNullOrEmpty(txtPassword.Text.ToString()))
            strRet = "** Please Enter Password **";
        else if (txtRetypePassword.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Retype Password **";
        else if (txtPassword.Text.ToString().Trim() != txtRetypePassword.Text.ToString().Trim())
            strRet = "** Please Re-Enter Same Password **";
        else
            strRet = "Y";
        return strRet;
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

    void Clear()
    {
        BusinessTier.Clear(txtName);
        BusinessTier.Clear(txtICnumber);
        BusinessTier.Clear(txtContact);
        BusinessTier.Clear(txtEmail);
        BusinessTier.Clear(txtAddress);
        //BusinessTier.Clear(txtState);
        BusinessTier.Clear(txtPostcode);
        BusinessTier.Clear(txtPassword);
        BusinessTier.Clear(txtRetypePassword);
        BusinessTier.Clear(txtAboutProduct);     
        BusinessTier.Clear(txtCaptcha);
        BusinessTier.Clear(txtPromoCode);
    }

}