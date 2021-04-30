$(document).ready(function () {



    // specify the columns
    var columnDefs = [
        { headerName: "Vendor Name", field: "VendorName", sortable: true, filter: true },
        { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },
        { headerName: "Vendor Price", field: "VendorPrice", sortable: true, filter: true },
        { headerName: "Vendor Priority", field: "VendorPriority", sortable: true, filter: true },

    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            var data = event.data;
            $("#myGrid_VendorProduct").hide();
            $("#btnVendorProduct").hide();
            $("#hdnVendorProductId").val(data.VendorProductId);
            $("#ddlVendor").val(data.VendorId);
            $("#ddlProduct").val(data.ProductId);
            $("#txtPriority").val(data.VendorPriority);
            $("#txtPrice").val(data.VendorPrice);
            $("#dvInsert").show();

        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_VendorProduct');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Vendor/GetVendorProductListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });

    $("#btnAddVendorProduct").click(function () {
        $("#dvInsert").show();
        $("#myGrid_VendorProduct").hide();
    });

    $("#btnSubmit").click(function () {      
        $("#frmVendorProduct").attr("action", "/Vendor/InsertVendorProduct");
        $("#frmVendorProduct").submit();
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

});