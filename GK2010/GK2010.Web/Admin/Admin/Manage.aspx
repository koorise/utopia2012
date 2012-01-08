<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.Admin.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		用户名或姓名：<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="搜索" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="添加" />   
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">管理员列表</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:TemplateField HeaderText="">
				<HeaderTemplate><input type="checkbox" id="chkSelectAll"></HeaderTemplate>
				<ItemTemplate><asp:CheckBox ID="chkID" runat="server" /></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="用户名">
				<ItemTemplate><%# Eval("UserName") %>&nbsp;<span style="color:Red"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("VIPFlag"), "[VIP会员]", "")%></span></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="角色">
				<ItemTemplate><%# GK2010.BLL.MemberGroup.GetTitle( Eval("GroupID")) %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			
			<asp:TemplateField HeaderText="姓名">
				<ItemTemplate><%# Eval("RealName") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			
			<asp:TemplateField HeaderText="注册时间">
				<ItemTemplate><%# GK2010.Utility.DatetimeHelper.Parse( Eval("RegisterDate"),"yyyy-MM-dd") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="最近登录">
				<ItemTemplate><%# GK2010.Utility.DatetimeHelper.Parse( Eval("LastDate"),"yyyy-MM-dd") %></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="当前状态">
				<ItemTemplate><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("LockFlag"), "锁定", "正常")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="操作" >
				<ItemTemplate><asp:HyperLink ID="HyperLinkModify" runat="server">[编辑]</asp:HyperLink><asp:HyperLink ID="HyperLinkDelete" runat="server">[删除]</asp:HyperLink></ItemTemplate>
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