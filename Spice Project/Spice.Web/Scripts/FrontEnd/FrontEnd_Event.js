$(document).ready(function () {

    //$('#btnSaveProduct').click(function () {
    //    if ($("#frmProduct").valid()) {

    //        $("#btnSaveProduct").prop("disabled", true);

    //        SaveProduct();
    //    }
    //});

    //$(document).on("change", "input[type='checkbox']", function () {

    //    if ($(this).prop("checked")) {

    //        $(this).val(true);
    //    }
    //    else {

    //        $(this).val(false);
    //    }
    //});


    if ($("#hdnPaymentFailed").val() != null && $("#hdnPaymentFailed").val() == 1) {
        toastr.error("Payment failed. Issues while placing order, please try again.");
    }
    else if ($("#hdnPaymentSuccessfull").val() != null && $("#hdnPaymentSuccessfull").val() == 1) {
        toastr.success("Payment successfull. Order placed successfully.");
    }
    else if ($("#hdnOrderResult").val() != null && $("#hdnOrderResult").val() == 1) {
        toastr.success("Order placed successfully.");
    }

    $("input:radio:first").prop("checked", true).trigger("click");

    $("#btnSubmit").click(function () {
        $("#frmProductDetails").attr("action", "/FrontEnd/InsertCustomerRating");
        $("#frmProductDetails").submit();
    });


    $("#btnSubmit2").click(function () {
        $("#hdnProductTotalPrice").val($("#lblTotalPrice").html());
        $("#hdnProductUnit").val($("#hdnUnit_" + $('input[name="catoption"]:checked').attr('id')).val());
        $("#hdnProductPriceSKUId").val($('input[name="catoption"]:checked').attr('id'));
        $("#hdnProductQuantity").val($("#txtQuantity").val());

        $("#frmProductDetails2").attr("action", "/FrontEnd/Checkout");
        $("#frmProductDetails2").submit();
    });


});

