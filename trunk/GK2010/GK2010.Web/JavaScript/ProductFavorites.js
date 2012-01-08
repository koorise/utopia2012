function addFavorites(ProductID,CategoryID, ProductTitle) {
    $.ajax({
        type: "GET",
        url: "/MemberProductFavorites_handle.aspx",
        data: "Action=add&ProductID=" + ProductID + "&CategoryID=" + CategoryID + "&Title=" + escape(ProductTitle) + "&temp=" + Math.random(10000),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (msg) {
            var flag = msg.split("|")[0];
            var result = msg.split("|")[1];

            if (flag == "失败") {
                alert(result);
                return;
            }
            if (flag == "成功") {
                if (confirm("收藏成功,现在就去收藏夹查看吗？")) {
                    location.href = result;
                }
            }
        }
    });
}

