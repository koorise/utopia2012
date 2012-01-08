(function($) {
    $.fn.extend({
        checkbox:function(options) {

            var defaults = {
                chkHead: $("#chkSelectAll"), //全选|取消checkbox
                chkItem: $("input[type='checkbox'][name$='chkID']"), //单个checkbox项
                btnSelectAll: $("#btnSelectAll"), //全选 button
                btnCancelAll: $("#btnCancelAll"), //取消 button
                btnDeleteBatch: $("input[type='submit'][name$='btnDelete']")//删除 button            
            }

            var options = $.extend(defaults, options);

            //头部全选|取消
            options.chkHead.click(function() {
                SetItemValue($(this).attr("checked"));
            });

            // 全选
            options.btnSelectAll.click(function() {
                SetHeadValue(true);
                SetItemValue(true);

            });

            // 取消全选
            options.btnCancelAll.click(function() {
                SetHeadValue(false);
                SetItemValue(false);
            });

            //每项单击
            options.chkItem.each(function() {
                $(this).click(function() {

                    if (checkSelectedCount() == checkTotalCount()) {
                        SetHeadValue(true);
                    }
                    else {
                        SetHeadValue(false);
                    }
                })
            });

            //单击批量删除
            options.btnDeleteBatch.click(function() {
            if (checkSelectedCount() == 0)
                {
                    alert("请选择要删除的项！");
                    return false;
                }                    
                else
                    return true;
            });

            //设置各项的值
            function SetItemValue(val) {
                options.chkItem.each(function() { $(this).attr("checked", val); });
            }
            //设置头部选择状态
            function SetHeadValue(val) {
                options.chkHead.attr("checked", val);
            }

            //检查选择数量
            function checkSelectedCount() {
                var count = 0;
                options.chkItem.each(function() {
                    if ($(this).attr("checked")) count++;
                });
                return count;
            }

            //检查总数量
            function checkTotalCount() {
                return options.chkItem.length;
            }
        }
    });

})(jQuery);