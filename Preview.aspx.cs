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

public partial class Preview : System.Web.UI.Page
{
    public DataTable dtPreview = new DataTable();

    public DataTable dtRecentitems = new DataTable();

    public DataTable dtProductReview = new DataTable();

    public string image1 = string.Empty;
    public string image2 = string.Empty;
    public string image3 = string.Empty;
    public string image4 = string.Empty;
    public string image5 = string.Empty;

    public string img1 = string.Empty, img2 = string.Empty, img3 = string.Empty;

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_PreInit(object sender, EventArgs e)
    {
        string @Param = string.Empty;
        @Param = Request.QueryString.Get("Param").ToString();
        string strUA = Request.UserAgent.Trim().ToLower();
        bool isMobile = false;
        if (strUA.Contains("ipod") || strUA.Contains("iphone"))
            isMobile = true;

        if (strUA.Contains("android"))
            isMobile = true;

        if (strUA.Contains("opera mobi"))
            isMobile = true;

        if (strUA.Contains("windows phone os") && strUA.Contains("iemobile"))
            isMobile = true;

        if (strUA.Contains("palm"))
            isMobile = true;

        bool MobileDevice = Request.Browser.IsMobileDevice;
        if (isMobile == true && MobileDevice == true)
        {
            string url="http:\\m.easybuybye.com/productView/" + @Param;
            Response.Write("<script>window.open('" + url + "','_self');</script>");
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        string @Param = string.Empty;
        @Param = Request.QueryString.Get("Param").ToString();

        SqlConnection con = BusinessTier.getConnection();

        try
        {
            con.Open();

            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            string sql = "select image1,image2,image3,image4,image5,Brand,Model,SellingPrice,ActualPrice,Details,Discount,DiscountPrice,CategoryID,ProductID,Category,shippingcost,TotalStock,id,BusinessName,CREATED_BY,BasicCategoryID,SubCategoryID,BasicCategory,SubCategory from Vw_Products where productid='" + @Param.ToString() + "' and  deleted=0  and MasterDel=0 and  approve=1";

            SqlCommand cmd = new SqlCommand(sql, connMenu);
            SqlDataReader reader = cmd.ExecuteReader();
            dtPreview.Load(reader);
            string catid = dtPreview.Rows[0][12].ToString();
            string proid = dtPreview.Rows[0][13].ToString();
            hdqnty.Value = dtPreview.Rows[0][16].ToString();
            if (dtPreview.Rows[0][12].ToString() == "60" || dtPreview.Rows[0][12].ToString() == "65")
            {
                divPostcode.Visible = false;
                divbr.Visible = true;
                divbr1.Visible = true;
            }
            else
            {
                divbr.Visible = false;
                divbr1.Visible = true;
            }

            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString();
            string stk = "in stock";
            if (hdqnty.Value == "0")
            {
                lnkAddcart.Enabled = false;
                lblstatus.Text = "Sold Out - In Stock Soon";
                stk = "out of stock";
            }
            int i = 0;
            image1 = path + dtPreview.Rows[0][0].ToString();
            image2 = path + dtPreview.Rows[0][1].ToString();
            image3 = path + dtPreview.Rows[0][2].ToString();
            image4 = path + dtPreview.Rows[0][3].ToString();
            image5 = path + dtPreview.Rows[0][4].ToString();
            Image1.ImageUrl = path + dtPreview.Rows[0][0].ToString();
            Image2.ImageUrl = path + dtPreview.Rows[0][0].ToString();
            Image3.ImageUrl = path + dtPreview.Rows[0][1].ToString();
            Image4.ImageUrl = path + dtPreview.Rows[0][1].ToString();
            Image5.ImageUrl = path + dtPreview.Rows[0][2].ToString();
            Image6.ImageUrl = path + dtPreview.Rows[0][2].ToString();
            Image7.ImageUrl = path + dtPreview.Rows[0][3].ToString();
            Image8.ImageUrl = path + dtPreview.Rows[0][3].ToString();
            Image9.ImageUrl = path + dtPreview.Rows[0][4].ToString();
            Image10.ImageUrl = path + dtPreview.Rows[0][4].ToString();
            if (dtPreview.Rows[0][0].ToString() != "")
            {
                i += 1;

            }
            if (dtPreview.Rows[0][1].ToString() != "")
            {
                i += 1;
            }
            if (dtPreview.Rows[0][2].ToString() != "")
            {
                i += 1;
            }
            if (dtPreview.Rows[0][3].ToString() != "")
            {
                i += 1;
            }
            if (dtPreview.Rows[0][4].ToString() != "")
            {
                i += 1;
            }
            if (i == 1)
            {
                i = 0;
            }
            param1.Value = i.ToString();


            var url = "<meta property=\"og:url\" content=" + "\"" + path + HttpContext.Current.Request.Url.PathAndQuery + "\"" + " />";
            var img = "<meta property=\"og:image\" content=" + "\"" + image1 + "\"" + " />";
            var amount = "<meta property=\"og:price:amount\" content=" + "\"" + dtPreview.Rows[0]["DiscountPrice"].ToString() + "\"" + " />";
            var title = "<meta property=\"og:title\" content=" + "\"" + dtPreview.Rows[0]["Brand"].ToString() + " " + dtPreview.Rows[0]["Model"].ToString() + "\"" + " />";
            var desc = "<meta property=\"og:description\" content=  " + "\"Get " + dtPreview.Rows[0]["Brand"].ToString() + " " + dtPreview.Rows[0]["Model"].ToString() + " from EasyBuyBye!\" />";
            var id = "<meta property=\"product:retailer_item_id\" content=" + "\"" + @Param + "\"" + " />";
            var stock = "<meta property=\"product:availability\" content=" + "\"" + stk + "\"" + " />";
            litMeta.Text = url + img + title + desc + amount + id +stock;

            //HtmlMeta tagurl = new HtmlMeta();
            //tagurl.Name = "og:url";
            //tagurl.Content = HttpContext.Current.Request.Url.PathAndQuery;
            //Header.Controls.Add(tagurl);

            //HtmlMeta tagtitle = new HtmlMeta();
            //tagtitle.Name = "og:title";
            //tagtitle.Content = dtPreview.Rows[0]["Brand"].ToString() + " " + dtPreview.Rows[0]["Model"].ToString();
            //Header.Controls.Add(tagtitle);           
           
            //HtmlMeta tagimage = new HtmlMeta();
            //tagimage.Name = "og:image";
            //tagimage.Content = image2;
            //Header.Controls.Add(tagimage);

            //HtmlMeta tagdescription = new HtmlMeta();
            //tagdescription.Name = "og:description";
            //tagdescription.Content = "Get " + dtPreview.Rows[0]["Brand"].ToString() + " " + dtPreview.Rows[0]["Model"].ToString() + " from EasyBuyBye";
            //Header.Controls.Add(tagdescription);

            //HtmlMeta tagamount = new HtmlMeta();
            //tagamount.Name = "og:price:amount";
            //tagamount.Content = dtPreview.Rows[0]["DiscountPrice"].ToString();
            //Header.Controls.Add(tagamount);

            reader.Close();

            string sql1 = "select TOP(4) Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,left((Brand + ' ' + Model),16)+'...' as ShortBrMod FROM Vw_Products where [CategoryID]= " + catid.ToString() + " and MasterDel=0 and  TotalStock>0 and approve=1 and [ProductID] not in(" + proid.ToString() + " ) ORDER BY newid()";

            SqlCommand cmd1 = new SqlCommand(sql1, connMenu);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            dtRecentitems.Load(reader1);

            SqlDataReader rdProductReview = BusinessTier.getProductReview(connMenu, @Param);
            dtProductReview.Load(rdProductReview);
            BusinessTier.DisposeReader(rdProductReview);

            if (!Page.IsPostBack)
            {
                SqlDataReader readerSize = BusinessTier.getSize(connMenu, @Param.ToString());
                if (readerSize.Read())
                {
                    ddlSize.Visible = true;
                    readerSize.Close();
                    ddlSize_Load();
                    divQuantity.Visible = false;
                }
                else
                {
                    ddlSize.Visible = false;
                    divsize.Visible = false;
                    divmiddle.Visible = false;
                    readerSize.Close();
                    ddlQuantity_Load();
                }
                viruppaporul_yeatral();
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }

    protected void viruppaporul_yeatral()
    {
        SqlConnection inaipu = BusinessTier.getConnection();
        try
        {
            inaipu.Open();
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            string vinaval = "select * from WishListMaster where productid='" + @Param.ToString() + "' and CustomerID='" + Request.Cookies["CustomerID"].Value.ToString() + "'";

            SqlCommand kattalai = new SqlCommand(vinaval, inaipu);
            SqlDataReader padipaan = kattalai.ExecuteReader();
            if (padipaan.Read())
            {
                BusinessTier.DisposeReader(padipaan);
                SqlDataReader padipaan2 = BusinessTier.getWishDuplicate(inaipu, @Param.ToString(), Request.Cookies["CustomerID"].Value.ToString());
                if (padipaan2.Read())
                {
                    imgbtn.ImageUrl = "~/images/fav1.png";
                    hdWhish.Value = "2";
                }
                else
                {
                    imgbtn.ImageUrl = "~/images/fav2.png";
                    hdWhish.Value = "1";
                }
                BusinessTier.DisposeReader(padipaan2);
            }
            else
            {
                imgbtn.ImageUrl = "~/images/fav2.png";
                hdWhish.Value = "0";
            }
        }
        catch (Exception ex) { }
        finally { BusinessTier.DisposeConnection(inaipu); };
    }

    protected void ddlSize_Load()
    {
        try
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            DataTable dtSize = new DataTable();
            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            SqlDataReader readerMenu = BusinessTier.getSize(connMenu, @Param.ToString());
            dtSize.Load(readerMenu);
            ddlSize.Items.Clear();
            foreach (DataRow row in dtSize.Rows)
            {
                if (!(string.IsNullOrEmpty(row["ProSize"].ToString())))
                {
                    ListItem l1 = new ListItem(row["ProSize"].ToString(), row["PricingID"].ToString());
                    ddlSize.Items.Add(l1);
                }
            }
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem("--Size--", "0"));
            BusinessTier.DisposeReader(readerMenu);
            BusinessTier.DisposeConnection(connMenu);
        }
        catch (Exception ex)
        {
            //ShowMessage("Please Select the Installation Name", "Red");
        }

    }

    protected void ddlQuantity_Load()
    {
        try
        {
            String Insdate = DateTime.Now.ToString();
            DateTime dtinsDate = DateTime.Parse(Insdate);
            Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            SqlDataReader readerMenu = BusinessTier.getQty(connMenu, @Param.ToString());
            if (readerMenu.Read())
            {
                int stock = 0;
                if (Convert.ToInt32(readerMenu["tstock"].ToString()) < 5)
                {
                    stock = Convert.ToInt32(readerMenu["tstock"].ToString());
                }
                else
                {
                    stock = 5;
                }
                for (int i = 1; i <= stock; i++)
                {
                    ListItem l1 = new ListItem(i.ToString(), i.ToString());
                    ddlQuantity.Items.Add(l1);
                }
                ddlQuantity.DataBind();
                ddlQuantity.Items.Insert(0, new ListItem("--Quantity--", "0"));
            }
            BusinessTier.DisposeReader(readerMenu);
            BusinessTier.DisposeConnection(connMenu);
        }
        catch (Exception ex)
        {
            //ShowMessage("Please Select the Installation Name", "Red");
        }

    }

    protected void ddlQuantityWithSize_Load()
    {
        try
        {
            String Insdate = DateTime.Now.ToString();
            DateTime dtinsDate = DateTime.Parse(Insdate);
            Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            SqlDataReader readerMenu = BusinessTier.getQtyWithSize(connMenu, @Param.ToString(), ddlSize.SelectedValue.ToString());
            if (readerMenu.Read())
            {
                int stock = 0;
                if (Convert.ToInt32(readerMenu["tstock"].ToString()) < 5)
                {
                    stock = Convert.ToInt32(readerMenu["tstock"].ToString());
                }
                else
                {
                    stock = 5;
                }
                for (int i = 1; i <= stock; i++)
                {
                    ListItem l1 = new ListItem(i.ToString(), i.ToString());
                    ddlQuantity.Items.Add(l1);


                }
                ddlQuantity.DataBind();
                ddlQuantity.Items.Insert(0, new ListItem("--Quantity--", "0"));
            }
            BusinessTier.DisposeReader(readerMenu);
            BusinessTier.DisposeConnection(connMenu);
        }
        catch (Exception ex)
        {
            //ShowMessage("Please Select the Installation Name", "Red");
        }

    }

    protected void ddlSize_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        divQuantity.Visible = true;
        ddlQuantity.Items.Clear();
        ddlQuantityWithSize_Load();
    }

