<%@ Page Title="" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="imgManage.aspx.cs" Inherits="Management_imgManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="main-content"> 
<div class="content-box"> 
				
				<div class="content-box-header">
					
					<h3>田园展示</h3>
					
					<ul class="content-box-tabs">
						<li><a href="#tab1" class="default-tab">添加</a></li> <!-- href must be unique and match the id of target div -->
						 
					</ul>
					
					<div class="clear"></div>
					
				</div> <!-- End .content-box-header -->
				
				<div class="content-box-content">
					
					<div class="tab-content default-tab" id="tab1"> <!-- This is the target div. id must match the href of this div's tab -->
						 
						<table style="width: 100%; background-color:Black;font-size:12px;" cellspacing="1">
    <tr>
        <td style="background-color: white;width:120px; text-align:right;"> 分类：</td>
        <td style="background-color: white"><asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="更改" onclick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="删除" onclick="Button3_Click" />
        </td>
    </tr>
    <tr>
        <td style="background-color: white;width:120px; text-align:right;">标题：</td>
        <td style="background-color: white">
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox></td>
    </tr>
     
    <tr>
        <td style="background-color: white;width:120px; text-align:right; vertical-align:top;">介绍：</td>
        <td style="background-color: white">
            <asp:TextBox ID="TextBox2" runat="server" Height="121px" TextMode="MultiLine" 
                Width="387px"></asp:TextBox>
        </td>
    </tr>
     
        <td style="background-color: white;width:120px; text-align:right;">上传图片：</td>
        <td style="background-color: white">
            <asp:FileUpload ID="FileUpload1" runat="server"  /></td>
    </tr>
    <tr>
        
        <td style="background-color: white;width:120px; text-align:right;">首页显示：</td>
        <td style="background-color: white">
            <asp:CheckBox ID="CheckBox1" runat="server"  />
             </td>
    </tr>
    <tr>
     
        <td style="background-color: white;width:120px; text-align:right;">&nbsp;</td>
        <td style="background-color: white">
            <asp:Button ID="btnUpload" runat="server"
                Text="提交" onclick="btnUpload_Click" /></td>
    </tr>
</table>
						 
						
					</div> <!-- End #tab1 -->
					
					  <!-- End #tab2 -->        
					
				</div> <!-- End .content-box-content -->
				
			</div>
</div>


     
</asp:Content>

