<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnsPolicy.aspx.cs" Inherits="ReturnsPolicy" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
    <title>EasyBuyBye | Return & Refund Policy </title>
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
        .ul
        {
            padding-left: 200px;
            color: #545454;
            line-height: 2em;
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
                Return, Refund & <span>Exchange Policy </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Return & Refund Policy</li>
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
                    Return, Refund & Exchange Policy <span> </span>
                </h5>
                <strong>How to Return Purchased Items</strong>
                <p>
                    Customers are advised to observe the following steps when returning purchased items:
                </p>
                <p>
                    1. Please check the return validity of the purchased item (please refer to our Returns Policy below for more information).<br />
                    2. Fill in the returns form (found in your “My Orders” page).<br />
                    3. Print or produce a copy of the shipping label.<br />
                    4. Pack the product and attach the shipping label to the package.<br />
                    5. Drop the package off at one of our courier partners nearest to you (contact us if you require assistance with this).<br />
                    6. Once we receive your package, we will process your request and update you of the status via email or phone.
                </p>

                <strong>Returns Policy</strong>               
                <p>
                    1. Return of the purchased item should be done within 3 days of receiving the item. After this period, all sales are final.<br />
                    2. Exchange of items do not apply to items sold by overseas suppliers.<br />
                    3. All sales are final for items sold by overseas suppliers.<br />
                    4. For drop off at Collection outlets, package size accepted must not exceed 35 cm (L) x 35 cm (W) x 35 cm (H) and must weigh less than 10 Kgs.<br />
                   
                </p>
                 <strong>Requirements for a Valid Return</strong>               
                <p>
                    1. Proof of purchase (please provide either the order number or invoice)<br />
                    2. Bank details in Shipping Label if the original payment is made via payment gateway.<br />
                    3. Include printed Shipping Label and EasyBuyBye Tax Invoice in each return package box.<br />
                    4. Valid reason for the product return should be met.<br />
                   
                </p>
                                <h4>
                    <strong>Valid Reasons for Returns, Refunds and Exchanges</strong>
                </h4>
                <p>
                    1. The item received by the buyer was not what was ordered.<br />
                    2. The product received is damaged or defective.<br />
                    3. Product quality or contents does not match the seller’s product description.<br />
                    4. The product does not meet the customer's expectations as described in the product’s description. <br />
                    5. The product could not be fixed or assembled (not applicable for fashion products from overseas sellers). <br />
                    6. The customer has a change of mind (not applicable for products from overseas sellers).
                    <br /> <br />
                    <b>Note :</b><br />
                    
                       * Returns are not applicable for all under garments sold due to hygiene and quality
                            reasons.<br />
                       * If you received damaged goods, please contact EasyBuyBye within 48 hours to expedite
                            the claim process.
                </p>
                <h4>
                    <strong>Refunds</strong>
                </h4>
                <p>
                   If you are eligible for a refund, we offer several refund options based on your chosen payment method at the time you made your purchase.
                </p>               
                <p>
                   We will update you via email once your refund has been initiated. You will be able to see the credited amount on your statement as per the lead time listed in the table below for each of the refund methods.
                </p>
                <p>
                   If the refund does not arrive after the next two months’ statements, please contact your issuing bank or EasyBuyBye directly for support.
                </p>
               <br />
                <table width="100%" border="1" cellpadding="3" class="Rightborders">
                    <tr align="center" style="padding: 2px 2px 2px 2px;">
                        <td width="25%" style="font-weight: bold;">
                            Payment Method (during purchase)
                        </td>
                        <td width="25%" style="font-weight: bold;">
                            Refund Method
                        </td>
                        <td width="25%" style="font-weight: bold;">
                            EasyBuyBye processing time (after return or cancellation has been checked)
                        </td>
                        <td width="25%" style="font-weight: bold;">
                            Bank processing Time (after refund has been processed by EasyBuyBye)
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            Credit card/Debit card
                        </td>
                        <td>
                            Credit card
                        </td>
                        <td>
                            1 - 3 working days
                        </td>
                        <td>
                            5 - 15 working days (depending on your bank)
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            Bank transfer
                        </td>
                        <td>
                            Ipay88 reversal refund
                        </td>
                        <td>
                            1 - 3 working days
                        </td>
                        <td>
                            5 – 14 working days (depending on your bank)
                        </td>
                    </tr>
                </table>
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
