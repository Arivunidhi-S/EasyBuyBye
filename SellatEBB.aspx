<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellatEBB.aspx.cs" Inherits="SellatEBB" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-164377292-1"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-164377292-1');
</script>
<!-- Global site tag (gtag.js) - Google Analytics -->

<!-- Google Tag Manager -->
<script>    (function (w, d, s, l, i) {
        w[l] = w[l] || []; w[l].push({ 'gtm.start':
new Date().getTime(), event: 'gtm.js'
        }); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
    })(window, document, 'script', 'dataLayer', 'GTM-KXJ9TVD');</script>
<!-- End Google Tag Manager -->
    <title>EasyBuyBye | Seller Register </title>
    <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="web/css/font-awesome.css" rel="stylesheet">
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet">
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css'>
    <script type="text/javascript">
        function OpenWindow() {
            var Mleft = (screen.width / 2) - (600 / 2); var Mtop = (screen.height / 2) - (300 / 2); window.open('web/images/tc_sellers.htm', 'newwindow', config = 'width=600,height=500,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'');
        }
    </script>
</head>
<body>
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->

<!-- Facebook Pixel Code -->
<script>
    !function (f, b, e, v, n, t, s) {
        if (f.fbq) return; n = f.fbq = function () {
            n.callMethod ?
n.callMethod.apply(n, arguments) : n.queue.push(arguments)
        };
        if (!f._fbq) f._fbq = n; n.push = n; n.loaded = !0; n.version = '2.0';
        n.queue = []; t = b.createElement(e); t.async = !0;
        t.src = v; s = b.getElementsByTagName(e)[0];
        s.parentNode.insertBefore(t, s)
    } (window, document, 'script',
'https://connect.facebook.net/en_US/fbevents.js');

    fbq('init', '517994975548842');
    fbq('track', 'PageView');
</script>
<noscript>
<img height="1" width="1"
src="https://www.facebook.com/tr?id=517994975548842&ev=PageView
&noscript=1"/>
</noscript>
<!-- End Facebook Pixel Code -->
    <form id="frm1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <!-- header -->
    <div class="header" id="home">
        <div class="container">
            <ul>
                  <li><i class="fa fa-whatsapp" aria-hidden="true"></i> <a href="https://web.whatsapp.com/" target="_blank"> +601160726529</a></li>    
                <li><i class="fa fa-unlock-alt" aria-hidden="true"></i><a href="http://admin.easybuybye.com/SellerLogin.aspx">
                   <strong> Seller Login </strong></a></li>
            </ul>
        </div>
    </div>
    <!-- //header -->
    <!-- header-bot -->
    <div class="header-bot">
        <SBCtrl:SearchBox ID="SearchBox" runat="server" />
    </div>
    <!-- //header-bot -->
    <!-- banner -->
    <div class="ban-top">
        <div class="container">
            <div class="top_nav_left">
                <nav class="navbar navbar-default">
			  <div class="container-fluid">
				<!-- Brand and toggle get grouped for better mobile display -->
				<div class="navbar-header">
				  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				  </button>
				</div>
				<!-- Collect the nav links, forms, and other content for toggling -->
					<div class="collapse navbar-collapse menu--shylock" id="bs-example-navbar-collapse-1">
				  <MenuCtrl:MenuControls id="MenuUserControls" runat="server" />
				</div>
			  </div>
			</nav>
            </div>
            <div class="top_nav_right">
               <%-- <CartCtrl:Cart ID="Cart" runat="server" />--%>
            </div>
            <div class="clearfix">
            </div>
        </div>
    </div>
    <!-- //banner-top -->
    <!-- Modal1 -->
    <!-- //Modal1 -->
    <!-- Modal2 -->
    <!-- //Modal2 -->
    <!-- /banner_bottom_agile_info -->
    <div class="page-head_agile_info_w3l">
        <div class="container">
            <h3>
                Seller <span>Register </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Seller Register</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <!--/contact-->
    <div class="banner_bottom_agile_info">
        <div class="container">
            <div class="agile-contact-grids">
                <div class="agile-contact-left">
                    <div class="regi">
                        <asp:Image ID="Image1" runat="server" ImageUrl="web\images\Register.png" /></div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>
                         <asp:Panel ID="Panel1" runat="server" DefaultButton="btnsumit">
                            <div class="col-md-6 contact-form">
                                <%--  <h4 class="white-w3ls">
                                    Seller  <span>Register</span></h4>--%>
                                <div class="styled-input agile-styled-input-top">
                                    <asp:TextBox ID="txtName" runat="server" class="textbox" ToolTip="You don't use Special Character like ' \ / : * ? ~ ` < > | . ''"></asp:TextBox>
                                    <%--onkeyup="checkchar(this);"--%>
                                    <label>
                                        Contact Name <i style="color: Red;">*</i></label>
                                    </span> <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtICnumber" runat="server" class="textbox"></asp:TextBox>
                                    <label>
                                        IC No/Passport Number <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtContact" runat="server" class="textbox" onkeyup="checkchar(this);"
                                        ToolTip="You don't use Special Character like ' \ / : * ? ~ ` < > | . ''"></asp:TextBox>
                                    <label>
                                        Mobile <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtEmail" runat="server" class="textbox"></asp:TextBox>
                                    <label>
                                        Email <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <br />
                                    <asp:DropDownList ID="ddlRegistrationType" runat="server" CssClass="sele1">
                                        <asp:ListItem Text="Select Registration Type" Value="0" style="color: #f00; font-style: italic;
                                            background-color: #e3e3e3"></asp:ListItem>
                                        <asp:ListItem Text="Company Seller" Value="Business"></asp:ListItem>
                                        <asp:ListItem Text="Individual Seller" Value="Individual"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>
                                        Registration Type <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtAddress" runat="server" class="textbox" TextMode="MultiLine"
                                        Height="51px">
                                    </asp:TextBox>
                                    <label>
                                        Address</label>
                                    <span></span>
                                </div>
                                
                                <div class="styled-input">
                                    <asp:TextBox ID="txtCity" runat="server" class="textbox"> </asp:TextBox>
                                    <label>
                                        City <%--<i style="color: Red;">*</i></label>--%>
                                    <span></span>
                                </div>
                                  <div class="styled-input">
                                <br />
                                 <asp:DropDownList ID="txtState" runat="server" CssClass="sele1">
                                        <asp:ListItem Text="Select State" Value="0" style="color: #f00; font-style: italic;
                                            background-color: #e3e3e3"></asp:ListItem>                                                                          
                                                                <asp:ListItem Text="Johor" Value="Johor" />
                                                                <asp:ListItem Text="Kedah" Value="Kedah" />
                                                                <asp:ListItem Text="Kuala Lumpur" Value="Kuala Lumpur" />
                                                                <asp:ListItem Text="Kelantan" Value="Kelantan" />
                                                                <asp:ListItem Text="Melaka" Value="Melaka" />
                                                                <asp:ListItem Text="Negeri Sembilan" Value="Negeri Sembilan" />
                                                                <asp:ListItem Text="Pahang" Value="Pahang" />
                                                                <asp:ListItem Text="Penang" Value="Penang" />
                                                                <asp:ListItem Text="Perak" Value="Perak" />
                                                                <asp:ListItem Text="Perlis" Value="Perlis" />
                                                                <asp:ListItem Text="Sabah" Value="Sabah" />
                                                                <asp:ListItem Text="Sarawak" Value="Sarawak" />
                                                                <asp:ListItem Text="Selangor" Value="Selangor" />
                                                                <asp:ListItem Text="Terengganu" Value="Terengganu" />
                                                                <asp:ListItem Text="WP Labuan" Value="WP Labuan" />
                                                                <asp:ListItem Text="WP Putrajaya" Value="WP Putrajaya" />
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="txtState" runat="server" class="textbox">
                                    </asp:TextBox>--%>
                                    <label>
                                        State</label>
                                    <span></span>
                                </div>
                            </div>
                            <div class="col-md-6 contact-form">
                              
                                 <div class="styled-input agile-styled-input-top">
                                    <asp:TextBox ID="txtPostcode" runat="server" class="textbox" onkeyup="checkDec(this);"></asp:TextBox>
                                    <label>
                                        Postcode</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtPassword" runat="server" class="textbox"> </asp:TextBox>
                                    <label>
                                        Password <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtRetypePassword" runat="server" class="textbox" > </asp:TextBox>
                                    <label>
                                        Retype Password <i style="color: Red;">*</i></label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtAboutProduct" runat="server" class="textbox" TextMode="MultiLine"
                                        Height="123px">
                                    </asp:TextBox>
                                    <label>
                                        About Product</label>
                                    <span></span>
                                </div>
                                 <div class="styled-input">
                                    <asp:TextBox ID="txtPromoCode" runat="server" class="textbox" onkeyup="checkDec(this);"></asp:TextBox>
                                    <label>
                                        Promo Code (Optional)</label>
                                    <span></span>
                                </div>
                                <span>
                                    <asp:CheckBox ID="chktc" runat="server" />&nbsp;<label style="color: Black; font-size: 16px;
                                        font-weight: lighter; padding-bottom: 15px">
                                        I've read and understood easybuybye
                                    </label>
                                    <a href="" onclick="OpenWindow();">Terms & Conditions</a>. </span>
                                <br />
                                <asp:Image ID="imgCaptcha" runat="server" />
                                <br />
                                <div class="styled-input">
                                    <asp:TextBox ID="txtCaptcha" runat="server" class="tb10" Width="100px"></asp:TextBox>
                                    <label>
                                        Enter Code Below</label>
                                    <span></span>
                                </div>
                                <span>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label><br />
                                    <asp:Button ID="btnsumit" runat="server" Text="Submit" OnClick="btnBusinessRegister_OnClick" />
                                </span>
                            </div>
                               </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <!--//contact-->
    <!-- footer -->
    <!-- #Include file="IncludeFooter.html" -->
    <!-- //footer -->
    <!-- login -->
    <!-- //login -->
    <a href="#home" class="scroll" id="toTop" style="display: block;"><span id="toTopHover"
        style="opacity: 1;"></span></a>
    <!-- js -->
    <script type="text/javascript" src="web/js/jquery-2.1.4.min.js"></script>
    <!-- //js -->
    <script src="web/js/modernizr.custom.js"></script>
    <!-- Custom-JavaScript-File-Links -->
    <!-- cart-js -->
    <script src="web/js/minicart.min.js"></script>
    <script>
        // Mini Cart
        paypal.minicart.render({
            action: '#'
        });

        if (~window.location.search.indexOf('reset=true')) {
            paypal.minicart.reset();
        }
    </script>
    <!-- //cart-js -->
    <!-- script for responsive tabs -->
    <script src="web/js/easy-responsive-tabs.js"></script>
    <script>
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true,   // 100% fit in a container
                closed: 'accordion', // Start closed if in accordion view
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
            $('#verticalTab').easyResponsiveTabs({
                type: 'vertical',
                width: 'auto',
                fit: true
            });
        });
    </script>
    <!-- //script for responsive tabs -->
    <!-- stats -->
    <script src="web/js/jquery.waypoints.min.js"></script>
    <script src="web/js/jquery.countup.js"></script>
    <script>
        $('.counter').countUp();
    </script>
    <!-- //stats -->
    <!-- start-smoth-scrolling -->
    <script type="text/javascript" src="web/js/move-top.js"></script>
    <script type="text/javascript" src="web/js/jquery.easing.min.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    <!-- here stars scrolling icon -->
    <script type="text/javascript">
        $(document).ready(function () {

            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear'
            };


            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>
    <!-- //here ends scrolling icon -->
    <!-- for bootstrap working -->
    <script type="text/javascript" src="web/js/bootstrap.js"></script>
    </form>
</body>
</html>
