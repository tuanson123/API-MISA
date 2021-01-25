class BaseJS {
    constructor() {
        //Các khởi tạo
        this.host = "";
        this.apiRouter = null;
        this.setApiRouter();
        this.loadData();
        this.clickEvent();

    }
    setApiRouter() { }

    clickEvent() {
        var me = this;
        /**
         *Ân hiện form
         * **/
        $("#btnShow").click(me.btnAddOnClick.bind(me));
        $("#btnClose").click(function () {
            $("#btnDialog").hide();
        });

        //Đóng
        $("#m-btn-close").click(function () {
            $("#m-error").hide();
        });
        // Thực hiện form xác nhận xóa
        $('.m-del').click(function () {
            //var span = $('#idRowDel');
            //span.empty();
            //span.append(me.EmployeeCode);
            // hiển thị form xác nhận xóa
            $('#m-popup-confirmDel').show();
        });

        // Thực hiện xóa record khi nhấn nút Có trên giao diện form xác nhận xóa
        $('#btnDel').click(function () {

            //Gọi service tương ứng thực hiên lưu dữ liệu
            $.ajax({
                url: me.host + me.apiRouter + `/${me.recordId}`,
                method: "DELETE",
                data: JSON.stringify(),
                contentType: 'application/json'
            }).done(function (res) {

                //Hiện thông báo xóa thành công
                var showPopup = $('div .warning-success');
                showPopup.empty();
                showPopup.append($(`<i class="fas fa-info-circle"></i>&nbsp;<p>` + res.Messenger + `</p>`));
                $(".m-inform").show().delay(2000).fadeOut(
                );
                //Ân Form nhập và Form thông báo
                $('#m-popup-confirmDel').hide();
                $('.m-dialog').hide();
                me.loadData();
                console.log(res);

            }).fail(function (res) {
                //Nếu xóa chưa được đổ ra để xem lỗi
                console.log(entity);
                var msgs = JSON.parse(res.responseText);
                var dataMsgs = msgs.Data;
                console.log(dataMsgs);

            })

        });


        /**
         *Nạp dữ liệu khi nhấn nạp
         * **/
        $('#btnRefresh').click(function () {
            me.loadData();
        });
        /**
         *Ân dữ liệu khi nhấn hủy
         * **/
        $('#btnCancel').click(function () {
            $("#btnDialog").hide();
        });

        // Thực hiện đóng form xác nhận xóa, khi nhấp nút [Không]
        $('#m-btn-cancel2').click(function () {
            $('#m-popup-confirmDel').hide();
        });


        /**
        *Thực hiện lưu dữ liệu khi nhấn lưu
        * **/
        $('#btnSave').click(me.btnSaveOnClick.bind(me));

        //load form
        //Load dữ liệu cho các combobox
        var select = $('select#cbxCustomerGroup');
        select.empty();
        //Load chờ màn hình
        $('.loading').show();

        /**
        *Hiện thị thông tin chi tiết khi click đúp chuột vào
        * **/
        $('table tbody').on('dblclick', 'tr', function () {
            $('.m-del').show();
            //Màu khi click đúp
            $(this).find('td').addClass('row-selected');
            try {
                $('.loading').show();
                //Reset lại field text của trường dữ liệu text và email
                $("input[type=text],input[type=email], input[type=date]").val("");
                $("input[type=text],input[type=email],input[type=date]").removeClass();
                me.FormMode = 'Edit';
                //Hiển thị nút xóa 
                $('.m-btn-confirm button').show();
                //Lấy khóa chính của bản ghi
                var recordId = $(this).data('recordId');
                me.recordId = recordId;
                //Lấy dữ liệu nhóm vị trí
                loadPosition(me.host);
                //lấy dữ liệu nhóm phòng ban
                loadDepartment(me.host);



                // Gọi service lấy thông tin chi tiết của bản ghi
                $.ajax({
                    url: me.host + me.apiRouter + `/${recordId}`,
                    method: "GET"
                }).done(function (res) {
                    //Build lên form chi tiết
                    console.log(res);
                    var inputs = $('input[fieldName],select[fieldName]');
                    $.each(inputs, function (index, input) {
                        //Lấy các tên trường tương ứng
                        var propertyName = $(this).attr('fieldName');
                        //Lấy giá trị tương ứng
                        var value = res[propertyName];
                        if (value) {
                            //Định dạng lại ngày tháng nếu các trường có field như này
                            if (propertyName == "DateOfBirth" || propertyName == "DateOfJoining" || propertyName == "DateOfID") {
                                var now = new Date(value);
                                var day = ("0" + now.getDate()).slice(-2);
                                var month = ("0" + (now.getMonth() + 1)).slice(-2);
                                value = now.getFullYear() + "-" + (month) + "-" + (day);
                            }
                            $(this).val(value);
                        }
                        if (this.tagName == "SELECT") {
                            //Đổ đúng dữ liệu vô Combobox
                            if (this.id == "cbxGender" || this.id == "cbxWorkStatus") {
                                $(this).val(value);
                            }
                            else {
                                //Lấy giá trị trường
                                var propValueName = $(this).attr('fieldValue');
                                value = res[propValueName];
                            }
                        }
                        $(this).val(value);
                    })
                    //Ân màn chờ
                    $('.loading').hide();
                    //Hiện Form nhập
                    $('#btnDialog').show();
                    //Ân form hiện lên dòng mã nhân viên
                    $("#txtEmployeeCode").focus();
                }).fail(function (res) {
                    $('.loading').hide();
                })



            } catch (e) {
                console.log(e);
            }
        })
        /**
         *Validate bắt buộc nhập
         * CreateBy:DoTuanSon(1/4/2021)
         */
        $('.input-required').blur(function () {
            //Kiểm tra dữ liệu đã nhập, nếu để trống thi cảnh báo:
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được phép để trống');
                $(this).attr("validate", false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        })
        /**
         *Validate email nhập đúng định dạng
         * CreateBy:DoTuanSon(1/4/2021)
         */
        $('input[type="email"]').blur(function () {
            var valueToTest = $(this).val();
            //Yêu cầu theo Email
            var testEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            if (!testEmail.test(valueToTest)) {
                //Nếu email khác dạng chuẩn có thông báo
                $(this).addClass('border-red');
                $(this).attr('title', 'Email không đúng định dạng');
                $(this).attr("validate", false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        })




    }
    /**
     * Load dữ liệu
     * CreatedBy:DTSON(12/29/2020)
     * */

    loadData() {
        var me = this;
        $('table tbody').empty();
        //lấy thông tin các cột giữ liệu:
        var column = $('table thead th');
        //Hiện màn hình load
        $('.loading').show();
        //Gọi service tương ứng
        $.ajax(
            {
                url: me.host + me.apiRouter,
                method: "GET",
            }
        )
            .done(function (res) {
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $(tr).data('recordId', obj.EmployeeId);
                    //Lấy thông tin các cột giữ liệu sẽ map tương ứng

                    $.each(column, function (index, th) {
                        var td = $(`<td></td>`);
                        var fieldName = $(th).attr('fieldname');
                        var value = obj[fieldName];

                        //Ep dữ liệu từ cơ sở dữ liệu hiện ra màn hình
                        if (fieldName == "Gender") {
                            if (value == "0") {
                                value = "Nữ";
                            }
                            else if (value == "1") {
                                value = "Nam";
                            }
                            else {
                                value = "Không xác định";
                            }
                        }
                        else if (fieldName == "WorkStatus") {
                            if (value == "1")
                                value = "Đang làm việc";
                            else value = "Đã nghỉ việc";
                        }

                        //Định dạng
                        var formatType = $(th).attr('formatType');

                        switch (formatType) {
                            //Đinh dạng ngày cho những trường là ngày/thanng/năm
                            case "ddmmyyyy":
                                td.addClass("text-align-center");
                                value = formatDate(value);
                                break;
                            //Đinh dạng ngày cho những trường là tiền
                            case "MoneyVND":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            //Căn giữa 
                            case "Center":
                                td.addClass("text-align-center");
                                break;
                            default:
                                break;
                        }
                        //Đẩy dữ liệu vào từng hàng
                        td.append(value);
                        $(tr).append(td);
                    })
                    //Đẩy dữ liệu cho bảng
                    $('table tbody').append(tr);
                    $('.loading').hide();
                })

            })
            .fail(function (res) { })

    }
    /**
     * Hàm xử lý khi ấn button thêm mới
     * CreatedBy:DOTUANSON(1/6/2021)
     * */
    btnAddOnClick() {
        try {
            $('.m-del').hide();
            var me = this;
            me.FormMode = 'Add';
            //Reset lại field text của trường dữ liệu
            $("input[type=text],input[type=email]").val("");
            $('input').val(null);
            loadPosition(me.host);
            loadDepartment(me.host);
            //Hiển thị thông tin chi tiết
            $("#btnDialog").show();
            $("#txtEmployeeCode").focus();

        }
        catch (e) {
            console.log(e);
        }
    }
    /**
     * Hàm xử lý khi ấn button lưu dữ liệu
     * CreatedBy:DOTUANSON(1/6/2021)
     * */
    btnSaveOnClick() {
        var me = this;
        //Validate dữ liệu Email
        var inputValidates = $('.input-required,input[type="email"]');
        $.each(inputValidates, function (index, input) {

            $(input).trigger('blur');
        })
        //Validate dữ liệu độ dài
        var inputNotValids = $('input[validate="false"]');
        if (inputNotValids && inputNotValids.length > 0) {
            inputNotValids[0].focus();
            return;
        }

        //thu thập thông tin dữ liệu được nhập=>buid thành object
        //Lấy tất cả các control nhập liệu
        var inputs = $('input[fieldName],select[fieldName]');
        var entity = {};
        $.each(inputs, function (index, input) {
            //Lấy tên trường và các giá trị tương ứng
            var propertyName = $(this).attr('fieldName');
            var propertyValue = $(this).attr('fieldValue');
            var value = $(this).val();
            //Lấy giá trị trong combobox
            if ($(this).attr('inputType') == "combobox") {
                if ($('option:selected', this)) {
                    entity[propertyValue] = value;
                }
            }
            else {

                entity[propertyName] = value;
            }


        })

        var method = "POST";
        //Phương thức sửa
        if (me.FormMode == 'Edit') {
            method = "PUT";
            entity.EmployeeId = me.recordId;
        }
        //Đường dẫn
        var stringUrl = me.host + me.apiRouter;
        if (me.FormMode == "Edit") {
            //Truyền ID vào đường dẫn để lấy 
            stringUrl = me.host + me.apiRouter + `/${entity.EmployeeId}`;
        }
        //Gọi service tương ứng thực hiên lưu dữ liệu
        $.ajax({
            url: stringUrl,
            method: method,
            data: JSON.stringify(entity),
            contentType: 'application/json'
        }).done(function (res) {
            //Sau khi lưu thành công thì: 
            //+đưa ra thông báo 
            //+ẩn form chi tiết, load lại dữ liệu
            //Thêm thành công
            var showPopup = $('div .warning-success');
            showPopup.empty();
            //Hiện thông báo thành công
            showPopup.append($(`<i class="fas fa-info-circle"></i>&nbsp;<p>` + res.Messenger + `</p>`));
            $('.m-inform').show().delay(2000).fadeOut();
            //Ân form
            $("#btnDialog").hide();
            me.loadData();
            console.log(res);

        }).fail(function (res) {
            $('#m-error').show();
            var msgs = JSON.parse(res.responseText);
            var dataMsgs = msgs.Data; // Lấy data lỗi trả về từ res
            $('#popup-list-content').empty(); // Làm trống danh sách hiển thị lỗi
            $.each(dataMsgs, function (index, msg) {
                //Chèn các lỗi vào danh sách thông báo 
                var msg = $(`<div style="display:flex; padding:10px;">
                                <div class="error-icon"><i class="fas fa-exclamation-circle"></i></div>
                                <div class="error-text">${msg}</div>
                            </div>`);
                $('#popup-list-content').append(msg);
            })
        })
    }
}