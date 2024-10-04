<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyerOrder.aspx.cs" Inherits="BuyerOrder" %>

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
    <title>EasyBuyBye | Order </title>
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
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/checkout.css" rel="stylesheet" type="text/css" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
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
                Order<span>s </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Orders</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
      <div class="banner-bootom-w3-agileits">
        <div class="container">
     <div class="sort-grid">
                <div class="sorting">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>  
                               <h6> Sort By</h6>
                            <asp:DropDownList ID="cboSortby" runat="server" Height="25px" class="frm-field sect"
                                Style="height: 35px" AutoPostBack="true" OnSelectedIndexChanged="cboSortby_OnSelectedIndexChanged">                               
                                <asp:ListItem Text="Last 5 Order" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Last 10 Order" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Last 25 Order" Value="25"></asp:ListItem>
                                <asp:ListItem Text="All Order" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clearfix">
                    </div>
                </div>              
                <div class="clearfix">
                </div>
            </div>
             </div>
            </div>
    <!-- banner-bootom-w3-agileits -->
    <section class="checkout py-lg-4 py-md-3 py-sm-3 py-3" style="margin-top:-100px">
            <div class="container py-lg-5 py-md-4 py-sm-4 py-3">
               <div class="shop_inner_inf">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>  
                  <div class="privacy about">
                  
                    <%-- <h3>Wish<span>list</span></h3>--%>
                     <div class="checkout-right">
                        <h4><asp:Label ID="lblStatus" runat="server" ></asp:Label></h4>
                        <%                           
                            if (dtGridVal.Rows.Count != 0)
                            {  %>
                        <asp:Repeater ID="rpCheckout"  runat="server" OnItemCommand="rpCheckout_ItemCommand" OnItemDataBound="rpCheckout_ItemDataBound">
         <HeaderTemplate>
                                 <table class="timetable_sub">                                  
                           <thead>
                              <tr>
                                 <th>OrderNo</th>
                                 <th>Product</th>                                 
                                 <th>Product Name</th>
                                 <th>Qty</th>
                                 <th>Price</th>
                                  <th>Status</th>
                                 <%--<th>Shipped</th>--%>
                               <%--  <th>Delivered</th>--%>
                                 <th>Cancel</th>
                              </tr>
                           </thead>
                            </HeaderTemplate>
                             <ItemTemplate>
                           <tbody>
                              <tr class="rem1">
                                 <td class="invert"><%# DataBinder.Eval(Container.DataItem, "OrderNo")%></td>
                                 <td class="invert-image"><a href="Preview.aspx?Param=<%# DataBinder.Eval(Container.DataItem, "ProductID")%>"><img src="<%# DataBinder.Eval(Container.DataItem, "ckimg")%>" alt=" " class="img-responsive" style="height:50px;width:50px"></a></td>
                               
                                 <td class="invert"><%# DataBinder.Eval(Container.DataItem, "Brand")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Model")%></td>
                                   <td class="invert">                                    
                                       <div class="quantity-select" style="text-align:center"> 
                                        <asp:Label ID="lblQnty" runat="server" Text='<%# Eval("Qnty")%>' ></asp:Label> 
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("DiscountPrice")%>' Visible="false" ></asp:Label>                                  
                                            <asp:HiddenField ID="hdAddcartID" runat="server" Value='<%# Eval("AddcartID")%>'/>
                                            <asp:HiddenField ID="hdOrderNo" runat="server" Value='<%# Eval("OrderNo")%>'/> 
                                             <asp:HiddenField ID="hdRunningNo" runat="server" Value='<%# Eval("RunningNo")%>'/>                                                              
                                       </div>                                    
                                 </td> 
                                 <td class="invert">RM <asp:Label ID="lbltotal" runat="server" ></asp:Label></td>
                                 <td class="invert"><asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Shipstatus")%>'></asp:Label></td>
                                <%-- <td class="invert"><asp:Label ID="lblShipped" runat="server" Text='<%# Eval("Shipping")%>'></asp:Label></td>
                                 <td class="invert"><asp:Label ID="lblDelivered" runat="server" Text='<%# Eval("Delivered")%>'></asp:Label></td>--%>
                                 <td class="invert">
                                    <div>
                                       <div><asp:Button ID="btnCancel" runat="server" CommandName="CancelReturn" CssClass="selectbutton" BorderStyle="None"></asp:Button></div>
                                    </div>
                                 </td>
                              </tr>                             
                           </tbody>
                            </ItemTemplate>
                        <FooterTemplate>
             </table>
          </FooterTemplate>         
                          </asp:Repeater>
                          <% }
                            else
                            {%>   <h4>No Order Records Found</h4><%} %>
                     </div>                    
                  </div>
                   </ContentTemplate>
                    </asp:UpdatePanel>
               </div>
               <!-- //top products -->
            </div>
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
    </form>
</body>
</html>
