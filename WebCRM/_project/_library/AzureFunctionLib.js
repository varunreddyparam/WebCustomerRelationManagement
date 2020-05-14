class AzureFunctionLibrary {
    constructor(id, EntityLogicalName, RequestBody) {
        this.defaultUrl = "https://webcustomerrelationmanagementapi.azurewebsites.net/api/";
        this.UniqueId = id;
        this.LogicalName = EntityLogicalName;
        this.requestBody = RequestBody;
    }

    getSingleRequest() {
        let result = null;
        let name = "RetrieveSingleRequest";
        let queryString = { id: this.UniqueId, entitylogicalname: this.LogicalName };
        let rqUrl = this.createRequestUrl(name, queryString);
        $.ajax({
            url: rqUrl,
            type: "POST",
            contentType: 'application/json',
            data: this.requestBody,
            dataType: 'json',
            crossDomain: true,
            async: false,
            cache: false,
            headers: {
                'Cache-Control': 'no-cache'
            },
            success: function (response) {
                if (Array.isArray(response)) {
                    if (response.length > 0) {
                        console.log("Success: " + response[0]);
                        result = response;
                    }
                }
            },
            error: function (ex) {
                console.log("Failure getting user token");
            }
        });
        return result;
    }

    CreateRequest() {
        let result = null;
        let name = "CreateRequest";
        let queryString = { id: this.UniqueId, entitylogicalname: this.LogicalName };
        let rqUrl = this.createRequestUrl(name, queryString);
        $.ajax({
            url: rqUrl,
            type: "POST",
            contentType: 'application/json',
            data: this.requestBody,
            dataType: 'json',
            crossDomain: true,
            async: false,
            cache: false,
            headers: {
                'Cache-Control': 'no-cache'
            },
            success: function (response) {
                if (Array.isArray(response)) {
                    if (response.length > 0) {
                        console.log("Success: " + response[0]);
                        result = response;
                    }
                }
            },
            error: function (ex) {
                console.log("Failure getting Create token");
            }
        });
        return result;

    }

    //only for login Currently
    ValidateRequest() {
        let result = null;
        let name = "ValidateRequest";
        let queryString = { id: this.UniqueId, entitylogicalname: this.LogicalName };
        let rqUrl = this.createRequestUrl(name, queryString);
        $.ajax({
            url: rqUrl,
            type: "POST",
            contentType: 'application/json',
            data: this.requestBody,
            dataType: 'json',
            crossDomain: true,
            async: false,
            cache: false,
            headers: {
                'Cache-Control': 'no-cache'
            },
            success: function (response) {
                if (response !== null || response !== 'undefined') {
                    console.log("Success: " + response);
                    result = response;
                }

            },
            error: function (ex) {
                console.log("Failure getting user token");
            }
        });
        return result;
    }

    UpdateRequest() {
        let result = null;
        let name = "UpdateRequest";
        let queryString = { id: this.UniqueId, entitylogicalname: this.LogicalName };
        let rqUrl = this.createRequestUrl(name, queryString);
        $.ajax({
            url: rqUrl,
            type: "POST",
            contentType: 'application/json',
            data: this.requestBody,
            dataType: 'json',
            crossDomain: true,
            async: false,
            cache: false,
            headers: {
                'Cache-Control': 'no-cache'
            },
            success: function (response) {
                if (Array.isArray(response)) {
                    if (response.length > 0) {
                        console.log("Success: " + response[0]);
                        result = response;
                    }
                }
            },
            error: function (ex) {
                console.log("Failure getting Create token");
            }
        });
        return result;

    }
    createRequestUrl(name, queryStrings) {
        return this.defaultUrl + name + "?" + this.serializeString(queryStrings);
    }

    serializeString(queryStrings) {
        let str = [];
        for (var p in queryStrings)
            if (queryStrings.hasOwnProperty(p)) {
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(queryStrings[p]));
            }
        return str.join("&");
    }
}