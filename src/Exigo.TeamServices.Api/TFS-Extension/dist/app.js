define(["require", "exports", "TFS/WorkItemTracking/Services", "./modules/login"], function (require, exports, WitService, login_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    exports.init = function () {
        // Demo: allows you to access fields of the work item.
        WitService.WorkItemFormService.getService().then(function (workItemFormSvc) {
            workItemFormSvc.getFieldValue("TicketID").then(function (data) {
                // in this case we are accessing a custom field
                console.log("TicketId:" + data);
            });
        });
        //initiates login script
        login_1.Login.Init();
    };
});
