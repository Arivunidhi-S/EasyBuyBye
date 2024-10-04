<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="MenuControl_TopMenu" %>
 <ul>
                <li><i class="fa fa-whatsapp" aria-hidden="true"></i> <a href="https://wa.me//60193880122" target="_blank"> +60193880122</a></li>               
                    <li><i class="fa fa-user-o" aria-hidden="true"></i><a href="SellatEBB.aspx" >
                    Sell At EasyBuyBye</a></li>
                <li><i class="glyphicon glyphicon-user"
                    aria-hidden="true"></i> 
                 <asp:Button ID="lblName" runat="server" OnClick="lnkMyAcc_Click" CssClass="logbtn" /><%--<asp:Label
                     ID="lblName" runat="server" CssClass="logbtn"></asp:Label>--%></li>
                <li><a href="Signup.aspx"><i class="fa fa-pencil-square-o" aria-hidden="true">
                </i>Sign Up </a></li>
                <li><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-unlock-alt"
                    aria-hidden="true"></i>                   
                </a>
                  <asp:Button ID="lblLog" runat="server" OnClick="BtnLogout_Click" CssClass="logbtn" /></li>
            </ul>