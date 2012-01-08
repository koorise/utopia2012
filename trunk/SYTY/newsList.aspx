<%@ Page Title="新闻-沈阳田园景观设计有限公司" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newsList.aspx.cs" Inherits="newsList" %>
<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:Left ID="Left1" runat="server" />
            <div class="team_display">
				<div class="hd clearfix">
					<h3 class="h3">
                        新闻中心</h3>
					<%--<div class="crumb"><a href="Default.aspx">首页</a>&gt;&gt;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></div>--%>
				 </div>
				 
                     <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
				  
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
			</div>
</asp:Content>

