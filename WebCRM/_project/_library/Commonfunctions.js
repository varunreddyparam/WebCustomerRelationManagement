function CreateUUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function ipLookup() {
    $.ajax('http://ip-api.com/json')
        .then(
            function success(response) {
                response.country.toString().replace(/\s/g, '').toUpperCase();
                //console.log('User\'s Location Data is ', response);
                //console.log('User\'s Country', response.country);
            },

            function fail(data, status) {
                console.log('Request failed.  Returned status of',
                    status);
            }
        );
}

function errorBootstrap_alert(message) {
    $('#alert_placeholder').html('<div class="alert alert-danger alert-dismissible fade show"><a class="close" data-dismiss="alert">×</a><span><i class="fa fa-times-circle"></i> ' + message + '</span></div>');
}

function successBootstrap_alert(message) {
    $('#alert_placeholder').html('<div class="alert alert-success alert-dismissible fade show"><a class="close" data-dismiss="alert">×</a ><span><i class="fa fa-check-circle" ></i > ' + message + '</span></div > ');
}

function handleForm(event) {
    event.preventDefault();
}

$(function () {
    $('[data-toggle="addressPopover"]').popover({
        container: 'body',
        html: true,
        placement: 'right',
        sanitize: false,
        content: function () {
            return $('#AddressPopoverContent').html()
        }
    })
});

$(function () {
    $('[data-toggle="fullNamePopover"]').popover({
        container: 'body',
        html: true,
        placement: 'right',
        sanitize: false,
        content: function () {
            return $('#FullNamePopoverContent').html()
        }
    })
});