var product = {
    init: function () {
        product.registerEvent();
    },
    //Vị trí tạo hàm muốn xử lý
    registerEvent: function () {
        //Hiện Modal khi ấn Nút Quản Lý Ảnh
        //$('.btn-images').off('click').on('click', function (e) {
        //    e.preventDefault();

        //    //Hiện Modal
        //    $('#imagesManager').show();
        //    $('#imagesManager').css("opacity", "1");

        //    //Lấy ID của Product cần xử lý
        //    $('#hidProductID').val($(this).data('id'));

        //    //Load hình của Product
        //    product.loadImages();
        //});

        //Xử lý cho nút Chọn Ảnh
        //$('#btnChooseImage').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    //Gọi CKFinder
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (url) {
        //        $('#imageList').append('<div style="float:left;"><img src="' + url + '"width="150px" height="150px" /><a href="#" class="btn-delImages"><i class="fa fa-times"></i></a></div>');
        //        $('.btn-delImages').off('click').on('click', function (e) {
        //            e.preventDefault();
        //            $(this).parent().remove();
        //        });
        //    }
        //    //Hiện popup
        //    finder.popup();
        //});

        //Xử lý cho nút Lưu
        //$('#btnSaveImages').off('click').on('click', function () {
        //    //Tạo mảng chứa hình ảnh
        //    var images = [];

        //    //Lấy ID của Product cần xử lý
        //    var id = $('#hidProductID').val();

        //    //Lấy hình ảnh khi nhấn nút Lưu
        //    $.each($('#imageList img'), function (i, item) {
        //        images.push($(item).prop('src'));
        //    });

        //    //Tạo Ajax gọi hàm xử lý ảnh từ server khi nhấn nút Lưu 
        //    $.ajax({
        //        url: '/Admin/Product/SaveImages',
        //        type: 'POST',
        //        data: {
        //            id: id,
        //            images: JSON.stringify(images)
        //        },
        //        dataType: 'json',
        //        success: function (response) {
        //            if (response.status) {
        //                $('#imagesManager').modal('hide');
        //                $('#imageList').html('');
        //                //Thông báo thành công
        //                alert("Cập nhật thành công");
        //            }

        //        }
        //    });
        //});

        //Xử lý cho nút Đóng
        //$('#btnCloseModel').off('click').on('click', function () {
        //    $('.modal-content').hide();
        //});

        //Xử lý cho nút cập nhật trạng thái
        //$('.btn-status').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    var btn = $(this);
        //    var id = $(this).data('id');

        //    $.ajax({
        //        url: '/Admin/Product/ChangeStatus',
        //        data: {
        //            id: id
        //        },
        //        dataType: 'json',
        //        type: 'POST',
        //        success: function (response) {
        //            if (response.status == true) {
        //                btn.text('Hoạt động');
        //            }
        //            else {
        //                btn.text('Tạm khóa');
        //            }
        //        }
        //    });
        //});

        // },

        //Hàm load hình cho Product
        //loadImages: function () {
        //    //Tạo Ajax gọi hàm load ảnh từ server
        //    $.ajax({
        //        url: '/Admin/Product/LoadImage',
        //        type: 'GET',
        //        data: {
        //            id: $('#hidProductID').val()
        //        },
        //        dataType: 'json',
        //        success: function (response) {
        //            var data = response.data;
        //            var html = '';
        //            $.each(data, function (i, item) {
        //                html += '<div style="float:left;"><img src="' + item + '"width="150px" height="150px" /><a href="#" class="btn-delImages"><i class="fa fa-times"></i></a></div>'
        //            });
        //            $('#imageList').html(html);

        //            $('.btn-delImages').off('click').on('click', function (e) {
        //                e.preventDefault();
        //                $(this).parent().remove();
        //            });
        //        }
        //    });

        ////Xử lý khi chọn Menu cha
        //$('#ParentID').on('click', function () {
        //    //alert('aaaa');
        //    $.ajax({
        //        url: '/Admin/Brand/SetViewBag',
        //        data: {
        //            id: id
        //        },
        //        dataType: 'json',
        //        type: 'POST'
        //    });
        //});
    }
}
product.init();