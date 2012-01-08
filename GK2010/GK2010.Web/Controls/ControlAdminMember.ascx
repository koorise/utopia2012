<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminMember.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminMember" %>
<tr>
	<td class="td1">分配管理员：</td>
	<td class="td2">			
		<asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0" GridLines="None" OnRowDataBound="grid_RowDataBound" 
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="管理员角色">
                    <ItemTemplate>
                        <%#Eval("Title") %>
                    </ItemTemplate>
                    <ItemStyle cssclass="td1" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="管理员列表">
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