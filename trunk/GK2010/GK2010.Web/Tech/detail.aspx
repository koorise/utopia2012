<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="GK2010.Web.Tech.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main ">
        <gk:Navigator ID="Navigator1" runat="server" />
        <div class="news_detail">
            <div class="left">
                <div id="news_detail">                     
                    <h1><asp:Literal ID="txtTitle" runat="server"></asp:Literal></h1>
                    <div class="info"><span class="pubTime"><asp:Literal ID="txtPostDate" runat="server"></asp:Literal></span><span class="infoCol"><asp:Literal ID="txtSource" runat="server"></asp:Literal></span><span class="infoCol">浏览(<asp:Literal ID="txtHits" runat="server"></asp:Literal>)</span></div>
                    <div class="summary"><asp:Literal ID="txtSummary" runat="server"></asp:Literal></div>
                    <div class="detail"><asp:Literal ID="txtDetail" runat="server"></asp:Literal></div>
                </div>
            </div>           
            <div class="right">
                <!--TechDetail_250_250_1 AD1-->
                <gk:AD ID="AD1" runat="server" Width="250" Height="250" Category="TechDetail_250_250_1" /> 
                <gk:ProductRelation ID="ProductRelation1" runat="server" />
                <div class="clear"></div>                    
                <asp:Repeater ID="RepeaterListRelation" runat="server" OnItemDataBound="RepeaterListRelation_ItemDataBound">
                    <HeaderTemplate>
                     <div class="news_content mdT10">
                         <div class="hd">
                            <h2><span></span>相关技术支持</h2>
                        </div>
                        <div class="bd ul_square mdB10">
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"  CssClass="Ablack f12"></asp:HyperLink></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                        </div>
                    </div>
                    </FooterTemplate>
                </asp:Repeater>                    
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
