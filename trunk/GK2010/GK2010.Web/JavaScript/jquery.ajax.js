$.extend({
    //����û����Ƿ����
    CheckUserName: function(obj) {
        return obj+"123";

//        $.getJSON(
//            "/Service/MemberHandle.aspx?callback=?",
//            { "Type": "CheckUserName", "UserName": escape(UserName) },
//            function(data) {
//              
//                if (data.Result == "OK") {
//                    arguments.IsValid = true;
//                }
//                else {
//                    arguments.IsValid = false;
//                }
//            })
    }
})