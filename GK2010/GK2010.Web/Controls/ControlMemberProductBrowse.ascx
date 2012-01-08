<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlMemberProductBrowse.ascx.cs" Inherits="GK2010.Web.Controls.ControlMemberProductBrowse" %>

<script language="javascript" type="text/javascript">
    var view_val = <%=id_Browse %>;
    $(document).ready(function () {
    view_change(view_val);
    });

    function view_change(id) {
        $("#view_" + view_val + "_pic").hide();
        $("#view_" + view_val).show();

        $("#view_" + id + "_pic").show();
        $("#view_" + id).hide();

        view_val = id;
    }
</script>
                 <div class="dp_sidebar_content mdT10">
                    <h2>浏览本商品的顾客还看过</h2>
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