$(document).ready(function () {


    // specify the columns
    var columnDefs = [
        { headerName: "Sub Category", field: "SubCategoryName", sortable: true, filter: true },
        { headerName: "Category", field: "CategoryName", sortable: true, filter: true },
        { headerName: "Description", field: "SubCategoryDesc", sortable: true, filter: true },
    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            var data = event.data;
            $("#myGrid_SubCategory").hide();
            $("#btnSubAddCategory").hide();
            $("#hdnSubCategoryId").val(data.Id);
            $("#txtSubCategoryName").val(data.SubCategoryName);
            $("#ddlCategory").val(data.CategoryId);
            $("#txtSubCategoryDesc").val(data.SubCategoryDesc);
            $("#txtsubCategoryCode").val(data.SubCategoryCode);
            $("#hdnSubCategoryCode").val(data.SubCategoryCode);
            $("#hdnsubcategoryImage").val(data.SubCategoryImage);
            $('#img1').attr('src', '/Uploads/SubCategoryImage/' + data.SubCategoryImage);
            $("#dvInsert").show();

        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_SubCategory');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/SubCategory/Get_Listing'}).then(function (data) {
        gridOptions.api.setRowData(data);
    });


    $("#btnSubmit").click(function () {
        $("#frmSubCategory").attr("action", "/SubCategory/Insert_Update");
        $("#frmSubCategory").submit();
    });
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
    $("#btnAddSubCategory").click(function () {
        $("#dvInsert").show();
        $("#myGrid_SubCategory").hide();
    });
});

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

function IsSubCategoryCodeexist() {
    debugger;
    if ($("#hdnSubCategoryCode").val() != $("#txtsubCategoryCode").val()) {
        var result = $.ajax({
            type: "POST",
            async: false,
            url: "/SubCategory/CheckExisting_SubCategoryCode",
            data: { SubCategoryCode: $("#txtsubCategoryCode").val() }
        }).responseText;
        if (result == 'true' || result == true) {
            //$("#txtCategoryCode").addClass('is-invalid');
            $(".Existerror").text("SubCategory Code exist");
            // $(".Existerror").addClass('error invalid - feedback');
            $("#hdnFlag").val("false");
            document.getElementById("btnSubmit").disabled = true;
            return false;

        }
        else {
            $(".Existerror").text("");
            $("#hdnFlag").val("true");
            document.getElementById("btnSubmit").disabled = false;
            return true;
        }
    }
    else {
        $(".Existerror").text("");
        $("#hdnFlag").val("true");
        document.getElementById("btnSubmit").disabled = false;
        return true;
    }
}