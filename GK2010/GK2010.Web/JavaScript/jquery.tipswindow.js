/*��������*/
(function($) {
    $.fn.extend({
        tipswindow: function(options) {
            var defaults = {
                btnPost: $("#btnPost"), //�ύ��ť
                title: "����", //����
                contentType: "iframe", //����iframe|html|text|img|id|url
                content: "����", //����
                width: 800,  //��
                height: 500, //��
                drag: false, //���϶�
                time: 0, //�ر�ʱ��
                showbg: true, //��ʾ����
                showok: true, //��ʾȷ����ť
                cssName: "", //css��ʽ               
                clickOK: function() { }
            }

            var options = $.extend(defaults, options);

            /*---------------------------------------------------------------�����¼���ʼ--------------------------------------------------------------------*/
            //options.btnPost.bind("click", function() {
            options.btnPost.click(function() {
                var showWindown = true;
                $("#windown-box").remove(); //�������
                //var width = width >= 950 ? this.width = 950 : this.width = options.width;     //������󴰿ڿ��
                //var height = height >= 527 ? this.height = 527 : this.height = options.height;  //������󴰿ڸ߶�

                var width = options.width;     //������󴰿ڿ��
                var height = options.height;  //������󴰿ڸ߶�
                if (showWindown == true) {
                    var simpleWindown_html = new String;
                    var showOK_css = new String;
                    simpleWindown_html = "<div id=\"windownbg\" style=\"height:" + $(document).height() + "px;;filter:alpha(opacity=0);opacity:0;z-index: 999901\"><iframe style=\"width:100%;height:100%;border:none;filter:alpha(opacity=0);opacity:0;\"></iframe></div>";
                    simpleWindown_html += "<div id=\"windown-box\">";
                    simpleWindown_html += "<div id=\"windown-title\"><h2></h2><span id=\"windown-close\"></span></div>";
                    simpleWindown_html += "<div id=\"windown-content-border\"><div id=\"windown-content\"></div></div>";
                    if (options.showok)
                        showOK_css = "";
                    else
                        showOK_css = "display:none";

                    simpleWindown_html += "<div id=\"windown-bottom\" style=\"" + showOK_css + "\"><div><span id=\"windown-ok\">ȷ��</span></div></div>";
                    simpleWindown_html += "</div>";
                    $("body").append(simpleWindown_html);
                    show = false;
                }

                switch (options.contentType) {
                    case "text":
                        $("#windown-content").html(options.content);

                        break;
                    case "id":
                        $("#windown-content").html($("#" + options.content + "").html());
                        break;
                    case "img":
                        $("#windown-content").ajaxStart(function() {
                            $(this).html("<img src='/images/loading.gif' class='loading' />");
                        });
                        $.ajax({
                            error: function() {
                                $("#windown-content").html("<p class='windown-error'>�������ݳ���...</p>");
                            },
                            success: function(html) {
                                $("#windown-content").html("<img src=" + options.content + " alt='' />");
                            }
                        });
                        break;
                    case "url":
                        var content_array = options.content.split("?");
                        $("#windown-content").ajaxStart(function() {
                            $(this).html("<img src='/images/loading.gif' class='loading' />");
                        });
                        $.ajax({
                            type: content_array[0],
                            url: content_array[1],
                            data: content_array[2],
                            error: function() {
                                $("#windown-content").html("<p class='windown-error'>�������ݳ���...</p>");
                            },
                            success: function(html) {
                                $("#windown-content").html(html);
                            }
                        });
                        break;
                    case "iframe":
                        $("#windown-content").ajaxStart(function() {
                            $(this).html("<img src='/images/loading.gif' class='loading' />");
                        });
                        $.ajax({
                            error: function() {
                                $("#windown-content").html("<p class='windown-error'>�������ݳ���...</p>");
                            },
                            success: function(html) {
                                $("#windown-content").html("<iframe id=\"frameContent\"src=\"" + options.content + "\" width=\"100%\" height=\"" + parseInt(height) + "px" + "\" scrolling=\"auto\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\"></iframe>");
                            }
                        });
                }

                $("#windown-title h2").html(options.title);
                if (options.showbg) { $("#windownbg").show(); } else { $("#windownbg").remove(); };
                $("#windownbg").animate({ opacity: "0.05" }, "normal"); //����͸����
                $("#windown-box").show();
                //alert($("#windown-box").html());
                if (height >= 527) {
                    $("#windown-title").css({ width: (parseInt(width) + 22) + "px" });
                    $("#windown-bottom").css({ width: (parseInt(width) + 23) + "px" });
                    $("#windown-content").css({ width: (parseInt(width) + 17) + "px", height: height + "px" });
                } else {
                    $("#windown-title").css({ width: (parseInt(width) + 10) + "px" });
                    $("#windown-bottom").css({ width: (parseInt(width) + 11) + "px" });
                    $("#windown-content").css({ width: width + "px", height: height + "px" });
                }

                var cw, ch, est = document.documentElement.scrollTop; //���ڵĸߺͿ�


                //ȡ�ô��ڵĸߺͿ�
                if (self.innerHeight) {
                    cw = self.innerWidth;
                    ch = self.innerHeight;
                } else if (document.documentElement && document.documentElement.clientHeight) {
                    cw = document.documentElement.clientWidth;
                    ch = document.documentElement.clientHeight;
                } else if (document.body) {
                    cw = document.body.clientWidth;
                    ch = document.body.clientHeight;
                }


                var isIE6 = false;
                if (isIE6) {
                    $("#windown-box").css({ left: "50%", top: (parseInt((ch) / 2) + est) + "px", marginTop: -((parseInt(height) + 53) / 2) + "px", marginLeft: -((parseInt(width) + 32) / 2) + "px", zIndex: "999999" });
                } else {
                    $("#windown-box").css({ left: "50%", top: "50%", marginTop: -((parseInt(height) + 53) / 2) + "px", marginLeft: -((parseInt(width) + 32) / 2) + "px", zIndex: "999999" });
                };
                var Drag_ID = document.getElementById("windown-box"), DragHead = document.getElementById("windown-title");

                var moveX = 0, moveY = 0, moveTop, moveLeft = 0, moveable = false;
                if (isIE6) {
                    moveTop = est;
                } else {
                    moveTop = 0;
                }
                var sw = Drag_ID.scrollWidth, sh = Drag_ID.scrollHeight;
                DragHead.onmouseover = function(e) {
                    if (options.drag) { DragHead.style.cursor = "move"; } else { DragHead.style.cursor = "default"; }
                };
                DragHead.onmousedown = function(e) {
                    $("#windown-box").css({ opacity: "0.5" }, "normal");
                    if (options.drag) { moveable = true; } else { moveable = false; }
                    e = window.event ? window.event : e;
                    var ol = Drag_ID.offsetLeft, ot = Drag_ID.offsetTop - moveTop;
                    moveX = e.clientX - ol;
                    moveY = e.clientY - ot;
                    document.onmousemove = function(e) {
                        if (moveable) {

                            e = window.event ? window.event : e;
                            var x = e.clientX - moveX;
                            var y = e.clientY - moveY;
                            if (x > 0 && (x + sw < cw) && y > 0 && (y + sh < ch)) {
                                Drag_ID.style.left = x + "px";
                                Drag_ID.style.top = parseInt(y + moveTop) + "px";
                                Drag_ID.style.margin = "auto";
                            }
                        }
                    }
                    document.onmouseup = function() { moveable = false; $("#windown-box").css({ opacity: "1" }, "normal"); };
                    Drag_ID.onselectstart = function(e) { return false; }
                }
                //$("#windown-content").attr("class", "windown-" + cssName);
                var closeWindown = function() {
                    $("#windownbg").remove();
                    $("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                }
                if (options.time == 0 || typeof (options.time) == "undefined") {
                    $("#windown-close").click(function() {
                        $("#windownbg").remove();
                        $("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                    });
                    $("#windown-ok").click(function() {
                        if (options.clickOK()) {
                            $("#windownbg").remove();
                            $("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                        }
                    });
                    //                    $("#btnOK").click(function() {

                    //                        $("#windownbg").remove();
                    //                        $("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                    //                    });
                    //��span�Ϳ��Թر�iframe����button�Ͳ����Թر�iframe��

                    //                    $("#btnOK").click(function() {
                    //                        //alert($("#frameContent").contents().find("#txtCategoryText").val());
                    //                        //options.clickOK();
                    //                        alert(1);
                    //                        $("#windownbg").remove();
                    //                        $("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                    //                        //$("#windown-box").fadeOut("fast", function() { $(this).remove(); });
                    //                    });
                }
                else {
                    setTimeout(closeWindown, options.time);
                }


            });
            /*-----------------------------�����¼�����-----------------*/

        }
    });

})(jQuery);