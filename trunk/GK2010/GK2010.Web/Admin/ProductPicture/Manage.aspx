<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.ProductPicture.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1"><span class="mr10 fl mb10">上传文件
    <asp:FileUpload ID="FileUpload1" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必选" Display="Dynamic" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator><asp:Button ID="btn_upload" runat="server" CssClass="btn_yellow_small" OnClick="btn_upload_Click" Text="上传" />（330px*330px,jpg或gif图片，最多上传5张）
</span></h2>
<div style="height:10px; overflow:hidden"></div>
<div class="admin_table mb10">
<table cellspacing="0" cellpadding="0" width="100%">
 <tr class="vt tr1">
 <td>
    <asp:Repeater id="RepeaterList" Runat="server">
        <ItemTemplate>        
            <table style="float:left; width:140px; height:130px;">
                <tr>
                    <td align="center" valign="middle"><img src="<%#Eval("PictureSmall") %>" width="100" height="100" style="border:1px solid #cccccc; padding:2px" /></td>
                </tr>
                <tr>    
                    <td align="center" height="30px">
                    排序：<input type="text" runat="server" id="txtSortID" class="input input_wd mr5" value='<%#Eval("SortID") %>' /><a href="delete.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>">删</a>
                    <input type="hidden" runat="server" id="txtID" value='<%#Eval("ID") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>							
    </asp:Repeater> 
    </td>
    </tr>  
</table>
</div>
<div id="divOperator" class="tac mb10">	
	<asp:Button ID="btnSave" runat="server" cssclass="btn_yellow_small" Text="保存" CausesValidation="false" OnClick="btnSave_Click" />
</div>
</asp:Content>