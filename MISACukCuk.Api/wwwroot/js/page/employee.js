$(document).ready(function () {
    new EmployeeJS();
})
/**
 * Class quản lý các sự kiện cho trang Employee
 * CreateBy:DTSON(12/29/2020)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        //this.loadData();
        super();
    }
    setApiRouter() {
        this.apiRouter = "/api/v1/Employees";
    }
   
}
