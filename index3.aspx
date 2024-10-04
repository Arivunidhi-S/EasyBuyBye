﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index3.aspx.cs" Inherits="index3" Trace="true" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
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
</head>
<body>
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
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1" class=""></li>
            <li data-target="#myCarousel" data-slide-to="2" class=""></li>
            <%--<li data-target="#myCarousel" data-slide-to="3" class=""></li>--%>
            <li data-target="#myCarousel" data-slide-to="4" class=""></li>
        </ol>
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
                        <%--  <h3>
                            Summer <span>Collection</span></h3>
                        <p>
                            New Arrivals On Sale</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>--%>
                    </div>
                </div>
            </div>
            <div class="item item3">
                <div class="container">
                    <div class="carousel-caption">
                        <%-- <h3>
                            Kurtis <span>Top</span></h3>
                        <p>
                            Up To 30% Offer</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=22&Param1=0">
                            Shop Now </a>--%>
                    </div>
                </div>
            </div>
            <%--  <div class="item item4">
                <div class="container">
                    <div class="carousel-caption">--%>
            <%--<h3>
                            Men <span>Shirts</span></h3>
                        <p>
                            New Arrivals On Sale</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=46&Param1=0">
                            Shop Now </a>--%>
            <%--  </div>
                </div>
            </div>--%>
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
        </div>
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                    data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                    </span><span class="sr-only">Next</span> </a>
        <!-- The Modal -->
    </div>
    <!-- banner-bootom-w3-agileits -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <h3 class="wthree_text_info">
                What's <span>Trending</span></h3>
            <div class="col-md-5 bb-grids bb-left-agileits-w3layouts">
                <a href="https://www.easybuybye.com/Products.aspx?Param=30&Param1=0 ">
                    <div class="bb-left-agileits-w3layouts-inner grid">
                        <figure class="effect-roxy">
							<img src="web/images/Left.jpg" alt="LeftSide" class="img-responsive" />
							<figcaption>
								<%--<h3><span>T</span>-Shirts </h3>
								<p>Upto 38%</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a>
            </div>
            <div class="col-md-7  bb-middle-agileits-w3layouts">
                <a href="https://www.easybuybye.com/Products.aspx?Param=18&Param1=0">
                    <div class="bb-middle-agileits-w3layouts grid">
                        <figure class="effect-roxy">
							<img src="web/images/Top.jpg" alt="TopSide" class="img-responsive" />
							<figcaption>
								<%--<h3><span>S</span>ales </h3>
								<p>Upto 38%</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a><a href="https://www.easybuybye.com/Products.aspx?Param=58&Param1=0">
                    <div class="bb-middle-agileits-w3layouts forth grid">
                        <figure class="effect-roxy">
							<img src="web/images/bottom.jpg" alt="BottomImage" class="img-responsive">
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
    <div class="banner_bottom_agile_info">
        <div class="container">
            <div class="banner_bottom_agile_info_inner_w3ls">
                <a href="https://www.easybuybye.com/Products.aspx?Param=35&Param1=0">
                    <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                        <figure class="effect-roxy">
							<img src="web/images/Women.jpg" alt="WomenDress" class="img-responsive" />
							<figcaption>
								<%--<h3><span>N</span>ew</h3>
								<p>Arrivals</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a><a href="https://www.easybuybye.com/Products.aspx?Param=23&Param1=0">
                    <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                        <figure class="effect-roxy">
							<img src="web/images/Men.jpg" alt="MenDress" class="img-responsive" />
							<figcaption>
								<%--<h3><span>N</span>ew</h3>
								<p>Arrivals</p>--%>
							</figcaption>			
						</figure>
                    </div>
                </a>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <!-- /we-offer -->
    <!-- /new_arrivals -->
    <div class="new_arrivals_agile_w3ls_info">
        <div class="container">
            <h3 class="wthree_text_info">
                New <span>Arrivals</span></h3>
            <div id="horizontalTab">
                <ul class="resp-tabs-list">
                    <%-- <li>Sarees</li>--%>
                    <li>Feature</li>
                    <li>Kurtis</li>
                    <%--<li>Accessories</li>--%>
                    <li>Sarees</li>
                    <li>Shirts</li>
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
                                   string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems.Rows[aa2][3].ToString().Trim(); 
                        %>
                        <div class="col-md-3">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <%--<div class="men-thumb-item">--%>
                                <div class="divthumb">
                                     <div class="flip-box">
                                        <div class="flip-box-inner">
                                            <div class="flip-box-front">
                                                <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa2][8].ToString()%>" /></a>
                                            </div>
                                            <div class="flip-box-back">
                                                <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa2][8].ToString()%>1"/></a>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<img src="<%= path%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                        class="pro-image-back" />--%>
                                    <%-- <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Quick View</a>
                                        </div>
                                    </div>--%>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems.Rows[aa2][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>                                   
                                </div>
                                <div class="item-info-product ">
                                    <h4>
                                        <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>">
                                            <%= dtRecentitems.Rows[aa2][8].ToString()%></a></h4>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems.Rows[aa2][5].ToString()%></span> <del>RM
                                            <%= dtRecentitems.Rows[aa2][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>                       
                        <%      aa2 = aa2 + 1;
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
                        <div class="col-md-3">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="divthumb">
                                    <div class="flip-box">
                                        <div class="flip-box-inner">
                                            <div class="flip-box-front">
                                                <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa4][8].ToString()%>" /></a>
                                            </div>
                                            <div class="flip-box-back">
                                                <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa2][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa4][8].ToString()%>2" /></a>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems1.Rows[aa4][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>                                   
                                </div>
                                <div class="item-info-product ">
                                    <h4>
                                        <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>"
                                            title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>">
                                            <%= dtRecentitems1.Rows[aa4][8].ToString()%></a></h4>
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
                        <div class="col-md-3">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="divthumb">
                                    <div class="flip-box">
                                        <div class="flip-box-inner">
                                            <div class="flip-box-front">
                                                <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa6][8].ToString()%>" /></a>
                                            </div>
                                            <div class="flip-box-back">
                                                <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa6][8].ToString()%>3" /></a>
                                            </div>
                                        </div>
                                    </div>

                                   
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems2.Rows[aa6][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>                                   
                                </div>
                                <div class="item-info-product ">
                                    <h4>
                                        <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>"
                                            title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>">
                                            <%= dtRecentitems2.Rows[aa6][8].ToString()%></a></h4>
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
                        <div class="col-md-3">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="divthumb">
                                   <div class="flip-box">
                                        <div class="flip-box-inner">
                                            <div class="flip-box-front">
                                                <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa8][8].ToString()%>" /></a>
                                            </div>
                                            <div class="flip-box-back">
                                                <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>">
                                        <img src="<%= path%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>"
                                            class="imgthumb" id="<%= dtRecentitems.Rows[aa8][8].ToString()%>4"/></a>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                   if (!(string.IsNullOrEmpty(dtRecentitems3.Rows[aa8][11].ToString())))
                                   { %>
                                    <span class="product-new-top">Special Offer</span>
                                    <% } %>                                   
                                </div>
                                <div class="item-info-product ">
                                    <h4>
                                        <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>"
                                            title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>">
                                            <%= dtRecentitems3.Rows[aa8][8].ToString()%></a></h4>
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
        <div class="col-md-6 agileinfo_schedule_bottom_left">
            <img src="web/images/Middle.jpg" alt="Middle" class="img-responsive" />
        </div>
        <div class="col-md-6 agileits_schedule_bottom_right">
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
        </div>
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
    </form>
</body>
</html>
