<%@ Page Title="" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="newsAdd.aspx.cs" Inherits="Management_newsAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="main-content"> 
<div class="content-box"> 
				
				<div class="content-box-header">
					
					<h3>新闻</h3>
					
					<ul class="content-box-tabs">
						<li><a href="#tab1" class="default-tab">添加</a></li> <!-- href must be unique and match the id of target div -->
						 
					</ul>
					
					<div class="clear"></div>
					
				</div> <!-- End .content-box-header -->
				
				<div class="content-box-content">
					
					<div class="tab-content default-tab" id="tab1"> <!-- This is the target div. id must match the href of this div's tab -->
						 
					<table style="width: 100%; background-color:Black; font-size:12px;">
    <tr>
        <td style="width: 180px; text-align:right;  background-color:White;">标题：</td>
        <td style="text-align: left;background-color:White;">
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 180px; text-align:right;  background-color:White;">分类：</td>
        <td style="text-align: left;background-color:White;">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="width: 180px; text-align:right;  background-color:White;">内容：</td>
        <td style="text-align: left;background-color:White;">
            <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
              </td>
    </tr>
    <tr> 
        <td colspan="2" style="text-align: center; background-color:White;">
            <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" /></td>
    </tr>
</table>
						
					</div> <!-- End #tab1 -->
					
					  <!-- End #tab2 -->        
					
				</div> <!-- End .content-box-content -->
				
			</div>
</div>

    
</asp:Content>

