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

public partial class web_StubsPost : System.Web.UI.Page
{
    //public string StubsID { get; private set; }
    //public string ProductID { get; private set; }
    //public string Gender { get; private set; }
    //public string Min_Age { get; private set; }

    //  public string ConnectionString { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(NewMethod());
        Response.End();
    }
         
    private string NewMethod()
    {
        Plant stupproductModal = new Plant();
        List<ProductInfo> addressDetails = new List<ProductInfo>();

        SqlConnection con = BusinessTier.getConnection();

        //string constring = @"Data Source=Maran\SQLEXPRESS;Initial Catalog=EShopping;User id = sa;password=manimaran15";
        //using (SqlConnection con = new SqlConnection(constring))
        {


            con.Open();
            string storedProcedure = "SELECT * FROM Vw_Stubs";
            using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                stupproductModal.Success = Convert.ToString("1");
                stupproductModal.ProductDetails = new List<ProductInfo>();
                //string img = Convert.ToString(reader["Image1"]);
                try
                {
                    while (reader.Read())
                    {
                        string img = reader["Image1"].ToString(), imgsml = reader["imagePath"].ToString();
                        img = img.Replace("\\", "/");
                        imgsml = imgsml.Replace("\\", "/");
                        DateTime sdate = Convert.ToDateTime(reader["StartDate"].ToString());
                        DateTime edate = Convert.ToDateTime(reader["EndDate"].ToString());
                        stupproductModal.ProductDetails.Add(new ProductInfo
                        {

                            StubsID = Convert.ToInt32(reader["StubsID"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            Gender = Convert.ToString(reader["Gender"]),
                            Min_Age = Convert.ToInt32(reader["Min_Age"]),
                            Max_Age = Convert.ToInt32(reader["Max_Age"]),
                            DisplayLocation = Convert.ToString(reader["DisplayLocation"]),
                            Title = Convert.ToString(reader["Brand"]) + " " + Convert.ToString(reader["Model"]),
                            Category = Convert.ToString(reader["Category"]),
                            CallToAction = Convert.ToString(reader["CallToAction"]),
                            StartDate = sdate.ToString("yyyy-MM-dd"),
                            StartTime = sdate.ToString("hh:mm tt"),
                            EndDate = edate.ToString("yyyy-MM-dd"),
                            EndTime = edate.ToString("hh:mm tt"),
                            Orientation = Convert.ToString(reader["Orientation"]),
                            //Brand = Convert.ToString(reader["Brand"]),
                            //Model = Convert.ToString(reader["Model"]),
                            details = Convert.ToString(reader["Details"]),
                            SellingPrice = "RM " + reader["DiscountPrice"].ToString(),
                            CutPrice = "RM " + reader["SellingPrice"],
                            quantity = Convert.ToInt32(reader["TotalStock"]),
                            ImageURL = WebConfigurationManager.AppSettings["ImagePath"].ToString() + img,
                            ImageSmall = WebConfigurationManager.AppSettings["ImagePath"].ToString() + imgsml,
                            locationID ="39",
                        });
                    }
                    BusinessTier.DisposeReader(reader);
                    BusinessTier.DisposeConnection(con);
                }
                catch (Exception ex)
                {
                    stupproductModal.Success = Convert.ToString(stupproductModal);
                    String Error = ex.ToString();
                }
                finally { BusinessTier.DisposeConnection(con); }
            }

        }
        string jsonplant = JsonConvert.SerializeObject(stupproductModal);
        return jsonplant;
    }
}