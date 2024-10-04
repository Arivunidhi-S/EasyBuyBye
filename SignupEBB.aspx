<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignupEBB.aspx.cs" Inherits="SignupEBB" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
    <title>EasyBuyBye | Signup </title>
    <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet">
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet">
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css'>
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
</head>
<body>
    <form id="frm1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true">
    </asp:ScriptManager>
    <!-- header -->
    <div class="header" id="home">
        <div class="container">
            <ul>
                <%--<li> <a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-unlock-alt" aria-hidden="true"></i> Sign In </a></li>
			<li> <a href="#" data-toggle="modal" data-target="#myModal2"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sign Up </a></li>
			<li><i class="fa fa-phone" aria-hidden="true"></i> Call : 01234567898</li>
			<li><i class="fa fa-envelope-o" aria-hidden="true"></i> <a href="mailto:info@example.com">info@example.com</a></li>--%>
                <li><i class="fa fa-phone" aria-hidden="true"></i>Call : +60 1160726529</li>
                <li><i class="fa fa-envelope-o" aria-hidden="true"></i><a href="mailto:admin@easybuybye.com">
                    admin@easybuybye.com</a></li>
                <li><a href="#" data-toggle="modal" data-target="#myModal1"><i class="glyphicon glyphicon-user"
                    aria-hidden="true"></i>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </a></li>
                <li><a href="#" data-toggle="modal"><i class="fa fa-pencil-square-o" aria-hidden="true">
                </i>Sign Up </a></li>
                <li><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-unlock-alt"
                    aria-hidden="true"></i>
                    <%--<asp:Label ID="lblLog" runat="server" ></asp:Label>--%>
                </a>
                    <%--<asp:LinkButton ID="lblLog" runat="server"  OnClick="BtnLogout_Click"     />--%><asp:Button
                        ID="lblLog" runat="server" OnClick="BtnLogout_Click" CssClass="logbtn" Text="" /></li>
            </ul>
        </div>
    </div>
    <!-- //header -->
    <!-- header-bot -->
    <div class="header-bot">
        <div class="header-bot_inner_wthreeinfo_header_mid">
            <div class="col-md-4 header-middle">
                <%--<form action="#" method="post">--%>
                <asp:TextBox ID="txtSearch" runat="server" class="Searchtxt" placeholder="EasyBuyBye Search here..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" class="Searchbtn" />
                <div class="clearfix">
                </div>
                <%--</form>--%>
            </div>
            <!-- header-bot -->
            <div class="col-md-4 logo_agile">
                <a href="index.aspx">
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/web/images/Logo.png" /></a>
            </div>
            <!-- header-bot -->
            <div class="col-md-4 agileits-social top_content">
                <ul class="social-nav model-3d-0 footer-social w3_agile_social">
                    <li class="share">Share On : </li>
                    <li><a href="https://www.facebook.com/Easybuybye-151955558610155/" class="facebook"
                        target="_blank">
                        <div class="front">
                            <i class="fa fa-facebook" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-facebook" aria-hidden="true"></i>
                        </div>
                    </a></li>
                    <li><a href="https://twitter.com/easybuybye" class="twitter" target="_blank">
                        <div class="front">
                            <i class="fa fa-twitter" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-twitter" aria-hidden="true"></i>
                        </div>
                    </a></li>
                    <li><a href="https://www.instagram.com/easybuybye__my/" class="instagram" target="_blank">
                        <div class="front">
                            <i class="fa fa-instagram" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-instagram" aria-hidden="true"></i>
                        </div>
                    </a></li>
                    <li><a href="https://www.linkedin.com/in/easybuybye-online-shopping-427335132" class="pinterest"
                        target="_blank">
                        <div class="front">
                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                        </div>
                    </a></li>
                </ul>
            </div>
            <div class="clearfix">
            </div>
        </div>
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
				  <ul class="nav navbar-nav menu__list">                
                  					<li class="dropdown menu__item">
						<a href="#" class="dropdown-toggle menu__link" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Women Fashion<span class="caret"></span></a>
							<ul class="dropdown-menu multi-column columns-3">
								<div class="agile_inner_drop_nav_info">
                                  <% 
                                      dtSubMenuItems = BusinessTier.getSubMenuItems("1");
                                      int j = 0, k = 0, n = 0;
                                      int inc = dtSubMenuItems.Rows.Count / 7;
                                      int l = 0;
                                      if (inc < 1)
                                      {
                                          k = 1;
                                          l = dtSubMenuItems.Rows.Count;
                                      }
                                      else
                                      {
                                          k = 2;
                                          l = 7;
                                      }
                                      for (j = 0; j < k; j++)
                                      {
                                     %>
									<div class="col-sm-3 multi-gd-img">
										<ul class="multi-column-dropdown">                                     
                                     
                                      <% 
                                          for (int mi = 0; mi < l; mi++)
                                          {
                                              if (n == 1) { mi = mi + 7; }
                                             %>
											<li><a href='Products.aspx?Param=<%= dtSubMenuItems.Rows[mi][2].ToString()%>&Param1=0'> <%= dtSubMenuItems.Rows[mi][0].ToString()%></a></li>
								      <%
                                            if (n == 1) { mi = mi - 7; }
                                        } %>
										</ul>
									</div>
								<%           
                                        l = dtSubMenuItems.Rows.Count - 7;
                                        n = 1;
                                      }  %>
									<div class="col-sm-6 multi-gd-img multi-gd-text ">
										<a href="#"><img src="web/images/top1.jpg" alt=" "/></a>
									</div>
									<div class="clearfix"></div>
								</div>
							</ul>
					</li>

                     <% for (int a = 0; a < dtMenuItems.Rows.Count; a++)
                        { %>
                            <li class="menu__item dropdown">
					   <a class="menu__link" href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <%= dtMenuItems.Rows[a][3].ToString()%><b class="caret"></b></a>
                               <ul class="dropdown-menu agile_short_dropdown">
                                    <% dtSubMenuItems = BusinessTier.getSubMenuItems(dtMenuItems.Rows[a][0].ToString());
                                       int aa;
                                       for (aa = 0; aa < dtSubMenuItems.Rows.Count; aa++)
                                       { %>
                                    <li><a href='Products.aspx?Param=<%= dtSubMenuItems.Rows[aa][2].ToString()%>&Param1=0'>
                                        
                                            <%= dtSubMenuItems.Rows[aa][0].ToString()%></a> </li>
                                    <% } %>
                                </ul>
                            </li>
                            <% } %>

                            <li class="menu__item dropdown">
					   <a class="menu__link" href="#" class="dropdown-toggle" data-toggle="dropdown">Others<b class="caret"></b></a>
								<ul class="dropdown-menu agile_short_dropdown">
									   <li><a href='Products.aspx?Param=29&Param1=0'>Travel Accessories</a> </li>
									  <li><a href='Products.aspx?Param=17&Param1=0'>Skin Care</a></li>
								</ul>
					</li>                        
				  </ul>
				</div>
			  </div>
			</nav>
            </div>
            <div class="top_nav_right">
                <div class="wthreecartaits wthreecartaits2 cart cart box_1">
                    <button id="btncart" class="w3view-cart" type="submit" name="submit" value="" onserverclick="btnShopCart_Click"
                        runat="server">
                        <i class="fa fa-cart-arrow-down" aria-hidden="true"></i>
                    </button>
                    <asp:Label runat="server" ID="lblcart" class="carttop"> </asp:Label>
                </div>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>
                            <div class="col-md-6 contact-form">
                                <h4 class="white-w3ls">
                                    CREATE <span>ACCOUNT</span></h4>
                                <div class="styled-input agile-styled-input-top">
                                    <asp:TextBox ID="txtName" runat="server" class="textbox"  onkeyup="checkchar(this);"
                                        ToolTip="You don't use Special Character like ' \ / : * ? ~ ` < > | . ''"></asp:TextBox>
                                    <label>
                                        Name</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtEmail" runat="server" class="textbox"></asp:TextBox>
                                    <label>
                                        Email</label>
                                    <span></span>
                                </div>
                                <div class="styled-input">
                                    <asp:TextBox ID="txtContact" runat="server" class="textbox" onkeyup="checkDec(this);"
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
                                <span>
                                    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <div class="clearfix">
                                    </div>
                                    <asp:Button ID="btnsumit" runat="server" Text="Submit" OnClick="btnsumit_OnClick" />
                                </span>
                            </div>
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
