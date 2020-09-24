/// <reference path="../../_library/commonfunctions.js" />
/// <reference path="../../_library/azurefunctionlib.js" />
/// <reference path="../../_library/_entitymodels/_organizationmodel.js" />
/// <reference path="../../_library/_sdk/documentreader.js" />
/// <reference path="../../_library/_entitymodels/_usermodel.js" />

// JavaScript source code
/********************************************************************************************************
Script Type: JavaScript
Author: Param Varun Reddy
Description: Monkey CRM SignUp Page Model
*********************************************************************************************************/

if (typeof Monkey === "undefined") { Monkey = { __namespace: true }; }
if (typeof Monkey.CRM === "undefined") { Monkey.CRM = { __namespace: true }; }
if (typeof Monkey.CRM.Model === "undefined") { Monkey.CRM.Model = { __namespace: true }; }

Monkey.CRM.Model.SignUpModel = {
   

    validateOrganization: function (orgName) {
        if (window.sessionStorage.getItem("SessionId") === null) {
            window.sessionStorage.setItem("SessionId", CreateUUID());
        }
        let azureLib = new AzureFunctionLibrary(window.sessionStorage.getItem("SessionId"), "Organization", JSON.stringify({ organizationName: orgName }));
        return azureLib.ValidateRequest();
    },

    createOrgandUser: function (firstName, lastname, username, password, email, phone, addressline1, addressline2, addressline3, country, city, state, zip) {
        try {
            let registration = new RegistrationModel(firstName, lastname, username, password, email, phone, addressline1, addressline2, addressline3, country, city, state, zip);
            let azureLib = new AzureFunctionLibrary(window.sessionStorage.getItem("SessionId"), "Organization", JSON.stringify({ registration }));
            let result = azureLib.CreateRequest();
            if (result) {
                successBootstrap_alert("Organization Created Successfully");
            }
        }
        catch (exception) {
            console.log(exception);
            errorBootstrap_alert(exception);
        }
    }

};