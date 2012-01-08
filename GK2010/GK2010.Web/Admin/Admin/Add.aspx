<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.Admin.Add"  ValidateRequest="false" EnableEventValidation="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/JavaScript/jquery.post.js" type="text/javascript"></script>
<script type="text/javascript">
        $("document").ready(function() {
           
            
            //username start
            $('document').input({
                Type: "UserName",
                MinLength: 6,
                MsgOKFlag: true,
                MsgOK: "恭喜您，此用户可以注册",
                MsgFailFlag: true,
                MsgFail: "对不起，此用户名已被注册",
                txtInput: $("#<%=txtUserName.ClientID %>"),
                txtInputMsg: $("#<%=txtUserName.ClientID %>Msg")
            });
            //username end

            //email start
            $('document').input({
                Type: "Email",               
                MinLength: 6,
                MsgOKFlag: true,
                MsgOK: "恭喜您，此邮箱可以注册",
                MsgFailFlag: true,
                MsgFail: "对不起，此邮箱已被注册",
                txtInput: $("#<%=txtEmail.ClientID %>"),
                txtInputMsg: $("#<%=txtEmail.ClientID %>Msg")
            });
            //email end

            //Mobile start
            $('document').input({
            Type: "Mobile",
                MinLength: 11,
                MsgOKFlag: true,
                MsgOK: "恭喜您，此手机可以注册",
                MsgFailFlag: true,
                MsgFail: "对不起，此手机已被注册",
                txtInput: $("#<%=txtMobile.ClientID %>"),
                txtInputMsg: $("#<%=txtMobile.ClientID %>Msg")
            });
            //email end   

            //post start
            $('document').post({
                btnPost: $("#<%=btnAdd.ClientID %>"),
                click: function(event) {
                    if (!$.UserNameChecked) {
                        alert("登录账号已经存在");
                        return false;
                    }
                    
                   
                    return true;
                }
            });
            //post end        
        })   
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">管理员新增</h2>
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
			<asp:TextBox ID="txtUserName" runat="server" class="input input_wa" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="登录账号必填"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" 
                            ErrorMessage="帐号必填！应该为6-20个英文字母、数字、下划线_组成，请以英文字母开头" ValidationExpression="[a-zA-Z]\w{5,19}"></asp:RegularExpressionValidator>
                        <asp:Label ID="txtUserNameMsg" runat="server"></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">用户密码：</td>
		<td class="td2">
			<asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" 
                            class="input input_wa" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="您的密码必填"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="密码由6-20位字母和数字组成" 
                            ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	
	<tr>
		<td class="td1">真实姓名：</td>
		<td class="td2">
			<asp:TextBox id="txtRealName" runat="server" cssclass="input input_wa" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRealName" ErrorMessage="必填"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">电子邮件：</td>
		<td class="td2">
			<asp:TextBox ID="txtEmail" runat="server" class="input input_wa"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="电子邮件格式不对" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:Label ID="txtEmailMsg" runat="server"></asp:Label>
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
		<td class="td1">手机号码：</td>
		<td class="td2">
		      <asp:TextBox ID="txtMobile" runat="server" class="input input_wa" MaxLength="11"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="手机号码为11位数字" 
                            ValidationExpression="1\d{10}"></asp:RegularExpressionValidator><asp:Label ID="txtMobileMsg" runat="server"></asp:Label>
			
		</td>
		<td class="td2"><div class="help_a"></div></td>
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
			<asp:TextBox ID="txtPostCode" runat="server" class="input input_wa" MaxLength="6"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="邮编为6位数字" 
                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
