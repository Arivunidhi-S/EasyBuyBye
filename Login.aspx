<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
        <img height="1" width="1" src="https://www.facebook.com/tr?id=517994975548842&ev=PageView
&noscript=1" />
    </noscript>
    <!-- End Facebook Pixel Code -->
    <title>EasyBuyBye | Login </title>
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
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />
    <%--<meta name="google-signin-client_id" content="483364606606-aenk52kg1m8cd89360qfbcgmq8h0nbmk.apps.googleusercontent.com" /> --%><!--Local-->
    <meta name="google-signin-client_id" content="483364606606-v16vfs8o70cevq4u2ho28r29gogbdt7v.apps.googleusercontent.com" />
    
    <script type="text/javascript">
        function OpenWindow() {
            var Mleft = (screen.width / 2) - (600 / 2); var Mtop = (screen.height / 2) - (300 / 2);
            //window.open('ForgetPassword.aspx?param=b', 'newwindow', config = 'height=200, width=400, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, directories=no, status=no');
            window.open('ForgetPassword.aspx?param=b', 'newwindow', config = 'width=500,height=200,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'');
            //window.top.location.href = 'ForgetPassword.aspxss'
        }
        function CallButtonClick2() {
            document.getElementById('Button1').click();
        }
    </script>
    <script>
        function alretmsg() {
            Swal.fire(
  'Good job!',
  'You clicked the button!',
  'success'
)
        }
    </script>
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KXJ9TVD" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <form id="frm1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <!-- header -->
    <div class="header" id="home">
        <div class="container">
            <ul>
                <li><i class="fa fa-whatsapp" aria-hidden="true"></i> <a href="https://wa.me//60193880122" target="_blank"> +60193880122</a></li>               
                <li><i class="fa fa-user-o" aria-hidden="true"></i><a href="sellatebb.aspx">Sell At
                    Easybuybye</a></li>
                <li><a href="Signup.aspx"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>Sign
                    Up </a></li>
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
                <%--                <div class="wthreecartaits wthreecartaits2 cart cart box_1">
                      <button id="btncart" class="w3view-cart" type="submit" name="submit" value="" 
                        runat="server">
                        <i class="fa fa-cart-arrow-down" aria-hidden="true"></i>
                    </button>
                </div>--%>
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
                L<span>ogin </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Login</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <div id="dvmsg" runat="server" style="width:100%; padding-top:25px; color:Green; font-weight:bold; text-align:center">Registration validated successfully!</div>
    
    <!--/contact-->
    <div class="banner_bottom_agile_info">
        <div class="container">
            <div class="agile-contact-grids">
                <div class="agile-contact-left">
                    <div class="col-md-6 address-grid">
                        <h4>
                            Our <span>Information</span></h4>
                        <div class="mail-agileits-w3layouts">
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
                            <i class="fa fa-envelope-o" aria-hidden="true"></i>
                            <div class="contact-right">
                                <p>
                                    Mail
                                </p>
                                <a href="mailto:admin@easybuybye.com">admin@easybuybye.com</a>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 contact-form">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnexpbuy">
                      <asp:Button ID="btnexpbuy" style="background-color: Green;" runat="server" Text="Express Checkout" OnClick="ExpressBuy_OnClick" />
                          <label style="color: Green; font-weight: normal">(No need to signup & Login)</label>
                           <br /><br />
                          <span style="color: #ff6000; font-weight: bold;font-size:18px">(or)</span>
                          <br /> <br />
                        </asp:Panel>
                        <h4 class="black-w3ls">
                            Login <span>Form</span></h4>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
                            <div class="styled-input agile-styled-input-top">
                                <asp:TextBox ID="txtUserID" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                <label>
                                    Email</label>
                                <span></span>
                            </div>
                            <div class="styled-input">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                <label>
                                    Password</label>
                                <span></span>
                            </div>
                            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:LinkButton runat="server" ID="lnkstatus" OnClick="lnkstatus_OnClick" >** Validation required. <u style="color:Blue"> Click here to resend the validation request to your email address</u> ** <br> </asp:LinkButton>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnSignin_OnClick" />
                          
                        </asp:Panel>
                        <a onclick="OpenWindow();" href="">Forget Password ?</a>
                        <br />
                        <br />
                        <div class="g-signin2" data-onsuccess="onSignIn">
                        </div>
                        <div style="margin-top: -55px; margin-left: 120px">
                            <a href="javascript:void(0);" onclick="fbLogin()" id="fbLink">
                                <img src="images/fblogin.png" alt="FBLogin" /></a></div>
                        <%--<a href="" onclick="signOut();">Sign out</a>--%>
                        <div style="color: #ff6000; font-weight: normal">
                            Seller? Sign in<a href="http://admin.easybuybye.com/SellerLogin.aspx"><u>here</u></a></div>
                    </div>
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
    <script type="text/javascript" src="web/js/sweetalert2.all.min.js"></script>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    </form>
</body>
</html>
