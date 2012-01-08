<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProductBrowse.ascx.cs" Inherits="GK2010.Web.Controls.ControlProductBrowse" %>

 <script language="javascript" type="text/javascript">
        var history_val = <%=id_Browse %>;
        $(document).ready(function() {
            history_change(history_val);
        });

        function history_change(id) {
            $("#history_" + history_val + "_pic").hide();
            $("#history_" + history_val).show();

            $("#history_" + id + "_pic").show();
            $("#history_" + id).hide();

            history_val = id;
        }
  </script>


<div class="dp_sidebar_content mdT10">
                    <h2>您的浏览历史</h2>
                    <ul >
                         <asp:Repeater id="RepeaterList" Runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                            <ItemTemplate >
	                                <asp:Literal ID="lit_Title" runat="server"></asp:Literal>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="60" height="60" align="center" valign="top">
                                           <asp:Literal ID="lit_Product_Img" runat="server"></asp:Literal>
                                            </td>
                                            <td class=" pdL5"  valign="top">
                                            <asp:Literal ID="lit_right_Title" runat="server"></asp:Literal>
	                                        <div><span class="price"><span>￥</span><asp:Literal ID="litPrice" runat="server"></asp:Literal></span></div>
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>  