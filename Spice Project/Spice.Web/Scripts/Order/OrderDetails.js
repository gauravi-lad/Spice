$(document).ready(function () {

    if ($("#hdnResult").val() != "") {
        if ($("#hdnResult").val() == "1") {
            $('.dvSuccess').show();
            $('.successAlrt').text('Order Status Updated Successfully');
            
        }
        else if ($("#hdnResult").val() == "2") {
            $('.dvSuccess').show();
            $('.successAlrt').text('Invoice Generated Successfully');

            $('html, body').animate({
                scrollTop: $("#invoice-section").offset().top
            }, 5000);
        }
        else if ($("#hdnResult").val() == "3") {
            $('.dvSuccess').show();
            $('.successAlrt').text('Invoice Updated Successfully');

            $('html, body').animate({
                scrollTop: $("#invoice-section").offset().top
            }, 5000);
        }
        else if ($("#hdnResult").val() == "0") {
            $('.dvError').show();
            $('.errorAlrt').text('Opps Something went Wrong !!!');
        }
        $("#hdnResult").val("");
    }
    $("#dvMsg").delay(2000).hide(0);


    $("#drp_OrderStatus").change(function () {
        if ($(this).val != "") {
            $("#frmUpdateOrderStatus").submit();
        }
    });

 
});