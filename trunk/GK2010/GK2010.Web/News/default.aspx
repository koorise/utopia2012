<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.News._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <link href="/css/page.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
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
          <div class="banner"> 
              <div class="tabs1">
                   <ul>                
                   <asp:Repeater ID="Repeater1" runat="server" 
                            onitemdatabound="Repeater1_ItemDataBound">
                        <ItemTemplate>
       <li><span><asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink></span></li>
                        </ItemTemplate>
                        </asp:Repeater>
                   </ul>       
              </div>
             </div>
          <div class="base_infor ">
               <div class="news_intro">
               <span class="top_bg"></span>
                <span class="middle_bg"><p><b>&nbsp;&nbsp;&nbsp; 欢迎</b>来到工控商城中国新闻中心，在这里您可以第一时间了解到工控商城的最新<b>公司动态</b></p></span>
                <span class="bottom_bg"></span>
                </div>
               
              <div class="news_content_list flow_l ">
               <h4 class="lan_title">>>&nbsp; 文章列表</h4>       
                <div class="bd ul_square_time flow_l">
                      <ul>
                      <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                            <ItemTemplate> <table><tr style="background-color:#F4F7FB;"><td><asp:Literal ID="txtContent" runat="server"></asp:Literal></td></tr></table></ItemTemplate>
                               <AlternatingItemTemplate><table><tr><td><asp:Literal ID="txtContent" runat="server"></asp:Literal></td></tr></table> </AlternatingItemTemplate>
                          </asp:Repeater>
                    </ul>        
                </div>             
                <div class="pages mdB10 mdL20" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                        onpagechanged="AspNetPager1_PageChanged"  ></webdiyer:AspNetPager>
                    
                </div>
            </div>
  
         </div> 
       </div>
    </div>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
