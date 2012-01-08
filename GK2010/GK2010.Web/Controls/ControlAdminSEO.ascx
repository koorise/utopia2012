<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminSEO.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminSEO" %>
<tr>
	<td class="td1">SEO标题：</td>
	<td class="td2">
		<asp:TextBox id="txtSEOTitle" runat="server" cssclass="input input_wa" 
            Width="431px" ></asp:TextBox>
	</td>
	<td class="td2"><div class="help_a"></div></td>
</tr>
<tr>
	<td class="td1">SEO关键词：</td>
	<td class="td2">
		<asp:TextBox id="txtSEOKeywords" runat="server" cssclass="input input_wa" 
            Width="430px" ></asp:TextBox>
	</td>
	<td class="td2"><div class="help_a"></div></td>
</tr>
<tr>
	<td class="td1">SEO描述：</td>
	<td class="td2">
		<asp:TextBox id="txtSEODescription" runat="server" cssclass="input input_wa" 
            Height="50px" TextMode="MultiLine" Width="431px" ></asp:TextBox>
	</td>
	<td class="td2"><div class="help_a"></div></td>
</tr>