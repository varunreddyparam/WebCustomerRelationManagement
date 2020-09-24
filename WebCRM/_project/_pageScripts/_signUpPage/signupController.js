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

    onLoad: function () {
        let Country = Monkey.CRM.DocumentReader.Main.getObjbyId("inputCountry");
        for (var i = 0; i < CountryList.length; i++) {
            let optionElement = Monkey.CRM.DocumentReader.Main.createElement("option");
            optionElement.textContent = CountryList[i].name;
            optionElement.value = CountryList[i].value;
            Country.appendChild(optionElement);
        }
    },

    CountrySelect: function () {
        let countryValue = Monkey.CRM.DocumentReader.Main.getObjbyId("inputCountry").value;
        let countryName = Monkey.CRM.DocumentReader.Main.getObjbyId("inputCountry")[countryValue].innerText;
        let state = Monkey.CRM.DocumentReader.Main.getObjbyId("inputState");
        let stateList = CountryProvinces.filter((i) => i.Country === countryName);
        for (var i = 0; i < stateList.length; i++) {
            let optionElement = Monkey.CRM.DocumentReader.Main.createElement("option");
            optionElement.textContent = stateList[i].name;
            optionElement.value = stateList[i].code;
            state.appendChild(optionElement);
        }
    },

    CheckOrgExist: function () {
        try {
            let organizationName = Monkey.CRM.DocumentReader.Main.getObjbyId("inlineFormInputGroup");
            if (organizationName !== null || organizationName !== 'undefined') {
                let result = Monkey.CRM.Model.SignUpModel.validateOrganization(organizationName.value + ".MonkeyCrm.com");
                if (result !== null || result !== 'undefined') {
                    if (!JSON.parse(result)) {
                        successBootstrap_alert("Organization is available");
                        organizationName.innerText = organizationName.value + ".MonkeyCrm.com";
                    }
                    else
                        errorBootstrap_alert("Organization is already taken");
                }
                else {
                    throw "Service Unavailable";
                }
            }
        }
        catch (exception) {
            console.log(exception);
        }
    },

    SignUpClick: function () {
        try {
            let documentObj = Monkey.CRM.DocumentReader.Main;
            let firstName = documentObj.getObjbyId("inputFirstName").value;
            let lastName = documentObj.getObjbyId("inputLastName").value;
            let userName = this.createUserName(documentObj.getObjbyId("inlineFormInput").value, documentObj.getObjbyId("inlineFormInputGroup").value);
            let password = documentObj.getObjbyId("inputPassword1").value;
            let email = documentObj.getObjbyId("inputEmail4").value;
            let phone = documentObj.getObjbyId("inputPhone").value;
            let addressLine1 = documentObj.getObjbyId("inputAddress").value;
            let addressLine2 = documentObj.getObjbyId("inputAddress2").value;
            let addressLine3 = documentObj.getObjbyId("inputAddress3").value;
            let country = this.getCountry(documentObj.getObjbyId("inputCountry").value, documentObj);
            let city = documentObj.getObjbyId("inputCity").value;
            let state = this.getState(documentObj.getObjbyId("inputState").value, documentObj);
            let zip = documentObj.getObjbyId("inputZip").value;
            Monkey.CRM.Model.SignUpModel.createOrgandUser(firstName, lastName, userName, password, email, phone, addressLine1, addressLine2, addressLine3, country, city, state, zip);
        }
        catch (exception) {
            console.log(exception);
        }
    },

    createUserName(username,Organization) {
        return username + "@" + Organization + ".MonkeyCrm.com";
    },

    getCountry(countryValue, obj) {
        return obj.getObjbyId("inputCountry")[countryValue].innerText;
    },

    getState(stateValue, obj) {
        let stateName = CountryProvinces.filter((i) => i.code === stateValue);
        return stateName[0].name;
    }
};