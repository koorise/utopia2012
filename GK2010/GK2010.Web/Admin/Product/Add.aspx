<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.Product.Add" ValidateRequest="false"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JavaScript/jquery.post.js" type="text/javascript"></script>

    <script type="text/javascript" src="/javascript/jquery.ProductCategory.js"></script>

    <script type="text/javascript">
        $("document").ready(function() {
            //category start
            $('document').ProductCategory({
                defaultSmall: false,
                defaultSmallID: "",
                hasHead:true,
                dropBig: $("#<%=dropBig.ClientID %>"),
                dropSmall: $("#<%=dropSmall.ClientID %>")
            });
            //category start            

            //post start
            $('document').post({
                btnPost: $("#<%=btnAdd.ClientID %>"),
                click: function(event) {
                    var BigID = $("#<%=dropBig.ClientID %>").attr("value");
                    if (BigID == "" || BigID == "0") {
                        alert("请选择大类别");
                        $("#<%=dropBig.ClientID %>").focus();
                        return false;
                    }
                
                    var SmallID = $("#<%=dropSmall.ClientID %>").attr("value");
                    if (SmallID == "" || SmallID == "0") {
                        alert("请选择小类别");
                        $("#<%=dropSmall.ClientID %>").focus();
                        return false;
                    }

                    return true;
                }
            });
            //post end        
        })   
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <h2 class="h1">
        产品新增</h2>
    <div class="admin_table mb10">
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="td1">
                    产品类别：
                </td>
                <td class="td2">
                    <asp:DropDownList ID="dropBig" runat="server" Width="100px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="dropSmall" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    产品名称：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                    ，产品拼音：<asp:TextBox ID="txtTitleEn" runat="server" CssClass="input input_wa" Width="209px"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    参数设置：
                </td>
                <td class="td2">
                    <asp:CheckBox ID="chkHotFlag" runat="server" Text="总首页疯狂抢购" />
                    <asp:CheckBox ID="chkIndexFlag" runat="server" Text="总首页新品专区" />
                    <asp:CheckBox ID="chkCommendFlag" runat="server" Text="总首页新品推荐" />
                    <asp:CheckBox ID="chkChannelFlag" runat="server" Text="频道页疯狂抢购" />
                    <asp:CheckBox ID="chkCategoryFlag" runat="server" Text="频道页产品推荐" />
                    <asp:CheckBox ID="chkMemberFlag" runat="server" Text="会员可见" />
                    <asp:CheckBox ID="chkShowFlag" runat="server" Text="前台显示" />
                </td>
                <td class="td2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="td1">
                    支持选型：
                </td>
                <td class="td2">
                    <asp:CheckBox ID="chkDiyFlag" runat="server" Text="支持选型" />
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    品牌：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultBrand" runat="server" CssClass="input input_wa"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    货期：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultPeriod" runat="server" CssClass="input input_wa"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    原价：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultPriceOld" runat="server" CssClass="input input_wa" Text="0"></asp:TextBox>
                    元
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    现价：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultPrice" runat="server" CssClass="input input_wa" Text="0"></asp:TextBox>
                    元，价格基准折扣：<asp:TextBox ID="txtBasicDiscountPrice" runat="server" CssClass="input input_wa"
                        Text="100" Width="40px">100</asp:TextBox>% ,（注意：支持选型的产品价格不要填）
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    积分：
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultJF" runat="server" CssClass="input input_wa">0</asp:TextBox>
                    分，积分基准折扣：<asp:TextBox ID="txtBasicDiscountJF" runat="server" CssClass="input input_wa"
                        Text="100" Width="40px">100</asp:TextBox>%
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    技术参数：
                </td>
                <td class="td2">
                    <fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/"
                        Height="400px" ToolbarSet="Default" Width="100%">
                    </fckeditorv2:FCKeditor>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <gk:AdminIndustry ID="AdminIndustry1" runat="server" />
            <gk:AdminMedium ID="AdminMedium1" runat="server" />
            <gk:AdminTag ID="AdminTag1" runat="server" />
            <gk:AdminSEO ID="AdminSEO1" runat="server" />
        </table>
    </div>
    <div class="tac mb10">
        <gk:AdminGoBack ID="AdminGoBack1" runat="server" />
        <asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="btn_yellow_big" OnClick="btnAdd_Click">
        </asp:Button>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
