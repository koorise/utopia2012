<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="modify.aspx.cs" Inherits="GK2010.Web.Admin.SystemPermission.modify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function selAll() {
        $("input[type='checkbox']").each(function() { $(this).attr("checked", true); });
    }
    function unselAll() {
        $("input[type='checkbox']").each(function() { $(this).attr("checked", false); });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1"><span class="mr10 fl"><asp:Literal ID="txtRole" runat="server"></asp:Literal>的后台权限分配</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>			
			<asp:TemplateField HeaderText="权限类别">
				<ItemTemplate><%#Eval("Title") %></ItemTemplate>
				<ItemStyle cssclass="td1" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="权限列表" >
				<ItemTemplate>
                    <asp:CheckBoxList ID="chkPermission" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" Width="100%" ></asp:CheckBoxList>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />		
	</asp:GridView>
</div>
<div id="divOperator" class="tac mb10">
	<input type="button"  onclick="selAll()" value="全选" class="btn_gray_small" /><input type="button" onclick="unselAll()" value="取消" class="btn_gray_small" />
</div>
<div class="tac mb10">
    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn_yellow_big" OnClick="btnSave_Click" ></asp:Button>
</div>
</asp:Content>