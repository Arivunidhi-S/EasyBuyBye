<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierLogin.aspx.cs" Inherits="SuplierLogin" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login</title>
    <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="web/css/style2.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="web/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="web/js/move-top.js"></script>
    <script type="text/javascript" src="web/js/easing.js"></script>
</head>
<body oncontextmenu="return false;">
    <form id="form1" runat="server">
    <div class="wrap">
        <div class="header">
            <div class="headertop_desc">
                <div class="call">
                    <p>
                        <span>Need help?</span> call us <span class="number">+60 1160726529</span></p>
                </div>
                <div class="account_desc">
                    <ul>
                        <li><a href="AccontInfo.aspx">My Account</a></li>
                        <li><a href="SellerSignup.aspx">Sell at EasyBuyBye</a></li>
                        <li><a href="CustomerMaster.aspx">Signup</a></li>
                        <li><a href="Login.aspx">Login</a></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="header_top">
            
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="main">
            <div class="content">
                <div class="section group">
                    <div class="col span_2_of_3">
                        <div class="contact-form">
                            <h2>
                                Seller Office Login</h2>
                            <div>
                                <span>
                                    <label>
                                        EmailID</label></span> <span>
                                            <asp:TextBox ID="txtUserID" runat="server" class="textbox"></asp:TextBox></span>
                            </div>
                              <%-- <asp:Label ID="lblsysRegno" runat="server" Style="font-size: 1em; padding: 10px 0;
                                        color: #666; font-family: 'ambleregular';" Text="EnterSysRegno">
                                    </asp:Label>--%>
                          <%--  <div>
                                <span>
                                    <label>
                                        EnterSysRegno</label>
                                  </span> <span>
                                        <asp:TextBox ID="txtsysRegno" runat="server" class="textbox"></asp:TextBox></span>
                            </div>--%>
                            <div>
                                <span>
                                    <label>
                                        Password</label></span> <span>
                                            <asp:TextBox ID="txtPassword" runat="server" class="textbox" TextMode="Password"
                                                Font-Bold="true" Font-Names="Arial"></asp:TextBox></span>
                            </div>
                            <div>
                                <span>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnForgetPassword_OnClick">Forget Password? </asp:LinkButton>
                                    <asp:Button ID="btnSignin" runat="server" Text="Sign In" OnClick="btnSignin_OnClick"
                                        class="myButton" /></span><asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col span_1_of_3">
                        <%--  <div class="contact_info">
                            <h3>
                                Find Us Here</h3>
                            <div class="map">
                                <iframe width="100%" height="175" frameborder="0" scrolling="no" marginheight="0"
                                    marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed">
                                </iframe>
                                <br>
                                <small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265"
                                    style="color: #666; text-align: left; font-size: 12px">View Larger Map</a></small>
                            </div>
                        </div>--%>
                        <div class="company_address">
                            <h3>
                                Company Information :</h3>
                            <p>
                                8-5, Pusat Dagangan UMNO Shah Alam,</p>
                            <p>
                                Lot 8, Persiaran Damai, Seksyen 11,</p>
                            <p>
                                40100 Shah Alam,Selangor Darul Ehsan, Malaysia.</p>
                            <p>
                                Phone: 603-5511 3213</p>
                            <p>
                                Fax: 603-5511 3212</p>
                            <p>
                                Email: <span>admin@easybuybye.com</span></p>
                            <!-- <p>
                                Web: <span>www.e-serbadk.com</span></p>-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
    <script type="text/javascript">
        $(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });

        });
	</script>
    <a href="#" id="toTop"><span id="toTopHover"></span></a>
    </form>
</body>
</html>
