<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="NewsTrade.aspx.cs" Inherits="GK2010.Web.News.NewsTrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <title>行业新闻</title>
<%--    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">  
    <gk:Navigator ID="Navigator1" runat="server" />  
 
    <div class="main">
        <div class="left mar5 ">
            <!--product left start-->
            <gk:ProductLeft ID="ProductLeft1" runat="server" />
            <!--product left end-->
        </div>
        <!-- right start -->
        <div class="right_cont ">
            <div> 
<%--                <asp:DataList ID="DataList1" runat="server" RepeatColumns="10">
                    <ItemTemplate>
                    <ul class="news_title"><li><a href=""><span>
                        <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink></a></li></ul>
                    </ItemTemplate>
                </asp:DataList> --%>
<%--
               <ul class="news_title">
             <li><a href=""><span>公司动态</span></a></li>
            <li><a href=""><span>行业新闻</span></a></li>
            <li><a href=""><span>人才招聘</span></a></li> 
            <li><a href=""><span>供应商进入</span></a></li></ul>--%></div>
            <asp:Repeater ID="Repeater1" runat="server" 
                onitemdatabound="Repeater1_ItemDataBound">
            <ItemTemplate>
            <ul class="news_title">
             <li><a href=""><span>
                 <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink></span></a></li>
            </ItemTemplate>
            </asp:Repeater>
            <div class="base_infor ">
                <!--product list start-->
                <!--product list end-->
                <div class="product_list">
                <span class=top_bg></span>
                <p><b>欢迎来到工控商城中国新闻中心，在这里您可以第一时间了解到工控商城最新动态</b></p> 
 
                <h4 class=lan_title>文章列表</H4>
                     <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                            <ItemTemplate>
                            <table style=" width:100%">
                               <tr style="background-color:#89c0fa;">

                          <td style="font-size:14px; float:left">
                            <asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"></asp:HyperLink></td><td align="right"; style="font-size:14px;"><asp:Literal ID="txtdate" runat="server"></asp:Literal>
                            </td>
                            </tr>
                            </table>
                             </ItemTemplate>
                   <AlternatingItemTemplate><!--注意此处,为交替项,实现了各行换色-->
           <table style=" width:100%">
                            <tr class='<%#(Container.ItemIndex%2==0)?"Red":"bule"%>'>

                            <td style="font-size:14px; float:left">
                            <asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"></asp:HyperLink></td><td align="right"; style="font-size:14px;"><asp:Literal ID="txtdate" runat="server"></asp:Literal>
                            </td>
                            </tr>
                            </table>
         </AlternatingItemTemplate>


                       </asp:Repeater>
                          
                </div>
                <div class="clear"></div>                 
                <div class="pages pdL10" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
                    
                </div>
            </div>
    <%--    </div>--%>
        <!-- right end -->
    </div> 
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>

