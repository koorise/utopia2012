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
                        alert("��ѡ������");
                        $("#<%=dropBig.ClientID %>").focus();
                        return false;
                    }
                
                    var SmallID = $("#<%=dropSmall.ClientID %>").attr("value");
                    if (SmallID == "" || SmallID == "0") {
                        alert("��ѡ��С���");
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
        ��Ʒ����</h2>
    <div class="admin_table mb10">
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="td1">
                    ��Ʒ���
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
                    ��Ʒ���ƣ�
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input input_wa" Width="311px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="����"></asp:RequiredFieldValidator>
                    ����Ʒƴ����<asp:TextBox ID="txtTitleEn" runat="server" CssClass="input input_wa" Width="209px"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    �������ã�
                </td>
                <td class="td2">
                    <asp:CheckBox ID="chkHotFlag" runat="server" Text="����ҳ�������" />
                    <asp:CheckBox ID="chkIndexFlag" runat="server" Text="����ҳ��Ʒר��" />
                    <asp:CheckBox ID="chkCommendFlag" runat="server" Text="����ҳ��Ʒ�Ƽ�" />
                    <asp:CheckBox ID="chkChannelFlag" runat="server" Text="Ƶ��ҳ�������" />
                    <asp:CheckBox ID="chkCategoryFlag" runat="server" Text="Ƶ��ҳ��Ʒ�Ƽ�" />
                    <asp:CheckBox ID="chkMemberFlag" runat="server" Text="��Ա�ɼ�" />
                    <asp:CheckBox ID="chkShowFlag" runat="server" Text="ǰ̨��ʾ" />
                </td>
                <td class="td2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="td1">
                    ֧��ѡ�ͣ�
                </td>
                <td class="td2">
                    <asp:CheckBox ID="chkDiyFlag" runat="server" Text="֧��ѡ��" />
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    Ʒ�ƣ�
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
                    ���ڣ�
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
                    ԭ�ۣ�
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultPriceOld" runat="server" CssClass="input input_wa" Text="0"></asp:TextBox>
                    Ԫ
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    �ּۣ�
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultPrice" runat="server" CssClass="input input_wa" Text="0"></asp:TextBox>
                    Ԫ���۸��׼�ۿۣ�<asp:TextBox ID="txtBasicDiscountPrice" runat="server" CssClass="input input_wa"
                        Text="100" Width="40px">100</asp:TextBox>% ,��ע�⣺֧��ѡ�͵Ĳ�Ʒ�۸�Ҫ�
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    ���֣�
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtDefaultJF" runat="server" CssClass="input input_wa">0</asp:TextBox>
                    �֣����ֻ�׼�ۿۣ�<asp:TextBox ID="txtBasicDiscountJF" runat="server" CssClass="input input_wa"
                        Text="100" Width="40px">100</asp:TextBox>%
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    ����������
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
        <asp:Button ID="btnAdd" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnAdd_Click">
        </asp:Button>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
