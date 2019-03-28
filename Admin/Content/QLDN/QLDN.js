$(document).ready(function () {
    evGeneral();
    //$(window).resize(function () {
    //    var w = window.outerWidth;
    //    var h = window.outerHeight;
    //    if (w > 1200) {
    //        var checki = $("[aria-hidden]").attr("aria-hidden");
    //        if (checki == "true") {
    //            $(".menu").removeClass("actmenu");
    //            $("[aria-hidden]").attr("aria-hidden", false);
    //            $(".subnav").css("display", "none");

    //        }
    //    }
    //});
});
function evGeneral() {

    $(".navmenuinside ul li").unbind("click").click(function () {
        $(".sidebargroup.ui.open").removeClass("open");
        if ($(this).find("a").hasClass("active")) {
            $(this).find("a").removeClass("active");
            $("#sidebar").css("display", "none");
        } else {
            $(".headermenu.active").removeClass("active");
            $(this).find("a").addClass("active");
            var index=$(this).index();
            $("#sidebar").css("display", "block");
            $("#sidebarwrapper ul:eq('" + index + "')").addClass("open");

        }
    });

}
