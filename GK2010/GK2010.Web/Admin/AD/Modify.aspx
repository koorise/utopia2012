<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.AD.Modify" Title=""
    ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JavaScript/jquery.post.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <h2 class="h1">
        ������ı༭</h2>
    <div class="admin_table mb10">
               <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="td1">
                    ���
                </td>
                <td class="td2">
                    <asp:DropDownList ID="dropCategory" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dropCategory"
                        InitialValue="0" Display="Dynamic" ErrorMessage="����"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    �����⣺
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="����"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    ��汸ע��
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="input input_wa" Width="311px" Height="80" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
             <tr >
                <td class="td1">
                    ����Url��
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
		        <td class="td1">����</td>
		        <td class="td2">
			        <asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		        </td>
		        <td class="td2"><div class="help_a"></div></td>
	        </tr>
            <gk:AdminUpload ID="AdminUpload1" runat="server" />           
        </table>
    </div>
    <div class="tac mb10">
        <gk:AdminGoBack ID="AdminGoBack1" runat="server" />
        <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="btn_yellow_big" OnClick="btnAdd_Click">
        </asp:Button>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
