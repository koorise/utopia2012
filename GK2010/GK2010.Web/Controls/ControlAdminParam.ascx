<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminParam.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminParam" %>
<tr>
	<td class="td1">参数显示：</td>
	<td class="td2">
		<asp:CheckBox ID="chkIndexFlag" runat="server" Text="总首页" />
		<asp:CheckBox ID="chkHotFlag" runat="server" Text="频道首页焦点" />
		<asp:CheckBox ID="chkChannelFlag" runat="server" Text="频道首页推荐" />   
		<asp:CheckBox ID="chkCommendFlag" runat="server" Text="频道列表页推荐" />             
	</td>
	<td class="td2"><div class="help_a"></div></td>
</tr>	
<tr>
	<td class="td1">参数排序：</td>
	<td class="td2">
        总首页排序：<asp:TextBox ID="txtIndexSortID" runat="server" Text="2000" Width="60" cssclass="input input_wa" ></asp:TextBox>			
		频道首页焦点排序：<asp:TextBox ID="txtHotSortID" runat="server" Text="2000" Width="60"  cssclass="input input_wa" ></asp:TextBox>	
		频道首页推荐：<asp:TextBox ID="txtChannelSortID" runat="server" Text="2000" Width="60"  cssclass="input input_wa" ></asp:TextBox>
		频道列表页排序：<asp:TextBox ID="txtCommendSortID" runat="server" Text="2000" Width="60"  cssclass="input input_wa" ></asp:TextBox>					
	</td>
	<td class="td2"><div class="help_a"></div></td>
</tr>	