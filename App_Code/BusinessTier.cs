using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Net;

using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Drawing;
using System.Xml;
using System.Web.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BusinessTier
{
    public BusinessTier()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable g_ErrorMessagesDataTable;

    public static SqlConnection getConnection()
    {
        string conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        return conn;
    }

    public static string getConnection1()
    {
        string conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        return conString;
    }

    public static void DisposeConnection(SqlConnection conn)
    {
        conn.Close();
        conn.Dispose();
    }

    public static void DisposeReader(SqlDataReader reader)
    {
        reader.Close();
        reader.Dispose();
    }

    public static void DisposeAdapter(SqlDataAdapter adapter)
    {
        adapter.Dispose();
    }

    public static SqlDataReader VaildateUserLogin(SqlConnection connec, string Logind, string Password, string Regno, string flag)
    {
        SqlCommand cmd = new SqlCommand("sp_Validate_UserLogin", connec);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Useridp", Logind);
        cmd.Parameters.AddWithValue("@Passp", Password);
        cmd.Parameters.AddWithValue("@Regno", Regno);
        cmd.Parameters.AddWithValue("@Flagp", flag);
        SqlDataReader reader1 = cmd.ExecuteReader();
        return reader1;
    }

    //--------------------------< Function For Master Check IS Duplicate >--------------------------------------

    public static string GetIPLocation(string ip)
    {
        //string IP = "";
        //IP = HttpContext.Current.Request.UserHostAddress;
        //Initializing a new xml document object to begin reading the xml file returned
        XmlDocument doc = new XmlDocument();
        doc.Load("http://www.freegeoip.net/xml/" + ip.ToString());
        XmlNodeList nodeIP = doc.GetElementsByTagName("IP");
        XmlNodeList nodeCity = doc.GetElementsByTagName("City");
        XmlNodeList nodeRegionName = doc.GetElementsByTagName("RegionName");
        XmlNodeList nodeRegionCode = doc.GetElementsByTagName("RegionCode");
        XmlNodeList nodeCountryName = doc.GetElementsByTagName("CountryName");
        XmlNodeList nodeCountryCode = doc.GetElementsByTagName("CountryCode");
        XmlNodeList nodeTimeZone = doc.GetElementsByTagName("TimeZone");
        XmlNodeList nodeLatitude = doc.GetElementsByTagName("Latitude");
        XmlNodeList nodeLongitude = doc.GetElementsByTagName("Longitude");
        XmlNodeList nodeMetroCode = doc.GetElementsByTagName("MetroCode");
        SqlConnection con = BusinessTier.getConnection();
        con.Open();
        string sql = "select HitCounter from GetIPLocation where DELETED=0 and IP='" + nodeIP[0].InnerText.ToString().Trim() + "' ";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader reader = cmd.ExecuteReader();
        string hit = "0";
        if (reader.Read())
        {
            int HitCounter = Convert.ToInt32(reader["HitCounter"].ToString());
            HitCounter = HitCounter + 1;
            hit = HitCounter.ToString();
            DisposeReader(reader);
            InsertIPLocation(con, 1, nodeIP[0].InnerText.ToString(), nodeCity[0].InnerText.ToString(), nodeRegionName[0].InnerText.ToString(), nodeRegionCode[0].InnerText.ToString(), nodeCountryName[0].InnerText.ToString(), nodeCountryCode[0].InnerText.ToString(), nodeTimeZone[0].InnerText.ToString(), nodeLatitude[0].InnerText.ToString(), nodeLongitude[0].InnerText.ToString(), nodeMetroCode[0].InnerText.ToString(), HitCounter, "1", "U");
        }
        else
        {
            DisposeReader(reader);
            InsertIPLocation(con, 1, nodeIP[0].InnerText.ToString(), nodeCity[0].InnerText.ToString(), nodeRegionName[0].InnerText.ToString(), nodeRegionCode[0].InnerText.ToString(), nodeCountryName[0].InnerText.ToString(), nodeCountryCode[0].InnerText.ToString(), nodeTimeZone[0].InnerText.ToString(), nodeLatitude[0].InnerText.ToString(), nodeLongitude[0].InnerText.ToString(), nodeMetroCode[0].InnerText.ToString(), 1, "1", "N");
        }


        DisposeConnection(con);
        return hit.ToString();
    }

    public static int InsertIPLocation(SqlConnection conn, int IPLocationID, string IP, string City, string RegionName, string RegionCode, string CountryName, string CountryCode, string TimeZone, string Latitude, string Longitude, string MetroCode, int HitCounter, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_GetIPLocation]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@IPLocationID", IPLocationID);
        dCmd.Parameters.AddWithValue("@IP", IP);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@RegionName", RegionName);
        dCmd.Parameters.AddWithValue("@RegionCode", RegionCode);
        dCmd.Parameters.AddWithValue("@CountryName", CountryName);
        dCmd.Parameters.AddWithValue("@CountryCode", CountryCode);
        dCmd.Parameters.AddWithValue("@TimeZone", TimeZone);
        dCmd.Parameters.AddWithValue("@Latitude", Latitude);
        dCmd.Parameters.AddWithValue("@Longitude", Longitude);
        dCmd.Parameters.AddWithValue("@MetroCode", MetroCode);
        dCmd.Parameters.AddWithValue("@HitCounter", HitCounter);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static SqlDataReader IDCheck(SqlConnection con, string ID, string Flag)
    {
        SqlCommand cmd = new SqlCommand("sp_Master_IsDuplicate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Flag", Flag);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static string GetMsg(string Name, string email)

    {
        string msg = string.Empty;
        msg = "<style>.btn {  font-family: arial;  color: #000000 !important;  font-size: 13px;  padding: 10px 25px;  background: #63B8EE;} .btn:hover {  color: #14396A !important;  background: #468CCF;}</style><font face='Cambria Math'><b>Welcome, " + Name.ToString() + " !</b><br><br>" + "Thank you very much for signing up with EasyBuyBye! We have incredible deals waiting for you but before that, please click the button below to validate your email so we know you’re really you.<br><br>";
        msg = msg + "<div style='width:100%; text-align:center'><a href=" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "EmailVerification.aspx?Param=" + email.ToString().Trim() + "><input id='Button1' type='button' value='Click Here to validate your email' /></a><br></div>";
        msg = msg + "<p>If you need help at any point during your shopping journey with us, please do not hesitate to get in touch immediately. Our most up-to-date contact details are posted on our website. We’re here for you and we’re glad to have you with us. (Don’t forget to validate, ok?).</p>";
        msg = msg + "<b>Thank you! </b><br> <a href='https://www.easybuybye.com/index.aspx' style='text-decoration: none'><img src='" + ConfigurationManager.AppSettings["ImagePath"].ToString() + "web/images/MailLogo.png' alt='' /></a><br><b>Team EasyBuyBye</b><br></font>";

        return msg;
    }

    //--------------------------< Function For Master Module >--------------------------------------

    public static int DeleteTables(SqlConnection conn, int ID, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_DeleteTables]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@ID", ID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int DeleteGrid(SqlConnection conn, string table, string field, int ID, string userid)
    {
        string sql = "update " + table.ToString() + " set deleted = 1,MODIFIED_DATE='" + DateTime.Now + "' ,Modified_by = " + userid.ToString() + " where " + field.ToString() + " = " + ID.ToString() + "";
        SqlCommand dCmd = new SqlCommand(sql, conn);
        return dCmd.ExecuteNonQuery();
    }

    public static int BasicCategory(SqlConnection conn, int BasicCategoryID, string BasicCategory, int Priority, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_BasicCategory", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@BasicCategoryID", BasicCategoryID);
        dCmd.Parameters.AddWithValue("@BasicCategory", BasicCategory);
        dCmd.Parameters.AddWithValue("@Priority", Priority);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Category(SqlConnection conn, int CategoryID, string Category, string BasicCategoryID, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_CategoryMaster", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
        dCmd.Parameters.AddWithValue("@Category", Category);
        dCmd.Parameters.AddWithValue("@BasicCategoryID", BasicCategoryID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int FeatureProduct(SqlConnection conn, int FeatureProductID, int ProductID, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_FeatureProduct", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@FeatureProductID", FeatureProductID);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Offers(SqlConnection conn, int OfferID, string OfferName, string Type, decimal ReducePrice, int ShowSeller, string FromDate, string ToDate, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_Offers", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@OfferID", OfferID);
        dCmd.Parameters.AddWithValue("@OfferName", OfferName);
        dCmd.Parameters.AddWithValue("@Type", Type);
        dCmd.Parameters.AddWithValue("@ReducePrice", ReducePrice);
        dCmd.Parameters.AddWithValue("@ShowSeller", ShowSeller);
        dCmd.Parameters.AddWithValue("@FromDate", FromDate);
        dCmd.Parameters.AddWithValue("@ToDate", ToDate);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Redirectpage(SqlConnection conn, int RedirectID, string Email, string Redirectlink, string Generatelink, string Clicked, string ClickedTime, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_Redirectpage", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@RedirectID", RedirectID);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@Redirectlink", Redirectlink);
        dCmd.Parameters.AddWithValue("@Generatelink", Generatelink);
        dCmd.Parameters.AddWithValue("@Clicked", Clicked);
        dCmd.Parameters.AddWithValue("@ClickedTime", ClickedTime);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Catalog(SqlConnection conn, int Catalogid, string Indate, string CatalogName, int QtyIn, decimal UnitPrice, decimal TotalPrice, int Damage, string Remarks, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_CatalogMaster", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@Catalogid", Catalogid);
        dCmd.Parameters.AddWithValue("@Indate", Indate);
        dCmd.Parameters.AddWithValue("@CatalogName", CatalogName);
        dCmd.Parameters.AddWithValue("@QtyIn", QtyIn);
        dCmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
        dCmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
        dCmd.Parameters.AddWithValue("@Damage", Damage);
        dCmd.Parameters.AddWithValue("@Remarks", Remarks);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Quotation(SqlConnection conn, int QuotationID, string QuotationNo, string Indate, string Name, string Mobile, string Company, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_Quotation", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@QuotationID", QuotationID);
        dCmd.Parameters.AddWithValue("@QuotationNo", QuotationNo);
        dCmd.Parameters.AddWithValue("@Indate", Indate);
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@Mobile", Mobile);
        dCmd.Parameters.AddWithValue("@Company", Company);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int QuotationDetails(SqlConnection conn, int QuotationDetails, int QuotationID, string Description, int QtyIn, decimal UnitPrice, decimal TotalPrice, decimal GST, decimal GrandTotal, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("sp_QuotationDetails", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@QuotationDetailsID", QuotationDetails);
        dCmd.Parameters.AddWithValue("@QuotationID", QuotationID);
        dCmd.Parameters.AddWithValue("@Description", Description);
        dCmd.Parameters.AddWithValue("@QtyIn", QtyIn);
        dCmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
        dCmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
        dCmd.Parameters.AddWithValue("@GST", GST);
        dCmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Product(SqlConnection conn, int ProductID, int CategoryID, string Brand, string Model, decimal ActualPrice, int Discount, decimal DiscountPrice, decimal SellingPrice, decimal ShippingCost, string imagePath, string Details, int Weight, string URL, string CatalogName, int SupplierID, string userid, string Flagp, int singapore, decimal sgcutprice, decimal sgprice)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ProductMaster]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
        dCmd.Parameters.AddWithValue("@Brand", Brand);
        dCmd.Parameters.AddWithValue("@Model", Model);
        dCmd.Parameters.AddWithValue("@ActualPrice", ActualPrice);
        dCmd.Parameters.AddWithValue("@Discount", Discount);
        dCmd.Parameters.AddWithValue("@DiscountPrice", DiscountPrice);
        dCmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
        dCmd.Parameters.AddWithValue("@ShippingCost", ShippingCost);
        dCmd.Parameters.AddWithValue("@imagePath", imagePath);
        dCmd.Parameters.AddWithValue("@Details", Details);
        dCmd.Parameters.AddWithValue("@Weight", Weight);
        dCmd.Parameters.AddWithValue("@URL", URL);
        dCmd.Parameters.AddWithValue("@CatalogName", CatalogName);
        dCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        dCmd.Parameters.AddWithValue("@singapore", singapore);
        dCmd.Parameters.AddWithValue("@sgcutprice", sgcutprice);
        dCmd.Parameters.AddWithValue("@sgprice", sgprice);
        return dCmd.ExecuteNonQuery();
    }

    public static int Bazzaae_Product(SqlConnection conn, int ProductID, int CategoryID, string Brand, string Model, decimal ActualPrice, int Discount, decimal DiscountPrice, decimal SellingPrice, decimal ShippingCost, string imagePath, string Details, int Weight, string URL, string CatalogName, int SupplierID, string userid, string Flagp, int singapore, decimal sgcutprice, decimal sgprice, int IsCOD, string NewProduct, string NewBrandColor)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Bazzaar_ProductMaster]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
        dCmd.Parameters.AddWithValue("@Brand", Brand);
        dCmd.Parameters.AddWithValue("@Model", Model);
        dCmd.Parameters.AddWithValue("@ActualPrice", ActualPrice);
        dCmd.Parameters.AddWithValue("@Discount", Discount);
        dCmd.Parameters.AddWithValue("@DiscountPrice", DiscountPrice);
        dCmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
        dCmd.Parameters.AddWithValue("@ShippingCost", ShippingCost);
        dCmd.Parameters.AddWithValue("@imagePath", imagePath);
        dCmd.Parameters.AddWithValue("@Details", Details);
        dCmd.Parameters.AddWithValue("@Weight", Weight);
        dCmd.Parameters.AddWithValue("@URL", URL);
        dCmd.Parameters.AddWithValue("@CatalogName", CatalogName);
        dCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        dCmd.Parameters.AddWithValue("@singapore", singapore);
        dCmd.Parameters.AddWithValue("@sgcutprice", sgcutprice);
        dCmd.Parameters.AddWithValue("@sgprice", sgprice);

        // @IsCOD
        dCmd.Parameters.AddWithValue("@IsCOD", IsCOD);
        dCmd.Parameters.AddWithValue("@NewProductName", NewProduct);
        dCmd.Parameters.AddWithValue("@NewModelColor", NewBrandColor);


        return dCmd.ExecuteNonQuery();
    }
        
    public static int ProductItem(SqlConnection conn, int ProductItemID, int ProductID, int TotalStock, string Image1, string Image2, string Image3, string Image4, string Image5, int Approve, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ItemProduct]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@ProductItemID", ProductItemID);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@TotalStock", TotalStock);
        dCmd.Parameters.AddWithValue("@Image1", Image1);
        dCmd.Parameters.AddWithValue("@Image2", Image2);
        dCmd.Parameters.AddWithValue("@Image3", Image3);
        dCmd.Parameters.AddWithValue("@Image4", Image4);
        dCmd.Parameters.AddWithValue("@Image5", Image5);
        dCmd.Parameters.AddWithValue("@Approve", Approve);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int AddStock(SqlConnection conn, int PricingID, int ProductID, string ProColor, string ProSize, string Stock, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_AddStock]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@PricingID", PricingID);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@ProColor", ProColor);
        dCmd.Parameters.AddWithValue("@ProSize", ProSize);
        dCmd.Parameters.AddWithValue("@Stock", Stock);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int AddAdress(SqlConnection conn, int AddressId, string Name, string Mobile, string Email, string Address1, string Address2, string Address3, string Postcode, string City, string State, string Country, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_MasterAddress]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@AddressId", AddressId);
        dCmd.Parameters.AddWithValue("@Name", Name);

        dCmd.Parameters.AddWithValue("@Mobile", Mobile);
        dCmd.Parameters.AddWithValue("@Email", Email);

        dCmd.Parameters.AddWithValue("@Address1", Address1);
        dCmd.Parameters.AddWithValue("@Address2", Address2);
        dCmd.Parameters.AddWithValue("@Address3", Address3);

        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int ExpressBuy(SqlConnection conn, string Name, string Mobile, string Email, string Address1, string Address2, string Address3, string Postcode, string City, string State, string Country, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ExpressBuy]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
      
        dCmd.Parameters.AddWithValue("@Name", Name);

        dCmd.Parameters.AddWithValue("@Mobile", Mobile);
        dCmd.Parameters.AddWithValue("@Email", Email);

        dCmd.Parameters.AddWithValue("@Address1", Address1);
        dCmd.Parameters.AddWithValue("@Address2", Address2);
        dCmd.Parameters.AddWithValue("@Address3", Address3);

        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);
      
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }
    
    public static int ProductReview(SqlConnection conn, int ReviewID, int Rate, string ReviewTitle, string ProductReview, int ProductID, int Approve, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ProductReview]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ReviewID", ReviewID);
        dCmd.Parameters.AddWithValue("@Rate", Rate);
        dCmd.Parameters.AddWithValue("@ReviewTitle", ReviewTitle);

        dCmd.Parameters.AddWithValue("@ProductReview", ProductReview);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);

        dCmd.Parameters.AddWithValue("@Approve", Approve);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Promotion(SqlConnection conn, int PromotionID, string PromotionCode, string Description, string Type, decimal Discount, decimal Total, string FromDate, string ToDate, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_PromotionMaster]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@PromotionID", PromotionID);
        dCmd.Parameters.AddWithValue("@PromotionCode", PromotionCode);

        dCmd.Parameters.AddWithValue("@Description", Description);
        dCmd.Parameters.AddWithValue("@Type", Type);

        dCmd.Parameters.AddWithValue("@Discount", Discount);
        dCmd.Parameters.AddWithValue("@Total", Total);
        dCmd.Parameters.AddWithValue("@FromDate", FromDate);

        dCmd.Parameters.AddWithValue("@ToDate", ToDate);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Feedback(SqlConnection conn, int FeedbackID, string Feedback, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_MasterFeedback]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@FeedbackID", FeedbackID);
        dCmd.Parameters.AddWithValue("@Feedback", Feedback);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Distributor(SqlConnection conn, int @Dist_ID, string @Dist_Name, string @Dist_Address, string @Dist_Phone, string @Dist_Company, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Distributor]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@Dist_ID", @Dist_ID);
        dCmd.Parameters.AddWithValue("@Dist_Name", @Dist_Name);
        dCmd.Parameters.AddWithValue("@Dist_Address", @Dist_Address);
        dCmd.Parameters.AddWithValue("@Dist_Phone", @Dist_Phone);
        dCmd.Parameters.AddWithValue("@Dist_Company", @Dist_Company);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int SupplierDetails(SqlConnection conn, int SupplierID, string SupplierName, string PersonIncharge, string Mobile, string Fax, string Email, string Address1, string Address2, string PostCode, string City, string State, string Country, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_SupplierDetails]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
        dCmd.Parameters.AddWithValue("@SupplierName", SupplierName);
        dCmd.Parameters.AddWithValue("@PersonIncharge", PersonIncharge);
        dCmd.Parameters.AddWithValue("@Mobile", Mobile);
        dCmd.Parameters.AddWithValue("@Fax", Fax);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@Address1", Address1);

        dCmd.Parameters.AddWithValue("@Address2", Address2);
        dCmd.Parameters.AddWithValue("@PostCode", PostCode);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int CustomerMaster(SqlConnection conn, int CustomerID, string CustomerName, string Email, int Contactno, string Address, string Password, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_CustomerMaster]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        dCmd.Parameters.AddWithValue("@CustomerName", CustomerName);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@Contactno", Contactno);
        dCmd.Parameters.AddWithValue("@Address", Address);
        dCmd.Parameters.AddWithValue("@Password", Password);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int SupplierMaster(SqlConnection conn, int SupplierID, string SupplierName, string Email, int BusinessID, string Address, string Password, string ProductName, decimal ActualPrice, decimal SellingPrice, decimal Profit, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_SupplierMaster]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
        dCmd.Parameters.AddWithValue("@SupplierName", SupplierName);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@BusinessID", BusinessID);
        dCmd.Parameters.AddWithValue("@Address", Address);
        dCmd.Parameters.AddWithValue("@Password", Password);

        dCmd.Parameters.AddWithValue("@ProductName", ProductName);
        dCmd.Parameters.AddWithValue("@ActualPrice", ActualPrice);
        dCmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
        dCmd.Parameters.AddWithValue("@Profit", Profit);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int BusinessRegister(SqlConnection conn, int BusinessID, string BusinessName, string Regno, string Name, string ICno, string Contactno, string Email, string Address, string Password, string Bankname, string AccHdrName, string Accountno, string BranchName, string Settlement, int Approve, string MyKad, string bankstatement, string utilitiesbill, string form9, string form49, string GSTApproval, string State, string Country, int Postcode, int ISDCode, string RegistrationType, string SWIFTcode, string Gender, string DOB, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_BusinessRegister]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@BusinessID", BusinessID);
        dCmd.Parameters.AddWithValue("@BusinessName", BusinessName);
        dCmd.Parameters.AddWithValue("@Regno", Regno);
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@ICno", ICno);
        dCmd.Parameters.AddWithValue("@Contactno", Contactno);
        dCmd.Parameters.AddWithValue("@Email", Email);

        dCmd.Parameters.AddWithValue("@Address", Address);
        dCmd.Parameters.AddWithValue("@Password", Password);
        dCmd.Parameters.AddWithValue("@Bankname", Bankname);
        dCmd.Parameters.AddWithValue("@AccHdrName", AccHdrName);
        dCmd.Parameters.AddWithValue("@Accountno", Accountno);
        dCmd.Parameters.AddWithValue("@BranchName", BranchName);
        dCmd.Parameters.AddWithValue("@Settlement", Settlement);

        dCmd.Parameters.AddWithValue("@Approve", Approve);

        dCmd.Parameters.AddWithValue("@MyKad", MyKad);
        dCmd.Parameters.AddWithValue("@bankstatement", bankstatement);
        dCmd.Parameters.AddWithValue("@utilitiesbill", utilitiesbill);
        dCmd.Parameters.AddWithValue("@form9", form9);
        dCmd.Parameters.AddWithValue("@form49", form49);
        dCmd.Parameters.AddWithValue("@GSTApproval", GSTApproval);

        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);
        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@ISDCode", ISDCode);
        dCmd.Parameters.AddWithValue("@RegistrationType", RegistrationType);
        dCmd.Parameters.AddWithValue("@SWIFTcode", SWIFTcode);

        dCmd.Parameters.AddWithValue("@Gender", Gender);
        dCmd.Parameters.AddWithValue("@DOB", DOB);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int SellerRegister(SqlConnection conn, int SellerID, string BusinessName, string Regno, string Name, string ICno, string Contactno, string Email, string Address, string Password, string Bankname, string AccHdrName, string Accountno, string BranchName, string Settlement, int Approve, string MyKad, string bankstatement, string utilitiesbill, string form9, string form49, string GSTApproval, string State, string Country, int Postcode, int ISDCode, string RegistrationType, string SWIFTcode, string Gender, string DOB, string AboutProduct, string Courier, string CourierACno, string PromoCode,string City, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_SellerRegister]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@SellerID", SellerID);
        dCmd.Parameters.AddWithValue("@BusinessName", BusinessName);
        dCmd.Parameters.AddWithValue("@Regno", Regno);
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@ICno", ICno);
        dCmd.Parameters.AddWithValue("@Contactno", Contactno);
        dCmd.Parameters.AddWithValue("@Email", Email);

        dCmd.Parameters.AddWithValue("@Address", Address);
        dCmd.Parameters.AddWithValue("@Password", Password);
        dCmd.Parameters.AddWithValue("@Bankname", Bankname);
        dCmd.Parameters.AddWithValue("@AccHdrName", AccHdrName);
        dCmd.Parameters.AddWithValue("@Accountno", Accountno);
        dCmd.Parameters.AddWithValue("@BranchName", BranchName);
        dCmd.Parameters.AddWithValue("@Settlement", Settlement);

        dCmd.Parameters.AddWithValue("@Approve", Approve);

        dCmd.Parameters.AddWithValue("@MyKad", MyKad);
        dCmd.Parameters.AddWithValue("@bankstatement", bankstatement);
        dCmd.Parameters.AddWithValue("@utilitiesbill", utilitiesbill);
        dCmd.Parameters.AddWithValue("@form9", form9);
        dCmd.Parameters.AddWithValue("@form49", form49);
        dCmd.Parameters.AddWithValue("@GSTApproval", GSTApproval);

        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);
        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@ISDCode", ISDCode);
        dCmd.Parameters.AddWithValue("@RegistrationType", RegistrationType);
        dCmd.Parameters.AddWithValue("@SWIFTcode", SWIFTcode);

        dCmd.Parameters.AddWithValue("@Gender", Gender);
        dCmd.Parameters.AddWithValue("@DOB", DOB);
        dCmd.Parameters.AddWithValue("@AboutProduct", AboutProduct);

        dCmd.Parameters.AddWithValue("@Courier", Courier);
        dCmd.Parameters.AddWithValue("@CourierACno", CourierACno);
        dCmd.Parameters.AddWithValue("@PromoCode", PromoCode);
        dCmd.Parameters.AddWithValue("@City", City);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        dCmd.ExecuteNonQuery();
        return 3;
    }

    public static int AddCart(SqlConnection conn, int AddcartID, int ProductID, int CustomerID, int pricingid, int Qnty,string BDID, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_AddCart]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@AddcartID", AddcartID);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        dCmd.Parameters.AddWithValue("@PricingID", pricingid);
        dCmd.Parameters.AddWithValue("@Qnty", Qnty);
        dCmd.Parameters.AddWithValue("@BDID", BDID);
        dCmd.Parameters.AddWithValue("@useridp", userid);       
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int AddCartReturnCancel(SqlConnection conn, string OrderNo, string RunningNo, string CancelReturnReason, string Reimburse, string BankingType, string AccountName, string AccountNumber, string BankName, string Branch, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_AddCartReturnCancel]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@OrderNo", OrderNo);
        dCmd.Parameters.AddWithValue("@RunningNo", RunningNo);
        dCmd.Parameters.AddWithValue("@CancelReturnReason", CancelReturnReason);
        dCmd.Parameters.AddWithValue("@Reimburse", Reimburse);
        dCmd.Parameters.AddWithValue("@BankingType", BankingType);
        dCmd.Parameters.AddWithValue("@AccountName", AccountName);
        dCmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
        dCmd.Parameters.AddWithValue("@BankName", BankName);
        dCmd.Parameters.AddWithValue("@Branch", Branch);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }
       
    public static int AddWishlist(SqlConnection conn, int WishlistID, int ProductID, int CustomerID, int PricingID, string userid, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Wishlist]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@WishlistID", WishlistID);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        dCmd.Parameters.AddWithValue("@PricingID", PricingID);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int NewUser(SqlConnection conn, string Name, string Email, string userid)
    {
        SqlCommand dCmd = new SqlCommand("[sp_NewUser]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@userid", userid);
        
        return dCmd.ExecuteNonQuery();
    }
    
    public static SqlDataReader getMasterModule(SqlConnection conn)
    {
        int delval = 0;
        string sql = "select * FROM Menulist ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader FindDuplicate(SqlConnection connect, string table, string field1, string cond1)
    {
        string sql = "select * FROM " + table + " WHERE Deleted=0 and " + field1 + "='" + cond1 + "'";
        SqlCommand cmd = new SqlCommand(sql, connect);
        SqlDataReader reader1 = cmd.ExecuteReader();
        return reader1;
    }

    public static SqlDataReader Find2Duplicate(SqlConnection connect, string table, string field1, string cond1, string field2, string cond2)
    {

        string sql = "select * FROM " + table + " WHERE Deleted=0 and " + field1 + "='" + cond1 + "' and " + field2 + "='" + cond2 + "'";
        SqlCommand cmd = new SqlCommand(sql, connect);
        SqlDataReader reader1 = cmd.ExecuteReader();
        return reader1;
    }

    public static SqlDataReader getMasterModuleById(SqlConnection connect, string strModuleId)
    {
        int delval = 0;
        string sql = "select * FROM MasterModule WHERE Deleted='" + delval + "' and ModuleId='" + strModuleId + "' ORDER BY ModuleId";
        SqlCommand cmd = new SqlCommand(sql, connect);
        SqlDataReader reader1 = cmd.ExecuteReader();
        return reader1;
    }

    public static int DeleteModuleGrid(SqlConnection conn, string id)
    {
        SqlCommand dCmd = new SqlCommand("sp_MasterModule_Delete", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@moduleidp", id);
        return dCmd.ExecuteNonQuery();
    }

    public static SqlDataReader checkModuleName(SqlConnection connCheck, string name)
    {
        SqlCommand cmd = new SqlCommand("sp_MasterModule_IsDuplicate", connCheck);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@modulenamep", name);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static void ddlDataLoad(DropDownList ddl, string Table, string Field1, string Field2, string Placeholder)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT * from " + Table + " where deleted=0");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = Field1;
        ddl.DataValueField = Field2;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static void ddlSelectedDataLoad(DropDownList ddl, string Table, string Field1, string Field2, string Placeholder, string Field3, string id)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT * from " + Table + " where deleted=0 and " + Field3 + "=" + id + "");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = Field1;
        ddl.DataValueField = Field2;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static void ddlSelectedDataLoad2(DropDownList ddl, string Field, string id1, string id2, string Placeholder)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT Distinct Brand,categoryid  from  MasterProducts where deleted=0 and " + Field + "=" + id1 + " and CREATED_BY=" + id2 + " group by CategoryID,Brand");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = "Brand";
        ddl.DataValueField = "Brand";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static void ddlSelectedDataLoad3(DropDownList ddl, string Field, string id1, string id2, string Placeholder)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT Model,productid  from  MasterProducts where deleted=0 and " + Field + "='" + id1 + "' and CREATED_BY=" + id2 + "");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = "Model";
        ddl.DataValueField = "productid";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static int SaveModuleMaster(SqlConnection conn, string name, string desc, string appflag, string userid, string saveflag, string modid)
    {
        string sp_Name;
        string RowValue = "0";
        if (saveflag.ToString() == "N")
        {
            sp_Name = "[sp_MasterModule_Insert]";
        }
        else
        {
            sp_Name = "[sp_MasterModule_Update]";
        }
        SqlCommand dCmd = new SqlCommand(sp_Name, conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        if (saveflag.ToString() == "U")
        {
            dCmd.Parameters.AddWithValue("@idp", modid);
            dCmd.Parameters.AddWithValue("@Rowp", RowValue);
        }
        dCmd.Parameters.AddWithValue("@namep", name);
        dCmd.Parameters.AddWithValue("@descriptionp", desc);
        dCmd.Parameters.AddWithValue("@approvalflag", appflag);
        dCmd.Parameters.AddWithValue("@useridp", userid);
        return dCmd.ExecuteNonQuery();
    }

    public static int GLogin(SqlConnection conn, int GLoginID, string Gname, string Gmail, string GID, string GImg,string LogWith, string userid, string Flag)
    {
        SqlCommand dCmd = new SqlCommand("[sp_GLogin]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@GLoginID", GLoginID);
        dCmd.Parameters.AddWithValue("@Gname", Gname);
        dCmd.Parameters.AddWithValue("@Gmail", Gmail);
        dCmd.Parameters.AddWithValue("@GID", GID);
        dCmd.Parameters.AddWithValue("@GImg", GImg);
        dCmd.Parameters.AddWithValue("@LogWith", LogWith);
        dCmd.Parameters.AddWithValue("@userid", userid);
        dCmd.Parameters.AddWithValue("@Flag", Flag);
        return dCmd.ExecuteNonQuery();
    }
    //--------------------------< Function For Master User >--------------------------------------

    private static void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = getConnection();
        connLog.Open();
        InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        DisposeConnection(connLog);       
    }

    public static SqlDataReader getMasterUserInfo(SqlConnection conn)
    {
        int delval = 0;
        string sql = "select * FROM Vw_MasterUser_Staff WHERE Deleted='" + delval + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getMasterUserByID(SqlConnection conn, string strID)
    {
        int delval = 0;
        string sql = "select * FROM Vw_MasterUser_Staff WHERE ID='" + strID + "' and  Deleted='" + delval + "' ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getUserNameByID(SqlConnection conn, string strID)
    {
        SqlCommand cmd = new SqlCommand("[sp_MasterUser_getUserName]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idp", strID);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static string getMasterUserIDByName(SqlConnection conn, string strName)
    {
        int delval = 0;
        string sql = "select ID FROM Vw_MasterUser_Staff WHERE UserName like '%" + strName + "%' and  Deleted='" + delval + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        string ret = reader[0].ToString();
        BusinessTier.DisposeReader(reader);
        //BusinessTier.DisposeConnection(conn);
        return ret;
    }

    public static SqlDataReader getMasterUserByLoginId(SqlConnection conn, string strLoginId)
    {
        int delval = 0;
        string sql = "select * FROM Vw_MasterUser_Staff WHERE Deleted='" + delval + "' and LoginId='" + strLoginId + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getMasterModulePermisnByUserId(SqlConnection connModulePermission, string strUserId)
    {
        int delval = 0;
        string sql = "select * FROM vw_MasterModulePermission_MasterModuleByModuleID WHERE Deleted='" + delval + "' and UserId='" + strUserId.ToString() + "' order by modulename";
        SqlCommand cmd = new SqlCommand(sql, connModulePermission);
        SqlDataReader readerModulePermission = cmd.ExecuteReader();
        return readerModulePermission;
    }

    public static int DeleteUserGrid(SqlConnection conn, string id)
    {
        SqlCommand dCmd = new SqlCommand("[sp_MasterUser_Delete]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@masteruseridp", id);
        return dCmd.ExecuteNonQuery();
    }

    public static int AddCourierID(SqlConnection conn, string orderno)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Courier]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@orderno", orderno);
        return dCmd.ExecuteNonQuery();
    }

    public static int AddCart_CustomerID_Update(SqlConnection conn, string BDID, string userid)
    {
        SqlCommand dCmd = new SqlCommand("[sp_AddCart_CustomerID_Update]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@BDID", BDID);
        dCmd.Parameters.AddWithValue("@userid", userid);
        return dCmd.ExecuteNonQuery();
    }

    public static int SaveUserMaster(SqlConnection connSave, int intstaffid, string strloginid, string strpass, string strCreatedByID, string strSaveFlag, string strCurrUserId)
    {
        string sp_Name;
        if (strSaveFlag.ToString() == "Insert")
        {
            sp_Name = "[sp_MasterUser_Insert]";
        }
        else
        {
            sp_Name = "[sp_MasterUser_Update]";
        }
        SqlCommand dCmd = new SqlCommand(sp_Name, connSave);
        dCmd.CommandType = CommandType.StoredProcedure;
        if (strSaveFlag.ToString() == "Update")
        {
            dCmd.Parameters.AddWithValue("@idp", strCurrUserId);
        }
        dCmd.Parameters.AddWithValue("@loginidp", strloginid);
        dCmd.Parameters.AddWithValue("@passp", strpass);
        dCmd.Parameters.AddWithValue("@Staffidp", intstaffid);
        // dCmd.Parameters.AddWithValue("@isapprovalrqrdp", strapprqrd);
        //  dCmd.Parameters.AddWithValue("@isnotifyrqrd", strnotifyrqrd);
        dCmd.Parameters.AddWithValue("@useridp", strCreatedByID);
        return dCmd.ExecuteNonQuery();
    }

    public static int InsertShippingAddress(SqlConnection connSave, int ShippingID, string Name, string Mobile, string Email, string Address1, string Address2, string Address3, string Postcode, string City, string State, string Country, string CustomerID, string PromotionID, string sentamount, string breakamount, int AgentID,decimal EBBShippingAmount,string useridp, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ShippingAddress]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ShippingID", ShippingID);
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@Mobile", Mobile);
        dCmd.Parameters.AddWithValue("@Email", Email);
        dCmd.Parameters.AddWithValue("@Address1", Address1);
        dCmd.Parameters.AddWithValue("@Address2", Address2);
        dCmd.Parameters.AddWithValue("@Address3", Address3);

        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);
        dCmd.Parameters.AddWithValue("@CustomerID", CustomerID);

        dCmd.Parameters.AddWithValue("@PromotionID", PromotionID);
        dCmd.Parameters.AddWithValue("@breakamount", breakamount);
        dCmd.Parameters.AddWithValue("@sentamount", sentamount);
        dCmd.Parameters.AddWithValue("@AgentID", AgentID);
        dCmd.Parameters.AddWithValue("@EBBShippingAmount", EBBShippingAmount);
        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int BankStatement(SqlConnection connSave, string ShippingID, string MerchantCode, string RefNo, string Amount, string Currency, string ProdDesc, string UserName, string UserEmail, string UserContact, string Remark, string Signature, string useridp, string Flagp)
    {

        SqlCommand dCmd = new SqlCommand("[sp_BankStatement]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ShippingID", ShippingID);
        dCmd.Parameters.AddWithValue("@MerchantCode", MerchantCode);
        dCmd.Parameters.AddWithValue("@RefNo", RefNo);
        dCmd.Parameters.AddWithValue("@Amount", Amount);
        dCmd.Parameters.AddWithValue("@Currency", Currency);
        dCmd.Parameters.AddWithValue("@ProdDesc", ProdDesc);
        dCmd.Parameters.AddWithValue("@UserName", UserName);

        dCmd.Parameters.AddWithValue("@UserEmail", UserEmail);
        dCmd.Parameters.AddWithValue("@UserContact", UserContact);
        dCmd.Parameters.AddWithValue("@Remark", Remark);
        dCmd.Parameters.AddWithValue("@Signature", Signature);

        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int Ticket(SqlConnection connSave, string TicketID, string MerchantCode, string RefNo, string Amount, string Currency, string ProdDesc, string UserName, string UserEmail, string UserContact, string Remark, string Signature, string TransId, string AuthCode, string Status, string ErrDesc, string ReturnSignature, string useridp, string Flagp)
    {

        SqlCommand dCmd = new SqlCommand("[sp_Ticket]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@TicketID", TicketID);
        dCmd.Parameters.AddWithValue("@MerchantCode", MerchantCode);
        dCmd.Parameters.AddWithValue("@RefNo", RefNo);
        dCmd.Parameters.AddWithValue("@Amount", Amount);
        dCmd.Parameters.AddWithValue("@Currency", Currency);
        dCmd.Parameters.AddWithValue("@ProdDesc", ProdDesc);
        dCmd.Parameters.AddWithValue("@UserName", UserName);

        dCmd.Parameters.AddWithValue("@UserEmail", UserEmail);
        dCmd.Parameters.AddWithValue("@UserContact", UserContact);
        dCmd.Parameters.AddWithValue("@Remark", Remark);
        dCmd.Parameters.AddWithValue("@Signature", Signature);

        dCmd.Parameters.AddWithValue("@TransId", TransId);
        dCmd.Parameters.AddWithValue("@AuthCode", AuthCode);
        dCmd.Parameters.AddWithValue("@Status", Status);
        dCmd.Parameters.AddWithValue("@ErrDesc", ErrDesc);
        dCmd.Parameters.AddWithValue("@ReturnSignature", ReturnSignature);

        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int OrderConfirmationMOL(SqlConnection connSave, string ShippingID, string tranID, string orderid, string status, string merchantID, string amount, string currency, string paydate, string appcode, string skey, string verifyKey, string useridp, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_OrderConfrimation]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ShippingID", ShippingID);
        dCmd.Parameters.AddWithValue("@tranID", tranID);
        dCmd.Parameters.AddWithValue("@orderid", orderid);
        dCmd.Parameters.AddWithValue("@status", status);
        dCmd.Parameters.AddWithValue("@merchantID", merchantID);
        dCmd.Parameters.AddWithValue("@amount", amount);
        dCmd.Parameters.AddWithValue("@currency", currency);
        dCmd.Parameters.AddWithValue("@paydate", paydate);

        dCmd.Parameters.AddWithValue("@appcode", appcode);
        dCmd.Parameters.AddWithValue("@skey", skey);
        dCmd.Parameters.AddWithValue("@verifyKey", verifyKey);

        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static int OrderConfirmation(SqlConnection connSave, string ShippingID, string MerchantCode, string PaymentId, string RefNo, string Amount, string Currency, string Remark, string TransId, string AuthCode, string Status, string ErrDesc, string ReturnSignature, string useridp, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_OrderConfrimation]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ShippingID", ShippingID);
        dCmd.Parameters.AddWithValue("@MerchantCode", MerchantCode);
        dCmd.Parameters.AddWithValue("@PaymentId", PaymentId);
        dCmd.Parameters.AddWithValue("@RefNo", RefNo);
        dCmd.Parameters.AddWithValue("@Amount", Amount);
        dCmd.Parameters.AddWithValue("@Currency", Currency);
        dCmd.Parameters.AddWithValue("@Remark", Remark);
        dCmd.Parameters.AddWithValue("@TransId", TransId);

        dCmd.Parameters.AddWithValue("@AuthCode", AuthCode);
        dCmd.Parameters.AddWithValue("@Status", Status);
        dCmd.Parameters.AddWithValue("@ErrDesc", ErrDesc);
        dCmd.Parameters.AddWithValue("@ReturnSignature", ReturnSignature);
        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static SqlDataReader checkUserLoginId(SqlConnection connCheck, string strLoginId)
    {
        SqlCommand cmd = new SqlCommand("[sp_MasterUser_IsDuplicate]", connCheck);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@loginidp", strLoginId);
        //cmd.Parameters.AddWithValue("@Flag", Flag);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader checkUserApprovalByUserId(SqlConnection connectUserAprvl, long lnguserid)
    {
        SqlCommand cmd = new SqlCommand("sp_MasterUserApproval_CheckUserId", connectUserAprvl);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@useridp", lnguserid);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static int SaveUserMasterApproval(SqlConnection connSave, long intloginid, long intlinebyline, string struserid)
    {
        SqlCommand dCmd = new SqlCommand("[sp_MasterUserApproval_Save]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@loginidp", intloginid);
        dCmd.Parameters.AddWithValue("@approvalp", intlinebyline);
        dCmd.Parameters.AddWithValue("@useridp", struserid);
        return dCmd.ExecuteNonQuery();
    }

    public static int SetDefaultAddress(SqlConnection connSave, int AddressId, string struserid, string flag)
    {
        SqlCommand dCmd = new SqlCommand("[sp_SetDefaultAddress]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@AddressId", AddressId);
        dCmd.Parameters.AddWithValue("@userid", struserid);
        dCmd.Parameters.AddWithValue("@Flag", flag);
        return dCmd.ExecuteNonQuery();
    }

    public static int SaveUserMasterModulePermission(SqlConnection connSave, long intloginid, long intlinebyline, string struserid)
    {
        SqlCommand dCmd = new SqlCommand("[sp_MasterUserModulePermission_Save]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@loginidp", intloginid);
        dCmd.Parameters.AddWithValue("@moduleidp", intlinebyline);
        // dCmd.Parameters.AddWithValue("@appflag", "Y");
        dCmd.Parameters.AddWithValue("@useridp", struserid);
        return dCmd.ExecuteNonQuery();
    }

    public static int Stock_Update(SqlConnection connSave, string AddCartid, string ProductID, string PricingID, int Qty, string struserid, string flag)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Stock_Update]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@AddCartid", AddCartid);
        dCmd.Parameters.AddWithValue("@ProductID", ProductID);
        dCmd.Parameters.AddWithValue("@PricingID", PricingID);
        dCmd.Parameters.AddWithValue("@Qty", Qty);
        dCmd.Parameters.AddWithValue("@useridp", struserid);
        dCmd.Parameters.AddWithValue("@Flagp", flag);
        return dCmd.ExecuteNonQuery();
    }

    public static int ManualSalesEntry(SqlConnection connSave, int ManualSalesID, long orderno, string invoiceno, string paymentdate, int productid, string Description, int Qnty, decimal UnitPrice, decimal Amount, decimal TotalAmount, decimal GST, string Remarks, string BankingDate, int Customer, int Distributor, string DeliveryNo, int Paid, string ToVia, string useridp, string Flagp)
    {
        SqlCommand dCmd = new SqlCommand("[sp_ManualSalesEntry]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@ManualSalesID", ManualSalesID);
        dCmd.Parameters.AddWithValue("@orderno", orderno);
        dCmd.Parameters.AddWithValue("@invoiceno", invoiceno);
        dCmd.Parameters.AddWithValue("@paymentdate", paymentdate);
        dCmd.Parameters.AddWithValue("@productid", productid);
        dCmd.Parameters.AddWithValue("@Description", Description);
        dCmd.Parameters.AddWithValue("@Qnty", Qnty);
        dCmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
        dCmd.Parameters.AddWithValue("@Amount", Amount);
        dCmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
        dCmd.Parameters.AddWithValue("@GST", GST);
        dCmd.Parameters.AddWithValue("@Remarks", Remarks);
        dCmd.Parameters.AddWithValue("@BankingDate", BankingDate);
        dCmd.Parameters.AddWithValue("@Customer", Customer);
        dCmd.Parameters.AddWithValue("@Distributor", Distributor);
        dCmd.Parameters.AddWithValue("@DeliveryNo", DeliveryNo);
        dCmd.Parameters.AddWithValue("@Paid", Paid);
        dCmd.Parameters.AddWithValue("@ToVia", ToVia);
        dCmd.Parameters.AddWithValue("@useridp", useridp);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        return dCmd.ExecuteNonQuery();
    }

    public static void BindErrorMessageDetails(SqlConnection connError)
    {
        string sql = "select * FROM MasterErrorMessage order by OrderNo";
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connError);
        g_ErrorMessagesDataTable = new DataTable();
        sqlDataAdapter.Fill(g_ErrorMessagesDataTable);
        BusinessTier.DisposeAdapter(sqlDataAdapter);
    }

    public static void InsertLogAuditTrial(SqlConnection connLog, string userid, string module, string activity, string result, string flag)
    {
        string sp_Name;
        if (flag.ToString() == "Log")
        {
            sp_Name = "[sp_Master_Insert_Log]";
        }
        else
        {
            sp_Name = "[sp_Master_Insert_AuditTrail]";
        }

        SqlCommand dCmd = new SqlCommand(sp_Name, connLog);

        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@modulep", module);
        dCmd.Parameters.AddWithValue("@activityp", activity);
        dCmd.Parameters.AddWithValue("@resultp", result);
        dCmd.ExecuteNonQuery();
    }

    public static SqlDataReader getMenuList(SqlConnection conn)
    {
        string sql = "";
        sql = "select BasicCategoryID,Categoryid,Category,BasicCategory,Priority from (select Categoryid,Category,BasicCategoryID,BasicCategory,Priority,row_number() over(partition by T.BasicCategoryID order by T.Priority asc) as rn from VW_BasicCategory as T where deleted=0 and BasicCategoryID in " + WebConfigurationManager.AppSettings["Menuselect"].ToString() + ") as n where n.rn <=1 order by Priority asc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getMenuList1(SqlConnection conn)
    {
        string sql = "";
        sql = "select BasicCategoryID,Categoryid,Category,BasicCategory,Priority from (select Categoryid,Category,BasicCategoryID,BasicCategory,Priority,row_number() over(partition by T.BasicCategoryID order by T.Priority asc) as rn from VW_BasicCategory as T where deleted=0 and BasicCategoryID in " + WebConfigurationManager.AppSettings["Menuselect1"].ToString() + ") as n where n.rn <=1 order by Priority asc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static DataTable getSubMenuItems(string category)
    {
        DataTable ret = new DataTable();
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "";
        sql = "select Category,BasicCategoryID,Categoryid from MasterCategory where deleted=0 and BasicCategoryID='" + category + "'  group by Category, BasicCategoryID,Categoryid order by Categoryid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        ret.Load(reader);
        BusinessTier.DisposeConnection(conn);
        return ret;
    }

    public static SqlDataReader getBasicCategory(SqlConnection conn)
    {
        string sql = "";
        sql = "select BasicCategoryID,Categoryid,Category,BasicCategory,Priority from (select Categoryid,Category,BasicCategoryID,BasicCategory,Priority,row_number() over(partition by T.BasicCategoryID order by T.Priority asc) as rn from VW_BasicCategory as T where deleted=0) as n where n.rn <=1 and BasicCategoryID<>14  order by Priority asc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static DataTable getSubCategory(string BasicCategoryID)
    {
        DataTable ret = new DataTable();
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "";
        sql = "select SubCategory,SubCategoryID from MasterSubCategory where SubCategoryID in( select distinct(SubCategoryID) from MasterCategory where Categoryid in(select distinct(Categoryid) from masterproducts)) and deleted=0 and BasicCategoryID='" + BasicCategoryID + "' order by Priority, SubCategory, BasicCategoryID, SubCategoryID";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        ret.Load(reader);
        BusinessTier.DisposeConnection(conn);
        return ret;
    }

    public static DataTable getCategory(string SubCategoryID)
    {
        DataTable ret = new DataTable();
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "";
        sql = "select Category,BasicCategoryID,Categoryid,SubCategoryID from MasterCategory where Categoryid in(select distinct(Categoryid) from masterproducts) and deleted=0 and SubCategoryID='" + SubCategoryID + "'  group by Category, BasicCategoryID,SubCategoryID,Categoryid order by Categoryid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        ret.Load(reader);
        BusinessTier.DisposeConnection(conn);
        return ret;
    }

    public static SqlDataReader getQty(SqlConnection conn, string ProductID)
    {
        string sql = "";

        sql = "select Totalstock as tstock from MasterItemProduct where deleted=0 and ProductID='" + ProductID.ToString() + "'";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getQtyWithSize(SqlConnection conn, string ProductID, string Sizecheckflag)
    {
        string sql = "";

        sql = "select stock as tstock from MasterPricing where deleted=0 and ProductID='" + ProductID.ToString() + "' and pricingid='" + Sizecheckflag.ToString() + "' ";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getSize(SqlConnection conn, string ProductID)
    {
        string sql = "";
        sql = "select PricingID,ProSize,Stock from MasterPricing where deleted=0 and Stock<>0 and ProductID='" + ProductID.ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getColor(SqlConnection conn, string ProductID)
    {
        string sql = "";
        sql = "select PricingID,ProColor,Stock from MasterPricing where deleted=0 and ProductID='" + ProductID.ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static void ddlTableDataLoad2(DropDownList ddl, string Table, string Field1, string Field2, string Placeholder)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT * from " + Table + " where deleted=0");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = Field1;
        ddl.DataValueField = Field2;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static SqlDataReader FindDublicate(SqlConnection conn, string tablename, string columnname, string validid)
    {
        string sql = "select * FROM " + tablename + " WHERE Deleted=0 and " + columnname + "='" + validid + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader SellerBillFindDublicate(SqlConnection conn, string Sellerid, string StartDate, string EndDate)
    {
        string sql = "select * FROM SellerBillDetails WHERE Deleted=0 and Sellerid='" + Sellerid + "' and FromDate = '" + StartDate + "' and ToDate='" + EndDate + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getBasicCategoryItems(SqlConnection conn, string category)
    {
        string sql = "";
        if (category == "")
        {
            sql = "select BasicCategory,BasicCategoryID from BasicCategoryMaster where deleted=0 group by BasicCategory,BasicCategoryID order by BasicCategoryID";
        }
        else
        {
            sql = "select BasicCategoryID from VW_BasicCategory where deleted=0 and Categoryid='" + category.ToString() + "'";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getCategoryItems(SqlConnection conn, string category)
    {
        string sql = "";
        sql = "select Category,Categoryid from MasterCategory where deleted=0 and BasicCategoryID='" + category + "'  group by Category, Categoryid order by Categoryid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getBrandItems(SqlConnection conn, string categoryid, string userid)
    {
        string sql = "";
        sql = "select CategoryID,Brand from MasterProducts where deleted=0 and CategoryID='" + categoryid.ToString() + "' and CREATED_BY='" + userid.ToString() + "'  group by CategoryID,Brand order by Brand";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getModelItems(SqlConnection conn, string categoryid, string Brand, string userid)
    {
        string sql = "";
        sql = "select CategoryID,Model,productid from MasterProducts where deleted=0 and CategoryID='" + categoryid.ToString() + "' and Brand='" + Brand.ToString() + "' and CREATED_BY='" + userid.ToString() + "'  group by Model,CategoryID,productid order by Model";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getCategoryList(SqlConnection conn)
    {
        string sql = "select Category,Page,Categoryid from MasterCategory where deleted=0";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getProductitems(SqlConnection conn, string categoryid)
    {
        string sql = "SELECT TOP (16) Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock, ROW_NUMBER() OVER (ORDER BY ProductId ) as RowNum,id FROM Vw_Products where CategoryID='" + categoryid + "' and deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 ORDER BY ProductId DESC";
        SqlCommand cmd = new SqlCommand(sql, conn);

        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getitemswithpid(SqlConnection conn, string productid)
    {
        string sql = "SELECT TOP (16) Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock, ROW_NUMBER() OVER (ORDER BY ProductId ) as RowNum,id FROM Vw_Products where ProductID in (" + productid + ") and deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 ORDER BY ProductId DESC";
        SqlCommand cmd = new SqlCommand(sql, conn);

        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getRecentitems(SqlConnection conn, string condition)
    {
        string sql = string.Empty;
        if (condition == "Latest" || condition == "First")
        {
            sql = "select top 16 Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,IsCOD=0,bazzaar,bazzarimagePath from Vw_Products where deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 and bazzarimagePath is null and bazzaar is null order by productid desc";
        }
        else if (condition == "Category")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where productID not in (select top((select COUNT(*) from Vw_Products  where approve=1) -16 )productID from Vw_Products) and deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 order by categoryid asc";
        }
        else if (condition == "asc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where productID not in (select top((select COUNT(*) from Vw_Products  where approve=1) -16 )productID from Vw_Products) and deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 ORDER BY DiscountPrice asc";
        }
        else if (condition == "desc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where productID not in (select top((select COUNT(*) from Vw_Products  where approve=1) -16 )productID from Vw_Products) and deleted=0 and MasterDel=0 and TotalStock>0 and approve=1 ORDER BY DiscountPrice desc";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getFeatureitems(SqlConnection conn)
    {
        // string sql = "select * from (select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,left((Brand + ' ' + Model),16)+'...' as ShortBrMod, ROW_NUMBER() OVER (ORDER BY ProductId) as RowNum,FeatureProductID from VW_FeatureProduct as t where deleted=0 )as t where t.RowNum <= 16 ORDER BY FeatureProductID";
        string sql = "select TOP (16) Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod, CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod, TotalStock,FeatureProductID,id from VW_FeatureProduct where deleted=0 order by FeatureProductID desc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getProductsList(SqlConnection conn, string param)
    {
        string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Categoryid='" + param.ToString() + "' and  Approve=1 order by productid desc";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getallProductsList(SqlConnection conn, string param, string param2,string param1)
    {
        string sql = string.Empty;
        if (param2 == "Default")
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BasicCategoryID,SubCategoryID,BasicCategory,SubCategory,CategoryID from Vw_Products where MasterDel=0 and Approve=1 and Categoryid = " + param.ToString() + " or productid in(" + param1 + ") order by productid desc";
        if (param2 == "Price(High - Low)")
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BasicCategoryID,SubCategoryID,BasicCategory,SubCategory,CategoryID from Vw_Products where MasterDel=0 and Approve=1 and Categoryid = " + param.ToString() + " or productid in(" + param1 + ") order by DiscountPrice desc";
        if (param2 == "Price(Low - High)")
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BasicCategoryID,SubCategoryID,BasicCategory,SubCategory,CategoryID from Vw_Products where MasterDel=0 and Approve=1 and Categoryid = " + param.ToString() + " or productid in(" + param1 + ") order by DiscountPrice asc ";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getSellerProductsList(SqlConnection conn, string sellerid, string from, string to)
    {
        string sql = "SELECT * FROM (select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BusinessName,ROW_NUMBER()OVER(ORDER BY ProductID)AS ID2 from Vw_Products where MasterDel=0 and CREATED_BY='" + sellerid.ToString() + "' and  Approve=1)AS tbl WHERE ID2 between " + from + " and " + to + " ORDER BY tbl.ID2";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getPromoList(SqlConnection conn, string condition)
    {
        string sql = string.Empty;
        if (condition == "Latest" || condition == "First")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and id is not null order by productid desc";
        }
        else if (condition == "Category")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and id is not null order by Categoryid asc";
        }
        else if (condition == "asc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and id is not null order by DiscountPrice asc";
        }
        else if (condition == "desc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and id is not null order by DiscountPrice desc";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getRM5(SqlConnection conn, string condition, string param)
    {
        string sql = string.Empty;
        if (condition == "Latest" || condition == "First")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and Categoryid='" + param.ToString() + "' order by productid desc";
        }
        else if (condition == "Category")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Categoryid='" + param.ToString() + "' order by Categoryid asc";
        }
        else if (condition == "asc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Categoryid='" + param.ToString() + "' order by DiscountPrice asc";
        }
        else if (condition == "desc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Categoryid='" + param.ToString() + "' order by DiscountPrice desc";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static string getBuyerOrder(string condition, string param)
    {
        string sql = string.Empty;
        if (condition != "0")
        {
            //sql = "select TOP (" + condition + ") *,CASE WHEN Shipped = 0  THEN 'No'  ELSE  'Yes'  END AS Shipping,CASE WHEN Deliver = 0  THEN 'No'  ELSE  'Yes'  END AS Delivered,CASE WHEN Cancel = 0  THEN 'No'  ELSE  'Yes'  END AS Cancelorder,CASE WHEN Returnproduct = 0  THEN 'No'  ELSE  'Yes'  END AS Returnpro , '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE Customerid='" + param.ToString() + "' and Deleted=0 and buy=1 and status=1 and Cancel=0 and Returnproduct=0 and IsCOD=0 order by addcartid desc";
            sql = "select TOP (" + condition + ") *,CASE WHEN Deliver = 1  THEN 'Delivered' when Shipped=1 then 'Shipped'  WHEN courierid is not null Then 'Ready to Ship'  WHEN courierid is null THEN 'Processing...'  END AS Shipstatus, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE Customerid='" + param.ToString() + "' and Deleted=0 and buy=1 and status=1 and Cancel=0 and Returnproduct=0 and IsCOD=0 order by addcartid desc";
        }
        else 
        {
            sql = "select *,CASE WHEN Deliver = 1  THEN 'Delivered' when Shipped=1 then 'Shipped'  WHEN courierid is not null Then 'Ready to Ship'  WHEN courierid is null THEN 'Processing...'  END AS Shipstatus, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE Customerid='" + param.ToString() + "' and Deleted=0 and buy=1 and status=1 and Cancel=0 and Returnproduct=0 and IsCOD=0 order by addcartid desc";
        }
        return sql;
    }

    public static string getReturnCancel(string condition, string param)
    {
        string sql = string.Empty;
        if (condition != "0")
        {
            sql = "select TOP (" + condition + ") *,CASE WHEN Shipped = 0  THEN 'No'  ELSE  'Yes'  END AS Shipping,CASE WHEN Deliver = 0  THEN 'No'  ELSE  'Yes'  END AS Delivered,CASE WHEN Cancel = 1  THEN 'Cancel' WHEN Returnproduct = 1  THEN 'Return'  END AS Returncancel , '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE  Customerid='" + param.ToString() + "'  and IsCOD=0 and  Deleted=0 and buy=1 and status=1 and Cancel=1 or Returnproduct=1 order by addcartid desc";
        }
        else
        {
            sql = "select *,CASE WHEN Shipped = 0  THEN 'No'  ELSE  'Yes'  END AS Shipping,CASE WHEN Deliver = 0  THEN 'No'  ELSE  'Yes'  END AS Delivered,CASE WHEN Cancel = 1  THEN 'Cancel' WHEN Returnproduct = 1  THEN 'Return'  END AS Returncancel , '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE Customerid='" + param.ToString() + "' and IsCOD=0 and Deleted=0 and buy=1 and status=1 and Cancel=1 or Returnproduct=1 order by addcartid desc";
        }
        return sql;
    }

    public static SqlDataReader getAT(SqlConnection conn, string condition)
    {
        string sql = string.Empty;
        if (condition == "Latest" || condition == "First")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and BasicCategoryID=13 order by productid desc";
        }
        else if (condition == "Category")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and BasicCategoryID=13 order by Categoryid asc";
        }
        else if (condition == "asc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and BasicCategoryID=13 order by DiscountPrice asc";
        }
        else if (condition == "desc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and BasicCategoryID=13 order by DiscountPrice desc";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getPopular(SqlConnection conn, string condition)
    {
        string sql = string.Empty;
        if (condition == "Latest" || condition == "First")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and Popular=1 order by productid desc";
        }
        else if (condition == "Category")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Popular=1 order by Categoryid asc";
        }
        else if (condition == "asc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Popular=1 order by DiscountPrice asc";
        }
        else if (condition == "desc")
        {
            sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and Popular=1 order by DiscountPrice desc";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getSearchList(SqlConnection conn, string param)
    {
        string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and IsCOD=0 and CategoryID in (select Sub_CategoryId from MSP_SearchTags where deleted=0 and Tags like '%" + param.ToString() + "%') order by productid desc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
    //public static SqlDataReader getSearchList(SqlConnection conn, string param)
    //{     
    //    string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and IsCOD=0 and (basiccategory like '%" + param.ToString() + "%' or category like '%" + param.ToString() + "%' or brand like '%" + param.ToString() + "%' or model like '%" + param.ToString() + "%' or details like '%" + param.ToString() + "%') order by productid desc";
    //    SqlCommand cmd = new SqlCommand(sql, conn);
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    return reader;
    //}

    public static SqlDataReader getcboProductsList(SqlConnection conn, string param, string param1)
    {
        string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Brand='" + param1.ToString() + "' and categoryid = '" + param.ToString() + "' and  Approve=1 order by productid desc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getcboSizeList(SqlConnection conn, string param, string param1)
    {
        string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Product_Size where MasterDel=0 and Prosize='" + param1.ToString() + "' and Categoryid='" + param.ToString() + "' and  Approve=1 order by productid desc";
        //string sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,left((Brand + ' ' + Model),16)+'...' as ShortBrMod,TotalStock,Category,id from Vw_Product_Size where MasterDel=0 and Prosize='" + param1.ToString() + "' and categoryid = '" + param.ToString() + "' and  Approve=1 and Stock<>0 order by productid desc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getProductsDistinctList(SqlConnection conn, string param)
    {
        string sql = "select distinct(Brand),categoryid from MasterProducts where Categoryid='" + param.ToString() + "' and deleted=0";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static void getBrandDistinctList(DropDownList ddl, string param)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("select distinct(Brand),categoryid from MasterProducts where Categoryid='" + param.ToString() + "' and deleted=0");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = "Brand";
        ddl.DataValueField = "categoryid";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select All Brand", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static SqlDataReader getdistinctBrand(SqlConnection conn, string param)
    {
        string sql = "";
        sql = "select distinct(Brand),categoryid from MasterProducts where Categoryid='" + param.ToString() + "' and deleted=0";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getProductsSizeList(SqlConnection conn, string param)
    {
        string sql = "select Prosize,categoryid from Vw_Product_Size where Categoryid='" + param.ToString() + "' and deleted=0 group by Prosize,categoryid";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getPreview(SqlConnection conn, string param)
    {
        string sql = "select image1,image2,image3,image4,image5,Brand,Model,SellingPrice,Stock,Details from Vw_Products where MasterDel=0 and productid='" + param.ToString() + "' and  deleted=0";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        return reader;
    }

    public static SqlDataReader getDuplicate(SqlConnection conn, string param, string param1, string param2)
    {
        string sql = string.Empty;
        if (param1 != "0")
        {
             sql = "select * from AddCartMaster where productid='" + param.ToString() + "' and customerid='" + param1.ToString() + "' and  deleted=0 and buy=0 and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
        }
        else 
        {
            sql = "select * from AddCartMaster where productid='" + param.ToString() + "' and BDID='" + param2.ToString() + "' and  deleted=0 and buy=0 and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getWishDuplicate(SqlConnection conn, string param, string param1)
    {
        string sql = "select * from WishListMaster where productid='" + param.ToString() + "' and customerid='" + param1.ToString() + "' and deleted=0";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getBusinessID(SqlConnection conn, string paramSysRegno, string paramEmail)
    {
        string sql = "select * from BusinessRegister where SysRegno='" + paramSysRegno.ToString() + "' and Email='" + paramEmail.ToString() + "' and  deleted=0";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getOrderNo(SqlConnection conn)
    {
        string sql = "";
        sql = "select distinct (OrderNo) from AddCartMaster where deleted=0 and ShippingID is not null order by OrderNo desc";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getOrderDetails(SqlConnection conn, string param, string param1)
    {
        string sql = "select RefNo,sum(discountprice*Qnty),convert(varchar, created_date, 103) as cdate from VW_OrderDetails where customerid='" + param.ToString() + "' and DATEPART(yyyy,created_date)='" + param1.ToString() + "' and  deleted=0 and buy=1 group by RefNo,created_date order by RefNo desc";

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getProductReview(SqlConnection conn, string param)
    {
        string sql = "select TOP(5) * from VWProductReview where ProductID='" + param.ToString() + "' and  deleted=0 and Approve=1";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getcalalogid(SqlConnection conn, string param)
    {
        SqlCommand cmd = new SqlCommand("[sp_selectCatalogMaster]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@catalogid", param);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader getcart(SqlConnection conn, string param, string param2)
    {
        String today = DateTime.Now.ToString();
        DateTime dtinsDate = DateTime.Parse(today);
        today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

        String week = DateTime.Now.AddDays(-7).ToString();
        DateTime dtweekDate = DateTime.Parse(week);
        week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";
        string sql = string.Empty;
        if (param != "0")
        {
            sql = "select count(*) as Cart  from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0 and Customerid='" + param.ToString() + "' and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
        }
        else
        {
            sql = "select count(*) as Cart  from Vw_AddCart where DELETED=0 and buy=0 and IsCOD=0 and BDID='" + param2.ToString() + "' and created_date between DATEADD(day, -7, getdate()) and convert(varchar, getdate(), 101)";
        }
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static int SellerBillDetails(SqlConnection connSave, int SellerBillID, int SellerID, string Invoice, string FromDate, string ToDate, string BillDate, int TotalOrder, decimal TotalAmount, decimal PaymentFee, decimal Shipping, decimal Refund, decimal Penalties, decimal Other, string userid, string Flag)
    {
        SqlCommand dCmd = new SqlCommand("[sp_SellerBillDetails]", connSave);
        dCmd.CommandType = CommandType.StoredProcedure;

        dCmd.Parameters.AddWithValue("@SellerBillID", SellerBillID);
        dCmd.Parameters.AddWithValue("@SellerID", SellerID);
        dCmd.Parameters.AddWithValue("@Invoice", Invoice);
        dCmd.Parameters.AddWithValue("@FromDate", FromDate);
        dCmd.Parameters.AddWithValue("@ToDate", ToDate);
        dCmd.Parameters.AddWithValue("@BillDate", BillDate);
        dCmd.Parameters.AddWithValue("@TotalOrder", TotalOrder);
        dCmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
        dCmd.Parameters.AddWithValue("@PaymentFee", PaymentFee);
        dCmd.Parameters.AddWithValue("@Shipping", Shipping);
        dCmd.Parameters.AddWithValue("@Refund", Refund);
        dCmd.Parameters.AddWithValue("@Penalties", Penalties);
        dCmd.Parameters.AddWithValue("@Other", Other);
        dCmd.Parameters.AddWithValue("@userid", userid);
        dCmd.Parameters.AddWithValue("@Flag", Flag);
        return dCmd.ExecuteNonQuery();
    }

    public static string SellerID(SqlConnection conn)
    {
        string id = string.Empty;
        string sql = "select Max(sellerid) + 1 as id  from SellerRegister";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            if (reader["id"].ToString() == "")
            {
                id = "1";
            }
            else
            {
                id = reader["id"].ToString();
            }
        }
        reader.Close();
        return id;
    }

    public static int SellerCount(SqlConnection conn, string uid)
    {
        int id = 0;
        string sql = "SELECT Count(*) as scnt from Vw_Products where CREATED_BY='" + uid.ToString() + "' and  deleted=0  and MasterDel=0 and  approve=1";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            id = Convert.ToInt32(reader["scnt"].ToString());
        }
        reader.Close();
        return id;
    }

    public static string MaxID(SqlConnection conn, string Table, string Field, string user)
    {
        string id = string.Empty;
        string sql = "select Max(" + Field + ") as id  from " + Table + " where CREATED_BY=" + user;
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            if (reader["id"].ToString() == "")
            {
                id = "1";
            }
            else
            {
                id = reader["id"].ToString();
            }
        }

        return id;
    }

    public static SqlDataReader SelectSellerBillCount(SqlConnection connec, string sellerid, string StartDate, string EndDate)
    {
        SqlCommand cmd = new SqlCommand("[sp_SelectSellerBillCount]", connec);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Userid", sellerid);
        cmd.Parameters.AddWithValue("@StartDate", StartDate);
        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        SqlDataReader reader1 = cmd.ExecuteReader();
        return reader1;
    }

    // ------------------------------------------Function For Manupulation----------------------------------------------

    public static string GetFixedLengthString(string input, int length)
    {
        string result = string.Empty;

        if (string.IsNullOrEmpty(input))
        {
            result = new string(' ', length);
        }
        else if (input.Length > length)
        {
            result = input.Substring(0, length);
        }
        else
        {
            result = input.PadRight(length);
        }

        return result;
    }

    public static string FileSave(FileUpload File, TextBox Txt, string Path, string fname)
    {
        string filename = string.Empty;
        string[] Extension = File.FileName.Split('.');
        filename = Txt.ToolTip.ToString() + fname + "." + Extension[1].ToString();
        File.SaveAs(Path + filename);
        return filename;

    }

    public static void Clear(TextBox txt)
    {
        txt.Text = string.Empty;
    }

    public static void Clearlbl(Label lbl)
    {
        lbl.Text = string.Empty;
    }

    public static void btnVisible(Button btn, bool torf)
    {
        btn.Visible = torf;
    }

    public static void LoadLink(Button lnkbutton, Button btn, FileUpload fup, string flag)
    {
        if (flag == "Load")
        {
            if (string.IsNullOrEmpty(lnkbutton.ToolTip.ToString().Trim()))
            {
                fup.Visible = true;
                btn.Visible = false;
                lnkbutton.Text = string.Empty;
                lnkbutton.Visible = false;
            }
            else
            {
                fup.Visible = false;
                btn.Visible = true;
                lnkbutton.Visible = true;
            }
        }
        else if (flag == "Reject")
        {
            lnkbutton.Visible = false;
            lnkbutton.Text = string.Empty;
            lnkbutton.ToolTip = string.Empty;
            btn.Visible = false;
            fup.Visible = true;
        }

    }

    public static string PhotoName(FileUpload File, string Filename)
    {
        string downfile = string.Empty;
        string[] Ext = File.FileName.Split('.');
        downfile = Filename + "." + Ext[1].ToString();
        return downfile;
    }

    public static void LoadLink(LinkButton lnkbutton, Button btn, FileUpload fup, string flag)
    {
        if (flag == "Load")
        {
            if (string.IsNullOrEmpty(lnkbutton.ToolTip.ToString().Trim()))
            {
                fup.Visible = true;
                btn.Visible = false;
                lnkbutton.Text = string.Empty;
                lnkbutton.Visible = false;
            }
            else
            {
                fup.Visible = false;
                btn.Visible = true;
                lnkbutton.Visible = true;
            }
        }
        else if (flag == "Reject")
        {
            lnkbutton.Visible = false;
            lnkbutton.Text = string.Empty;
            lnkbutton.ToolTip = string.Empty;
            btn.Visible = false;
            fup.Visible = true;
        }

    }

    public static string LinkClick(LinkButton lnkbutton)
    {
        String path = string.Empty;
        path = WebConfigurationManager.AppSettings["ImagePath"].ToString();
        string line = lnkbutton.ToolTip.ToString().Trim();
        string[] tokens = line.Split(new char[] { '\\' }, 3, 0);
        string strLink = path + tokens[0] + "/" + tokens[1] + "/" + tokens[2];
        return strLink;

    }

    public static string Findnull(string table, string column, string field1, string cond1)
    {
        string val = string.Empty;
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "select " + column + " as val FROM " + table + " WHERE " + field1 + "='" + cond1 + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.Read())
        {
            val = reader1["val"].ToString();
        }
        reader1.Close();
        return val;
    }

    public static string FindMin(string table, string column)
    {
        string val = string.Empty;
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "select min(" + column + ")+1 as Minval FROM " + table + "";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.Read())
        {
            val = reader1["Minval"].ToString();
        }
        reader1.Close();
        return val;
    }

    public static string FindStock(string Pid, string cid)
    {
        string val = string.Empty;
        String today = DateTime.Now.ToString();
        DateTime dtinsDate = DateTime.Parse(today);
        today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

        String week = DateTime.Now.AddDays(-7).ToString();
        DateTime dtweekDate = DateTime.Parse(week);
        week = dtweekDate.Month + "/" + dtweekDate.Day + "/" + dtweekDate.Year + " 00:00:00";

        SqlConnection conn = getConnection();
        conn.Open();
        string sql = "select * FROM Vw_StockChkUp where Productid ='" + Pid + "' and CREATED_BY ='" + cid + "' and CREATED_DATE between '" + week.ToString() + "' and '" + today.ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.Read())
        {
            if (string.IsNullOrEmpty(reader1["Stock"].ToString()))
            {
                val = reader1["TotalStock"].ToString();
            }
            else
            {
                val = reader1["Stock"].ToString();
            }
        }
        reader1.Close();
        conn.Close();
        return val;
    }

    public static int totCount(string qry)
    {
        int val = 0;
        SqlConnection conn = getConnection();
        conn.Open();
        string sql = qry;
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.Read())
        {
            if (!(string.IsNullOrEmpty(reader1["totCount"].ToString())))
            {
                val = Convert.ToInt32(reader1["totCount"].ToString());
            }
        }
        reader1.Close();
        conn.Close();
        return val;
    }

    public static void PageLoad_ddlDate(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Date", "Date"));
        ddl.Items.FindByValue("Date").Attributes.Add("style", "color:#f00;font-style: italic;");
        for (int i = 1; i <= 31; i++)
        {
            ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    public static void PageLoad_ddlYear(DropDownList ddl, int Year1, int Year2)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Year", "Year"));
        ddl.Items.FindByValue("Year").Attributes.Add("style", "color:#f00;font-style: italic;");
        for (int i = Year1; i <= Year2; i++)
        {
            ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    public static void PageLoad_ddlMonth(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Month", "00"));
        ddl.Items.Add(new ListItem("Jan", "01"));
        ddl.Items.Add(new ListItem("Feb", "02"));
        ddl.Items.Add(new ListItem("Mar", "03"));
        ddl.Items.Add(new ListItem("Apr", "04"));
        ddl.Items.Add(new ListItem("May", "05"));
        ddl.Items.Add(new ListItem("Jun", "06"));
        ddl.Items.Add(new ListItem("Jul", "07"));
        ddl.Items.Add(new ListItem("Aug", "08"));
        ddl.Items.Add(new ListItem("Sep", "09"));
        ddl.Items.Add(new ListItem("Oct", "10"));
        ddl.Items.Add(new ListItem("Nov", "11"));
        ddl.Items.Add(new ListItem("Dec", "12"));
        ddl.Items.FindByValue("00").Attributes.Add("style", "color:#f00;font-style: italic;");
    }

    public static void ddlTableDataLoad(DropDownList ddl, string Table, string Field1, string Field2, string Placeholder)
    {
        SqlConnection sqlcon = getConnection();
        sqlcon.Open();
        DataSet g_datatable = new DataSet();
        SqlCommand SelectCmd = new SqlCommand("SELECT * from " + Table + " where deleted=0");
        SelectCmd.Connection = sqlcon;
        ddl.Items.Clear();
        ddl.DataSource = SelectCmd.ExecuteReader();
        ddl.DataTextField = Field1;
        ddl.DataValueField = Field2;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select " + Placeholder + "--", "0"));
        ddl.Items.FindByValue("0").Attributes.Add("style", "color:#f00;font-style: italic;");
        DisposeConnection(sqlcon);
    }

    public static string ddlJoinDate(DropDownList ddl1, DropDownList ddl2, DropDownList ddl3)
    {
        string value = "01/01/1900 00:00:00";
        if (ddl1.Text != "Date" && ddl2.Text != "Month" && ddl3.Text != "Year")
        {
            value = ddl2.Text + "/" + ddl1.Text + "/" + ddl3.Text + " 00:00:00";
        }
        return value;
    }

    //----------------------MISC------------------------------------------------------------------

    //public static void SendMail(string strSubject, string strBody, string strToAddress, string strApprovarMail, string strAttachmentFilename)
    //{
    //SmtpClient smtpClient = new SmtpClient();
    //MailMessage message = new MailMessage();
    //if (!(strAttachmentFilename.ToString().Trim() == "NoAttach"))
    //{
    //    Attachment attachment = new Attachment(strAttachmentFilename.ToString().Trim());
    //    message.Attachments.Add(attachment);
    //}
    //MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString(), "LSB Asset Tracking System");
    //smtpClient.Host = ConfigurationManager.AppSettings["ExchangeServer"].ToString();
    //smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());

    //message.Priority = MailPriority.High;
    //message.From = fromAddress;
    //message.Subject = strSubject.ToString();
    //message.To.Add(strToAddress.ToString());
    //message.CC.Add(strApprovarMail.ToString());
    ////message.CC.Add("bala@e-serbadk.com");
    ////message.CC.Add("karthi@e-serbadk.com");
    ////message.CC.Add("fadzli_mzain@yahoo.com");
    ////message.CC.Add("zuhaifi.mghani@iperintis.com");
    ////message.CC.Add("nurlisa_ahmad@petronas.com.my");
    //message.Body = strBody;
    ////smtpClient.EnableSsl = true;
    ////smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    ////smtpClient.UseDefaultCredentials = false;
    //smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromAddress"].ToString(), ConfigurationManager.AppSettings["Password"].ToString().Trim());
    ////smtpClient.Send(message);
    //message.Dispose();
    //smtpClient.Dispose();
    //File.Delete(strAttachmentFilename.ToString().Trim());
    //}

    public static void SendMail(string MailTo, string Subject, string msg, int cc)
    {
        MailMessage message1 = new MailMessage();
        message1.From = new MailAddress(ConfigurationManager.AppSettings["MailAddress"].ToString());
        message1.To.Add(new MailAddress(MailTo.ToString().Trim()));
        if (cc == 1)
        {
            message1.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["MailAddress"].ToString()));
            message1.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["MailAddress2"].ToString()));
            message1.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["MailAddress3"].ToString()));
            message1.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["MailAddress4"].ToString()));
            message1.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["MailAddress5"].ToString()));
        }
        message1.Subject = Subject.ToString().Trim();
        message1.IsBodyHtml = true;
        message1.Body = msg;
        SmtpClient client1 = new SmtpClient(ConfigurationManager.AppSettings["Webserver"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString()));
        //client1.UseDefaultCredentials = false;
        client1.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailAddress"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
        //client1.DeliveryMethod = SmtpDeliveryMethod.Network;
        //client1.EnableSsl = true;
        client1.Send(message1);
        message1.Dispose();
        client1.Dispose();// Dispose();
    }

    public static SqlDataReader getProductsDistinctList(SqlConnection con)
    {
        throw new NotImplementedException();
    }

    public static int OrderConfirmation(SqlConnection con, string tranID, string p, string p_2)
    {
        throw new NotImplementedException();
    }

    //--------------------------------------Bazaar-------------------------------------------------


    public static string DocLinkClick(LinkButton lnkbutton)
    {
        String path = string.Empty;
        path = WebConfigurationManager.AppSettings["DocumentsPath"].ToString();
        string line = lnkbutton.ToolTip.ToString().Trim();
        string strLink = path + line;
        return strLink;

    }
    
    public static int Bazzaar_SellerRegister(SqlConnection conn, int SellerID, string BusinessName, string Regno, string Name, string ICno, string Contactno, string Email, string Address, string Password, string Bankname, string AccHdrName, string Accountno, string BranchName, string Settlement, int Approve, string MyKad, string bankstatement, string utilitiesbill, string form9, string form49, string GSTApproval, string State, string Country, int Postcode, int ISDCode, string RegistrationType, string SWIFTcode, string Gender, string DOB, string AboutProduct, string Courier, string CourierACno, string PromoCode, string City, string userid, string Flagp, string bazzartype, string imagePath)
    {
        SqlCommand dCmd = new SqlCommand("[sp_Bazzaar_SellerRegister]", conn);
        dCmd.CommandType = CommandType.StoredProcedure;
        dCmd.Parameters.AddWithValue("@SellerID", SellerID);
        dCmd.Parameters.AddWithValue("@BusinessName", BusinessName);
        dCmd.Parameters.AddWithValue("@Regno", Regno);
        dCmd.Parameters.AddWithValue("@Name", Name);
        dCmd.Parameters.AddWithValue("@ICno", ICno);
        dCmd.Parameters.AddWithValue("@Contactno", Contactno);
        dCmd.Parameters.AddWithValue("@Email", Email);

        dCmd.Parameters.AddWithValue("@Address", Address);
        dCmd.Parameters.AddWithValue("@Password", Password);
        dCmd.Parameters.AddWithValue("@Bankname", Bankname);
        dCmd.Parameters.AddWithValue("@AccHdrName", AccHdrName);
        dCmd.Parameters.AddWithValue("@Accountno", Accountno);
        dCmd.Parameters.AddWithValue("@BranchName", BranchName);
        dCmd.Parameters.AddWithValue("@Settlement", Settlement);

        dCmd.Parameters.AddWithValue("@Approve", Approve);

        dCmd.Parameters.AddWithValue("@MyKad", MyKad);
        dCmd.Parameters.AddWithValue("@bankstatement", bankstatement);
        dCmd.Parameters.AddWithValue("@utilitiesbill", utilitiesbill);
        dCmd.Parameters.AddWithValue("@form9", form9);
        dCmd.Parameters.AddWithValue("@form49", form49);
        dCmd.Parameters.AddWithValue("@GSTApproval", GSTApproval);

        dCmd.Parameters.AddWithValue("@State", State);
        dCmd.Parameters.AddWithValue("@Country", Country);
        dCmd.Parameters.AddWithValue("@Postcode", Postcode);
        dCmd.Parameters.AddWithValue("@ISDCode", ISDCode);
        dCmd.Parameters.AddWithValue("@RegistrationType", RegistrationType);
        dCmd.Parameters.AddWithValue("@SWIFTcode", SWIFTcode);

        dCmd.Parameters.AddWithValue("@Gender", Gender);
        dCmd.Parameters.AddWithValue("@DOB", DOB);
        dCmd.Parameters.AddWithValue("@AboutProduct", AboutProduct);

        dCmd.Parameters.AddWithValue("@Courier", Courier);
        dCmd.Parameters.AddWithValue("@CourierACno", CourierACno);

        dCmd.Parameters.AddWithValue("@useridp", userid);
        dCmd.Parameters.AddWithValue("@Flagp", Flagp);
        dCmd.Parameters.AddWithValue("@Bazzaar", bazzartype);
        dCmd.Parameters.AddWithValue("@City", City);
        dCmd.Parameters.AddWithValue("@PromoCode", PromoCode);
        dCmd.Parameters.AddWithValue("@bazzarimagePath", imagePath);
        dCmd.ExecuteNonQuery();
        return 3;
    }


}