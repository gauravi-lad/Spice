// localStorage --> using localStorage data can be get even after page refresh/ reload 
//window.history.replaceState --> block re-post of form if page is refresh after form post at first time.

$(document).ready(function () {

    // $( "#datepicker, #datepicker1 , #datepicker2" ).datepicker();

    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    //on page reload keep the last selected menu active in menu bar
    //$(this).addClass("active");
    //localStorage.setItem("ActiveMenu", $(this).children('a').attr('class'));

    //if (localStorage.getItem("ActiveMenu") !== "") {
    //    var setActiveMenu = document.getElementsByClassName(localStorage.getItem("ActiveMenu"));
    //    localStorage.removeItem("ActiveMenu");
    //}

    //$('.module').click(function (event) {
    //    event.stopPropagation();
    //});


    // });
    //***************************************************//

    //Generic Form Validation
    $("form").submit(function (event) {
        var content = this;
        var form_valid = true;

        $(content).find(".required").each(function (index) {
            if ($.trim($(this).val()) === "") {
                form_valid = false;
                // added for css changes for validation -- Venkat start--
                $(this).parents(".form-group").find(".required").addClass("is-invalid");
                $(this).parents(".form-group").find(".error").addClass("invalid-feedback");
                //added for css changes for validation -- Venkat end--
                $(this).parents(".form-group").find(".error").text($(this).attr("placeholder") + " is required");
            }
            else {
                //added for css changes for validation -- Venkat start--
                $(this).parents(".form-group").find(".required").removeClass("is-invalid");
                $(this).parents(".form-group").find(".error").removeClass("invalid-feedback");
                //added for css changes for validation -- Venkat end--
                $(this).parents(".form-group").find(".error").text("");
            }
        });

        $(content).find(".validatePositiveNo").each(function (index) {
            if ($(this).val() < 0) {
                form_valid = false;
                $(this).parents(".form-group").find(".error").text("Enter Positive No");
                validNumber = false;
            }
            else {
                $(this).parents(".form-group").find(".error").text("");
                validNumber = true;
            }
        });
        if (form_valid === true) {
            $(".loader").show();
        }
        else {
            event.preventDefault();
        }
    });

    if ($("#isPostValid").val() === "1") {
        $(".toast-body").text("Data Saved Successfully!");
        $('.toast').toast('show');
    }
    else if ($("#isPostValid").val() === "2") {
        $(".toast-body").text("Already Exists..!!");
        $('.toast').toast('show');
    }
    else if ($("#isPostValid").val() === "0") {
        $(".toast-body").text("something went wrong please try again.");
        $('.toast').toast('show');
    }
    else {
        $(".toast-body").text("");
    }

    //***************************************//
    $("#hdnPageNo").val("0");


    $(".validateEmail").focusout(function () {
        if (!validateEmail($(this).val())) {
            $(this).parents(".form-group").find(".error").text("Enter valid Email Id");
            validEmail = false;
        }
        else {
            $(this).parents(".form-group").find(".error").text("");
            validEmail = true;
        }

    });

    $(".validateMobile").keyup(function () {
        filter = /^\d*(?:\.\d{1,2})?$/;
        if (!filter.test(this.value)) { $(this).val(""); return false }
    });

    $(".validateMobile").focusout(function () {
        if ($(this).val() !== "")
            if (!validateMobile($(this).val())) {
                $(this).parents(".form-group").find(".error").text("Enter valid Mobile No.");
                validMobile = false;
            }
            else {
                $(this).parents(".form-group").find(".error").text("");
                validMobile = true;
            }
    });

    $.ajax({

        url: "../FrontEnd/Get_AllMenus/",

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            //$("#Menubind").append(response);

        }
    });

    //Cal();
});


//function Cal() {

//    alert(parseInt($(this).find(".product-quantity").html()));
//    var mySum = 0;
//    var myQuantity = 0;


//    $('#Cartlist tr').each(function () {
//        var value = (parseFloat($(this).find(".product-subtotal").html()));
//        var Quantity = (parseInt($(this).find(".product-quantity").html()));
//        console.log(parseInt($(this).find(".product-quantity").html()))
//        if (!isNaN(value) && value.length != 0) {
//            mySum += parseFloat(value);
//            myQuantity += parseFloat(Quantity);
//        }

//        $("#totalproPrice").text(myQuantity);
//        $("#GrandPrice").text(mySum);

//    });
//}


function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

function validateMobile($mobile) {
    var mobileReg = /^[6-9]\d{9}$/;
    return mobileReg.test($mobile);
}


//Generic Pagination - Logic revised from Google pagination

function GetNextPage() {
    var last_page = $("#hdnPageNo").val();
    var i = parseInt(last_page) + 1;
    $("#hdnPageNo").val(i);
    $.when(Pagination_load_page(i)).done(function () {
        if (parseInt($("#hdnPagination_Page_Count").val() - 1) === parseInt($("#hdnPageNo").val())) {
            $(".page-next").hide();
        }
    });

}

function GetPrevPage() {
    var first_page = parseInt($("#hdnPageNo").val());
    if (first_page >= 0) {
        $("#hdnPageNo").val(parseInt(first_page - 1));
        $.when(Pagination_load_page(first_page - 1)).done(function () {
            if (parseInt($(".pagination-page").first().attr("page-no") - 1) === parseInt($("#hdnPageNo").val())) {
                $(".page-previous").hide();
            }
        });
    }
}

function GetCurrentPage(item) {
    if (item !== "0") {
        $("#hdnPageNo").val(parseInt(item - 1));
        $.when(Pagination_load_page(parseInt(item - 1))).done(function () {
            if (parseInt($("#hdnPagination_Page_Count").val() - 1) === parseInt($("#hdnPageNo").val())) {
                $(".page-next").hide();
            }

            if (parseInt($(".pagination-page").first().attr("page-no") - 1) === parseInt($("#hdnPageNo").val())) {
                $(".page-previous").hide();
            }
        });

    }
}

//*********************************************************/
