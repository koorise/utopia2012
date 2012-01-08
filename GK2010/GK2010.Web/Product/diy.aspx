<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"   CodeBehind="diy.aspx.cs" Inherits="GK2010.Web.Product.diy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/product_detail.css" rel="stylesheet" type="text/css" />
    <link href="/css/grant.css" rel="stylesheet" type="text/css" />
    
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
    <script type="text/javascript">
        function changeTab(index) {
            for (var i = 1; i <= 3; i++) {
                document.getElementById("li_" + i).className = "";
                document.getElementById("li_" + index).className = "bg f14 B";
                document.getElementById("div" + i).style.display = "none";
            }
            document.getElementById("div" + index).style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function ChangeOption(radRootControl, SelectID) {
            var i = 0;
            var litModelType="";
            var litOriginalPrice=0;
            var litMemberPrice=0;
            var litJF;
            var partsList="";
            $(".ppradio").each(function () {
                if ($(this).attr("checked")) {
                    var v = $(this).attr("value").split('$');
                    litModelType += v[1] + ",";
                    litOriginalPrice += parseFloat(v[3]);
                    litMemberPrice += parseFloat(v[3]);
                    partsList += "<li><a href='#'>" + v[4] + " 型号：" + v[2] + "(" + v[1] + ")</a></li>";

                }
            });
            $("#litModelType").html(litModelType.substring(0, litModelType.length - 1));
            $("#litOriginalPrice").html(litOriginalPrice);
            $("#litMemberPrice").html(litMemberPrice);
            $("#partsList").html(partsList);
        }
        function SetFj(flag, SelectID) { 
            if (flag) {
                $("." + SelectID).addClass("ppradio");
            }
            else {
                $("." + SelectID).removeClass("ppradio");
            }
            ChangeOption("", "");
        }
        function ajaxSubmit() {
            var Url = "/product_modelselect_handle.aspx";
            var urlParam = "pid="+$("#litProductID").val()+"&ppid=";
            var pp = "";
            var ppCN = "";
            var ppEN = "";
            var ppPrice = 0;
            $(".ppradio").each(function () {
                if ($(this).attr("checked")) {

                    var v = $(this).attr("value").split('$');
                    ppEN += v[1] + "|";
                    ppCN += v[2] + "|";
                    ppPrice += parseFloat(v[3]);
                    pp += v[0] + "|";
                }
            });
            pp = pp.substring(0, pp.length - 1);
            ppCN = ppCN.substring(0, ppCN.length - 1);
            ppEN = ppEN.substring(0, ppEN.length - 1);
            urlParam = urlParam + pp+"&ppCN="+ppCN+"&ppEN="+ppEN+"&ppPrice="+ppPrice;
            location.href = Url+"?"+urlParam;
             
        }
        $(function () {
            $(".ppradio").click(function () {
                var chk = $("input[@type=radio][@checked]").val();
                for (var i = 0; i < chk.Length; i++) {
                    alert(chk[i]);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="navigator">
        <a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="/product/">产品中心</a>&nbsp;&gt;&nbsp;<asp:HyperLink
            ID="HyperLinkBig" runat="server"></asp:HyperLink>&nbsp;&gt;&nbsp;<asp:HyperLink ID="HyperLinkSmall" runat="server"></asp:HyperLink>
    </div>
    <div class="main grant mdT8">
        <div class="left">
            <div class="hd">
            
            </div>
            <div class="bd">
               <div class="commodity_list mdT10 pdL5">
                    <div class="commodity_list_nav">
                        <ul>
                            <li id="li_1" class="bg f14 B" onclick="changeTab('1')" style="cursor:pointer">1 基本型号</li>                           
                            <li id="li_2" onclick="changeTab('2')" style="cursor:pointer">2 附件型号</li>
                            <li id="li_3" onclick="changeTab('3')" style="cursor:pointer">3 参数设置</li>
                        </ul>
                    </div>
                    <div class="right_bottom"></div>
                </div>
               <div id="div1" style="display: block" class="divContent">
               <div class="cont" style="">
                   <asp:Label ID="lblTxta" runat="server" Text="Label"></asp:Label>
                 </div>
               </div>
                <div id="div2" style="display: none" class="divContent">
                <div class="cont" style="">
                   <asp:Label ID="lblTxtb" runat="server" Text="Label"></asp:Label>
                </div> 
               </div>
               <div id="div3" style="display: none" class="divContent">3        
               </div>
            
                
            </div>
            <div class="ft">
            </div>
        </div>
        <div class="right">
            <div class="hd">
                <h2>
                    配置型号</h2>
            </div>
            <div class="bd">
                <table class="wp95 bg_white">
                    <tr>
                        <td>
                            型号:<asp:Literal ID="litModelType" runat="server"></asp:Literal><br />
                            原价:<asp:Literal ID="litOriginalPrice" runat="server"></asp:Literal>
                            <br />
                            会员价:<asp:Literal ID="litMemberPrice" runat="server"></asp:Literal>
                            <br />
                            积分:<asp:Literal ID="litJF" runat="server"></asp:Literal>
                            <asp:Literal ID="litBasicDiscountPrice" runat="server"></asp:Literal>
                            <asp:Literal ID="litProductID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_c">
                            <img src="/images/button06.jpg"  width="127" height="36" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_c">
                            <img src="/images/button07.jpg" onclick="ajaxSubmit()" style=" cursor:pointer;" width="127" height="36" />
                        </td>
                    </tr>
                </table>
                <table class="wp95">
                    <tr>
                        <td class="bg">
                            配置清单
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ul id="partsList">
                                <asp:Literal ID="litPartsList" runat="server"></asp:Literal> 
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ft">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
