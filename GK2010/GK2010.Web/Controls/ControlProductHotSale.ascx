<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProductHotSale.ascx.cs" Inherits="GK2010.Web.Controls.ControlProductHotSale" %>
 <div class="dp_sidebar_content mdT10">
                    <h2>商家热卖</h2>
                    <ul>
                      <asp:Repeater id="RepeaterList" Runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                      <ItemTemplate >
                        <li class="t3"><table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                 <td  align="center" valign="top">
                                     <asp:Literal ID="lit_productImg" runat="server"></asp:Literal>
                                 </td>
                                
                            </tr>
                            <tr>
                                <td align="center" >
                                    <asp:Literal ID="lit_ProductTitle" runat="server"></asp:Literal>
                                    <div><span class="price"><span>￥</span><asp:Literal ID="litPrice" runat="server"></asp:Literal></span></div>
                                </td>
                            </tr>
                        </table>
                        </li>
                        </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                </div>  