(function($) {
    $.fn.extend({
        ProductCategory: function(options) {
            var defaults = {
                dropBig: $("#dropBig"), //�����
                dropSmall: $("#dropSmall"), //С���
                defaultSmall: false, //�Ƿ�����Ĭ��С���
                defaultSmallID: "",
                hasHead: false, //ͷ���Ƿ����������С���
                BigHead: '�����',
                SmallHead: 'С���',
                url: "/Service/ProductCategory_Handle.aspx?callback=?"
            }

            var options = $.extend(defaults, options);

            options.dropBig.change(function() { change_Big($(this).val(),""); });
            options.dropSmall.change(function() { });

            //��ʼ������
            init_Big();

            //---------------------------method start--------------------------------------------//

            //��ʼ�������
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
                            //����Ĭ��С���
                            default_Big_Small(options.defaultSmallID);                    
                        }
                    })
            }

            //�ı�����
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
                            //Ĭ��С���
                            if (defaultSmallID != "")
                                options.dropSmall.attr("value", options.defaultSmallID);
                        });
                    })
            }

            //����Ĭ��С���
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