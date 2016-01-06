$(document).ready(function () {
    // === sa_content resize === //
    fnWindowsResize();
    function fnWindowsResize() {
        $('.container-fluid', $('.sa_content'))
            .height($(window).height() - 77 - $('.fixed_bottom').outerHeight());
        $('.sa_content').height($('.container-fluid', $('.sa_content')).height()+10 + $('.fixed_bottom').outerHeight());
    }
    $(window).resize(function () {
        fnWindowsResize();
    });

    var $scrollspyObj = $(".widget-box").find('.widget-title').clone()
        .addClass('widget-fixed')
        .appendTo($(".widget-box"));
    $scrollspyObj.hide();
    //获取要定位元素距离浏览器顶部的距离 
    var navH = $(".widget-box").offset().top;
    //滚动条事件 
    $(window).scroll(function () {
        //获取滚动条的滑动距离 
        var scroH = $(this).scrollTop();
        //滚动条的滑动距离大于等于定位元素距离浏览器顶部的距离，就固定，反之就不固定 
        var scroW = $(".widget-box .table").width();
        $scrollspyObj.css('width', scroW);
        if (scroH >= navH - 77) {
            //$scrollspyObj.show();
        } else if (scroH < navH - 77) {
            $scrollspyObj.hide();
        }
    });
    $(window).resize(function () {
        var scroW = $(".widget-box .table").width();
        $scrollspyObj.css('width', scroW);
    });

    $('body').on('click', 'input[type=checkbox].ace+.lbl', function () {
        var $cbi = $(this).find('i');
        if (!$cbi.is('.fa-check-square-o')) {
            $(this).prev('.ace').prop("checked", true);
            $cbi.attr('class', 'fa fa-check-square-o');
        } else {
            $(this).prev('.ace').prop("checked", false);
            $cbi.attr('class', 'fa fa-square-o');
        }
    });

    // === Sidebar navigation === //
    $('.submenu > a').click(function (e) {
        e.preventDefault();
        var submenu = $(this).siblings('ul');
        var li = $(this).parents('li');
        var submenus = $('.sa_sidebar li.submenu ul');
        var submenus_parents = $('.sa_sidebar li.submenu');
        if (li.hasClass('open')) {
            if (($(window).width() > 768) || ($(window).width() < 479)) {
                submenu.slideUp();
            } else {
                submenu.fadeOut(250);
            }
            li.removeClass('open');
        } else {
            if (($(window).width() > 768) || ($(window).width() < 479)) {
                submenus.slideUp();
                submenu.slideDown();
            } else {
                submenus.fadeOut(250);
                submenu.fadeIn(250);
            }
            submenus_parents.removeClass('open');
            li.addClass('open');
        }
        return false;
    });

    // === Tooltips === //
    $('.tip').tooltip();
    $('.tip-left').tooltip({ placement: 'left' });
    $('.tip-right').tooltip({ placement: 'right' });
    $('.tip-top').tooltip({ placement: 'top' });
    $('.tip-bottom').tooltip({ placement: 'bottom' });

});


(function ($) {
    function WxLoading(options) {
        var _that = this;
        var opts = {
            content: "loading..."
        };

        if (typeof options == "string") {
            opts["content"] = options;
        }

        if ($('#wxloading', $(_that)).length == 0) {
            $('<div>', { id: 'wxloading' })
                .append(
                    $('<div>', { 'class': 'wx_loading_inner' })
                        .append($('<img>', { 'class': 'wx_loading_icon' }))
                        .append($('<span>').text(opts["content"] == null
                        ? "loading..." : opts["content"]))
                )
                .appendTo($(_that));
        } else {
            $('#wxloading .wx_loading_inner span', $(_that)).text(opts["content"] == null
                        ? "loading..." : opts["content"]);
            $('#wxloading', $(_that)).show();
        }
    }

    function UnWxLoading() {
        var _that = this;
        $("#wxloading", $(_that)).remove();
    }

    function SpinnerContainer(options) {
        var _that = this;
        var opts = {
            content: "loading...",
            spinnerSize: "20px",
            containerSize: "6px"
        };

        if (typeof options == "string") {
            options = $.parseJSON(options);
        }

        var opts = $.extend({}, opts, options);

        var ctrCss = { 'width': opts.containerSize, 'height': opts.containerSize }

        var $spn_ctr = $('<div>', { 'class': 'spinner-container' })
            .append($('<div>', { 'class': 'circle1' }).css(ctrCss))
            .append($('<div>', { 'class': 'circle2' }).css(ctrCss))
            .append($('<div>', { 'class': 'circle3' }).css(ctrCss))
            .append($('<div>', { 'class': 'circle4' }).css(ctrCss));

        $('<div>', { 'class': 'spinner' }).css({ 'width': opts.spinnerSize, 'height': opts.spinnerSize })
            .append($spn_ctr.clone(true).addClass("container1"))
            .append($spn_ctr.clone(true).addClass("container2"))
            .append($spn_ctr.clone(true).addClass("container3"))
            .appendTo($(_that));
    }

    $.fn.WxLoading = WxLoading;
    $.fn.UnWxLoading = UnWxLoading;

    $.fn.SpinnerContainer = SpinnerContainer;

    $.extend({

    });

})(jQuery);
