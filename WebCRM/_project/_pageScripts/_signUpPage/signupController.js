/// <reference path="../../_library/_sdk/documentreader.js" />
/// <reference path="signupModel.js" />
/// <reference path="../../_library/countryprovincedata.js" />

// JavaScript source code
/********************************************************************************************************
Script Type: JavaScript
Author: Param Varun Reddy
Description: Monkey CRM Login Page
*********************************************************************************************************/

if (typeof (Monkey) === "undefined") { Monkey = { __namespace: true }; }
if (typeof (Monkey.CRM) === "undefined") { Monkey.CRM = { __namespace: true }; }
if (typeof (Monkey.CRM.SignUp) === "undefined") { Monkey.CRM.SignUp = { __namespace: true }; }

Monkey.CRM.SignUp.Main = {

    onSubmitClick: function () {
        try {
            let isAuthenticated = false;
            console.log("logging in");
            let userId = Monkey.CRM.DocumentReader.Main.getObjbyId("inputEmail");
            let pass = Monkey.CRM.DocumentReader.Main.getObjbyId("inputPassword");

        }
        catch (exception) {
            console.log(exception);
        }
    },

    onLoad() {
        let Country = Monkey.CRM.getObjbyId("inputCountry");
        for (var i = 0; i < countryArray.length; i++) {
            let optionElement = Monkey.CRM.DocumentReader.Main.createElement("Option");
            optionElement.textContent = countryArray[i];
            optionElement.value = countryArray[i];
            Country.appendChild(optionElement);
        }
    }
};