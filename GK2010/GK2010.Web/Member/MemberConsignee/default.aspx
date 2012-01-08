<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Member.MemberConsignee._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">首页 > 我的工控 > 常用收货人
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <h2>常用收货人</h2>
    <div class="bd_bd">
    
                        <asp:GridView ID="GridView1" class="wp95 m_center table3" DataKeyNames="id" 
                            runat="server" AutoGenerateColumns="False" 
                            Width="95%" onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input type="checkbox" name="allbox" >
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkID" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>公司名称</HeaderTemplate>
                                    <ItemTemplate><%# Eval("Company")%></ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>姓名</HeaderTemplate>
                                    <ItemTemplate><%# Eval("RealName")%></ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>地址</HeaderTemplate>
                                    <ItemTemplate><%# Eval("Province")%><%# Eval("City")%><%# Eval("Area")%><%# Eval("Address")%></ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>默认</HeaderTemplate>
                                    <ItemTemplate><asp:Literal ID="txtDefaultFlag" runat="server"></asp:Literal></ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>操作</HeaderTemplate>
                                    <ItemTemplate><asp:HyperLink ID="HyperLinkModify" runat="server">修改</asp:HyperLink></ItemTemplate>
                                    <HeaderStyle CssClass="gd_th"  />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
        <table cellpadding="0" cellspacing="0" class="wp95 m_center table3">
                <tr>
                    <td colspan="6" class="text_c">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" class="btn_light_small" 
                            onclick="btnDelete_Click" OnClientClick="return confirm('您确定要删除吗？')"/>
                        <asp:Button ID="btnAdd" runat="server" Text="新增" class="btn_light_small" 
                            onclick="btnAdd_Click"/>
                    </td>
                </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
