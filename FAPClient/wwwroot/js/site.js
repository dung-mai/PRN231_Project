// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function callAjax(apiUrl, successFunction) {
    let repsonseData;
    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: apiUrl,
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Content-Type": "application/x-www-form-urlencoded",
        },
        success: function (data) {
            repsonseData = data;
            successFunction(data);
        },
        error: function (xhr, status, error) {
            console.log(xhr);
        },
    });
    return repsonseData;
}
