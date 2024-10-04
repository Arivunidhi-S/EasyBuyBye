using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class web_QwikStubsPost : System.Web.UI.Page
{
    public class Postval
    {
        public string Success { get; set; }
        public int StubsID { get; set; }
        public int ProductID { get; set; }
        public string Gender { get; set; }
        public int Min_Age { get; set; }
        public int Max_Age { get; set; }
        public string DisplayLocation { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string CallToAction { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Orientation { get; set; }
        //public string Brand { get; set; }
        //public string Model { get; set; }
        public string details { get; set; }
        public string CutPrice { get; set; }
        public string SellingPrice { get; set; }
        public int quantity { get; set; }
        public string ImageURL { get; set; }
        public string ImageSmall { get; set; }
        public int locationID { get; set; }
        public List<SizeDetails2> SizeDetails { get; set; }
    }

    public class SizeDetails2 
    {       
        public string Size { get; set; }
        public int Stock { get; set; }
        public int PricingID { get; set; }
    }

    public class Postval1
    {
        public string Success { get; set; }
        public string ProductDetails { get; set; }
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
       
        //Response.Write(NewMethod());
        SqlConnection con = BusinessTier.getConnection();
        {

            string @ProductID = Request.QueryString.Get("ProductID").ToString();
            con.Open();
            string storedProcedure = "SELECT * FROM Vw_Stubs where ProductID=" + @ProductID;
            using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
               try
                {
                    if (reader.Read())
                    {
                        Postval val = new Postval();
                        //stupproductModal.ProductDetails = new List<ProductInfo>();
                        string img = reader["Image1"].ToString(), imgsml = reader["imagePath"].ToString(),dtil=Convert.ToString(reader["Details"]);
                        img = img.Replace("\\", "/");
                        img = img.Replace(" ", "%20");
                        imgsml = imgsml.Replace("\\", "/");
                        imgsml = imgsml.Replace(" ", "%20");
                        dtil = dtil.Replace("<br>", "\n");
                        dtil = dtil.Replace("\r\n", " ");
                        dtil = dtil.Replace("”", "inch");
                        DateTime sdate = Convert.ToDateTime(reader["StartDate"].ToString());
                        DateTime edate = Convert.ToDateTime(reader["EndDate"].ToString());
                        val.Success = Convert.ToString("1");
                        val.StubsID = Convert.ToInt32(reader["StubsID"]);
                        val.ProductID = Convert.ToInt32(reader["ProductID"]);
                        val.Gender = Convert.ToString(reader["Gender"]);
                        val.Min_Age = Convert.ToInt32(reader["Min_Age"]);
                        val.Max_Age = Convert.ToInt32(reader["Max_Age"]);
                        val.DisplayLocation = Convert.ToString(reader["DisplayLocation"]);
                        val.Title = Convert.ToString(reader["Brand"]) + " " + Convert.ToString(reader["Model"]);
                        val.Category = Convert.ToString(reader["Category"]);
                        val.CallToAction = Convert.ToString(reader["CallToAction"]);
                        val.StartDate = sdate.ToString("yyyy-MM-dd");
                        val.StartTime = sdate.ToString("hh:mm tt");
                        val.EndDate = edate.ToString("yyyy-MM-dd");
                        val.EndTime = edate.ToString("hh:mm tt");
                        val.Orientation = Convert.ToString(reader["Orientation"]);
                        //Brand = Convert.ToString(reader["Brand"]),
                        //Model = Convert.ToString(reader["Model"]),
                        val.details = dtil;
                        val.SellingPrice = Convert.ToString(reader["DiscountPrice"]);
                        val.CutPrice = Convert.ToString(reader["SellingPrice"]);
                        val.quantity = Convert.ToInt32(reader["TotalStock"]);
                        val.ImageURL = WebConfigurationManager.AppSettings["ImagePath"].ToString() + img;
                        val.ImageSmall = WebConfigurationManager.AppSettings["ImagePath"].ToString() + imgsml;
                        val.locationID = 39;
                        string a = string.Empty;
                        a = "Arivunidhi";
                        val.SizeDetails = new List<SizeDetails2>();
                        BusinessTier.DisposeReader(reader);
                        string sql = "SELECT * FROM MasterPricing where deleted=0 and ProductID=" + @ProductID;
                        SqlCommand cmd2 = new SqlCommand(sql, con);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            val.SizeDetails.Add(new SizeDetails2
                            {   Size = (reader2["ProSize"]).ToString(),
                                Stock = Convert.ToInt32((reader2["Stock"])),
                                PricingID = Convert.ToInt32((reader2["PricingID"])) 
                            });
                        }
                        BusinessTier.DisposeReader(reader2);
                        Response.Write(PostData(val));
                    }
                    else
                    {
                        Postval1 val = new Postval1();
                        val.Success = Convert.ToString("0");
                        Response.Write(PostData1(val));
                        BusinessTier.DisposeReader(reader);
                        //stupproductModal.ProductDetails = new List<ProductInfo>();
                        //stupproductModal.ProductDetails.Add(new ProductInfo{Title="not available"});
                    }
                    BusinessTier.DisposeConnection(con);
                }
                catch (Exception ex)
                {
                    Postval1 val = new Postval1();
                    val.Success = Convert.ToString(0);
                    Response.Write(PostData1(val));
                    String Error = ex.ToString();
                }
                finally { BusinessTier.DisposeConnection(con); }
            }
        }       
        Response.End();
    }

    public static string PostData(Postval val)
    {
        string jsonplant = JsonConvert.SerializeObject(val);
        return jsonplant;
    }

    public static string PostData1(Postval1 val)
    {
        string jsonplant = JsonConvert.SerializeObject(val);
        return jsonplant;
    }

    //private string NewMethod()
    //{
    //    //Plant stupproductModal = new Plant();
    //    //List<ProductInfo> addressDetails = new List<ProductInfo>();
    //    SqlConnection con = BusinessTier.getConnection();
    //          {
                  
    //        string @ProductID = Request.QueryString.Get("ProductID").ToString();                
    //        con.Open();
    //        string storedProcedure = "SELECT * FROM Vw_Stubs where ProductID=" + @ProductID;
    //        using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
    //        {
    //            SqlDataReader reader = cmd.ExecuteReader();

               
    //            //string img = Convert.ToString(reader["Image1"]);
    //            try
    //            {
    //                if (reader.Read())
    //                {
    //                    Postval val = new Postval();
    //                    //stupproductModal.ProductDetails = new List<ProductInfo>();
    //                    string img = reader["Image1"].ToString(), imgsml = reader["imagePath"].ToString();
    //                    img = img.Replace("\\", "/");
    //                    imgsml = imgsml.Replace("\\", "/");
    //                    DateTime sdate = Convert.ToDateTime(reader["StartDate"].ToString());
    //                    DateTime edate = Convert.ToDateTime(reader["EndDate"].ToString());

    //                    val.Success = Convert.ToString("1");
    //                    val.StubsID = Convert.ToInt32(reader["StubsID"]);
    //                    val.ProductID = Convert.ToInt32(reader["ProductID"]);
    //                    val.Gender = Convert.ToString(reader["Gender"]);
    //                    val.Min_Age = Convert.ToInt32(reader["Min_Age"]);
    //                    val.Max_Age = Convert.ToInt32(reader["Max_Age"]);
    //                    val.DisplayLocation = Convert.ToString(reader["DisplayLocation"]);
    //                    val.Title = Convert.ToString(reader["Brand"]) + " " + Convert.ToString(reader["Model"]);
    //                    val.Category = Convert.ToString(reader["Category"]);
    //                    val.CallToAction = Convert.ToString(reader["CallToAction"]);
    //                    val.StartDate = sdate.ToString("yyyy-MM-dd");
    //                    val.StartTime = sdate.ToString("hh:mm tt");
    //                    val.EndDate = edate.ToString("yyyy-MM-dd");
    //                    val.EndTime = edate.ToString("hh:mm tt");
    //                    val.Orientation = Convert.ToString(reader["Orientation"]);
    //                        //Brand = Convert.ToString(reader["Brand"]),
    //                        //Model = Convert.ToString(reader["Model"]),
    //                    val.details = Convert.ToString(reader["Details"]);
    //                    val.SellingPrice = "RM " + reader["DiscountPrice"].ToString();
    //                    val.CutPrice = "RM " + reader["SellingPrice"];
    //                    val.quantity = Convert.ToInt32(reader["TotalStock"]);
    //                    val.ImageURL = WebConfigurationManager.AppSettings["ImagePath"].ToString() + img;
    //                    val.ImageSmall = WebConfigurationManager.AppSettings["ImagePath"].ToString() + imgsml;
                       
    //                }
    //                else
    //                {
    //                    Postval Postval = new Postval();
    //                    Postval.Success = Convert.ToString("0");
    //                //stupproductModal.ProductDetails = new List<ProductInfo>();
    //                //stupproductModal.ProductDetails.Add(new ProductInfo{Title="not available"});
    //                }
    //                BusinessTier.DisposeConnection(con);
    //            }
    //            catch (Exception ex)
    //            {
    //                Postval val = new Postval();
    //                val.Success = Convert.ToString(0);
    //                String Error = ex.ToString();
    //            }
    //            finally { BusinessTier.DisposeConnection(con); }
    //        }

    //    }
    //    //      string jsonplant = JsonConvert.SerializeObject();
    //    //return jsonplant;
    //          return null;
    //}

   
}