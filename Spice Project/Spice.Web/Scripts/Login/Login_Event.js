$(document).ready(function () {
    //$("#btnLogin").click(function () {
    //    console.log("hit");
    //    //if ($("#frmFormEnd").valid()) {
    //        ValidateUser();
    //    //}
    //});
    $("#btnLogin").click(function () {
        $("#frmFormEnd").attr("action", "/Login/FrontEndLogin");
        $("#frmFormEnd").submit();
    });
    $("#btnRegistration").click(function () {
        if (validate()) {
            $("#frmRegisteration").attr("action", "/Login/InsertData");
            $("#frmRegisteration").submit();
        }
    });
    //$("#btnRegistration").click(function () {
    //    console.log("hit");
    //    //if ($("#frmFormEnd").valid()) {
    //        RegisterUser();
    //    //}
    //});

    //function validat()
    //{
    //    ValidateUser();
    //}

});


function validate() {
    var result = false;
    var password = $("#txtPassword").val();
    var count = password.length;


    if (count < 5) {
        $("#errorPassword").text("minimum 5 characters required.")
    }
    else {
        $("#errorPassword").text("");
        result = true;
    }
    return result;
}