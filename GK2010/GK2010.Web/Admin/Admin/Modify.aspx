<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.Admin.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">����Ա�༭</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >	
	<tr>
		<td class="td1">��ɫ��</td>
		<td class="td2">
			<asp:RadioButtonList ID="radGroupID" runat="server"></asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radGroupID" ErrorMessage="��ɫ��ѡ"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�û�����</td>
		<td class="td2">
			<asp:Label id="txtUserName" runat="server" ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	<tr>
		<td class="td1">��ʵ������</td>
		<td class="td2">
			<asp:TextBox id="txtRealName" runat="server" cssclass="input input_wa" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRealName" ErrorMessage="����"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�����ʼ���</td>
		<td class="td2">
			<asp:TextBox id="txtEmail" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�绰��</td>
		<td class="td2">
			<asp:TextBox id="txtTelephone" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1" style="height: 39px">�ֻ����룺</td>
		<td class="td2" style="height: 39px">
			<asp:TextBox id="txtMobile" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2" style="height: 39px"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��ַ��</td>
		<td class="td2">
			<asp:TextBox id="txtAddress" runat="server" cssclass="input input_wa" ></asp:TextBox>
		    
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�ʱࣺ</td>
		<td class="td2">
			<asp:TextBox id="txtPostCode" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��ǰ״̬��</td>
		<td class="td2">
			<asp:RadioButtonList ID="radLockFlag" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="0">����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>