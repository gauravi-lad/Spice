
function GetCompanies() {


    var companyViewModel =
        {
            CompanyInfo: {

                CompanyName: $("#hdnCompanyName").val(),

                CompanyCode: $("#txtCompanyCode").val(),

                Is_Active: $("#drpStatus").val(),
            },

            GridDetail: {

                Pager: SetPager($("#divCompanyPager"))
            }
        }

    $.ajax({

        url: "/Company/GetCompanies",

        data: JSON.stringify(companyViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            BindGrid(obj, "CompanyList");

            $("#divCompanyPager").html(obj.GridDetail['Pager']['PageHtmlString']);

            FriendlyMessages(obj);

        }
    });
}

function ValidateFileUpload(Id, secondId) {
    debugger;
    var fuData = document.getElementById(Id);
    var FileUploadPath = fuData.value;

    var Extension = FileUploadPath.substring(
        FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

    //The file uploaded is an image

    if (Extension == "png" || Extension == "jpeg" || Extension == "jpg") {

        // To Display
        if (fuData.files && fuData.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(secondId).attr('src', e.target.result);
            }

            reader.readAsDataURL(fuData.files[0]);
        }

    }

    //The file upload is NOT an image
    else {
        fuData.value = '';
        alert("Photo only allows file types of PNG, JPG, JPEG.");

    }

}