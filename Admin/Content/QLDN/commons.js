var xajax;
function evAjax(parameter, request, ajaxUrl, type) {
    //if (xajax && xajax.abort) xajax.abort(); //cancel ajax    
    xajax = jQuery.ajax({
        url: ajaxUrl,
        data: parameter,
        type: "POST",
        dataType: type || "json",
        async: true,
        success: function (json) {
            $('#divloadding').hide();
            request(json);
        },
        beforeSend: function () {
            cssLoadding();
        },
        error: function (xhr, status) {
            $('#divloadding').hide();
        }
    });
};
function popupGeneral() {
    if ($("#modalStyle1").length > 0) {
        $("#modalStyle1").remove();
        $(".modal-backdrop").remove();
    }
    $("body").append('<div class="modal modal-kay fade fade--in in" id="modalStyle1" aria-hidden="false" style="display: block; padding-right: 12px;">' +
            '<div class="modal-dialog" style="width:50%;margin: 0px auto;"> ' +
                '<div class="modal-content"> ' +
                    '<div class="modal-header"> ' +
                        '<button type="button" class="close" data-dismiss="modal" id="ClPop" style="opacity:1;"><i class="fa fa-times"></i></button> ' +
                        '<h4 class="modal-title">Modal title</h4> ' +
                    '</div> ' +
                    '<div class="modal-body"></div>' +
                '</div> ' +
            '</div>' +
        '</div>' +
        '<div class="modal-backdrop fade in"></div>');
};
function ClPop2() {
    $("#ClPop,#btnBack").unbind("click").click(function () {
        $("#modalStyle1").remove();
        $(".modal-backdrop").remove();
    });
};
function cssLoadding() {
    var textLoad = "<div class='preloader' id='divloadding'></div>";

    if ($("#divloadding").length > 0) {
        $('#divloadding').show();
    } else {
        $("body").append(textLoad);
    }
};
function checkPhoneEvent(str) {
    var filter = /^\+?[\d]{7,15}$/;
    var rtn = filter.test(str);
    return rtn;
};

function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."); //format num: 1000 -> 1.000
};
function alertErr(query, timeout) {
    $("#modalStyle1 .modal-header .alert-err.system_message").remove();
    $("#modalStyle1 .modal-header").prepend(Message_Alert_Cart(query, false));
    $("#modalStyle1 .modal-header .alert-heading").css({ "font-size": "18px", "line-height": "20px" });
    setTimeout(function () { $("#modalStyle1 .modal-header .alert-err.system_message").remove(); }, timeout);
};
function alertSucc(query, timeout) {
    $("#modalStyle1 .modal-header .alert-err.system_message").remove();
    $("#modalStyle1 .modal-header").prepend(Message_Alert_Cart(query, true));
    $("#modalStyle1 .modal-header .alert-heading").css({ "font-size": "18px", "line-height": "20px" });
    setTimeout(function () { $("#modalStyle1 .modal-header .alert-err.system_message").remove(); }, timeout);
};
function Message_Alert_Cart(query, status) {
    var color = (status == true ? "#07a3b2" : "#f0605d");
    query = '<div class="message-alert animated animated-delay-2400ms animated-duration-1400ms visible fadeInDown alert-err system_message" style="overflow: hidden; position: absolute;width: 100%;margin-top: 0px;padding: 12px 0 0 10px;background: ' + color + ';border-radius: initial;">' +
                '<div class="alert-icon-wrapper comp-err-icon-red">' +
                    '<span class="err-icon" style=" display: inline-block; background: #fff; border-radius: 50%; width: 45px; height: 45px; text-align: center; color: #c3c3c3; cursor: default; border: 1px solid #e2e2e2; margin-top: -3px;">' +
                        '<i class="fa fa-3x fa-warning" style=" padding: 0; font-size: 30px; color: ' + color + '; line-height: 43px; "></i>' +
                    '</span>' +
                '</div>' +
                '<p style="margin-top: 8px;"><span class="alert-heading" style="color:white">' + query + '</span></p>' +
            '</div>';
    return query;
};
//validate email
function checkMail(str) {
    var filter = /^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.([a-zA-Z]){2,4})$/;
    var rtn = filter.test(str);
    return rtn;
};

(function () {
    popupModal = function (options) {
        var defaults = {
            id: 'modal',
            header: '',// html of header
            body: 'content here',// html of body
            footer: ''// html of footer
            , modalchild: 0
        };
        var hasheader = '';
        var hasfooter = '';
        if (options.modalchild == 0) {
            $('.popupmodal').remove();
        }
        $('.modal-backdrop').remove();
        if (options.header == undefined) hasheader = '';
        else hasheader = '<div class="modal-header"><p class="h3 modal-title text-uppercase">' + options.header + '</p></div>';
        if (options.footer == undefined) hasfooter = '';
        else hasfooter = '<div class="modal-footer">' + options.footer + '</div>';
        var _html = '<div class="modal fade fade--in modal-cus popupmodal modal-kay in" aria-hidden="false" ' +
            'id="' + options.id + '">' +
                        '<div class="modal-dialog"  style="margin:0 auto;">' +
                            '<button type="button" class="close" data-dismiss="modal" style="position:absolute;top:0;right:0;z-index:1"><span></span></button>' +
                            '<div class="modal-content">' +
                                hasheader +
                                '<div class="modal-body">' + options.body + '</div>' +
                                hasfooter +
                            '</div>' +
                        '</div>' +
                    '</div>';
        $(_html).appendTo('body');
        //$('body').appendChild(_html);
        $('#' + options.id).modal('show');
        //autosize($('textarea'));
        //mainResize(options.id);
    };
})(jQuery);

function mainResize(box) {
    try {
        var divBox = document.getElementById(box);
        if (divBox) divBox.style.left = (document.body.offsetWidth / 2) - (divBox.offsetWidth / 2) + "px";
        var divPopup = divBox;
        //if (divPopup && divPopup.visible()) {
        var sizeW = windowSize();
        var divPopupL = (sizeW[0] - divPopup.offsetWidth) / 2;
        var divPopupT = (sizeW[1] - divPopup.offsetHeight) / 2;
        divPopupL = (divPopupL > 0 ? divPopupL : 0);
        divPopupT = (divPopupT > 0 ? divPopupT : 10);
        var offsetY = typeof (window.pageYOffset) == 'number' ? window.pageYOffset : document.documentElement.scrollTop;
        divPopup.style.left = divPopupL + 'px';
        divPopup.style.top = divPopupT + 'px';
        //}
    } catch (ex) {
    }
};

function windowSize() {
    var a = 0, iMyHeight = 0;
    //    if (typeof (window.innerWidth) == 'number') {
    //        a = window.innerWidth;
    //        iMyHeight = window.innerHeight;
    //    } else 
    if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
        a = document.documentElement.clientWidth;
        iMyHeight = document.documentElement.clientHeight;
    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
        a = document.body.clientWidth;
        iMyHeight = document.body.clientHeight;
    }
    return [a, iMyHeight];
};
