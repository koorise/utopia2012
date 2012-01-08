<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="list_pic.aspx.cs" Inherits="GK2010.Web.Product.list_pic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/detail.css" rel="stylesheet" type="text/css" />
    <link href="/css/page.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="navigator">
         <a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="/product/">产品中心</a>&nbsp;&gt;&nbsp;<asp:HyperLink ID="HyperLinkBig" runat="server"></asp:HyperLink>&nbsp;&gt;&nbsp;<asp:HyperLink ID="HyperLinkSmall" runat="server"></asp:HyperLink>
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
                <gk:productlist ID="ProductList1" runat="server" />
                <!--product list end-->
                <div class="list2">
                    <div class="buy_contt">
                        <asp:Repeater ID="RepeaterListProduct" runat="server" OnItemDataBound="RepeaterListProduct_ItemDataBound">
                            <ItemTemplate>
                            <dl>
                                <dt>
                                    <table class="pic">
                                        <tr>
                                            <td align="center" valign="middle"><asp:HyperLink ID="HyperLinkImage" runat="server" Target="_blank"></asp:HyperLink></td>
                                        </tr>
                                    </table>
                                </dt>
                                <dt class="good-name"><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"></asp:HyperLink></dt>
                                <dd class="good-market-price">市场价：<s><asp:Literal ID="txtPriceOld" runat="server"></asp:Literal></s></dd>
                                <dd class="good-price"><span><asp:Literal ID="txtPrice" runat="server"></asp:Literal></span></dd>
                            </dl>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="clear"></div>
                    <div class="pages pdL10" >
	                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <!-- right end -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
