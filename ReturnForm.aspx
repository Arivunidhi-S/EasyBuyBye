<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnForm.aspx.cs" Inherits="ReturnForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Returm Form EasyBuyBye</title><link rel="shortcut icon" href="web/Images/Slogo.png" />
    <style type="text/css">
        #td tr td
        {
            border: 1px solid gray;
        }
    </style>
</head>
<body>
    <br />
    <table style="font-family: Cambria Math" align="center" width="900" border="0px" >
        <tr>
            <td>
                <table id="td">
                    <tr>
                        <td style="width: 10%">
                            <img src="web/images/Maillogo.png" alt="" />
                        </td>
                        <td align="center">
                            <b><font size="+2">
                                <asp:Label ID="lbltitle" runat="server" Text="Return Form"></asp:Label></font></b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" id="td1">
                    <tbody>
                        <tr>
                            <td>
                                <strong>Invoice No : </strong> <%= dtreport.Rows[0][2].ToString()%>
                            </td>
                            <td>
                                <strong>Return Type : </strong>Drop Off
                            </td>
                            <td width="30%" rowspan="2">
                                EasyBuyBye ecommerce package, DO NOT Charge for customer
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Date : </strong> <%= dtreport.Rows[0][1].ToString()%>
                            </td>
                            <td>
                                <strong>Return Method : </strong>Refund Money
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellspacing="5px" cellpadding="5px" id="td">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <font><b>From </b></font>
                                <br />
                                <br />
                                <b>
                                    <%= dtreport.Rows[0][3].ToString()%>&nbsp;</b><br />
                                <%= dtreport.Rows[0][4].ToString()%><br />
                                <%= dtreport.Rows[0][5].ToString()%><br />
                                <%= dtreport.Rows[0][6].ToString()%>
                                &nbsp;<%= dtreport.Rows[0][7].ToString()%><br />
                                <%= dtreport.Rows[0][8].ToString()%>&nbsp;<%= dtreport.Rows[0][9].ToString()%><br />
                                <br />
                                Phone:&nbsp;<%= dtreport.Rows[0][10].ToString()%><br />
                                <br />
                            </td>
                            <td valign="top">
                                <font><b>To EasyBuyBye Warehouse </b></font>
                                <br />
                                <br />
                                ACCOUNT NO : 071707004 (CR4)<br />
                                SERBA DINAMIK IT SOLUTIONS SDN BHD <font size="1px">(919896-A)</font><br />
                                <font>F-1-22 1st Floor, Vista Alam,<br />
                                    Jalan Ikhtisas 14/1, Seksyen 14,
                                    <br />
                                    40100 Shah Alam,<br />
                                    Selangor Darul Ehsan,<br />
                                    Malaysia<br />
                                </font>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellspacing="5px" cellpadding="5px">
                    <tbody>
                        <tr>
                            <td align="left">
                                <strong>Item(s)</strong>
                            </td>
                            <td align="right" style="width: 30%;">
                                <strong>Reason for return</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <%= dtreport.Rows[0][11].ToString()%>&nbsp; <%= dtreport.Rows[0][12].ToString()%>
                            </td>
                            <td align="right" style="width: 30%;">
                                <%= dtreport.Rows[0][13].ToString()%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
