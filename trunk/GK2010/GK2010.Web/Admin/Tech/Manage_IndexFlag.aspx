<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage_IndexFlag.aspx.cs" Inherits="GK2010.Web.Admin.Tech.Manage_IndexFlag" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/tipswindown.css" rel="stylesheet" type="text/css" />
    <script src="/JavaScript/jquery.tipswindow.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		关键字：<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:DropDownList ID="dropCategory" runat="server"></asp:DropDownList>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="搜索" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="添加" />   
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">技术支持管理（总首页推荐）</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" >
				<ItemStyle cssclass="td2" Width="50" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="标题">
				<ItemTemplate>				
				<%# Eval("Title") %>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="类别">
				<ItemTemplate><%# GK2010.BLL.TechCategory.GetTitle( Eval("CategoryID"))%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="图片">
				<ItemTemplate>
				<div id="img<%#Eval("ID")%>"><%# GK2010.Utility.StringHelper.GetPicture(Eval("PictureSmall"))%></div>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="推荐">
				<ItemTemplate>
                   <%# GK2010.Utility.StringHelper.GetStrFlag(Eval("IndexFlag"), "推荐")%>
				</ItemTemplate>
				<ItemStyle cssclass="td2"  />
			</asp:TemplateField> 		
			<asp:TemplateField HeaderText="排序">
				<ItemTemplate>
                    <asp:TextBox ID="txtSortID" runat="server" Text='<%# Eval("IndexSortID") %>' CssClass="input"></asp:TextBox>
				</ItemTemplate>
				<ItemStyle cssclass="td2"  />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="操作" >
				<ItemTemplate>
				    <asp:HyperLink ID="HyperLinkModify" runat="server">[修改]</asp:HyperLink>
				    <asp:HyperLink ID="HyperLinkDelete" runat="server">[删除]</asp:HyperLink>
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
	<asp:Button ID="btnSave" runat="server" cssclass="btn_yellow_small" Text="保存" CausesValidation="false" OnClick="btnSave_Click" />
</div>

</asp:Content>