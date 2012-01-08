<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage_Index.aspx.cs" Inherits="GK2010.Web.Admin.ProductJF.Manage_Index" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		商品名称：<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="搜索" />
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">本期积分商品列表</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="商品编号" ReadOnly="True" >
				<ItemStyle cssclass="td2" Width="80" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="图片">
				<ItemTemplate><img src='<%# Eval("PictureNormal") %>' width='20' height='15'></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate><%# Eval("Title") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="所需积分">
				<ItemTemplate><%# Eval("DefaultJF")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="排序">
				<ItemTemplate>
                    <asp:TextBox ID="txtSortID" runat="server" Text='<%# Eval("IndexSortID")%>' cssclass="input input_wa"></asp:TextBox></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="操作" >
				<ItemTemplate><asp:HyperLink ID="HyperLinkModify" runat="server">[修改]</asp:HyperLink></ItemTemplate>
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
<div id="divOperator" class="tac mb10">
	<asp:Button ID="btnSave" runat="server" cssclass="btn_yellow_small" Text="保存" CausesValidation="false" OnClick="btnSave_Click" />
</div>
</asp:Content>