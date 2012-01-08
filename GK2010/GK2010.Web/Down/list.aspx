<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="GK2010.Web.Down.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <link href="/css/page.css" rel="stylesheet" type="text/css" />
    <title>
        <%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <gk:Navigator ID="Navigator1" runat="server" />
    <div class="news_list">
        <div class="left">
            <div class="news_content_list flow_l">
                <div class="hd">
                    <h2><asp:Literal ID="txtCategory" runat="server"></asp:Literal></h2>
                </div>
                <div class="bd ul_square_time flow_l">
                    <ul>
                        <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                            <ItemTemplate><asp:Literal ID="txtContent" runat="server"></asp:Literal></ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="pages mdB10 mdL20" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
        <div class="right">
            <!--DownList_250_250_1 AD1-->
            <gk:AD ID="AD1" runat="server" Width="250" Height="250" Category="DownList_250_250_1" />   
            <div class="mdT10"></div>
            <gk:ProductCommend ID="ProductCommend1" runat="server" />
            <div class="clear"></div>
            <div class="news_content mdT10">
                <div class="hd">
                    <h2><span><a href="/Down/0-3-1.html">更多</a></span>下载推荐</h2>
                </div>
                <div class="bd ul_square mdB10">
                    <asp:Repeater ID="RepeaterListCommend" runat="server" OnItemDataBound="RepeaterListCommend_ItemDataBound">
                        <HeaderTemplate><ul></HeaderTemplate>
                        <ItemTemplate>
                            <li><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"  CssClass="Ablack f12"></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
