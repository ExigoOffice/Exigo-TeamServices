import * as $ from "jquery";
import { util } from "./util";
import { TicketService } from "../services/TicketSErvice";

export class Login {

    public static Init() {
        if (this.isLoggedIn()) {
            $("#login-page").hide();
            $("#main-content").show()
        }else{
            $("#main-content").hide()
            $("#login-page").show();
            this.registerEventHandler();
        }
    }

    public static isLoggedIn() {
        var cookie = util.getCookie("exigoticketing")
        return cookie !=  null;
    }

    public static login(callback?) {
        //sets the context
        var context = $("#login-page");
        var userName = $("#userName", context).val();
        var password = $("#password", context).val();
        //passes username and password to api and sets cookie with token
        TicketService.Login(userName, password, function (err, token) {
            if (err) {
                console.log(err)
            } else {
                util.setCookie("exigoticketing", token, 1);
                if (callback) {
                    callback();
                }
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