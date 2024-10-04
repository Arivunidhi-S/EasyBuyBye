<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Preview.aspx.cs" Inherits="Preview" %>

<!--
A Design by ArivunidhiSrinivasan
      -->
<!DOCTYPE html>
<html>
<head runat="server">
   <meta property="og:site_name" content="EasyBuyBye" />
    <meta property="og:type" content="product" />
    <meta property="og:price:currency" content="MYR" /> 
<asp:Literal runat="server" ID="litMeta" />
<%--<meta property="product:availability" content="in stock" />--%>
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
    <title>EasyBuyBye | Preview </title>
    <link rel="shortcut icon" href="web/Images/Slogo2.png" />
    <!--/tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
 
    <script>
        var link = document.createElement('meta');
        link.setAttribute('property', 'og:url');
        link.content = document.location;
        document.getElementsByTagName('head')[0].appendChild(link);
    </script>
    <script>
        var link = document.createElement('meta');
        link.setAttribute('property', 'og:image');
        link.content = document.getElementById('<%= Image2.ClientID %>').src;
        document.getElementsByTagName('head')[1].appendChild(link);
    </script>
    <script>
        //For Character Check TextBox
        function checkDec(el) {
            var ex = /^[0-9]+\.?[0-9]*$/;
            if (ex.test(el.value) == false) {
                el.value = el.value.substring(0, el.value.length - 1);
            }
        }
    </script>
    <%--<script>
    var link = document.createElement('meta');
    link.setAttribute('property', 'og:title');
    link.content = document.getElementById("htitle").innerHTML;
    document.getElementsByTagName('head')[2].appendChild(link);
</script>--%>
    <%--<script>
    var link = document.createElement('meta');
    link.setAttribute('property', 'og:description');
    link.content = "<b>" + document.getElementById("htitle").innerText + " <b><br>" + document.getElementById("pdesc").innerHTML;
    document.getElementsByTagName('head')[3].appendChild(link);
