var ajaxUrl = "/MemberCart_checkout.aspx";
var isConsigneeOpen = false;
var isInvoiceMailOpen = false;
var label_consignee;
//显示地址信息表单
function showForm_Consignee(obj) {
    label_consignee = $("#part_consignee").html();
    var UrlParam = "action=showForm_Consignee";
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "part_consignee");
    isConsigneeOpen = true;
}

//保存地址信息
function saveForm_Consignee(obj) {
    var UrlParam = "action=saveForm_Consignee";
    UrlParam += "&ConsigneeCompany=" + escape($("#ConsigneeCompany").val());
    UrlParam += "&ConsigneeRealName=" + escape($("#ConsigneeRealName").val());
    UrlParam += "&ConsigneeProvince=" + escape($("#ConsigneeProvince").val());
    UrlParam += "&ConsigneeCity=" + escape($("#ConsigneeCity").val());
    UrlParam += "&ConsigneeArae=" + escape($("#ConsigneeArae").val());
    UrlParam += "&ConsigneeAddress=" + escape($("#address").val());
    UrlParam += "&ConsigneePostCode=" + escape($("#ConsigneePostCode").val());
    UrlParam += "&ConsigneeTelephone=" + escape($("#ConsigneeTelephone").val());
    UrlParam += "&ConsigneeMobile=" + escape($("#ConsigneeMobile").val());
    UrlParam += "&ConsigneeEmail=" + escape($("#ConsigneeEmail").val());
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "part_consignee");
    isConsigneeOpen = false;
}

function setAjax(UrlParam, obj) {
    $.ajax({
        type: "GET",
        url: ajaxUrl,
        data: UrlParam,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (data) {
            alert("发生错误！");
        },
        success: function (data) {
            if (data.State == 1) {
                $("#" + obj).html(data.Result)
            }
            else {
                alert(data.Result);
                return;
            }
        }
    });
}

//关闭地址信息
function closeForm_Consignee(obj) {
    if (label_consignee == null) {
        var UrlParam = "action=closeForm_Consignee";
        UrlParam += "&temp=" + Math.random(1000);
        setAjax(UrlParam, "part_consignee");
        isConsigneeOpen = false;
    }
    else {
        $("#part_consignee").html(label_consignee);
        isConsigneeOpen = false;
    }
}


function changeConsignee(obj, objID) {
    var UrlParam = "action=changeConsignee";
    UrlParam += "&ConsigneeID=" + objID;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "consignee_addr");
}

function changeConsigneeProvince(obj) {
    var UrlParam = "action=changeArea_province";
    UrlParam += "&ConsigneeProvince=" + obj.value;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "ConsigneeArea");

    $("#ConsigneeCity").val(0);
    $("#ConsigneeArea").val(0);
    showAreaConsigneeInfo();
}
function changeConsigneeCity(obj) {
    var UrlParam = "action=changeArea_city";
    UrlParam += "&ConsigneeProvince=" + $("#ConsigneeProvince").val();
    UrlParam += "&ConsigneeCity=" + obj.value;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "ConsigneeArea");

    $("#ConsigneeArea").val(0);
    showAreaConsigneeInfo();
}
function changeConsigneeArea(obj) {
    showAreaConsigneeInfo();
}

function showAreaConsigneeInfo() {
    var _info = '';
    _info += $("#ConsigneeProvince").val() == '0' ? "" : $("#ConsigneeProvince").find("option:selected").text();
    _info += $("#ConsigneeCity").val() == '0' ? "" : $("#ConsigneeCity").find("option:selected").text();
    _info += $("#ConsigneeArae").val() == '0' ? "" : $("#ConsigneeArae").find("option:selected").text(); 
    $('#ConsigneeAddress').html(_info);
}

function changeConsignee(obj, objID) {
    var UrlParam = "action=changeConsignee";
    UrlParam += "&temp=" + Math.random(1000);
    UrlParam += "&ConsigneeID=" + objID;
    setAjax(UrlParam, "consignee_addr");
}

