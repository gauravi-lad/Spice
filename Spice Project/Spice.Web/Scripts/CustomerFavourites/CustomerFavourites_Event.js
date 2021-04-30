$(document).ready(function () {


    $("#btnSubmit").click(function () {

        $("#frmCustomerFavourites").attr("action", "/CustomerFavourites/InsertCustomerFavourites");

        $("#frmCustomerFavourites").submit();

    });

});