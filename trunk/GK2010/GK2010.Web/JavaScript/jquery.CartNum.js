function UpdateCartNum(cartNum, id) {
    var num = document.getElementById('TotalNum' + id).value;
    if (isNaN(num) == false) {
        if (parseInt(num) == num && num>0) {
            num = parseInt(num);
            $.ajax({
                type: "Get",
                url: "/MemberCartNum_UpdateNum.aspx",
                data: "Action=update&Num=" + num + "&CartNum=" + cartNum + "&MemberCartDetail_ID=" + id,
                contentType: "application/json;charset=utf-8",
                dataType: "html",
                success: function (msg) {
                    if (msg != "") {
                        var price = msg.split('|')[0];
                        var jf = msg.split('|')[1];
                        var totalNum = msg.split('|')[2];
                        var totaljf = msg.split('|')[3]
                        var totalPrice = msg.split('|')[4];

                        document.getElementById('jf' + id).innerHTML = jf;
                        document.getElementById('je' + id).innerHTML = price;
                        document.getElementById('zsl' + cartNum).innerHTML = totalNum;
                        document.getElementById('zjf' + cartNum).innerHTML = totaljf;
                        document.getElementById('zjg' + cartNum).innerHTML = totalPrice;
                        document.getElementById('top_zsl').innerHTML = totalNum;
                    }
                }
            });
        } else {
            alert("输入错误，请输入正整数");
            return;
        }
    } else {
        alert("输入错误，请输入数字");
        return;
    }
}