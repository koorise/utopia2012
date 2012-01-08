<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProductCommend.ascx.cs" Inherits="GK2010.Web.Controls.ControlProductCommend" %>
<div class="news_content flow_l" style="background:#F8F8F8">
    <div class="hd"><h2><span><a href="/product/" >更多</a></span>产品推荐</h2></div>
    <div class="bd ul_img mdB10">
        <ul>
            <asp:Repeater ID="rptCommendProduct" runat="server" 
                onitemdatabound="rptCommendProduct_ItemDataBound">
                <ItemTemplate>
                    <li><asp:HyperLink ID="productUrl" runat="server"><asp:Image ID="productPic" runat="server" /></asp:HyperLink><asp:HyperLink ID="productUrl1" runat="server"><asp:Literal ID="productTitle" runat="server"></asp:Literal></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="ft"></div>
</div>