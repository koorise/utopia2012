<%@ Page Title="人才招聘" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recruit.aspx.cs" Inherits="Recruit" %>
<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
<style TYPE="text/css" > 
    <!--
    /*
	* { margin: 0; padding: 0; }
	body {font-family: Verdana, Arial; font-size: 12px; line-height: 18px; }
	a { text-decoration: none; }
	.container{margin: 20px auto; width: 900px; background: #fff;}
	h3 { margin-bottom: 15px; font-size: 22px; text-shadow: 2px 2px 2px #ccc; }
	*/
	#contactform {
	
	width: 500px;
	padding: 20px;
	background: #f0f0f0;
	overflow:auto;
	
	border: 1px solid #cccccc;
	-moz-border-radius: 7px;
	-webkit-border-radius: 7px;
	border-radius: 7px;	
	
	-moz-box-shadow: 2px 2px 2px #cccccc;
	-webkit-box-shadow: 2px 2px 2px #cccccc;
	box-shadow: 2px 2px 2px #cccccc;
	
	}
	
	.field{margin-bottom:7px;}
	
	label {
	font-family: Arial, Verdana; 
	/*text-shadow: 2px 2px 2px #ccc;*/
	display: block; 
	float: left; 
	font-weight: bold; 
	margin-right:10px; 
	text-align: right; 
	width: 120px; 
	line-height: 25px; 
	font-size: 12px; 
	}
	
	.input{
	font-family: Arial, Verdana; 
	font-size: 12px; 
	padding:5px; 
	border: 1px solid #b9bdc1; 
	width: 300px; 
	color: #797979;	
	}

    select.input{ width:312px}
	
	.input:focus{
	background-color:#E7E8E7;	
	}
	
	.textarea {
	height:150px;	
	}
	
	.hint{
	display:none;
	}
	
	.field:hover .hint {  
	position: absolute;
	display: block;  
	margin: -30px 0 0 455px;
	color: #FFFFFF;
	padding: 7px 10px;
	background: rgba(0, 0, 0, 0.6);
	
	-moz-border-radius: 7px;
	-webkit-border-radius: 7px;
	border-radius: 7px;	
	}
	
	.button{
	 
	margin:10px 55px 10px 0;
	font-weight: bold;
	line-height: 1;
	padding: 6px 10px;
	cursor:pointer;   
	color: #fff;
	
	text-align: center;
	text-shadow: 0 -1px 1px #64799e;
	
	/* Background gradient */
	background: #a5b8da;
	background: -moz-linear-gradient(top, #a5b8da 0%, #7089b3 100%);
	background: -webkit-gradient(linear, 0% 0%, 0% 100%, from(#a5b8da), to(#7089b3));
	
	/* Border style */
  	border: 1px solid #5c6f91;  
	-moz-border-radius: 10px;
	-webkit-border-radius: 10px;
	border-radius: 10px;
  
	/* Box shadow */
	-moz-box-shadow: inset 0 1px 0 0 #aec3e5;
	-webkit-box-shadow: inset 0 1px 0 0 #aec3e5;
	box-shadow: inset 0 1px 0 0 #aec3e5;
	
	}
	
	.button:hover {
	background: #848FB2;
    cursor: pointer;
	}
    -->
   </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:Left ID="Left1" runat="server" />
            <div class="team_display">
				<div class="hd clearfix">
					<h3 class="h3">
                      人才招聘
                    <%--<div class="crumb"><a href="Default.aspx">首页</a>&gt;&gt;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></div>--%>
                    <div class="news">
				 	<form id="contactform" class="rounded" method="post" action="">
<h3></h3>
<div class="field">
	<label for="name">姓名:</label>
    <asp:TextBox ID="tbUsername" CssClass="input" runat="server"></asp:TextBox>
	<p class="hint">输入你的姓名</p>
</div>

<div class="field">
	<label for="email">Email:</label>
  	<asp:TextBox ID="tbEmail" CssClass="input" runat="server"></asp:TextBox>
	<p class="hint">输入你的E-mail</p>
</div>

<div class="field">
	<label for="sex">性别:</label>
    <asp:DropDownList ID="ddlSex" CssClass="input" runat="server">
        <asp:ListItem>男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    
    </asp:DropDownList> 
</div>

<div class="field">
	<label for="xueli">学历:</label>
  	<asp:TextBox ID="tbXueLi" CssClass="input" runat="server"></asp:TextBox>
	<p class="hint">输入你的学历</p>
</div>

<div class="field">
	<label for="xueli">大学:</label>
    <asp:TextBox ID="tbSchool" CssClass="input" runat="server"></asp:TextBox>
	<p class="hint">毕业院校及专业</p>
</div>

<div class="field">
	<label for="sex">职称:</label>
    <asp:DropDownList ID="ddlZhicheng" CssClass="input" runat="server">
        <asp:ListItem>助理工程师</asp:ListItem>
        <asp:ListItem>工程师</asp:ListItem>
        <asp:ListItem>高级工程师</asp:ListItem>
        <asp:ListItem>其他</asp:ListItem>
    
    </asp:DropDownList> 
</div>

<div class="field">
	<label for="sex">工作年限:</label>
    <asp:DropDownList ID="ddlWorksYears" CssClass="input" runat="server">
        <asp:ListItem>应届毕业生</asp:ListItem>
        <asp:ListItem>1年</asp:ListItem>
        <asp:ListItem>2年</asp:ListItem>
        <asp:ListItem>3年</asp:ListItem>
        <asp:ListItem>5年以上</asp:ListItem>
    
    </asp:DropDownList> 
</div>

<div class="field">
	<label for="xueli">电话:</label>
  	<asp:TextBox ID="tbPhones" CssClass="input" runat="server"></asp:TextBox>
	<p class="hint">电话号码</p>
</div>

<div class="field">
	<label for="message">工作经验:</label>
    <asp:TextBox ID="tbExp" CssClass="input textarea" TextMode="MultiLine" runat="server"></asp:TextBox>
  	 
	<p class="hint">写下你的工作经验.</p>
</div>

 <center>
     <asp:Button ID="Button1" runat="server" CssClass="button" Text="投递" 
         onclick="Button1_Click" /></center>


</form>
                    
                     </div>
				 </div>
				 
                       
			</div>
</asp:Content>
