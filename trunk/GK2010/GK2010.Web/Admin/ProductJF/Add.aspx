<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ProductJF.Add"  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">积分商品新增</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >	
	<tr>
		<td class="td1">商品名称：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
			<asp:CheckBox ID="chkIndexFlag" runat="server" Text="本期" />
			<asp:CheckBox ID="chkCommendFlag" runat="server" Text="推荐" />
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">所需积分：</td>
		<td class="td2">
			<asp:TextBox id="txtDefaultJF" runat="server" cssclass="input input_wa" Text="0" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr>
		<td class="td1">详细信息：</td>
		<td class="td2">
			<fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/" Height="400px" ToolbarSet="Default" Width="100%"></fckeditorv2:FCKeditor>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">图片：</td>
		<td class="td2">
			<asp:FileUpload ID="FileUpload1" runat="server" />
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
    <gk:AdminTag ID="AdminTag1" runat="server" />
    <gk:AdminSEO ID="AdminSEO1" runat="server" />
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
