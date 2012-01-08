<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage_No.aspx.cs" Inherits="GK2010.Web.Admin.Qa.Manage_No" Title="" %>
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
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="搜索" />
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">解答中心管理（未解答）</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" >
				<ItemStyle cssclass="td2" Width="50" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="问题标题">
				<ItemTemplate>				
				<%# GK2010.Utility.StringHelper.SubString( Eval("Title"),20) %>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="分类">
				<ItemTemplate><%# GK2010.BLL.QaCategory.GetTitle( Eval("CategoryID"))%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="提问时间">
				<ItemTemplate>
				<%# GK2010.Utility.DatetimeHelper.Parse(Eval("PostDate"), "yyyy-MM-dd HH:mm")%>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="是否解答">
				<ItemTemplate>
				<%# GK2010.Utility.StringHelper.GetStrFlag(Eval("CheckFlag"), "已解答", "未解答")%>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="操作" >
				<ItemTemplate>
				    <asp:HyperLink ID="HyperLinkModify" runat="server">[回复]</asp:HyperLink>
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
</asp:Content>