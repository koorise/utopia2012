<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ConfigNavigator.Add"  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">��վ��������</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	
	<tr>
		<td class="td1">���ƣ�</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="����"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">ƴ����</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��ʾ��</td>
		<td class="td2">
            <asp:CheckBox ID="chkIndexFlag" runat="server" Text="ѡ�д�����ʾ" />
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	<tr>
		<td class="td1">���ӵ�ַ��</td>
		<td class="td2">
			<asp:TextBox id="txtUrl" runat="server" cssclass="input input_wa" Width="400px" Text="" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">����</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><gk:AdminGoBack ID="AdminGoBack1" runat="server" /><asp:Button ID="btnAdd" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
