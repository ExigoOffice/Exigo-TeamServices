import * as VSSService from "VSS/Service";
import * as WitService from "TFS/WorkItemTracking/Services";
import * as ExtensionContracts from "TFS/WorkItemTracking/ExtensionContracts";
import * as $ from "jquery";
import Controls = require("VSS/Controls");
import Grids = require("VSS/Controls/Grids");
import { Project } from "./models/models";
import {util} from "./modules/util";
import {Login} from "./modules/login";



exports.init = function(){
    // Demo: allows you to access fields of the work item.
    WitService.WorkItemFormService.getService().then(function (workItemFormSvc) {
        workItemFormSvc.getFieldValue("TicketID").then(data =>{
            // in this case we are accessing a custom field
           console.log(`TicketId:${data}`)
        }); 
    });
    //initiates login script
    Login.Init();
}
