<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head>
    <title>EasyBuyBye | Search </title>
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
<%--    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />--%>
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />  
    
    <link href="AC/css/jquery-ui.css" rel="stylesheet" type="text/css" /> 

   
    
             
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
        <div class="header-bot_inner_wthreeinfo_header_mid">
            <div class="col-md-4 header-middle">
                <%--<form action="#" method="post">--%>
                  <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">    
                 <%--  <asp:AutoCompleteExtender ServiceMethod="GetSearch" MinimumPrefixLength="1" CompletionInterval="10"
            EnableCaching="false" CompletionSetCount="10" TargetControlID="txtSearch" ID="AutoCompleteExtender1"
            runat="server" FirstRowSelected="false">
        </asp:AutoCompleteExtender>--%>
                 <asp:TextBox ID="txtSearch" runat="server" class="Searchtxt" placeholder="EasyBuyBye Search here..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" class="Searchbtn" OnClick="btnSearch_OnClick" />
                   </asp:Panel>
                <div class="clearfix">
                </div>
                <%--</form>--%>
            </div>

    
    
            <!-- header-bot -->
            <div class="col-md-4 logo_agile">
                <a href="index.aspx">
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/web/images/Logo3.png"  Height="60px" alt="Logo"/></a>
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
            Search Page              
                <%--<span>Page </span>--%>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li>Search Page</li>
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
                <div class="" style="text-align:center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                        EnableViewState="true">
                        <ContentTemplate>
                       
                            <h3 style="text-align:center">
                               <asp:Label ID="lblResult" runat="server"></asp:Label></h3>
                            <%--<asp:DropDownList ID="cboBasicCategories" runat="server" Height="25px" class="frm-field sect"
                                Style="height: 35px" AutoPostBack="true"  OnSelectedIndexChanged="cboBasicCategories_SelectedIndexChanged">
                                <%--OnSelectedIndexChanged="cboBasicCategories_OnSelectedIndexChanged"
                                <asp:ListItem Text="Default" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Price(High - Low)" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Price(Low - High)" Value="2"></asp:ListItem>
                            </asp:DropDownList>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clearfix">
                    </div>
                </div>
                <%--<div class="sorting">
					<h6>Showing</h6>
					<select id="country2" onchange="change_country(this.value)" class="frm-field sect" AutoPostBack="true">
						<option value="null">7</option>
						<option value="null">14</option> 
						<option value="null">28</option>					
						<option value="null">35</option>								
					</select>
					<div class="clearfix"></div>
				</div>--%>
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
                                            <%= dtRecentitems.Rows[aa2][8].ToString()%></a></h4>
                                             </div>
                                    <div class="info-product-price">
                                        <span class="item_price">RM<%= dtRecentitems.Rows[aa2][5].ToString()%></span> <del>RM
                                            <%= dtRecentitems.Rows[aa2][2].ToString()%></del>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% 
                                   aa2 = aa2 + 1;
                               }

                               if (s > 4)
                               { aa2 = aa2 - 1; aa1 = 4; }
                               else
                               { aa2 = aa2 + 0; aa1 = 0; }

                           } %>
                    </div>
                </ContentTemplate>            
            </asp:UpdatePanel>
        </div>
    </div>
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

    <script src="AC/js/jquery.min.js" type="text/javascript"></script>
    <script src="AC/js/jquery-ui.min.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           SearchText();
       });
       function SearchText() {
           $("#<%= txtSearch.ClientID %>").autocomplete({
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
//                           alert("No Match");
                       }
                   });
               }
           });
       }
    </script>
     <%--data: "{'BrandName':'" + document.getElementById('txtSearch').value + "'}",--%>
    </form>
</body>
</html>
