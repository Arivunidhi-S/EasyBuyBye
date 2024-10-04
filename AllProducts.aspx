<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllProducts.aspx.cs" Inherits="AllProducts" %>

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

    <title>EasyBuyBye | Products </title>
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
        <% if (Loadpage == 0)
       { %>
         <div class="page-head_agile_info_w3l">
        <div class="container">
            <h3>
               
                <span>No Product Found </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a></li>    
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
            <div class="sort-grid">
                <div class=""  style="text-align:center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/NoFound.png" />  <span style="font-size:25px;font-weight:bold">Sorry! No Product Found </span>
                    
                    <div class="clearfix">
                    </div>
                </div>
             
                <div class="clearfix">
                </div>
            </div>
           
        </div>
    </div>

    <%} else {  %>
    <!-- /banner_bottom_agile_info -->
    <div class="page-head_agile_info_w3l">
        <div class="container">
            <h3>
            <%= dtRecentitems.Rows[0][12].ToString().Trim()%>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <%  if (@Basic != "0")
                            { %>
                        <li><%= dtRecentitems.Rows[0][12].ToString().Trim()%></li>
                        <%} else { %>
                        <li><a href='AllProducts.aspx?Basic=<%= dtRecentitems.Rows[0][15].ToString()%>&Sub=0'>
                            <%= dtRecentitems.Rows[0][14].ToString()%></a><i>|</i></li>
                               <li><%= dtRecentitems.Rows[0][12].ToString().Trim()%></li>
                         <%} %>
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
            <div class="sort-grid">
                <div class="sorting">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>  
                               <h6> Sort By</h6>
                            <asp:DropDownList ID="cboSortby" runat="server" Height="25px" class="frm-field sect"
                                Style="height: 35px" AutoPostBack="true" OnSelectedIndexChanged="cboSortby_SelectedIndexChanged">                               
                                <asp:ListItem Text="Order By Latest" Value="productid desc"></asp:ListItem>
                                <asp:ListItem Text="Order By Category" Value="categoryid asc"></asp:ListItem>
                                <asp:ListItem Text="Price(High - Low)" Value="DiscountPrice desc"></asp:ListItem>
                                <asp:ListItem Text="Price(Low - High)" Value="DiscountPrice asc"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clearfix">
                    </div>
                </div>              
                <div class="clearfix">
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                EnableViewState="true">
                <ContentTemplate>
                    <div class="single-pro">
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
                                    <%--<img src="<%= path%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                        class="pro-image-back" />
                                     <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                         <%
                                   if (dtRecentitems.Rows[aa2][9].ToString()!="0")
                                   { %>
                                    <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Buy Now</a>
                                    <% }else{ %>
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" class="link-product-add-cart1">
                                                Sold Out</a>
                                            <% } %>
                                        </div>
                                    </div>--%>
                                   <%                                        
                                   if (!(string.IsNullOrEmpty(dtRecentitems.Rows[aa2][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>
                                      <%                                        
                                   if (dtRecentitems.Rows[aa2][9].ToString() == "0")
                                   { %>
                                    <span class="product-SoldOut-top">Sold Out</span>
                                    <% } %>
                                </div>
                                <div class="item-info-product ">
                                 <div style="height:40px">
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
                            <br>
                        </div>
                        <% 
                           aa2 = aa2 + 1;
                               }

                               if (s > 4)
                               { aa2 = aa2 - 1; aa1 = 4; }
                               else
                               { aa2 = aa2 + 0; aa1 = 0; }
                           }  %>
                    </div>
                </ContentTemplate>             
            </asp:UpdatePanel>
        </div>
    </div>
     <%}%>
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
