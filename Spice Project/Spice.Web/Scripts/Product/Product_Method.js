//function SaveProduct() {

//    var activeFlg = false;
//    var IsRecommended = false;
//    var IsFeatured = false;
//    var IsRefundable = false;

//    if ($("[name='Product.IsActive']").val() == 1 || $("[name='Product.IsActive']").val().toLowerCase() == "true") {
//        activeFlg = true;
//    }
//    else {
//        activeFlg = false;
//    }

//    if ($("[name='Product.IsRefundable']").val() == 1 || $("[name='Product.IsRefundable']").val().toLowerCase() == "true") {
//        IsRefundable = true;
//    }
//    else {
//        IsRefundable = false;
//    }

//    if ($("[name='Product.IsFeatured']").val() == 1 || $("[name='Product.IsFeatured']").val().toLowerCase() == "true") {
//        IsFeatured = true;
//    }
//    else {
//        IsFeatured = false;
//    }

//    if ($("[name='Product.IsRecommended']").val() == 1 || $("[name='Product.IsRecommended']").val().toLowerCase() == "true") {
//        IsRecommended = true;
//    }
//    else {
//        IsRecommended = false;
//    }
    
//    var obj_ProductVM = {

//        Product: {
//            ProductId: $("#hdnProductId").val(),
//            ProductCode: $("#txtProductCode").val(),
//            ProductName: $("#txtProductName").val(),
//            Product_Short_Desc: $("#txtProduct_Short_Desc").val(),
//            Product_Long_Desc: $("#txtProduct_Long_Desc").val(),
//            Product_Features: $("#txtProduct_Features").val(),
//            SubCategoryId: $("#drpPSCategory").val(),
//            IsActive: activeFlg,
//            IsRefundable: IsRefundable,
//            IsFeatured: IsFeatured,
//            IsRecommended: IsRecommended
//        }
//    }

//        $.ajax({

//            url: "/Product/InsertUpdateProductDetails/",

//            data: JSON.stringify(obj_ProductVM),

//            dataType: 'json',

//            type: 'POST',
//            contentType: 'application/json',
//            success: function (data) {
                
//                $('#btnSaveProduct').prop("disabled", false);
//                $("#frmProduct")[0].reset();
//                //$("#dvSuccess").text("Product Code " + data._ProductInfo.ProductCode + ", Name " + data._ProductInfo.ProductName + " Saved Successfully");
//                //$("#successmessage").modal("show");
//               // $("#dvSuccess").css("display", "block");
//            }
//        });

  
//}


//function SaveProduct() {

//    var activeFlg = false;
//    var IsRecommended = false;
//    var IsFeatured = false;
//    var IsRefundable = false;

//    if ($("[name='Product.IsActive']").val() == 1 || $("[name='Product.IsActive']").val().toLowerCase() == "true") {
//        activeFlg = true;
//    }
//    else {
//        activeFlg = false;
//    }

//    if ($("[name='Product.IsRefundable']").val() == 1 || $("[name='Product.IsRefundable']").val().toLowerCase() == "true") {
//        IsRefundable = true;
//    }
//    else {
//        IsRefundable = false;
//    }

//    if ($("[name='Product.IsFeatured']").val() == 1 || $("[name='Product.IsFeatured']").val().toLowerCase() == "true") {
//        IsFeatured = true;
//    }
//    else {
//        IsFeatured = false;
//    }

//    if ($("[name='Product.IsRecommended']").val() == 1 || $("[name='Product.IsRecommended']").val().toLowerCase() == "true") {
//        IsRecommended = true;
//    }
//    else {
//        IsRecommended = false;
//    }

//    var obj_ProductVM = {

//        Product: {
//            ProductId: $("#hdnProductId").val(),
//            ProductCode: $("#txtProductCode").val(),
//            ProductName: $("#txtProductName").val(),
//            Product_Short_Desc: $("#txtProduct_Short_Desc").val(),
//            Product_Long_Desc: $("#txtProduct_Long_Desc").val(),
//            Product_Features: $("#txtProduct_Features").val(),
//            SubCategoryId: $("#drpPSCategory").val(),
//            IsActive: activeFlg,
//            IsRefundable: IsRefundable,
//            IsFeatured: IsFeatured,
//            IsRecommended: IsRecommended
//        }
//    }
//    var arr = [];
//    $("#tblDocumentDetails").find("[id^='td_']").each(function (j) {
//        if ($(this).val() != undefined) {
//            arr.push(document.getElementById("Resumefileselect_" + j).files[0]);
//        }
      
