(function($) {
    $.fn.extend({
        province_city: function(options) {
            var defaults = {
                dropProvince: $("#dropProvince"), //省份
                dropCity: $("#dropCity"), //城市
                defaultCity: false, //是否设置默认IP城市
                defaultCityID: "",
                hasHead: false, //头部是否包含省份和城市
                provinceHead: '省份',
                cityHead: '城市',
                showCityEn: false,
                url:"/Service/Province_City_Handle.aspx?callback=?"
            }

            var options = $.extend(defaults, options);

            options.dropProvince.change(function() { change_province($(this).val(),""); });
            options.dropCity.change(function() { });

            //初始化操作
            init_province();

            //---------------------------method start--------------------------------------------//

            //初始化省份
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
                            //设置默认城市
                            default_province_city(options.defaultCityID);                    
                        }
                    })
            }

            //改变省份
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
                            //默认城市
                            if (defaultCityID != "")
                                options.dropCity.attr("value", options.defaultCityID);
                        });
                    })
            }

            //设置默认城市
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