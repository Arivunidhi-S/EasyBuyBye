<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AdminPage </title>
    <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="web/css/style2.css" rel="stylesheet" type="text/css" media="all" />
    <style type="text/css">
        div.background
        {
            text-align: center;
            float: inherit;
            background-size: 100% 100%;
            position: static;
            width: 300px;
            height: 200px;
            border: 2px solid black;
        }
        
        div.transbox
        {
            margin: 150px 1px 1px 1px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
        }
        
        div.transbox p, .link
        {
            z-index: 1;
            margin: 5%;
            font-weight: bold;
            color: #000000;
        }
    </style>
    <script type="text/javascript" src="web/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="web/js/move-top.js"></script>
    <script type="text/javascript" src="web/js/easing.js"></script>
    <script type="text/javascript" src="web/js/jquery.accordion.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#posts").accordion({
                header: "div.tab",
                alwaysOpen: false,
                autoheight: false
            });
        });
</script>
</head>
<body oncontextmenu="return false;">
    <form id="form1" runat="server">
    <div class="wrap">
        <div class="header">
            <div class="headertop_desc">
                <div class="call">
                    <p>
                        <span>Need help?</span> call us <span class="number">+60 1160726529</span></p>
                </div>
                <div class="account_desc">
                    <ul>
                        <li><a id="A1" runat="server">Welcome :</a>
                            <asp:Label ID="lblName" runat="server" Style="font-size: small"></asp:Label></li>
                        <li><a id="BtnLogout" onserverclick="BtnLogout_Click" runat="server">Logout</a></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="header_top">
           
                <div class="clear">
                </div>
            </div>
            <div class="header_bottom">
                <div class="menu">
                
                </div>
              
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="main">
            <div class="content">
                <div class="section group">
                    
                    <table width="90%">
                        <tr>
                            <td>
                                <div class="background" style="background-image: url(web/images/ProductMaster.jpg);">
                                    <div class="transbox">
                                        <p>
                                            <a href="MasterProduct.aspx" class="link">Add Product </a>
                                        </p>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="background" style="background-image: url(web/images/ProductMaster.png);">
                                    <div class="transbox">
                                        <p>
                                            <a href="MasterProductEdit.aspx" class="link">Edit Product </a>
                                        </p>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="background" style="background-image: url(web/images/ProductItem.jpg);">
                                    <div class="transbox">
                                        <p>
                                            <a href="ProductItemMaster.aspx" class="link">Add/Edit Product Image</a>
                                        </p>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });

        });
	</script>
    <a href="#" id="toTop"><span id="toTopHover"></span></a>
    </form>
</body>
</html>
