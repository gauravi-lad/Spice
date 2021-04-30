$(document).ready(function () {
    // specify the columns
    var columnDefs = [
        {
            headerName: "Vendor Name", field: "FirstName", sortable: true, filter: true, cellRenderer: (data) => {
                return data.data.FirstName + ' ' + data.data.MiddleName + ' ' + data.data.LastName;
            }
        },
        { headerName: "Mobile No", field: "MobileNo", sortable: true, filter: true },
        { headerName: "Email", field: "Email", sortable: true, filter: true },
        { headerName: "Country", field: "CountryName", sortable: true, filter: true },
        { headerName: "State", field: "StateName", sortable: true, filter: true },
        { headerName: "City", field: "CityName", sortable: true, filter: true },
        { headerName: "Address", field: "Address", sortable: true, filter: true },
        { headerName: "Tax Value", field: "GSTValue", sortable: true, filter: true },
        //{ headerName: "Price", field: "price", sortable: true, filter: true }
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
            $("#myGrid_Vendor").hide();
            $("#btnAddVendor").hide();
            $("#hdnVendorId").val(data.Id);
            $("#txtFirstName").val(data.FirstName);
            $("#txtMiddleName").val(data.MiddleName);
            $("#txtLastName").val(data.LastName);
            $("#txtMobileNo").val(data.MobileNo);
            $("#txtEmailId").val(data.Email);
            $("#ddlGST").val(data.GST);
            $("#ddlCountry").val(data.CountryId);
            $("#txtStateName").val(data.StateName);
            $("#txtCityName").val(data.CityName);
            $("#txtAddress").val(data.Address);
            $("#txtAddress2").val(data.Address2);
            $("#dvInsert").show();
            
        },
    };

    // lookup the container we want the Grid to use
    var eGridDiv = document.querySelector('#myGrid_Vendor');

    // create the grid passing in the div to use together with the columns & data we want to use
    new agGrid.Grid(eGridDiv, gridOptions);

    agGrid.simpleHttpRequest({ url: '/Vendor/GetVendorListing' }).then(function (data) {
        gridOptions.api.setRowData(data);
    });



    $("#btnSubmit").click(function () {      
        $("#frmVendor").attr("action", "/Vendor/InsertVendor");
        $("#frmVendor").submit();
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
    $("#btnAddVendor").click(function () {      
        $("#dvInsert").show();
        $("#myGrid_Vendor").hide();
    });
});

