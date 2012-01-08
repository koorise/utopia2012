<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.News._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">  
    <gk:Navigator ID="Navigator1" runat="server" />  
    <div class="news_index">
        <!--NewsIndex_960_100_1 AD1-->
        <gk:AD ID="AD1" runat="server" Width="960" Height="100" Category="NewsIndex_960_100_1" />       
    </div>
    <div class="news_index">
        <div class="left">
            <div class=" mdB10"><gk:Slide ID="Slide1" runat="server" Width="344" Height="258" Category="NewsIndex" /></div>
            <div class="news_content">
                <div class="hd"><h2><span><a href="/News/0-1-1.html" >更多</a></span>新闻排行</h2></div>
                <div class="bd ul_square">
                    <asp:Repeater ID="RepeaterListHits" runat="server" OnItemDataBound="RepeaterListHits_ItemDataBound">
                        <HeaderTemplate><ul></HeaderTemplate>
                        <ItemTemplate>
                            <li><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"  CssClass="Ablack"></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="ft"></div>
            </div>
        </div>
        <div class="center">
            <div class="news_content">
                <div class="hd"><h2><span><a href="/News/0-2-1.html">更多</a></span>焦点新闻</h2></div>
                <div class="bd ul_none">   
                   <h2><asp:HyperLink ID="HyperLinkHotTitle1" runat="server" Target="_blank"></asp:HyperLink></h2>      
                   <asp:Repeater ID="RepeaterListHotUp" runat="server" OnItemDataBound="RepeaterListHot_ItemDataBound">
                        <HeaderTemplate><ul></HeaderTemplate>
                        <ItemTemplate>
                            <li><asp:HyperLink ID="HyperLinkCategory" runat="server" Target="_blank"  CssClass="Ablue"></asp:HyperLink><asp:HyperLink ID="HyperLinkTitle" CssClass="Ablack" runat="server" Target="_blank"></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:Repeater>
                    <h2><asp:HyperLink ID="HyperLinkHotTitle2" runat="server" Target="_blank"></asp:HyperLink></h2>      
                    <asp:Repeater ID="RepeaterListHotDown" runat="server" OnItemDataBound="RepeaterListHot_ItemDataBound">
                        <HeaderTemplate><ul></HeaderTemplate>
                        <ItemTemplate>
                            <li><asp:HyperLink ID="HyperLinkCategory" runat="server" Target="_blank" CssClass="Ablue"></asp:HyperLink><asp:HyperLink ID="HyperLinkTitle"  CssClass="Ablack" runat="server" Target="_blank"></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="ft"></div>
            </div>
        </div>
        <div class="right">
            <gk:ProductCommend ID="ProductCommend1" runat="server" />
        </div>
    </div>
    <div class="clear"></div>
    <div class="news_index  mdT10 mdB10">
        <!--NewsIndex_960_100_2 AD2-->
        <gk:AD ID="AD2" runat="server" Width="960" Height="100" Category="NewsIndex_960_100_2" />       
    </div>
    <gk:ChannelIndexCategory ID="ChannelIndexCategory1" runat="server" />
    <div class="clear"></div>
    <div class="news_index mdT10">
        <!--NewsIndex_960_100_3 AD3-->
        <gk:AD ID="AD3" runat="server" Width="960" Height="100" Category="NewsIndex_960_100_3" />       
    </div>   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
