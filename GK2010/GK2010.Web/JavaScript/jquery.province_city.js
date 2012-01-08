(function($) {
    $.fn.extend({
        province_city: function(options) {
            var defaults = {
                dropProvince: $("#dropProvince"), //ʡ��
                dropCity: $("#dropCity"), //����
                defaultCity: false, //�Ƿ�����Ĭ��IP����
                defaultCityID: "",
                hasHead: false, //ͷ���Ƿ����ʡ�ݺͳ���
                provinceHead: 'ʡ��',
                cityHead: '����',
                showCityEn: false,
                url:"/Service/Province_City_Handle.aspx?callback=?"
            }

            var options = $.extend(defaults, options);

            options.dropProvince.change(function() { change_province($(this).val(),""); });
            options.dropCity.change(function() { });

            //��ʼ������
            init_province();

            //---------------------------method start--------------------------------------------//

            //��ʼ��ʡ��
            function init_province() {
                if (options.hasHead) {
                    options.dropProvince.append("<option value=''>" + options.provinceHead + "</option>");
                }

                $.getJSON(
                    options.url,
                    { "Type": "ListProvince" },
                    function(data) {
                        $.each(data.ConfigProvince, function(i, item) {
                            var ProvinceID = item.ProvinceID;
                            var ProvinceName = item.ProvinceName;
                            options.dropProvince.append("<option value='" + ProvinceID + "'>" + ProvinceName + "</option>");
                        });

                        if (!options.defaultCity) {
                            change_province(options.dropProvince.val(),"");
                        }
                        else {
                            //����Ĭ�ϳ���
                            default_province_city(options.defaultCityID);                    
                        }
                    })
            }

            //�ı�ʡ��
            function change_province(ProvinceID, defaultCityID) {
                options.dropCity.removeAttr("disabled");
                options.dropCity.find("option").remove();
                if (options.hasHead) {
                    options.dropCity.append("<option value=''>" + options.cityHead + "</option>");
                }

                $.getJSON(
                    options.url,
                    { "Type": "ListCity", "ProvinceID": ProvinceID },
                    function(data) {
                        $.each(data.ConfigCity, function(i, item) {
                            var CityID = item.CityID;
                            if(options.showCityEn)
                                CityID = item.CityEn;
                            var CityName = item.CityName;
                            options.dropCity.append("<option value='" + CityID + "'>" + CityName + "</option>");
                            //Ĭ�ϳ���
                            if (defaultCityID != "")
                                options.dropCity.attr("value", options.defaultCityID);
                        });
                    })
            }

            //����Ĭ�ϳ���
            function default_province_city(defaultCityID) {
                $.getJSON(
                    options.url,
                    { "Type": "DefaultProvinceCity" },
                    function(data) {
                        $.each(data.ConfigCity, function(i, item) {
                            var ProvinceID = item.ProvinceID;
                            var CityID = item.CityID;
                            if(options.showCityEn)
                                CityID = item.CityEn;
                            options.dropProvince.attr("value", ProvinceID);
                            change_province(ProvinceID, defaultCityID);
                            //options.dropCity.attr("value", CityID);
                            //$("#province option[value=" + ProvinceID + "]").attr("selected", true);
                            //$("#city option[value=" + CityID + "]").attr("selected", true);
                        });
                    })
            }
            //---------------------------method end--------------------------------------------//
        }
    });

})(jQuery);