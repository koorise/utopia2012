<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.ProductMemberDiscount.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $("document").ready(function() {
        $('document').thumbShow({ PicList: $(".PictureThumb") });
    });

    function SetDiscount(ProductID, UserID, Type, BasicDiscount, Discount) {
        if (Discount < BasicDiscount) {
            alert("�˲�Ʒ�ۿ�С�ڻ�׼�ۿ���Ҫ���");
            $("#txtDiscount" + Type + ProductID).val($("#txtHid" + Type + ProductID).val()); 
            return;    
        }

        $.getJSON(
            "/Service/ProductMemberDiscount.aspx?callback=?",
            { "Type": Type, "ProductID": ProductID, "UserID": UserID, "BasicDiscount": BasicDiscount, "Discount": Discount },
            function(data) {

                if (data.Result == "OK") {
                    //�ͺ�,�۸�,����
                    $("#lblStatus" + ProductID).html(data.Status);
                    $("#lbl" + Type + ProductID).html("��");
                    $("#txtHid" + Type + ProductID).val($("#txtDiscount" + Type + ProductID).val())

                }
                else {
                    alert(data.Result);                    
                    $("#txtDiscount" + Type + ProductID).val($("#txtHid" + Type + ProductID).val());                    
                }
            })
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		��Ʒ���ƣ�<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:DropDownList ID="dropBig" runat="server" Width="100px" 
            onselectedindexchanged="dropBig_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
		<asp:DropDownList ID="dropSmall" runat="server" Width="100px" 
            onselectedindexchanged="dropSmall_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="����" />
        <asp:HyperLink ID="HyperLinkBack" runat="server">[�����б�]</asp:HyperLink>
	</asp:Panel>
</div>
<div class="admin_table mb10"></div>
<h2 class="h1"><span class="mr10 fl"><asp:Label ID="txtUserName" runat="server" Text="" ForeColor="Blue"></asp:Label>��Ʒ�ۿ�����</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" PageSize="50" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
		<Columns>
			<asp:TemplateField HeaderText="">
				<HeaderTemplate><input type="checkbox" id="chkSelectAll"></HeaderTemplate>
				<ItemTemplate><asp:CheckBox ID="chkID" runat="server" /></ItemTemplate>
				<ItemStyle cssclass="td2" Width="20" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="ͼƬ">
				<ItemTemplate>	
				<img class="PictureThumb" src='<%# Eval("PictureSmall") %>' width="16" height="16" alt="<%# Eval("PictureBig") %>"/>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="��Ʒ����">
				<ItemTemplate>				
				<%# Eval("Title") %><asp:HiddenField ID="txtID" runat="server" Value='<%# Eval("ID") %>' />
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="��Ʒ���">
				<ItemTemplate><%# Eval("ProductCategory")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="�۸�">
				<ItemTemplate><%# Eval("DefaultPrice")%>Ԫ</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="�۸��׼�ۿ�">
				<ItemTemplate><b style="color:blue; font-size:18px"><%# Eval("BasicDiscountPrice")%>%</b></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="�۸��ۿ�">
				<ItemTemplate>
				<input type="text" Class="input input_we"  style="color:Green" ID="txtDiscountPrice<%# Eval("ID") %>" value='<%# Eval("DiscountPrice")%>' onchange='SetDiscount(<%# Eval("ID")%>, <%=UserID%>, "Price", <%# Eval("BasicDiscountPrice")%>, this.value)' />%
				<input type="hidden" ID="txtHidPrice<%# Eval("ID") %>" value='<%# Eval("DiscountPrice")%>' />
				<span id="lblPrice<%# Eval("ID") %>" style="color:green"></span>
				</ItemTemplate>
				<ItemStyle cssclass="td2" Width="100px"  />
			</asp:TemplateField> 				
			<asp:TemplateField HeaderText="����">
				<ItemTemplate><%# Eval("DefaultJF")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="���ֻ�׼�ۿ�">
				<ItemTemplate><b style="color:blue; font-size:18px"><%# Eval("BasicDiscountJF")%>%</b></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="�����ۿ�">
				<ItemTemplate>
				<input type="text" Class="input input_we" style="color:Green" ID="txtDiscountJF<%# Eval("ID") %>" value='<%# Eval("DiscountJF")%>' onchange='SetDiscount(<%# Eval("ID")%>, <%=UserID%>, "JF", <%# Eval("BasicDiscountJF")%>, this.value)' />%
				<input type="hidden" ID="txtHidJF<%# Eval("ID") %>" value='<%# Eval("DiscountJF")%>' />
				<span id="lblJF<%# Eval("ID") %>" style="color:green"></span>
				</ItemTemplate>
				<ItemStyle cssclass="td2" Width="100px" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="״̬">
				<ItemTemplate><span id="lblStatus<%# Eval("ID") %>"><%# GK2010.Utility.StringHelper.GetStrFlag(Eval("CheckFlag"), "������", "δ���", "δ����")%></span></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 						
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />
	</asp:GridView>
</div>

<div id="divOperator" class="mb10" style="border:1px solid orange; padding:10px; float:left">
�������ã�<input type="button" ID="btnSelectAll" value="ȫѡ" class="btn_gray_small" /><input type="button" ID="btnCancelAll" value="ȡ��" class="btn_gray_small" />
�۸��ۿۣ�<asp:TextBox ID="txtDiscountPrice" runat="server" CssClass="input" Text="100" Width="25"></asp:TextBox> %
�����ۿۣ�<asp:TextBox ID="txtDiscountJF" runat="server" CssClass="input" Text="100"  Width="25"></asp:TextBox> %
<asp:Button ID="btnSetBatch" runat="server" cssclass="btn_yellow_small" Text="����" CausesValidation="false" OnClick="btnSetBatch_Click" />
</div>
<div id="divPage" class="pages">
	<webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
</div>
</asp:Content>