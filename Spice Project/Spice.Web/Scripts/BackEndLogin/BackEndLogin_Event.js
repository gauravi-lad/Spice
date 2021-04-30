$(document).ready(function () {
    //$("#btnLogin").click(function () {
    //      ValidateUser();
    // });
    $("#btnLogin").click(function () {
        $("#frmBackEnd").attr("action", "/BackEndLogin/BackEndLogin");
        $("#frmBackEnd").submit();
    });

});