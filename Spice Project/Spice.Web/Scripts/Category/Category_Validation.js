$(document).ready(function () {


    $("#frmCategory").validate({
        ignore: [],
        rules: {
            "CategoryMasterDataModel.CategoryName": {
                required: true//,
                //UniqueCompanyName: true
            }//,
            //"UploadImage": {
            //    required: true,
            //    extension: "jpeg|png|jpg|JPEG|PNG|JPG"
            //},
            //"CompanyInfo.CompanyCode": {
            //    required: true,
            //},

        },
        messages: {
            "CategoryMasterDataModel.CategoryName": {
                required: "Category Name is a required field."
            }//,

            //"UploadImage": {
            //    required: "Company Image Path is a required field.",
            //    extension: "Please upload a proper image"
            //},
            //"CompanyInfo.CompanyCode": {
            //    required: "Company Code is a required field."
            //},

        }
    });


    //$.validator.addMethod("UniqueCompanyName", function (value, element) {

    //    if ($("#hdnCompanyName").val() != $("#txtCompanyName").val()) {
    //        var result = $.ajax({
    //            type: "POST",
    //            async: false,
    //            url: "/Company/CheckCompanyName",
    //            data: { CompanyName: value }
    //        }).responseText;
    //        if (result == 'true' || result == true) {
    //            return false;
    //        }
    //        else {
    //            return true;
    //        }
    //    }
    //    else {
    //        return true;
    //    }
    //}, "This Company Name already exists. Please enter another Company Names.");




});