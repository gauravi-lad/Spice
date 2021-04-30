$(document).ready(function () {

    var switchStatus = false;
    $("#switch-1").on('change', function () {
        if ($(this).is(':checked')) {
            switchStatus = $(this).is(':checked');
            $("#txtIsActive").val(switchStatus);
        }
        else {
            switchStatus = $(this).is(':checked');
            $("#txtIsActive").val(switchStatus);

        }
    });



    $("#btnSubmit").click(function () {

        $("#frmCustRating").attr("action", "/CustomerRating/InsertCustomerRating");

        $("#frmCustRating").submit();

    });

  
});