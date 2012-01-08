<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.VirtualCategory.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">


<h2 class="h1"><span class="mr10 fl">产品虚拟类别管理</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>		
		    
			<asp:TemplateField HeaderText="产品类别">
				<ItemTemplate>序号<%=I++ %><br /><b><%# Eval("Title") %></b><br /><a href="add.aspx?CategoryID=<%#Eval("ID") %>" class="mr10">[添加虚拟类别]</a></ItemTemplate>
				<ItemStyle cssclass="td2" Width="120" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="虚拟类别" >
				<ItemTemplate>
				    <asp:GridView ID="gridVirtual" runat="server" OnRowDataBound="gridVirtual_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		                <Columns>			
		                    
			                <asp:TemplateField HeaderText="名称">
				                <ItemTemplate><%# Eval("Title") %>：</ItemTemplate>
				                <ItemStyle cssclass="td2" Width="100px" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="值">
				                <ItemTemplate><%# Eval("Tags") %></ItemTemplate>
				                <ItemStyle cssclass="td2" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="排序">
				                <ItemTemplate><%# Eval("SortID") %></ItemTemplate>
				                <ItemStyle cssclass="td2" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="操作" >
				                <ItemTemplate>
                				<a href="modify.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>" class="mr10">[编辑]</a>
                                <a href="delete.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>">[删除]</a>
				                </ItemTemplate>
				                <ItemStyle cssclass="td2" />
			                </asp:TemplateField>
		                </Columns>
		                <RowStyle CssClass="tr1 vt" />
		                <HeaderStyle CssClass="tr2" HorizontalAlign="Center" />
	                </asp:GridView>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />
	</asp:GridView>
</div>
</asp:Content>