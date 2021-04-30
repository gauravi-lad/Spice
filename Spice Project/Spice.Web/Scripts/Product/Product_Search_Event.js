$(document).ready(function () {

    var columnDefs = [
        {
          headerName: "Product Code", field: "ProductCode", sortable: true, filter: true

        },
        { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },
        { headerName: "Category", field: "CategoryName", sortable: true, filter: true },
        { headerName: "Sub Category", field: "SubCategoryName", sortable: true, filter: true },
        { headerName: "Product Short Desc", field: "Product_Short_Desc", sortable: true, filter: true },
        { headerName: "Product Long Desc", field: "Product_Long_Desc", sortable: true, filter: true },
        { headerName: "Product features", field: "Product_Features", sortable: true, filter: true },
        { headerName: "IsActive", field: "IsActive", sortable: true, filter: true },
    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            console.log('Data of row clicked', event.data);
            var data = event.data;
           
            window.location.href = "/Product/GetProductById/?ProductId=" + data.ProductId;
            //agGrid.simpleHttpRequest({ url: '/Product/GetProductById/ProductId=' + data.ProductId})
            //var url = "/Product/GetProductById/?ProductId=" + data.ProductId;
            //var myWind = open(url, '_blank');
            //myWind.focus();
        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_Product');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Product/GetAllProducts' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });

    $("#btnAddProduct").click(function () {
        debugger;
        window.location.href = "/Product/Index/";
    });
})