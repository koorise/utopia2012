<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminUpload.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminUpload" %>
 <tr>
    <td class="td1">
        图片：
    </td>
    <td class="td2"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="input" />
        <asp:Literal ID="txtPicture" runat="server"></asp:Literal>
    </td>
    <td class="td2">
        <div class="help_a">
        </div>
    </td>
</tr>       