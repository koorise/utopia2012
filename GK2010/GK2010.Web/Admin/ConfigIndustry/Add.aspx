<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ConfigIndustry.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1">应用行业新增</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">父类别：</td>
		<td class="td2"><asp:Literal ID="txtParentID" runat="server"></asp:Literal></td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">栏目名称：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr>
		<td class="td1">栏目拼音：</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr>
		<td class="td1">排序：</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<gk:AdminUpload ID="AdminUpload1" runat="server" />
	<gk:AdminSEO ID="AdminSEO1" runat="server" />
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
