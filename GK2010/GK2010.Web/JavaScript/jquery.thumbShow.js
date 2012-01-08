(function($) {
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    $.fn.extend({
        thumbShow: function(options) {
            var defaults = {
                PicList: $(".PictureThumb")
            };
            var options = $.extend(defaults, options);

            //---------------------------event start--------------------------------------------//
            var x = 10;
            var y = 20;
            options.PicList.mouseover(function(e) {
                var tooltip = "<div id='tooltip' style='position:absolute;border:1px solid #ccc;background:#333;  padding:1px;display:none;color:#fff;'><img src='" + this.alt + "' alt='产品预览图'/><\/div>"; //创建 div 元素
                $("body").append(tooltip);    //把它追加到文档中                         
                $("#tooltip")
            .css({
                "top": (e.pageY + y) + "px",
                "left": (e.pageX + x) + "px"
            }).show("fast");      //设置x坐标和y坐标，并且显示
            }).mouseout(function() {
                $("#tooltip").remove();     //移除 
            }).mousemove(function(e) {
                $("#tooltip")
            .css({
                "top": (e.pageY + y) + "px",
                "left": (e.pageX + x) + "px"
            });
            });

            //---------------------------event end--------------------------------------------//
        }
    });
})(jQuery);