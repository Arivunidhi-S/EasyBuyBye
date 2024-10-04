<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Privacy" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
<meta property="og:title"              content="Privacy policy" />
<meta property="og:description"  content="Easybuybye privacy policy"/>
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

    <title>EasyBuyBye | Privacy Policy </title>
      <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" type="text/css" href="web/zoom/css/styleZoom.css" />
     <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fbs_click() {
            u = location.href; t = document.title; window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', 'toolbar=0,status=0,width=626,height=436');
            return false;
        }
        function twi_click() {
            u = location.href; t = document.title; window.open('https://twitter.com/intent/tweet?original_referer=' + encodeURIComponent(u) + '&url=' + encodeURIComponent(u), 'sharer', 'toolbar=0,status=0,width=626,height=436');
            return false;
        }         
    </script>
    <style>
    .ul{padding-left: 200px;color: #545454;
    line-height: 2em;}
    </style>
</head>
<body>
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <form runat="server" id="form1">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <!-- header -->
    <div class="header" id="home">
        <div class="container">
           <TopMenuCtrl:TopMenu ID="TopMenu" runat="server" />
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
    <!-- /banner_bottom_agile_info -->
    <div class="page-head_agile_info_w3l">
        <div class="container">
            <h3>
                Privacy <span>Policy </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Privacy Policy</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <!-- banner-bootom-w3-agileits -->
    <div class="banner_bottom_agile_info">
        <div class="container">
            <div class="agile_ab_w3ls_info">
                <h5>
                    Privacy <span>Policy </span>
                </h5>
                <p>
                    According to Personal Data Protection Act 2010 which was introduced by government
                    to process personal data in commercial transactions, we are required to inform you
                    about your rights with respect of your personal data that we are collecting and
                    processed during registration and data processing respectively. We will only collect
                    information wherever it is necessary for us to do so and also if it is relevant
                    to our dealings with you.
                </p>
                <p>
                    You can visit our website, www. EasyByeBuy.com and browse without providing any
                    of your personal details. During your visit to our website, you may remain anonymous
                    and at no time would we be able to identify you unless you have registered an account
                    (“EasyByeBuy account”) with us on our website and have logged on with your user
                    name and password.</p>
                <p>
                    If you have any comments or suggestions, we would be very much pleased to receive
                    them at our Customer Service page.
                </p>
                <p>
                    For your information, EasyByeBuy do not sell or trade the collected customer’s personal
                    data with any third parties. The personal information collected in online by EasyBuyBye
                    may include your below details:
                </p>
                <p>
                    <ul class="ul" >
                        <li>Name</li>
                        <li>Delivery Address</li>
                        <li>Email Address</li>
                        <li>Date of Birth</li>
                        <li>IC No. (or) Passport No. (Optional)</li>
                        <li>Gender</li>
                        <li>Telephone (or) Mobile Number</li>
                        <li>Delivery Address</li>
                        <li>Credit card details (if paid by Credit Card)</li>
                    </ul>
                </p>
                <p>
                    The customer’s personal information collected by EasyBuyBye will be used and/ or
                    shared within our corporate group and also to the third parties to deliver the products
                    that you purchase from our website. For example, we may pass your name and address
                    on to a third party such as our Shipping (or) Courier Service Company or supplier
                    of your choice in order to make delivery of the product to you.
                </p>
                <p>
                    EasyBuyBye also ensures that all the information collected by us will be safely
                    and securely stored. We protect your personal information by:
                </p>
                <p>
                    <ul class="ul" >
                        <li>Allowing access to personal information only through secured passwords.</li>
                        <li>Maintaining technology products to prevent unauthorised user/computer access.</li>
                        <li>Securely destroy your personal information when it is no longer needed for us.</li>
                        <li>EasyBuyBye uses 128-bit SSL (Secure Sockets Layer) encryption technology when processing
                            your financial details.</li>
                    </ul>
                </p>
                <p>
                    EasyBuyBye reserves the right to modify or change the Privacy Policy at any time.
                    Any changes to this policy will be published on our website. You should check this
                    Policy each time you access our website so as to be aware of the most recent updates
                    in the Policy. If you are not satisfied with the way in which we handle your enquiry
                    or complaint, please don't hesitate to contact Customer Service.
                </p>
            </div>
        </div>
    </div>
    <!--//single_page-->
    <!-- footer -->
    <!-- #Include file="IncludeFooter.html" -->
    <!-- //footer -->
    <a href="#home" class="scroll" id="toTop" style="display: block;"><span id="toTopHover"
        style="opacity: 1;"></span></a>
    <!-- js -->
    <script type="text/javascript" src="web/js/jquery-2.1.4.min.js"></script>
    <!-- //js -->
    <script src="web/js/modernizr.custom.js"></script>
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

            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>
    <!-- //here ends scrolling icon -->
    <!-- for bootstrap working -->
    <script type="text/javascript" src="web/js/bootstrap.js"></script>
    <!-- for zoom working -->
    <%--<script type="text/javascript" src="web/zoom/js/jquery-1.11.1.min.js"></script>--%>
    <script type="text/javascript" src="web/zoom/js/jqzoom.js"></script>
    <script type="text/javascript">
        $("#bzoom").zoom({
            zoom_area_width: 300,
            autoplay_interval: 3000,
            small_thumbs: document.getElementById("param1").value,
            autoplay: false
        });
    </script>
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
