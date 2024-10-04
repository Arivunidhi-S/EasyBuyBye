﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="index2" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
    <title>EasyBuyBye | Home </title>
     <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <meta name="keywords" content="shopping,online shopping,buy online,buy now,shop now,promotion,sale,fashion,electronics,men fashion,women fashion,grocery,kurtis,tops,sarees,punjabi dress,punjabi suit,salwar kameez,churidar,jacket,cap,round neck,polo,tshirt,t-shirt,laptop,mobile,phone,Lenovo,Asus,HP,Dell,wholesale,product,item,chocolate,biscuit,cookies,tudung,shawls,Denim,Crepe,Cotton,hairgel,chipsmore,jacobs,bake,tudor,tango,kandos,travel,travelloc,travel lock,easybuybye" />
      <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />
</head>
<body>
    <form runat="server" id="form1">
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
                        ID="lblLog" runat="server" OnClick="BtnLogout_Click" CssClass="logbtn" /></li>
            </ul>
        </div>
    </div>
    <!-- //header -->
    <!-- header-bot -->
    <div class="header-bot">
        <div class="header-bot_inner_wthreeinfo_header_mid">
            <div class="col-md-4 header-middle">
                <asp:TextBox ID="txtSearch" runat="server" class="Searchtxt" placeholder="EasyBuyBye Search here..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" class="Searchbtn" />
                <%--<input type="search" name="search" placeholder="Search here...">
					<input type="submit" value=" " runat="server" onserverclick="BtnLogout_Click">--%>
            </div>
            <!-- header-bot -->
            <div class="col-md-4 logo_agile">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/web/images/Logo.png" /><%--<h1><a href="index.aspx"><span>E</span>lite Shoppy <i class="fa fa-shopping-bag top_logo_agile_bag" aria-hidden="true"></i></a></h1>--%>
            </div>
            <!-- header-bot -->
            <div class="col-md-4 agileits-social top_content">
                <ul class="social-nav model-3d-0 footer-social w3_agile_social">
                    <li class="share">Share On : </li>
                    <li><a href="https://www.facebook.com/Easybuybye-151955558610155/" class="facebook" target="_blank">
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
                    <li><a href="https://www.linkedin.com/in/easybuybye-online-shopping-427335132" class="pinterest" target="_blank">
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
                  <li class="active menu__item"><a class="menu__link" href="index.aspx">Home <span class="sr-only">(current)</span></a></li>
					<li class=" menu__item"><a class="menu__link" href="AboutUs.aspx">About</a></li>
                  					<li class="dropdown menu__item">
						<a href="#" class="dropdown-toggle menu__link" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Women Fashion<span class="caret"></span></a>
							<ul class="dropdown-menu multi-column columns-3">
								<div class="agile_inner_drop_nav_info">
                                  <% 
                                    dtSubMenuItems = BusinessTier.getSubMenuItems("1");
                                    int j=0 , k=0 ,n=0;
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
                                    for (j=0;j<k;j++)
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
										<a href="womens.html"><img src="web/images/top1.jpg" alt=" "/></a>
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
					   <a class="menu__link" href="#" class="dropdown-toggle" data-toggle="dropdown">Accessories <b class="caret"></b></a>
								<ul class="dropdown-menu agile_short_dropdown">
									   <li><a href='Products.aspx?Param=42&Param1=0'>Mobile Accessories</a> </li>
									  <li><a href='Products.aspx?Param=45&Param1=0'>Power Banks</a></li>
								</ul>
					</li>

                            <%--<li class="dropdown menu__item">
						<a href="#" class="dropdown-toggle menu__link" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Others <span class="caret"></span></a>
							<ul class="dropdown-menu multi-column columns-3">
								<div class="agile_inner_drop_nav_info">
									
									<div class="col-sm-3 multi-gd-img">
										<ul class="multi-column-dropdown">
											<li ><b>Grocery</b></li>
											<li><a href="Products.aspx?Param=15&Param1=0">Cookies & Biscuits</a></li>
											<li ><b>Travel</b></li>
											<li><a href="Products.aspx?Param=29&Param1=0">Accessories</a></li>
											<li ><b>Wholesale</b></li>
											<li><a href="Products.aspx?Param=31&Param1=0">Biscuits</a></li>
											<li><a href="Products.aspx?Param=32&Param1=0">Chocolates</a></li>
                                            <li><a href="Products.aspx?Param=39&Param1=0">Hair Gel</a></li>
										</ul>
									</div>
                                    <div class="col-sm-6 multi-gd-img1 multi-gd-text ">
										<a href="#"><img src="web/images/top2.jpg" alt=" "/></a>
									</div>
									<div class="clearfix"></div>
								</div>
							</ul>
					</li>--%>

                   <%-- <li class="menu__item dropdown">
					   <a class="menu__link" href="#" class="dropdown-toggle" data-toggle="dropdown">Short Codes <b class="caret"></b></a>
								<ul class="dropdown-menu agile_short_dropdown">
									<li><a href="icons.html">Web Icons</a></li>
									<li><a href="typography.html">Typography</a></li>
								</ul>
					</li>--%>
