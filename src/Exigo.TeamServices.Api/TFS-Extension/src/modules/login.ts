import * as $ from "jquery";
import { util } from "./util";
import { TicketService } from "../services/TicketSErvice";

export class Login {

    public static Init() {
        //can be changed depending on changes in the flow or ui of login 
        if (util.IsLoggedIn()) {
            $("#login-page").hide();
            $("#main-content").show()
        }else{
            $("#main-content").hide()
            $("#login-page").show();
            this.registerEventHandler();
        }
    }

    public static login(callback?) {
        //sets the context
        var context = $("#login-page");
        var userName = $("#userName", context).val();
        var password = $("#password", context).val();
        //passes username and password to api and sets cookie with token
        //will need to adjust for actual session tokens
        TicketService.Login(userName, password, function (err, token) {
           if(err){
               console.log(err)
           }
        });
    }

    public static registerEventHandler() {
        $("#login").on("click", function () {
            Login.login(function () {
                Login.Init();
            });
        })
    }
}