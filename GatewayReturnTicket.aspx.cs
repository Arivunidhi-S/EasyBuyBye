using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Drawing;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class GatewayReturnTicket : System.Web.UI.Page
{

    public class Postval
    {
        public string MerchantCode { get; set; }
        public string PaymentId { get; set; }
        public string RefNo { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Remark { get; set; }
        public string TransId { get; set; }
        public string AuthCode { get; set; }
        public string Status { get; set; }
        public string ErrDesc { get; set; }
        public string Signature { get; set; }    
    }

    public static string PostData(Postval Postval)
    {
        string response = string.Empty;
        HttpClient client = new HttpClient();
        string PostString = JsonConvert.SerializeObject(Postval);

        var content = new StringContent(PostString, Encoding.UTF8, "application/json");
        var result = client.PostAsync("https://ebbapi.easybuybye.com/api/WebPayment", content).Result;

        if (result.IsSuccessStatusCode == false)
        {
            var contents = result.Content.ReadAsStringAsync().Result;
            response = contents;

        }
        else if (result.IsSuccessStatusCode == true)
        {
            var contents = result.Content.ReadAsStringAsync().Result;
            response = contents;
        }

        return response;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {

            //var MerchantCode = "1234";
            //var PaymentId = "0001";
            //var RefNo = "02235";
            //var Amount = "222.00";
            //var Currency = "MYR";
            //var Remark = "EBB_Bazaar";
            //var TransId = "02265656";
            //var AuthCode = "0";
            //var Status = "1";
            //var ErrDesc = "0";
            //var ReturnSignature = "FHADHADA56DJSFS15456545BSDFJDSFH";

            var MerchantCode = Request.Form["MerchantCode"];
            var PaymentId = Request.Form["PaymentId"];
            var RefNo = Request.Form["RefNo"];
            var Amount = Request.Form["Amount"];
            var Currency = Request.Form["Currency"];
            var Remark = Request.Form["Remark"];
            var TransId = Request.Form["TransId"];
            var AuthCode = Request.Form["AuthCode"];
            var Status = Request.Form["Status"];
            var ErrDesc = Request.Form["ErrDesc"];
            var ReturnSignature = Request.Form["Signature"];



            if (string.IsNullOrEmpty(Request.Form["MerchantCode"]))
            {
                MerchantCode = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["PaymentId"]))
            {
                PaymentId = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["RefNo"]))
            {
                RefNo = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["Amount"]))
            {
                Amount = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["Currency"]))
            {
                Currency = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["Remark"]))
            {
                Remark = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["TransId"]))
            {
                TransId = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["AuthCode"]))
            {
                AuthCode = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["Status"]))
            {
                Status = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["ErrDesc"]))
            {
                ErrDesc = "0";
            }
            if (string.IsNullOrEmpty(Request.Form["Signature"]))
            {
                ReturnSignature = "0";
            }

            string payment = "Failure";
            if (Status == "1")
            {
                payment = "Success";
            }

            Postval Postval = new Postval();
            Postval.MerchantCode = MerchantCode.ToString();
            Postval.PaymentId =PaymentId.ToString();
            Postval.RefNo = RefNo;
            Postval.Amount = Amount;
            Postval.Currency = "MYR";
            Postval.Remark = Remark;
            Postval.TransId = TransId;
            Postval.AuthCode = AuthCode.ToString();
            Postval.Status = Status;
            Postval.ErrDesc = ErrDesc.ToString();
            Postval.Signature = ReturnSignature.ToString();
            PostData(Postval);



           //Response.Write("MerchantCode=" + MerchantCode + "<br>");
           //Response.Write("PaymentId=" + PaymentId + "<br>");
           //Response.Write("RefNo=" + RefNo + "<br>");
           //Response.Write("Amount=" + Amount + "<br>");
           //Response.Write("Currency=" + Currency + "<br>");
           //Response.Write("Remark=" + Remark + "<br>");
           //Response.Write("TransId=" + TransId + "<br>");
           //Response.Write("AuthCode=" + AuthCode + "<br>");
           //Response.Write("Status=" + Status + "<br>");
           //Response.Write("ErrDesc=" + ErrDesc + "<br>");
           //Response.Write("ReturnSignature=" + ReturnSignature + "<br>");
            //var TransId = "A23423434124";
            //var Status = "0";
            //if (Status == "1")
            //{
            //    lblStatus.Text = "** Payment Success ! **";
            //    lblStatus.ForeColor = Color.Green;
            //    lblTransID.Text = "TransID : " + TransId.ToString();
            //}
            //else
            //{
            //    lblStatus.Text = "** Payment Failure ! **";
            //    lblStatus.ForeColor = Color.Red;
            //}

           // BusinessTier.Ticket(conn, "1", "", RefNo.ToString(), "", "", "", "", "", "", "", "", TransId.ToString(), AuthCode.ToString(), Status.ToString(), ErrDesc.ToString(), ReturnSignature.ToString(), "1", "U");
            BusinessTier.DisposeConnection(conn);


            //string _regId = RefNo.ToString();
            //string _refNo = RefNo.ToString();
            //string _Amount = Amount.ToString();
            //string _Remark = Remark.ToString();
            //string _TransId = TransId.ToString();
            //string _AuthCode = AuthCode.ToString();
            //string _Status = Status.ToString();
            //string _ErrDesc = ErrDesc.ToString();

            string rem = string.Empty;
            string[] Ext = Remark.Split('-');
            rem = Ext[0].ToString();

           // Response.Redirect("https://wcit2020.org/payment-response?refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString());
            if (rem.ToString().Trim() == "EBB_Bazaar")
            {
                string url = "http://bazaar.easybuybye.com/Bazaar_OrderConfirmation.aspx?MerchantCode=" + MerchantCode.ToString() + "&PaymentId=" + PaymentId.ToString() + "&refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString() + "&Signature=" + ReturnSignature.ToString();
                Response.Write("<script>window.location.replace('" + url + "','_parent');</script>");

                //Server.Transfer("http://bazaar.easybuybye.com/Bazaar_OrderConfirmation.aspx?MerchantCode=" + MerchantCode.ToString() + "&PaymentId=" + PaymentId.ToString() + "&refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString() + "&Signature=" + ReturnSignature.ToString());
            }
            else
            {
               // Server.Transfer("http://m.easybuybye.com/payment-response?refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString() + "&Signature=" + ReturnSignature.ToString());
                string url ="http://m.easybuybye.com/payment-response?payment=" + payment.ToString() + " &refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString() + "&Signature=" + ReturnSignature.ToString();
                Response.Write("<script>window.location.replace('" + url + "','_parent');</script>");
            }
            //Response.Write("<form name='pay' id='pay' action='https://wcit2020.org/wcit/public/payment-response' method='post' >");
            //Response.Write("<input type=hidden name='refNo' value='" + RefNo.ToString() + "'>");
            //Response.Write("<input type=hidden name='Amount' value=" + Amount.ToString() + ">");          
            //Response.Write("<input type=hidden name='Remark' value='" + Remark.ToString() + "'>");
            //Response.Write("<input type=hidden name='TransId' value='" + TransId.ToString() + "'>");
            //Response.Write("<input type=hidden name='AuthCode' value='" + AuthCode.ToString() + "'>");
            //Response.Write("<input type=hidden name='Status' value='" + Status.ToString() + "'>");
            //Response.Write("<input type=hidden name='ErrDesc' value='" + ErrDesc.ToString() + "'>");

            //Response.Write("</form>");
            //Response.Write("<script>pay.submit();</script>");



            //try
            //{

            //    //string _regId = "1234";
            //    //string _refNo = "789";
            //    //string _Amount = "100.00";
            //    //string _Remark = "KL";
            //    //string _TransId = "678";
            //    //string _AuthCode = "01";
            //    //string _Status = "01";
            //    //string _ErrDesc = "Success";
            //    //----------------------------------------------------------

            //    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://wcit2020.org/wcit/public/payment-response");
            //    httpWebRequest.ContentType = "application/json";
            //    httpWebRequest.Method = "POST";

            //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //    {
            //        string json = new JavaScriptSerializer().Serialize(new
            //        {
            //            //regId = _regId,
            //            refNo = _refNo,
            //            Amount = _Amount,
            //            Remark = _Remark,
            //            TransId = _TransId,
            //            AuthCode = _AuthCode,
            //            Status = _Status,
            //            ErrDesc = _ErrDesc,
            //        });

            //        streamWriter.Write(json);
            //    }

            //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //    {
            //        var result = streamReader.ReadToEnd();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.ToString());
            //}
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            InsertLogAuditTrail("1", "GatewayReturnTicket", "Page_Load", ex.ToString(), "Audit");
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