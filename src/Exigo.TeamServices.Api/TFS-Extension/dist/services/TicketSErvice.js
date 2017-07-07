define(["require", "exports", "jquery", "../modules/util"], function (require, exports, $, util_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var TicketService = (function () {
        /**
         * handles communication between the client and Exigo.TFSApi
         */
        function TicketService() {
        }
        TicketService.Login = function (userName, password, callback) {
            //TODO: Add api calls
            var data = null;
            // $.post("https://jsonplaceholder.typicode.com/posts/1",(data,status,req)=>{
            //     this.SessionToken = data
            //     console.log(data,status,req)
            // })
            data = "Stufff";
            util_1.util.setCookie("exigoticketing", data, 1);
            callback(data);
        };
        //TODO: Make Decorator to add the session tokens to the requests
        TicketService.GetTicket = function (TicketId, callback) {
            //get ticket data
            //Add Session token in the headers of every subsequent request
            $.get({
                url: "/test",
                headers: { "Authorization": this.SessionToken }
            }).then(function (data) {
                //do stuff
            });
            callback(); //pass in data and do stuff
        };
        TicketService.GetDetail = function () {
        };
        TicketService.GetTicketDetails = function () {
        };
        ;
        TicketService.CreateDetail = function () {
        };
        TicketService.UpdateDetail = function () {
        };
        TicketService.DeleteDetail = function () {
        };
        return TicketService;
    }());
    exports.TicketService = TicketService;
});
