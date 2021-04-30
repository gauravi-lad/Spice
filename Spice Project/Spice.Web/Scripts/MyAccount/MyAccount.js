$(document).ready(function () {


    $("#btnSubmit").click(function () {
        $("#frmCustomer").attr("action", "/MyAccount/InsertData");
        $("#frmCustomer").submit();
    });
    $("#btnAddAddressSubmit").click(function () {
        $("#frmAddAddress").attr("action", "/MyAccount/InsertCustomerAddressData");
        $("#frmAddAddress").submit();
    });
    $("#btnPassword").click(function () {
        $("#frmPassword").attr("action", "/MyAccount/ChangePassword");
        $("#frmPassword").submit();
    });
});

function validatePassword() {
    var flag = false;
    if ($("#txtPassword").val() != null && $("#txtConfirmPassword").val() != null) {
        if ($("#txtPassword").val() != $("#txtConfirmPassword").val()) {
            flag = true;
            $("#changepassworderr").text("Password and Confirm Password must be same.");
            document.getElementById("btnPassword").disabled = true;
        } else {
            $("#changepassworderr").text("");
            document.getElementById("btnPassword").disabled = false;
        }
    }
}


function validateFirstName() {
    var flag = false;
    var firstName = $("#txtFirstName").val();
    var regex = /^[A-Za-z']+$/
   var isValid = regex.test(document.getElementById("txtFirstName").value);
    if (isValid) {
        var firstNamecount = firstName.length;
        if (firstNamecount < 3) {
            $("#errorFirstName").text("minimum 3 characters required.")
            document.getElementById("btnSubmit").disabled = true;
        }
        else {
            flag = true;
            $("#errorFirstName").text("");
            validateUserDetails();
            document.getElementById("btnSubmit").disabled = false;
            //if (result) {
            //    //validateLastName(false);
            //}
        }
    }
    else
    {
        $("#errorFirstName").text("Please enter on alphabets only.")
        document.getElementById("btnSubmit").disabled = true;
    }
}

function validateLastName() {
    var flag = false;
    var lastName = $("#txtLastName").val();
    
    var regex = /^[A-Za-z']+$/
    var isValid = regex.test(document.getElementById("txtLastName").value);
    if (isValid) {
    var lastNamecount = lastName.length;

    if (lastNamecount < 3) {
        $("#errorLastName").text("minimum 3 characters required.")
        document.getElementById("btnSubmit").disabled = true;
    }
    else {
        $("#errorLastName").text("");
        flag = true;
        document.getElementById("btnSubmit").disabled = false;
        validateUserDetails();
        //if (result) {
        //   // validateFirstName(false);
        //}
        }
    }
    else {
        $("#errorLastName").text("Please enter on alphabets only.")
        document.getElementById("btnSubmit").disabled = true;
    }
}

function validateUserDetails() {
    if ( $("#errorLastName").text() == "" &&  $("#errorFirstName").text() == "")
    {
        document.getElementById("btnSubmit").disabled = false;
    }
    else
    {
        document.getElementById("btnSubmit").disabled = true;
    }
}

function validateStreet_1() {
    var street_1 = $("#txtStreet_1").val();

    if (street_1 == null) {
        $("#errorStreet_1").text("minimum 5 characters required.")
    }
    else if (street_1.length < 5) {
        $("#errorStreet_1").text("minimum 5 characters required.")
    }
    else {
        $("#errorStreet_1").text("");
    }
    validateAddressDetails();
}

function validateStreet_2() {
    var street_2 = $("#txtStreet_2").val();

    if (street_2 == null)
    {
        $("#errorStreet_2").text("minimum 5 characters required.")
    }
    else if (street_2.length < 5) {
        $("#errorStreet_2").text("minimum 5 characters required.")
    }
    else {
        $("#errorStreet_2").text("");
    }
    validateAddressDetails();
}

function validateCity() {
    var city = $("#txtCity").val();

    if (city == null) {
        $("#errorCity").text("minimum 5 characters required.")
    }
    else if (city.length < 5) {
        $("#errorCity").text("minimum 5 characters required.")

    }
    else {
        $("#errorCity").text("");

    }
    validateAddressDetails();
}

function validateState() {
    var lastState = $("#txtState").val();

    var lastStatecount = lastState.length;

    if (lastState == null) {
        $("#errorState").text("minimum 5 characters required.")
    }
    else if (lastState.length < 5) {
        $("#errorState").text("minimum 5 characters required.")

    }
    else {
        $("#errorState").text("");

    }

    validateAddressDetails();
}

function validatePincode() {
    var pincode = $("#txtPincode").val();

    var pincodecount = pincode.length;

    if (pincode == null) {
        $("#errorPincode").text("minimum 5 characters required.")
    }
    else if (pincode.length < 5) {
        $("#errorPincode").text("minimum 5 characters required.")
    }
    else {
        $("#errorPincode").text("");
    }
    validateAddressDetails();
}

function validateAddressDetails() {
    if ($("#errorStreet_1").text() == "" && $("#errorStreet_2").text() ==  ""
        && $("#errorCity").text() ==  "" && $("#errorState").text() ==  "" && $("#errorPincode").text() ==  "") {
        document.getElementById("btnAddAddressSubmit").disabled = false;
    }
    else {
        document.getElementById("btnAddAddressSubmit").disabled = true;
    }
}


function GetAddressMasterDataById(id) {
    $.ajax({

        url: "/MyAccount/GetCustomerAddressDataById",

        data: { id: id },

        dataType: 'json',

        type: 'GET',

        contentType: 'application/json',

        success: function (response) {
            $("#hdnAddressId").val(response.Id);
            $("#hdnCustomerId").val(response.Customer_Id);
            $("#txtStreet_1").val(response.Street_1);
            $("#txtStreet_2").val(response.Street_2);
            $("#txtCity").val(response.City);
            $("#txtState").val(response.State);
            $("#txtPincode").val(response.Pincode);
            $("#inputCountry").val(response.Country);
            $("#inputCountry").attr("data-value", response.Country);
            $('#inputCountry').css('display', 'inline-block');
            $(".nice-select").remove();
            $("#addAddress").modal();
        },
        error: function (response) {
            alert("Erroe Occur.");
            console.log("Erroe Occur.");
        }
    });
}
function clearForm()
{
    $("#txtStreet_1").val("");
    $("#txtStreet_2").val("");
    $("#txtCity").val("");
    $("#txtState").val("");
    $("#txtPincode").val("");
    $("#inputCountry").val("");
    $("#inputCountry").attr("data-value", "");
    $('#inputCountry').css('display', 'inline-block');
    $(".nice-select").remove();
    $("#errorStreet_1").text("");
    $("#errorStreet_2").text("");
    $("#errorCity").text("");
    $("#errorState").text("");
    $("#errorPincode").text("");
}

function show(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            $('#profilePicture_img').attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}


