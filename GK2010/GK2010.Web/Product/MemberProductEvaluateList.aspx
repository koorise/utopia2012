<%@ Page Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="MemberProductEvaluateList.aspx.cs" Inherits="GK2010.Web.Product.MemberProductEvaluateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
     <link href="/css/product_detail.css" rel="stylesheet" type="text/css" />
   <link href="/Css/page.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var buy_val = "110";
        var view_val = "110";
        var history_val = "110";
        $(document).ready(function() {
            buy_change(buy_val);
            view_change(view_val);
            history_change(history_val);
        });

        function buy_change(id) {
            $("#buy_" + buy_val + "_pic").hide();
            $("#buy_" + buy_val).show();

            $("#buy_" + id + "_pic").show();
            $("#buy_" + id).hide();

            buy_val = id;
        }
        function view_change(id) {
            $("#view_" + view_val + "_pic").hide();
            $("#view_" + view_val).show();

            $("#view_" + id + "_pic").show();
            $("#view_" + id).hide();

            view_val = id;
        }
        function history_change(id) {
            $("#history_" + history_val + "_pic").hide();
            $("#history_" + history_val).show();

            $("#history_" + id + "_pic").show();
            $("#history_" + id).hide();

            history_val = id;
        }

     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="navigator">
    <asp:Literal ID="litProduct_Title" runat="server"></asp:Literal>
    </div>
    <div class="main">
            <!--left -->
            <div class="left mar5">
                <div class="dp_sidebar_content">
                    <h2>购买本商品的顾客还买过</h2>
                    <ul >                        
                        <li id="buy_110" onmouseover="buy_change('110')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">1新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="buy_110_pic" class="t2" style="display: none;">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="buy_111" onmouseover="buy_change('111')" style="display: list-item;" class="t1" >
	                        ·<a target="_blank" href="#">2新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="buy_111_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                               <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="buy_112" onmouseover="buy_change('112')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">3新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="buy_112_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ul>
                </div>  
                <div class="dp_sidebar_content mdT10">
                    <h2>浏览本商品的顾客还看过</h2>
                    <ul >                        
                        <li id="view_110" onmouseover="view_change('110')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">1新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="view_110_pic" class="t2" style="display: none;">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="view_111" onmouseover="view_change('111')" style="display: list-item;" class="t1" >
	                        ·<a target="_blank" href="#">2新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="view_111_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                               <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="view_112" onmouseover="view_change('112')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">3新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="view_112_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ul>
                </div>  
                <div class="dp_sidebar_content mdT10">
                    <h2>商家热卖</h2>
                    <ul>
                        <li class="t3"><table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                 <td  align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic120"></a></td>
                                
                            </tr>
                            <tr>
                                <td align="center" >
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
                                    <div><span class="price"><span>￥</span>43.60</span></div>
                                </td>
                            </tr>
                        </table>
                        </li>
                         <li class="t3"><table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                 <td  align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic120"></a></td>
                                
                            </tr>
                            <tr>
                                <td align="center" >
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
                                    <div><span class="price"><span>￥</span>43.60</span></div>
                                </td>
                            </tr>
                        </table>
                        </li>
                         <li class="t3"><table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                 <td  align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic120"></a></td>
                                
                            </tr>
                            <tr>
                                <td align="center" >
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
                                    <div><span class="price"><span>￥</span>43.60</span></div>
                                </td>
                            </tr>
                        </table>
                        </li>
                         <li class="t3"><table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                 <td  align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic120"></a></td>
                                
                            </tr>
                            <tr>
                                <td align="center" >
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
                                    <div><span class="price"><span>￥</span>43.60</span></div>
                                </td>
                            </tr>
                        </table>
                        </li>
                    </ul>
                </div>  
                
                <div class="dp_sidebar_content mdT10">
                    <h2>您的浏览历史</h2>
                    <ul >                        
                        <li id="history_110" onmouseover="history_change('110')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">1新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="history_110_pic" class="t2" style="display: none;">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="history_111" onmouseover="history_change('111')" style="display: list-item;" class="t1" >
	                        ·<a target="_blank" href="#">2新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="history_111_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                               <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        
                        <li id="history_112" onmouseover="history_change('112')" style="display: list-item;" class="t1">
	                        ·<a target="_blank" href="#">3新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑色</a>
                        </li>
                        <li id="history_112_pic" class="t2" style="display: none;">
	                         <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="60" height="60" align="center" valign="top"><a title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#"><img src="http://localhost:7755/UserFiles/2010-12-08/2(2)_100_100.jpg" class="pic"></a></td>
                                    <td class=" pdL5"  valign="top">
                                    <a class="name" title="新盟2.4G无线光学鼠标 N3 黑色" target="_blank" href="#">新盟2.4G无线光学鼠标&nbsp;N3&nbsp;黑</a>
	                                <div><span class="price"><span>￥</span>43.60</span></div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ul>
                </div>  
            </div>
            <!--left end -->
            <!-- right -->
            <div class="right_cont ">
                <div id="div2" class="divContent">
                <div style="height:3px;" > </div>
                <div class="evaluate">
                   <div class="evaluate_cont">
                        <div class="comment">
                            <div class="mc tabcon">
                                <div class="mc tabcon">
                                    <div class="i-comment">
                                        <div class="rate">
                                            <strong>
                                                <asp:Literal ID="litGoodScroe1_1" runat="server"></asp:Literal></strong>
                                            <br>
                                            好评度
                                        </div>
                                        <div class="percent">
                                            <dl>
                                                <dt>好评</dt>
                                                <dd class="d1">
                                                    <asp:Literal ID="litGoodWith1_1" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litGoodScroe1_2" runat="server"></asp:Literal></dd>
                                            </dl>
                                            <dl>
                                                <dt>中评</dt>
                                                <dd class="d1">
                                                    <asp:Literal ID="litCenterWith1" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litCenterScroe1" runat="server"></asp:Literal></dd>
                                            </dl>
                                            <dl>
                                                <dt>差评</dt>
                                                <dd class="d1">
                                                   <asp:Literal ID="litPoorWith1" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litPoorScroe1" runat="server"></asp:Literal></dd>
                                            </dl>
                                        </div>
                                        <div class="actor">
                                            <strong>
                                                <asp:Literal ID="litScroe1_0" runat="server"></asp:Literal>分 </strong><br />评价得分
                                        </div>
                                        <div class="btns">
                                            共有<asp:Literal ID="litPepCount1" runat="server"></asp:Literal>人评价>></div>
                                    </div>
                                </div>
                                <asp:Repeater runat="server" ID="repeaterEvaluateList1" 
                                    onitemdatabound="repeaterEvaluateList1_ItemDataBound">
                                    <ItemTemplate>
                                <div class="item">
                                    <div class="user">
                                        <div class="u-icon">
                                            <a href="" target="_blank">
                                                <img src="/images/60.gif" width="50" height="50">
                                            </a></div>
                                        <div class="u-name">
                                            <a href="<%# Eval("MemberID") %>" target="_blank"><%# Eval("MemeberUserName")%></a></div>
                                    </div>
                                    <div class="i-item">
                                        <div class="o-topic">
                                            <strong class="topic"><a href="" target="_blank"><%# Eval("EvaluateTitle")%></a></strong>&nbsp;&nbsp;<span>
                                                <img src="/images/star0<%# Eval("Score") %>.jpg" alt="" /></span><span class="date-comment"><%# Eval("EvaluateTime")%></span></div>
                                        <div class="comment-content">
                                            <dl>
                                                <dt>优点：</dt>
                                                <dd>
                                                    <%# Eval("Advantage")%></dd>
                                            </dl>
                                            <dl class="o-topic">
                                                <dt>不足：</dt>
                                                <dd>
                                                    <%# Eval("Inadequate")%></dd>
                                            </dl>
                                            <asp:Literal ID="lit_JieShi1" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="corner tl">
                                    </div>
                                    <div class="corner tr">
                                    </div>
                                    <div class="corner b">
                                    </div>
                                    <div class="corner bl">
                                    </div>
                                    <div class="corner br">
                                    </div>
                                </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>   
                <div class="clear"></div>                 
              <div class="pages pdL10" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  UrlPageIndexName="Page"></webdiyer:AspNetPager>
                </div>
               </div>
                
            </div>
            <!-- right end -->
             <div class="Related_products main mdT10">
            <div class="hd">
                <h2>
                    相关产品</h2>
            </div>
            <div class="buy_cont5">
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">多普达S910W 3G WIFI </a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">多普达S910W 3G WIFI </a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
                <dl>
                    <dt class="s120 pic"><a href=" " target="_blank">
                        <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                    <dt class="good-name"><a href=" " target="_blank">多普达S910W 3G WIFI </a></dt>
                    <dd class="good-market-price">
                        市场价：<s>4080</s></dd>
                    <dd class="good-price">
                        <span>3138</span></dd>
                </dl>
            </div>
        </div>
        </div>
</asp:Content>