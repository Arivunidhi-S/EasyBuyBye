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

public partial class AccountInfo : System.Web.UI.Page
{
    public DataTable dtMenuItems = new DataTable();

    public DataTable dtSubMenuItems = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddldate();
            AccountLoad();
            //FillCapctha();
        }
    }

    //void FillCapctha()
    //{
    //    try
    //    {
    //        Random random = new Random();
    //        string combination = "23456789ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
    //        StringBuilder captcha = new StringBuilder();
    //        for (int i = 0; i < 6; i++)
    //            captcha.Append(combination[random.Next(combination.Length)]);
    //        HttpCookie Cpt = new HttpCookie("Cpt");
    //        Cpt.Value = captcha.ToString();
    //        Cpt.Expires = DateTime.Now.AddDays(1);
    //        Response.Cookies.Set(Cpt);
    //        imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
    //    }

    //    catch
    //    {
    //        throw;
    //    }

    //}

    private string ValidateNull()
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        Regex urlRegex = new Regex(@"\b(ht|f)tp(s?)://\S+");
        string strRet = "";
        Regex charregex = new Regex(@"[^a-zA-Z0-9\s]");
        if (txtName.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Valid Name **";
        else if (cboGender.SelectedItem.Text.ToString().Trim() == "Select Gender")
            strRet = "** Please Select Valid Gender **";
        else if ((charregex.IsMatch(txtName.Text.ToString().Trim())))
            strRet = "** Special Characters Are Not Allowed In Name **";
        else if (cboDate.SelectedItem.Text.ToString().Trim() == "Date")
            strRet = "** Please Select Valid Date **";
        else if (cboMonth.SelectedItem.Text.ToString().Trim() == "Month")
            strRet = "** Please Select Valid Month **";
        else if (cboYear.SelectedItem.Text.ToString().Trim() == "Year")
            strRet = "** Please Select Valid Year **";
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            strRet = "** Invalid Email Address **";
        //else if (txtPassword.Text.ToString().Trim() == string.Empty)
        //    strRet = "** Please Enter Valid Password **";
        //else if (txtRetypePassword.Text.ToString().Trim() == string.Empty)
        //    strRet = "** Please Re-Enter The Password **";
        //else if (txtPassword.Text.ToString().Trim() != txtRetypePassword.Text.ToString().Trim())
        //    strRet = "** Please Re-Enter Same Password **";
        else
            strRet = "Y";
        return strRet;
    }

    private void ddldate()
    {

        /****************** For Year ddl Load *****************/

        int year = DateTime.Now.AddYears(0).Year;
        int year1 = DateTime.Now.AddYears(-80).Year;

        BusinessTier.PageLoad_ddlYear(cboYear, year1, year);

        /****************** For Date ddl Load *****************/

        BusinessTier.PageLoad_ddlDate(cboDate);

        /****************** For Date ddl Load *****************/

        BusinessTier.PageLoad_ddlMonth(cboMonth);

    }

    private void AccountLoad() 
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        if (Request.Cookies["CustomerID"].Value.ToString() != "0")
        {
            string sql = "select * from BusinessRegister where DELETED=0 and BusinessID='" + Request.Cookies["CustomerID"].Value.ToString()  + "' ";
            SqlCommand cmd = new SqlCommand(sql, connMenu);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {               
                txtName.Text = reader["Name"].ToString();
                txtICnumber.Text = reader["ICno"].ToString();
                txtContact.Text = reader["Contactno"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                cboGender.Text = reader["Gender"].ToString();
                string line = reader["DOB"].ToString();
                string[] tokens = line.Split(new char[] { '/' }, 3, 0);
                cboDate.SelectedValue = tokens[0].ToString();
                cboMonth.SelectedItem.Text = tokens[1].ToString();
                cboYear.SelectedValue = tokens[2].ToString();
            }
            BusinessTier.DisposeReader(reader);  
        }
        else
        {
            Response.Redirect("https://www.easybuybye.com/Login.aspx", false);
        }
        BusinessTier.DisposeConnection(connMenu);
    }

    protected void btnsumit_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            //string sql = "select * from BusinessRegister where Email ='" + txtEmail.Text.ToString().Trim() + "' and deleted=0";

            //SqlCommand cmd = new SqlCommand(sql, conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    lblStatus.Text = "** Email Address Already Exists Try Another Email **";
            //    //DivInfo.Visible = true;
            //    return;
            //}

            //BusinessTier.DisposeReader(reader);
            string val = ValidateNull();
            if (val == "Y")
            {
                //if (Request.Cookies["Cpt"].Value.ToString().Trim() == txtCaptcha.Text.ToString().Trim())
                //{
                    string dob = cboDate.SelectedItem.Text.ToString() + "/" + cboMonth.SelectedItem.Text.ToString() + "/" + cboYear.SelectedItem.Text.ToString();
                    //int flg = 2;
                    int flg = BusinessTier.BusinessRegister(conn, Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), "", "", txtName.Text.ToString().Trim(), txtICnumber.Text.ToString().Trim(), txtContact.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), "", "", "", "", "", "", "", 0, "", "", "", "", "", "", "", "Malaysia", 0, 006, "Buyer", "", cboGender.Text.ToString(), dob.ToString(), "1", "BU");
                    BusinessTier.DisposeConnection(conn);
                    if (flg >= 1)
                    {


                        lblStatus.Text = "** You have Successfully Modified! **";
                        lblStatus.ForeColor = Color.Green;
                       // DivInsert.Visible = true;
                    }
                //}
                //else
                //{
                //    lblStatus.Text = "** Invalid Captcha Try again **";
                //    FillCapctha();
                //    //DivInfo.Visible = true;
                //}
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
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AccountInfo", "btnsumit_OnClick", ex.ToString(), "Audit");
            BusinessTier.SendMail("arivu@e-serbadk.com", "AccountInfo----btnsumit_OnClick", ex.ToString(), 0);
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    protected void btnChangePassword_OnClick(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        try
        {
            if (txtNewPassword.Text.ToString().Trim() == string.Empty)
            {
                lblStatus2.Text = "** Please Enter New Password **";
                lblStatus2.ForeColor = Color.Red;
                return;
            }
            else if (txtRetypeNewPassword.Text.ToString().Trim() == string.Empty)
            {
                lblStatus2.Text = "** Please re-enter same Password **";
                lblStatus2.ForeColor = Color.Red;
                return;
            }
            else if (txtNewPassword.Text.ToString().Trim() != txtRetypeNewPassword.Text.ToString().Trim())
            {
                lblStatus2.Text = "** Password doesn't match. Please re-enter the Password **";
                lblStatus2.ForeColor = Color.Red;
                return;
            }

            string sql = "update BusinessRegister set Password='" + txtNewPassword.Text.ToString() + "' where BusinessID='" + Request.Cookies["CustomerID"].Value.ToString() + "' and  deleted=0";
            SqlCommand cmd = new SqlCommand(sql, connMenu);
            cmd.ExecuteNonQuery();
            BusinessTier.DisposeConnection(connMenu);
            lblStatus2.Text = "** Successfully Changed **";
            lblStatus2.ForeColor = Color.Green;
        }

        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AccountInfo", "btnChangePassword_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(connMenu);
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