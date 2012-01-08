<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="GK2010.Web.Admin.ProductMemberDiscount.ManageMember" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		�û�����������<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="����" />
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">��Ա��Ʒ�ۿ��趨</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:TemplateField HeaderText="�û���">
				<ItemTemplate><%# Eval("UserName") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="����">
				<ItemTemplate><%# Eval("RealName") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="VIP">
				<ItemTemplate><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("VIPFlag"), "[VIP��Ա]", "")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 			
			<asp:TemplateField HeaderText="����" >
				<ItemTemplate><asp:HyperLink ID="HyperLinkModify" runat="server">[����]</asp:HyperLink></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />
	</asp:GridView>
</div>
<div id="divPage" class="pages">
	<webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
</div>
</asp:Content>