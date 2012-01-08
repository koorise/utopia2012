<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.Product.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/tipswindown.css" rel="stylesheet" type="text/css" />
    <script src="/JavaScript/jquery.tipswindow.js" type="text/javascript"></script> 
    <script src="/JavaScript/jquery.thumbShow.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("document").ready(function() {
            $('document').thumbShow({ PicList: $(".PictureThumb") });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

<div id="divSearch" class="admin_table mb10">
	<asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
		�ؼ��֣�<asp:TextBox ID="txtKey" runat="server" cssclass="input input_wa" ></asp:TextBox>
		<asp:DropDownList ID="dropBig" runat="server" Width="100px" 
            onselectedindexchanged="dropBig_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
		<asp:DropDownList ID="dropSmall" runat="server" Width="100px" 
            onselectedindexchanged="dropSmall_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
		<asp:Button ID="btnSearch" runat="server" cssclass="btn_gray_small" OnClick="btnSearch_Click" Text="����" /><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="���" />   
	    
	</asp:Panel>
</div>
<div class="admin_table mb10">
		
</div>
<h2 class="h1"><span class="mr10 fl">��Ʒ�����б�</span></h2>
<div id="divGrid" class="admin_table mb10" >
	<asp:GridView ID="grid" runat="server" OnRowDataBound="grid_RowDataBound" Width="100%" BorderWidth="0" AutoGenerateColumns="false" GridLines="None" >
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
				<%# Eval("Title") %>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="��Ʒ���">
				<ItemTemplate><%# GK2010.BLL.ProductCategory.GetTitle( Eval("RootID"))%> > <%# GK2010.BLL.ProductCategory.GetTitle( Eval("CategoryID"))%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="ԭ��">
				<ItemTemplate><%# Eval("DefaultPriceOld")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="�۸�">
				<ItemTemplate><%# Eval("DefaultPrice")%></ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 
			<asp:TemplateField HeaderText="ͼƬ">
				<ItemTemplate>
				<div id="img<%#Eval("ID")%>"><%# GK2010.Utility.StringHelper.GetPicture(Eval("PictureSmall"))%></div>
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField> 	
			<asp:TemplateField HeaderText="����" >
				<ItemTemplate>
				    <script type="text/javascript">
                        $(document).ready(function() {
                            $('document').tipswindow({
                                btnPost: $('#btnParts<%#Eval("ID")%>'), //�����ύ��ť
                                title: '<%#Eval("Title")%>-��������', //����
                                width: 900,         
                                height:460,                       
                                content: '/admin/ProductParts/manage.aspx?ProductID=<%#Eval("ID")%>', //����                               
                                clickOK: function() {return true;}
                            });
                        });
                        $(document).ready(function() {
                            $('document').tipswindow({
                            btnPost: $('#btnPicture<%#Eval("ID")%>'), //ͼƬ�ύ��ť
                            title: '<%#Eval("Title")%>-ͼƬ����', //����
                            height:245,
                            content: '/admin/ProductPicture/manage.aspx?ProductID=<%#Eval("ID")%>', //����                               
                            clickOK: function() { return true; }
                            });
                        });
                        $(document).ready(function() {
                            $('document').tipswindow({
                                btnPost: $('#btnVirtual<%#Eval("ID")%>'), //��������ύ��ť
                                title: '<%#Eval("Title")%>-�����������', //����
                                content: '/admin/ProductVirtual/manage.aspx?ProductID=<%#Eval("ID")%>', //����                               
                                clickOK: function() { return true; }
                            });
                        });
                     </script>                    
				    <asp:HyperLink ID="HyperLinkModify" runat="server">[�޸�]</asp:HyperLink>
				    <asp:HyperLink ID="HyperLinkDelete" Visible="false" runat="server">[ɾ��]</asp:HyperLink>				    		    
				    <a id='btnPicture<%#Eval("ID")%>' href="javascript:void(0)" >[ͼƬ]</a>
				    <a id='btnVirtual<%#Eval("ID")%>' href="javascript:void(0)" >[�������]</a>
				    <asp:Literal ID="txtParts" runat="server"></asp:Literal>		
				</ItemTemplate>
				<ItemStyle cssclass="td2" />
			</asp:TemplateField>
		</Columns>
		<RowStyle CssClass="tr1 vt" />
		<HeaderStyle CssClass="tr2" />
	</asp:GridView>
</div>
<div id="divPage" class="pages">
	<webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>
</div>
<div id="divOperator" class="tac mb10">
	<input type="button" ID="btnSelectAll" value="ȫѡ" class="btn_gray_small" /><input type="button" ID="btnCancelAll" value="ȡ��" class="btn_gray_small" /><asp:Button ID="btnDelete" runat="server" cssclass="btn_yellow_small" Text="ɾ��" CausesValidation="false" OnClick="btnDelete_Click" />
</div>

</asp:Content>