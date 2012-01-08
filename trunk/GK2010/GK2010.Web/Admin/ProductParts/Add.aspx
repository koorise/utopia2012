<%@ Page Title="" Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GK2010.Web.Admin.ProductParts.Add"  ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<h2 class="h1"><asp:Label ID="lblAttachFlag" runat="server" Text=""></asp:Label>����</h2>
<div class="admin_table mb10">
<table cellSpacing="0" cellPadding="0" width="100%" >
	<tr>
		<td class="td1">�ϼ����</td>
		<td class="td2"><asp:Literal ID="txtParentID" runat="server"></asp:Literal></td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr id="tdAttachment" runat="server">
		<td class="td1">���ͣ�</td>
		<td class="td2">
           <asp:RadioButtonList ID="radAttachment" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="2">����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdShowFlag" runat="server">
		<td class="td1">ǰ̨��ʾ��</td>
		<td class="td2">
           <asp:RadioButtonList ID="radShowFlag" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="1" Selected="True">��</asp:ListItem>
                <asp:ListItem Value="0">��</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdTitle" runat="server">
		<td class="td1"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>��</td>
		<td class="td2">
			<asp:TextBox id="txtTitle" runat="server" cssclass="input input_wa" Width="400px" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="����"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdTitleEn" runat="server">
		<td class="td1"><asp:Label ID="lblTitleEn" runat="server" Text=""></asp:Label>��</td>
		<td class="td2">
			<asp:TextBox id="txtTitleEn" runat="server" cssclass="input input_wa" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTitleEn" Display="Dynamic" ErrorMessage="����"></asp:RequiredFieldValidator>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdPrice" runat="server">
		<td class="td1">
            <asp:Label ID="lblPrice" runat="server" Text="�����۸�"></asp:Label>��</td>
		<td class="td2">
			<asp:TextBox id="txtPrice" runat="server" cssclass="input input_wa" Text="0" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr id="tdDefaultFlag" runat="server">
		<td class="td1">Ĭ��ѡ�</td>
		<td class="td2">
           <asp:RadioButtonList ID="radDefaultFlag" runat="server"  RepeatDirection="Horizontal">                
                <asp:ListItem Value="1">��</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">��</asp:ListItem>
            </asp:RadioButtonList>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>	
	<tr id="tdDetail" runat="server">
		<td class="td1">�˽���ࣺ</td>
		<td class="td2">
			<fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/" Height="250px" ToolbarSet="Basic" Width="100%"></fckeditorv2:FCKeditor>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
	<tr>
		<td class="td1">����</td>
		<td class="td2">
			<asp:TextBox id="txtSortID" runat="server" cssclass="input input_wd" ></asp:TextBox>
		</td>
		<td class="td2"><div class="help_a"></div></td>
	</tr>
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnBack" runat="server" Text="�� ��" CssClass="btn_gray_big" CausesValidation="false" OnClick="btnBack_Click" ></asp:Button><asp:Button ID="btnAdd" runat="server" Text="�� ��" CssClass="btn_yellow_big" OnClick="btnAdd_Click" ></asp:Button></div>

</asp:Content>
