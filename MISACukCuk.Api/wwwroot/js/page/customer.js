﻿$(document).ready(function () {
    new CustomerJS();
})


class CustomerJS extends BaseJS {
    constructor() {
        
        super();
      
    }
    setApiRouter() {
        this.apiRouter = "/api/v1/customers";
    }
    setDataUrl() {
        this.getDataUrl = "http://api.manhnv.net/api/customers";
    }



}




