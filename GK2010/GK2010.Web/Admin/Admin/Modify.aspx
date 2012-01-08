<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.Admin.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">管理员编辑</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >	
	<tr>
		<td class="td1">角色：</td>
		<td class="td2">
			<asp:RadioButtonList ID="radGroupID" runat="server"></asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radGroupID" ErrorMessage="角色必选"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">用户名：</td>
		<td class="td2">
			<asp:Label id="txtUserName" runat="server" ></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	<tr>
		<td class="td1">真实姓名：</td>
		<td class="td2">
			<asp:TextBox id="txtRealName" runat="server" cssclass="input input_wa" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRealName" ErrorMessage="必填"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">电子邮件：</td>
		<td class="td2">
			<asp:TextBox id="txtEmail" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">电话：</td>
		<td class="td2">
			<asp:TextBox id="txtTelephone" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1" style="height: 39px">手机号码：</td>
		<td class="td2" style="height: 39px">
			<asp:TextBox id="txtMobile" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2" style="height: 39px"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">地址：</td>
		<td class="td2">
			<asp:TextBox id="txtAddress" runat="server" cssclass="input input_wa" ></asp:TextBox>
		    
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">邮编：</td>
		<td class="td2">
			<asp:TextBox id="txtPostCode" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">当前状态：</td>
		<td class="td2">
			<asp:RadioButtonList ID="radLockFlag" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="0">正常</asp:ListItem>
                <asp:ListItem Value="1">锁定</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>