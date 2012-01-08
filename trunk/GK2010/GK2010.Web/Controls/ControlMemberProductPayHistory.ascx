<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlMemberProductPayHistory.ascx.cs" Inherits="GK2010.Web.Controls.ControlMemberProductPayHistory" %>

<script  language="javascript" type="text/javascript">
    var buy_val = <%=id_Browse %>;
    $(document).ready(function () {
        buy_change(buy_val);
    });

    function buy_change(id) {
        $("#buy_" + buy_val + "_pic").hide();
        $("#buy_" + buy_val).show();

        $("#buy_" + id + "_pic").show();
        $("#buy_" + id).hide();

        buy_val = id;
    }


</script>
<div class="dp_sidebar_content">
                    <h2>购买本商品的顾客还买过</h2>
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