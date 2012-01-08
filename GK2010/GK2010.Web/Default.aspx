<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <!--left start -->
        <div class="left mar5 ">
            <!--product left start-->
            <gk:ProductLeft ID="ProductLeft1" runat="server" />
            <!--product left end-->
            <div class="brand_section">
                <h2>
                    <span><a href="">更多>></a></span>品牌专区</h2>
                <ul>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                    <li><a href="">
                        <img src="/images/pc01.jpg" /></a></li>
                </ul>
            </div>
            <div class="technology_support">
                <h2>
                    <span><a href="">更多>></a></span>技术支持</h2>
                <ul>
                    <li><a href="">什么是超声的频率、声速和波长</a></li>
                    <li><a href="">防爆基本知识理化仪器对比</a></li>
                    <li><a href="">干燥箱与真空干燥与真空干燥与真空干燥箱的区别干燥</a></li>
                    <li><a href="">湿度传感器选择的注意</a></li>
                    <li><a href="">事项检测数据处理基础知</a></li>
                    <li><a href="">识涡轮流量计注意事项涡</a></li>
                    <li><a href="">轮流量计的安装阀</a></li>
                    <li><a href="">门的主要技术性能</a></li>
                </ul>
            </div>
            <div id="comment">
                <div class="news_comment">
                    <h2>
                        <span><a href="">更多>></a></span>最新热评</h2>
                    <dl>
                        <dt><a href="">铁三角！再续当年的</a></dt>
                        <dd class="img">
                            <a href="">
                                <img src="/images/pc02.jpg" /></a></dd>
                        <dd>
                            <a href="">不知还有多少人想起当年广为流行的</a></dd>
                    </dl>
                    <dl>
                        <dt><a href="">铁三角！再续当年的</a></dt>
                        <dd class="img">
                            <a href="">
                                <img src="/images/pc02.jpg" /></a></dd>
                        <dd>
                            <a href="">不知还有多少人想起当年广为流行的</a></dd>
                    </dl>
                    <dl>
                        <dt><a href="">铁三角！再续当年的</a></dt>
                        <dd class="img">
                            <a href="">
                                <img src="/images/pc02.jpg" /></a></dd>
                        <dd>
                            <a href="">不知还有多少人想起当年广为流行的</a></dd>
                    </dl>
                </div>
            </div>
        </div>
        <!--left end -->
        <!--right start-->
        <div class="right_cont">
            <div class="right_cont1">
                <div class="right_left">
                    <div class="adv">
                        <gk:Slide ID="Slide1" runat="server" Width="536" Height="226" Category="Index" />
                    </div>
                    <div class="buying mar5">
                        <h2>
                            疯狂抢购</h2>
                        <div class="buy_cont">
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
                            <dl class="line">
                                <dt class="s120 pic"><a href=" " target="_blank">
                                    <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                                <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                                <dd class="good-market-price">
                                    市场价：<s>4080</s></dd>
                                <dd class="good-price">
                                    <span>3138</span></dd>
                            </dl>
                        </div>
                    </div>
                    <!-- 新品专区 -->
                    <div class="news_section mar5">
                        <h2>
                            <span><a href="">更多>></a></span>新品专区</h2>
                        <div class="buy_cont1">
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
                            <dl class="line">
                                <dt class="s120 pic"><a href=" " target="_blank">
                                    <img src="/images/chanp_pc01.jpg" alt="MOTO XT702"></a></dt>
                                <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                                <dd class="good-market-price">
                                    市场价：<s>4080</s></dd>
                                <dd class="good-price">
                                    <span>3138</span></dd>
                            </dl>
                        </div>
                    </div>
                    <!-- 新品专区end -->
                </div>
                <div class="right_right">
                    <!-- 商城公告 -->
                    <div class="Shop_notice">
                        <h2>
                            <span><a href="">更多>></a></span>商城公告</h2>
                        <ul>
                            <li><a href="">什么是超声的频率、声速和波长</a></li>
                            <li class="org"><a href="">防爆基本知识理化仪器对比</a></li>
                            <li><a href="">干燥箱与真空干燥与真空干燥与真空干燥箱的区别干燥</a></li>
                            <li><a href="">湿度传感器选择的注意</a></li>
                            <li><a href="">事项检测数据处理基础知</a></li>
                            <li class="org"><a href="">识涡轮流量计注意事项涡</a></li>
                            <li><a href="">轮流量计的安装阀</a></li>
                            <li><a href="">门的主要技术性能</a></li>
                        </ul>
                    </div>
                    <!-- 商城公告end -->
                    <div class="huiyuan">
                        <div class="huiyuan_button">
                            <a href="">
                                <img src="/images/huiyuan_button.jpg" alt="会员注册" /></a>
                        </div>
                        <a href="">新手帮助</a>|<a href="">新手帮助</a>|<a href="">注册有礼</a>
                        <ul>
                            <li><a href="/会员登录/会员登录.asp">会员登陆</a> </li>
                            <li><a href="/会员登录/用户注册.asp">会员注册</a> </li>
                            <li><a href="">证书申请</a> </li>
                            <li><a href="">证书延期</a> </li>
                        </ul>
                    </div>
                    <div class="download">
                        <h2>
                            <span><a href="">更多>></a></span>下载中心</h2>
                        <ul>
                            <li><a href="">什么是超声的频率、声速和波长</a></li>
                            <li class="org"><a href="">防爆基本知识理化仪器对比</a></li>
                            <li><a href="">干燥箱与真空干燥与真空干燥与真空干燥箱的区别干燥</a></li>
                            <li><a href="">湿度传感器选择的注意</a></li>
                            <li><a href="">事项检测数据处理基础知</a></li>
                            <li class="org"><a href="">识涡轮流量计注意事项涡</a></li>
                            <li><a href="">轮流量计的安装阀</a></li>
                            <li><a href="">门的主要技术性能</a></li>
                            <li><a href="">轮流量计的安装阀</a></li>
                            <li><a href="">门的主要技术性能</a></li>
                        </ul>
                    </div>
                    <div class="adv02 mar5">
                        <img src="/images/adv02.jpg" />
                    </div>
                </div>
            </div>
            <!-- 最新推荐 -->
            <div class="recommend_news">
                <h2>
                    <span><a href="">更多>></a></span>最新推荐</h2>
                <div class="recommend_cont">
                    <div class="buy_cont2">
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
                            <dt class="good-name"><a href=" " target="_blank">MOTO XT702</a></dt>
                            <dd class="good-market-price">
                                市场价：<s>4080</s></dd>
                            <dd class="good-price">
                                <span>3138</span></dd>
                        </dl>
                    </div>
                    <!-- 解答中心 -->
                    <div class="answer">
                        <h2>
                            <span><a href="">更多>></a></span>解答中心</h2>
                        <dl>
                            <dt><a href="">铁三角！再续当年的</a></dt>
                            <dd class="img">
                                <a href="">
                                    <img src="/images/pc02.jpg" /></a></dd>
                            <dd>
                                <a href="">不知还有多少人想起当年广为流行的</a></dd>
                        </dl>
                        <ul>
                            <li><span>待解答</span><a href="">什么是超声的频率、声速和波长</a></li>
                            <li><span>待解答</span><a href="">防爆基本知识理化仪器对比</a></li>
                            <li><span>待解答</span><a href="">干燥箱与真空干燥与真空干燥与真空干燥箱的区别干燥</a></li>
                            <li><span>待解答</span><a href="">湿度传感器选择的注意</a></li>
                            <li><span>待解答</span><a href="">事项检测数据处理基础知</a></li>
                            <li><span>待解答</span><a href="">识涡轮流量计注意事项涡</a></li>
                            <li><span>待解答</span><a href="">轮流量计的安装阀</a></li>
                            <li><span>待解答</span><a href="">门的主要技术性能</a></li>
                            <li><span>待解答</span><a href="">轮流量计的安装阀</a></li>
                            <li><span>待解答</span><a href="">门的主要技术性能</a></li>
                        </ul>
                    </div>
                    <!-- 解答中心end -->
                </div>
            </div>
            <!-- 最新推荐end -->
        </div>
        <!--right end -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
