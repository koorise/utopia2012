<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GK2010.Web.Admin.ProductParts.Manage" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .checked {font-size:12px; font-family:宋体; font-weight:bold; color:green}
    .unchecked {font-size:12px; font-family:宋体; font-weight:normal; color:#000000}
</style>
<script type="text/javascript">
    var ProductID = <%=ProductID %>;
    function DoCalc() {
        $.getJSON(
            "/Service/ProductParts_Handle.aspx?callback=?",
            { "Type": "DoCalc", "ProductID": ProductID, "Expression": FixJqText(escape( $("#<%=txtExpressions.ClientID %>").val()))},
            function(data) {
                
                if (data.Result == "OK") {
                    //型号,价格,附件
                    $("#<%=lblType.ClientID %>").html(data.Type);
                    $("#<%=lblPrice.ClientID %>").html(data.Price);
                    alert("保存成功！");
                }
                else {
                    alert(data.Result);
                }
            })
    }
    function FixJqText(str) {
        var tempstr = str.replace(/\+/g, "%2B");
        tempstr = tempstr.replace(/\&/g, "%26");
        return tempstr;
    }

    function ChangeOption(radRootControl, PartsID) {
        ChangeRadioCss(document.getElementsByName(radRootControl));

        $.getJSON(
            "/Service/ProductParts_Handle.aspx?callback=?",
            { "Type": "ChangeOption", "PartsID": escape(PartsID), "ProductID": escape(ProductID) },
            function(data) {
                //alert(data.Result);
                if (data.Result == "OK") {
                    
                    //型号,价格,附件
                    $("#<%=lblType.ClientID %>").html(data.Type);
                    $("#<%=lblPrice.ClientID %>").html(data.Price);
                }
                else {
                    alert(data.Result);
                }
            })
       
    }
    function ChangeRadioCss(rad) {
        for (var i = 0; i < rad.length; i++) {
            if (rad[i].checked) {
                $("#span_rad_" + rad[i].value).addClass("checked");
                $("#span_rad_" + rad[i].value).removeClass("unchecked");
            }
            else {
                $("#span_rad_" + rad[i].value).addClass("unchecked");
                $("#span_rad_" + rad[i].value).removeClass("checked");
            }
        }
    }	
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
<div id="divSearch" class="admin_table mb10">
<asp:Button ID="btnAdd" runat="server" cssclass="btn_yellow_small" OnClick="btnAdd_Click" Text="增部件" />
<asp:Button ID="btnAddFJ" runat="server" cssclass="btn_yellow_small" OnClick="btnAddFJ_Click" Text="增附件" />
公式：<asp:TextBox ID="txtExpressions" runat="server" Width="300" CssClass="input"></asp:TextBox>
<input type="button" class="btn_yellow_small" value="计算" onclick="DoCalc()" />
</div>
<h2 class="h1"><span  class="mr10">部件管理</span>
默认型号：<asp:Label ID="lblType" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
默认价格：<asp:Label ID="lblPrice" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>元
</h2>
<div class="admin_table mb10">
<table id="ftable" cellspacing="0" cellpadding="0" width="100%">
    <asp:Repeater id="RepeaterList" Runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
        <ItemTemplate>        
         <tr class="tr1 vt">
		    <asp:Literal ID="txtTdStart" runat="server"></asp:Literal>
			    <%#GK2010.Utility.StringHelper.GetStrLine(Eval("ID"), Eval("Path"))%>
			    <input type="hidden" runat="server" id="txtID" value='<%#Eval("ID") %>' />
			    <input type="text" runat="server" id="txtSortID"   class="input input_wd mr5" value='<%#Eval("SortID") %>' />
			    <asp:Literal ID="txtParamCode" runat="server"></asp:Literal>
                <asp:Literal ID="txtParam" runat="server"></asp:Literal>
		    <asp:Literal ID="txtTdEnd" runat="server"></asp:Literal>
	    </tr>  
        </ItemTemplate>							
    </asp:Repeater> 
</table>
</div>
<div class="tac mb10"><asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn_yellow_big" OnClick="btnSave_Click" ></asp:Button></div>
</asp:Content>