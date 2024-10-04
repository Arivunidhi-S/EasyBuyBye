<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addcart2.aspx.cs" Inherits="Addcart2" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
<style>
g{text-decoration:underline;
  color:Blue}
</style>
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
<img height="1" width="1"
src="https://www.facebook.com/tr?id=517994975548842&ev=PageView
&noscript=1"/>
</noscript>
<!-- End Facebook Pixel Code -->
    <title>EasyBuyBye | Express Checkout </title>
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
        function FuncAlrt(msg) {
            alert(msg);
            location.href = window.location;
        } 
    </script>
    <style type="text/css">
        .alert {
  padding: 15px;
  margin-bottom: 20px;
  border: 1px solid transparent;
  border-radius: 4px;
}
.alert-danger {
  color: #a94442;
  background-color: #f2dede;
  border-color: #ebccd1;
}
}
    </style>
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
    <link rel="stylesheet" type="text/css" href="web/zoom/css/styleZoom.css" />
     <meta name="google-signin-client_id" content="483364606606-v16vfs8o70cevq4u2ho28r29gogbdt7v.apps.googleusercontent.com" />
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
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
               Express <span>Checkout </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Express Checkout</li>
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
                    <%-- <h3>Check<span>out</span></h3>--%>
                     <div class="checkout-right">
                        <h4>Your shopping cart contains: <span><%= dtGridVal.Rows.Count %> Products</span></h4>
                        <% if (dtGridVal.Rows.Count != 0)
                           { %>
                        <asp:Repeater ID="rpCheckout"  runat="server">
          <HeaderTemplate>
                                 <table class="timetable_sub">
                           <thead>
                              <tr>
                                 <th>SNo.</th>
                                 <th>Product</th>                                 
                                 <th style="width:30%">Product Name</th>
                                 <th>Quantity</th>
                                 <th>Price</th>
                                 <th>Remove</th>
                              </tr>
                           </thead>
                            </HeaderTemplate>
                             <ItemTemplate>
                           <tbody>
                              <tr class="rem1">
                                 <td class="invert"><%# Container.ItemIndex + 1 %></td>
                                 <td class="invert-image"><a href="Preview.aspx?Param=<%# DataBinder.Eval(Container.DataItem, "ProductID")%>"><img src="<%# DataBinder.Eval(Container.DataItem, "ckimg")%>" alt=" " class="img-responsive" style="height:50px;width:50px"></a></td>
                                 <td class="invert"><%# DataBinder.Eval(Container.DataItem, "Brand")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Model")%></td>
                                 <td class="invert">
                                    <div >
                                       <div class="quantity-select" style="text-align:center">
                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true" EnableViewState="true">
                                            <ContentTemplate>
                                            <asp:HiddenField ID="hdAddcartID" runat="server" Value='<%# Eval("AddcartID")%>'/>
                                            <asp:HiddenField ID="hdProductID" runat="server" Value='<%# Eval("ProductID")%>'/>
                                          <div><asp:LinkButton ID="lbminus"  style="float:left;" runat="server"  class="entry value-minus" OnClick="btnminus_Onclick" ></asp:LinkButton></div>
                                          <div><asp:TextBox style="float:left;"  ForeColor="Black"  ID="txtval" runat="server" class="entry value" onkeyup="checkDec(this);" Text='<%# Eval("Qnty")%>'></asp:TextBox></div>
                                          <div ><asp:LinkButton style="float:left;" ID="lbplus" OnClick="btnplus_Onclick" runat="server" class="entry value-plus active"></asp:LinkButton></div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                       </div>
                                    </div>
                                 </td>                                 
                                 <td class="invert">RM <%# DataBinder.Eval(Container.DataItem, "totprice")%></td>
                                 <td class="invert">
                                    <div>
                                       <div><asp:ImageButton runat="server" ID="Imgbtn_Delete" ImageUrl="~/web/images/close_1.jpg" OnClick="btnDelete_Onclick" /> </div>
                                    </div>
                                 </td>
                              </tr>                             
                           </tbody>
                            </ItemTemplate>
                        <FooterTemplate>
             </table>
          </FooterTemplate>
                          </asp:Repeater>
                          <%} %>
                     </div>
                     <div class="checkout-left">    
                        <div class="col-md-8 checkout-left-basket" >
                           <h4 style="background-color: Green;">Express Checkout</h4>
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" ChildrenAsTriggers="true" EnableViewState="true">
                                            <ContentTemplate>
                              <section class="creditly-wrapper wrapper">
                                 <div class="information-wrapper">
                                 <h5 style="padding:0px 0px 20px 15px;font-size:larger;font-weight:bold;color:#ff6000">To whom should we deliver to?</h5>
                                 
                                  <div class="col-md-12">
                                    <div class="first-row form-group">
                                       <div class="controls">
                                          <label class="control-label">Full name: </label>
                                          <asp:TextBox ID="txtName" runat="server" class="billing-address-name form-control" onkeyup="checkchar(this);"></asp:TextBox>
                                       </div>
                                       <div class="card_number_grids">
                                          <div class="card_number_grid_left">
                                             <div class="controls">
                                                <label class="control-label">Mobile number:</label>
                                               <asp:TextBox ID="txtMobile" runat="server" onkeyup="checkDec(this);" class="billing-address-name form-control" ></asp:TextBox>
                                             </div>
                                          </div>
                                          <div class="card_number_grid_right">
                                             <div class="controls">
                                                <label class="control-label">Email: </label>
                                              <asp:TextBox ID="txtEmail" runat="server" class="billing-address-name form-control" ></asp:TextBox>
                                             </div>
                                          </div>
                                          <div class="clear"> </div>
                                       </div>
                                       <h5 style="padding:0px 0px 20px 0px;font-size:larger;font-weight:bold; color:#ff6000">Where should we send it?</h5>
                                       <div class="controls">
                                          <label class="control-label">Address Line 1: </label>
                                         <asp:TextBox ID="txtAddress1" runat="server" class="billing-address-name form-control"></asp:TextBox>
                                       </div>
                                       <div class="controls">
                                          <label class="control-label">Address Line 2: </label>
                                         <asp:TextBox ID="txtAddress2" runat="server" class="billing-address-name form-control"></asp:TextBox>
                                       </div>
                                    </div>
                                     </div>
                                  <div class="col-md-12">
                                    <div class="first-row form-group">
                                       <div class="controls">
                                          <label class="control-label">PostCode: </label>
                                         <asp:TextBox ID="txtPostCode" runat="server" onkeyup="checkDec(this);" class="billing-address-name form-control" ></asp:TextBox>
                                       </div>
                                       <div class="card_number_grids">
                                          <div class="card_number_grid_left">
                                             <div class="controls">
                                                <label class="control-label">City:</label>
                                                <asp:TextBox ID="txtCity" runat="server" class="billing-address-name form-control"></asp:TextBox>
                                             </div>
                                          </div>
                                         <%-- <div class="card_number_grid_right">
                                             <div class="controls">
                                                <label class="control-label">Landmark: </label>
                                                <input class="form-control" type="text" placeholder="Landmark">
                                             </div>
                                          </div>--%>
                                          <div class="clear"> </div>
                                       </div>                                    
                                       <div class="controls">
                                          <label class="control-label">State: </label>
                                          <asp:DropDownList ID="txtState" runat="server" class="form-control option-w3ls">   
                                                                <asp:ListItem Text="Select State" Value="0" style="color:#f00;font-style: italic;"/>                                      
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
                                          <div class="clear"> </div>    
                                             </div>        
                                                          
                                          <div class="controls">
                                          <label class="control-label">Country: </label>
                                           <asp:DropDownList ID="txtCountry" runat="server" class="form-control option-w3ls">                                         
                                                                <asp:ListItem Text="Malaysia" Value="Malaysia" />                                                                
                                                                          </asp:DropDownList>
                                       </div>
                                    </div>
                                    <asp:Button CssClass="buybutton" runat="server" id="btnBye" Text="Buy Now" OnClick="btnbuy_OnClick" BorderStyle="None" /> 
                                    <%--<button class="submit check_out" runat="server" id="btnBye" onclick="btnbuy_OnClick">Buy Now</button> --%>                 
                                 </div>
                                
                                 </div>                                 
                              </section>  
                                <strong> <asp:Label ID="lblStatus" runat="server" style="background-color:#f2dede; font-size:15px;  border-radius: 4px;"></asp:Label></strong>                                     
                               </ContentTemplate>
                                        </asp:UpdatePanel>                        
                        </div>
                       
                       <div class="col-md-4 checkout-left-basket" style="border:1px solid black;background-color: #ffd6bd;">
                           <h4 style="width:378px">HAVE AN ACCOUNT ? LOGIN</h4>
                             <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin" >
                              <div class="information-wrapper" >
                              <div class="col-md-12"  >
                                    <div class="first-row form-group">
                                       <div class="card_number_grids">
                            <div class="controls">
                             <label class="control-label">
                                    Email</label>
                                <asp:TextBox ID="txtUserID" runat="server" AutoCompleteType="Disabled" class="billing-address-name form-control"></asp:TextBox>
                               
                                  <div class="clear"> </div>    
                            </div>
                            </div>
                             <br />                
                              <div class="card_number_grid_left">
                             <div class="controls">
                             <label class="control-label">
                                    Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="billing-address-name form-control" AutoCompleteType="Disabled"></asp:TextBox>
                               
                                  <div class="clear"> </div>    
                            </div>
                            </div>
                            <br />                
                            <asp:Label ID="lblLogStatus" runat="server" Text="" ForeColor="Red"></asp:Label>                           
                            <asp:Button ID="btnLogin" CssClass="buybutton" runat="server" Text="Login" OnClick="btnSignin_OnClick" BorderStyle="None"/>
                                                    <br />
                        <br />
                       <%-- <div class="g-signin2" data-onsuccess="onSignIn">
                        </div>
                        <div style="margin-top: -55px; margin-left: 145px">
                            <a href="javascript:void(0);" onclick="fbLogin()" id="fbLink">
                                <img src="images/fblogin.png" alt="FBLogin" /></a></div>
                          </div>--%>
                          </div> 
                          
                          </div>
                          </div>
                        </asp:Panel>
                        </div>
                         <div class="clearfix"> </div>
                        <div class="clearfix"></div>
                     </div>
                  </div>
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

        <!-- //Here Google Login -->
    <script>

        function onSignIn(googleUser) {
            var profile = googleUser.getBasicProfile();
            signOut();
            //document.getElementById('profileinfo').innerHTML = "<label>" + profile.getId() + "</label><br>" + profile.getName() + "<br>" + "<a  href='mailto:'" + profile.getEmail() + "'>" + profile.getEmail() + "</a>" + "<br>" + "<img src='" + profile.getImageUrl() + "'/>";
            window.location.href = "http://www.easybuybye.com/Glogin.aspx?param1=" + profile.getEmail() + "&param2=" + profile.getName() + "&param3=" + profile.getImageUrl() + "&param4=" + profile.getId() + "&param5=Google";
            // window.location.href = "http://localhost/EasyBuyBye/Glogin.aspx?param1=" + profile.getEmail() + "&param2=" + profile.getName() + "&param3=" + profile.getImageUrl() + "&param4=" + profile.getId();
        }

        function signOut() {
            var auth2 = gapi.auth2.getAuthInstance();
            auth2.signOut().then(function () {
                document.getElementById('profileinfo').innerHtML = "";
            });
        }
    </script>
    <!-- //End Google Login -->
    <!-- //Here Facebook Login -->
    <script>
        window.fbAsyncInit = function () {
            // FB JavaScript SDK configuration and setup
            FB.init({
                appId: '654329048636497', // FB App ID
                cookie: true,  // enable cookies to allow the server to access the session
                xfbml: true,  // parse social plugins on this page
                version: 'v2.8' // use graph api version 2.8
            });

            // Check whether the user already logged in
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    //display user data
                    getFbUserData();
                }
            });
        };

        // Load the JavaScript SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));

        // Facebook login with JavaScript SDK
        function fbLogin() {
            FB.login(function (response) {
                if (response.authResponse) {
                    // Get and display the user profile data
                    getFbUserData();
                } else {
                    document.getElementById('status').innerHTML = 'User cancelled login or did not fully authorize.';
                }
            }, { scope: 'email' });
        }

        // Fetch the user profile data from facebook
        function getFbUserData() {
            FB.api('/me', { locale: 'en_US', fields: 'id,first_name,last_name,email,link,gender,locale,picture' },
    function (response) {
        fbLogout();
        //        document.getElementById('fbLink').setAttribute("onclick", "fbLogout()");
        //        document.getElementById('fbLink').innerHTML = 'Logout from Facebook';
        //        document.getElementById('status').innerHTML = 'Thanks for logging in, ' + response.first_name + '!';
        //        document.getElementById('userData').innerHTML = '<p><b>FB ID:</b> ' + response.id + '</p><p><b>Name:</b> ' + response.first_name + ' ' + response.last_name + '</p><p><b>Email:</b> ' + response.email + '</p><p><b>Gender:</b> ' + response.gender + '</p><p><b>Locale:</b> ' + response.locale + '</p><p><b>Picture:</b> <img src="' + response.picture.data.url + '"/></p><p><b>FB Profile:</b> <a target="_blank" href="' + response.link + '">click to view profile</a></p>';
        window.location.href = "http://www.easybuybye.com/Glogin.aspx?param1=" + response.email + "&param2=" + response.first_name + "&param3=" + response.picture.data.url + "&param4=" + response.id + "&param5=Facebook";

    });
        }

        // Logout from facebook
        function fbLogout() {
            FB.logout(function () {
                document.getElementById('fbLink').setAttribute("onclick", "fbLogin()");
                document.getElementById('fbLink').innerHTML = '<img src="fblogin.png"/>';
                document.getElementById('userData').innerHTML = '';
                document.getElementById('status').innerHTML = 'You have successfully logout from Facebook.';
            });
        }
    </script>
    <!-- //End Facebook Login -->

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
     <script src="https://apis.google.com/js/platform.js" async defer></script>
    </form>
</body>
</html>
