<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.ProductSpecial.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">编辑</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">促销商品（指定时间内有效）：</td>
		<td class="td2">
		<asp:label id="lblID" runat="server"></asp:label>
		</td>
		<td class="td2"></td>
	</tr>
	<tr>
		<td class="td1">产品编号：</td>
		<td class="td2">
			<asp:TextBox id="txtProductID" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">促销价格：</td>
		<td class="td2">
			<asp:TextBox id="txtPrice" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">开始时间：</td>
		<td class="td2">
			<asp:TextBox id="txtStartDate" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">结束时间：</td>
		<td class="td2">
			<asp:TextBox id="txtEndDate" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">排序：</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>