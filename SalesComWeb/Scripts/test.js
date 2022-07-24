function HelloPrint() {
    debugger;
    $.ajax({
        url: "/CampaignDenoDriveSetup.aspx", success: function (result) {
            debugger;
            console.log(result);
        }
    });
}

