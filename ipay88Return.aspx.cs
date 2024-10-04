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


public partial class ipay88Return : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {      
        try
        {   
            //var Param = "99"; //31
            //var MerchantCode = "M03359";
            //var PaymentId = "2";
            //var RefNo = "17032133";
            //var Amount = "80.00";
            //var Currency = "MYR";
            //var Remark = "PWD";
            //var TransId = "T112427185000";
            //var AuthCode = "T50155";
            //var Status = "0";
            //var ErrDesc = "";
            //var ReturnSignature = "hG0g7B9wLOil34gpZig+m4qYp78=";

            var Param = Request.QueryString.Get("param1").ToString();
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

            string payment = "Failure";
            if (Status == "1")
            {
                payment = "Success";
            }
            Response.Redirect("OrderConfirmation.aspx?payment=" + payment.ToString().Trim() + "&refNo=" + RefNo.ToString() + "&Amount=" + Amount.ToString() + "&Remark=" + Remark.ToString() + "&TransId=" + TransId.ToString() + "&AuthCode=" + AuthCode.ToString() + "&Status=" + Status.ToString() + "&ErrDesc=" + ErrDesc.ToString() + "&Signature=" + ReturnSignature.ToString() + "&param1=" + Param.ToString() + "&MerchantCode=" + MerchantCode.ToString() + "&PaymentId=" + PaymentId.ToString() + "&Currency=" + Currency.ToString(), false);
        
        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            InsertLogAuditTrail("1", "ipay88Return", "Page_Load", ex.ToString(), "Audit");
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