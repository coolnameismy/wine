$(function(){
	$("#js_nav > li").hover(function(){
		$(this).find(".subnav").show();
	},function(){
		$("#js_nav div").hide();
	});

	//subnav bg
	var count = $("#js_nav").find(".subnav").length;
	for(var i = 0; i < count; i++){
		var num = $(".subnav:eq("+i+")").find("a").length;
		switch(num){
			case 1 : $(".subnav:eq("+i+")").css({"width":"174px","background-position":"0 -180px"});
				break;
			case 2 : $(".subnav:eq("+i+")").css({"width":"330px","background-position":"0 -90px"});
				break;
			case 3 : $(".subnav:eq("+i+")").css({"width":"518px","background-position":"0 0"});
				break;
			default: break;
		}
	}

	

});