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

public partial class ExpressBuy : System.Web.UI.Page
{
    public DataTable dtMugavari = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public string path = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string msg = string.Empty, sName = "Arivu", email = "arivu@e-serbadk.com";

        //msg = "<style>.btn {  font-family: arial;  color: #000000 !important;  font-size: 13px;  padding: 10px 25px;  background: #63B8EE;} .btn:hover {  color: #14396A !important;  background: #468CCF;}</style><font face='Cambria Math'><b>Welcome, " + sName.ToString() + " !</b><br><br>" + "Thank you very much for signing up with EasyBuyBye! We have incredible deals waiting for you but before that, please click the button below to validate your email so we know you’re really you.<br><br>";
        //msg = msg + "<div style='width:100%; text-align:center'><b style='background: Yellow;'>UserID : " + email.ToString().Trim() + "</b> <br> <b style='background: Yellow;'>Password : 12345</b><br></div>";
        //msg = msg + "<div style='width:100%; text-align:center'><a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "EmailVerification.aspx?Param=" + email.ToString().Trim() + "><input id='Button1' type='button' value='Click Here to validate your email' /></a><br></div>";
        //msg = msg + "<p>If you need help at any point during your shopping journey with us, please do not hesitate to get in touch immediately. Our most up-to-date contact details are posted on our website. We’re here for you and we’re glad to have you with us. (Don’t forget to validate, ok?).</p>";
        //msg = msg + "<b>Thank you! </b><br> <a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br><b>Team EasyBuyBye</b><br></font>";

    }

    protected void btnAddAddressOnClick(object sender, EventArgs e)
    {
        if (ValidateNull() == "Y")
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            try
            {
                int BusinessID = 0; string CName = string.Empty;
                int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());
                string sql = "SELECT BusinessID from BusinessRegister where DELETED=0 and Email='" + txtEmail.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    BusinessID = Convert.ToInt32(reader["BusinessID"].ToString());
                    // CName = reader["Name"].ToString();
                }
                BusinessTier.DisposeReader(reader);

                if (BusinessID == 0)
                {
                    string msg = string.Empty;

                    msg = "<style>.btn {  font-family: arial;  color: #000000 !important;  font-size: 13px;  padding: 10px 25px;  background: #63B8EE;} .btn:hover {  color: #14396A !important;  background: #468CCF;}</style><font face='Cambria Math'><b>Welcome, " + txtName.Text.ToString() + " !</b><br><br>" + "Thank you very much for signing up with EasyBuyBye! We have incredible deals waiting for you but before that, please click the button below to validate your email so we know you’re really you.<br><br>";
                    msg = msg + "<div style='width:100%; text-align:center'><b style='background: Yellow;'>UserID : " + txtEmail.Text.ToString().Trim() + "</b> <br> <b style='background: Yellow;'>Password : 12345</b><br></div>";
                    msg = msg + "<div style='width:100%; text-align:center'><a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "EmailVerification.aspx?Param=" + txtEmail.Text.ToString().Trim() + "><input id='Button1' type='button' value='Click Here to validate your email' /></a><br></div>";
                    msg = msg + "<p>If you need help at any point during your shopping journey with us, please do not hesitate to get in touch immediately. Our most up-to-date contact details are posted on our website. We’re here for you and we’re glad to have you with us. (Don’t forget to validate, ok?).</p>";
                    msg = msg + "<b>Thank you! </b><br> <a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br><b>Team EasyBuyBye</b><br></font>";
                    BusinessTier.SendMail(txtEmail.Text.ToString(), "Easybuybye Buyer Registration", msg, 1);
                }
                BusinessTier.ExpressBuy(conn, txtName.Text.ToString().Trim(), txtMobile.Text.ToString(), txtEmail.Text.ToString(), txtAddress1.Text.ToString().Trim(), txtAddress2.Text.ToString().Trim(), "", txtPostCode.Text.ToString().Trim(), txtCity.Text.ToString().Trim(), txtState.SelectedItem.Text.ToString().Trim(), txtCountry.SelectedItem.Text.ToString().Trim(), "N");


                string sql2 = "SELECT BusinessID,Name from BusinessRegister where DELETED=0 and Email='" + txtEmail.Text.ToString() + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    BusinessID = Convert.ToInt32(reader2["BusinessID"].ToString());
                    CName = reader2["Name"].ToString();
                }
                BusinessTier.DisposeReader(reader2);


                HttpCookie Name = new HttpCookie("Name");
                Name.Value = CName.ToString();
                Name.Expires = DateTime.Now.AddDays(expire);
                Response.Cookies.Add(Name);

                HttpCookie CustomerID = new HttpCookie("CustomerID");
                CustomerID.Value = BusinessID.ToString();
                CustomerID.Expires = DateTime.Now.AddDays(expire);
                Response.Cookies.Add(CustomerID);

                string vinaval = "update AddCartMaster set deleted = 1 where CustomerID = " + BusinessID + " and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101) and buy=0 and deleted=0";
                SqlCommand katalai = new SqlCommand(vinaval, conn);
                katalai.ExecuteNonQuery();

                string @Param = string.Empty;int pricingid = 0, qty = 1;;
                @Param = Request.QueryString.Get("Param").ToString();
                pricingid= Convert.ToInt32(Request.QueryString.Get("Param1").ToString());

                String Insdate = DateTime.Now.ToString();
                DateTime dtinsDate = DateTime.Parse(Insdate);
                Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
                SqlDataReader rd = BusinessTier.getDuplicate(conn, @Param, BusinessID.ToString(), Insdate.ToString());
                if (rd.Read())
                {
                    int AddcartID = Convert.ToInt32(rd["AddcartID"].ToString());
                    int dtqty = Convert.ToInt32(rd["Qnty"].ToString());
                   
                    BusinessTier.DisposeReader(rd);

                    //int flg = BusinessTier.AddCart(conn, AddcartID, Convert.ToInt32(@Param.ToString().Trim()), BusinessID, pricingid, qty, BusinessID.ToString(), "U");
                }
                else
                {
                    BusinessTier.DisposeReader(rd);
                    //int flg = BusinessTier.AddCart(conn, 1, Convert.ToInt32(@Param.ToString().Trim()), BusinessID, pricingid, qty, BusinessID.ToString(), "N");
                }
                BusinessTier.DisposeConnection(conn);
                Response.Redirect("AddCart.aspx?Param=" + BusinessID.ToString(), false);
            }
            catch (Exception ex)
            {

                BusinessTier.DisposeConnection(conn);
               // Response.Write(ex.ToString());
                InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Address", "btnbuy_OnClick", ex.ToString(), "Audit");
            }
        }
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

    private string ValidateNull()
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        Regex charregex = new Regex(@"[^a-zA-Z0-9\s.]");
        string retval = "";
        if (txtName.Text.ToString().Trim() == "")
            txt(txtName, "Enter Name");
        else if ((charregex.IsMatch(txtName.Text.ToString().Trim())))
            txt(txtName, "Enter Valid Name");
        else if (txtMobile.Text.ToString().Trim() == "")
            txt(txtMobile, "Enter Mobile No");
        else if (txtEmail.Text.ToString().Trim() == "")
            txt(txtEmail, "Enter Email");
        else if (!(emailRegex.IsMatch(txtEmail.Text.ToString().Trim())))
            txt(txtEmail, "Enter Valid Email");
        else if (txtAddress1.Text.ToString().Trim() == string.Empty)
            txt(txtAddress1, "Enter Address Line 1");
        else if (txtPostCode.Text.ToString().Trim() == string.Empty)
            txt(txtPostCode, "Enter PostCode");
        else if (txtCity.Text.ToString().Trim() == string.Empty)
            txt(txtCity, "Enter City");
        else if (txtState.Text.ToString().Trim() == string.Empty)
            ddl(txtState, "Select State");
        else if (txtCountry.Text.ToString().Trim() == string.Empty)
            ddl(txtCountry, "Select Country");
        else
            retval = "Y";
        return retval;

    }

    protected void Clear()
    {
        txtName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress1.Text = string.Empty;
        txtAddress2.Text = string.Empty;
        txtPostCode.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtState.Text = string.Empty;
        txtCountry.Text = string.Empty;
    }

    private void txt(TextBox txtbx, string strRet)
    {
        txtbx.Attributes["placeholder"] = strRet;
        txtbx.CssClass = "form-control1 txtbx";
        txtbx.Focus();
    }

    private void ddl(DropDownList txtbx, string strRet)
    {
        txtbx.Attributes["placeholder"] = strRet;
        txtbx.CssClass = "form-control1 txtbx";
        txtbx.Focus();
    }


}