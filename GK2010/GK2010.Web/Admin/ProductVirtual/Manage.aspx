<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.ProductVirtual.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:TemplateField HeaderText="虚拟类别名称">
				<ItemTemplate><%#Eval("Title") %>
				<input type="hidden" runat="server" id="txtID" value='<%#Eval("ID") %>' />
				<input type="hidden" runat="server" id="txtProductCategoryID" value='<%#Eval("CategoryID") %>' />
				</ItemTemplate>
				<ItemStyle cssclass="td1" Width="120" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="虚拟类别值" >
				<ItemTemplate>
                    <asp:RadioButtonList ID="radID" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />		
	</asp:GridView>
</div>
<div id="divOperator" class="tac mb10">
<asp:Button ID="btnSave" runat="server" cssclass="btn_yellow_small" Text="保存" CausesValidation="false" OnClick="btnSave_Click" />
</div>
</asp:Content>