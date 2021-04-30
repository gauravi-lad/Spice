$(document).ready(function () {

    // specify the columns
    var columnDefs = [
        
        { headerName: "Receipe Name", field: "ReceipeName", sortable: true, filter: true },
        { headerName: "Description", field: "Description", sortable: true, filter: true },
        { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },
       
    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            var data = event.data;
            $("#myGrid_Receipe").hide();
            $("#btnAddReceipe").hide();
            $("#hdnReceipeId").val(data.ReceipeId);
            $("#txtReceipeName").val(data.ReceipeName);
            $("#txtDescription").val(data.Description);
            $("#ddlProduct").val(data.ProductId);           
            $("#dvInsert").show();

        },
    };
    var eGridDiv = document.querySelector('#myGrid_Receipe');
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Receipe/GetReceipeListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });
    $("#btnAddReceipe").click(function () {
        $("#dvInsert").show();
        $("#myGrid_Receipe").hide();
    });
    $("#btnSubmit").click(function () {
        $("#frmReceipe").attr("action", "/Receipe/InsertReceipe");
        $("#frmReceipe").submit();
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