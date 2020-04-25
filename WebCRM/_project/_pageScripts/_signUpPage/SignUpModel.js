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
    CreateOrganization(partitionKey, rowKey, orgId, orgName, orgUrl, orgfullAddress, phone1, phone2, phone3, email1, email2, email3,
        linkedinUrl, twitter, facebook, blogurl1, blogurl2, blogurl3, ownerId, ownerName, createdBy, createdByName, createdOn, createdOnBehalfBy,
        createdOnBehalfByName, modifiedOn, modifiedBy, modifiedByName, modifiedOnBehalfBy, modifiedOnBehalfByName) {
        var orgModel = new OrganizationModel(partitionKey, rowKey, orgId, orgName, orgUrl, orgfullAddress, phone1, phone2, phone3, email1, email2, email3,
            linkedinUrl, twitter, facebook, blogurl1, blogurl2, blogurl3, ownerId, ownerName, createdBy, createdByName, createdOn, createdOnBehalfBy,
            createdOnBehalfByName, modifiedOn, modifiedBy, modifiedByName, modifiedOnBehalfBy, modifiedOnBehalfByName);
    },

    CreateUser() {

    }


};