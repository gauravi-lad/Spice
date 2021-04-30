$(document).ready(function () {

    var columnDefs = [
        { headerName: "Video Name", field: "Video_Name", sortable: true, filter: true},
        { headerName: "Video Url", field: "Video_Url", sortable: true, filter: true },
        { headerName: "Receipe Name", field: "ReceipeName", sortable: true, filter: true },
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
            $("#myGrid_Video").hide();
            $("#btnAddVideo").hide();
            $("#hdnVideoId").val(data.Video_Id);
            $("#txtVideoName").val(data.Video_Name);
            $("#txtvideourl").val(data.Video_Url);
            $("#ddReceip").val(data.Receipe_Id);
            $("#ddproduct").val(data.Product_Id);
            $("#txtVideo_Discription").val(data.Video_Discription);
            $("#dvInsert").show();
        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_Video');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/VideoMaster/GetVideoListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });

    $("#btnSubmit").click(function () {

        $("#frmVideo").attr("action", "/VideoMaster/Insert_Update_Video");

        $("#frmVideo").submit();

    });

    $("#btnAddVideo").click(function () {
        $("#dvInsert").show();
        $("#myGrid_Video").hide();
    });

});