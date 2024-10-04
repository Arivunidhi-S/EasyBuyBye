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

public partial class OrderConfirmation : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public DataTable dtFeatureitems = new DataTable();

    public DataTable dtGridVal = new DataTable();

    public DataTable dtMugavari = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());decimal aryshipcst = 0;

    public string path = string.Empty;

    string Status = string.Empty, test = string.Empty;

    public string CustomerID = string.Empty, Name = string.Empty, Mobile = string.Empty, Email = string.Empty, Address1 = string.Empty, Address2 = string.Empty, PostCode = string.Empty, City = string.Empty, State = string.Empty, Country = string.Empty, Amount = string.Empty;

    public string MerchantCode = "", PaymentId = "", RefNo = "", Currency = "", Remark = "", TransId = "", AuthCode = "", ErrDesc = "", ReturnSignature = "", Param="";
   
    protected void Page_Init(object sender, EventArgs e)
    {


        Param = Request.QueryString.Get("param1").ToString();
        MerchantCode =Request.QueryString.Get("MerchantCode");
        PaymentId = Request.QueryString.Get("PaymentId");
        RefNo = Request.QueryString.Get("RefNo");
        Amount = Request.QueryString.Get("Amount");
        Currency = Request.QueryString.Get("Currency");
        Remark = Request.QueryString.Get("Remark");
        TransId = Request.QueryString.Get("TransId");
        AuthCode = Request.QueryString.Get("AuthCode");
        Status = Request.QueryString.Get("Status");
        ErrDesc = Request.QueryString.Get("ErrDesc");
        ReturnSignature = Request.QueryString.Get("Signature");

        //Param = Request.QueryString.Get("param1").ToString();
        //MerchantCode = Request.Form["MerchantCode"];
        //PaymentId = Request.Form["PaymentId"];
        //RefNo = Request.Form["RefNo"];
        //Amount = Request.Form["Amount"];
        //Currency = Request.Form["Currency"];
        //Remark = Request.Form["Remark"];
        //TransId = Request.Form["TransId"];
        //AuthCode = Request.Form["AuthCode"];
        //Status = Request.Form["Status"];
        //ErrDesc = Request.Form["ErrDesc"];
        //ReturnSignature = Request.Form["Signature"];

        //Param = "99"; //31
        //MerchantCode = "M03359";
        //PaymentId = "2";
        //RefNo = "17032133";
        //Amount = "80.00";
        //Currency = "MYR";
        //Remark = "PWD";
        //TransId = "T112427185000";
        //AuthCode = "T50155";
        //Status = "1";
        //ErrDesc = "";
        //ReturnSignature = "hG0g7B9wLOil34gpZig+m4qYp78=";

         //test = Param + "<br>MerchantCode=" + Request.Form["MerchantCode"] + "<br>PaymentId=" + Request.Form["PaymentId"] + "<br>RefNo=" + Request.Form["RefNo"] + "<br>Amount=" + Request.Form["Amount"] + "<br>Currency=" + Request.Form["Currency"] + "<br>Remark=" + Request.Form["Remark"] + "<br>TransId=" + Request.Form["TransId"] + "<br>AuthCode=" + Request.Form["AuthCode"] + "<br>Status=" + Request.Form["Status"] + "<br>ErrDesc=" + Request.Form["ErrDesc"] + "<br>Signature=" + Request.Form["Signature"];
       // BusinessTier.SendMail("arivu@e-serbadk.com", "ReturnValue of Easybuybye.com OrderConfirmation Page", test, 0);

        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        lblOrderno.Text = RefNo.ToString();
        string sql1 = "select * from ShippingAddress where DELETED=0 and ShippingID='" + Param.ToString() + "'";
        SqlCommand cmd1 = new SqlCommand(sql1, connMenu);
        SqlDataReader reader1 = cmd1.ExecuteReader();
        if (reader1.Read())
        {
            CustomerID = reader1["CustomerID"].ToString();
            Name = reader1["Name"].ToString();
            Mobile = reader1["Mobile"].ToString();
            Email = reader1["Email"].ToString();
            Address1 = reader1["Address1"].ToString();
            Address2 = reader1["Address2"].ToString();
            PostCode = reader1["PostCode"].ToString();
            City = reader1["City"].ToString();
            State = reader1["State"].ToString();
            Country = reader1["Country"].ToString();
        }

        BusinessTier.DisposeReader(reader1);     

        var verifyKey = ConfigurationManager.AppSettings["VerifyKey"].ToString(CultureInfo.InvariantCulture);
        var Signature = GetVCode(verifyKey.ToString() + MerchantCode.ToString() + PaymentId.ToString() + RefNo.ToString() + Amount.Replace(".", string.Empty) + Currency.ToString() + Status.ToString());
        if (Status == "1")
        {
            if (PaymentId.ToString() == "0") { lblstatus.Text = "** Order Placed Successfully **"; }
            else
            {
                lblstatus.Text = "Congratulations! You Will Receive Your Order In 2-5 Days. Confirmation Email Has Sent To Your Registered Email Address";
            }
            lblstatus.ForeColor = Color.Green;
            int flg = 0;
            flg = BusinessTier.OrderConfirmation(connMenu, Param.ToString().Trim(),
                MerchantCode.ToString().Trim(), PaymentId.ToString().Trim(),
                RefNo.ToString().Trim(), Amount.ToString().Trim(),
                Currency.ToString().Trim(), Remark.ToString().Trim(), TransId.ToString().Trim(),
                AuthCode.ToString().Trim(), Status.ToString().Trim(), ErrDesc.ToString().Trim(),
                ReturnSignature.ToString().Trim(), CustomerID.ToString().Trim(), "N");

        }
        else if (Status == "0")
        {

            lblstatus.Text = "** The transaction was cancelled. If you did not cancel the transaction, please get in touch with the EasyBuyBye Customer Care team. See Store Information below for our customer care contact details.**";
            lblstatus.ForeColor = Color.Red;
            int flg = 0;
            flg = BusinessTier.OrderConfirmation(connMenu, Param.ToString().Trim(),
                MerchantCode.ToString().Trim(), PaymentId.ToString().Trim(),
                RefNo.ToString().Trim(), Amount.ToString().Trim(),
                Currency.ToString().Trim(), Remark.ToString().Trim(), TransId.ToString().Trim(),
                AuthCode.ToString().Trim(), Status.ToString().Trim(), ErrDesc.ToString().Trim(),
                ReturnSignature.ToString().Trim(), CustomerID.ToString().Trim(), "N");

            lblOrderno.Visible = false;
            lblordertitle.Visible = false;
        }
        else         
        {
            lblstatus.Text = "** Sorry! The transaction failed. If any money was debited from your account please get in touch with us. See Store Information below for contact details. Don’t worry, we can either proceed to process the purchase or refund the payment back to your account. We regret any inconvenience caused.**";
            lblstatus.ForeColor = Color.Red;
            lblOrderno.Visible = false;
            lblordertitle.Visible = false;
        }
        BusinessTier.DisposeConnection(connMenu);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridload();
            kuttalyeatral();
        }

        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        try
        {
            decimal tot = 0, ship = 0, shipcost = 0, Gtot = 0, subtot = 0, inttot = 0, disc = 0;            
            string tablepricelist = string.Empty;

            if (Status == "1")
            {
                /// ************ For Email Send ************ ///
                /// 
                string selleremail = string.Empty, type = string.Empty, DiscTXT = string.Empty, Discount = string.Empty;
                string sql = "select * from VW_SellerOrderDetails where DELETED=0 and ShippingID='" + Param.ToString() + "' order by email";
                SqlCommand cmd = new SqlCommand(sql, connMenu);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    type = reader["Type"].ToString();
                    if (string.IsNullOrEmpty(reader["DiscountPromotion"].ToString()))
                    {
                        disc = 0;
                    }
                    else
                    {
                        disc = Convert.ToDecimal(reader["DiscountPromotion"].ToString());
                    }
                    //-----------Seller Mail-------
                    if (selleremail != reader["Email"].ToString())
                    {
                        string sellermsg = "<font face='Cambria Math'>Dear " + reader["SellerName"].ToString() + ",<br><br>" + "Greetings from Easybuybye !  <br><br> You have received a new order in your easybuybye Seller account.<br> Please <a href='http://admin.easybuybye.com/SellerLogin.aspx'>click here</a> to access your account's order overview. <br> <br><br>Thanks & Regards<br><table border='0' bordercolor='#b4b1b4' style='border: 0px solid; border-collapse: collapse;'><tr><td> <b>Admin Team</b><br></td></tr><tr><td><a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br>Malaysia</td></tr></table> </font>";
                        BusinessTier.SendMail(reader["Email"].ToString(), "New Order Notification From Easybuybye Seller Account", sellermsg, 0);
                        selleremail = reader["Email"].ToString();
                    }

                    //-------------------
                    //ship = Convert.ToDecimal(reader["ShippingCost"].ToString());
                    tot = Convert.ToDecimal(reader["DiscountPrice"].ToString()) * Convert.ToDecimal(reader["Qnty"].ToString());
                    subtot = tot;
                    inttot = tot / Convert.ToDecimal(reader["Qnty"].ToString());
                    tablepricelist = tablepricelist + "<tr><td style='width:5%;height:50px;width:50px'><img style='height:50px;width:50px' alt='' height='50px' width='50px' src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + reader["imagePath"].ToString() + "'></img></td><td  style='width:15%;'>" + reader["Brand"].ToString() + " " + reader["Model"].ToString() + "</td><td  style='width:6%;'>" + inttot.ToString("#0.00") + "</td><td style='width:5%;'>" + reader["Qnty"].ToString() + "</td><td style='width:9%;'>" + subtot.ToString("#0.00") + "</td></tr>";
                    Gtot = Gtot + subtot;
                    shipcost = Convert.ToDecimal(aryshipcst);
                    ship = shipcost;
                }
                decimal total = 0;
                total = Gtot;
                if (type == "RM")
                {
                    Discount = "-" + disc.ToString("#0.00");
                    DiscTXT = "Discount";
                    Gtot = Gtot - disc;
                }
                else if (type == "Percentage")
                {
                    decimal p = 0, r = 0, per = 0;
                    p = Gtot;
                    r = disc;
                    Discount = "-" + ((r / 100) * p).ToString("#0.00");
                    per = p - ((r / 100) * p);
                    lblpromotion.Visible = true;
                    lblPRA.Visible = true;
                    DiscTXT = "Discount(" + disc.ToString("N0") + "%)";
                    Gtot = per;

                }
                else if (type == "Shipping")
                {
                    lblpromotion.Visible = true;
                    lblPRA.Visible = true;
                    //lblPRA.Text = "Discount Shipping Amount :";                   
                    DiscTXT = "Discount Shipping Amount";
                    Discount = "-" + shipcost.ToString("#0.00");
                    lblpromotion.Text = Discount + "<br><br />";
                    shipcost = 0;
                }
                else
                {
                    Discount = "0.00";
                    DiscTXT = "Discount";
                }
                decimal totamt = Gtot + shipcost;
                BusinessTier.DisposeReader(reader);
                string tabletotal = "<tr><td colspan='4' style='width:5%;text-align:right'>Subtotal &nbsp;</td><td style='width:5%;'>" + Convert.ToDecimal(lblSubTotal.Text).ToString("#0.00") + "</td></tr><tr><td colspan='4' style='width:5%;text-align:right'>Shipping Fee &nbsp;</td><td style='width:5%;'>" + Convert.ToDecimal(lblShippingCost.Text).ToString("#0.00") + "</td></tr><tr><td colspan='4' style='width:5%;text-align:right'>Total &nbsp;</td><td style='width:5%;'>" + Convert.ToDecimal(lblTotal.Text).ToString("#0.00") + "</td></tr><tr><td colspan='4' style='width:5%;text-align:right'>" + lblPRA.Text + " &nbsp;</td><td style='width:5%;'>" + lblpromotion.Text + "</td></tr><tr><td colspan='4' style='width:5%;text-align:right'>" + lblGtotal.Text + "&nbsp;</td><td style='width:5%;'>" + Convert.ToDecimal(lblGrandTotal.Text).ToString("#0.00") + "</td></tr>";

                string msg = string.Empty, Note = string.Empty, via = string.Empty;
                if (PaymentId.ToString() == "0") 
                {
                    via = "Cash On Delivery";
                    Note = "*Please take note delivery will be made within 2-3 hours.*";
                }
                else
                {
                    via = "Credit or Debit Card";
                    Note = "*Please take note delivery will be made within 2-5 days.*";
                }
                msg = "<font face='Cambria Math'>Dear " + Name.ToString() + ",<br><br>" + "Your Order No # <b>" + lblOrderno.Text.ToString() + "</b> has been placed on <b>" + String.Format("{0:dddd, MMMM dd, yyyy hh:mm tt}", DateTime.Now) + "</b> via " + via.ToString() + " <br><br> " + Note.ToString() + " <br><br><table border='1' bordercolor='#b4b1b4' style='border: 1px solid; border-collapse: collapse;text-align:center;width:60%' cellspacing='0px'>" + tablepricelist.ToString() + tabletotal.ToString() + "</table><br><br>Your Order will be delivered to below address:<br><br><b>" + Name.ToString() + " <br>" + Address1.ToString() + " &nbsp;" + Address2.ToString() + " <br>" + PostCode.ToString() + " &nbsp;" + City.ToString() + " <br>" + State.ToString() + "  &nbsp;" + Country.ToString() + "</b>";
                msg = msg + "<br><br>Enjoy your Shopping at Easybuybye !!!<br><br>Thanks & Regards<br><table border='0' bordercolor='#b4b1b4' style='border: 0px solid; border-collapse: collapse;'><tr><td> <b>Admin Team</b><br></td></tr><tr><td><a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br>Malaysia</td></tr></table> </font>";

               BusinessTier.SendMail(Email.ToString(), "Easybuybye Order Confirmation", msg, 1);

            }

            BusinessTier.DisposeConnection(connMenu);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(CustomerID.ToString(), "OrderConfirmation", "Page_Load", ex.ToString(), "Audit");
            BusinessTier.SendMail("arivu@e-serbadk.com", "Error on Easybuybye.com OrderConfirmation Page", test + "<br>" + ex.ToString(), 0);
            Response.Redirect("index.aspx", false);
        }
        finally
        {
            BusinessTier.DisposeConnection(connMenu);
        }
    }

    public void kuttalyeatral()
    {

        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            string sql1 = "select count(*) as Cart, sum(DiscountPrice*Qnty) as Total, sum(ShippingCost*Qnty) as ShipCost from Vw_AddCart where DELETED=0 and IsCOD=0 and ShippingID='" + Param.ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                lblSubTotal.Text = reader1["Total"].ToString();
            }
            BusinessTier.DisposeReader(reader1);

            string sql = "select sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID from Vw_AddCart where ShippingCost>0 and DELETED=0 and IsCOD=0 and buy=1 and ShippingID='" + Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();             
            while (reader.Read())
            {
                decimal cmpwgt = 0, cst = 0, addcst = 0,shipcst = 0;
                if (State == "WP Labuan" || State == "Sabah" || State == "Sarawak")
                {
                    cmpwgt = 1000;
                    cst = Convert.ToDecimal(reader["ShipCost2"].ToString());
                    addcst = Convert.ToDecimal(reader["ShipCost2Next"].ToString());
                }
                else
                {
                    cmpwgt = 1000;
                    cst = Convert.ToDecimal(reader["ShipCost"].ToString());
                    addcst = Convert.ToDecimal(reader["ShipCostNext"].ToString());
                }

                if (!(string.IsNullOrEmpty(reader["totweight"].ToString())))
                {
                    decimal compweight = Convert.ToDecimal(reader["totweight"].ToString());
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
            }
            lblShippingCost.Text = aryshipcst.ToString("0.00");
            lblTotal.Text = Math.Round((Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text)), 2).ToString("#0.00");

            BusinessTier.DisposeReader(reader);

            string fdt = string.Empty, tdt = string.Empty, bcatid = string.Empty, proid = string.Empty, pcode = string.Empty;
            DateTime FromDate = DateTime.Now, ToDate = DateTime.Now, TodayDate = DateTime.Now;
            string sql2 = "Select * from VW_SellerOrderDetails where DELETED=0 and ShippingID=" + Param.ToString();
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader rd = cmd2.ExecuteReader();
            string type = string.Empty;
            decimal disc = 0, total = 0;
            if (rd.Read())
            {
                if (string.IsNullOrEmpty(rd["DiscountPromotion"].ToString()))
                {
                    disc = 0;
                }
                else
                {
                    disc = Convert.ToDecimal(rd["DiscountPromotion"].ToString());
                }
                type = rd["Type"].ToString();
                proid = rd["PromotionID"].ToString();
            }
            else 
            {
                lblGtotal.Text = "Grand Total :";
                proid = "0";
            }
            BusinessTier.DisposeReader(rd);
            if (!(string.IsNullOrEmpty(proid.ToString())))
            {
                SqlDataReader rdDuplicates = BusinessTier.FindDuplicate(conn, "PromotionMaster", "PromotionID", proid);
                if (rdDuplicates.Read())
                {
                    pcode = rdDuplicates["PromotionCode"].ToString();
                    bcatid = rdDuplicates["BasicCategoryID"].ToString();
                }
                BusinessTier.DisposeReader(rdDuplicates);
            }
            string sql5 = string.Empty;
            if (bcatid != "0")
            {
                //string sql5 = "select * FROM Vw_AddCart WHERE Deleted=0 and buy=0 and IsCOD=0 and BasicCategoryID='" + bcatid + "' and Customerid='" + @Param + "' and CREATED_DATE between '" + week.ToString() + "' and '" + Today.ToString() + "'";
                sql5 = "select sum(DiscountPrice*Qnty) as Total, sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=1 and IsCOD=0 and BasicCategoryID='" + bcatid + "' and ShippingID='" + Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next";
            }
            else
            {
                sql5 = "select sum(DiscountPrice*Qnty) as Total, sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next from Vw_AddCart where ShippingCost>0 and DELETED=0 and buy=1 and IsCOD=0 and ShippingID='" + Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next";
            }
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            if (rd5.Read())
            {
                decimal cmpwgt = 1000, cst = 0, addcst = 0, shipcst = 0, gndtot = 0,
                compweight = Convert.ToDecimal(rd5["totweight"].ToString()),
                Total = Convert.ToDecimal(rd5["Total"].ToString()),
                ShipCost = Convert.ToDecimal(rd5["ShipCost"].ToString()),
                ShipCostNext = Convert.ToDecimal(rd5["ShipCostNext"].ToString()),
                ShipCost2 = Convert.ToDecimal(rd5["ShipCost2"].ToString()),
                ShipCost2Next = Convert.ToDecimal(rd5["ShipCost2Next"].ToString());
                BusinessTier.DisposeReader(rd5);


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
                    lblPRA.Text = "Discount(%) :";
                    lblpromotion.ToolTip = decimal.Round((p - per), 2, MidpointRounding.AwayFromZero).ToString();
                    lblpromotion.Text = "-" + decimal.Round((p - per), 2, MidpointRounding.AwayFromZero).ToString().Trim() + "<br><br />";

                    lblGrandTotal.Text = ((t - (p - per)) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                    lblGrandTotal.ToolTip = ((t - (p - per)) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                }

                if (pcode.ToString() == "#serbastar")
                {
                    type = "Shipping";
                    gndtot = Convert.ToDecimal(lblGrandTotal.Text.ToString());
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
                    if (pcode.ToString() == "#serbastar")
                    {
                        lblGrandTotal.Text = (gndtot - shipcst).ToString("0.00");
                        lblGrandTotal.ToolTip = (gndtot - shipcst).ToString("0.00");
                    }
                }
                if (pcode.ToString() == "#serbastar")
                {
                    lblPRA.Text = "Discount (" + Math.Round(disc, 0) + "% + Shipping) :";

                    lblpromotion.Text = (Convert.ToDecimal(lblGrandTotal.Text) - (Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text))).ToString("0.00") + "<br><br />";
                }
                lblGtotal.Text = "After Discount :";
                BusinessTier.DisposeReader(rd);
            }
            else
            {
                lblGtotal.Text = "Grand Total :";
                lblPRA.Text = "Discount";
                lblpromotion.Text = "0.00" + "<br><br />";
                lblGrandTotal.Text = (Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblShippingCost.Text)).ToString("0.00");
                BusinessTier.DisposeReader(rd5);
            }
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            //lblStatus.Text = ex.Message;
            BusinessTier.DisposeConnection(conn);
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "OrderConfirmation", "kuttalyeatral", ex.ToString(), "Audit");
        }
    }

    //public void kuttalyeatral2()
    //{
    //    SqlConnection connMenu = BusinessTier.getConnection();
    //    connMenu.Open();
    //    try
    //    {
    //        String today = DateTime.Now.ToString();
    //        DateTime dtinsDate = DateTime.Parse(today);
    //        today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

    //        string sql1 = "select count(*) as Cart, sum(DiscountPrice*Qnty) as Total, sum(ShippingCost*Qnty) as ShipCost from Vw_AddCart where DELETED=0 and IsCOD=0 and ShippingID='" + Param.ToString() + "'";
    //        SqlCommand cmd1 = new SqlCommand(sql1, connMenu);
    //        SqlDataReader reader1 = cmd1.ExecuteReader();
    //        if (reader1.Read())
    //        {
    //            lblSubTotal.Text = reader1["Total"].ToString();
    //        }
    //        BusinessTier.DisposeReader(reader1);

    //        string sql = "select sum(Weight*Qnty) as totweight,ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID from Vw_AddCart where ShippingCost>0 and DELETED=0 and IsCOD=0 and buy=1 and ShippingID='" + Param.ToString() + "' group by ShipCost,ShipCostNext,ShipCost2,ShipCost2Next,SellerID";
    //        SqlCommand cmd = new SqlCommand(sql, connMenu);
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        decimal shipcst = 0;
    //        while (reader.Read())
    //        {
    //            decimal cmpwgt = 0, cst = 0, addcst = 0;
    //            if (State == "WP Labuan" || State == "Sabah" || State == "Sarawak")
    //            {
    //                cmpwgt = 1000;
    //                cst = Convert.ToDecimal(reader["ShipCost2"].ToString());
    //                addcst = Convert.ToDecimal(reader["ShipCost2Next"].ToString());
    //            }
    //            else
    //            {
    //                cmpwgt = 1000;
    //                cst = Convert.ToDecimal(reader["ShipCost"].ToString());
    //                addcst = Convert.ToDecimal(reader["ShipCostNext"].ToString());
    //            }

    //            if (!(string.IsNullOrEmpty(reader["totweight"].ToString())))
    //            {
    //                decimal compweight = Convert.ToDecimal(reader["totweight"].ToString());
    //                if (compweight <= cmpwgt)
    //                {
    //                    shipcst = cst;
    //                }
    //                else
    //                {
    //                    decimal weight = Math.Ceiling(compweight / cmpwgt);

    //                    decimal shipcost = cst + (addcst * (Convert.ToInt32(weight) - 1));
    //                    shipcst = shipcost;
    //                }
    //            }
    //            else
    //            {
    //                shipcst = 0;
    //            }
    //            aryshipcst = aryshipcst + shipcst;
    //        }
    //        lblShippingCost.Text = aryshipcst.ToString("0.00");
    //        BusinessTier.DisposeReader(reader);

    //        string sql2 = "Select * from VW_SellerOrderDetails where DELETED=0 and ShippingID=" + Param.ToString();
    //        SqlCommand cmd2 = new SqlCommand(sql2, connMenu);
    //        SqlDataReader rd = cmd2.ExecuteReader();
    //        string type = string.Empty;
    //        decimal disc = 0, total = 0;
    //        if (rd.Read())
    //        {
    //            if (string.IsNullOrEmpty(rd["DiscountPromotion"].ToString()))
    //            {
    //                disc = 0;
    //            }
    //            else
    //            {
    //                disc = Convert.ToDecimal(rd["DiscountPromotion"].ToString());
    //            }
    //            type = rd["Type"].ToString();
    //        }
    //        if (type == "RM")
    //        {
    //            decimal s = 0;
    //            s = (Convert.ToDecimal(lblSubTotal.Text));
    //            total = (s - disc);
    //            lblpromotion.Visible = true;
    //            lblPRA.Visible = true;
    //            lblPRA.Text = "Discount :";
    //            lblpromotion.Text = "-" + disc.ToString() + "<br><br />";
    //        }
    //        else if (type == "Percentage")
    //        {
    //            decimal p = 0, r = 0, per = 0;
    //            p = Convert.ToDecimal(lblSubTotal.Text.ToString().Trim());
    //            r = Convert.ToDecimal(disc.ToString().Trim());
    //            per = p - ((r / 100) * p);
    //            lblpromotion.Visible = true;
    //            lblPRA.Visible = true;
    //            lblPRA.Text = "Discount(" + disc.ToString("N0") + "%) :";
    //            lblpromotion.Text = "-" + decimal.Round((p - per), 2, MidpointRounding.AwayFromZero).ToString().Trim() + "<br><br>";
    //            total = (per + Convert.ToDecimal(lblShippingCost.Text));
    //        }
    //        else if (type == "Shipping")
    //        {
    //            lblpromotion.Visible = true;
    //            lblPRA.Visible = true;
    //            lblPRA.Text = "Discount Shipping Amount :";
    //            //lblpromotion.ToolTip = lblShippingCost.Text.ToString();
    //            lblpromotion.Text = "-" + lblShippingCost.Text.ToString() + "<br><br />";
    //            lblShippingCost.Text = "0";
    //            total = Convert.ToDecimal(lblSubTotal.Text.ToString().Trim());
    //        }
    //        else
    //        {
    //            total = Convert.ToDecimal(lblSubTotal.Text.ToString().Trim());
    //        }
    //        BusinessTier.DisposeReader(rd);
    //        lblGrandTotal.Text = Math.Round((Convert.ToDecimal(total) + Convert.ToDecimal(lblShippingCost.Text)), 2).ToString("#0.00");
    //        BusinessTier.DisposeConnection(connMenu);
    //    }
    //    catch (Exception ex)
    //    {

    //        InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "kuttalyeatral", "OrderConfirmation", ex.ToString(), "Audit");
    //    }
    //    finally
    //    {
    //        BusinessTier.DisposeConnection(connMenu);
    //    }

    //}

    public void gridload()
    {
        try
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string sql = "select *, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM Vw_AddCart WHERE Deleted=0 and IsCOD=0 and shippingid='" + Param.ToString() + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dtGridVal);
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

    protected void btnMoreBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx", false);
    }

    protected void rpAddress_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SqlConnection inaippu = BusinessTier.getConnection();
        inaippu.Open();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            string AddcartID = (item.FindControl("hdAddcartID") as HiddenField).Value;
            string ProductID = (item.FindControl("hdProductID") as HiddenField).Value;
            string PricingID = (item.FindControl("hdPricingID") as HiddenField).Value;
            string Qnty = (item.FindControl("hdQnty") as HiddenField).Value;
            string Price = (item.FindControl("hdPrice") as HiddenField).Value;
            Label lblProductPrice = item.FindControl("lblProductPrice") as Label;            
            
            decimal tot = 0;
            tot = Convert.ToDecimal(Price.ToString()) * Convert.ToDecimal(Qnty.ToString());
            lblProductPrice.Text = "RM " + tot.ToString("0.00");

            if (Status.ToString() == "1")
            {
                BusinessTier.Stock_Update(inaippu, AddcartID.ToString(), ProductID.ToString(), PricingID.ToString(), Convert.ToInt32(Qnty.ToString()), CustomerID.ToString().Trim(), "U");
            }
        }
        BusinessTier.DisposeConnection(inaippu);
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

    private string GetVCode(string input)
    {
        SHA1CryptoServiceProvider objSHA1 = new SHA1CryptoServiceProvider();

        objSHA1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

        byte[] buffer = objSHA1.Hash;
        string HashValue = System.Convert.ToBase64String(buffer);

        return HashValue;
    }
}