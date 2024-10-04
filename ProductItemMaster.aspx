<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductItemMaster.aspx.cs"
    Inherits="ProductItemMaster" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Products Item Master </title>
    <link rel="shortcut icon" href="web/Images/Slogo.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="web/css/style2.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="web/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="web/js/move-top.js"></script>
    <script type="text/javascript" src="web/js/easing.js"></script>
    <style type="text/css">
        .enjoy-css
        {
            display: inline-block;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            cursor: pointer;
            padding: 5px 15px;
            border: 1px solid #c1011e;
            font: normal 14px/normal Arial, Helvetica, sans-serif;
            color: rgba(255,255,255,0.9);
            -o-text-overflow: clip;
            text-overflow: clip;
            background: #ba2518;
            -webkit-box-shadow: 2px 2px 2px 0 rgba(0,0,0,0.2);
            box-shadow: 2px 2px 2px 0 rgba(0,0,0,0.2);
            text-shadow: -1px -1px 0 rgba(15,73,168,0.66);
            -webkit-transition: font-size 300ms cubic-bezier(0.175, 0.885, 0.32, 1.275) 4ms, color 200ms cubic-bezier(0.19, 1, 0.22, 1) 15ms;
            -moz-transition: font-size 300ms cubic-bezier(0.175, 0.885, 0.32, 1.275) 4ms, color 200ms cubic-bezier(0.19, 1, 0.22, 1) 15ms;
            -o-transition: font-size 300ms cubic-bezier(0.175, 0.885, 0.32, 1.275) 4ms, color 200ms cubic-bezier(0.19, 1, 0.22, 1) 15ms;
            transition: font-size 300ms cubic-bezier(0.175, 0.885, 0.32, 1.275) 4ms, color 200ms cubic-bezier(0.19, 1, 0.22, 1) 15ms;
        }
        
        .enjoy-css:hover
        {
            border: 1px solid #0c0a0a;
            background: #0c0b0b;
            -webkit-transition: all 1000ms cubic-bezier(0.25, 0.25, 0.75, 0.75) 17ms;
            -moz-transition: all 1000ms cubic-bezier(0.25, 0.25, 0.75, 0.75) 17ms;
            -o-transition: all 1000ms cubic-bezier(0.25, 0.25, 0.75, 0.75) 17ms;
            transition: all 1000ms cubic-bezier(0.25, 0.25, 0.75, 0.75) 17ms;
        }
        
        .search
        {
            background: url(images/Reject.png) no-repeat;
            background-position: center;
        }
    </style>
    <script type="text/javascript">

        function checkDec(el) {
            var ex = /^[0-9]+\.?[0-9]*$/;
            if (ex.test(el.value) == false) {
                el.value = el.value.substring(0, el.value.length - 1);
            }
        }
    </script>
    <script type="text/javascript">
        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }
      
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
                <div class="logo">
                    <a href="index.aspx">
                        <img src="web/images/logo.png" alt="" /></a>
                    <img src="web/images/malaysia.jpg" width="400px" height="70px" style="left:110px;position:relative"
                        alt="" />
                </div>
               
                <div class="clear">
                </div>
            </div>
            <div class="header_bottom">
                <div class="menu">
                    <ul>
                        <li><a href="index.aspx">Home</a></li>
                        <li><a href="AboutUs.aspx">About</a></li>
                        <li><a href="Delivery.aspx">Delivery</a></li>
                        <li><a href="News.aspx">News</a></li>
                        <li><a href="Contact.aspx">Contact</a></li>
                        <li><a href="AdminPage.aspx">Dashboard</a></li>
                        <%-- <li><a href="index.aspx">Logout</a></li>--%>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <telerik:RadScriptManager ID="ScriptManager1" runat="server" />
                <%--  <div class="search_box">
                    <input type="text" value="Search" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Search';}" /><input
                        type="submit" value="" />
                </div>--%>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="main">
            <div class="content">
                <div class="section group">
                    <div class="col span_2_of_7">
                        <div class="contact-form1">
                            <h2>
                                Products Item Master</h2>
                            <div>
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                <span>
                                    <label>
                                        Basic Categories</label></span> <span>
                                            <%--  <asp:DropDownList ID="cboCategories" runat="server" class="mydropdown" Height="33px"
                                                Width="684px">
                                            </asp:DropDownList>--%>
                                            <telerik:RadComboBox ID="cboBasicCategories" runat="server" EnableLoadOnDemand="true" Skin="Sunset"
                                                Width="300px" AutoPostBack="true" DropDownWidth="300px" AppendDataBoundItems="true"
                                                OnItemsRequested="cboBasicCategories_OnItemsRequested" EmptyMessage="Select Basic Categories"
                                                OnSelectedIndexChanged="cboBasicCategories_SelectedIndexChanged">
                                                <Items>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Categories</label></span> <span>
                                            <%--  <asp:DropDownList ID="cboCategories" runat="server" class="mydropdown" Height="33px"
                                                Width="684px">
                                            </asp:DropDownList>--%>
                                            <telerik:RadComboBox ID="cboCategories" runat="server" Width="300px" OnSelectedIndexChanged ="cboCategory_SelectedIndexChanged"
                                                DropDownWidth="300px" DataValueField="Dept_ID" CssClass="textbox" EnableLoadOnDemand="true"
                                                AutoPostBack="true" AppendDataBoundItems="True" EmptyMessage="Select Categories" Skin="Sunset"
                                                OnItemsRequested="cboCategory_OnItemsRequested">
                                                <Items>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Brand</label></span> <span>
                                            <telerik:RadComboBox ID="cboBrand" runat="server" Width="300px" OnItemsRequested="cboBrand_OnItemsRequested"
                                                DropDownWidth="300px" DataValueField="Dept_ID" CssClass="textbox" EnableLoadOnDemand="true" Skin="Sunset"
                                                AutoPostBack="true" AppendDataBoundItems="True" EmptyMessage="Select Brand" OnSelectedIndexChanged ="cboBrand_OnSelectedIndexChanged">
                                                <Items>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Model</label></span> <span>
                                            <telerik:RadComboBox ID="cboModel" runat="server" Width="300px" DropDownWidth="300px" OnItemsRequested="cboModel_OnItemsRequested"
                                                DataValueField="Dept_ID" CssClass="textbox" EnableLoadOnDemand="true" AppendDataBoundItems="True"
                                                EmptyMessage="Select Model" OnSelectedIndexChanged="cboModel_SelectedIndexChanged" Skin="Sunset"
                                                AutoPostBack="true">
                                                <Items>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Total Stock</label></span> <span>
                                            <asp:TextBox ID="txtTotalStock" runat="server" class="textbox" onkeyup="checkDec(this);"></asp:TextBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Image 1</label></span> <span>
                                            <asp:FileUpload ID="FileImage1" runat="server" class="textbox" /></span>
                                <asp:LinkButton ID="lnkDownload1" Font-Size="13px" runat="server" Visible="true"
                                    ForeColor="Blue" OnClick="lnkDownload1_OnClick" CommandName="Download" />
                                <asp:Button runat="server" ID="btnclikrjt1" Font-Size="Smaller" ForeColor="Green" Text=" "
                                    BorderStyle="None" Style="background: url(images/Reject.png) no-repeat; background-position: center;"
                                    AutoPostBack="true" Width="25px" Height="20px" OnClick="btnclikrjt1_Onclick" />
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Image 2</label></span> <span>
                                            <asp:FileUpload ID="FileImage2" runat="server" class="textbox" /></span>
                                <asp:LinkButton ID="lnkDownload2" Font-Size="13px" runat="server" Visible="true"
                                    ForeColor="Blue" OnClick="lnkDownload2_OnClick" CommandName="Download" />
                                <asp:Button runat="server" ID="btnclikrjt2" Font-Size="Smaller" ForeColor="Green" Text=" "
                                    BorderStyle="None" Style="background: url(images/Reject.png) no-repeat; background-position: center;"
                                    AutoPostBack="true" Width="25px" Height="20px" OnClick="btnclikrjt2_Onclick" />
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Image 3</label></span> <span>
                                            <asp:FileUpload ID="FileImage3" runat="server" class="textbox" />
                                        </span>
                                <asp:LinkButton ID="lnkDownload3" Font-Size="13px" runat="server" Visible="true"
                                    ForeColor="Blue" OnClick="lnkDownload3_OnClick" CommandName="Download" />
                                <asp:Button runat="server" ID="btnclikrjt3" Font-Size="Smaller" ForeColor="Green" Text=" "
                                    BorderStyle="None" Style="background: url(images/Reject.png) no-repeat; background-position: center;"
                                    AutoPostBack="true" Width="25px" Height="20px" OnClick="btnclikrjt3_Onclick" />
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Image 4</label></span> <span>
                                            <asp:FileUpload ID="FileImage4" runat="server" class="textbox" /></span>
                                <asp:LinkButton ID="lnkDownload4" Font-Size="13px" runat="server" Visible="true"
                                    ForeColor="Blue" OnClick="lnkDownload4_OnClick" CommandName="Download" />
                                <asp:Button runat="server" ID="btnclikrjt4" Font-Size="Smaller" ForeColor="Green" Text=" "
                                    BorderStyle="None" Style="background: url(images/Reject.png) no-repeat; background-position: center;"
                                    AutoPostBack="true" Width="25px" Height="20px" OnClick="btnclikrjt4_Onclick" />
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Image 5</label></span> <span>
                                            <asp:FileUpload ID="FileImage5" runat="server" class="textbox" /></span>
                                <asp:LinkButton ID="lnkDownload5" Font-Size="13px" runat="server" Visible="true"
                                    ForeColor="Blue" OnClick="lnkDownload5_OnClick" CommandName="Download" />
                                <asp:Button runat="server" ID="btnclikrjt5" Font-Size="Smaller" ForeColor="Green" Text=" "
                                    BorderStyle="None" Style="background: url(images/Reject.png) no-repeat; background-position: center;"
                                    AutoPostBack="true" Width="25px" Height="20px" OnClick="btnclikrjt5_Onclick" />
                            </div>
                            <div>
                                <span>
                                    <asp:Button ID="Button1" runat="server" Text="Add Product" class="myButton" OnClick="btnAddProduct_OnClick" /></span>
                            </div>
                        </div>
                    </div>
                    <div class="col span_2_of_7">
                        <div class="contact_info">
                            <br />
                            <br />
                            <br />
                            <br />
                            <h2>
                                Add Stocks</h2>
                            <%--  <div class="map">
							   	    <iframe width="100%" height="175" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed"></iframe><br><small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265" style="color:#666;text-align:left;font-size:12px">View Larger Map</a></small>
							  </div>--%>
                        </div>
                        <div class="contact-form1">
                            <div>
                                <%-- <span>
                                    <label>
                                        Color</label></span>--%>
                                <span>
                                    <asp:TextBox ID="txtcolor" CssClass="csstext" runat="server" Visible="false"></asp:TextBox>
                                </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Size</label></span> <span>
                                            <asp:TextBox ID="txtSize" runat="server" CssClass="csstext"></asp:TextBox>
                                        </span>
                            </div>
                            <div>
                                <span>
                                    <label>
                                        Stock</label></span> <span>
                                            <asp:TextBox ID="txtStock" runat="server" CssClass="csstext" onkeyup="checkDec(this);"></asp:TextBox>
                                        </span>
                            </div>
                            <div>
                                <br />
                                <span>
                                    <asp:Button ID="Button2" runat="server" Text="Add" CssClass="enjoy-css" OnClick="btnAddStock_OnClick" /></span>&nbsp;&nbsp;&nbsp;<asp:Label
                                        ID="lblGridStatus" runat="server" Text=""></asp:Label>
                            </div>
                            <br />
                            <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowEdit="false" OnNeedDataSource="RadGrid2_NeedDataSource"
                                GridLines="Vertical" AllowPaging="false" PagerStyle-AlwaysVisible="false" PagerStyle-Position="Bottom"
                                OnDeleteCommand="RadGrid2_DeleteCommand" Skin="Sunset" AllowAutomaticUpdates="true"
                                OnItemCommand="RadGrid2_ItemCommand" AllowAutomaticInserts="true" PagerStyle-Mode="NextPrevNumericAndAdvanced"
                                AllowAutomaticDeletes="true" AllowSorting="true" AllowFilteringByColumn="false">
                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="false" DataKeyNames="PricingID">
                                    <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="PricingID" DataType="System.Int64" HeaderText="ID"
                                            ReadOnly="True" SortExpression="PricingID" UniqueName="PricingID" AllowFiltering="false"
                                            AllowSorting="false" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <%-- <telerik:GridBoundColumn DataField="ProColor" DataType="System.String" HeaderText="Color"
                                                SortExpression="ProColor" UniqueName="ProColor" AllowFiltering="false">
                                                <HeaderStyle Width="10%" />
                                            </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn DataField="ProSize" DataType="System.String" HeaderText="Size"
                                            SortExpression="ProSize" UniqueName="ProSize" AllowFiltering="false">
                                            <HeaderStyle Width="10%" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Stock" DataType="System.String" HeaderText="Stock"
                                            SortExpression="Stock" UniqueName="Stock" AllowFiltering="false">
                                            <HeaderStyle Width="10%" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton"
                                            HeaderText="Remove" ConfirmText="Are you sure want to delete?">
                                            <HeaderStyle Width="2%" />
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
    <script type="text/javascript">
        $(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });

        });
	</script>
    <%--<a href="#" id="toTop"><span id="toTopHover"></span></a>--%>
    </form>
</body>
</html>
