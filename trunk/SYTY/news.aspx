<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>

<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:Left ID="Left1" runat="server" />
            <div class="team_display">
				<div class="hd clearfix">
					<h3 class="h3">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h3>
					<div class="crumb"><a href="default.aspx">首页</a>&gt;&gt;<asp:Label ID="Label3"
                            runat="server" Text="Label"></asp:Label> </div>
				 </div>
				 <div class="news">
				 	<h4 class="title">
                         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
					<p class="date">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
                     <asp:Literal ID="Literal1" runat="server"></asp:Literal>
				</div>
						  
			</div>
</asp:Content>

