<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master"  AutoEventWireup="true" CodeBehind="member_consignee_add.aspx.cs" Inherits="GK2010.Web.Member.MemberConsignee.member_consignee_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
            width:100px;
        }
        .style2
        {
            text-align: left;
            height:25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">首页 > 我的工控 > 常用收货人添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <h2>常用收货人添加</h2>
    <div class="bd_bd">
        <table cellpadding="0" cellspacing="0" class="wp95 m_center table3">
                    <tbody>   
                         <tr>
                    <td class="style1">
                        公司名称：
                    </td>
                    <td class="style2" width="*"><asp:TextBox id="txtCompany"  runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany"
                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="style1">
                        收货人姓名：
                    </td>
                    <td class="style2"><asp:TextBox id="txtRealName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRealName"
                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                </tr>
              <%--  <tr>
                    <td class="style1">
                        省份：
                    </td>
                    <td class="style2"></td>
                </tr>--%>
                <tr>
                    <td class="style1">
                        地址：
                    </td>
                    <td class="style2"><asp:TextBox id="txtAddress" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress"
                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="style1">
                        邮编：
                    </td>
                    <td class="style2"><asp:TextBox id="txtPostCode" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style1">
                        固定电话：
                    </td>
                    <td class="style2"><asp:TextBox id="txtTelephone" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style1">
                        手机号码：
                    </td>
                    <td class="style2"><asp:TextBox id="txtMobile" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style1">
                        电子邮件：
                    </td>
                    <td class="style2"><asp:TextBox id="txtEmail"  runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style1">
                        默认选项：
                    </td>
                    <td class="style2"><asp:CheckBox ID="chkDefaultFlag" runat="server" /></td>
                </tr>
              <tr>
                <td></td>
                <td class="style2"><asp:Button ID="btnPost" runat="server" Text="提交" 
                        class="btn_light_small" onclick="btnPost_Click" /></td>
              </tr>
            </table>
               </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>