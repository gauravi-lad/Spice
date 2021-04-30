$(document).ready(function () {
    var Flag = '';

    // specify the columns
    var columnDefs = [
        { headerName: "Category Name", field: "CategoryName", sortable: true, filter: true },
        { headerName: "Short Description", field: "CategoryShortDescription", sortable: true, filter: true },
        { headerName: "Long Description", field: "CategoryLongDescription", sortable: true, filter: true },
    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            var data = event.data;
            $("#myGrid_Category").hide();
            $("#btnAddCategory").hide();
            $("#hdnCategoryId").val(data.CategoryId);
            $("#txtCategoryName").val(data.CategoryName);
            $("#txtShortDescription").val(data.CategoryShortDescription);
            $("#txtLongDescription").val(data.CategoryLongDescription);
            $("#txtCategoryCode").val(data.CategoryCode);
            $("#hdnCategoryCode").val(data.CategoryCode);
            $("#hdncategoryImage").val(data.CategoryImage);
            $('#img1').attr('src', '/Uploads/CategoryImages/' + data.CategoryImage);
            $("#dvInsert").show();

        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_Category');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Category/GetCategoryListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });


    $("#btnSubmit").click(function () {

        $("#frmCategory").attr("action", "/Category/InsertCategory");
        $("#frmCategory").submit();


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
    $("#btnAddCategory").click(function () {
        $("#dvInsert").show();
        $("#myGrid_Category").hide();
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

function IsCategoryCodeexist() {
    debugger;
    if ($("#hdnCategoryCode").val() != $("#txtCategoryCode").val()) {
        var result = $.ajax({
            type: "POST",
            async: false,
            url: "/Category/CheckExisting_CategoryCode",
            data: { CategoryCode: $("#txtCategoryCode").val() }
        }).responseText;
        if (result == 'true' || result == true) {
            //$("#txtCategoryCode").addClass('is-invalid');
            $(".Existerror").text("Category Code exist");

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

