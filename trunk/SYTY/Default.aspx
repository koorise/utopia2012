<%@ Page Title="沈阳田园景观设计有限公司" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!-- main_promo -->
            <div class="main_promo" id="JS_promo">      
                <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
                <ul id="JS_triggers" class="triggers_num"> 
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </ul>       		
            </div>
                
            <div class="clearfix">
            
            	<!--index_news-->
                <div class="index_news">
                	<div class="hd clearfix"><h3>新闻中心</h3><span>News</span><a class="more" href="#">更多</a></div>
                    <ul class="index_new_list"> 
                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                    </ul>
                </div>
				
                <!--index_aboutus-->
                <div class="index_news index_aboutus clearfix">
                	<div class="hd clearfix"><h3>关于田园</h3><span>COMPANY</span></div>
                    <div class="pic"><a href="#"><img alt="" src="images/img_aboutus.jpg" /></a></div>
                    <div class="intro">田园景观设计公司主要从事风景区、居住区、别墅区、城市广场、主题公园、大型绿地等各种类型项目的景观规划设计工作。我们立志以开放的思维，将国、内外先进的设计历年与设计手法引入项目的创造之中，结合地域文化特色和生态环境特点，以求真求实的职业精神，奉献给社会以景观设计精品。田园景观——让您品位艺术生活…<a href="#">[查看详情]</a></div>
                </div>
                
                
                	                
            </div>
</asp:Content>

