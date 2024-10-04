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

public partial class Addcart : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public DataTable dtFeatureitems = new DataTable();

    public DataTable dtGridVal = new DataTable();

    public DataTable dtMugavari = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public string path = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            gridload();
            mugavariyeatral();
        }
        SqlConnection con = BusinessTier.getConnection();
        try
        {
            con.Open();
            SqlDataReader rdFeatureitems = BusinessTier.getFeatureitems(con);
            dtFeatureitems.Load(rdFeatureitems);
            BusinessTier.DisposeReader(rdFeatureitems);
        }
        catch (Exception ex)
        {
            Response.Redirect("index.aspx", false);
        }
        finally
        {
            BusinessTier.DisposeConnection(con);
        }
    }

    public void gridload()
    {
        try
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string @Param = string.Empty, @Param2 = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            @Param2 = Request.QueryString.Get("Param2").ToString();
            String today = DateTime.Now.ToString();
            DateTime dtinsDate = DateTime.Parse(today);
            today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

            String week = DateTime.Now.AddDays(-7).ToString();
            DateTime dtweekDate = DateTime.Parse(week);
            week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";
            string sql = string.Empty;
            if (@Param != "0")
            {
               // BusinessTier.AddCart_CustomerID_Update(conn, @Param2, @Param);
                 sql = "select *, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg, DiscountPrice*qnty as totprice FROM Vw_AddCart WHERE Deleted=0 and buy=0 and IsCOD=0 and Customerid='" + @Param + "' and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
            }
            else 
            {
                Panel1.Visible = false;
                sql = "select *, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg, DiscountPrice*qnty as totprice FROM Vw_AddCart WHERE Deleted=0 and buy=0 and IsCOD=0 and BDID='" + @Param2 + "' and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dtGridVal);
            if (dtGridVal.Rows.Count == 0)
            {
                btnBye.Visible = false;
            }
            rpCheckout.DataSource = dtGridVal;
            rpCheckout.DataBind();
            BusinessTier.DisposeAdapter(sqlDataAdapter);
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AddCart", "gridload", ex.ToString(), "Audit");
        }
    }

    public void mugavariyeatral()
    {
        try
        {
            SqlConnection inaippu = BusinessTier.getConnection();
            inaippu.Open();
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            string vinaval = "select * FROM MasterAddress WHERE Deleted=0 and CREATED_BY='" + @Param + "' and IsFoodAddress=0 order by DefaultAddress desc";
            SqlDataAdapter sqlPori = new SqlDataAdapter(vinaval, inaippu);
            sqlPori.Fill(dtMugavari);
            rpAddress.DataSource = dtMugavari;
            rpAddress.DataBind();
            BusinessTier.DisposeAdapter(sqlPori);
            BusinessTier.DisposeConnection(inaippu);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AddCart", "mugavariyeatral", ex.ToString(), "Audit");
        }
    }

    //protected void rpCheckout_ItemCommand(object sender, RepeaterCommandEventArgs e)
    //{
    //    try
    //    {
    //        TextBox txtval = e.Item.FindControl("txtval") as TextBox;
    //        if (txtval.Text == string.Empty)
    //        {
    //            txtval.Text = "1";
    //        }
    //        string val = txtval.Text;
    //        int i = Convert.ToInt32(val);
    //        if (e.CommandName == "minus")
    //        {
    //            if (i > 1)
    //                i -= 1;
    //            txtval.Text = i.ToString();
    //            QtyUpdate("U1", Convert.ToInt32(hdAddcartID.Value));
    //        }
    //        else if (e.CommandName == "plus")
    //        {
    //            string stck = BusinessTier.FindStock(hdProductID.Value, Request.Cookies["CustomerID"].Value.ToString());
    //            if (Convert.ToInt32(stck.ToString()) > i)
    //            {
    //                i += 1;
    //                txtval.Text = i.ToString();
    //            }
    //            else
    //            {
    //                txtval.Text = stck.ToString();
    //            }
    //            QtyUpdate("U1", Convert.ToInt32(hdAddcartID.Value));
    //        }
    //        //else if (e.CommandName == "Delete")
    //        //{
    //        //    QtyUpdate("D");
    //        //}
    //        Response.Redirect(Request.Url.PathAndQuery, true);
    //    }
    //    catch (Exception ex)
    //    {
    //        InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AddCart", "rpCheckout_ItemCommand", ex.ToString(), "Audit");
    //    }
    //}

    protected void btnminus_Onclick(object sender, EventArgs e)
    {
       
        try
        {
            LinkButton btn = (LinkButton)sender;
            LinkButton lbminus = btn.FindControl("lbminus") as LinkButton;
            TextBox txtval = btn.FindControl("txtval") as TextBox;
            HiddenField hdAddcartID = btn.FindControl("hdAddcartID") as HiddenField;
            HiddenField hdProductID = btn.FindControl("hdProductID") as HiddenField;
            string stck = BusinessTier.FindStock(hdProductID.Value, Request.Cookies["CustomerID"].Value.ToString());
            string val = txtval.Text;
            int i = Convert.ToInt32(val);
            if (txtval.Text == string.Empty)
            {
                txtval.Text = "1";
            }

            if (i > 1)
                i -= 1;
            txtval.Text = i.ToString();
            QtyUpdate("U1", Convert.ToInt32(hdAddcartID.Value), Convert.ToInt32(txtval.Text));
            Response.Redirect(Request.Url.PathAndQuery, true);

        }
        catch (Exception ex)
        {

        }

    }

    protected void btnplus_Onclick(object sender, EventArgs e)
    {
       
        try
        {
            LinkButton btn = (LinkButton)sender;
            LinkButton lbplus = btn.FindControl("lbplus") as LinkButton;
            TextBox txtval = btn.FindControl("txtval") as TextBox;
            HiddenField hdAddcartID = btn.FindControl("hdAddcartID") as HiddenField;
            HiddenField hdProductID = btn.FindControl("hdProductID") as HiddenField;
            string val = txtval.Text;
            int i = Convert.ToInt32(val);
            string stck = BusinessTier.FindStock(hdProductID.Value, Request.Cookies["CustomerID"].Value.ToString());

            if (Convert.ToInt32(stck.ToString()) > i)
            {
                i += 1;
                txtval.Text = i.ToString();
            }
            else
            {
                txtval.Text = stck.ToString();
            }
            QtyUpdate("U1", Convert.ToInt32(hdAddcartID.Value),Convert.ToInt32(txtval.Text));
            Response.Redirect(Request.Url.PathAndQuery, true);

        }
        catch (Exception ex)
        {

        }

    }

    protected void rpAddress_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            SqlConnection inaippu = BusinessTier.getConnection();
            inaippu.Open();
            HiddenField hidAddressID = e.Item.FindControl("hidAddressID") as HiddenField;
            if (e.CommandName == "Select")
            {
                SqlDataReader padipaan = BusinessTier.FindDuplicate(inaippu, "MasterAddress", "AddressId", hidAddressID.Value);
                if (padipaan.Read())
                {
                    txtName.Text = (padipaan["Name"].ToString());
                    txtMobile.Text = (padipaan["Mobile"].ToString());
                    txtEmail.Text = (padipaan["Email"].ToString());
                    txtAddress1.Text = (padipaan["Address1"].ToString());
                    txtAddress2.Text = (padipaan["Address2"].ToString());
                    txtPostCode.Text = (padipaan["Postcode"].ToString());
                    txtCity.Text = (padipaan["City"].ToString());
                    txtState.Text = (padipaan["State"].ToString());
                    txtCountry.Text = (padipaan["Country"].ToString());
                    txtAddress1.ToolTip = (padipaan["AddressId"].ToString());
                }
                BusinessTier.DisposeReader(padipaan);
                //BusinessTier.SetDefaultAddress(inaippu, Convert.ToInt32(hidAddressID.Value), Request.Cookies["CustomerID"].Value.ToString(), "U");
            }
            BusinessTier.DisposeConnection(inaippu);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AddCart", "rpAddress_ItemCommand", ex.ToString(), "Audit");
        }
    }

    protected void rpAddress_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SqlConnection inaippu = BusinessTier.getConnection();
        inaippu.Open();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            string AddressID = (item.FindControl("hidAddressID") as HiddenField).Value;
            Button btnAddressID = item.FindControl("btnAddressID") as Button;
        }
    }

    protected void btnbuy_OnClick(object sender, EventArgs e)
    {
        if (ValidateNull() == "Y")
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            try
            {
                int BusinessID = 0; 
                if (Request.Cookies["CustomerID"].Value.ToString() != "0")
                {
                    BusinessID = Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString());
                    String Insdate = DateTime.Now.ToString();
                    DateTime dtinsDate = DateTime.Parse(Insdate);
                    Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

                    String week = DateTime.Now.AddDays(-7).ToString();
                    DateTime dtweekDate = DateTime.Parse(week);
                    week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

                    int cnt = BusinessTier.totCount("select count(*) as totCount from Vw_AddCart where DELETED=0 and buy=0 and CategoryID in(" + WebConfigurationManager.AppSettings["CategoryID"].ToString() + ") and Customerid='" + Request.Cookies["CustomerID"].Value.ToString().Trim() + "' and CREATED_DATE between '" + week.ToString() + "' and '" + Insdate.ToString() + "'");
                    // string sql = "select count(*) as totCount from Vw_AddCart where DELETED=0 and buy=0 and CategoryID in(" + WebConfigurationManager.AppSettings["CategoryID"].ToString() + ") and Customerid='" + Request.Cookies["CustomerID"].Value.ToString().Trim() + "' and CREATED_DATE='" + Insdate.ToString() + "'";
                    int cnt2 = BusinessTier.totCount("select count(*) as totCount from Vw_AddCart where DELETED=0 and buy=0 and Customerid='" + Request.Cookies["CustomerID"].Value.ToString().Trim() + "' and CREATED_DATE between '" + week.ToString() + "' and '" + Insdate.ToString() + "'");
                    if (cnt != cnt2 && cnt != 0)
                    {
                        lblStatus.Text = "** Grocery/Packed foods cannot be order with other item **";
                        lblStatus.ForeColor = Color.Red;
                        return;
                    }

                    int cnt1 = BusinessTier.totCount("select sum(qnty) as totCount from Vw_AddCart where DELETED=0 and buy=0 and CategoryID =" + WebConfigurationManager.AppSettings["CategoryID2"].ToString() + " and Customerid='" + Request.Cookies["CustomerID"].Value.ToString().Trim() + "' and CREATED_DATE between '" + week.ToString() + "' and '" + Insdate.ToString() + "'");
                    if (cnt1 < 5 && cnt1 != 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "FuncAlrt('** Minimum order 5 pax for Asian Taste Packed Food **')", true);
                        lblStatus.Text = "** Minimum order 5 pax for Asian Taste Packed Food **";
                        lblStatus.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    string CName = string.Empty;
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

                    BusinessTier.AddCart_CustomerID_Update(conn, Request.Cookies["BDID"].Value.ToString().ToString(), BusinessID.ToString());
                }

                BusinessTier.InsertShippingAddress(conn, 1, txtName.Text.ToString().Trim(), txtMobile.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtAddress1.Text.ToString().Trim(), txtAddress2.Text.ToString().Trim(), "", txtPostCode.Text.ToString().Trim(), txtCity.Text.ToString().Trim(), txtState.Text.ToString().Trim(), txtCountry.Text.ToString().Trim(), BusinessID.ToString(), "", "", "", 0, 0, BusinessID.ToString(), "N");
                string shipingid = BusinessTier.MaxID(conn, "ShippingAddress", "ShippingID", BusinessID.ToString());
                Response.Redirect("ShippingAddress.aspx?Param=" + shipingid.ToString(), false);
                BusinessTier.DisposeConnection(conn);
            }
            catch (Exception ex)
            {
                BusinessTier.DisposeConnection(conn);
                InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "AddCart", "btnbuy_OnClick", ex.ToString(), "Audit");
            }
        }
    }

    protected void btnDelete_Onclick(object sender, EventArgs e)
    {

        try
        {
            ImageButton btn = (ImageButton)sender;
            ImageButton btnDelete = btn.FindControl("Imgbtn_Delete") as ImageButton;
            HiddenField hdAddcartID = btn.FindControl("hdAddcartID") as HiddenField;
            //int flg = 0;
            QtyUpdate("D", Convert.ToInt32(hdAddcartID.Value),0);

            Response.Redirect(Request.Url.PathAndQuery, true);
        }
        catch (Exception ex)
        {

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

    private void QtyUpdate(string Condition, int id, int qty)
    {
        SqlConnection inaippu = BusinessTier.getConnection();
        inaippu.Open();
        BusinessTier.AddCart(inaippu, id, 1, 1, 1, qty, Request.Cookies["CustomerID"].Value.ToString().Trim(), Request.Cookies["BDID"].Value.ToString().Trim(), Condition);
        BusinessTier.DisposeConnection(inaippu);
    }
}