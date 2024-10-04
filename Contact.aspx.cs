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

public partial class Contact : System.Web.UI.Page
{
    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCapctha();
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
        if (txtContactName.Text.ToString().Trim() == string.Empty)
            strRet = "** Please Enter Valid Name **";
        else if ((charregex.IsMatch(txtContactName.Text.ToString().Trim())))
            strRet = "** Special Characters Are Not Allowed In Name **";
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            strRet = "Email ID Format is Worng";
        else if (txtSubject.Text.Contains("sex") == true || txtSubject.Text.Contains("SEX") == true || txtSubject.Text.Contains("sEX") == true || txtSubject.Text.Contains("seX") == true || txtSubject.Text.Contains("Sex") == true || txtSubject.Text.Contains("sEx") == true)
            strRet = "** Unwanted entry in Subject **";
        else if (txtMessage.Text.Contains("sex") == true || txtMessage.Text.Contains("SEX") == true || txtMessage.Text.Contains("sEX") == true || txtMessage.Text.Contains("seX") == true || txtMessage.Text.Contains("Sex") == true || txtMessage.Text.Contains("sEx") == true)
            strRet = "** Unwanted entry in Message **";
        else if ((urlRegex.IsMatch(txtMessage.Text.ToString().Trim())))
            strRet = "** You Can't Type or Paste URL in Message**";
        else if ((charregex.IsMatch(txtMessage.Text.ToString().Trim())))
            strRet = "** Special Characters Are Not Allowed In Message **";      
        else
            strRet = "Y";
        return strRet;
    }

    protected void btnsumit_OnClick(object sender, EventArgs e)
    {
        try
        {
            string val = ValidateNull();
            if (val == "Y")
            {
                if (Session["captcha"].ToString().Trim() == txtCaptcha.Text.ToString().Trim())
                {
                    string Subject = "From EasyBuyBye Contact Us Page";
                    string strbody = string.Empty;

                    strbody = "<table border='0' width='100%'><tr><td><table border='1' width='100%'>";
                    strbody = strbody + "<tr><td style='width: 70px'>Name : </td> <td> <b>" + txtContactName.Text.ToString() + "</b> </td></tr>";
                    strbody = strbody + "<tr><td>Email : </td> <td> " + txtEmail.Text.ToString() + " </td></tr>";
                    strbody = strbody + "<tr><td>Subject : </td> <td> <i>" + txtSubject.Text.ToString() + " </i></td></tr>";
                    strbody = strbody + "<tr><td  style='vertical-align:top;'>Message : </td> <td> " + txtMessage.Text.ToString() + " </td></tr></table></td></tr></table>";
                    BusinessTier.SendMail(txtEmail.Text, Subject, strbody, 1);

                    lblStatus.Text = "** Your Message is Successfully Sent! Thanks for Contact Us **";
                    lblStatus.ForeColor = Color.Green;                   

                    txtContactName.Text = "";
                    txtEmail.Text = "";
                    txtSubject.Text = "";
                    txtMessage.Text = "";
                    txtCaptcha.Text = "";
                    FillCapctha();
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "** Invalid Captcha Try Again **";
                    FillCapctha();
                }
            }
            else
            {
                lblStatus.Text = val.ToString();
                lblStatus.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            //lblStatus.Text = ex.ToString();
            lblStatus.Text = "** Sorry Your Mail Cannot Be Send! Please Contact Customer Care **";
        }
    }

    
}