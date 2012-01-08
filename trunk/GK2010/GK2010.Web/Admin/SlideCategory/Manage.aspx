<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.SlideCategory.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<div id="divSearch" class="admin_table mb10"><asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="添加" /></div>
<h2 class="h1"><span  class="mr10">幻灯片类别管理</span></h2>
<div class="admin_table mb10">
<table id="ftable" cellspacing="0" cellpadding="0" width="100%">
    <tr class="tr2">
        <td>[顺序]栏目名称</td>       
        <td>栏目拼音</td>	   
        <td>操作</td>
    </tr>    
    <asp:Repeater id="RepeaterList" Runat="server">
        <ItemTemplate>        
         <tr class="vt tr1" >
		    <td class="td4 tdcur">			  
			    <%#GK2010.Utility.StringHelper.GetStrLine(Eval("ID"), Eval("Path"))%>
			    <input type="hidden" runat="server" id="txtID" value='<%#Eval("ID") %>' />
			    <input type="text" runat="server" id="txtSortID"   class="input input_wd mr5" value='<%#Eval("SortID") %>' />
			    <span id="fourm_<%#Eval("ID") %>"><%#Eval("Title") %></span>			   
			    <font class="gray mr20">FID:<%#Eval("ID") %></font>&nbsp;&nbsp;
		    </td>	
		    <td class="td2"><input type="text" runat="server" id="txtTitleEn"   class="input input_wa mr5" value='<%#Eval("TitleEn") %>' /></td>	  
            <td class="td2">
                <a href="modify.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>" class="mr10">[编辑]</a>
                <a href="delete.aspx?id=<%#Eval("ID") %>&ReturnUrl=<%=GK2010.Utility.ConfigUrl.CurrentUrl %>">[删除]</a>
            </td>
	    </tr>  
        </ItemTemplate>							
    </asp:Repeater> 
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn_yellow_big" OnClick="btnSave_Click" ></asp:Button></div>
</asp:Content>