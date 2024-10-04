<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
    <script>        (function (w, d, s, l, i) {
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
        <img height="1" width="1" src="https://www.facebook.com/tr?id=517994975548842&ev=PageView
&noscript=1" />
    </noscript>
    <!-- End Facebook Pixel Code -->
    <title>EasyBuyBye | Home </title>
    <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta http-equiv="content-language" content="en-us" />
    <%--<meta http-equiv="X-Frame-Options" content="deny" />--%>
    <%--  <meta http-equiv="Content-Security-Policy" content="default-src 'self'">--%>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="shopping,online shopping,buy online,buy now,shop now,promotion,sale,fashion,electronics,men fashion,women fashion,grocery,kurtis,tops,sarees,punjabi dress,punjabi suit,salwar kameez,churidar,jacket,cap,round neck,polo,tshirt,t-shirt,laptop,mobile,phone,Lenovo,Asus,HP,Dell,wholesale,product,item,chocolate,biscuit,cookies,tudung,shawls,Denim,Crepe,Cotton,hairgel,chipsmore,jacobs,bake,tudor,tango,kandos,travel,travelloc,travel lock,easybuybye" />
    <meta name="description" content="shopping,online shopping,buy online,buy now,shop now,promotion,sale,fashion,electronics,men fashion,women fashion,grocery,kurtis,tops,sarees,punjabi dress,punjabi suit,salwar kameez,churidar,jacket,cap,round neck,polo,tshirt,t-shirt,laptop,mobile,phone,Lenovo,Asus,HP,Dell,wholesale,product,item,chocolate,biscuit,cookies,tudung,shawls,Denim,Crepe,Cotton,hairgel,chipsmore,jacobs,bake,tudor,tango,kandos,travel,travelloc,travel lock,easybuybye" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <!-- //for bootstrap working -->
    <link href="web/css/opscn1.css" rel="stylesheet" type="text/css" />
    <link href="web/css/opscn2.css" rel="stylesheet" type="text/css" />
    <%--  <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />--%>
    <style type="text/css">
        #widget
        {
            position: fixed;
            right: 0;
            top: 50%;
            z-index: 99;
            overflow: auto;
        }
    </style>
    <link href="web/css/Popup.css" rel="stylesheet" type="text/css" />
    <!-- For Icon Slider -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        $(function () {
            var $clientcarousel = $('#clients-list');
            var clients = $clientcarousel.children().length;
            var clientwidth = (clients * 220); // 140px width for each client item 
            $clientcarousel.css('width', clientwidth);

            var rotating = true;
            var clientspeed = 0;
            var seeclients = setInterval(rotateClients, clientspeed);

            $(document).on({
                mouseenter: function () {
                    rotating = false; // turn off rotation when hovering
                },
                mouseleave: function () {
                    rotating = true;
                }
            }, '#clients');

            function rotateClients() {
                if (rotating != false) {
                    var $first = $('#clients-list li:first');
                    $first.animate({
                        'margin-left': '-220px'
                    }, 2000, function () {
                        $first.remove().css({
                            'margin-left': '0px'
                        });
                        $('#clients-list li:last').after($first);
                    });
                }
            }
        });
    </script>
    <style>
        /*Logo carousel*/
        
        #clients
        {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
        #clients .clients-wrap
        {
            display: block;
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
        }
        #clients .clients-wrap ul
        {
            display: block;
            list-style: none;
            position: relative;
            margin-left: auto;
            margin-right: auto;
        }
        #clients .clients-wrap ul li
        {
            display: block;
            margin: 0 auto;
            float: left;
            position: relative;
            width: 150px;
            height: 170px; /* line-height:100px;
  text-align: center; */
        }
        #clients .clients-wrap ul li img
        {
            vertical-align: middle;
            max-width: 100%;
            height: 100px;
            -webkit-transition: 0 linear left;
            -moz-transition: 0 linear left;
            transition: 0 linear left;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=65)";
            filter: alpha(opacity=100);
            opacity: 1.0;
        }
        #clients .clients-wrap ul li img:hover
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=65);
            opacity: 0.65;
        }
        
        #clients .clients-wrap div
        {
            /* color: Red;*/
            overflow: hidden;
            width: 100%;
            margin: 0 auto;
            text-align: center;
        }
    </style>
    <!-- For Icon Slider -->
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <%--<a class="button" href="#myPopup">Let me Pop up</a>--%>
    <%-- <button id="myBtn">Open Modal</button>--%>
    <form runat="server" id="form1">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
        EnableViewState="true">
        <ContentTemplate>--%>
    <div id="myPopup" class="Popup">
        <!-- Modal content -->
        <%-- <div class="Popup-content">
                    <div class="Popup-header">
                        <span class="close">
                            <button id="Button1" onserverclick="btnclose_Click" runat="server">
                                &times;</button></span><br />
                        <h2>
                            LET'S REDEEM RM 2 VOUCHER</h2>
                    </div>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <div class="Popup-body">
                                    <p>
                                        <asp:TextBox ID="txtName" runat="server" placeholder='Enter Name Here' class="csstxt-input"></asp:TextBox></p>
                                   
                                    <p>
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder='Enter Email Here' class="csstxt-input"></asp:TextBox></p>
                                   
                                    <p><asp:Label ID="lblmsg" runat="server" ></asp:Label></p>
                                    
                                   <p> <button id="btnregsave" onserverclick="btnRegSave_OnClick" class="Popupbutton" runat="server">Submit</button></p>
                                         <br />
                                </div>
                            </td>
                            <td valign="top">
                                <div class="Popup-sideRight">
                                    Subscribe here to receive our daily new deals and offer up to 70%
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>--%>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script>
        // Get the Popup
        var Popup2 = document.getElementById("myPopup");

        // Get the button that opens the Popup
        var btn = document.getElementById("myBtn");

        // Get the <span> element that closes the Popup
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the Popup 
        btn.onclick = function () {
            Popup2.style.display = "block";
        }

        function pgload() {
            Popup2.style.display = "block";
        }
        // When the user clicks on <span> (x), close the Popup
        span.onclick = function () {
            Popup2.style.display = "none";
        }
        function pgunload() {
            Popup2.style.display = "none";
        }
        // When the user clicks anywhere outside of the Popup, close it
        //    window.onclick = function (event) {
        //        if (event.target == Popup2) {
        //            Popup2.style.display = "none";
        //        }
        //    }
    </script>
    <%--<i class="fa fa-users" aria-hidden="true"></i>--%>
    <!-- header -->
    <div id="widget">
        <a href="RM5.aspx">
            <asp:Image ID="imgRM5" runat="server" ImageUrl="~/web/images/BelowRM5.png" AlternateText="RM5" /></a>
    </div>
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
                <div id="menu-wrap">    
	            <MenuCtrl:MenuControls id="MenuUserControls" runat="server" />
                </div>				
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
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <%-- <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1" class=""></li>
            <li data-target="#myCarousel" data-slide-to="2" class=""></li>
            <li data-target="#myCarousel" data-slide-to="3" class=""></li>
            <li data-target="#myCarousel" data-slide-to="4" class=""></li>
             <li data-target="#myCarousel" data-slide-to="5" class=""></li>
        </ol>--%>
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <div class="container">
                    <div class="carousel-caption">
                        <%-- <h3>
                            The Biggest <span>Sale</span></h3>
                        <p>
                            Special for Allday</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>--%>
                    </div>
                </div>
            </div>
            <div class="item item2">
                <div class="container">
                    <div class="carousel-caption">
                        <%-- <h3>
                            Women's <span>Day Collection</span></h3>--%>
                        <%--<p>
                            New Arrivals On Sale</p>--%>
                    </div>
                </div>
            </div>
            <%--   <div class="item item3">
                <div class="container">
                    <div class="carousel-caption">                   
                         <h3>
                            Kurtis <span>Top</span></h3>
                        <p>
                            Up To 30% Offer</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=22&Param1=0">
                            Shop Now </a>
                    </div>
                </div>
            </div>--%>
            <div class="item item4">
                <div class="container">
                    <div class="carousel-caption">
                        <%--  <h3>
                            Men <span>Shirts</span></h3>
                        <p>
                            New Arrivals On Sale</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=46&Param1=0">
                            Shop Now </a>--%>
                    </div>
                </div>
            </div>
            <div class="item item5">
                <div class="container">
                    <div class="carousel-caption">
                        <%--  <h3>
                            The Biggest <span>Sale</span></h3>
                        <p>
                            Special for today</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>--%>
                    </div>
                </div>
            </div>
            <%-- <div class="item item6">
                <div class="container">
                    <div class="carousel-caption">--%>
            <%--  <h3>
                            The Biggest <span>Sale</span></h3>
                        <p>
                            Special for today</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>--%>
            <%-- </div>
                </div>
            </div>--%>
        </div>
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                    data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                    </span><span class="sr-only">Next</span> </a>
        <!-- The Modal -->
    </div>
    <br />
    <!-- banner-bootom-w3-agileits -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <h3 class="wthree_text_info">
                MyMerdeka <span>Sale</span></h3>
            <div class="col-md-5 bb-grids bb-left-agileits-w3layouts">
                <a href="https://www.easybuybye.com/Products.aspx?Param=54&Param1=6">
                    <div class="bb-left-agileits-w3layouts-inner grid">
                        <figure><%-- class="effect-roxy"--%>
							<img src="web/images/specialweb1.jpg" alt="LeftSide" class="img-responsive" />
							<figcaption>
								<%--<h3><span>T</span>-Shirts </h3>
								<p>Upto 38%</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a>
            </div>
            <div class="col-md-7  bb-middle-agileits-w3layouts">
                <a href="https://www.easybuybye.com/Products.aspx?Param=67&Param1=22">
                    <div class="bb-middle-agileits-w3layouts grid">
                        <figure> <%-- class="effect-roxy"--%>
							<img src="web/images/specialweb2.jpg" alt="TopSide" class="img-responsive" />
							<figcaption>
								<%--<h3><span>S</span>ales </h3>
								<p>Upto 38%</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a><a href="https://www.easybuybye.com/Products.aspx?Param=59&Param1=8">
                    <div class="bb-middle-agileits-w3layouts forth grid">
                        <figure> <%--class="effect-roxy"--%>
							<img src="web/images/specialweb3.jpg" alt="BottomImage" class="img-responsive">
							<figcaption>
								<%--<h3><span>S</span>ales </h3>
								<p>Upto 28%</p>--%>
							</figcaption>		
						</figure>
                    </div>
                </a>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <!--/grids-->
    <!-- //banner -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <h3 class="wthree_text_info">
               Product <span>Categories</span></h3>
            <div class="col-md-12">
               <div id="clients">
        <div class="clients-wrap">
            <ul id="clients-list" class="clearfix">
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/AllProducts.aspx?Basic=0&Sub=10">
                            <img src="images\icons\1.png" alt="Women" /></a> <span>Women&nbsp;Fashion</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/AllProducts.aspx?Basic=0&Sub=8">
                            <img src="images\icons\2.png" alt="Men" />
                        </a><span>Men&nbsp;Fashion</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/AllProducts.aspx?Basic=16&Sub=0">
                            <img src="images\icons\3.png" alt="Kids&Toys" /></a><span>Kids&nbsp;&&nbsp;Toys</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=54&Param1=5">
                            <img src="images\icons\4.png" alt="Cosmetic" /></a><span>Health&nbsp;&&nbsp;Beauty </span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/AllProducts.aspx?Basic=5&Sub=0">
                            <img src="images\icons\5.png" alt="Sports" /></a><span>Sport&nbsp;&&nbsp;Outdoor </span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=85&Param1=34">
                            <img src="images\icons\6.png" alt="Grocery" /></a> <span>Grocery</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=18&Param1=15">
                            <img src="images\icons\7.png" alt="Laptop" /></a><span>Electronics</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=67&Param1=22">
                            <img src="images\icons\8.png" alt="Paste" /></a> <span>Asian&nbsp;Taste </span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=31&Param1=11">
                            <img src="images\icons\9.png" alt="Biscut" /></a> <span>Wholesale</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/Products.aspx?Param=97&Param1=13">
                            <img src="images\icons\10.png" alt="Bag" /></a> <span>&nbsp;Travel&nbsp;</span>
                    </div>
                </li>
                <li>
                    <div>
                        <a href="https://www.easybuybye.com/AllProducts.aspx?Basic=4&Sub=0">
                            <img src="images\icons\11.png" alt="Home&Living" /></a><span>Home&nbsp;&&nbsp;Living </span>
                    </div>
                </li>
                <li><div><a href="https://www.easybuybye.com/Products.aspx?Param=55&Param1=7">
                    <img src="images\icons\12.png" alt="RM5" /></a> <span>Below&nbsp;RM5 </span>
        </div>
        </li> </ul>
    </div>
    <!-- @end .clients-wrap -->
    </div>
            </div>
        </div>
    </div>
   
    <%--<div class="banner_bottom_agile_info">
        <div class="container">
            <div class="banner_bottom_agile_info_inner_w3ls">
                <a href="https://www.easybuybye.com/Products.aspx?Param=35&Param1=0">
                    <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                        <figure class="effect-roxy">
							<img src="web/images/4.jpg" alt="WomenDress" class="img-responsive" />
							<figcaption>
								<h3><span>N</span>ew</h3>
								<p>Arrivals</p>
							</figcaption>			
						</figure>
                    </div>
                </a><a href="https://www.easybuybye.com/Products.aspx?Param=23&Param1=0">
                    <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                        <figure class="effect-roxy">
							<img src="web/images/5.jpg" alt="MenDress" class="img-responsive" />
							<figcaption>
								<h3><span>N</span>ew</h3>
								<p>Arrivals</p>
							</figcaption>			
						</figure>
                    </div>
                </a>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>--%>
    <!-- /we-offer -->
    <!-- /new_arrivals -->
    <div class="new_arrivals_agile_w3ls_info">
        <div class="container">
            <h3 class="wthree_text_info">
                Feature <span>Products</span></h3>
            <div id="horizontalTab">
                <ul class="resp-tabs-list">
                    <%-- <li>Sarees</li>--%>
                    <li>Feature</li>
                    <li>Kurtis</li>
                    <li>Hanna Rauda</li>
                    <li>Molecule</li>
                    <%--<li>Sarees</li>
                    <li>Shirts</li>--%>
                </ul>
                <div class="resp-tabs-container">
                    <!--/tab_one-->
                    <div class="tab1">
                        <% int aa2 = 0, aa1 = 0, s = 0, t = 0;
                           s = dtRecentitems.Rows.Count;
                           for (aa2 = 0; aa2 < dtRecentitems.Rows.Count; aa2++)
                           {
                               s = s - aa1;
                               if (s > 4)
                               { t = 4; }
                               else
                               { t = s; }
                               for (int f = 0; f < t; f++)
                               {
                                   System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                   System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
                                   string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems.Rows[aa2][3].ToString().Trim(); 
                        %>
                        <div class="col-md-3">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="divthumb">
                                    <div class="flip-box">
                                        <div class="flip-box-inner">
                                            <div class="flip-box-front">
                                                <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>">
                                                    <img src="<%= path%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                                        class="imgthumb" /></a>
                                            </div>
                                            <div class="flip-box-back">
                                                <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>">
                                                    <img src="<%= path%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                                        class="imgthumb" /></a>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems.Rows[aa2][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>
                                </div>
                                <div class="item-info-product ">
                                    <div style="height: 40px">
                                        <h4>
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>">
                                                <%= textInfo.ToTitleCase(dtRecentitems.Rows[aa2][8].ToString().ToLower())%></a></h4>
                                    </div>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems.Rows[aa2][5].ToString()%></span> <del>RM
                                            <%= dtRecentitems.Rows[aa2][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--  <br>--%>
                        <% 
                                   aa2 = aa2 + 1;
                               }

                               if (s > 4)
                               { aa2 = aa2 - 1; aa1 = 4; }
                               else
                               { aa2 = aa2 + 0; aa1 = 0; }

                           } %>
                    </div>
                    <!--//tab_one-->
                    <!--/tab_two-->
                    <div class="tab2">
                        <% int aa4 = 0, aa3 = 0, s1 = 0, t1 = 0;
                           s1 = dtRecentitems1.Rows.Count;
                           for (aa4 = 0; aa4 < dtRecentitems1.Rows.Count; aa4++)
                           {
                               s1 = s1 - aa3;
                               if (s1 > 4)
                               { t1 = 4; }
                               else
                               { t1 = s1; }
                               for (int f1 = 0; f1 < t1; f1++)
                               {
                                   string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems1.Rows[aa4][3].ToString().Trim(); 
                        %>
                        <div class="col-md-3 product-men">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="men-thumb-item">
                                    <img src="<%= path%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" class="pro-image-front" />
                                    <img src="<%= path%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>"
                                                class="link-product-add-cart">Quick View</a>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems1.Rows[aa4][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>
                                </div>
                                <div class="item-info-product ">
                                    <div style="height: 40px">
                                        <h4>
                                            <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>"
                                                title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>">
                                                <%= dtRecentitems1.Rows[aa4][8].ToString()%></a></h4>
                                    </div>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems1.Rows[aa4][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems1.Rows[aa4][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% 
                                   aa4 = aa4 + 1;
                               }

                               if (s1 > 4)
                               { aa4 = aa4 - 1; aa3 = 4; }
                               else
                               { aa4 = aa4 + 0; aa3 = 0; }
                           } %>
                    </div>
                    <!--//tab_two-->
                    <!--/tab_three-->
                    <div class="tab3">
                        <% int aa6 = 0, aa5 = 0, s2 = 0, t2 = 0;
                           s2 = dtRecentitems2.Rows.Count;
                           for (aa6 = 0; aa6 < dtRecentitems2.Rows.Count; aa6++)
                           {
                               s2 = s2 - aa5;
                               if (s2 > 4)
                               { t2 = 4; }
                               else
                               { t2 = s2; }
                               for (int f2 = 0; f2 < t2; f2++)
                               {
                                   string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems2.Rows[aa6][3].ToString().Trim(); 
                        %>
                        <div class="col-md-3 product-men">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="men-thumb-item">
                                    <img src="<%= path%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" class="pro-image-front" />
                                    <img src="<%= path%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>"
                                                class="link-product-add-cart">Quick View</a>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems2.Rows[aa6][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>
                                </div>
                                <div class="item-info-product ">
                                    <div style="height: 40px">
                                        <h4>
                                            <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>"
                                                title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>">
                                                <%= dtRecentitems2.Rows[aa6][8].ToString()%></a></h4>
                                    </div>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems2.Rows[aa6][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems2.Rows[aa6][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% 
                                   aa6 = aa6 + 1;
                               }

                               if (s2 > 4)
                               { aa6 = aa6 - 1; aa5 = 4; }
                               else
                               { aa6 = aa6 + 0; aa5 = 0; }
                           } %>
                    </div>
                    <!--//tab_three-->
                    <!--/tab_four-->
                    <div class="tab4">
                        <% int aa8 = 0, aa7 = 0, s3 = 0, t3 = 0;
                           s3 = dtRecentitems3.Rows.Count;
                           for (aa8 = 0; aa8 < dtRecentitems3.Rows.Count; aa8++)
                           {
                               s3 = s3 - aa7;
                               if (s3 > 4)
                               { t3 = 4; }
                               else
                               { t3 = s3; }
                               for (int f3 = 0; f3 < t3; f3++)
                               {
                                   string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems3.Rows[aa8][3].ToString().Trim(); 
                        %>
                        <div class="col-md-3 product-men">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="men-thumb-item">
                                    <img src="<%= path%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" class="pro-image-front" />
                                    <img src="<%= path%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>"
                                                class="link-product-add-cart">Quick View</a>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems3.Rows[aa8][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>
                                </div>
                                <div class="item-info-product ">
                                    <div style="height: 40px">
                                        <h4>
                                            <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>"
                                                title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>">
                                                <%= dtRecentitems3.Rows[aa8][8].ToString()%></a></h4>
                                    </div>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems3.Rows[aa8][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems3.Rows[aa8][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% 
                                   aa8 = aa8 + 1;
                               }

                               if (s3 > 4)
                               { aa8 = aa8 - 1; aa7 = 4; }
                               else
                               { aa8 = aa8 + 0; aa7 = 0; }
                           } %>
                    </div>
                    <!--//tab_four-->
                </div>
            </div>
        </div>
    </div>
    <!-- //new_arrivals -->
    <!-- schedule-bottom -->
    <div class="schedule-bottom">
        <div class="col-md-12 agileinfo_schedule_bottom_left">
            <a href="SellatEBB.aspx">
                <img src="web/images/seller update.jpg" alt="Middle" class="img-responsive" /></a>
        </div>
        <%--  <div class="col-md-6 agileits_schedule_bottom_right">
            <div class="w3ls_schedule_bottom_right_grid">
                <h3>
                    Save up to <span>50%</span> on this Month</h3>
                <br>
                <h3>
                    Grab a Free Gift On Every Purchase</h3>
                <br>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-users" aria-hidden="true"></i>
                    <h4>
                        Daily Viewers</h4>
                    <h5 class="counter" style="float: left; margin-left: 25px;">
                        2000</h5>
                    <h5 style="margin-right: 25px;">
                        +</h5>
                </div>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-suitcase" aria-hidden="true"></i>
                    <h4>
                        Products</h4>
                    <h5 class="counter" style="float: left; margin-left: 25px;">
                        3000</h5>
                    <h5 style="margin-right: 25px;">
                        +</h5>
                </div>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-user" aria-hidden="true"></i>
                    <h4>
                        Sellers</h4>
                    <h5 class="counter" style="float: left; margin-left: 30px;">
                        100</h5>
                    <h5 style="margin-right: 30px;">
                        +</h5>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>--%>
        <div class="clearfix">
        </div>
    </div>
    <!-- //schedule-bottom -->
    <!-- //footer -->
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
    <%-- <script src="web/js/minicart.min.js"></script>
    <script>
        // Mini Cart
        paypal.minicart.render({
            action: '#'
        });

        if (~window.location.search.indexOf('reset=true')) {
            paypal.minicart.reset();
        }
    </script>--%>
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
    <script type="text/jscript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    <!-- here stars scrolling icon -->
    <script type="text/jscript">
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
    <%--<script src="AC/js/jquery.min.js" type="text/javascript"></script>--%>
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
