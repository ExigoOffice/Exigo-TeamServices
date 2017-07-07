import * as $ from "jquery"
import {util} from "../modules/util"

export class TicketService{
    
    

    public static SessionToken: any
    /**
     * handles communication between the client and Exigo.TFSApi
     */
    constructor() {
        
    }

    public static Login(userName, password, callback){
        //TODO: Add api calls
        var data = null;
        // $.post("https://jsonplaceholder.typicode.com/posts/1",(data,status,req)=>{
        //     this.SessionToken = data
        //     console.log(data,status,req)
        // })
        data = "Stufff"
        util.setCookie("exigoticketing", data, 1);
        callback(data)
    }

    //TODO: Make Decorator to add the session tokens to the requests
    public static GetTicket(TicketId, callback){
        //get ticket data
        //Add Session token in the headers of every subsequent request
        $.get({
            url: "/test",
            headers: {"Authorization": this.SessionToken}
        }).then((data)=>{
            //do stuff
        })
        callback() //pass in data and do stuff
    }

    public static GetDetail(){

    }

    public static GetTicketDetails(){

    }
    ;
    public static CreateDetail(){

    }

    public static UpdateDetail(){

    }

    public static DeleteDetail(){

    }

    
}