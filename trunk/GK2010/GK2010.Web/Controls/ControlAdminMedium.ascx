<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminMedium.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminMedium" %>
<tr>
	<td class="td1">应用行业：</td>
	<td class="td2">			
		<asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0" GridLines="None" OnRowDataBound="grid_RowDataBound" 
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="大类">
                    <ItemTemplate>
                        <%#Eval("Title") %>
                    </ItemTemplate>
                    <ItemStyle cssclass="td1" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="小类">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" >
                        </asp:CheckBoxList>
                    </ItemTemplate>
                    <ItemStyle cssclass="td2" />
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="tr1 vt" />
            <HeaderStyle CssClass="tr2" />
        </asp:GridView>
	</td>
	<td class="td2">&nbsp;</td>
</tr>