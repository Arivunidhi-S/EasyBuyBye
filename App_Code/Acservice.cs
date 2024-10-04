using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Acservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Acservice : System.Web.Services.WebService {

    public Acservice () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod]

    public List<string> GetbrandName(string BrandName)
    {
        List<string> empResult = new List<string>();
        using (SqlConnection con = BusinessTier.getConnection())
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct top 10 Tags from MSP_SearchTags where Deleted=0 and Tags like ''+@SearchbrandName+'%' order by Tags";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@SearchbrandName", BrandName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empResult.Add(dr["Tags"].ToString());
                }
                con.Close();
                return empResult;
            }
        }
    }
}
