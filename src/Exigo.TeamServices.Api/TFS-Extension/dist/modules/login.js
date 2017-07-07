define(["require", "exports", "jquery", "./util", "../services/TicketSErvice"], function (require, exports, $, util_1, TicketSErvice_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Login = (function () {
        function Login() {
        }
        Login.Init = function () {
            //can be changed depending on changes in the flow or ui of login 
            if (util_1.util.IsLoggedIn()) {
                $("#login-page").hide();
                $("#main-content").show();
            }
            else {
                $("#main-content").hide();
                $("#login-page").show();
                this.registerEventHandler();
            }
        };
        Login.login = function (callback) {
            //sets the context
            var context = $("#login-page");
            var userName = $("#userName", context).val();
            var password = $("#password", context).val();
            //passes username and password to api and sets cookie with token
            //will need to adjust for actual session tokens
            TicketSErvice_1.TicketService.Login(userName, password, function (err, token) {
                if (err) {
                    console.log(err);
                }
            });
        };
        Login.registerEventHandler = function () {
            $("#login").on("click", function () {
                Login.login(function () {
                    Login.Init();
                });
            });
        };
        return Login;
    }());
    exports.Login = Login;
});