</script>--%>
    <%--<meta property="og:url"           content="location.href" />--%>
    <%--<meta property="og:type" content="website" /> --------------------------------------------- Note
    <meta property="og:title" content="Preview Page" />--%>
    <%-- <meta property="og:description"   content="document.getElementById("hthree").innerhtml" />--%>
    <%--<meta property="og:image"         content= "document.getElementById("Image2").src" />--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--//tags -->
    <link href="web/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/style3.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/font-awesome.css" rel="stylesheet" />
    <link href="web/css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
    <link href="web/css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="web/css/rating.min.css" rel="stylesheet" type="text/css" />
    <!-- //for bootstrap working -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800"
        rel="stylesheet" />
    <link href='//fonts.googleapis.com/css?family=Lato:400,100,100italic,300,300italic,400italic,700,900,900italic,700italic'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" type="text/css" href="web/zoom/css/styleZoom.css" />
    <script type="text/javascript">
        document.getElementById("title").setAttribute("content", document.getElementById("htitle").innerText);
        function fbs_click() {
            //+'&t=' + encodeURIComponent(t) //kid_directed_site=0&
            //u = "www.easybuybye.com/preview.aspx";

            u = location.href; t = document.getElementById("htitle").innerText; window.open('http://www.facebook.com/sharer/sharer.php?kid_directed_site=0&u=' + encodeURIComponent(u), 'sharer', 'toolbar=0,status=0,width=626,height=436');
            return false;
        }
        function twi_click() {
            u = location.href; t = document.getElementById("htitle").innerText + ' ' + document.getElementById("spanprice").innerText; window.open('https://twitter.com/intent/tweet?original_referer=' + encodeURIComponent(u) + '&url=' + encodeURIComponent(u) + '&hashtags=EasyBuyBye&text=' + encodeURIComponent(t) + '. Get it on www.easybuybye.com now! ', 'sharer', 'toolbar=0,status=0,width=626,height=436');
            return false;
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
                Product <span>Details </span>
            </h3>
            <!--/w3_short-->
            <div class="services-breadcrumb">
                <div class="agile_inner_breadcrumb">
                    <ul class="w3_short">
                        <li><a href="index.aspx">Home</a><i>|</i></li>
                        <li><a href='AllProducts.aspx?Basic=<%= dtPreview.Rows[0][20].ToString()%>&Sub=0'>
                            <%= dtPreview.Rows[0][22].ToString()%></a><i>|</i></li>
                        <li><a href='AllProducts.aspx?Basic=0&Sub=<%= dtPreview.Rows[0][21].ToString()%>'>
                            <%= dtPreview.Rows[0][23].ToString()%></a><i>|</i></li>
                        <li><a href='Products.aspx?Param=<%= dtPreview.Rows[0][12].ToString()%>&Param1=0'>
                            <%= dtPreview.Rows[0][14].ToString()%></a><i>|</i></li>
                        <li>Product Details</li>
                    </ul>
                </div>
            </div>
            <!--//w3_short-->
        </div>
    </div>
    <!-- banner-bootom-w3-agileits -->
    <div class="banner-bootom-w3-agileits">
        <div class="container">
            <div class="col-md-4 single-right-left ">
                <div class="grid images_3_of_2">
                    <p>
                        <div class="bzoom_wrap">
                            <ul id="bzoom">
                                <% 
                                    if (dtPreview.Rows[0][0].ToString() != "")
                                    { %>
                                <li>
                                    <asp:Image class="bzoom_thumb_image" ID="Image1" runat="server" title="first img" />
                                    <asp:Image class="bzoom_big_image" ID="Image2" runat="server" />
                                </li>
                                <% } %>
                                <% 
                                    if (dtPreview.Rows[0][1].ToString() != "")
                                    { %>
                                <li>
                                    <asp:Image class="bzoom_thumb_image" ID="Image3" runat="server" title="Second img" />
                                    <asp:Image class="bzoom_big_image" ID="Image4" runat="server" />
                                </li>
                                <% } %>
                                <% 
                                    if (dtPreview.Rows[0][2].ToString() != "")
                                    { %>
                                <li>
                                    <asp:Image class="bzoom_thumb_image" ID="Image5" runat="server" title="Third img" />
                                    <asp:Image class="bzoom_big_image" ID="Image6" runat="server" />
                                </li>
                                <% } %>
                                <% 
                                    if (dtPreview.Rows[0][3].ToString() != "")
                                    { %>
                                <li>
                                    <asp:Image class="bzoom_thumb_image" ID="Image7" runat="server" title="Forth img" />
                                    <asp:Image class="bzoom_big_image" ID="Image8" runat="server" />
                                </li>
                                <% } %>
                                <% 
                                    if (dtPreview.Rows[0][4].ToString() != "")
                                    { %>
                                <li>
                                    <asp:Image class="bzoom_thumb_image" ID="Image9" runat="server" title="Fifth img" />
                                    <asp:Image class="bzoom_big_image" ID="Image10" runat="server" />
                                </li>
                                <% } %>
                            </ul>
                            <input type="hidden" runat='server' id="param1" value="" />
                            <div class="clearfix">
                            </div>
                        </div>
                    </p>
                </div>
            </div>
            <div class="clearfix">
                <div class="move">
                    <div class="col-md-8 single-right-left simpleCart_shelfItem" style="float: left;">
                        <br />
                        <h3 id="htitle">
                            <%= dtPreview.Rows[0][5].ToString()%>&nbsp;
                            <%= dtPreview.Rows[0][6].ToString()%>
                        </h3>
                        <p>
                            <span class="item_price" id="spanprice">RM
                                <%= dtPreview.Rows[0][11].ToString()%></span> <del>RM
                                    <%= dtPreview.Rows[0][7].ToString()%></del></p>
                        <div class="rating1">
                            <span class="starRating">
                                <input id="rating5" type="radio" name="rating" value="5" />
                                <label for="rating5">
                                    5</label>
                                <input id="rating4" type="radio" name="rating" value="4" />
                                <label for="rating4">
                                    4</label>
                                <input id="rating3" type="radio" name="rating" value="3" checked="checked" />
                                <label for="rating3">
                                    3</label>
                                <input id="rating2" type="radio" name="rating" value="2" />
                                <label for="rating2">
                                    2</label>
                                <input id="rating1" type="radio" name="rating" value="1" />
                                <label for="rating1">
                                    1</label>
                            </span><span style="padding-left: 20px; font-weight: bold">Add Wishlist : </span>
                            <asp:ImageButton ID="imgbtn" runat="server" OnClick="imgbtn_Click"></asp:ImageButton>
                            <input type="hidden" runat='server' id="hdWhish" value="" />
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                            EnableViewState="true">
                            <ContentTemplate>
                                <div class="description" id="divPostcode" runat="server">
                                    <h5>
                                        Check delivery availability and charges for your location</h5>
                                    <asp:TextBox ID="txtPincode" runat="server" placeholder="Enter postcode..." onkeyup="checkDec(this);"></asp:TextBox>
                                    <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_OnClick" /><br />
                                    <h5 style="padding-top: 10px">
                                        <asp:Label ID="lblPincode" runat="server"></asp:Label></h5>
                                </div>
                                <div id="divbr" runat="server">
                                    <br />
                                    <br />
                                    <b>* Delivery in Shah Alam & Subang * </b>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </div>
                                <div class="color-quality" style="float: left">
                                    <div class="color-quality-right" runat="server" id="divsize">
                                        <h5>
                                            Size :</h5>
                                        <asp:HiddenField ID="hdqnty" runat="server" />
                                        <asp:DropDownList ID="ddlSize" runat="server" OnSelectedIndexChanged="ddlSize_OnSelectedIndexChanged"
                                            EnableViewState="true" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="color-quality" style="float: left" runat="server" id="divmiddle">
                                    &nbsp; &nbsp; &nbsp;
                                </div>
                                <div class="color-quality">
                                    <div class="color-quality-right" style="float: left" runat="server" id="divQuantity">
                                        <h5>
                                            Quantity :</h5>
                                        <asp:DropDownList ID="ddlQuantity" runat="server" class="frm-field sect">
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                                <div class="occasion-cart">
                                    <asp:LinkButton ID="lnkAddcart" runat="server" OnClick="btnAddCart_OnClick" class="snipcart-details single-item hvr-outline-out">Add Cart</asp:LinkButton>
                                </div>
                            </ContentTemplate>

                           <%--  <Triggers>
           <asp:PostBackTrigger ControlID="lnkAddcart" />
          </Triggers>--%>
                        </asp:UpdatePanel>
                        <ul class="social-nav model-3d-0 footer-social w3_agile_social single_page_w3ls">
                            <li class="share">Share On : </li>
                            <li><a onclick="return fbs_click()" target="_blank" class="facebook">
                                <div class="front">
                                    <i class="fa fa-facebook" aria-hidden="true"></i>
                                </div>
                                <div class="back">
                                    <i class="fa fa-facebook" aria-hidden="true"></i>
                                </div>
                            </a></li>
                            <li><a onclick="return twi_click()" target="_blank" class="twitter">
                                <div class="front">
                                    <i class="fa fa-twitter" aria-hidden="true"></i>
                                </div>
                                <div class="back">
                                    <i class="fa fa-twitter" aria-hidden="true"></i>
                                </div>
                            </a></li>
                            <%-- <li><a href="#" class="instagram">
                        <div class="front">
                            <i class="fa fa-instagram" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-instagram" aria-hidden="true"></i>
                        </div>
                    </a></li>
                    <li><a href="#" class="pinterest">
                        <div class="front">
                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                        </div>
                        <div class="back">
                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                        </div>
                    </a></li>--%>
                        </ul>
                        <%--  <a data-share="facebook" href="" data-href="https://www.facebook.com/sharer/sharer.php" data-url="https://easybuybye.com/preview.aspx/" class="bd-facebook-share bd-social-share" data-wpel-link="internal">facebook</a>--%>
                        <%--<a href="https://twitter.com/share?ref_src=twsrc%5Etfw" class="twitter-share-button" data-size="large" data-text="SilkSarees  CS105" data-hashtags="EasyBuyBye" data-related="EasyBuyBye" data-dnt="true" data-show-count="false">Tweet</a><script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>--%>
                        <%--<iframe src="https://www.facebook.com/plugins/share_button.php?href=https%3A%2F%2Fwww.easybuybye.com%2Fpreview.aspx%3FParam%3D859&layout=button_count&size=large&width=102&height=28&appId" width="102" height="28" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true" allow="encrypted-media"></iframe>--%>
                        <%--                        <div id="fb-root"></div>
<script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v6.0"></script>
<div class="fb-share-button" data-href="https://www.easybuybye.com/Products.aspx" data-layout="button" data-size="large">
<a target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fwww.easybuybye.com%2FProducts.aspx&amp;src=sdkpreparse" class="fb-xfbml-parse-ignore">Share</a>
</div>--%>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <br />
                <br />
                <br />
                <br />
                <!-- /new_arrivals -->
                <div class="responsive_tabs_agileits">
                    <div id="divbr1" runat="server" style="margin-top: 50px; padding-bottom: 50px; height: 50px">
                        <br />
                        <br />
                        <br />
                        <br />
                        &nbsp;
                        <br />
                        <br />
                    </div>
                    <div id="horizontalTab">
                        <ul class="resp-tabs-list">
                            <li>Description</li>
                            <li>Reviews</li>
                            <li>View More</li>
                        </ul>
                        <div class="resp-tabs-container">
                            <!--/tab_one-->
                            <div class="tab1">
                                <div class="single_page_agile_its_w3ls">
                                    <h6>
                                        Product details of
                                        <%= dtPreview.Rows[0][5].ToString()%>&nbsp;
                                        <%= dtPreview.Rows[0][6].ToString()%></h6>
                                    <p id="pdesc">
                                        <%= dtPreview.Rows[0][9].ToString()%></p>
                                </div>
                            </div>
                            <!--//tab_one-->
                            <div class="tab2">
                                <div class="single_page_agile_its_w3ls">
                                    <div class="bootstrap-tab-text-grids">
                                        <div class="bootstrap-tab-text-grid">
                                        </div>
                                        <div class="add-review">
                                            <h4>
                                                add a review</h4>
                                            <%--<form action="#" method="post">--%>
                                            <input type="hidden" runat='server' id="HiddenField1" value="" />
                                            <input type="hidden" runat='server' id="HiddenField2" value="" />
                                            <div id="shop" style="padding-bottom: 10px">
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true"
                                                EnableViewState="true">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtReviewtitle" runat="server" placeholder="Review Title"></asp:TextBox>
                                                    <%--<input type="email" name="Email">--%>
                                                    <asp:TextBox ID="txtReviewdescription" runat="server" placeholder="Review Description"
                                                        Width="320px" TextMode="MultiLine" Height="90px" MaxLength="300" onkeypress="return this.value.length<=299"></asp:TextBox>
                                                    <h5 style="padding: 0 0 10px 0">
                                                        <asp:Label class="labelstyle" ID="lblreviewstatus" runat="server" /></h5>
                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit Review" class="btn-css" OnClick="btnsubmit_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <% if (!(dtProductReview.Rows.Count == 0))
                                               { %>
                                            <div class="review">
                                                <div class="your-review">
                                                    <hr style="border: 0; height: 1px; background-image: linear-gradient(to right, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.75), rgba(0, 0, 0, 0));" />
                                                    <%   
                                                   int dtPR = 0;
                                                   for (dtPR = 0; dtPR < dtProductReview.Rows.Count; dtPR++)
                                                   { %>
                                                    <h4>
                                                        Review by
                                                        <%= dtProductReview.Rows[dtPR][2].ToString().Trim()%></h4>
                                                    <ul style="list-style: none; padding: 5px 0 5px 0;">
                                                        <li style="padding: 5px 0 5px 0;">Rating :<img src="images/star<%= dtProductReview.Rows[dtPR][1].ToString().Trim()%>.png"
                                                            alt="" /></li>
                                                        <li>
                                                            <%= dtProductReview.Rows[dtPR][3].ToString().Trim()%></li>
                                                        <%--<li>Quality :<a href="#"><img src="images/quality-rating.png" alt="" /></a></li>--%>
                                                    </ul>
                                                    <p class="lblfont">
                                                        <%= dtProductReview.Rows[dtPR][4].ToString().Trim()%></p>
                                                    <hr style="border: 0; height: 1px; background-image: linear-gradient(to right, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.75), rgba(0, 0, 0, 0));" />
                                                    <% 
                                   }
                                                    %>
                                                </div>
                                            </div>
                                            <%} %>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab3">
                                <div class="single_page_agile_its_w3ls">
                                    <div style="text-align: center;">
                                        <% 
                                            if (!(string.IsNullOrEmpty(dtPreview.Rows[0][0].ToString())))
                                            {
                                                string path1 = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtPreview.Rows[0][0].ToString().Trim();
                                        %>
                                        <img src="<%= path1%>" alt="" />
                                        <% } %><br />
                                        <% 
                                            if (!(string.IsNullOrEmpty(dtPreview.Rows[0][1].ToString())))
                                            {
                                                string path2 = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtPreview.Rows[0][1].ToString().Trim();
                                            
                                        %>
                                        <img src="<%= path2%>" alt="" />
                                        <% } %><br />
                                        <% 
                                            if (!(string.IsNullOrEmpty(dtPreview.Rows[0][2].ToString())))
                                            {
                                                string path3 = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtPreview.Rows[0][2].ToString().Trim();
                                        %>
                                        <img src="<%= path3%>" alt="" />
                                        <% } %><br />
                                        <% 
                                            if (!(string.IsNullOrEmpty(dtPreview.Rows[0][3].ToString())))
                                            {
                                                string path4 = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtPreview.Rows[0][3].ToString().Trim();
                                        %>
                                        <img src="<%= path4%>" alt="" />
                                        <% } %><br />
                                        <% 
                                            if (!(string.IsNullOrEmpty(dtPreview.Rows[0][4].ToString())))
                                            {
                                                string path5 = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtPreview.Rows[0][4].ToString().Trim();
                                        %>
                                        <img src="<%= path5%>" alt="" />
                                        <% } %>
                                    </div>
                                    <%--<h6>
                                    Big Wing Sneakers (Navy)</h6>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elPellentesque vehicula augue
                                    eget nisl ullamcorper, molestie blandit ipsum auctor. Mauris volutpat augue dolor.Consectetur
                                    adipisicing elit, sed do eiusmod tempor incididunt ut lab ore et dolore magna aliqua.
                                    Ut enim ad minim veniam, quis nostrud exercitation ullamco. labore et dolore magna
                                    aliqua.</p>
                                <p class="w3ls_para">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elPellentesque vehicula augue
                                    eget nisl ullamcorper, molestie blandit ipsum auctor. Mauris volutpat augue dolor.Consectetur
                                    adipisicing elit, sed do eiusmod tempor incididunt ut lab ore et dolore magna aliqua.
                                    Ut enim ad minim veniam, quis nostrud exercitation ullamco. labore et dolore magna
                                    aliqua.</p>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- //new_arrivals -->
                <!--/slider_owl-->
                <div class="w3_agile_latest_arrivals">
                    <h3 class="wthree_text_info">
                        RELATED <span>PRODUCTS</span></h3>
                    <%   
                        int dtR = 0;
                        for (dtR = 0; dtR < dtRecentitems.Rows.Count; dtR++)
                        {
                            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + dtRecentitems.Rows[dtR][3].ToString().Trim();   
                    %>
                    <div class="col-md-3">
                        <div class="men-pro-item simpleCart_shelfItem">
                            <div class="divthumb">
                                <div class="flip-box">
                                    <div class="flip-box-inner">
                                        <div class="flip-box-front">
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[dtR][4].ToString().Trim()%>">
                                                <img class="imgthumb" src="<%= path%>" alt="<%= dtRecentitems.Rows[dtR][7].ToString()%>"
                                                    title="<%= dtRecentitems.Rows[dtR][7].ToString()%>" /></a>
                                        </div>
                                        <div class="flip-box-back">
                                            <a href="preview.aspx?Param=<%= dtRecentitems.Rows[dtR][4].ToString().Trim()%>">
                                                <img class="imgthumb" src="<%= path%>" alt="<%= dtRecentitems.Rows[dtR][7].ToString()%>"
                                                    title="<%= dtRecentitems.Rows[dtR][7].ToString()%>" /></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item-info-product ">
                             <div style="height:40px">
                                <h4>
                                    <a href="preview.aspx?Param=<%= dtRecentitems.Rows[dtR][4].ToString().Trim()%>">
                                        <%= dtRecentitems.Rows[dtR][8].ToString()%></a></h4>
                                         </div>
                                <div class="info-product-price">
                                    <span class="item_price">RM<%= dtRecentitems.Rows[dtR][5].ToString()%></span> <del>RM
                                        <%= dtRecentitems.Rows[dtR][2].ToString()%></del>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% 
                        }
                    %>
                    <div class="clearfix">
                    </div>
                    <!--//slider_owl-->
                </div>
            </div>
        </div>
        <!--//single_page-->
        <!-- footer -->
        <!-- #Include file="IncludeFooter.html" -->
        <!-- //footer -->
        <script type="text/javascript" src="web/js/rating.min.js"></script>
        <script type="text/javascript">

            /**
            * Demo in action!
            */
            (function () {

                'use strict';

                // SHOP ELEMENT
                var shop = document.querySelector('#shop');

                // DUMMY DATA
                var data = [
      {

          rating: document.getElementById("HiddenField1").value
      },
                //      {

                //          rating: 2
                //      },
                //      {

                //          rating: null
                //      }
    ];

                // INITIALIZE
                (function init() {
                    for (var i = 0; i < data.length; i++) {
                        addRatingWidget(buildShopItem(data[i]), data[i]);
                    }
                })();

                // BUILD SHOP ITEM
                function buildShopItem(data) {
                    var shopItem = document.createElement('div');

                    var html = '<div class="c-shop-item__img"></div>' +
        '<div class="c-shop-item__details">' +
                    //          '<h3 class="c-shop-item__title">' + data.title + '</h3>' +
                    //          '<p class="c-shop-item__description">' + data.description + '</p>' +
          '<ul class="c-rating"></ul>' +
        '</div>';

                    shopItem.classList.add('c-shop-item');
                    shopItem.innerHTML = html;
                    shop.appendChild(shopItem);

                    return shopItem;
                }

                // ADD RATING WIDGET
                function addRatingWidget(shopItem, data) {
                    var ratingElement = shopItem.querySelector('.c-rating');
                    var currentRating = data.rating;
                    var maxRating = 5;

                    var callback = function (rating) {
                        document.getElementById("HiddenField1").value = rating;
                        //                                alert(rating);

                    };
                    var r = rating(ratingElement, currentRating, maxRating, callback);
                }

            })();

        </script>
        <a href="#home" class="scroll" id="toTop" style="display: block;"><span id="toTopHover"
            style="opacity: 1;"></span></a>
        <!-- js -->
        <script type="text/javascript" src="web/js/jquery-2.1.4.min.js"></script>
        <!-- //js -->
        <script src="web/js/modernizr.custom.js"></script>
        <!-- Custom-JavaScript-File-Links -->
        <!-- cart-js -->
        <%--    <script src="web/js/minicart.min.js"></script>
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
        <!-- FlexSlider -->
        <%--    <script src="web/js/jquery.flexslider.js"></script>
    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
            });
        });
    </script>--%>
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