//    })
//    var fileData = new FormData();

//    for (var i = 0; i < arr.length; i++) {
//        fileData.append("fileInput", arr[i]);
//    }
    
//    fileData.append(obj_ProductVM, obj_ProductVM)
//    $.ajax({

//        url: "/Product/InsertUpdateProductDetails/",

//        //data: JSON.stringify(fileData),

//        data: (fileData),

//        dataType: 'json',

//        type: 'POST',
//        contentType: 'application/json',
//        success: function (data) {

//            $('#btnSaveProduct').prop("disabled", false);
//            $("#frmProduct")[0].reset();
//            //$("#dvSuccess").text("Product Code " + data._ProductInfo.ProductCode + ", Name " + data._ProductInfo.ProductName + " Saved Successfully");
//            //$("#successmessage").modal("show");
//            // $("#dvSuccess").css("display", "block");
//        }
//    });


//}

//function SaveProduct() {

//    var activeFlg = false;
//    var IsRecommended = false;
//    var IsFeatured = false;
//    var IsRefundable = false;

//    if ($("[name='Product.IsActive']").val() == 1 || $("[name='Product.IsActive']").val().toLowerCase() == "true") {
//        activeFlg = true;
//    }
//    else {
//        activeFlg = false;
//    }

//    if ($("[name='Product.IsRefundable']").val() == 1 || $("[name='Product.IsRefundable']").val().toLowerCase() == "true") {
//        IsRefundable = true;
//    }
//    else {
//        IsRefundable = false;
//    }

//    if ($("[name='Product.IsFeatured']").val() == 1 || $("[name='Product.IsFeatured']").val().toLowerCase() == "true") {
//        IsFeatured = true;
//    }
//    else {
//        IsFeatured = false;
//    }

//    if ($("[name='Product.IsRecommended']").val() == 1 || $("[name='Product.IsRecommended']").val().toLowerCase() == "true") {
//        IsRecommended = true;
//    }
//    else {
//        IsRecommended = false;
//    }

  
//    var arr = [];
//    $("#tblDocumentDetails").find("[id^='td_']").each(function (j) {
//        if ($(this).val() != undefined) {
//            arr.push(document.getElementById("Resumefileselect_" + j).files[0]);
//        }

//    })
//     var fileData = new FormData();

//    for (var i = 0; i < arr.length; i++) {
//        fileData.append("fileInput_"+i, arr[i]);
//    }

//    var otherData = $("#frmProduct").serializeArray();
//    $(otherData).each(function (index, item) {
//        fileData.append(item.name, item.value);
//    })


//    $.ajax({

//        url: "/Product/InsertUpdateProductDetails/",

//        type: "post",

//        contentType: false, // Not to set any content header  

//        processData: false, // Not to process data  


//        data: fileData,

//        dataType: 'json',

       
//        success: function (data) {

//            $('#btnSaveProduct').prop("disabled", false);
//            $("#frmProduct")[0].reset();
//            //$("#dvSuccess").text("Product Code " + data._ProductInfo.ProductCode + ", Name " + data._ProductInfo.ProductName + " Saved Successfully");
//            //$("#successmessage").modal("show");
//            // $("#dvSuccess").css("display", "block");
//        }
//    });


//}

function GetSubCategoryByCategory() {

    $("#drpStateId").val();
    $("#statecodelabel").text("");
    $.ajax({
        url: '/Product/GetPSCategoryByCategoryId',
        data: { CategoryId: $("#drpPCategory").val() },
        method: 'GET',
        async: false,
        success: function (data) {
            if (data != null) {
                BindSubCategoryData(data);
            }
        }
    });
}

function BindSubCategoryData(data) {
    debugger;

    $("#drpPSCategory").html("");

    var htmltext = "";
    htmltext += "<option value=''>-Select SubCategory -</option>";
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            htmltext += "<option value='" + data[i].Id + "'>" + data[i].SubCategoryName + "</option>";
        }
    }
    $("#drpPSCategory").html(htmltext);

    //var id = $("#hdnDistrictId").val();
   
    //if (id > 0) {
    //    $("#drpDistrict option[value=" + id + "]").attr("selected", true);
    //}
}

function ValidateFileUpload(Id,secondId) {
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
            fuData.value='';
            alert("Photo only allows file types of PNG, JPG, JPEG.");
            
        }
 
}