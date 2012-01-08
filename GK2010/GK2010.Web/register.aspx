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

            //checkcode start
            $('document').input({
                Type: "Code",
                MinLength: 1,
                MsgOKFlag: true,
                MsgOK: "验证码正确",
                MsgFailFlag: true,
                MsgFail: "验证码错误",
                txtInput: $("#<%=txtCheckCode.ClientID %>"),
                txtInputMsg: $("#<%=txtCheckCode.ClientID %>Msg")
            });
            //checkcode end   

            //post start
            $('document').post({
                btnPost: $("#<%=btnPost.ClientID %>"),
                click: function(event) {
                    if (!$.UserNameChecked) {
                        alert("登录账号已经存在");
                        return false;
                    }
                    if (!$.EmailChecked) {
                        alert("邮箱已经存在");
                        return false;
                    }
                    if (!$.CodeChecked) {
                        alert("验证码不正确");
                        return false;
                    }
                    return true;
                }
            });
            //post end        
        })   
    </script>
     <title>用户注册 - <%=GK2010.Common.ConfigHelper.Config.WebName%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="message">首页 > 用户注册</div>
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
                            填写注册信息
                        </td>
                        <td>
                            <img src="/images/tubiao02.jpg" width="16" height="16" />
                        </td>
                        <td>
                            查看激活邮件
                        </td>
                        <td>
                            <img src="/images/tubiao03.jpg" width="16" height="16" />
                        </td>
                        <td>
                            注册成功
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
                基本信息（以下带*的为必填内容!）</h2>
            <table border="0" cellspacing="0" cellpadding="0" class="wp90 m_center table2">
                <tr>
                    <td class="td1">
                        <em>* </em>登录账号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="登录账号必填"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic" cssclass="valierror"
                            ErrorMessage="帐号必填！应该为6-20个英文字母、数字、下划线_组成，请以英文字母开头" ValidationExpression="[a-zA-Z]\w{5,19}"></asp:RegularExpressionValidator>
                        <asp:Label ID="txtUserNameMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        <em>* </em>您的密码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" 
                            class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="您的密码必填"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwd" Display="Dynamic" ErrorMessage="密码由6-20位字母和数字组成" 
                            ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        <em>* </em><span class="td1">确认密码：</span>
                    </td>
                    <td>
                       <asp:TextBox ID="txtUserPwdConfirm" runat="server" TextMode="Password" 
                            class="input w200" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  cssclass="valierror"
                            ControlToValidate="txtUserPwdConfirm" Display="Dynamic" ErrorMessage="确认密码必填"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" cssclass="valierror"
                            ControlToCompare="txtUserPwd" ControlToValidate="txtUserPwdConfirm" 
                            Display="Dynamic" ErrorMessage="两次密码不同"></asp:CompareValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                
                <tr>
                    <td class="td1">
                        <em>* </em>电子邮件：
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" class="input w200"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" cssclass="valierror"
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="电子邮件必填"></asp:RequiredFieldValidator><asp:RegularExpressionValidator cssclass="valierror" ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="电子邮件格式不对" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:Label ID="txtEmailMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1" align="right">
                        <em>* </em><span class="td1">验&nbsp;证&nbsp;码：</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCheckCode" runat="server" class="input w100" MaxLength="4"></asp:TextBox><gk:CheckCode ID="CheckCode1" runat="server" />                      
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" cssclass="valierror"
                            ControlToValidate="txtCheckCode" Display="Dynamic" ErrorMessage="验证码必填"></asp:RequiredFieldValidator>
                        <asp:Label ID="txtCheckCodeMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <h2>
                高级选项（打折优惠请认真填写）</h2>
            <table border="0" cellspacing="0" cellpadding="0" class="wp90 m_center table2">
                <tr>
                    <td class="td1">
                        公司名称<span class="hong12"></span>：
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
                        真实姓名：
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
                        常用手机：
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" class="input w200" MaxLength="11"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="手机号码为11位数字" cssclass="valierror"
                            ValidationExpression="1\d{10}"></asp:RegularExpressionValidator><asp:Label ID="txtMobileMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="td1">
                        固定电话：
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
                        公司传真：
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
                        <span class="td1">所在城市：</span>
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
                        公司地址：
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
                        邮政编码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostCode" runat="server" class="input w200" MaxLength="6"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" cssclass="valierror"
                            ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="邮编为6位数字" 
                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <h2>
            <strong>用户协议（ 请阅读用户协议及其中的相关条件和条款）</strong></h2>
            <table class="wp90 m_center table2" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td class="td1">
                            &nbsp;
                        </td>
                        <td class="field"><a href="/register_protocal.aspx" target="_blank">查看注册协议</a>                           
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td class="td1">
                        </td>
                        <td><asp:Button ID="btnPost" runat="server" Text="同意协议，并注册！"  style="height:40px" class="btn_org_big2 B" onclick="btnPost_Click" /></td>
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
