<%@ Page Title="" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Management_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content"> 
<div class="content-box"> 
				
				<div class="content-box-header">
					
					<h3>新闻</h3>
					
					<ul class="content-box-tabs">
						<li><a href="#tab1" class="default-tab">列表</a></li> <!-- href must be unique and match the id of target div -->
						 
					</ul>
					
					<div class="clear"></div>
					
				</div> <!-- End .content-box-header -->
				
				<div class="content-box-content">
					
					<div class="tab-content default-tab" id="tab1"> <!-- This is the target div. id must match the href of this div's tab -->
						 
						
						<table>
							
							<thead>
								<tr> 
								   <th>ID</th>
								   <th>标题</th> 
								   <th>操作</th> 
								</tr>
								
							</thead>
						 
							<tfoot>
								<tr>
									<td colspan="4">
										 
										
										<asp:Literal ID="Literal2" runat="server"></asp:Literal>
										<div class="clear"></div>
									</td>
								</tr>
							</tfoot>
						 
							<tbody>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
								 
							</tbody>
							
						</table>
						
					</div> <!-- End #tab1 -->
					
					  <!-- End #tab2 -->        
					
				</div> <!-- End .content-box-content -->
				
			</div>
</div>
</asp:Content>