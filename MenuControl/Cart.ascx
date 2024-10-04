<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cart.ascx.cs" Inherits="MenuControl_Cart" %>
<style type="text/css">
    .dropbtn
    {
        background-color: #4CAF50;
        color: white;
        padding: 16px;
        font-size: 16px;
        border: none;
    }
    
    .dropdown
    {
        position: absolute;
    }
    
    .dropdown-content
    {
        display: none;
        position: absolute;
        background-color: #f1f1f1;
        min-width: 160px;
        z-index: 1;
    }
    
    .dropdown-content a
    {
        font:  14px 'Open Sans', sans-serif;
        letter-spacing:1px;
		text-decoration: none;
        color: black;
        padding: 15px 15px;
        text-decoration: none;
        display: block;
    }
    
    .dropdown-content a:hover
    {
        background-color: #ddd;
    }
    
    .dropdown:hover .dropdown-content
    {
        display: block;
    }
    
    .dropdown:hover .dropbtn
    {
        background-color: #3e8e41;
    }
    
    .btncart
    {
        font-size:26px;
        text-decoration:none;
        color:Black;
        padding:2px 2px 3px 2px;
        }
    .btncart:hover
    {      
        color:Black;       
        }
    
</style>
<div class="wthreecartaits wthreecartaits2 cart cart box_1">
    <div class="dropdown">
        <a id="Button2" class="btncart" onclick="myFunction()">
            <i class="fa fa-user-plus" aria-hidden="true"></i>
        </a>
        <% if (Request.Cookies["CustomerID"].Value.ToString() != "0")
           { %>
        <div id="myDropdown" class="dropdown-content">
            <a href="AccountInfo.aspx">My Account</a> <a href="Wishlist.aspx">My Wishlist</a> <a href="Address.aspx">My Address</a> <a href="BuyerOrder.aspx">My Orders</a> <a href="ReturnCancel.aspx">Return/Cancel</a>
        </div>
        <% }
           else
           { %>
           <div id="myDropdown" class="dropdown-content">
            <a href="login.aspx?param=0">Login</a>
        </div>
        <% } %>
    </div>
    <a id="Button1" class="btncart" type="submit" name="submit" value="" onserverclick="btnShopCart_Click"
        runat="server">
        <i class="fa fa-cart-arrow-down " aria-hidden="true"></i>
    </a>
    <asp:Label runat="server" ID="lblcart" class="carttop"></asp:Label>
</div>
