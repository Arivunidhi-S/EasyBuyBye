using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace StupWeb
//{
    public class Plant
    {
      

        public string Success { get; set; }


        public List<ProductInfo> ProductDetails { get; set; }
        //public string Genus { get; internal set; }
    }

    public class ProductInfo
    {
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
        public int quantity{ get; set; }
        public string ImageURL { get; set; }
        public string ImageSmall { get; set; }
        public string locationID { get; set; }




    }
//}