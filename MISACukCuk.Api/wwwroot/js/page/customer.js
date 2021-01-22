$(document).ready(function () {
    new CustomerJS();
})

/**
 * Class quản lý các sự kiện cho trang Employee
 * CreateBy:DTSON(12/29/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        
        super();
      
    }
    setApiRouter() {
        this.apiRouter = "/api/v1/Customers";
    }
    


}




