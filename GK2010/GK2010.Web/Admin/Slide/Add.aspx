<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.Slide.Add" ValidateRequest="false"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JavaScript/jquery.post.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <h2 class="h1">
        幻灯片新增</h2>
    <div class="admin_table mb10">
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="td1">
                    类别：
                </td>
                <td class="td2">
                    <asp:DropDownList ID="dropCategory" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dropCategory"
                        InitialValue="0" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    标题：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
             <tr >
                <td class="td1">
                    链接Url：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr style="display:none">
                <td class="td1">
                    摘要：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="input input_wa" Width="311px" Height="80" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <gk:AdminParam ID="AdminParam1" runat="server"  Visible="false" />
             <tr style="display:none">
                <td class="td1">
                    详细：
                </td>
                <td class="td2">
                    <fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/"
                        Height="400px" ToolbarSet="Default" Width="100%">
                    </fckeditorv2:FCKeditor>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
		        <td class="td1">排序：</td>
		        <td class="td2">
			        <asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		        </td>
		        <td class="td2"><div class="help_a"></div></td>
	        </tr>
            <gk:AdminUpload ID="AdminUpload1" runat="server" />
            <gk:AdminTag ID="AdminTag1" runat="server" Visible="false" />
            <gk:AdminSEO ID="AdminSEO1" runat="server" Visible="false" />
        </table>
    </div>
    <div class="tac mb10">
        <gk:AdminGoBack ID="AdminGoBack1" runat="server" />
        <asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click">
        </asp:Button>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
