<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GK2010.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <style type="text/css">
<%--     .recommend_news
    {
	clear: both;
	margin-top: 8px;
    }--%>

<%--    .recommend_news h2
    {
	    background: url(/images/tuijian_tit.jpg) no-repeat;
	    height: 32px;
	    line-height: 32px;
	    color: #fff;
	    padding-left: 60px;
    }--%>
<%--    </style>--%>--%>

</head>
<body>
    <form id="form1" runat="server">
    
<%--    <div>
    <table  border="1" width="600px">
    <tr style="background-color:Blue ; border-color:Green">
    <td>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound">
         <ItemTemplate>
              
               <asp:HyperLink ID="HyperLinkCTitle" runat="server"></asp:HyperLink>
          </td>
           </tr>
               <tr>
               <td>
                      <asp:Repeater ID="RepeaterListChildProduct" runat="server" OnItemDataBound="RepeaterListChildProduct_ItemDataBound">
                            <ItemTemplate>
                            <dl>
                                <dt>
                                    <table class="pic">
                                        <tr>
                                            <td align="center" valign="middle"><asp:HyperLink ID="HyperLinkImage" runat="server" Target="_blank"></asp:HyperLink></td>
                                        </tr>
                                    
                                    </table>
                                </dt>
                                <dt class="good-name"><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"></asp:HyperLink></dt>
                                <dd class="good-market-price">市场价：<s><asp:Literal ID="txtPriceOld" runat="server"></asp:Literal></s></dd>
                                <dd class="good-price"><span><asp:Literal ID="txtPrice" runat="server"></asp:Literal></span></dd>
                            </dl>
                            </ItemTemplate>
                        </asp:Repeater>
                     
                           </ItemTemplate>
                        </asp:Repeater>
                  </td>
                </tr>
               </table>
        </div>--%>
    




    <div  style="clear: both;
	margin-top: 8px;">
     <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound">
         <ItemTemplate>
                <h2 style=" background: url(/images/tuijian_tit.jpg) no-repeat;
	    height: 32px;
	    line-height: 32px;
	    color: #fff;
	    padding-left: 60px;"><span><a href="">更多>></a></span>
                     <asp:HyperLink ID="HyperLinkCTitle" runat="server"></asp:HyperLink></h2>
                <div style="border: 1px solid #D4D4D4;float: left;width: 736px;">
                    <div style="width: 736px;">

                        <asp:Repeater ID="RepeaterListChildProduct" runat="server" OnItemDataBound="RepeaterListChildProduct_ItemDataBound">
                            <ItemTemplate>
                            <dl>
                                <dt>
                                    <table class="pic">
                                        <tr>
                                            <td align="center" valign="middle"><asp:HyperLink ID="HyperLinkImage" runat="server" Target="_blank"></asp:HyperLink></td>
                                        </tr>
                                    
                                    </table>
                                </dt>
                                <dt class="good-name"><asp:HyperLink ID="HyperLinkTitle" runat="server" Target="_blank"></asp:HyperLink></dt>
                                <dd class="good-market-price">市场价：<s><asp:Literal ID="txtPriceOld" runat="server"></asp:Literal></s></dd>
                                <dd class="good-price"><span><asp:Literal ID="txtPrice" runat="server"></asp:Literal></span></dd>
                            </dl>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                     </div>
                    </ItemTemplate>
        </asp:Repeater>

  </div>
    </form>
</body>
</html>
