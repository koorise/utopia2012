<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="GK2010.Web.Product.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="navigator">
        <a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="/product/">产品中心</a>&nbsp;&gt;&nbsp;<asp:HyperLink
            ID="HyperLinkBig" runat="server"></asp:HyperLink>&nbsp;&gt;&nbsp;<asp:HyperLink ID="HyperLinkSmall" runat="server"></asp:HyperLink>
    </div>
    <div class="main">
        <div class="left mar5 ">
            <!--product left start-->
            <gk:ProductLeft ID="ProductLeft1" runat="server" />
            <!--product left end-->
        </div>
        <!-- right start -->
        <div class="right_cont ">
            <div class="base_infor ">
                <!--product list start-->
                <gk:ProductList ID="ProductList1" runat="server" />
                <!--product list end-->
                <div class="product_list">
                      <asp:Repeater ID="RepeaterListProduct" runat="server" OnItemDataBound="RepeaterListProduct_ItemDataBound">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="td1" valign="middle" align="center">
                                            <asp:Literal ID="txtImg" runat="server"></asp:Literal>
                                        </td>
                                        <td class="td2" valign="top">
                                            <h2><asp:Literal ID="txtTitle" runat="server"></asp:Literal></h2>                                
                                            <div>
                                                <asp:Literal ID="txtSummary" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td class="td3">
                                            <span class="price"><asp:Literal ID="txtPrice" runat="server"></asp:Literal></span><br />
                                            <span class="price-market"><asp:Literal ID="txtPriceOld" runat="server"></asp:Literal></span>
                                        </td>
                                    </tr>
                                </table>
                                <div class="seperator"></div>
                            </ItemTemplate>
                        </asp:Repeater>       
                </div>
                <div class="clear"></div>                 
                <div class="pages pdL10" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
                    
                </div>
            </div>
        </div>
        <!-- right end -->
    </div>
</asp:Content>