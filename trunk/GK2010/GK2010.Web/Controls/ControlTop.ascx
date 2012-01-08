<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlTop.ascx.cs" Inherits="GK2010.Web.Controls.ControlTop" %>
<div class="hearder">
    <div class="loginNav">
        <div class="login">
            <ul>
                <asp:Panel ID="panHasLogin" runat="server">
                    <li>欢迎<a href="/member/" class="Ablue"><asp:Literal ID="lblRealName" runat="server"></asp:Literal></a>您来到工控商城网 </li>
                    <li><a href="/loginOut.aspx">[退出]</a></li>
                </asp:Panel>
                <asp:Panel ID="panHasNotLogin" runat="server">
                    <li><a href="/login.aspx">[请登录]</a></li>
                    <li>新用户？</li>
                    <li class="yellow"><a href="/register.aspx">[免费注册]</a></li>
                </asp:Panel>                
            </ul>
        </div>
        <div class="order">
            <ul>
                <li><a href="">我的订单</a></li>
                <li class="car"><asp:Literal ID="litCart" runat="server"></asp:Literal></li>
                <li class="bg01">
                    <asp:Literal ID="lit_jz" runat="server"></asp:Literal></li>
                <li><a href="/help/">帮助中心</a></li>
            </ul>
        </div>        
    </div>
    <div class="main">
        <div class="logo">
        </div>
        <div class="top_right">
            <div class="top_tel">
                <ul>
                    <li><span>适用行业：</span>化工 | 冶金 | 电力 | 机械</li>
                    <li><span>适用介质：</span>酸 | 碱 | 水 | 天然气 ...</li>
                </ul>
            </div>
            <div class="nav">
                <asp:Literal ID="txtNavigator" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="search01">
        <div class="search_bg01"></div>
        <div class="search_kuan">
            <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
            <input type="text" runat="server" id="txtTag" name="txtTag" class="key" onfocus="inputAutoClear(this)" value="输入搜索关键字" />
            <asp:Button ID="btnSearch" cssclass="btn-search" runat="server" Text="搜 索" onclick="btnSearch_Click" />
            </asp:Panel>
        </div>
        <div class="hotwords">
            <strong>热门搜索：</strong> <a href="">电磁流量计</a> <a href="">插入式电磁流量计</a> <a href="">智能涡街流量计
            </a><a href="">V锥</a>
        </div>
    </div>
</div>