    protected void btnAddCart_OnClick(object sender, EventArgs e)
    {
        //if (Request.Cookies["CustomerID"].Value.ToString() == "0")
        //{
        //    string @Param = string.Empty;
        //    @Param = Request.QueryString.Get("Param").ToString();
        //    Session["AddCart"] = @Param.ToString();
        //    if (string.IsNullOrEmpty(ddlSize.SelectedValue))
        //    {
        //        Session["pricingid"] = 0;
        //    }
        //    else { Session["pricingid"] = ddlSize.SelectedValue.ToString(); }

        //    Response.Redirect("Login.aspx?param=0", false);
        //    return;
        //}

        string BDID = Request.Cookies["BDID"].Value.ToString();

        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            int pricingid = 0;
            string sql = "select * from MasterPricing where productid='" + @Param.ToString() + "' and deleted=0";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hdqnty.Value = reader["Stock"].ToString();

                if (!(string.IsNullOrEmpty(reader["ProSize"].ToString())))
                {
                    if (ddlSize.Text.ToString() == "0")
                    {
                        lblstatus.Text = "** Please Select Any Size **";
                        return;
                    }
                }
            }
            BusinessTier.DisposeReader(reader);
            if (ddlQuantity.Text.ToString() == "0")
            {
                lblstatus.Text = "** Please Select Quantity **";
                return;
            }
            if (!(string.IsNullOrEmpty(ddlSize.Text.ToString())))
            {
                pricingid = Convert.ToInt32(ddlSize.SelectedValue.ToString().Trim());
            }

