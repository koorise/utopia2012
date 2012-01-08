(function($) {
    $.fn.extend({
        checkbox:function(options) {

            var defaults = {
                chkHead: $("#chkSelectAll"), //ȫѡ|ȡ��checkbox
                chkItem: $("input[type='checkbox'][name$='chkID']"), //����checkbox��
                btnSelectAll: $("#btnSelectAll"), //ȫѡ button
                btnCancelAll: $("#btnCancelAll"), //ȡ�� button
                btnDeleteBatch: $("input[type='submit'][name$='btnDelete']")//ɾ�� button            
            }

            var options = $.extend(defaults, options);

            //ͷ��ȫѡ|ȡ��
            options.chkHead.click(function() {
                SetItemValue($(this).attr("checked"));
            });

            // ȫѡ
            options.btnSelectAll.click(function() {
                SetHeadValue(true);
                SetItemValue(true);

            });

            // ȡ��ȫѡ
            options.btnCancelAll.click(function() {
                SetHeadValue(false);
                SetItemValue(false);
            });

            //ÿ���
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

            //��������ɾ��
            options.btnDeleteBatch.click(function() {
            if (checkSelectedCount() == 0)
                {
                    alert("��ѡ��Ҫɾ�����");
                    return false;
                }                    
                else
                    return true;
            });

            //���ø����ֵ
            function SetItemValue(val) {
                options.chkItem.each(function() { $(this).attr("checked", val); });
            }
            //����ͷ��ѡ��״̬
            function SetHeadValue(val) {
                options.chkHead.attr("checked", val);
            }

            //���ѡ������
            function checkSelectedCount() {
                var count = 0;
                options.chkItem.each(function() {
                    if ($(this).attr("checked")) count++;
                });
                return count;
            }

            //���������
            function checkTotalCount() {
                return options.chkItem.length;
            }
        }
    });

})(jQuery);