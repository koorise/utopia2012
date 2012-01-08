(function($) {
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    $.fn.extend({
        post: function(options) {
            var defaults = {
                btnPost: $("#btnPost"),
                click: function(event) {
                    return true;
                }
            };
            var options = $.extend(defaults, options);

            //---------------------------event start--------------------------------------------//
            //options.btnPost.bind("click", options.click);
            options.btnPost.bind("click", function(event) {
                if (Page_ClientValidate() == false) {
                    event.preventDefault();
                }
                else {
                    if (options.click(event)) {
                        $(this).val('正在提交...');
                        $(this).attr("disabled", "true");
                        __doPostBack($(this).attr("name"), '');
                    }
                    else {
                        event.preventDefault();
                    }
                }
            });

            //---------------------------event end--------------------------------------------//
        }
    });

    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    $.fn.extend({
        input: function(options) {
            var defaults = {
                Type: "", //验证类型
                MinLength: 6, //大于等于此长度才验证
                MsgOKFlag: true, //验证正确提示是否显示
                MsgOK: "", //验证正确提示
                MsgFailFlag: true, //验证错误提示是否显示
                MsgFail: "", //验证错误提示
                txtInput: $("#txtInput"),
                txtInputMsg: $("#txtInputMsg"),
                focus: function() { },
                blur: function() {
                    DoCheck(this.value);
                },
                keyup: function(event) { }
            };
            var options = $.extend(defaults, options);


            //---------------------------event start--------------------------------------------//
            options.txtInput.bind("focus", options.focus)
            options.txtInput.bind("blur", options.blur); ;
            options.txtInput.bind("keyup", options.keyup);
            //---------------------------event end--------------------------------------------//

            //---------------------------private method start--------------------------------------------//
            function DoCheck(Content) {
                if (options.Type == "UserName") {
                    if (!chkUserName(Content)) {
                        options.txtInputMsg.html("");
                        eval("$." + options.Type + "Checked = false;");
                        return false;
                    }
                }
                if (options.Type == "Email") {
                    if (!chkEmail(Content)) {
                        options.txtInputMsg.html("");
                        eval("$." + options.Type + "Checked = false;");
                        return false;
                    }
                }
                if (options.Type == "Mobile") {
                    if (!chkMobile(Content)) {
                        options.txtInputMsg.html("");
                        eval("$." + options.Type + "Checked = false;");
                        return false;
                    }
                }
                if (Content.length >= options.MinLength) {
                    $.getJSON(
                    "/Service/MemberHandle.aspx?callback=?",
                    { "Type": "Check" + options.Type, "Content": escape(Content) },
                    function(data) {
                        //alert(data.Result);
                        if (data.Result == "OK") {
                            if (options.MsgOKFlag) {
                                options.txtInputMsg.html(options.MsgOK);
                                options.txtInputMsg.css("color", "green");
                                options.txtInputMsg.removeClass("valierror");
                            }
                            eval("$." + options.Type + "Checked = true;");
                        }
                        else {
                            if (options.MsgFailFlag) {
                                options.txtInputMsg.html(options.MsgFail);
                                options.txtInputMsg.css("color", "red");
                                options.txtInputMsg.addClass("valierror");

                            }
                            eval("$." + options.Type + "Checked = false;");
                        }
                    })
                }
                else {
                    options.txtInputMsg.html("");
                    eval("$." + options.Type + "Checked = false;");
                }
            }
            function chkUserName(UserName) {
                if (UserName == "") return false;
                if (/^[A-Za-z]\w{5,19}$/.test(UserName))
                    return true;
                return false;
            }

            function chkEmail(Email) {
                if (Email == "") return false;
                if (/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(Email))
                    return true;
                return false;
            }
            function chkMobile(Mobile) {
                if (Mobile == "") return false;
                if (/^13\d{9}$/.test(Mobile) | /^15\d{9}$/.test(Mobile) | /^18\d{9}$/.test(Mobile))
                    return true;
                else
                    return false;
            }
            //---------------------------private method start--------------------------------------------//
        }
    });
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
})(jQuery);