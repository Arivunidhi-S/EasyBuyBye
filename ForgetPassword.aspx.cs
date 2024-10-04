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

public partial class ForgetPassword : System.Web.UI.Page
{
    string @Param = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            @Param = Request.QueryString.Get("param").ToString();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnChangePassword_OnClick(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        try
        {
            if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
            {
                lblStatus.Text = "Please enter your email id";
                lblStatus.ForeColor = Color.Red;
                return;
            }
            else
            {
                Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
                {
                    lblStatus.Text = "** Email id format is worng **";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                //string sql = "select * from BusinessRegister where Email ='" + txtEmail.Text.ToString().Trim() + "' and deleted=0";
              
                //SqlCommand cmd = new SqlCommand(sql, connMenu);
                string tablename=string.Empty;
                if(@Param == "b"){tablename="BusinessRegister";}else{tablename="SellerRegister";}


                SqlDataReader reader = BusinessTier.FindDublicate(connMenu, tablename, "Email", txtEmail.Text.ToString().Trim());
                if (reader.Read())
                {
                    string Name = reader["name"].ToString();
                    string SysReg = reader["SysRegno"].ToString();
                    string id = reader.GetValue(0).ToString();

                    string msg = string.Empty;
                    if (@Param == "b")
                    {
                        msg = "Dear " + Name.ToString() + ",<br><br>" + "Do you want to change your password <a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "ChangePassword.aspx?Param1=f&Param=" + txtEmail.Text.ToString().Trim() + ">Click Here</a><br><br> Thank you <br><br> EasyBuyBye Admin Team<br>Malaysia<br><br> http://www.easybuybye.com";
                    }
                    else
                    {
                        msg = "<font face='Cambria Math'>Dear " + Name.ToString() + ",<br><br>" + "Do you want to change your password <a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "ChangePassword.aspx?Param1=b&Param=" + id.ToString().Trim() + ">Click Here</a><br><br>Thanks & Regards<br><table border='0' bordercolor='#b4b1b4' style='border: 0px solid; border-collapse: collapse;'><tr><td> <b>Admin Team</b><br></td></tr><tr><td><a href='http://easybuybye.com' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br>Malaysia</td></tr></table></font>";
                    }
                    BusinessTier.SendMail(txtEmail.Text.ToString(), "EasyBuyBye Change Password", msg, 2);

                    lblStatus.Text = "** Please go to your registered email address and click the given link **";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "** Sorry your email id doesn't exists **";
                    lblStatus.ForeColor = Color.Red;
                }
                BusinessTier.DisposeReader(reader);
                BusinessTier.DisposeConnection(connMenu);
            }
            //Response.Redirect("login.aspx", false);
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.ToString();
            //Response.Redirect("index.aspx");
        }
        finally
        {
            BusinessTier.DisposeConnection(connMenu);
        }
    }
}