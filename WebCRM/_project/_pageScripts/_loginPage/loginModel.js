/// <reference path="../../_library/commonfunctions.js" />
/// <reference path="../../_library/azurefunctionlib.js" />
/// <reference path="../../_library/_entitymodels/_organizationmodel.js" />
/// <reference path="../../_library/_sdk/documentreader.js" />
/// <reference path="../../_library/_entitymodels/_usermodel.js" />

// JavaScript source code
/********************************************************************************************************
Script Type: JavaScript
Author: Param Varun Reddy
Description: Monkey CRM Login Page Model
*********************************************************************************************************/

if (typeof Monkey === "undefined") { Monkey = { __namespace: true }; }
if (typeof Monkey.CRM === "undefined") { Monkey.CRM = { __namespace: true }; }
if (typeof Monkey.CRM.Model === "undefined") { Monkey.CRM.Model = { __namespace: true }; }

Monkey.CRM.Model.LoginModel = {
    getOrganizationDetail: function (email) {
        try {
            let errorMsg = "Organization doesn't exist, Please SignUp";
            window.sessionStorage.setItem("SessionId", CreateUUID());
            let azureRequest = new AzureFunctionLibrary(window.sessionStorage.getItem("SessionId"), "Organization", JSON.stringify({ name: email }));
            let orgModel = azureRequest.getSingleRequest();
            if (orgModel === null || orgModel === "undefined") {
                throw errorMsg;
            }
            else
                window.sessionStorage.setItem("_orgDetail", orgModel);
        }
        catch (exception) {
            console.log(exception);
            errorBootstrap_alert(exception);
            window.stop();
        }
    },

    getUserAuthenticated: function (UserName, Password) {
        try {
            let loginFailMsg = "InCorrect UserName or Password";
            let azureAuthRequest = new AzureFunctionLibrary(window.sessionStorage.getItem("SessionId"), "User", JSON.stringify({ user: UserName, pass: Password }));
            let userModel = azureAuthRequest.getSingleRequest();
            if (userModel === null || userModel === "undefined") {
                throw loginFailMsg;
            }
            else
                window.sessionStorage.setItem("_useDetail", userModel);
        }
        catch (exception) {
            console.log(exception);
            errorBootstrap_alert(exception);
            window.stop();
        }
    }
};