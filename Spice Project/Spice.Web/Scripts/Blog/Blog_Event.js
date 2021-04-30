$(document).ready(function () {

    var columnDefs = [
        { headerName: "Blog Name", field: "Blog_Name", sortable: true, filter: true},
        { headerName: "Blog Discription", field: "Blog_Discription", sortable: true, filter: true },
        { headerName: "Product Name", field: "ProductName", sortable: true, filter: true },

    ];

    // let the grid know which columns to use
    var gridOptions = {
        columnDefs: columnDefs,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10,
        onRowClicked: function (event) {
            console.log('Data of row clicked', event.data); // bind this event.data to the textbox of their respective fields
            var data = event.data;
            $("#myGrid_Blog").hide();
            $("#btnAddBlog").hide();
            $("#hdnBlogId").val(data.Blog_Id);
            $("#ddproduct").val(data.Product_Id);
            $("#txtBlogName").val(data.Blog_Name);
            $("#txtBlog_Discription").val(data.Blog_Discription);
            $("#dvInsert").show();
        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_Blog');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Blog/GetBlogListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });

    $("#btnSubmit").click(function () {

        $("#frmBlog").attr("action", "/Blog/Insert_Update_Blog");

        $("#frmBlog").submit();

    });

    $("#btnAddBlog").click(function () {
        $("#dvInsert").show();
        $("#myGrid_Blog").hide();
    });

});