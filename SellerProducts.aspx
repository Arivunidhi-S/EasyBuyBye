<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellerProducts.aspx.cs" Inherits="SellerProducts" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Master </title>
    <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="web/css/style2.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/select.css" rel="stylesheet" type="text/css" media="all" />
    <link href="web/css/GridStyle.css" rel="stylesheet" type="text/css" />
    <link href="web/css/alert.css" rel="stylesheet" type="text/css" media="all" />
    <script src="web/js/JScript.js" type="text/javascript"></script>
</head>
<body oncontextmenu="return false;">
    <form id="form1" runat="server">
    <div class="wrap">
        <div class="header">
            <div class="headertop_desc">
                <div class="call">
                    <p>
                          <span>Need help?</span> WhatsApp <span class="number">+601160726529</span></p>
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
                    <ul>
                        <%--<li><a href="index.aspx">Home</a></li>
                        <li><a href="AboutUs.aspx">About</a></li>
                        <li><a href="Delivery.aspx">Delivery</a></li>
                        <li><a href="News.aspx">News</a></li>
                        <li><a href="Contact.aspx">Contact</a></li>--%>
                        <li><a href="http://admin.easybuybye.com/SellerAdminPage.aspx">Dashboard</a></li>
                        <%-- <li><a href="index.aspx">Logout</a></li>--%>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <telerik:RadScriptManager ID="ScriptManager1" runat="server" />
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="main">
            <div class="content">
                <style type="text/css">
                    td
                    {
                        padding: 0px 10px 10px 0px;
                    }
                    .upbtn
                    {
                        color: #FFFFFF !important;
                        font-size: 14px;
                        box-shadow: 1px 1px 0px #BEE2F9;
                        padding: 4px 7px;
                        background: #C41B1B;
                    }
                    .upbtn:hover
                    {
                        color: #FFFFFF !important;
                        background: #000000;
                    }
                </style>
                <div class="section group">
                    <h2>
                        Add Product
                    </h2>
                    <div style="text-align: center">
                        <div class="alert alert-success lblfont" role="alert" id="DivInsert" runat="server">
                            <strong>Well Done!&nbsp;</strong><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                        </div>
                        <%-- <div class="alert alert-info" role="alert" id="DivUpdate" runat="server">
                            <strong>Well Done!</strong>  <asp:Label ID="lblStatus2" runat="server" Text=""></asp:Label>
                        </div>--%>
                        <div class="alert alert-danger lblfont" role="alert" id="DivInfo" runat="server">
                            <strong>Warning!&nbsp;</strong><asp:Label ID="lblStatus2" runat="server" Text=""></asp:Label>
                        </div>
                        <%-- <div class="alert alert-warning" role="alert" id="DivDelete" runat="server">
                            <strong>Well Done!</strong> You are successfully modified seller details.
                        </div>--%>
                    </div>
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="grid_1_of_3 images_1_of_5">
                            <div class="contact-form1">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Basic Categories</label></span> <span>
                                                            <asp:DropDownList ID="cboBasicCategories" runat="server" class="dropdown" Height="25px"
                                                                Width="200px" OnSelectedIndexChanged="cboBasicCategories_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Categories</label></span> <span>
                                                            <asp:DropDownList ID="cboCategories" runat="server" class="dropdown" Height="25px"
                                                                Width="200px">
                                                            </asp:DropDownList>
                                                        </span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label style="float: left; padding-right: 3px">
                                                        Brand</label>
                                                    &nbsp;<img title="You don't use Special Character like ' \ / : * ? ' < > | '" src="images/q.jpg"
                                                        style="float: left" alt="" /></span> <span>
                                                            <asp:TextBox ID="txtBrand" runat="server" class="textbox" Width="200px"></asp:TextBox>
                                                        </span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label style="float: left; padding-right: 3px">
                                                        Model / Color</label>&nbsp;<img title="You don't use Special Character like ' \ / : * ? ' < > | '"
                                                            src="images/q.jpg" style="float: left" alt="" /></span> <span>
                                                                <asp:TextBox ID="txtModel" runat="server" class="textbox" Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <div>
                                                <span>
                                                    <label>
                                                        Product Details</label></span> <span>
                                                            <asp:TextBox ID="txtProductDetails" runat="server" TextMode="MultiLine" Height="88px"
                                                                Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Weight(In Grams)</label></span> <span>
                                                            <asp:TextBox ID="txtWeight" runat="server" class="textbox" onkeyup="checkDec(this);"
                                                                Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label style="float: left; padding-right: 3px">
                                                        Product Photo</label>&nbsp;<img title="(Note: Photo Resolution must be 212x212)"
                                                            src="images/q.jpg" style="float: left" alt="" /> </span>  <span>
                                                            <asp:FileUpload ID="flProductPhoto" runat="server" class="textbox" Width="200px" />
                                                        </span>
                                            </div>
                                        </td>
                                         
                                        <td>
                                        <div>
                                                <span>
                                                    <label style="float: left; padding-right: 3px">
                                                        Shipping Price</label>&nbsp;<img title="(Note: If 'Yes' shipping charge is detect from customer. If 'No' shipping charge is detect from seller)"
                                                            src="images/q.jpg" style="float: left" alt="" /> </span>  <span>
                                                                <asp:RadioButtonList ID="rdShipping" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Text="No"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                               
                                                        </span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Selling Price</label></span> <span>
                                                            <asp:TextBox ID="txtSellingPrice" runat="server" class="textbox" onkeyup="checkDec(this);"
                                                                Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Discount Price</label></span> <span>
                                                            <asp:TextBox ID="txtDiscountPrice" runat="server" class="textbox" onkeyup="checkDec(this);"
                                                                AutoPostBack="false" OnTextChanged="txtDiscount_OnTextChanged" Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>
                                         <td>
                                            <div>
                                                <span>
                                                    <%--<label>
                                                        Actual Price</label>--%></span> <span>
                                                            <asp:TextBox ID="txtActualPrice" runat="server" class="textbox" onkeyup="checkDec(this);"
                                                                Width="200px" Visible="false"></asp:TextBox>
                                                        </span>
                                            </div>
                                        </td>
                                        <%-- <td>
                                            <div>
                                                <span>
                                                    <label>
                                                        Discount (%)</label></span> <span>
                                                            <asp:TextBox ID="txtDiscount" runat="server" MaxLength="2" class="textbox" onkeypress="return onlyNos(event,this);"
                                                                Enabled="false" Width="200px"></asp:TextBox></span>
                                            </div>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="float: none">
                                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_OnClick" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="grid_1_of_3 images_1_of_5">
                            <div class="contact-form1">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Total Stock</label></span> <span>
                                                                        <asp:TextBox ID="txtTotalStock" runat="server" class="textbox" onkeyup="checkDec(this);"
                                                                            Width="200px"></asp:TextBox>
                                                                    </span>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Image 1</label>&nbsp;<img title="(Note: Photo Resolution must be 723x992)"
                                                            src="images/q.jpg"  alt="" /></span> <span>
                                                                        <asp:FileUpload ID="FileImage1" runat="server" class="textbox" Width="200px" /></span>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Image 2</label>&nbsp;<img title="(Note: Photo Resolution must be 723x992)"
                                                            src="images/q.jpg"  alt="" /></span> <span>
                                                                        <asp:FileUpload ID="FileImage2" runat="server" class="textbox" Width="200px" /></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Image 3</label>&nbsp;<img title="(Note: Photo Resolution must be 723x992)"
                                                            src="images/q.jpg" alt="" /></span> <span>
                                                                        <asp:FileUpload ID="FileImage3" runat="server" class="textbox" Width="200px" />
                                                                    </span>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Image 4</label>&nbsp;<img title="(Note: Photo Resolution must be 723x992)"
                                                            src="images/q.jpg"  alt="" /></span> <span>
                                                                        <asp:FileUpload ID="FileImage4" runat="server" class="textbox" Width="200px" /></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <span>
                                                                <label>
                                                                    Image 5</label>&nbsp;<img title="(Note: Photo Resolution must be 723x992)"
                                                            src="images/q.jpg"  alt="" /></span> <span>
                                                                        <asp:FileUpload ID="FileImage5" runat="server" class="textbox" Width="200px" /></span>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <br />
                                                            <div>
                                                                <span>
                                                                    <asp:Button ID="Button1" runat="server" Text="Add Product" class="myButton" OnClick="btnAddProduct_OnClick" />
                                                                    <asp:Button ID="Button2" runat="server" Text="Add New" class="myButton" OnClick="btnAddNew_Click" /></span>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel3" runat="server">
                                                <table>
                                                    <tr>
                                                        <td colspan="3" class="lblfont">
                                                            Add Stocks
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <span>
                                                                    <label>
                                                                        Size</label></span> <span>
                                                                            <asp:TextBox ID="txtSize" runat="server" CssClass="csstext" Width="150px"></asp:TextBox>
                                                                        </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <span>
                                                                    <label>
                                                                        Stock</label></span> <span>
                                                                            <asp:TextBox ID="txtStock" runat="server" CssClass="csstext" onkeyup="checkDec(this);"
                                                                                Width="150px"></asp:TextBox>
                                                                        </span>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: middle">
                                                            <br />
                                                            <asp:LinkButton ID="btnins_up" runat="server" Text="Add" class="lblfont upbtn" OnClick="btnins_up_Onclick" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                PageSize="10" ShowFooter="false" FooterStyle-BackColor="Aqua" ForeColor="#333333"
                                                                GridLines="None" CssClass="mGrid" Width="100%" AlternatingRowStyle-CssClass="alt"
                                                                PagerStyle-CssClass="pgr">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Small" Height="10px" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" ToolTip='<%#Eval("PricingID")%>' OnClick="lnkEdit_OnClick">Edit</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="ProSize" HeaderText="Size" />
                                                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:Button runat="server" ID="btnDelete" ToolTip='<%#Eval("PricingID")%>' Font-Size="Smaller"
                                                                                ForeColor="Green" BorderStyle="None" Style="background: url(images/close.png) no-repeat;
                                                                                background-position: center;" AutoPostBack="true" OnClientClick="return confirm('Are you sure you want to delete this data?');"
                                                                                OnClick="btnDelete_Onclick" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
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
