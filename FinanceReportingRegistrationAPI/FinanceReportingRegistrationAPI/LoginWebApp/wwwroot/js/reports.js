(function () {
    // Automatically display credit card report
    $(document).ready(function () {
        loadCreditCardReport();
    });

    // Credit Card
    $("#creditReportTab").on("click", function () {
        loadCreditCardReport();
    });

    function loadCreditCardReport() {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/CreditCard",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#creditCard-view").html(data);
            }
        });

        loadUploadReport();
    }

    function loadUploadReport() {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/UploadReport",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#uploadReport-view").html(data);
            }
        });
    }

    // Cellular
    $("#cellularReportTab").on("click", function () {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/Cellular",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#cellular-view").html(data);
            }
        });
    });

    // Fleet
    $("#fleetReportTab").on("click", function () {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/Fleet",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#fleet-view").html(data);
            }
        });
    });

    // Payroll
    $("#payrollReportTab").on("click", function () {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/Payroll",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#payroll-view").html(data);
            }
        });
    });

    // Procurement
    $("#procurementReportTab").on("click", function () {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/Procurement",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#procurement-view").html(data);
            }
        });
    });

    // Travel
    $("#travelReportTab").on("click", function () {
        var baseUrl = window.location.origin;
        $.ajax({
            type: "GET",
            url: baseUrl + "/Reports/Travel",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#travel-view").html(data);
            }
        });
    });
})();