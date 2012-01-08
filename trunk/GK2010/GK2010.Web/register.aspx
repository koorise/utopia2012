<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GK2010.Web.register" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/JavaScript/jquery.post.js" type="text/javascript"></script>
    <script type="text/javascript" src="/javascript/jquery.province_city.js"></script>   
    <link href="/css/login/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $("document").ready(function() {
            //city start
            $('document').province_city({
                defaultCity:false,
                defaultCityID:"",
                dropProvince: $("#<%=dropProvince.ClientID %>"),
                dropCity: $("#<%=dropCity.ClientID %>")
            });
            //city start
            
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

            //checkcode start
            $('document').input({
                Type: "Code",
                MinLength: 1,
                MsgOKFlag: true,
                MsgOK: "��֤����ȷ",
                MsgFailFlag: true,
                MsgFail: "��֤�����",
                txtInput: $("#<%=txtCheckCode.ClientID %>"),
                txtInputMsg: $("#<%=txtCheckCode.ClientID %>Msg")
            });
            //checkcode end   

            //post start
            $('document').post({
                btnPost: $("#<%=btnPost.ClientID %>"),
                click: function(event) {
                    if (!$.UserNameChecked) {
                        alert("��¼�˺��Ѿ�����");
                        return false;
                    }
                    if (!$.EmailChecked) {
                        alert("�����Ѿ�����");
                        return false;
                    }
                    if (!$.CodeChecked) {
                        alert("��֤�벻��ȷ");
                        return false;
                    }
                    return true;
                }
            });
            //post end        
        })   
    </script>
     <title>�û�ע�� - <%=GK2010.Common.ConfigHelper.Config.WebName%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="message">��ҳ > �û�ע��</div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mdT8">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table cellspacing="0" cellpadding="0" class="w350 flow_r">
                    <tr>
                        <td>
                            <img src="/images/tubiao01.jpg" width="16" height="16" />
                        </td>
                        <td>
                            ��дע����Ϣ
                        </td>
                        <td>
                            <img src="/images/tubiao02.jpg" width="16" height="16" />
                        </td>
                        <td>
                            �鿴�����ʼ�
                        </td>
                        <td>
                            <img src="/images/tubiao03.jpg" width="16" height="16" />
                        </td>
                        <td>
                            ע��ɹ�
                        </td>
                    </tr>
                </table>
            </td>
            <td class="text_r">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="plan mdT8">
        <div class="hd">
            <div class="hd_top">
            </div>
        </div>
        <div class="bd1">
            <h2>
                ������Ϣ�����´�*��Ϊ��������!��</h2>
            <table border="0" cellspacing="0" cellpadding="0" class="wp90 m_center table2">
                <tr>
                    <td class="td1">
                        <em>* </em>��¼�˺ţ�
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="��¼�˺ű���"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" cssclass="valierror"
                            ErrorMessage="�ʺű��Ӧ��Ϊ6-20��Ӣ����ĸ�����֡��»���_��ɣ�����Ӣ����ĸ��ͷ" ValidationExpression="[a-zA-Z]\w{5,19}"></asp:RegularExpressionValidator>
                        <asp:Label ID="txtUserNameMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        <em>* </em>�������룺
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" 
                            class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="�����������"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="������6-20λ��ĸ���������" 
                            ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        <em>* </em><span class="td1">ȷ�����룺</span>
                    </td>
                    <td>
                       <asp:TextBox ID="txtUserPwdConfirm" runat="server" TextMode="Password" 
                            class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwdConfirm" Display="Dynamic" ErrorMessage="ȷ���������"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" cssclass="valierror"
                            ControlToCompare="txtUserPwd" ControlToValidate="txtUserPwdConfirm" 
                            Display="Dynamic" ErrorMessage="�������벻ͬ"></asp:CompareValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                
                <tr>
                    <td class="td1">
                        <em>* </em>�����ʼ���
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" class="input w200"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" cssclass="valierror"
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="�����ʼ�����"></asp:RequiredFieldValidator><asp:RegularExpressionValidator cssclass="valierror" ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="�����ʼ���ʽ����" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:Label ID="txtEmailMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1" align="right">
                        <em>* </em><span class="td1">��&nbsp;֤&nbsp;�룺</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCheckCode" runat="server" class="input w100" MaxLength="4"></asp:TextBox><gk:CheckCode ID="CheckCode1" runat="server" />                      
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" cssclass="valierror"
                            ControlToValidate="txtCheckCode" Display="Dynamic" ErrorMessage="��֤�����"></asp:RequiredFieldValidator>
                        <asp:Label ID="txtCheckCodeMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <h2>
                �߼�ѡ������Ż���������д��</h2>
            <table border="0" cellspacing="0" cellpadding="0" class="wp90 m_center table2">
                <tr>
                    <td class="td1">
                        ��˾����<span class="hong12"></span>��
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server" class="input w200" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        ��ʵ������
                    </td>
                    <td>
                         <asp:TextBox ID="txtRealName" runat="server" class="input w200" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        �����ֻ���
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" class="input w200" MaxLength="11"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="�ֻ�����Ϊ11λ����" cssclass="valierror"
                            ValidationExpression="1\d{10}"></asp:RegularExpressionValidator><asp:Label ID="txtMobileMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        �̶��绰��
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelephone" runat="server" class="input w200"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        ��˾���棺
                    </td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" class="input w200"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                 <tr>
                    <td class="td1">
                        <span class="td1">���ڳ��У�</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropProvince" runat="server" Width="60"></asp:DropDownList>
                        <asp:DropDownList ID="dropCity" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        ��˾��ַ��
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" class="input w200"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        �������룺
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostCode" runat="server" class="input w200" MaxLength="6"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" cssclass="valierror"
                            ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="�ʱ�Ϊ6λ����" 
                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <h2>
            <strong>�û�Э�飨 ���Ķ��û�Э�鼰���е�������������</strong></h2>
            <table class="wp90 m_center table2" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td class="td1">
                            &nbsp;
                        </td>
                        <td class="field"><a href="/register_protocal.aspx" target="_blank">�鿴ע��Э��</a>                           
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td class="td1">
                        </td>
                        <td><asp:Button ID="btnPost" runat="server" Text="ͬ��Э�飬��ע�ᣡ"  style="height:40px" class="btn_org_big2 B" onclick="btnPost_Click" /></td>
                    </tr>
                    <tr>
                        <td class="td1">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="ft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
