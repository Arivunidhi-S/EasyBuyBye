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
using System.Security.Cryptography;

public partial class ShippingAddress : System.Web.UI.Page
{
    public string CustomerID = string.Empty, Name = string.Empty, Mobile = string.Empty, Email = string.Empty, Address1 = string.Empty, Address2 = string.Empty, PostCode = string.Empty, City = string.Empty, State = string.Empty, Country = string.Empty, Amount = string.Empty;

    public string breakamount = "0";

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public string path = string.Empty;

    public string @Param = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        @Param = Request.QueryString.Get("Param").ToString();
        if (!IsPostBack)
        {
            cartload();
            COD();
            hdAgentID.Value = "0";
            hdPromotionID.Value = "0";
        }
    }

    public void cartload()
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();       
        
        string vinaval = "select * from ShippingAddress where DELETED=0 and ShippingID='" + @Param.ToString() + "'";
        SqlCommand katalai = new SqlCommand(vinaval, connMenu);
        SqlDataReader padipaan = katalai.ExecuteReader();
        if (padipaan.Read())
        {
            CustomerID = padipaan["CustomerID"].ToString();
            Name = padipaan["Name"].ToString();
            Mobile = padipaan["Mobile"].ToString();
            Email = padipaan["Email"].ToString();
            Address1 = padipaan["Address1"].ToString();
            Address2 = padipaan["Address2"].ToString();
            PostCode = padipaan["PostCode"].ToString();
            City = padipaan["City"].ToString();
            State = padipaan["State"].ToString().TrimEnd();
            Country = padipaan["Country"].ToString();

        }
        BusinessTier.DisposeReader(padipaan);

        String today = DateTime.Now.ToString();
        DateTime dtinsDate = DateTime.Parse(today);
        today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

        String week = DateTime.Now.AddDays(-7).ToString();
        DateTime dtweekDate = DateTime.Parse(week);
        week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

        //string sql = "select count(*) as Cart, sum(DiscountPrice*Qnty) as Total, sum(ShippingCost*Qnty) as ShipCost from Vw_AddCart where DELETED=0 and buy=0 and Customerid='" + Request.Cookies["CustomerID"].Value.ToString() + "' and CREATED_DATE between '" + week.ToString() + "' and '" + today.ToString() + "'";
        string sql = "select count(*) as Cart, sum(DiscountPrice*Qnty) as Total, sum(ShippingCost*Qnty) as ShipCost from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0 and ShippingID='" + @Param.ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, connMenu);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            //lblcart.Text = reader["Cart"].ToString();
            Session["Cart"] = reader["Cart"].ToString();
            lblSubTotal.Text = reader["Total"].ToString();
            Session["Total"] = reader["Total"].ToString();
        }
        BusinessTier.DisposeReader(reader);

        //string sql1 = "select sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=0 and Customerid='" + Request.Cookies["CustomerID"].Value.ToString() + "' and CREATED_DATE between '" + week.ToString() + "' and '" + today.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID";
        string sql1 = "select sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=0 and IsCOD=0  and ShippingID='" + @Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID";
        SqlCommand cmd1 = new SqlCommand(sql1, connMenu);
        SqlDataReader reader1 = cmd1.ExecuteReader();
        decimal shipcst = 0, aryshipcst = 0;
        while (reader1.Read())
        {
            decimal cmpwgt = 0 , cst = 0, addcst = 0;

            if (State == "WP Labuan" || State == "Sabah" || State == "Sarawak")
            { 
                cmpwgt = 1000;
                cst = Convert.ToDecimal(reader1["ShipCost2"].ToString());
                addcst = Convert.ToDecimal(reader1["ShipCost2Next"].ToString());
            }
            else 
            {
                cmpwgt = 1000;
                cst = Convert.ToDecimal(reader1["ShipCost"].ToString());
                addcst = Convert.ToDecimal(reader1["ShipCostNext"].ToString());
            }

            if (!(string.IsNullOrEmpty(reader1["totweight"].ToString())))
            {
                decimal compweight = Convert.ToDecimal(reader1["totweight"].ToString());
                if (compweight <= cmpwgt)
                {
                    shipcst = cst;
                }
                else
                {
                    decimal weight = Math.Ceiling(compweight / cmpwgt);

                    decimal shipcost = cst + (addcst * (Convert.ToInt32(weight) - 1));
                    shipcst = shipcost;
                }
            }
            else
            {
                shipcst = 0;
            }
            aryshipcst = aryshipcst + shipcst;
            string test = aryshipcst.ToString();
        }
        lblShippingCost.Text = aryshipcst.ToString("0.00");
        Session["ShipCost"] = lblShippingCost.Text;
        lblGtotal.Text = "Grand Total :";
        lblTotal.Text = Math.Round((Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text)), 2).ToString("#0.00");
        lblGrandTotal.Text = Math.Round((Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text)), 2).ToString("#0.00");

        BusinessTier.DisposeReader(reader1);

        BusinessTier.DisposeConnection(connMenu);
    }

    public void COD()
    {
        String Insdate = DateTime.Now.ToString();
        DateTime dtinsDate = DateTime.Parse(Insdate);
        Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

        String week = DateTime.Now.AddDays(-7).ToString();
        DateTime dtweekDate = DateTime.Parse(week);
        week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

        int cnt1 = BusinessTier.totCount("select count(*) as totCount from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0  and ShippingID='" + @Param.ToString() + "'");
        int cnt2 = BusinessTier.totCount("select count(*) as totCount from Vw_AddCart where CategoryID=" + WebConfigurationManager.AppSettings["CategoryID2"].ToString() + " and DELETED=0 and buy=0 and IsCOD=0 and ShippingID='" + @Param.ToString() + "'");
        if (cnt1 == cnt2)
        {
            divCOD.Visible = true;
        }
        else
        {
            divCOD.Visible = false;
        }
    }

    //private void BulkCopy()
    //{
    //    String Insdate = DateTime.Now.ToString();
    //    DateTime dtinsDate = DateTime.Parse(Insdate);
    //    Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

    //    SqlConnection con = BusinessTier.getConnection();
    //    con.Open();
    //    string sql = "select OrderNo, 'EBBAT' + CAST(OrderNo AS VARCHAR(255))  as invoiceno, getdate() as paymentdate,productid, Brand+' '+Model as Description,Qnty,DiscountPrice, Qnty*DiscountPrice as Amount, 0 as GST,13 as Distributor, convert(varchar, getdate(), 12) + CAST(AddcartID AS VARCHAR(255)) as DeliveryNo,CREATED_BY, 'For Asian Taste Food' as Remarks  from Vw_AddCart where DELETED=0 and buy=0 and BasicCategoryID=13 and Customerid='" + Request.Cookies["CustomerID"].Value.ToString().Trim() + "' and CREATED_DATE='" + Insdate.ToString() + "'";

    //    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
    //    DataTable Table = new DataTable();
    //    adapter.Fill(Table);
    //    SqlBulkCopy bc = new SqlBulkCopy(con);
    //    bc.DestinationTableName = "ManualSalesEntry";

    //    bc.ColumnMappings.Add("OrderNo", "orderno");
    //    bc.ColumnMappings.Add("invoiceno", "invoiceno");
    //    bc.ColumnMappings.Add("paymentdate", "paymentdate");
    //    bc.ColumnMappings.Add("productid", "productid");
    //    bc.ColumnMappings.Add("Description", "Description");
    //    bc.ColumnMappings.Add("Qnty", "Qnty");
    //    bc.ColumnMappings.Add("DiscountPrice", "UnitPrice");
    //    bc.ColumnMappings.Add("Amount", "TotalAmount");
    //    bc.ColumnMappings.Add("Amount", "Amount");
    //    bc.ColumnMappings.Add("GST", "GST");
    //    bc.ColumnMappings.Add("Remarks", "Remarks");
    //    bc.ColumnMappings.Add("paymentdate", "BankingDate");
    //    bc.ColumnMappings.Add("GST", "Customer");
    //    bc.ColumnMappings.Add("Distributor", "Distributor");
    //    bc.ColumnMappings.Add("DeliveryNo", "DeliveryNo");
    //    bc.ColumnMappings.Add("CREATED_BY", "CREATED_BY");
    //    bc.ColumnMappings.Add("paymentdate", "CREATED_DATE");
    //    bc.WriteToServer(Table);
    //    bc.Close();
    //    ////rdr.Close();
    //    con.Close();
    //}

    //protected void btnCOD_OnClick(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BulkCopy();
    //        //lblStatus.Text = "** Successfully Inserted **";
    //        //lblStatus.ForeColor = Color.Green;
    //        Response.Redirect("COD.aspx", false);
    //    }
    //    catch (Exception ex)
    //    {
    //        InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ShippingAddress", "btnCOD_OnClick", ex.ToString(), "Audit");
    //        lblStatus.Text = ex.Message.ToString();
    //        lblStatus.ForeColor = Color.Red;
    //    }

    //}

    protected void btnCOD_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();

            BusinessTier.InsertShippingAddress(conn, Convert.ToInt32(@Param), "", "", "", "", "", "", "", "", "", "", "", hdPromotionID.Value.ToString(), lblGrandTotal.Text.ToString(), lblpromotion.ToolTip.ToString(), Convert.ToInt32(hdAgentID.Value.ToString()),Convert.ToDecimal(lblShippingCost.Text.ToString()),Request.Cookies["CustomerID"].Value.ToString().Trim(), "U");
            /// ************ For Select All Product Description in Vw_AddCart   ************ ///

            String Insdate = DateTime.Now.ToString();
            DateTime dtinsDate = DateTime.Parse(Insdate);
            Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

            String week = DateTime.Now.AddDays(-7).ToString();
            DateTime dtweekDate = DateTime.Parse(week);
            week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

            int orderid = 0, shippingid = 0, i = 0;
            shippingid = Convert.ToInt32(@Param);
            string[] Brand = new string[20];
            string ProdDesc = string.Empty;
            string sql2 = "SELECT Brand from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0 and ShippingID='" + @Param.ToString() + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Brand[i] = reader2["Brand"].ToString();
                ProdDesc = ProdDesc.ToString().Trim() + " " + Brand[i].ToString();
                i = i + 1;
            }
            BusinessTier.DisposeReader(reader2);

            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For get orderno from AddCartMaster Table  ************ ///

            string sql = "SELECT distinct(orderno) as orderid from AddCartMaster where DELETED=0 and buy=0 and ShippingID='" + @Param.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                orderid = Convert.ToInt32(reader["orderid"].ToString());
            }
            BusinessTier.DisposeReader(reader);

            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For Insert BankStatement Table ************ ///

            string amount = lblGrandTotal.Text.ToString();
            var MerchantCode = ConfigurationManager.AppSettings["MerchantId"].ToString(CultureInfo.InvariantCulture);
            var verifyKey = ConfigurationManager.AppSettings["VerifyKey"].ToString(CultureInfo.InvariantCulture);
            var Signature = GetVCode(verifyKey.ToString() + MerchantCode.ToString() + orderid.ToString() + amount.Replace(".", string.Empty) + "MYR");
            BusinessTier.BankStatement(conn, shippingid.ToString(), MerchantCode.ToString(), orderid.ToString(), lblStatus.ToolTip.ToString(), "MYR", ProdDesc.ToString(), Name.ToString(), Email.ToString(), Mobile.ToString(), "", Signature.ToString(), Request.Cookies["CustomerID"].Value.ToString().Trim(), "N");

            BusinessTier.DisposeConnection(conn);


            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For ipay88 Transaction ************ ///

            var ResponseURL = "OrderConfirmation.aspx?param1=" + shippingid.ToString();
            var BackendURL = ConfigurationManager.AppSettings["ImagePath"].ToString() + "BackEndProcess.aspx?param1=" + shippingid.ToString();

            Response.Write("<form name='ebb' id='ebb' action='" + ResponseURL + "' method='post' >");

            Response.Write("<input type=hidden name='MerchantCode' value='" + MerchantCode + "'>");
            Response.Write("<input type=hidden name='PaymentId' value='0'>");
            Response.Write("<input type=hidden name='RefNo' value='" + orderid.ToString() + "'>");
            Response.Write("<input type=hidden name='Amount' value=" + amount.ToString() + ">");
            Response.Write("<input type=hidden name='Currency' value='MYR'>");
            //Response.Write("<input type=hidden name='Remark' value='" + ProdDesc.ToString() + "'>");
            //Response.Write("<input type=hidden name='UserName' value='" + Name.ToString() + "'>");
            //Response.Write("<input type=hidden name='UserEmail' value='" + Email.ToString() + "'>");
            //Response.Write("<input type=hidden name='UserContact' value='" + Mobile.ToString() + "'>");
            Response.Write("<input type=hidden name='Remark' value='EBBAT'>");
            Response.Write("<input type=hidden name='TransId' value='EBBAT" + orderid.ToString() + "'>");
            Response.Write("<input type=hidden name='AuthCode' value=''>");
            Response.Write("<input type=hidden name='Status' value='1'>");
            Response.Write("<input type=hidden name='ErrDesc' value=''>");
            Response.Write("<input type=hidden name='Signature' value='" + Signature + "'>");

            Response.Write("</form>");
            Response.Write("<script>ebb.submit();</script>");

        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ShippingAddress", "btnBuy_OnClick", ex.ToString(), "Audit");
            lblStatus.Text = ex.Message.ToString();
            lblStatus.ForeColor = Color.Red;
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    protected void btnBuy_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();

            BusinessTier.InsertShippingAddress(conn, Convert.ToInt32(@Param), "", "", "", "", "", "", "", "", "", "", "", hdPromotionID.Value.ToString(), lblGrandTotal.Text.ToString(), lblpromotion.ToolTip.ToString(), Convert.ToInt32(hdAgentID.Value.ToString()), Convert.ToDecimal(lblShippingCost.Text.ToString()), Request.Cookies["CustomerID"].Value.ToString().Trim(), "U");
            /// ************ For Select All Product Description in Vw_AddCart   ************ ///

            String Insdate = DateTime.Now.ToString();
            DateTime dtinsDate = DateTime.Parse(Insdate);
            Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

            String week = DateTime.Now.AddDays(-7).ToString();
            DateTime dtweekDate = DateTime.Parse(week);
            week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

            int orderid = 0, shippingid = 0, i = 0;
            shippingid = Convert.ToInt32(@Param);
            string[] Brand = new string[20];
            string ProdDesc = string.Empty;
            string sql2 = "SELECT Brand from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0 and ShippingID='" + @Param.ToString() + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Brand[i] = reader2["Brand"].ToString();
                ProdDesc = ProdDesc.ToString().Trim() + " " + Brand[i].ToString();
                i = i + 1;
            }
            BusinessTier.DisposeReader(reader2);

            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For get orderno from AddCartMaster Table  ************ ///

            string sql = "SELECT distinct(orderno) as orderid from AddCartMaster where DELETED=0 and buy=0 and ShippingID='" + @Param.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                orderid = Convert.ToInt32(reader["orderid"].ToString());
            }
            BusinessTier.DisposeReader(reader);

            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For Insert BankStatement Table ************ ///

            string amount = lblGrandTotal.Text.ToString();
            var MerchantCode = ConfigurationManager.AppSettings["MerchantId"].ToString(CultureInfo.InvariantCulture);
            var verifyKey = ConfigurationManager.AppSettings["VerifyKey"].ToString(CultureInfo.InvariantCulture);
            var Signature = GetVCode(verifyKey.ToString() + MerchantCode.ToString() + orderid.ToString() + amount.Replace(".", string.Empty) + "MYR");
            BusinessTier.BankStatement(conn, shippingid.ToString(), MerchantCode.ToString(), orderid.ToString(), lblStatus.ToolTip.ToString(), "MYR", ProdDesc.ToString(), Name.ToString(), Email.ToString(), Mobile.ToString(), "", Signature.ToString(), Request.Cookies["CustomerID"].Value.ToString().Trim(), "N");

            BusinessTier.DisposeConnection(conn);


            /// ************ ************ ************ ************ ************ ************ ///

            /// ************ For ipay88 Transaction ************ ///

            var ResponseURL = ConfigurationManager.AppSettings["ImagePath"].ToString() + "ipay88Return.aspx?param1=" + shippingid.ToString();
            var BackendURL = ConfigurationManager.AppSettings["ImagePath"].ToString() + "BackEndProcess.aspx?param1=" + shippingid.ToString();

            Response.Write("<form name='ebb' id='ebb' action='https://payment.ipay88.com.my/epayment/entry.asp' method='post' >");

            Response.Write("<input type=hidden name='MerchantCode' value='" + MerchantCode + "'>");
            Response.Write("<input type=hidden name='PaymentId' value=''>");
            Response.Write("<input type=hidden name='RefNo' value='" + orderid.ToString() + "'>");
            Response.Write("<input type=hidden name='Amount' value=" + amount.ToString() + ">");
            Response.Write("<input type=hidden name='Currency' value='MYR'>");
            Response.Write("<input type=hidden name='ProdDesc' value='" + ProdDesc.ToString() + "'>");
            Response.Write("<input type=hidden name='UserName' value='" + Name.ToString() + "'>");
            Response.Write("<input type=hidden name='UserEmail' value='" + Email.ToString() + "'>");
            Response.Write("<input type=hidden name='UserContact' value='" + Mobile.ToString() + "'>");
            Response.Write("<input type=hidden name='Remark' value='EBB'>");
            Response.Write("<input type=hidden name='Lang' value='UTF-8'>");
            Response.Write("<input type=hidden name='Signature' value='" + Signature + "'>");
            Response.Write("<input type=hidden name='ResponseURL' value='" + ResponseURL.ToString() + "'>");
            Response.Write("<input type=hidden name='BackendURL' value='" + BackendURL.ToString() + "'>");
            Response.Write("</form>");
            Response.Write("<script>ebb.submit();</script>");

        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ShippingAddress", "btnBuy_OnClick", ex.ToString(), "Audit");
            lblStatus.Text = ex.Message.ToString();
            lblStatus.ForeColor = Color.Red;
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    private string GetVCode(string input)
    {
        SHA1CryptoServiceProvider objSHA1 = new SHA1CryptoServiceProvider();
        objSHA1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        byte[] buffer = objSHA1.Hash;
        string HashValue = System.Convert.ToBase64String(buffer);
        return HashValue;

    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            string fdt = string.Empty, tdt = string.Empty, bcatid = string.Empty, Usage = string.Empty;
            decimal protot = 0;
            DateTime FromDate = DateTime.Now, ToDate = DateTime.Now, TodayDate = DateTime.Now;
            SqlDataReader rdDuplicates = BusinessTier.FindDuplicate(conn, "PromotionMaster", "PromotionCode", txtPCode.Text.ToString());
            if (rdDuplicates.Read())
            {
                hdPromotionID.Value = rdDuplicates["Promotionid"].ToString();
                FromDate = Convert.ToDateTime(rdDuplicates["FromDate"].ToString());
                ToDate = Convert.ToDateTime(rdDuplicates["ToDate"].ToString());
                protot = Convert.ToDecimal(rdDuplicates["Total"].ToString());
                bcatid = rdDuplicates["BasicCategoryID"].ToString();
                Usage = rdDuplicates["MultiUsage"].ToString();
                if (FromDate >= TodayDate)
                {
                    lblStatus.Text = "** Promo Code Is Invalid **";
                    BusinessTier.DisposeReader(rdDuplicates);
                }
                else if (ToDate <= TodayDate)
                {
                    lblStatus.Text = "** Promo Code Is Invalid **";
                    BusinessTier.DisposeReader(rdDuplicates);
                }
                
            }
            else
            {
                lblStatus.Text = "** Promo Code Is Invalid **";
                BusinessTier.DisposeReader(rdDuplicates);
            }
            BusinessTier.DisposeReader(rdDuplicates);


            if (Usage.ToString() != "True" && hdPromotionID.Value.ToString() != "0")
            {
                SqlDataReader rd2Duplicates = BusinessTier.Find2Duplicate(conn, "ShippingAddress", "CustomerID", Request.Cookies["CustomerID"].Value.ToString(), "PromotionID", hdPromotionID.Value.ToString());
                if (rd2Duplicates.Read())
                {
                    lblStatus.Text = "** Promo Code Used Already **";
                    BusinessTier.DisposeReader(rd2Duplicates);
                    return;
                }
                BusinessTier.DisposeReader(rd2Duplicates);
            }
            string AgCd = string.Empty;
            string[] Ext = txtPCode.Text.Split('-');
            AgCd = Ext[0].ToString();

            if (AgCd == "#UTHM")
            {
                SqlDataReader rdAgent = BusinessTier.FindDuplicate(conn, "MasterAgent", "AgentCode", txtPCode.Text.ToString());
                if (rdAgent.Read())
                {
                    hdAgentID.Value = rdAgent["AgentID"].ToString();
                    lblStatus.Text = "** This order placed under Agent : " + rdAgent["AgentName"].ToString() + " **";
                }
                else
                {
                    lblStatus.Text = "** Agent Code is Invalid **";
                }
                BusinessTier.DisposeReader(rdAgent);
            }
            string Today = DateTime.Now.ToString();
            DateTime idt2 = DateTime.Parse(Today);
            Today = idt2.Month + "/" + idt2.Day + "/" + idt2.Year + " 00:00:00";
           
            string sql5 = string.Empty;
            if (bcatid != "0")
            {
                //string sql5 = "select * FROM Vw_AddCart WHERE Deleted=0 and buy=0 and IsCOD=0 and BasicCategoryID='" + bcatid + "' and Customerid='" + @Param + "' and CREATED_DATE between '" + week.ToString() + "' and '" + Today.ToString() + "'";
                sql5 = "select  sum(DiscountPrice*Qnty) as Total, sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=0 and IsCOD=0 and BasicCategoryID='" + bcatid + "' and ShippingID='" + @Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next";
            }
            else 
            {
                sql5 = "select  sum(DiscountPrice*Qnty) as Total, sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=0 and IsCOD=0 and ShippingID='" + @Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next";
            }
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            if (rd5.Read())
            {
                decimal cmpwgt = 1000, cst = 0, addcst = 0, shipcst = 0,gndtot=0,brkamt=0,
                compweight = Convert.ToDecimal(rd5["totweight"].ToString()),
                Total = Convert.ToDecimal(rd5["Total"].ToString()),
                ShipCost = Convert.ToDecimal(rd5["ShipCost"].ToString()),
                ShipCostNext = Convert.ToDecimal(rd5["ShipCostNext"].ToString()),
                ShipCost2 = Convert.ToDecimal(rd5["ShipCost2"].ToString()),
                ShipCost2Next = Convert.ToDecimal(rd5["ShipCost2Next"].ToString());
                BusinessTier.DisposeReader(rd5);

                if (protot>Total)
                {
                    lblStatus.Text = "** Promo Code Is Invalid **";
                    return;
                }

                string sql = "Select Type,Discount,PromotionID from PromotionMaster where PromotionCode='" + txtPCode.Text.ToString() + "' and deleted=0 and FromDate <= '" + Today.ToString() + "' and ToDate >= '" + Today.ToString() + "' and Total<='" + lblSubTotal.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                string type = string.Empty;
                decimal disc = 0;
                if (rd.Read())
                {
                    disc = Convert.ToDecimal(rd["Discount"].ToString());
                    type = rd["Type"].ToString();
                    txtPCode.ToolTip = rd["PromotionID"].ToString();
                }

                if (type == "RM")
                {
                    decimal s = 0;
                    s = (Convert.ToDecimal(lblSubTotal.Text));
                    lblGrandTotal.Text = ((s - disc) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    lblGrandTotal.ToolTip = ((s - disc) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    lblpromotion.Visible = true;
                    lblPRA.Visible = true;
                    lblPRA.Text = "Discount :";
                    lblpromotion.Text = "-" + disc.ToString() + "<br><br />";
                    lblpromotion.ToolTip = disc.ToString();
                }

                else if (type == "Percentage")
                {
                    decimal t = 0, p = 0, r = 0, per = 0;
                    t = Convert.ToDecimal(lblSubTotal.Text.ToString().Trim());
                    if (bcatid != "0")
                    { p = Convert.ToDecimal(Total.ToString().Trim()); }
                    else
                    { p = Convert.ToDecimal(lblSubTotal.Text.ToString().Trim()); }

                    
                    r = Convert.ToDecimal(disc.ToString().Trim());
                    per = p - ((r / 100) * p);
                    lblpromotion.Visible = true;
                    lblPRA.Visible = true;
                    lblPRA.Text = "Discount(" + Math.Round(disc, 0) + "%) :";
                    lblpromotion.ToolTip = decimal.Round((p - per), 2, MidpointRounding.AwayFromZero).ToString();
                    lblpromotion.Text = "-" + decimal.Round((p - per), 2, MidpointRounding.AwayFromZero).ToString().Trim() + "<br><br />";

                    lblGrandTotal.Text = ((t - (p - per)) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    lblGrandTotal.ToolTip = ((t - (p - per)) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                }

                if (txtPCode.Text.ToString() == "#serbastar") //#serbastar
                {
                    type = "Shipping";
                    gndtot = Convert.ToDecimal(lblGrandTotal.Text.ToString());
                    brkamt = Convert.ToDecimal(lblpromotion.ToolTip);                    
                }
                
                if (type == "Shipping")
                {

                    if (State == "WP Labuan" || State == "Sabah" || State == "Sarawak")
                    {
                        cmpwgt = 1000;
                        cst = ShipCost2;
                        addcst = ShipCost2Next;
                    }
                    else
                    {
                        cmpwgt = 1000;
                        cst = ShipCost;
                        addcst = ShipCostNext;
                    }

                    if (!(string.IsNullOrEmpty(compweight.ToString())))
                    {

                        if (compweight <= cmpwgt)
                        {
                            shipcst = cst;
                        }
                        else
                        {
                            decimal weight = Math.Ceiling(compweight / cmpwgt);

                            decimal shipcost = cst + (addcst * (Convert.ToInt32(weight) - 1));
                            shipcst = shipcost;
                        }
                    }
                    else
                    {
                        shipcst = 0;
                    }

                    lblpromotion.Visible = true;
                    lblPRA.Visible = true;
                    lblPRA.Text = "Discount Shipping Amount :";
                    lblpromotion.ToolTip = lblShippingCost.Text.ToString();
                    lblpromotion.Text = "-" + lblShippingCost.Text.ToString() + "<br><br />";
                    lblGrandTotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    lblGrandTotal.ToolTip = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    if (txtPCode.Text.ToString() == "#serbastar")
                    {
                        lblpromotion.ToolTip = (Convert.ToDecimal(lblpromotion.ToolTip)+brkamt).ToString("0.00"); ;          
                        lblGrandTotal.Text = (gndtot - shipcst).ToString("0.00");
                        lblGrandTotal.ToolTip = (gndtot - shipcst).ToString("0.00");
                    }

                }
                if (txtPCode.Text.ToString() == "#serbastar")
                {
                    lblPRA.Text = "Discount (" + Math.Round(disc, 0) + "% + Shipping) :";

                    lblpromotion.Text = (Convert.ToDecimal(lblGrandTotal.Text) - (Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text))).ToString("0.00") + "<br><br />";
                    //lblPRA.Visible = false;
                    //lblpromotion.Visible = false;
                }
                lblGtotal.Text = "After Discount :";
                BusinessTier.DisposeReader(rd);
            }
            else
            {
                lblStatus.Text = "** Promo Code Is Invalid... **";
                BusinessTier.DisposeReader(rd5);
            }
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            //lblStatus.Text = ex.Message;
            BusinessTier.DisposeConnection(conn);
            InsertLogAuditTrail(Session["sesUserID"].ToString(), "AddCart", "btnSubmit_OnClick", ex.ToString(), "Audit");
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