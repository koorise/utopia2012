<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage_IndexFlag.aspx.cs" Inherits="GK2010.Web.Admin.Tech.Manage_IndexFlag" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/tipswindown.css" rel="stylesheet" type="text/css" />
    <script src="/JavaScript/jquery.tipswindow.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		�ؼ��֣�<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:DropDownList ID="dropCategory" runat="server"></asp:DropDownList>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="����" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="���" />   
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">����֧�ֹ�������ҳ�Ƽ���</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:BoundField DataField="ID" HeaderText="���" ReadOnly="True" >
				<ItemStyle cssclass="td2" Width="50" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="����">
				<ItemTemplate>				
				<%# Eval("Title") %>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="���">
				<ItemTemplate><%# GK2010.BLL.TechCategory.GetTitle( Eval("CategoryID"))%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="ͼƬ">
				<ItemTemplate>
				<div id="img<%#Eval("ID")%>"><%# GK2010.Utility.StringHelper.GetPicture(Eval("PictureSmall"))%></div>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="�Ƽ�">
				<ItemTemplate>
                   <%# GK2010.Utility.StringHelper.GetStrFlag(Eval("IndexFlag"), "�Ƽ�")%>
				</ItemTemplate>
				<ItemStyle cssclass="td2"  />
			</asp:TemplateField> 		
			<asp:TemplateField HeaderText="����">
				<ItemTemplate>
                    <asp:TextBox ID="txtSortID" runat="server" Text='<%# Eval("IndexSortID") %>' CssClass="input"></asp:TextBox>
				</ItemTemplate>
				<ItemStyle cssclass="td2"  />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="����" >
				<ItemTemplate>
				    <asp:HyperLink ID="HyperLinkModify" runat="server">[�޸�]</asp:HyperLink>
				    <asp:HyperLink ID="HyperLinkDelete" runat="server">[ɾ��]</asp:HyperLink>
				</ItemTemplate>
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
	<asp:Button ID="btnSave" runat="server" cssclass="btn_yellow_small" Text="����" CausesValidation="false" OnClick="btnSave_Click" />
</div>

</asp:Content>