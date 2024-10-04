<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="MenuControl_SearchBox" %>

 <div class="header-bot_inner_wthreeinfo_header_mid">
            <!-- header-bot -->
            <div class="col-md-4 header-middle">
             <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">     
              <asp:TextBox ID="txtSearch" runat="server" class="Searchtxt" placeholder="EasyBuyBye Search here..." Modifier="Public"></asp:TextBox>       
                <asp:Button ID="btnSearch" runat="server" class="Searchbtn" OnClick="btnSearch_OnClick" />
                  </asp:Panel>
            </div>
            <!-- header-bot -->
            <div class="col-md-4 logo_agile">
                <a href="index.aspx"> <asp:Image ID="Image1" runat="server" ImageUrl="~/web/images/logo3.png" Height="60px" alt="Logo" /></a>
            </div>
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

     