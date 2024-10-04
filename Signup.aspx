﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

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


<%-- <script type="text/javascript">
     var c = document.getElementById("<%=txtEmail.ClientID %>");
     c.select =
        function (event, ui)
        { this.value = ""; return false; }
    </script>--%>
    <title>EasyBuyBye | Signup </title>
   <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
     <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet">
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet">
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css'>
        <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
</head>
<body>
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <form id="frm1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <!-- header -->
    <div class="header" id="home">
        <div class="container">
            <ul>
                <li><i class="fa fa-whatsapp" aria-hidden="true"></i> <a href="https://wa.me//60193880122" target="_blank"> +60193880122</a></li>               
                <li><i class="fa fa-user-o" aria-hidden="true"></i><a href="sellatebb.aspx">
                    Sell At Easybuybye</a></li>
                <li><a href="#" data-toggle="modal" data-target="#myModal1"><i class="glyphicon glyphicon-user"
                    aria-hidden="true"></i>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </a></li>
                <li><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-unlock-alt"
                    aria-hidden="true"></i></a>
                    <asp:Button ID="lblLog" runat="server" OnClick="BtnLogout_Click" CssClass="logbtn"
                        Text="" /></li>
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
                <CartCtrl:Cart ID="Cart" runat="server" />
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
                Sign<span>Up </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Signup</li>
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
                    <div class="col-md-6 address-grid" style="background-color:#ebf1f5">
                     <style>
                        .ulsty{font-size:24px;padding-top:45px;padding-bottom:20px;padding-left:40px;list-style-type:none;line-height:20px}
                        .ulsty li{padding-bottom:40px;}
                        </style>
                        <h4 style="font-size:24px;padding-left:10px">
                       
                            Create an account and gain access to <%--<span>Information</span>--%></h4>
                            <ul class="ulsty">
                            <li>✅ Great deals</li>
                            <li>✅ Awesome promotions</li>
                            <li>✅ Members-only offers</li>

                            </ul>

                            <h4 style="font-size:24px;padding-left:10px">
                       
                           Need help? Have a question? </h4>
                           <ul  class="ulsty"><li><%--💬--%> <i class="fa fa-whatsapp" aria-hidden="true"></i>&nbsp;&nbsp;WhatsApp us now <a href="https://wa.me//60193880122" target="_blank"> +60193880122</a></li></ul>
                       <%-- <div class="mail-agileits-w3layouts">
                            <i class="fa fa-volume-control-phone" aria-hidden="true"></i>
                            <div class="contact-right">
                                <p>
                                    Telephone
                                </p>
                                <span>+603-5511 3213</span>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="mail-agileits-w3layouts">
                            <i class="fa fa-fax" aria-hidden="true"></i>
                            <div class="contact-right">
                                <p>
                                    Fax
                                </p>
                                <span>+603-5511 3212</span>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                         <div class="mail-agileits-w3layouts">
                            <i class="fa fa-whatsapp" aria-hidden="true"></i>
                            <div class="contact-right">
                                <p>
                                    WhatsApp
                                </p>
                                 <span>NEED HELP WITH REGISTRATION?</span> <br /> <span>(Click to WhatsApp us now.) </span><a href="https://web.whatsapp.com/" target="_blank"> +601160726529</a>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>

                        <div class="mail-agileits-w3layouts">
                            <i class="fa fa-envelope-o" aria-hidden="true"></i>
                            <div class="contact-right">
                                <p>
                                    Mail
                                </p>
                                <a href="mailto:admin@easybuybye.com">admin@easybuybye.com</a>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>--%>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>
                          <asp:Panel ID="Panel1" runat="server" DefaultButton="btnsumit">
                            <div class="col-md-6 contact-form">
                                <h4 class="black-w3ls">
                                    CREATE <span>ACCOUNT</span></h4>
                                <div class="styled-input agile-styled-input-top">
                                    <asp:TextBox ID="txtName" runat="server" class="textbox" onkeyup="checkchar(this);"
                                        ToolTip="You don't use Special Character like ' \ / : * ? ~ ` < > | . ''"></asp:TextBox>
                                    <label>
                                        Name</label>
                                    <span></span>
                                </div>
                               <%-- <div class="styled-input">
                                    <br />
                                    <asp:DropDownList ID="cboGender" runat="server" CssClass="sele1">
                                        <asp:ListItem Text="Select Gender" Value="0" style="color: #f00; font-style: italic;"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>
                                        Gender</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <br />
                                    <asp:DropDownList ID="cboDate" runat="server" CssClass="sele2">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="cboMonth" runat="server" CssClass="sele2">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="cboYear" runat="server" CssClass="sele2">
                                        <asp:ListItem Text="Year" Value="Year" />
                                    </asp:DropDownList>
                                    <label>
                                        Date of Birth</label>
                                    <span></span>
                                </div>--%>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtEmail" runat="server" class="textbox"></asp:TextBox>
                                    <label>
                                        Email</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtContact" runat="server" class="textbox" onkeyup="checkchar(this);"
                                        ToolTip="You don't use Special Character like ' \ / : * ? ~ ` < > | . ''"></asp:TextBox>
                                    <label>
                                        Mobile</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtPassword" runat="server" class="textbox" TextMode="Password"></asp:TextBox>
                                    <label>
                                        Password</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtRetypePassword" runat="server" class="textbox" TextMode="Password"></asp:TextBox>
                                    <label>
                                        Confirm Password</label>
                                    <span></span>
                                </div>
                                <asp:Image ID="imgCaptcha" runat="server" />
                                <br />
                                <div class="styled-input">
                                    <asp:TextBox ID="txtCaptcha" runat="server" class="tb10" Width="100px"></asp:TextBox>
                                    <label>
                                        Enter Code Below</label>
                                    <span></span>
                                </div>
                                <span>
                                    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <div class="clearfix">
                                    </div>
                                    <asp:Button ID="btnsumit" runat="server" Text="Submit" OnClick="btnsumit_OnClick" />
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
     <script src="AC/js/jquery-ui.min.js" type="text/javascript"></script>
    <link href="AC/css/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("input[id*=txtSearch]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Acservice.asmx/GetbrandName",
                        data: "{'BrandName':'" + request.term + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            //                            alert("No Match");
                        }
                    });
                }
            });
        }
    </script>
    </form>
</body>
</html>
