<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WomensDay.aspx.cs" Inherits="WomensDay" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
    <title>EasyBuyBye | Women'sDay </title>
    <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <%--<link rel="stylesheet" href="web/css/flexslider.css" type="text/css" media="screen" />--%>
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" type="text/css" href="web/zoom/css/styleZoom.css" />
    <style type="text/css">
        div.background
        {
            text-align: center;
            float: inherit;
            background-size: 99% 100%;
            position: static;
            width: 285px;
            height: 190px;
            border: 2px solid #B81D22;          
        }
        
        div.transbox
        {
            margin: 187px 0px 0px 0px;
            background-color: #ffffff;
            border: 2px solid #B81D22;
            width: 283px;
            opacity: 0.9;
            filter: alpha(opacity=60); /* For IE8 and earlier */
         
        }
        
        div.transbox p, .link
        {
            z-index: 0;
            margin: 5%;
            font-weight: bold;
            color: #000000;
        }
        </style>
</head>
<body>
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
       <SBCtrl:SearchBox id="SearchBox" runat="server" />
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
               <CartCtrl:Cart id="Cart" runat="server" />
            </div>
            <div class="clearfix">
            </div>
        </div>
    </div>
    <!-- /banner_bottom_agile_info -->
    <div class="page-head_agile_info_w3l">
        <div class="container">
            <h3>
          Women's Day Deals
            </h3> 
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Women's Day</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <!-- banner-bootom-w3-agileits -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <!-- mens -->
             <table width="100%">
                        <tr align="center">
                        
                            <td>
                                <a id="A1" runat="server"  class="link" href="https://www.easybuybye.com/Products.aspx?Param=30&Param1=0">
                                    <div class="background" style="background-image: url(web/images/Tudung.jpg);">
                                        <div class="transbox">
                                            <p>
                                                Shawal & Tudung
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </td>
                            <td>
                                <a runat="server" class="link" href="https://www.easybuybye.com/Products.aspx?Param=35&Param1=0">
                                    <div class="background" style="background-image: url(web/images/Baju.jpg);">
                                        <div class="transbox">
                                            <p>
                                               Baju / Abaya
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </td>
                            <td>
                                <a href="https://www.easybuybye.com/Products.aspx?Param=52&Param1=0" class="link">
                                    <div class="background" style="background-image: url(web/images/Kaftan.jpg);">
                                        <div class="transbox">
                                            <p>
                                                Kaftan
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </td>
                                <td>
                                <a id="A2" href="https://www.easybuybye.com/Products.aspx?Param=37&Param1=0" runat="server"  class="link">
                                    <div class="background" style="background-image: url(web/images/sarees.jpg);">
                                        <div class="transbox">
                                            <p>
                                                Sarees
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                    
                       
                    </table>
        </div>
    </div>
    <!-- //mens -->
    <!-- footer -->
    <!-- #Include file="IncludeFooter.html" -->
    <!-- //footer -->
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
    <!-- single -->
    <%--<script src="web/js/imagezoom.js"></script>--%>
    <!-- single -->
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
    <!-- FlexSlider -->
    <script src="web/js/jquery.flexslider.js"></script>
    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
            });
        });
    </script>
    <!-- //FlexSlider-->
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
            /*
            var defaults = {
            containerID: 'toTop', // fading element id
            containerHoverID: 'toTopHover', // fading element hover id
            scrollSpeed: 1200,
            easingType: 'linear' 
            };
            */

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
    </form>
</body>
</html>
