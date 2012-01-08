<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.News.Manage" Title="" %>
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
		<gk:AdminParamSearch ID="AdminParamSearch1" runat="server" />
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="����" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="���" />   
	</asp:Panel>
</div>
<h2 class="h1"><span class="mr10 fl">�������Ĺ���</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:TemplateField HeaderText="">
				<HeaderTemplate><input type="checkbox" id="chkSelectAll"></HeaderTemplate>
				<ItemTemplate><asp:CheckBox ID="chkID" runat="server" /></ItemTemplate>
				<ItemStyle cssclass="td2" Width="20" />
			</asp:TemplateField>
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
				<ItemTemplate><%# GK2010.BLL.NewsCategory.GetTitle( Eval("CategoryID"))%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="ͼƬ">
				<ItemTemplate>
				<div id="img<%#Eval("ID")%>"><%# GK2010.Utility.StringHelper.GetPicture(Eval("PictureSmall"))%></div>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="����">
				<ItemTemplate>
				<table>
				    <tr>
				       <td width="25%"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("IndexFlag"), "���� ")%></td>
				        <td width="25%"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("HotFlag"), "Ƶ��")%></td>
				        <td width="25%"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("ChannelFlag"), "Ƶ�� ")%></td>
				        <td width="25%"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("CommendFlag"), "Ƶ�� ")%></td>
				    </tr>
				</table>
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
	<input type="button" ID="btnSelectAll" value="ȫѡ" class="btn_gray_small" /><input type="button" ID="btnCancelAll" value="ȡ��" class="btn_gray_small" /><asp:Button ID="btnDelete" runat="server" cssclass="btn_yellow_small" Text="ɾ��" CausesValidation="false" OnClick="btnDelete_Click" />
</div>

</asp:Content>