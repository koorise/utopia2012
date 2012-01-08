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
                var tooltip = "<div id='tooltip' style='position:absolute;border:1px solid #ccc;background:#333;  padding:1px;display:none;color:#fff;'><img src='" + this.alt + "' alt='��ƷԤ��ͼ'/><\/div>"; //���� div Ԫ��
                $("body").append(tooltip);    //����׷�ӵ��ĵ���                         
                $("#tooltip")
            .css({
                "top": (e.pageY + y) + "px",
                "left": (e.pageX + x) + "px"
            }).show("fast");      //����x�����y���꣬������ʾ
            }).mouseout(function() {
                $("#tooltip").remove();     //�Ƴ� 
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