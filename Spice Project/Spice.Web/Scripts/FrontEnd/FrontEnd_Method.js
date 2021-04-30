//Changes by Aditya [Commented for now] 

function SetAddress(elem) {
    var shippingAddressID = $('input:radio[name="shippingAddressRadios"]:checked').attr("data-shipping");
    var billingAddressID = $('input:radio[name="billingAddressRadios"]:checked').attr("data-billing");

    $("#hdnShippingAdressId").val(shippingAddressID);
    $("#hdnBillingAdressId").val(billingAddressID);

    $(elem).closest('form').submit(); return false;
}

function SaveProduct() {

    var activeFlg = false;
    var IsRecommended = false;
    var IsFeatured = false;
    var IsRefundable = false;

    if ($("[name='Product.IsActive']").val() == 1 || $("[name='Product.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    if ($("[name='Product.IsRefundable']").val() == 1 || $("[name='Product.IsRefundable']").val().toLowerCase() == "true") {
        IsRefundable = true;
    }
    else {
        IsRefundable = false;
    }

    if ($("[name='Product.IsFeatured']").val() == 1 || $("[name='Product.IsFeatured']").val().toLowerCase() == "true") {
        IsFeatured = true;
    }
    else {
        IsFeatured = false;
    }

    if ($("[name='Product.IsRecommended']").val() == 1 || $("[name='Product.IsRecommended']").val().toLowerCase() == "true") {
        IsRecommended = true;
    }
    else {
        IsRecommended = false;
    }

    var obj_ProductVM = {

        Product: {
            ProductId: $("#hdnProductId").val(),
            ProductCode: $("#txtProductCode").val(),
            ProductName: $("#txtProductName").val(),
            Product_Short_Desc: $("#txtProduct_Short_Desc").val(),
            Product_Long_Desc: $("#txtProduct_Long_Desc").val(),
            Product_Features: $("#txtProduct_Features").val(),
            SubCategoryId: $("#drpPSCategory").val(),
            IsActive: activeFlg,
            IsRefundable: IsRefundable,
            IsFeatured: IsFeatured,
            IsRecommended: IsRecommended
        }
    }

    $.ajax({

        url: "/Product/InsertUpdateProductDetails/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {

            $('#btnSaveProduct').prop("disabled", false);
            $("#frmProduct")[0].reset();
            //$("#dvSuccess").text("Product Code " + data._ProductInfo.ProductCode + ", Name " + data._ProductInfo.ProductName + " Saved Successfully");
            //$("#successmessage").modal("show");
            // $("#dvSuccess").css("display", "block");
        }
    });


}

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

function BindSKUPrice(SKUData, ProdPrice) {
    $("#lblSKU").html(SKUData);
    $("#hdnSKU").val(SKUData);
    var tmp = $("#txtQuantity").val();
    var value = parseInt(tmp) * parseInt(ProdPrice);
    $("#lblTotalPrice").html(value);

}

function AddToCart() {
    debugger;
    var rbVal = $('input[name="catoption"]:checked')[0].id;
    var unitVal = $("#hdnUnit_" + rbVal).val();
    //var unitVal = $("#hdnUnit_" + $('input[name="catoption"]:checked').attr('id')).val()
    var obj_ProductVM = {
        cart_DataModel: {
            Customer_ID: $("#hdnCustomerId").val(),
            Product_ID: $("#hdnProductId").val(),
            ProductSku_ID: rbVal,
            Unit: unitVal,
            Quantity: $("#txtQuantity").val(),
            Amount: $("#lblTotalPrice").html(),
            Discount: 0
        }
    }
    var ProductName = $("#hdnProductName").val();
    $.ajax({

        url: "/FrontEnd/AddToCart/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            if (data == null || data == "") {
                window.location.href = "/Login/Redirect_page?ReturnUrl=Product";
            }
            else {
                toastr.success(ProductName + " added to cart successfuly");
            }
        },
        error: function () {
            toastr.error("Sorry couldn't add " + ProductName + " to cart");
        }
    });
}

function Redirect_Page() {


    $.ajax({

        url: "/Login/Redirect_page/",

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        //success: function () {
        //}
    });
}

function AddToWishlist(prodId) {
    if (prodId == undefined) {
        prodId = $("#hdnProductId").val();
    }

    var obj_ProductVM = {
        CustomerFavourites: {
            Customer_Id: $("#hdnCustomerId").val(),
            Product_Id: prodId
        }
    }

    $.ajax({

        url: "/FrontEnd/AddToWishList/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            alert("Added successfully");
        }
    });
}

function Checkout() {
    var obj_ProductVM = {
        CustomerFavourites: {
            Customer_Id: $("#hdnCustomerId").val(),
            Product_Id: 1
        }
    }

    $.ajax({

        url: "/FrontEnd/Checkout/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            //alert("Added successfully");
        }
    });
}

function SaveAddress() {
    var isShip = 0; var isBill = 0;
    if ($("#hdnIsShipping").val() == 1) {
        isShip = 1;
    }
    else {
        isBill = 1;
    }

    var obj_ProductVM = {
        customerAddresMaster: {
            Customer_Id: $("#hdnCustomerId").val(),
            Street_1: $("input[name=Street_1]").val(),
            Street_2: $("input[name=Street_2]").val(),
            Pincode: $("input[name=Pincode]").val(),
            City: $("input[name=City]").val(),
            State: $("input[name=State]").val(),
            CountryName: $("input[name=CountryName]").val(),
            IsShipping: isShip,
            IsDelivery: isBill
        }
    }

    $.ajax({

        url: "/FrontEnd/SaveAddress/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            $("#addAddress").modal('hide');
            alert("Added successfully");
            location.reload();
            window.location.reload(true);

        }
    });
}

function SetIsShipping(isShipping) {
    $("#hdnIsShipping").val(isShipping);
}



