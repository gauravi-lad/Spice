$(document).ready(function () {
    Cal();
});


function ChangeCart_total(RatePerPc, Count, Product_ID, ProductSku_ID, Customer_ID, Unit) {

    var Quantity = document.getElementById("txtQuantity_" + Count).value;
    var value = parseInt(RatePerPc) * parseInt(Quantity);
    $("#hdntotal_" + Count).html(value);
    Cal();
    AddToCart(Product_ID, ProductSku_ID, Quantity, value, Customer_ID, Unit);
}


function Cal() {

    var mySum = 0;
    var myQuantity = 0;

    $('#Cartlist tr').each(function (index) {
        var value = (parseFloat($(this).find(".product-subtotal").html()));
        //var Quantity = (parseFloat($(this).find(".Quanitycheck_" + ${ index }).html()));
        var Quantity = index;

        if (!isNaN(value) && value.length != 0) {
            mySum += parseFloat(value);
        }

        $("#totalproPrice").text(Quantity);
        $("#GrandPrice").text(mySum);
        //   $("#totalCart").text(3);
    });
}


function AddToCart(Product_ID, ProductSku_ID, Quantity, value, Customer_ID, Unit) {

    debugger;

    var obj_ProductVM = {
        cart_DataModel: {
            Customer_ID: Customer_ID,
            Product_ID: Product_ID,
            ProductSku_ID: ProductSku_ID,
            Quantity: Quantity,
            Amount: value,
            Unit: Unit,
            Discount: 0
        }
    }

    $.ajax({

        url: "/FrontEnd/AddToCart/",

        data: JSON.stringify(obj_ProductVM),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
        }
    });

}


function DeleteCart(Customer_ID, Product_ID, ProductSku_ID) {
    debugger;

    var obj_Cart = {
        cart_DataModel: {
            Customer_ID: Customer_ID,
            Product_ID: Product_ID,
            ProductSku_ID: ProductSku_ID

        }
    }

    $.ajax({

        url: "/Cart/Delete_Cart/",

        data: JSON.stringify(obj_Cart),

        dataType: 'json',

        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
        }
    });
}