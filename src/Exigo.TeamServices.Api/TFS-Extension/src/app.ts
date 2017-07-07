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
    WitService.WorkItemFormService.getService().then(function (workItemFormSvc) {
        workItemFormSvc.getFieldValue("TicketID").then(data =>{
           console.log(`TicketId:${data}`)
        }); 
    });
    Login.Init();
}
