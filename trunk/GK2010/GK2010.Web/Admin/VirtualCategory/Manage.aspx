<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.VirtualCategory.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">


<h2 class="h1"><span class="mr10 fl">��Ʒ����������</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>		
		    
			<asp:TemplateField HeaderText="��Ʒ���">
				<ItemTemplate>���<%=I++ %><br /><b><%# Eval("Title") %></b><br /><a href="add.aspx?CategoryID=<%#Eval("ID") %>" class="mr10">[����������]</a></ItemTemplate>
				<ItemStyle cssclass="td2" Width="120" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="�������" >
				<ItemTemplate>
				    <asp:GridView ID="gridVirtual" runat="server" OnRowDataBound="gridVirtual_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		                <Columns>			
		                    
			                <asp:TemplateField HeaderText="����">
				                <ItemTemplate><%# Eval("Title") %>��</ItemTemplate>
				                <ItemStyle cssclass="td2" Width="100px" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="ֵ">
				                <ItemTemplate><%# Eval("Tags") %></ItemTemplate>
				                <ItemStyle cssclass="td2" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="����">
				                <ItemTemplate><%# Eval("SortID") %></ItemTemplate>
				                <ItemStyle cssclass="td2" />
			                </asp:TemplateField> 	
			                <asp:TemplateField HeaderText="����" >
				                <ItemTemplate>
                				<a href="modify.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>" class="mr10">[�༭]</a>
                                <a href="delete.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>">[ɾ��]</a>
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