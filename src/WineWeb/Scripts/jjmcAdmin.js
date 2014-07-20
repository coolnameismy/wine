$(function () {

    //alert("");
    //集成在老官网后台时，暂时隐去header，不然顶部距离太大
    $("#header").css("display","none");
   
    //Create 标签添加样式CreateButton
    $(".page p a:contains('Create')").addClass("CreateButton");
    //导出到Excel 按钮添加样式CreateButton
    $(".page p :contains('导出到Excel表格')").addClass("ExcelButtin");
    //From 、table清除面包屑的float
    $("form").addClass("clear");
	$("table").addClass("clear");
    //全部删除按钮添加样式
    $(".page input[value=全部删除]").addClass("allDelete");
 

    
    //中文汉化
    $(".page table td a:contains('Edit')").html("编辑");
    $(".page table td a:contains('Details')").html("详细");
    $(".page table td a:contains('Delete')").html("删除");
    $(".page p a:contains('Edit')").html("编辑");
    $(".page p a:contains('Back to List')").html("返回列表");
    $(".page a:contains('Back to List')").html("返回列表");
    $(".page input[value=Delete]").val("删除");
    $(".page input[value=Save]").val("保存");
    $(".page input[value=Create]").val("保存");

    //站点地图
    Controller = $(".breadcrumbs .Controller").html();
    Action = $(".breadcrumbs .Action").html();

    switch (Action.toLowerCase()) {
        case "index": level2 = "列表"; break;
        case "create": level2 = "新建"; break;
        case "edit": level2 = "编辑"; break;
        case "delete": level2 = "删除"; break;
        case "details": level2 = "详细"; break;
        case "search": level2 = "搜索"; break;
        default: level2 = "";
    }
    switch (Controller.toLowerCase()) {

        
        case "encyclopediamanage": level1 = "<p>酒事百科维护</p>"; break;
        case "productmanage": level1 = "<p>推荐产品维护</p>"; break;

        default: level1 = ""; 
    }
    //alert(level2+"," + level1);

    $(".breadcrumbs").html(  level1 +
        "</p> ><p class='level2'> "+ level2 +"</p> ");

    //搜索按钮
    href = $(".BtnSearch").attr("href");
    $(".BtnSearch").removeAttr("href");
    $(".BtnSearch").click(function ()
    {
        Keyword = $(".Keyword").val();   
        location.href = href + "?Keyword=" + Keyword;
    })
    //确认删除
    var exLink = '<div class="exLink"><p>您是否确认删除此条记录？</p><a class="exConfirm" target="mainfra">确认</a><a class="exCancel" href="#">取消</a></div>';
    $('a[rel="external"]').each(function () {
        $(this).click(function () {
            $('body').append(exLink);
            $('.exConfirm').attr('href', $(this).attr('href'));
            return false;
        })
    });
   
    $('.exConfirm').live('click', function () {
        //window.open($(this).attr('href'));
        $('.exLink').remove();
    });

    $('.exCancel').live('click', function () {
        $('.exLink').remove();
        return false;
    });
    
    //表单验证
    if ($("#IsCategoryTop").attr("checked") || $("#IsHomeTop").attr("checked")) {

    }
    else {
        $("#addition").hide();
    }
   
    $("#IsCategoryTop").click(function () {               //checkBox点击事件
        if ($("#IsCategoryTop").attr("checked") || $("#IsHomeTop").attr("checked"))              //判断是否选中
            $("#addition").show();
        else
            $("#addition").hide();
    });
    $("#IsHomeTop").click(function () {               //checkBox点击事件
        if ($("#IsHomeTop").attr("checked") || $("#IsCategoryTop").attr("checked"))              //判断是否选中
            $("#addition").show();
        else
            $("#addition").hide();
    });
   
})