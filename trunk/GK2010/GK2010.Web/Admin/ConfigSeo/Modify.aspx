<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.ConfigSeo.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">SEO�༭</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">SEO��</td>
		<td class="td2">
		<asp:label id="lblID" runat="server"></asp:label>
		</td>
		<td class="td2"></td>
	</tr>
	<tr>
		<td class="td1">���⣺</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">���ޱ�ע</div></td>
	</tr>
	<tr>
		<td class="td1">ƴ����</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">���ޱ�ע</div></td>
	</tr>
	<tr>
		<td class="td1">SeoTitle��</td>
		<td class="td2">
			<asp:TextBox id="txtSeoTitle" runat="server" cssclass="input " TextMode="MultiLine" style="width:400px; height:50px" ></asp:TextBox>
		</td>
		<td class="td2">
		    $DetailTitle$ ��ϸҳ����<br />
            $CategoryTitle$ ������<br />
            $Tags$ ��ǩ<br />
            $WebSiteTitle$ ��վ����<br />
            $SEOTitle$ ԭʼ���е�SEOTitle<br />
            $SEOKeywords$  ԭʼ���е�SEOKeywords<br />
            $SEODescription$  ԭʼ���е�SEODescription<br />
		</td>
	</tr>
	<tr>
		<td class="td1">SeoKeywords��</td>
		<td class="td2">
			<asp:TextBox id="txtSeoKeywords" runat="server" cssclass="input "   TextMode="MultiLine" style="width:400px; height:50px"></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">���ޱ�ע</div></td>
	</tr>
	<tr>
		<td class="td1">SeoDescription��</td>
		<td class="td2">
			<asp:TextBox id="txtSeoDescription" runat="server" cssclass="input "  TextMode="MultiLine" style="width:400px; height:50px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">���ޱ�ע</div></td>
	</tr>
	<tr>
		<td class="td1">����</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a">���ޱ�ע</div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>