//----------------------------发票邮寄信息-------------------------------------        
var label_InvoiceMail;
//显示发票邮寄表单
function showForm_InvoiceMail(obj) {
    label_InvoiceMail = $("#part_invoiceMail").html();

    var UrlParam = "action=showForm_InvoiceMail";
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "part_invoiceMail");
    isInvoiceMailOpen = true;
}

function changeInvoiceMail(obj, objID) {
    var UrlParam = "action=changeInvoiceMail";
    UrlParam += "&InvoiceMailID=" + objID;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "InvoiceMail_addr");
}
function changeInvoiceMailToConsignee() {
    var UrlParam = "action=changeInvoiceMailToConsignee";
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "InvoiceMail_addr");
}

//保存发票邮寄
function saveForm_InvoiceMail(obj) {
    var UrlParam = "action=saveForm_InvoiceMail";
    UrlParam += "&InvoiceMailCompany=" + escape($("#InvoiceMailCompany").val());
    UrlParam += "&InvoiceMailRealName=" + escape($("#InvoiceMailRealName").val());
    UrlParam += "&InvoiceMailProvince=" + escape($("#InvoiceMailProvince").val());
    UrlParam += "&InvoiceMailCity=" + escape($("#InvoiceMailCity").val());
    UrlParam += "&InvoiceMailArae=" + escape($("#InvoiceMailArae").val());
    UrlParam += "&InvoiceMailAddress=" + escape($("#address").val());
    UrlParam += "&InvoiceMailPostCode=" + escape($("#InvoiceMailPostCode").val());
    UrlParam += "&InvoiceMailTelephone=" + escape($("#InvoiceMailTelephone").val());
    UrlParam += "&InvoiceMailMobile=" + escape($("#InvoiceMailMobile").val());
    UrlParam += "&InvoiceMailEmail=" + escape($("#InvoiceMailEmail").val());
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "part_invoiceMail");
    isInvoiceMailOpen = false;
}

function changeInvoiceMailProvince(obj) {
    var UrlParam = "action=changeArea_InvoiceMailProvince";
    UrlParam += "&InvoiceMailProvince=" + obj.value;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "InvoiceMailArea");

    $("#InvoiceMailCity").val(0);
    $("#InvoiceMailArea").val(0);
    showAreaInvoiceMailInfo();
}
function changeInvoiceMailCity(obj) {
    var UrlParam = "action=changeArea_InvoiceMailCity";
    UrlParam += "&InvoiceMailProvince=" + $("#InvoiceMailProvince").val();
    UrlParam += "&InvoiceMailCity=" + obj.value;
    UrlParam += "&temp=" + Math.random(1000);
    setAjax(UrlParam, "InvoiceMailArea");

    $("#InvoiceMailArae").val(0);
    showAreaInvoiceMailInfo();
}
function changeInvoiceMailArea(obj) {
    showAreaInvoiceMailInfo();
}

function showAreaInvoiceMailInfo() {
    var _info = '';
    _info += $("#InvoiceMailProvince").val() == '0' ? "" : $("#InvoiceMailProvince").find("option:selected").text(); ;
    _info += $("#InvoiceMailCity").val() == '0' ? "" : $("#InvoiceMailCity").find("option:selected").text();
    _info += $("#InvoiceMailArae").val() == '0' ? "" : $("#InvoiceMailArae").find("option:selected").text();
    $('#InvoiceMailAddress').html(_info);
}

//关闭发票邮寄
function closeForm_InvoiceMail(obj) {
    if (label_InvoiceMail == null) {
        var UrlParam = "action=closeForm_InvoiceMail";
        UrlParam += "&temp=" + Math.random(1000);
        setAjax(UrlParam, "part_invoiceMail");
        isInvoiceMailOpen = false;
    }
    else {
        $("#part_invoiceMail").html(label_InvoiceMail);
        isInvoiceMailOpen = false;
    }
}