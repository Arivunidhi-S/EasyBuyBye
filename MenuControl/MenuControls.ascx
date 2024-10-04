<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControls.ascx.cs" Inherits="MenuControls" %>

<ul id="menu">
    <li>
			<a href="#">All Categories</a>
			<ul>
           
             <% for (int a = 0; a < dtBasicCategory.Rows.Count; a++)
                        { %>
					 <li><a href='AllProducts.aspx?Basic=<%= dtBasicCategory.Rows[a][0].ToString()%>&Sub=0'><%= dtBasicCategory.Rows[a][3].ToString()%></a>
					<ul>
                     <% dtSubCategory = BusinessTier.getSubCategory(dtBasicCategory.Rows[a][0].ToString());
                                       int aa;
                                       for (aa = 0; aa < dtSubCategory.Rows.Count; aa++)
                                       { %>
						<li>

							<a href='AllProducts.aspx?Basic=0&Sub=<%= dtSubCategory.Rows[aa][1].ToString()%>'>  <%= dtSubCategory.Rows[aa][0].ToString()%></a>
							<ul>
                             <% dtCategory = BusinessTier.getCategory(dtSubCategory.Rows[aa][1].ToString());
                                       int aaa;
                                       for (aaa = 0; aaa < dtCategory.Rows.Count; aaa++)
                                       { %>
								<li class='last-child '><a href='Products.aspx?Param=<%= dtCategory.Rows[aaa][2].ToString()%>&Param1=<%= dtCategory.Rows[aaa][3].ToString()%>'><%= dtCategory.Rows[aaa][0].ToString()%></a></li>
								  <% } %>
							</ul>							
						</li>
                         <% } %>

					</ul>					
				</li>
                 <% } %>
					</ul>		
		</li>
		<%--<li><a href="MonthlyDeals.aspx"><% =DateTime.Now.ToString("MMMM") %> Deals</a></li>--%>
        <%--<li><a href="http://bazaar.easybuybye.com/eBazzaar.aspx" target="_blank" ><b>EasyBazaar</b></a></li>--%>

		<li><a href="https://www.easybuybye.com/AllProducts.aspx?Basic=5&Sub=0"><b>Sports & Outdoors</b></a></li>
        <li><a href="https://www.easybuybye.com/AllProducts.aspx?Basic=13&Sub=0"><b>Asian Taste</b></a></li>
         <li><a href="https://www.easybuybye.com/AllProducts.aspx?Basic=16&Sub=0" ><b>Kids Fashion</b></a>
			<%--<a href="RM5.aspx">Below RM 5</a>--%>			
		</li>
		
		<li><a href="Recent.aspx">Recent Products</a></li>
		
	</ul>
