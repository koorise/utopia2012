<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.QaCategory.Modify" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">����������༭</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >

	<tr>
		<td class="td1">��Ŀ���ƣ�</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr style="display:none">
		<td class="td1">��Ŀƴ����</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr>
		<td class="td1">ѡ���ϼ���Ŀ��</td>
		<td class="td2">
            <asp:DropDownList ID="dropParentID" runat="server"></asp:DropDownList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr style="display:none">
		<td class="td1">Url��</td>
		<td class="td2">
			<asp:TextBox id="txtUrl" runat="server" cssclass="input input_wb" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	<tr>
		<td class="td1">����</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr style="display:none">
		<td class="td1">���ù��ܣ�</td>
		<td class="td2"><asp:CheckBox ID="chkIsDefault" runat="server" /></td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>