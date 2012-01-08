<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.Program.Add"  ValidateRequest="false" EnableEventValidation="false"    %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/JavaScript/jquery.post.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1">方案中心新增</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >	
	
	<tr>
		<td class="td1">标题：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" 
                Width="311px" ></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" 
                Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">参数设置：</td>
		<td class="td2">			
			<asp:CheckBox ID="chkIndexFlag" runat="server" Text="总首页推荐" />
			<asp:CheckBox ID="chkChannelFlag" runat="server" Text="频道页首页推荐" />
			<asp:CheckBox ID="chkCommendFlag" runat="server" Text="频道页今日推荐" />		
			<asp:CheckBox ID="chkHotFlag" runat="server" Text="频道页热门推荐" />
		</td>
		<td class="td2">&nbsp;</td>
	</tr>
    <gk:AdminIndustry ID="AdminIndustry1" runat="server" />
	<gk:AdminMedium ID="AdminMedium1" runat="server" />
	<tr>
		<td class="td1">详细：</td>
		<td class="td2">
			<fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/" Height="400px" ToolbarSet="Default" Width="100%"></fckeditorv2:FCKeditor>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<gk:AdminTag ID="AdminTag1" runat="server" />
	<gk:AdminSEO ID="AdminSEO1" runat="server" />
	
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>

</asp:Content>
