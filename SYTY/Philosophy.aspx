<%@ Page Title="田园理念" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Philosophy.aspx.cs" Inherits="Philosophy" %>
<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:Left ID="Left1" runat="server" />
            <div class="team_display">
				<div class="hd clearfix">
					<h3 class="h3">
                        田园理念</h3>
					<%--<div class="crumb"><a href="Default.aspx">首页</a>&gt;&gt;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></div>--%>
				 </div>
				 
                     <asp:Literal ID="Literal1" runat="server"></asp:Literal>  
			</div>
</asp:Content>

