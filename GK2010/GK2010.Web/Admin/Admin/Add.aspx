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
                MsgOK: "��ϲ�������û�����ע��",
                MsgFailFlag: true,
                MsgFail: "�Բ��𣬴��û����ѱ�ע��",
                txtInput: $("#<%=txtUserName.ClientID %>"),
                txtInputMsg: $("#<%=txtUserName.ClientID %>Msg")
            });
            //username end

            //email start
            $('document').input({
                Type: "Email",               
                MinLength: 6,
                MsgOKFlag: true,
                MsgOK: "��ϲ�������������ע��",
                MsgFailFlag: true,
                MsgFail: "�Բ��𣬴������ѱ�ע��",
                txtInput: $("#<%=txtEmail.ClientID %>"),
                txtInputMsg: $("#<%=txtEmail.ClientID %>Msg")
            });
            //email end

            //Mobile start
            $('document').input({
            Type: "Mobile",
                MinLength: 11,
                MsgOKFlag: true,
                MsgOK: "��ϲ�������ֻ�����ע��",
                MsgFailFlag: true,
                MsgFail: "�Բ��𣬴��ֻ��ѱ�ע��",
                txtInput: $("#<%=txtMobile.ClientID %>"),
                txtInputMsg: $("#<%=txtMobile.ClientID %>Msg")
            });
            //email end   

            //post start
            $('document').post({
                btnPost: $("#<%=btnAdd.ClientID %>"),
                click: function(event) {
                    if (!$.UserNameChecked) {
                        alert("��¼�˺��Ѿ�����");
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

<h2 class="h1">����Ա����</h2>
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
			<asp:TextBox ID="txtUserName" runat="server" class="input input_wa" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="��¼�˺ű���"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" 
                            ErrorMessage="�ʺű��Ӧ��Ϊ6-20��Ӣ����ĸ�����֡��»���_��ɣ�����Ӣ����ĸ��ͷ" ValidationExpression="[a-zA-Z]\w{5,19}"></asp:RegularExpressionValidator>
                        <asp:Label ID="txtUserNameMsg" runat="server"></asp:Label>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�û����룺</td>
		<td class="td2">
			<asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" 
                            class="input input_wa" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="�����������"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="������6-20λ��ĸ���������" 
                            ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	
	
	<tr>
		<td class="td1">��ʵ������</td>
		<td class="td2">
			<asp:TextBox id="txtRealName" runat="server" cssclass="input input_wa" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRealName" ErrorMessage="����"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">�����ʼ���</td>
		<td class="td2">
			<asp:TextBox ID="txtEmail" runat="server" class="input input_wa"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="�����ʼ���ʽ����" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:Label ID="txtEmailMsg" runat="server"></asp:Label>
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
		<td class="td1">�ֻ����룺</td>
		<td class="td2">
		      <asp:TextBox ID="txtMobile" runat="server" class="input input_wa" MaxLength="11"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="�ֻ�����Ϊ11λ����" 
                            ValidationExpression="1\d{10}"></asp:RegularExpressionValidator><asp:Label ID="txtMobileMsg" runat="server"></asp:Label>
			
		</td>
		<td class="td2"><div class="help_a"></div></td>
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
			<asp:TextBox ID="txtPostCode" runat="server" class="input input_wa" MaxLength="6"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="�ʱ�Ϊ6λ����" 
                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
