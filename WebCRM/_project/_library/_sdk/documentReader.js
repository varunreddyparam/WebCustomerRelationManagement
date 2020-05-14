// JavaScript source code
/********************************************************************************************************
Script Type: JavaScript
Author: Param Varun Reddy
Description: Monkey CRM Login Page
*********************************************************************************************************/

if (typeof (Monkey) === "undefined") { Monkey = { __namespace: true }; }
if (typeof (Monkey.CRM) === "undefined") { Monkey.CRM = { __namespace: true }; }
if (typeof (Monkey.CRM.DocumentReader) === "undefined") { Monkey.CRM.DocumentReader = { __namespace: true }; }

Monkey.CRM.DocumentReader.Main = {
    getObjbyId: function (name) {
        return document.getElementById(name);
    },

    getObjbyClass: function (name) {
        return document.getElementsByClassName(name);
    },

    createElement: function (elementName) {
        let element = document.createElement(elementName);
        return element;
    }
};