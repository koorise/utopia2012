(function($) {
    $.fn.extend({
        ProductCategory: function(options) {
            var defaults = {
                dropBig: $("#dropBig"), //大类别
                dropSmall: $("#dropSmall"), //小类别
                defaultSmall: false, //是否设置默认小类别
                defaultSmallID: "",
                hasHead: false, //头部是否包含大类别和小类别
                BigHead: '大类别',
                SmallHead: '小类别',
                url: "/Service/ProductCategory_Handle.aspx?callback=?"
            }

            var options = $.extend(defaults, options);

            options.dropBig.change(function() { change_Big($(this).val(),""); });
            options.dropSmall.change(function() { });

            //初始化操作
            init_Big();

            //---------------------------method start--------------------------------------------//

            //初始化大类别
            function init_Big() {
                if (options.hasHead) {
                    options.dropBig.append("<option value=''>" + options.BigHead + "</option>");
                }

                $.getJSON(
                    options.url,
                    { "Type": "ListBigCategory" },
                    function(data) {
                    $.each(data.ProductCategory, function(i, item) {
                            var BigID = item.ID;
                            var BigName = item.Title;
                            options.dropBig.append("<option value='" + BigID + "'>" + BigName + "</option>");
                        });

                        if (!options.defaultSmall) {
                            change_Big(options.dropBig.val(),"");
                        }
                        else {
                            //设置默认小类别
                            default_Big_Small(options.defaultSmallID);                    
                        }
                    })
            }

            //改变大类别
            function change_Big(BigID, defaultSmallID) {
                options.dropSmall.removeAttr("disabled");
                options.dropSmall.find("option").remove();
                if (options.hasHead) {
                    options.dropSmall.append("<option value=''>" + options.SmallHead + "</option>");
                }

                $.getJSON(
                    options.url,
                    { "Type": "ListSmallCategory", "BigID": BigID },
                    function(data) {
                    $.each(data.ProductCategory, function(i, item) {
                            var SmallID = item.ID;                       
                            var SmallName = item.Title;
                            options.dropSmall.append("<option value='" + SmallID + "'>" + SmallName + "</option>");
                            //默认小类别
                            if (defaultSmallID != "")
                                options.dropSmall.attr("value", options.defaultSmallID);
                        });
                    })
            }

            //设置默认小类别
            function default_Big_Small(defaultSmallID) {
                $.getJSON(
                    options.url,
                    { "Type": "DefaultCategory", "SmallID": defaultSmallID },
                    function(data) {
                    $.each(data.ProductCategory, function(i, item) {
                            var BigID = item.ParentID;
                            var SmallID = item.ID;                            
                            options.dropBig.attr("value", BigID);
                            change_Big(BigID, defaultSmallID);
                        });
                    })
            }
            //---------------------------method end--------------------------------------------//
        }
    });

})(jQuery);