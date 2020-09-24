/// <reference path="../../_library/_sdk/documentreader.js" />
/// <reference path="loginmodel.js" />

// JavaScript source code
/********************************************************************************************************
Script Type: JavaScript
Author: Param Varun Reddy
Description: Monkey CRM Login Page
*********************************************************************************************************/

if (typeof (Monkey) === "undefined") { Monkey = { __namespace: true }; }
if (typeof (Monkey.CRM) === "undefined") { Monkey.CRM = { __namespace: true }; }
if (typeof (Monkey.CRM.Login) === "undefined") { Monkey.CRM.Login = { __namespace: true }; }

Monkey.CRM.Login.Main = {

    onSubmitClick: function () {
        try {
            let isAuthenticated = false;
            console.log("logging in");
            let userId = Monkey.CRM.DocumentReader.Main.getObjbyId("inputEmail");
            let pass = Monkey.CRM.DocumentReader.Main.getObjbyId("inputPassword");
            Monkey.CRM.Model.LoginModel.getOrganizationDetail(userId.value.split("@")[1].split(".")[0]);
            let Authenticate = Monkey.CRM.Model.LoginModel.getUserAuthenticated(userId.value, pass.value);
            if (Authenticate !== null || Authenticate !== "undefined") {

                isAuthenticated = Authenticate;
                if (isAuthenticated)
                    window.location.href = "../../_viewPages/Dashboard.html";
                else {
                    let loginFailMsg = "Incorrect UserName or Password";
                    errorBootstrap_alert(loginFailMsg);
                }
            }
        }
        catch (exception) {
            console.log(exception);
        }
    }
};