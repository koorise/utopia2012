<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="GK2010.Web.Product.detail" %>
<%@ Register Src="~/Controls/ControlProductBrowse.ascx" TagName="ProductBrowse" TagPrefix="userControl" %>
<%@ Register Src="~/Controls/ControlMemberProductBrowse.ascx" TagName="MemberProductBrowse" TagPrefix="userControl1" %>
<%@ Register Src="~/Controls/ControlMemberProductPayHistory.ascx" TagName="MemberProductPayHistory" TagPrefix="userControl2" %>
<%@ Register Src="~/Controls/ControlProductHotSale.ascx" TagName="ProductHotSale" TagPrefix="userControl3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/product_detail.css" rel="stylesheet" type="text/css" />
   <link href="/Css/page.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            showPic(1);
        });

        function changeTab(index) {
            for (var i = 1; i <= 2; i++) {
                document.getElementById("li_" + i).className = "";
                document.getElementById("li_" + index).className = "bg f14 B";
                document.getElementById("div" + i).style.display = "none";
            }
           
            document.getElementById("div" + index).style.display = "block";
        }

        function showPic(num) {
            try {
                var src = $("#imgPictureSmall" + num).attr("bigImg");
                $("#<%=imgPictureBig.ClientID %>").attr("src", src);

                $("ul.thumb li").removeClass("current");
                $("ul.thumb li").addClass("unselect");

                $("#liPic" + num).removeClass("unselect");
                $("#liPic" + num).addClass("current");
            }
            catch (e) { }
        }


     
    </script>
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <div class="main">
            <!--left -->
            <div class="left mar5">
                <userControl2:MemberProductPayHistory ID="memberPayHistory" runat="server" />
                <userControl1:MemberProductBrowse runat="server" ID="MemberProductBrowse"/>
                <userControl3:ProductHotSale runat="server" ID="ProductHotSale" />
               <userControl:ProductBrowse ID="ProductBrowse1" runat="server" />
            </div>
            <!--left end -->
            <!-- right -->
            <div class="right_cont ">
                <div class="base_infor mdT8">
                    <div class="h1_title"><h1><asp:Literal ID="txtTitle" runat="server"></asp:Literal></h1></div>                    
                    <div class="base_left_pc">
                        <div class="gallery">
                            <div class="booth picc s310">
                                <asp:Image ID="imgPictureBig" runat="server" Height="310" Width="310" />
                            </div>
                            <ul class="thumb clearfix">
                                 <asp:Repeater ID="RepeaterListPicture" runat="server">
                                    <ItemTemplate>
                                        <li onmouseover="showPic(<%=I %>)" id="liPic<%=I%>" style="cursor: pointer">
                                            <div class="s50"><img src="<%#Eval("PictureSmall") %>" bigimg="<%#Eval("PictureBig") %>" id="imgPictureSmall<%=I++%>" /></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
    <script src="../JavaScript/ProductFavorites.js" ></script>   
                        <div class="collect_bg mar8"><a style="cursor:pointer" onclick='addFavorites(<%=GK2010.Utility.ConfigParam.ID %>,<%=Product_CategoryID %>,"<%=Product_Title %>");'>收藏该商品</a><span>(<%=Product_Favorites_Count %>)</span></div>
                    </div>
                    <div class="right_infor">
                        <ul>
                            <li class="detail-price">品 牌：<asp:Literal ID="txtBrand" runat="server"></asp:Literal> 货 期：<asp:Literal ID="Literal2" runat="server"></asp:Literal></li>
                            <li class="detail-price">类别：<asp:Literal ID="txtCategory" runat="server"></asp:Literal></li>    
                            <li class="good-price">会员价：<span class="f24" style="font-size:24px"><asp:Literal ID="Literal4" runat="server"></asp:Literal></span></li>                        
                            <li class="good-market-price">市场价：<s><asp:Literal ID="Literal3" runat="server"></asp:Literal></s></li>
                            <li>产品型号：<asp:Literal ID="Literal5" runat="server"></asp:Literal></li>
                            <li>商品评分：<span><img src="/images/star0<%=EvaluateZongSorce %>.jpg" alt="" /></span> <span class="blue">已有<%=EvaluateZongCount%>人评价</span></li>
                            <li>成为VIP可享受更多优惠 什么是VIP? <span>
                                <img src="/images/vip02.jpg" alt="" /></span> </li>
                            <li class="B blue">特色服务</li>
                            <li class="online_service1">
                                <img src="/images/word02.jpg" alt="" />
                            </li>
                            <li>
                                <span>
                                <asp:ImageButton ID="iBSelfHelpSelectType" runat="server" 
                                    ImageUrl="/images/button08.jpg" onclick="iBSelfHelpSelectType_Click" /></span>
                                <span>
                                <asp:ImageButton ID="iBJoinShoppongCart" runat="server" 
                                    ImageUrl="/images/button07.jpg" onclick="iBJoinShoppongCart_Click" />
                                </span>
                              </li>
                        </ul>
                        <div class="clear_b"><a href="">送积分：<asp:Literal ID="Literal6" runat="server"></asp:Literal></a><a href=""> 收藏人气：<%=Product_Favorites_Count%></a></div>
                    </div>
                </div>
                <div class="commodity_list">
                    <div class="commodity_list_nav">
                        <ul>
                            <li id="li_1" class="bg f14 B" onclick="changeTab('1')" style="cursor:pointer">商品详情</li>
                            <li id="li_2" onclick="changeTab('2')" style="cursor:pointer">商品评价</li>
                            <!--<li id="li_3" onclick="changeTab('3')" style="cursor:pointer">商家问答</li>-->
                        </ul>
                    </div>
                    <div class="right_bottom"></div>
                </div>
               <div id="div1" style="display: block" class="divContent">
                <div class="attributes-list">
                    <ul>
                        <li>名称:<%=Product_Title %></li>
                        <li>品牌:<asp:Literal ID="litBrand" runat="server"></asp:Literal></li>
                        <li>型号:<asp:Literal ID="litProduct_xinhao" runat="server"></asp:Literal></li>
                        <li>货期:<asp:Literal ID="litProduct_huoqi" runat="server"></asp:Literal></li>
                        
                    </ul>
                </div>
                <div class="description mar25">
                   <%=Product_Content %>
                </div>
                <div class="evaluate">
                    <h2>商品评价详情</h2>
                    <div class="evaluate_cont">
                        <div class="comment">
                            <div class="mc tabcon">
                                <div class="mc tabcon">
                                    <div class="i-comment">
                                        <div class="rate">
                                            <strong>
                                                <asp:Literal ID="litGoodScroe" runat="server"></asp:Literal></strong>
                                            <br>
                                            好评度
                                        </div>
                                        <div class="percent">
                                            <dl>
                                                <dt>好评</dt>
                                                <dd class="d1">
                                                    <asp:Literal ID="litGoodWith" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litGoodScroe1" runat="server"></asp:Literal></dd>
                                            </dl>
                                            <dl>
                                                <dt>中评</dt>
                                                <dd class="d1">
                                                    <asp:Literal ID="litCenterWith" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litCenterScroe" runat="server"></asp:Literal></dd>
                                            </dl>
                                            <dl>
                                                <dt>差评</dt>
                                                <dd class="d1">
                                                   <asp:Literal ID="litPoorWith" runat="server"></asp:Literal>
                                                </dd>
                                                <dd class="d2">
                                                    <asp:Literal ID="litPoorScroe" runat="server"></asp:Literal></dd>
                                            </dl>
                                        </div>
                                        <div class="actor">
                                            <strong>
                                                <asp:Literal ID="litScroe" runat="server"></asp:Literal>分 </strong><br />评价得分
                                        </div>
                                        <div class="btns">
                                            共有<%=EvaluateZongCount %>人评价>></div>
                                    </div>
                                </div>
                                <asp:Repeater runat="server" ID="repeaterEvaluateList" 
                                    onitemdatabound="repeaterEvaluateList_ItemDataBound">
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
                                            <asp:Literal ID="lit_JieShi" runat="server"></asp:Literal>
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
                <div class="evaluate ">
                    <asp:Literal ID="litgdsppj" runat="server"></asp:Literal>
                   <!--
                    <div class="consult">
                        <div class="search">
                            <div class="i-search1">
                                <strong>咨询前请先搜索，方便又快捷：</strong><input class="text" id="txbReferSearch" value="请输入咨询关键词"
                                    type="text">
                                <input name="button" type="button" class="btn_gray_big" value="搜索" />
                            </div>
                            <div class="i-search2">
                                <strong>温馨提示:</strong>因厂家更改产品包装、产地或者更换随机附件等没有任何提前通知，且每位咨询者购买情况、提问时间等不同，为此以下回复仅对提问者3天内有效，其他网友仅供参考！若由此给您带来不便请多多谅解，谢谢！</div>
                        </div>
                        <div class="item">
                            <div class="user ">
                                <span class="u-name">网友：shanhuhai1379</span> <span class="u-level" name="shanhuhai1379">
                                    <em style="color: rgb(153, 153, 153);">铜牌会员</em></span> <span class="date-ask">2010-10-19
                                        19:58</span>
                            </div>
                            <dl class="ask">
                                <dt><b></b>咨询内容：</dt>
                                <dd>
                                    请问我499元刚买的，才两天就降到415元了，为什么，不理解</dd>
                            </dl>
                            <dl class="answer">
                                <dt><b></b>工控回复：</dt>
                                <dd>
                                    <div class="content">
                                        您好！抱歉，请提供详细的订单编号致电我司客服为您核实处理。感谢您对工控的支持！祝您购物愉快！</div>
                                    <div class="date-answer">
                                        2010-10-20 09:58</div>
                                </dd>
                            </dl>
                            <div class="useful">
                                您对我们的回复： <a href="" class="Ablue">满意</a> (<span>0</span>)&nbsp;&nbsp; <a href=""
                                    class="Ablue">不满意</a> (<span>1</span>)
                            </div>
                        </div>
                    </div>
                    -->
                    <!--tabcon end-->
                </div>        
               </div>
                <div id="div2" style="display: none" class="divContent">
                <div style="height:10px;" > </div>
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
                                            共有<%=EvaluateZongCount %>>人评价>></div>
                                    </div>
                                </div>
                                <asp:Repeater runat="server" ID="repeaterEvaluateList1">
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
                    <asp:Literal ID="litgdsppj1" runat="server"></asp:Literal>
                </div>   
                <div class="clear"></div>                 
               <!-- <div class="pages pdL10" >
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  UrlPageIndexName="Page"></webdiyer:AspNetPager>
                </div>-->
               </div>
              <div id="div3" style="display: none" class="divContent">3        
               </div>
                
            </div>
            <!-- right end -->
        </div>
        <!-- productsection-->
        <!-- end -->
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
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