            //String Insdate = DateTime.Now.ToString();
            //DateTime dtinsDate = DateTime.Parse(Insdate);
            //Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
            SqlDataReader rd = BusinessTier.getDuplicate(conn, @Param, Request.Cookies["CustomerID"].Value.ToString(), Request.Cookies["BDID"].Value.ToString());
            if (rd.Read())
            {
                int AddcartID = Convert.ToInt32(rd["AddcartID"].ToString());
                int dtqty = Convert.ToInt32(rd["Qnty"].ToString());
                int qty = dtqty + Convert.ToInt32(ddlQuantity.Text.ToString());
                BusinessTier.DisposeReader(rd);
                if (qty >= Convert.ToInt32(hdqnty.Value))
                {
                    int flg = BusinessTier.AddCart(conn, AddcartID, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), pricingid, Convert.ToInt32(hdqnty.Value),BDID, Request.Cookies["CustomerID"].Value.ToString(), "U");
                }
                else
                {
                    int flg = BusinessTier.AddCart(conn, AddcartID, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), pricingid, qty, BDID, Request.Cookies["CustomerID"].Value.ToString(), "U");
                }
            }
            else
            {
                BusinessTier.DisposeReader(rd);
                int flg = BusinessTier.AddCart(conn, 1, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), pricingid, Convert.ToInt32(ddlQuantity.Text.ToString().Trim()),BDID, Request.Cookies["CustomerID"].Value.ToString(), "N");
            }
            BusinessTier.DisposeConnection(conn);
            Response.Redirect(Request.Url.PathAndQuery, true);
            //Response.Redirect("AddCart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString(), false);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Preview", "btnAddCart_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }

    }

    protected void btnCheck_OnClick(object sender, EventArgs e)
    {
        try
        {
            string val = BusinessTier.Findnull("Postcode", "distinct[STATE]", "POSTCODE", txtPincode.Text.ToString());
            if (val == "SRW" || val == "SBH" || val == "LBN")
            {
                lblPincode.Text = "** Delivery Available in State " + val.ToString() + " | Shipping Fee RM 11. **";
                lblPincode.ForeColor = Color.Green;
            }
            else if (string.IsNullOrEmpty(val.ToString()))
            {
                lblPincode.Text = "** Not Valid Pincode **";
                lblPincode.ForeColor = Color.Red;
            }
            else
            {
                lblPincode.Text = "** Delivery Available in State " + val.ToString() + " | Shipping Fee RM 5. **";
                lblPincode.ForeColor = Color.Green;

            }
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Preview", "btnCheck_OnClick", ex.ToString(), "Audit");
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CustomerID"].Value.ToString() == "0")
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            Session["AddCart"] = @Param.ToString();
            Response.Redirect("Login.aspx?param=0", false);
        }
        if (string.IsNullOrEmpty(HiddenField1.Value)) { HiddenField1.Value = "0"; }
        lblreviewstatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        string ProductID = Request.QueryString.Get("Param").ToString();

        if (string.IsNullOrEmpty(txtReviewtitle.Text.ToString()))
        {
            lblreviewstatus.Text = "** Please Fill Review title **";
            lblreviewstatus.ForeColor = Color.Red;
            return;
        }
        if (string.IsNullOrEmpty(txtReviewdescription.Text.ToString()))
        {

            lblreviewstatus.Text = "** Please Fill Review description **";
            lblreviewstatus.ForeColor = Color.Red;
            return;

        }
        int flg = BusinessTier.ProductReview(conn, 1, Convert.ToInt32(HiddenField1.Value), txtReviewtitle.Text.ToString().Trim(), txtReviewdescription.Text.ToString().Trim(), Convert.ToInt32(ProductID.ToString()), 0, Request.Cookies["CustomerID"].Value.ToString(), "N");
        BusinessTier.DisposeConnection(conn);
        lblreviewstatus.Text = "** Thank you! Successfully Submitted Your Review **";

        lblreviewstatus.ForeColor = Color.Green;
        //lblOrderNo.ToolTip = HiddenField1.Value;
    }

    protected void imgbtn_Click(object sender, EventArgs e)
    {

        if (Request.Cookies["CustomerID"].Value.ToString() == "0")
        {
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            Session["AddCart"] = @Param.ToString();
            Response.Redirect("Login.aspx", false);
            return;
        }
        SqlConnection inaipu = BusinessTier.getConnection();
        try
        {
            inaipu.Open();
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();


            int pricingid = 0;
            if (string.IsNullOrEmpty(ddlSize.SelectedValue.ToString()))
            {
                pricingid = 0;
            }
            else
            {
                pricingid = Convert.ToInt32(ddlSize.SelectedValue.ToString().Trim());
            }
            switch (hdWhish.Value)
            {
                case "0":
                    BusinessTier.AddWishlist(inaipu, 1, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString().Trim()), pricingid, Request.Cookies["CustomerID"].Value.ToString().Trim(), "N");
                    break;
                case "1":
                    BusinessTier.AddWishlist(inaipu, 1, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString().Trim()), pricingid, Request.Cookies["CustomerID"].Value.ToString().Trim(), "PU");
                    break;
                case "2":
                    BusinessTier.AddWishlist(inaipu, 1, Convert.ToInt32(@Param.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString().Trim()), pricingid, Request.Cookies["CustomerID"].Value.ToString().Trim(), "PUD");
                    break;

            }
            viruppaporul_yeatral();
        }
        finally { BusinessTier.DisposeConnection(inaipu); }
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }
}