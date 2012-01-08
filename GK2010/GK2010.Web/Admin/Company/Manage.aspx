<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.Company.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		关键字：<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="搜索" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="添加" />   
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">关于我们管理列表</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:TemplateField HeaderText="">
				<HeaderTemplate><input type="checkbox" id="chkSelectAll"></HeaderTemplate>
				<ItemTemplate><asp:CheckBox ID="chkID" runat="server" /></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
			<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" >
				<ItemStyle cssclass="td2" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="名称">
				<ItemTemplate><%# Eval("Title") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="转向地址">
				<ItemTemplate><%# Eval("Url") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="排序">
				<ItemTemplate><%# Eval("SortID") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="操作" >
				<ItemTemplate><asp:HyperLink ID="HyperLinkModify" runat="server">[修改]</asp:HyperLink><asp:HyperLink ID="HyperLinkDelete" runat="server">[删除]</asp:HyperLink></ItemTemplate>
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
	<input type="button" ID="btnSelectAll" value="全选" class="btn_gray_small" /><input type="button" ID="btnCancelAll" value="取消" class="btn_gray_small" /><asp:Button ID="btnDelete" runat="server" cssclass="btn_yellow_small" Text="删除" CausesValidation="false" OnClick="btnDelete_Click" />
</div>

</asp:Content>