/* ---------- DOM加载完毕 ---------- */
$(document).ready(function(){
    $("#Js_nav > li").hover(function(){
        var $this=$(this)
        if($this.children("div.sub_box").length>0)
        {
            $this.children("a").addClass("selected").siblings("div.sub_box").show();
        }
    },function(){
        var $this=$(this)
        if($this.children("div.sub_box").length>0)
        {
            $this.children("a").removeClass("selected").siblings("div.sub_box").hide();
        }
    });
    $("#JS_promo a").addClass("bigimg");
	$("#JS_promo .bigimg img").banner_thaw({
		thumbObj:"#JS_triggers img"
	});
	
        $(".pic_list_change_show").find("li").each(function(index){
		    $(this).delay(parseInt(index)*1000).show(1110);
 	    });

    // display  
    var i = 1;
    $(".cert_image").find("li").each(function(index){
		var _this = $(this);
		_this.click(function(){
			_this.addClass("selected").siblings().removeClass("selected");
			$("#JS_pic_list").find("ul.pic_list_change").each(function(index2){
				if(index==index2){
                    $(this).addClass("pic_list_change_show").siblings().removeClass("pic_list_change_show");
                    $(this).find("li").each(function(index3){
		                $(this).delay(parseInt(index3)*1000).show(1110);
 	                });
                }
			});
			$("#JS_intro").find("div.intro").each(function(index2){
				if(index==index2){$(this).addClass("description").siblings().removeClass("description");}
			});
            i = index +1;
		});
	});
	
/*
    function change_img(){
        $("#JS_pic_list").find("ul.pic_list_change").each(function(index){
			if(i==index + 1){
			$(this).addClass("pic_list_change_show").siblings().removeClass("pic_list_change_show");
			}
		});
        $("#JS_intro").find("div.intro").each(function(index){
			if(i==index + 1){
			$(this).addClass("description").siblings().removeClass("description");
			}
		});
        $(".cert_image").find("li").each(function(index){
			if(i==index + 1){
			$(this).addClass("selected").siblings().removeClass("selected");
			}
		});
    }
*/	
	$(".cert_image").Scroll({
		visible:5,
		next:".pic_next",
		prev:".pic_prev"
	});
	
	$(".pic_list_change").each(function(){
		$(this).find("a.lightbox").lightBox();
	})
	
	
	$(".nav_list > li").hover(function(){
		$(this).addClass("nav_item_hover");},function(){
		$(this).removeClass("nav_item_hover");
	});
	/*
	$(".sub_list li").hover(function(){
		$(this).addClass("sub_item_hover");},function(){
		$(this).removeClass("sub_item_hover");
	});
    */
	
	$(".team_list li.item_team:nth-child(even)").addClass("item_team_even");
	
	
});
