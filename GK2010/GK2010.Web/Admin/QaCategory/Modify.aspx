<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.QaCategory.Modify" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">解答中心类别编辑</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >

	<tr>
		<td class="td1">栏目名称：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr style="display:none">
		<td class="td1">栏目拼音：</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr>
		<td class="td1">选择上级栏目：</td>
		<td class="td2">
            <asp:DropDownList ID="dropParentID" runat="server"></asp:DropDownList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr style="display:none">
		<td class="td1">Url：</td>
		<td class="td2">
			<asp:TextBox id="txtUrl" runat="server" cssclass="input input_wb" ></asp:TextBox>
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
	<tr style="display:none">
		<td class="td1">常用功能：</td>
		<td class="td2"><asp:CheckBox ID="chkIsDefault" runat="server" /></td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>