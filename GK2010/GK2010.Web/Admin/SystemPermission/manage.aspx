<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="GK2010.Web.Admin.SystemPermission.manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h3 class="h1"><b>提示信息</b></h3>
<div class="legend">
    <ol><li>可添加或删除后台管理权限。</li><li>根据需求设置每个用户组的后台管理权限。</li></ol>
</div>
<h2 class="h1"><span class="mr10 fl">用户组后台权限管理</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:TemplateField HeaderText="用户组">
				<ItemTemplate><%#Eval("Title") %></ItemTemplate>
				<ItemStyle cssclass="td1" VerticalAlign="Middle" />
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

</asp:Content>