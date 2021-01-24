/**
 * Format dữ liệu ngày/tháng/năm
 * CreatedBy:DoTuanSon(12/29/2020 )
 * @param {any} date
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";

    }
    else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return day + '/' + month + '/' + year;
    }

}
/**
 * Format dữ liệu tiền lương
 * CreatedBy:DoTuanSon(12/29/2020 )
 * @param {any} money
 */
function formatMoney(money) {
    if (money) {
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    }
    else return num = "0";
}
/**
 * Đổ dữ liệu từ server lên Combobox  Vị trí tương ứng
 * @param {any} url
 */
function loadPosition(url) {
    var selectPosition = $('select#cbxPosition');
    selectPosition.empty();
    //Gọi service tương ứng
    $.ajax({
        url: url + "/api/v1/positions",
        method: "GET"
    }).done(function (res) {
        if (res) {
            $.each(res, function (index, obj) {
                var option = $(`<option value="${obj.PositionId}">${obj.PositionName}</option>`);
                selectPosition.append(option);
            })
        }
    }).fail(function (res) {
    });
}
/**
 * Đổ dữ liệu từ server lên Combobox  Phòng Ban tương ứng
 * @param {any} url
 */
function loadDepartment(url) {
    var selectDepartment = $('select#cbxDepartment');
    selectDepartment.empty();
    //Gọi service tương ứng
    $.ajax({
        url: url + "/api/v1/departments",
        method: "GET"
    }).done(function (res) {
        if (res) {
            $.each(res, function (index, obj) {
                var option = $(`<option value="${obj.DepartmentId}">${obj.DepartmentName}</option>`);
                selectDepartment.append(option);
            })
        }
        $('.loading').hide();
    }).fail(function (res) {
        $('.loading').hide();
    })
}

