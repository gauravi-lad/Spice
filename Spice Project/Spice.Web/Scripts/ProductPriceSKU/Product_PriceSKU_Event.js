$(document).ready(function () {

    // specify the columns
    var columnDefs = [

        { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },
        { headerName: "SKU Name", field: "SKU", sortable: true, filter: true },
        { headerName: "Unit", field: "Unit", sortable: true, filter: true },
        { headerName: "Rate Per Pc", field: "RatePerPc", sortable: true, filter: true },
        { headerName: "Min Order Quantity", field: "MinOrderQuantity", sortable: true, filter: true },
        { headerName: "Max Order Quantity", field: "MaxOrderQuantity", sortable: true, filter: true },

    ]; 

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            var data = event.data;
            $("#myGrid_Sku").hide();
            $("#btnAddSKU").hide();
            $("#hdnProductPriceSKUId").val(data.ProductPriceSKUId);
            $("#ddproduct").val(data.ProductId);
            $("#txtSkuName").val(data.SKU);
            $("#txtunit").val(data.Unit);
            $("#txtRate").val(data.RatePerPc);
            $("#txtminQ").val(data.MinOrderQuantity);
            $("#txtMaxQ").val(data.MaxOrderQuantity);
            $("#AddSkuList").hide();
            $("#btnAdd").hide();
            $("#dvInsert").show();
            $("#btnSubmit").show();
        },
    };
    var eGridDiv = document.querySelector('#myGrid_Sku');
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/ProductPriceSKU/GetAllProductPriceSKU' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });
    $("#btnAddSKU").click(function () {
        $("#dvInsert").show();
        $("#myGrid_Sku").hide();
    });
    $("#btnSubmit").click(function () {
      
        var rowCount = $('#AddSkuList tr').length;
        if (rowCount > 1 || $("#hdnProductPriceSKUId").val()>0) {  
           $("#frmSKU").attr("action", "/ProductPriceSKU/InsertUpdateProductDetails");
           $("#frmSKU").submit();
        }
    });
});