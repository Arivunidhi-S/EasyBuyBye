using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Security.Cryptography;
using System.Globalization;

public partial class PayTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            var MerchantCode = ConfigurationManager.AppSettings["MerchantId"].ToString(CultureInfo.InvariantCulture);
            var verifyKey = ConfigurationManager.AppSettings["VerifyKey"].ToString(CultureInfo.InvariantCulture);  
       
            var orderid = Request.Form["RefNo"];
            var amount = Request.Form["Amount"];
            var ProdDesc = Request.Form["ProdDesc"];
            var UserName = Request.Form["UserName"];
            var UserEmail = Request.Form["UserEmail"];
            var UserContact = Request.Form["UserContact"];
            var Remark = Request.Form["Remark"];
            var Signature = GetVCode(verifyKey.ToString() + MerchantCode.ToString() + orderid.ToString() + amount.Replace(".", string.Empty) + "MYR");
            var ResponseURL = ConfigurationManager.AppSettings["ImagePath"].ToString() + "GatewayReturnTicket.aspx";
            var BackendURL = ConfigurationManager.AppSettings["ImagePath"].ToString() + "GatewayReturnTicket.aspx";

            //Response.Write("MerchantCode=" + MerchantCode + "<br>");
            //Response.Write("verifyKey=" + verifyKey + "<br>");
            //Response.Write("orderid=" + orderid + "<br>");
            //Response.Write("Amount=" + amount + "<br>");
            //Response.Write("ProdDesc=" + ProdDesc + "<br>");
            //Response.Write("Remark=" + Remark + "<br>");
            //Response.Write("UserName=" + UserName + "<br>");
            //Response.Write("UserEmail=" + UserEmail + "<br>");

            //Response.Write("UserContact=" + UserContact + "<br>");
            //Response.Write("Remark=" + Remark + "<br>");
            //Response.Write("Signature=" + Signature + "<br>");
            //Response.Write("ResponseURL=" + ResponseURL + "<br>");
            //Response.Write("BackendURL=" + BackendURL);

            BusinessTier.Ticket(conn, "1", MerchantCode.ToString(), orderid.ToString(), amount.ToString(), "MYR", ProdDesc.ToString(), UserName.ToString(), UserEmail.ToString(), UserContact.ToString(), Remark.ToString(), Signature.ToString(), "", "", "", "", "", "1", "N");
            BusinessTier.DisposeConnection(conn);

            Response.Write("<form name='pay' id='pay' action='https://payment.ipay88.com.my/epayment/entry.asp' method='post' >");
            Response.Write("<input type=hidden name='MerchantCode' value='" + MerchantCode + "'>");
            Response.Write("<input type=hidden name='PaymentId' value=''>");
            Response.Write("<input type=hidden name='RefNo' value='" + orderid.ToString() + "'>");
            Response.Write("<input type=hidden name='Amount' value=" + amount.ToString() + ">");
            Response.Write("<input type=hidden name='Currency' value='MYR'>");
            Response.Write("<input type=hidden name='ProdDesc' value='" + ProdDesc.ToString() + "'>");
            Response.Write("<input type=hidden name='UserName' value='" + UserName.ToString() + "'>");
            Response.Write("<input type=hidden name='UserEmail' value='" + UserEmail.ToString() + "'>");
            Response.Write("<input type=hidden name='UserContact' value='" + UserContact.ToString() + "'>");
            Response.Write("<input type=hidden name='Remark' value='" + Remark.ToString() + "'>");
            Response.Write("<input type=hidden name='Lang' value='UTF-8'>");
            Response.Write("<input type=hidden name='Signature' value='" + Signature + "'>");
            Response.Write("<input type=hidden name='ResponseURL' value='" + ResponseURL.ToString() + "'>");
            Response.Write("<input type=hidden name='BackendURL' value='" + BackendURL.ToString() + "'>");
            Response.Write("</form>");
            Response.Write("<script>pay.submit();</script>");
        
    }
    catch (Exception ex)
{
    Response.Write(ex.ToString());
    InsertLogAuditTrail("1", "PayTicket", "Page_Load", ex.ToString(), "Audit");
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

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }
}