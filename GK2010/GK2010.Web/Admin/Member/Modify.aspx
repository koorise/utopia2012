<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.Member.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">��Ա�༭</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr style="display:none">
		<td class="td1">��Ա��ţ�</td>
		<td class="td2">
		<asp:label id="lblID" runat="server"></asp:label>
		</td>
		<td class="td2"></td>
	</tr>
	<tr>
		<td class="td1">�û�����</td>
		<td class="td2">
			<asp:label id="txtUserName" runat="server" ></asp:label>&nbsp;&nbsp;����������<asp:label id="txtTotalOrder" runat="server" ></asp:label>&nbsp;&nbsp;���֣�<asp:label id="txtTotalJF" runat="server"  ></asp:label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��ʵ������</td>
		<td class="td2">
			<asp:label id="txtRealName" runat="server" ></asp:label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">���ڳ��У�</td>
		<td class="td2">
			<asp:label id="txtProvinceID" runat="server"  ></asp:label>
			<asp:label id="txtCityID" runat="server"  ></asp:label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��˾���ƣ�</td>
		<td class="td2">
			<asp:label id="txtCompany" runat="server" ></asp:label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�����ʼ���</td>
		<td class="td2">
			<asp:Label id="txtEmail" runat="server" ></asp:Label>&nbsp;<asp:Label id="txtEmailFlag" runat="server"  ForeColor="Red" ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�ֻ����룺</td>
		<td class="td2">
			<asp:Label id="txtMobile" runat="server" ></asp:Label>&nbsp;<asp:Label id="txtMobileFlag" runat="server"  ForeColor="Red"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">VIP��Ա��</td>
		<td class="td2">
			<asp:RadioButtonList ID="radVIPFlag" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="1">VIP��Ա</asp:ListItem>
                <asp:ListItem Value="0">��VIP��Ա</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2">&nbsp;</td>
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
	<gk:adminmember ID="AdminMember1" runat="server" />
	
	
	<tr>
		<td class="td1">�绰��</td>
		<td class="td2">
			<asp:Label id="txtTelephone" runat="server"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">��ַ��</td>
		<td class="td2">
			<asp:Label id="txtAddress" runat="server"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�ʱࣺ</td>
		<td class="td2">
			<asp:Label id="txtPostCode" runat="server"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">ע��ʱ�䣺</td>
		<td class="td2">
			<asp:Label id="txtRegisterDate" runat="server" ></asp:Label>
		    IP��<asp:Label id="txtRegisterIP" runat="server"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�����¼��</td>
		<td class="td2">
			<asp:Label id="txtLastDate" runat="server"  ></asp:Label>
		    &nbsp;<asp:Label id="txtLastIP" runat="server"  ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	
	
</table>
</div>
<div class="tac mb10">
<gk:AdminGoBack ID="AdminGoBack1" runat="server" />
<asp:Button ID="btnUpdate" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>