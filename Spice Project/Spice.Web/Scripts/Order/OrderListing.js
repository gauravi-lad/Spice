$(document).ready(function(){
    LoadPartial();

    $('#btnSearch').click(function () {
        LoadPartial();
    });

});

function LoadPartial() {
    var url = 'Get_Listing_PartialView';
    $('#partialOrderListingTable').load(url, { Order_Invoice_Number: $("#txtInvoinceNo").val(), from_Date: $("#txtFromData").val(), to_Date: $("#txtToData").val(), order_Status: $("#drpStatus").val() });
}