<%--					<li class="active menu__item menu__item--current"><a class="menu__link" href="index.aspx">Home <span class="sr-only">(current)</span></a></li>
					<li class=" menu__item"><a class="menu__link" href="about.html">About</a></li>
					<li class="dropdown menu__item">
						<a href="#" class="dropdown-toggle menu__link" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Men's wear <span class="caret"></span></a>
							<ul class="dropdown-menu multi-column columns-3">
								<div class="agile_inner_drop_nav_info">
									<div class="col-sm-6 multi-gd-img1 multi-gd-text ">
										<a href="#"><img src="web/images/top2.jpg" alt=" "/></a>
									</div>
									<div class="col-sm-3 multi-gd-img">
										<ul class="multi-column-dropdown">
											<li><a href="#">Clothing</a></li>
											<li><a href="#">Wallets</a></li>
											<li><a href="#">Footwear</a></li>
											<li><a href="#">Watches</a></li>
											<li><a href="#">Accessories</a></li>
											<li><a href="#">Bags</a></li>
											<li><a href="#">Caps & Hats</a></li>
										</ul>
									</div>
									<div class="col-sm-3 multi-gd-img">
										<ul class="multi-column-dropdown">
											<li><a href="#">Jewellery</a></li>
											<li><a href="#">Sunglasses</a></li>
											<li><a href="#">Perfumes</a></li>
											<li><a href="#">Beauty</a></li>
											<li><a href="#">Shirts</a></li>
											<li><a href="#">Sunglasses</a></li>
											<li><a href="#">Swimwear</a></li>
										</ul>
									</div>
									<div class="clearfix"></div>
								</div>
							</ul>
					</li>--%>
					<li class=" menu__item"><a class="menu__link" href="contact.aspx">Contact</a></li>
				  </ul>
				</div>
			  </div>
			</nav>
            </div>
            <div class="top_nav_right">
                <div class="wthreecartaits wthreecartaits2 cart cart box_1">
                    <%--<form action="#" method="post" class="last">--%>
                    <input type="hidden" name="cmd" value="_cart">
                    <input type="hidden" name="display" value="1">
                    <button class="w3view-cart" type="submit" name="submit" value="" onserverclick="btnShopCart_Click" runat="server">
                       <i class="fa fa-cart-arrow-down" aria-hidden="true"></i>
                    </button> <div class="carttop"><asp:Label runat="server" ID="lblcart" ></asp:Label></div>                  
                   <%-- </form>--%>
                </div>
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
            <li data-target="#myCarousel" data-slide-to="3" class=""></li>
            <li data-target="#myCarousel" data-slide-to="4" class=""></li>
        </ol>
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <div class="container">
                    <div class="carousel-caption">
                        <h3>
                            The Biggest <span>Sale</span></h3>
                        <p>
                            Special for Allday</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>
                    </div>
                </div>
            </div>
            <div class="item item2">
                <div class="container">
                    <div class="carousel-caption">
                        <h3>
                            Summer <span>Collection</span></h3>
                        <p>
                            New Arrivals On Sale</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>
                    </div>
                </div>
            </div>
            <div class="item item3">
                <div class="container">
                    <div class="carousel-caption">
                        <h3>
                            Kurtis <span>Top</span></h3>
                        <p>
                            Up To 30% Offer</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=22&Param1=0">Shop Now </a>
                    </div>
                </div>
            </div>
            <div class="item item4">
                <div class="container">
                    <div class="carousel-caption">
                        <h3>
                            Men <span>Shirts</span></h3>
                        <p>
                            New Arrivals On Sale</p>
                        <a class="hvr-outline-out button2" href="https://www.easybuybye.com/Products.aspx?Param=46&Param1=0">Shop Now </a>
                    </div>
                </div>
            </div>
            <div class="item item5">
                <div class="container">
                    <div class="carousel-caption">
                        <h3>
                            The Biggest <span>Sale</span></h3>
                        <p>
                            Special for today</p>
                        <a class="hvr-outline-out button2" href="#">Shop Now </a>
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
        <!-- /new_arrivals -->
    <div class="new_arrivals_agile_w3ls_info">
        <div class="container">
            <h3 class="wthree_text_info">
                New <span>Arrivals</span></h3>
            <div id="horizontalTab">
                <ul class="resp-tabs-list">
                    <li>Sarees</li>
                    <li>Kurtis</li>
                    <li>Accessories</li>
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
                            <div class="col-md-3 product-men">
                            <div class="men-pro-item simpleCart_shelfItem">
                                <div class="men-thumb-item">
                                    <img src="<%= path%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                        class="pro-image-front" />
                                    <img src="<%= path%>" title="<%= dtRecentitems.Rows[aa2][7].ToString()%>" alt="<%= dtRecentitems.Rows[aa2][7].ToString()%>"
                                        class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[aa2][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Quick View</a>
                                        </div>
                                    </div>
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
                                        <span class="item_price">RM<%= dtRecentitems.Rows[aa2][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems.Rows[aa2][2].ToString()%></del>
                                    </div>
                                    <div class="snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2">
                                        <form action="#" method="post">
                                        <fieldset>
                                            <input type="hidden" name="cmd" value="_cart" />
                                            <input type="hidden" name="add" value="1" />
                                            <input type="hidden" name="business" value=" " />
                                            <input type="hidden" name="item_name" value=" <%= dtRecentitems.Rows[aa2][8].ToString()%>" />
                                            <input type="hidden" name="amount" value=" <%= dtRecentitems.Rows[aa2][5].ToString()%>" />
                                            <input type="hidden" name="discount_amount" value="0.00" />
                                            <input type="hidden" name="currency_code" value="MYR" />
                                            <input type="hidden" name="return" value=" " />
                                            <input type="hidden" name="cancel_return" value=" " />
                                            <input type="submit" name="submit" value="Add to cart" class="button" />
                                        </fieldset>
                                        </form>
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
                                    <img src="<%= path%>" title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>"
                                        class="pro-image-front" />
                                    <img src="<%= path%>" title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>" alt="<%= dtRecentitems1.Rows[aa4][7].ToString()%>"
                                        class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Quick View</a>
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
                                        <a href="preview.aspx?Param=<%= dtRecentitems1.Rows[aa4][4].ToString().Trim()%>" title="<%= dtRecentitems1.Rows[aa4][7].ToString()%>">
                                            <%= dtRecentitems1.Rows[aa4][8].ToString()%></a></h4>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems1.Rows[aa4][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems1.Rows[aa4][2].ToString()%></del>
                                    </div>
                                    <div class="snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2">
                                        <form action="#" method="post">
                                        <fieldset>
                                            <input type="hidden" name="cmd" value="_cart" />
                                            <input type="hidden" name="add" value="1" />
                                            <input type="hidden" name="business" value=" " />
                                            <input type="hidden" name="item_name" value=" <%= dtRecentitems1.Rows[aa4][8].ToString()%>" />
                                            <input type="hidden" name="amount" value=" <%= dtRecentitems1.Rows[aa4][5].ToString()%>" />
                                            <input type="hidden" name="discount_amount" value="0.00" />
                                            <input type="hidden" name="currency_code" value="MYR" />
                                            <input type="hidden" name="return" value=" " />
                                            <input type="hidden" name="cancel_return" value=" " />
                                            <input type="submit" name="submit" value="Add to cart" class="button" />
                                        </fieldset>
                                        </form>
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
                                    <img src="<%= path%>" title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>"
                                        class="pro-image-front" />
                                    <img src="<%= path%>" title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>" alt="<%= dtRecentitems2.Rows[aa6][7].ToString()%>"
                                        class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Quick View</a>
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
                                        <a href="preview.aspx?Param=<%= dtRecentitems2.Rows[aa6][4].ToString().Trim()%>" title="<%= dtRecentitems2.Rows[aa6][7].ToString()%>">
                                            <%= dtRecentitems2.Rows[aa6][8].ToString()%></a></h4>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems2.Rows[aa6][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems2.Rows[aa6][2].ToString()%></del>
                                    </div>
                                    <div class="snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2">
                                        <form action="#" method="post">
                                        <fieldset>
                                            <input type="hidden" name="cmd" value="_cart" />
                                            <input type="hidden" name="add" value="1" />
                                            <input type="hidden" name="business" value=" " />
                                            <input type="hidden" name="item_name" value=" <%= dtRecentitems2.Rows[aa6][8].ToString()%>" />
                                            <input type="hidden" name="amount" value=" <%= dtRecentitems2.Rows[aa6][5].ToString()%>" />
                                            <input type="hidden" name="discount_amount" value="0.00" />
                                            <input type="hidden" name="currency_code" value="MYR" />
                                            <input type="hidden" name="return" value=" " />
                                            <input type="hidden" name="cancel_return" value=" " />
                                            <input type="submit" name="submit" value="Add to cart" class="button" />
                                        </fieldset>
                                        </form>
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
                                    <img src="<%= path%>" title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>"
                                        class="pro-image-front" />
                                    <img src="<%= path%>" title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>" alt="<%= dtRecentitems3.Rows[aa8][7].ToString()%>"
                                        class="pro-image-back" />
                                    <div class="men-cart-pro">
                                        <div class="inner-men-cart-pro">
                                            <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>" class="link-product-add-cart">
                                                Quick View</a>
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
                                        <a href="preview.aspx?Param=<%= dtRecentitems3.Rows[aa8][4].ToString().Trim()%>" title="<%= dtRecentitems3.Rows[aa8][7].ToString()%>">
                                            <%= dtRecentitems3.Rows[aa8][8].ToString()%></a></h4>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems3.Rows[aa8][5].ToString()%></span> <del>
                                            RM
                                            <%= dtRecentitems3.Rows[aa8][2].ToString()%></del>
                                    </div>
                                    <div class="snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2">
                                        <form action="#" method="post">
                                        <fieldset>
                                            <input type="hidden" name="cmd" value="_cart" />
                                            <input type="hidden" name="add" value="1" />
                                            <input type="hidden" name="business" value=" " />
                                            <input type="hidden" name="item_name" value=" <%= dtRecentitems3.Rows[aa8][8].ToString()%>" />
                                            <input type="hidden" name="amount" value=" <%= dtRecentitems3.Rows[aa8][5].ToString()%>" />
                                            <input type="hidden" name="discount_amount" value="0.00" />
                                            <input type="hidden" name="currency_code" value="MYR" />
                                            <input type="hidden" name="return" value=" " />
                                            <input type="hidden" name="cancel_return" value=" " />
                                            <input type="submit" name="submit" value="Add to cart" class="button" />
                                        </fieldset>
                                        </form>
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
            <img src="web/images/mid.jpg" alt=" " class="img-responsive" />
        </div>
        <div class="col-md-6 agileits_schedule_bottom_right">
            <div class="w3ls_schedule_bottom_right_grid">
                <h3>
                    Save up to <span>50%</span> in this week</h3>
                <p>
                    Suspendisse varius turpis efficitur erat laoreet dapibus. Mauris sollicitudin scelerisque
                    commodo.Nunc dapibus mauris sed metus finibus posuere.</p>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-user-o" aria-hidden="true"></i>
                    <h4>
                        Customers</h4>
                    <h5 class="counter">
                        653</h5>
                </div>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-calendar-o" aria-hidden="true"></i>
                    <h4>
                        Events</h4>
                    <h5 class="counter">
                        823</h5>
                </div>
                <div class="col-md-4 w3l_schedule_bottom_right_grid1">
                    <i class="fa fa-shield" aria-hidden="true"></i>
                    <h4>
                        Awards</h4>
                    <h5 class="counter">
                        45</h5>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
    <!-- //schedule-bottom -->
    <!-- banner-bootom-w3-agileits -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <h3 class="wthree_text_info">
                What's <span>Trending</span></h3>
            <div class="col-md-5 bb-grids bb-left-agileits-w3layouts">
                <a href="https://www.easybuybye.com/preview.aspx?Param=1192">
                    <div class="bb-left-agileits-w3layouts-inner grid">
                        <figure class="effect-roxy">
							<img src="web/images/bb1.jpg" alt=" " class="img-responsive" />
							<figcaption>
								<h3><span>T</span>-Shirts </h3>
								<p>Upto 38%</p>
							</figcaption>			
						</figure>
                    </div>
                </a>
            </div>
            <div class="col-md-7 bb-grids bb-middle-agileits-w3layouts">
                <a href="https://www.easybuybye.com/Products.aspx?Param=42&Param1=0">
                    <div class="bb-middle-agileits-w3layouts grid">
                        <figure class="effect-roxy">
							<img src="web/images/bottom3.jpg" alt=" " class="img-responsive" />
							<figcaption>
								<h3><span>S</span>ales </h3>
								<p>Upto 38%</p>
							</figcaption>			
						</figure>
                    </div>
                </a><a href="https://www.easybuybye.com/Products.aspx?Param=37&Param1=0">
                    <div class="bb-middle-agileits-w3layouts forth grid">
                        <figure class="effect-roxy">
							<img src="web/images/bottom4.jpg" alt=" " class="img-responsive">
							<figcaption>
								<h3><span>S</span>ales </h3>
								<p>Upto 28%</p>
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
   <%-- <div class="agile_last_double_sectionw3ls">
        <div class="col-md-6 multi-gd-img multi-gd-text ">
            <a href="womens.html">
                <img src="web/images/bot_1.jpg" alt=" "><h4>
                    Flat <span>50%</span> offer</h4>
            </a>
        </div>
        <div class="col-md-6 multi-gd-img multi-gd-text ">
            <a href="womens.html">
                <img src="web/images/bot_2.jpg" alt=" "><h4>
                    Flat <span>50%</span> offer</h4>
            </a>
        </div>
        <div class="clearfix">
        </div>
    </div>--%>
    <!--/grids-->
     <!-- //banner -->
    <div class="banner_bottom_agile_info">
        <div class="container">
            <div class="banner_bottom_agile_info_inner_w3ls">
                <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                    <figure class="effect-roxy">
							<img src="web/images/bottom1.jpg" alt=" " class="img-responsive" />
							<figcaption>
								<h3><span>N</span>ew</h3>
								<p>Arrivals</p>
							</figcaption>			
						</figure>
                </div>
                <div class="col-md-6 wthree_banner_bottom_grid_three_left1 grid">
                    <figure class="effect-roxy">
							<img src="web/images/bottom2.jpg" alt=" " class="img-responsive" />
							<figcaption>
								<h3><span>N</span>ew</h3>
								<p>Arrivals</p>
							</figcaption>			
						</figure>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <!-- /we-offer -->
   <%-- <div class="sale-w3ls">
        <div class="container">
            <h6>
                We Offer Flat <span>40%</span> Discount</h6>
            <a class="hvr-outline-out button2" href="single.html">Shop Now </a>
        </div>
    </div>--%>
    <!-- //we-offer -->
    <!--/grids-->
  
    <!--grids-->
    <!-- footer -->
   <!-- #Include file="IncludeFooter.html" -->
    <%--</div>--%>
    <!-- //footer -->
    <!-- login -->
    <%--<div class="modal fade" id="myModal4" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
				<div class="modal-dialog" role="document">
					<div class="modal-content modal-info">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>						
						</div>
						<div class="modal-body modal-spa">
							<div class="login-grids">
								<div class="login">
									<div class="login-bottom">
										<h3>Sign up for free</h3>
										<form>
											<div class="sign-up">
												<h4>Email :</h4>
												<input type="text" value="Type here" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Type here';}">	
											</div>
											<div class="sign-up">
												<h4>Password :</h4>
												<input type="password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}">
												
											</div>
											<div class="sign-up">
												<h4>Re-type Password :</h4>
												<input type="password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}">
												
											</div>
											<div class="sign-up">
												<input type="submit" value="REGISTER NOW" >
											</div>
											
										</form>
									</div>
									<div class="login-right">
										<h3>Sign in with your account</h3>
										<form>
											<div class="sign-in">
												<h4>Email :</h4>
												<input type="text" value="Type here" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Type here';}">	
											</div>
											<div class="sign-in">
												<h4>Password :</h4>
												<input type="password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}">
												<a href="#">Forgot password?</a>
											</div>
											<div class="single-bottom">
												<input type="checkbox"  id="brand" value="">
												<label for="brand"><span></span>Remember Me.</label>
											</div>
											<div class="sign-in">
												<input type="submit" value="SIGNIN" >
											</div>
										</form>
									</div>
									<div class="clearfix"></div>
								</div>
								<p>By logging in you agree to our <a href="#">Terms and Conditions</a> and <a href="#">Privacy Policy</a></p>
							</div>
						</div>
					</div>
				</div>
			</div>--%>
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
    </form>
</body>
</html>
