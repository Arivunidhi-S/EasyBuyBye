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

public partial class Address : System.Web.UI.Page
{
    public DataTable dtMugavari = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public string path = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
                      mugavariyeatral();
        }
    }

    public void mugavariyeatral()
    {
        try
        {
            SqlConnection inaippu = BusinessTier.getConnection();
            inaippu.Open();
            string vinaval = "select * FROM MasterAddress WHERE  CREATED_BY='" + Request.Cookies["CustomerID"].Value.ToString() + "' and Deleted=0  and IsFoodAddress=0 order by DefaultAddress desc";
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

    protected void rpAddress_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            SqlConnection inaippu = BusinessTier.getConnection();
            inaippu.Open();
            HiddenField hidAddressID = e.Item.FindControl("hidAddressID") as HiddenField;
            if (e.CommandName == "Select")
            {
                SqlDataReader padipaan = BusinessTier.FindDuplicate(inaippu, "MasterAddress", "AddressId", hidAddressID.Value );
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
                    hdAddressID.Value = padipaan["AddressId"].ToString();
                }
                BusinessTier.DisposeReader(padipaan);
            }
            else if (e.CommandName == "Delete")
            {
                BusinessTier.AddAdress(inaippu, Convert.ToInt32(hidAddressID.Value.ToString().Trim()), "", "", "", "", "", "", "", "", "", "", "", "D");
                Response.Redirect(Request.Url.PathAndQuery, true);
                // lblStatus3.Text = "Successfully Address Delete";               
            }
            else if (e.CommandName == "Default")
            {
                BusinessTier.SetDefaultAddress(inaippu, Convert.ToInt32(hidAddressID.Value), Request.Cookies["CustomerID"].Value.ToString(), "U");
                mugavariyeatral();
            }

            BusinessTier.DisposeConnection(inaippu);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Address", "rpAddress_ItemCommand", ex.ToString(), "Audit");
        }
    }

    protected void rpAddress_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //SqlConnection inaippu = BusinessTier.getConnection();
        //inaippu.Open();
        // Label lblDefault = e.item.FindControl("lblDefault") as Label;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            string Default = (item.FindControl("hdDefault") as HiddenField).Value;
            ImageButton btnAddressID = item.FindControl("btnAddressID") as ImageButton;
            Label lblDefault = item.FindControl("lblDefault") as Label;
            if (Default == "True") { btnAddressID.Visible = false; }//lblDefault.Visible = true;} else { lblDefault.Visible = false; }

        }
    }

    protected void btnAddAddressOnClick(object sender, EventArgs e)
    {
        if (ValidateNull() == "Y")
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            try
            {
                string sql = "select count(*)as counting from MasterAddress where CREATED_BY='" + Request.Cookies["CustomerID"].Value.ToString() + "' and deleted=0";
                int counting = 0;
                string msg = string.Empty;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    counting = Convert.ToInt32(reader["counting"].ToString());
                }
                reader.Close();
                if (hdAddressID.Value == "")
                {
                    if (counting < 5)
                    {
                        BusinessTier.AddAdress(conn, 1, txtName.Text.ToString().Trim(), txtMobile.Text.ToString(), txtEmail.Text.ToString(), txtAddress1.Text.ToString().Trim(), txtAddress2.Text.ToString().Trim(), "", txtPostCode.Text.ToString().Trim(), txtCity.Text.ToString().Trim(), txtState.SelectedItem.Text.ToString().Trim(), txtCountry.SelectedItem.Text.ToString().Trim(), Request.Cookies["CustomerID"].Value.ToString(), "N");
                        //lblStatus.Text = "** Successfully Address Added **";
                        //lblStatus.ForeColor = Color.Green;
                        //DivInsert.Visible = true;
                        Clear();
                        msg = "** Successfully Address Added **";
                    }
                    else
                    {
                        msg = "** You have reached address limit ** ";
                        //lblStatus.Text = "** You have reached address limit ** ";
                        //lblStatus.ForeColor = Color.Red;
                        //DivInfo.Visible = true;
                    }
                }
                else
                {
                    BusinessTier.AddAdress(conn, Convert.ToInt32(hdAddressID.Value.ToString().Trim()), txtName.Text.ToString().Trim(), txtMobile.Text.ToString(), txtEmail.Text.ToString(), txtAddress1.Text.ToString().Trim(), txtAddress2.Text.ToString().Trim(), "", txtPostCode.Text.ToString().Trim(), txtCity.Text.ToString().Trim(), txtState.SelectedItem.Text.ToString().Trim(), txtCountry.SelectedItem.Text.ToString().Trim(), Request.Cookies["CustomerID"].Value.ToString(), "U");
                    msg = "** Successfully Address Modified **";
                    //lblStatus.Text = "** Successfully Address Modified **";
                    //lblStatus.ForeColor = Color.Blue;
                    //DivModify.Visible = true;
                    hdAddressID.Value = "";
                    Clear();
                   // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('** Successfully Address Modified **');", true);
                    
                }
                //mugavariyeatral();
                //this.DataBind();
                //Response.Redirect(Request.Url.PathAndQuery, true);
                BusinessTier.DisposeConnection(conn);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "FuncAlrt('" + msg.ToString() + "')", true);
            }
            catch (Exception ex)
            {

                BusinessTier.DisposeConnection(conn);
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