<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.Config.Modify" Title=""  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<h2 class="h1">站点配置信息</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >	
	<tr>
		<td class="td1">网站域名：</td>
		<td class="td2">
			<asp:TextBox id="txtWebDomain" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站名称：</td>
		<td class="td2">
			<asp:TextBox id="txtWebName" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站备案号：</td>
		<td class="td2">
			<asp:TextBox id="txtWebBeian" runat="server" cssclass="input input_wa" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站统计：</td>
		<td class="td2">
			<asp:TextBox id="txtWebStatic" runat="server" cssclass="input " 
                TextMode="MultiLine" Height="58px" Width="432px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站53在线客服代码：</td>
		<td class="td2">
			<asp:TextBox id="txtControlService" runat="server" cssclass="input " 
                TextMode="MultiLine" Height="55px" Width="431px"></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站头部html文件：</td>
		<td class="td2">
		    <fckeditorv2:FCKeditor ID="txtControlTop" runat="server" BasePath="/admin/FCKeditor/" Height="400px" ToolbarSet="Default" Width="100%"></fckeditorv2:FCKeditor>
			
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">网站底部html文件：</td>
		<td class="td2">
		    <fckeditorv2:FCKeditor ID="txtControlBoot" runat="server" BasePath="/admin/FCKeditor/" Height="400px" ToolbarSet="Default" Width="100%"></fckeditorv2:FCKeditor>
		
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">显示选型价格：</td>
		<td class="td2">
            <asp:RadioButtonList ID="radShowPriceDiyFlag" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList>		
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">未登录显示价格：</td>
		<td class="td2">
            <asp:RadioButtonList ID="radShowPriceWhenNotLogin" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList>		
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">邮箱用户名：</td>
		<td class="td2">
			<asp:TextBox id="txtEmailUserName" runat="server" cssclass="input input_wa" 
                Width="454px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">邮箱登录密码：</td>
		<td class="td2">
			<asp:TextBox id="txtEmailUserPwd" runat="server" cssclass="input input_wa" 
                Width="454px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">邮箱主机：</td>
		<td class="td2">
			<asp:TextBox id="txtEmailHost" runat="server" cssclass="input input_wa" 
                Width="453px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">邮箱端口：</td>
		<td class="td2">
			<asp:TextBox id="txtEmailPort" runat="server" cssclass="input input_wa" 
                Width="455px" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnUpdate" runat="server" Text="保存" CssClass="btn_yellow_big" OnClick="btnUpdate_Click" ></asp:Button></div>

</asp:Content>