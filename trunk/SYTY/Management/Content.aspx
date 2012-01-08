<%@ Page Title="" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Management_Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
     
     <div id="main-content"> 
<div class="content-box"> 
				
				<div class="content-box-header">
					
					<h3>    <asp:Literal ID="Literal1" runat="server"></asp:Literal></h3>
					
					<ul class="content-box-tabs">
						<li><a href="#tab1" class="default-tab">更改</a></li> <!-- href must be unique and match the id of target div -->
						 
					</ul>
					
					<div class="clear"></div>
					
				</div> <!-- End .content-box-header -->
				
				<div class="content-box-content">
					
					<div class="tab-content default-tab" id="tab1"> <!-- This is the target div. id must match the href of this div's tab -->
						 
						
<CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
<center>
    <asp:Button ID="Button1" runat="server" Text="更新" onclick="Button1_Click" />
    <br />
    </center>
    <p>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    </p>
						
					</div> <!-- End #tab1 -->
					
					  <!-- End #tab2 -->        
					
				</div> <!-- End .content-box-content -->
				
			</div>
</div>
 
     
 

</asp:Content>

