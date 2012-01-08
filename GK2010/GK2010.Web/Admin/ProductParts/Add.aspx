<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ProductParts.Add"  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1"><asp:Label ID="lblAttachFlag" runat="server" Text=""></asp:Label>新增</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">上级类别：</td>
		<td class="td2"><asp:Literal ID="txtParentID" runat="server"></asp:Literal></td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr id="tdAttachment" runat="server">
		<td class="td1">类型：</td>
		<td class="td2">
           <asp:RadioButtonList ID="radAttachment" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="2">基本</asp:ListItem>
                <asp:ListItem Value="1">附件</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdShowFlag" runat="server">
		<td class="td1">前台显示：</td>
		<td class="td2">
           <asp:RadioButtonList ID="radShowFlag" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdTitle" runat="server">
		<td class="td1"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>：</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" Width="400px" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdTitleEn" runat="server">
		<td class="td1"><asp:Label ID="lblTitleEn" runat="server" Text=""></asp:Label>：</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTitleEn" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdPrice" runat="server">
		<td class="td1">
            <asp:Label ID="lblPrice" runat="server" Text="部件价格"></asp:Label>：</td>
		<td class="td2">
			<asp:TextBox id="txtPrice" runat="server" cssclass="input input_wa" Text="0" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr id="tdDefaultFlag" runat="server">
		<td class="td1">默认选项：</td>
		<td class="td2">
           <asp:RadioButtonList ID="radDefaultFlag" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdDetail" runat="server">
		<td class="td1">了解更多：</td>
		<td class="td2">
			<fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/" Height="250px" ToolbarSet="Basic" Width="100%"></fckeditorv2:FCKeditor>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">排序：</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnBack" runat="server" Text="返 回" CssClass="btn_gray_big" CausesValidation="false" OnClick="btnBack_Click" ></asp:Button><asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
