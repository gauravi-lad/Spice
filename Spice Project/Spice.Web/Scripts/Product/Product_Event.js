$(document).ready(function () {

    //var columnDefs = [
    //    {
    //        headerName: "Product Code", field: "ProductCode", sortable: true, filter: true
            
    //    },
    //    { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },
    //    { headerName: "Product Short Desc", field: "Product_Short_Desc", sortable: true, filter: true },
    //    { headerName: "Product Long Desc", field: "Product_Long_Desc", sortable: true, filter: true },
    //    { headerName: "Product features", field: "Product_Features", sortable: true, filter: true },
    //    { headerName: "IsActive", field: "IsActive", sortable: true, filter: true },
    //];

    //// let the grid know which columns to use
    //var gridOptions = {
    //    columnDefs: columnDefs,
    //    rowSelection: 'single',
    //    pagination: true,
    //    paginationPageSize: 10,
    //    onRowClicked: function (event) {
    //        console.log('Data of row clicked', event.data); 
    //        var data = event.data;
    //        //$("#myGrid_Product").hide();
    //        //$("#btnAddProduct").hide();
    //        //$("#hdnProductId").val(data.ProductId);
    //        //$("#txtProductCode").val(data.ProductCode);
    //        //$("#txtProductName").val(data.ProductName);
    //        //$("#txtProduct_Short_Desc").val(data.Product_Short_Desc);
    //        //$("#txtProduct_Long_Desc").val(data.Product_Long_Desc);
    //        //$("#txtProduct_Features").val(data.Product_Features);
    //        ////$("#txtProduct_Features").val(data.IsActive==1?"True":"False");
    //        //$("#txtProduct_Features").val(data.IsActive);
    //        $("#dvInsert").show();
    //        //window.location.href = '@Url.Action("GetProductById", "Product")/' + data.ProductId;
    //        window.location.href = "/Product/GetProductById/?ProductId=" + data.ProductId;
    //        //agGrid.simpleHttpRequest({ url: '/Product/GetProductById/ProductId=' + data.ProductId})
    //        //var url = "/Product/GetProductById/?ProductId=" + data.ProductId;
    //        //var myWind = open(url, '_blank');
    //        //myWind.focus();
    //    },
    //};

    //// lookup the container we want the Grid to use
    //var eGridDiv = document.querySelector('#myGrid_Product');

    //// create the grid passing in the div to use together with the columns & data we want to use
    //new agGrid.Grid(eGridDiv, gridOptions);

    //agGrid.simpleHttpRequest({ url: '/Product/GetAllProducts' }).then(function (data) {
    //    gridOptions.api.setRowData(data);
    //});



    $('#btnSaveProduct').click(function () {
       // if ($("#frmProduct").valid()) {

            //$("#btnSaveProduct").prop("disabled", true);
        
            //SaveProduct();
        $("#frmProduct").attr("action", "/Product/InsertUpdateProductDetails");
        $("#frmProduct").submit();
       // }
    });

    $(document).on("change", "input[type='checkbox']", function () {

        if ($(this).prop("checked")) {

            $(this).val(true);
        }
        else {

            $(this).val(false);
        }
    });

    function showImage1(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#img1').attr('src', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }

    function showImage2(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#img2').attr('src', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }

    function showImage3(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#img3').attr('src', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }

    function showImage4(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#img4').attr('src', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }

    function showImage5(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#img5').attr('src', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }

    $("#btnlstProduct").click(function () {
        debugger;
        window.location.href = "/Product/Search/";
    });
    
})