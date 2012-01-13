<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Product._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/product.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="navigator">
         <a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="/product/">产品中心</a>
    </div>
    <div class="main">
        <div class="product mdT8">
            <div class="product_left">
                <div class="left1">
                    <div class="hd">
                        <h2>类别检索</h2>
                    </div>
                    <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                        <ItemTemplate>
                            <div class="bd">
                                <h2><asp:HyperLink ID="HyperLinkTitle"  runat="server"></asp:HyperLink></h2>
                                <ul>
                                    <asp:Repeater ID="RepeaterListChild" runat="server" OnItemDataBound="RepeaterListChild_ItemDataBound">
                                        <ItemTemplate>
                                            <li><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="left1 mdT8">
                    <div class="hd">
                        <h2>
                            按拼音检索</h2>
                    </div>
                    <div class="hd2">
                        <ul>
                            <asp:Repeater ID="RepeaterListABC_First" runat="server" OnItemDataBound="RepeaterListABC_First_ItemDataBound">
                                <ItemTemplate><li><asp:Literal ID="txtTitle" runat="server"></asp:Literal></li></ItemTemplate>
                            </asp:Repeater>
                            <li></li>
                        </ul>
                    </div>
                    <asp:Repeater ID="RepeaterListABC" runat="server" OnItemDataBound="RepeaterListABC_ItemDataBound">
                        <ItemTemplate>
                            <div class="bd">
                                <h2><asp:Literal ID="txtTitle" runat="server"></asp:Literal></h2>
                                <ul>
                                    <asp:Repeater ID="RepeaterListABCChild" runat="server" OnItemDataBound="RepeaterListABCChild_ItemDataBound">
                                        <ItemTemplate>
                                            <li><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="product_right">
                <div class="right1">
                    <h2>
                        <span><a href="">更多</a></span>商城公告</h2>
                    <div class="bd">
                        <dl>
                            <dt><a href="" class="red">雨天切记不要狠加速</a></dt>
                            <dd class="img">
                                <img src="/images/adv02.jpg" alt="图片" /></dd>
                            <dd class="dd">
                                <a href="">又到了天气变幻无常、暴雨时常光 [详细]</a></dd>
                        </dl>
                        <ul class="dashed-top">
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                            <li><a href="">十一黄金周成都车商服务优</a></li>
                            <li><a href="">惠一览 深入烧机油原因</a></li>
                            <li><a href="">分：燃油问题 节后迎汽车</a></li>
                            <li><a href="">保养高峰 保养提前预约更</a></li>
                            <li><a href="">省时 服务升级 长安铃木</a></li>
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                        </ul>
                    </div>
                </div>
                <div class="right1 mdT8">
                    <h2>
                        <span><a href="">更多</a></span>下载中心</h2>
                    <div class="bd">
                        <ul>
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                            <li><a href="">十一黄金周成都车商服务优</a></li>
                            <li><a href="">惠一览 深入烧机油原因</a></li>
                            <li><a href="">分：燃油问题 节后迎汽车</a></li>
                            <li><a href="">保养高峰 保养提前预约更</a></li>
                            <li><a href="">省时 服务升级 长安铃木</a></li>
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                        </ul>
                    </div>
                </div>
                <div class="right1 mdT8">
                    <h2>
                        <span><a href="">更多</a></span>技术支持</h2>
                    <div class="bd">
                        <ul>
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                            <li><a href="">十一黄金周成都车商服务优</a></li>
                            <li><a href="">惠一览 深入烧机油原因</a></li>
                            <li><a href="">分：燃油问题 节后迎汽车</a></li>
                            <li><a href="">保养高峰 保养提前预约更</a></li>
                            <li><a href="">省时 服务升级 长安铃木</a></li>
                            <li><a href="">秋季爱车防潮保护妙招</a></li>
                        </ul>
                    </div>
                </div>

                <div class="right1 mdT8">
                    <h2>
                        <span><a href="/Program/" target="_blank">更多</a></span>方案中心</h2>
                    <div class="bd">
                        <ul>
                            <asp:Repeater ID="rptProgram" runat="server" 
                                onitemdatabound="rptProgram_ItemDataBound">
                                <ItemTemplate>
                                <li><asp:HyperLink ID="lnkTitle" runat="server">Program title</asp:HyperLink></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>

            </div>
        </div>        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
