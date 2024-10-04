<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShippingAddress.aspx.cs"
    Inherits="ShippingAddress" %>

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
    <title>EasyBuyBye | Checkout </title>
    <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); }    
    </script>
    <script type="text/javascript">
        function checkDec(el) {
            var ex = /^[0-9]+\.?[0-9]*$/;
            if (ex.test(el.value) == false) {
                el.value = el.value.substring(0, el.value.length - 1);
            }
        }
        function checkchar(el) {
            var ex = /^[a-zA-Z0-9-. ]*$/;
            if (ex.test(el.value) == false) {
                el.value = el.value.substring(0, el.value.length - 1);
            }
        }        
    </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <%--<link rel="stylesheet" href="web/css/flexslider.css" type="text/css" media="screen" />--%>
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/checkout.css" rel="stylesheet" type="text/css" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />    
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
                Order <span>Summary </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Order Summary</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <!-- banner-bootom-w3-agileits -->
    <section class="checkout py-lg-4 py-md-3 py-sm-3 py-3">
            <div class="container py-lg-5 py-md-4 py-sm-4 py-3">
               <div class="shop_inner_inf">
                  <div class="privacy about">
                     <div class="checkout-left">
                        <div class="col-md-4 checkout-left-basket">
                           <h4>Billing Address</h4>                     
                         <div style="padding:5px 5px 5px 5px">              
                               <p>    
                              <b ><% =Name%></b><br />
                             <% =Address1%><br />
                              <% =Address2%><br />
                              <% =PostCode%>&nbsp;
                              <% =City%>&nbsp;
                               <% =State%><br />
                               <% =Country%><br />   <br />
                               Mobile :
                               <% =Mobile%>
                                </p>                       
                         </div>
                        </div>         
                              <section class="creditly-wrapper wrapper">
                                 <div class="information-wrapper">
                                   <div class="col-md-4 checkout-left-basket" >
                                  
                                  <h4>Promotion</h4> 
                                   <div style="padding:5px 5px 5px 5px">
                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true" EnableViewState="true">
                                            <ContentTemplate>
                                    <div class="first-row form-group">
                                       <div class="controls">
                                          <label class="control-label"> If you have the PROMO CODE: </label> <br /><br />
                                          <asp:HiddenField runat="server" ID="hdPromotionID" />
                                          <asp:HiddenField runat="server" ID="hdAgentID" />
                                         <asp:TextBox ID="txtPCode" runat="server" BorderStyle="Groove" class="billing-address-name form-control" ></asp:TextBox>
                                       </div>
                                       <div class="card_number_grids">                                         
                                          <div class="card_number_grid_right">
                                             <div class="controls">
                                                 <asp:Label class="labelstyle" ID="lblStatus" runat="server" ForeColor="Red" Font-Bold="true" />
                                             </div>
                                          </div>
                                          <div class="clear"> </div>
                                       </div>                                    
                                     
                                    </div>
                                    <asp:Button CssClass="selectbutton" runat="server" id="btnBye" Text="Apply Now" OnClick="btnSubmit_OnClick" BorderStyle="None" style="width:200px"  /> 
                                    </ContentTemplate>
                                        </asp:UpdatePanel> 
                                        </div>            
                                 </div>
                                
                                 <div class="col-md-4 checkout-left-basket">
                           <h4>Order Summary</h4>    
                            <div style="padding:5px 5px 5px 5px">    
                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true" EnableViewState="true">
                                            <ContentTemplate>
                        <b> Subtotal :</b>
                                    <asp:Label class="labelstyle" ID="lblSubTotal" runat="server" ForeColor="Red" Font-Bold="true" style="float:right;"/><br />
                                    <br />
                                     <b>Shipping Fee :</b>
                                    <asp:Label class="labelstyle" ID="lblShippingCost" runat="server" ForeColor="Red"
                                        Font-Bold="true" style="float:right;"/><br />
                                    <br />
                                    <b>Total :</b>
                                    <asp:Label class="labelstyle" ID="lblTotal" runat="server" ForeColor="Red"
                                        Font-Bold="true" style="float:right;"/><br />
                                    <br />
                                    <b><asp:Label class="labelstyle" ID="lblPRA" runat="server" ForeColor="Black" Font-Bold="true" /></b>
                                    <asp:Label class="labelstyle" ID="lblpromotion" runat="server" ForeColor="Red" Font-Bold="true" style="float:right;"/>
                                   <hr style="border: 0; height: 1px; background-image: linear-gradient(to right, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.75), rgba(0, 0, 0, 0));" />
                                    <b><asp:Label class="labelstyle" ID="lblGtotal" runat="server" ForeColor="Black" Font-Bold="true" /></b>
                                    <asp:Label class="labelstyle" ID="lblGrandTotal" runat="server" ForeColor="Red" Font-Bold="true" style="float:right;"/> <br /><br />     
                                     </ContentTemplate>
                                        </asp:UpdatePanel>
                         <asp:Button CssClass="buybutton" runat="server" id="btnBuy" Text="Buy Now" OnClick="btnBuy_OnClick" BorderStyle="None" /> 
                        </div>
                                 </div>
                                  
                                 </div>
                              </section>                                  
                        <div class="clearfix"> </div>
                        <div class="clearfix"></div>
                     </div>
                  </div>
               </div>
               <!-- //top products -->
              <div id="divCOD" runat="server">COD Available only in ShahAlam, Subang : &nbsp;
               <asp:Button CssClass="buybuttonGreen" runat="server" id="btnCOD" Text="Cash On Delivery" OnClick="btnCOD_OnClick" BorderStyle="None" style="float:none" /> 
            </div> </div>

             
      </section>
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
    <!--quantity-->
    <%--    <script>
        function changeQuantity(type) {
            var currentQty = $("#txtval").val();
            if (type == 'plus') {
                $("#txtval").val(parseInt(currentQty, 10) + 1);
            }
            else if (currentQty < 2) {
                $("#txtval").val('1');
            }
            else {
                $("#txtval").val(parseInt(currentQty, 10) - 1);
            }
        }
    </script>--%>
    <%--  <script>
        $('.value-plus').on('click', function () {
            var divUpd = $(this).parent().find('.value'),
         		newVal = parseInt(divUpd.text(), 10) + 1;
            divUpd.text(newVal);
        });

        $('.value-minus').on('click', function () {
            var divUpd = $(this).parent().find('.value'),
         		newVal = parseInt(divUpd.text(), 10) - 1;
            if (newVal >= 1) divUpd.text(newVal);
        });
    </script>--%>
    <!--quantity-->
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
