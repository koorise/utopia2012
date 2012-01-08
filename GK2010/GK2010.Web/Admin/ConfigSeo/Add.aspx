<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ConfigSeo.Add"  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">SEO新增</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">标题：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">暂无备注</div></td>
	</tr>
	<tr>
		<td class="td1">拼音：</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">暂无备注</div></td>
	</tr>
	<tr>
		<td class="td1">SeoTitle：</td>
		<td class="td2">
			<asp:TextBox id="txtSeoTitle" runat="server" cssclass="input " TextMode="MultiLine" style="width:400px; height:50px" ></asp:TextBox>
		</td>
		<td class="td2">
		    $DetailTitle$ 详细页标题<br />
            $CategoryTitle$ 类别标题<br />
            $Tags$ 标签<br />
            $WebSiteTitle$ 网站名称<br />
            $SEOTitle$ 原始表中的SEOTitle<br />
            $SEOKeywords$  原始表中的SEOKeywords<br />
            $SEODescription$  原始表中的SEODescription<br />
		</td>
	</tr>
	<tr>
		<td class="td1">SeoKeywords：</td>
		<td class="td2">
			<asp:TextBox id="txtSeoKeywords" runat="server" cssclass="input "   TextMode="MultiLine" style="width:400px; height:50px"></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">同上</div></td>
	</tr>
	<tr>
		<td class="td1">SeoDescription：</td>
		<td class="td2">
			<asp:TextBox id="txtSeoDescription" runat="server" cssclass="input "  TextMode="MultiLine" style="width:400px; height:50px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">同上</div></td>
	</tr>
	<tr>
		<td class="td1">排序：</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">暂无备注</div></td>
	</tr>
	
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
