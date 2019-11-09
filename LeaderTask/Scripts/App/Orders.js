$(document).ready(function () {
    var Useername = localStorage.Useername;
    var password = localStorage.password;
    var Prod;
    $('#Orderbtn').click(function () {
        var shipname = $("#shipname").val();
        var shipnEmail = $("#shipnEmail").val();
        var phone = $("#phone").val();
        var Shipaddress = $("#Shipaddress").val();
        $.ajax({
            url: "/api/orders?username="+Useername,
            type: 'POST',
            dataType: 'json',
            data: {
                ShipName: shipname,
                ShipEmail: shipnEmail,
                Phone: phone,
                ShipAddress: Shipaddress,
            },
            success: function (data) {
                $("#CompleteOrderModal").modal("hide");
                alert("success")
              //  console.log(data)
            }
        });
    });
    var table = $("#OrderTbl").DataTable({
        ajax: {
            url: "/api/orders/",
            dataSrc: "",
            headers: { 'Authorization': 'Basic ' + btoa(Useername + ':' + password) },
        },
        columns: [
            {data: "ShipName"  },
            { data: "ShipEmail" },
            { data: "Phone" },
            { data: "ShipAddress" },
            {
                data: "OrderId",
                render: function (data) {
                    return "<button class='btn-link js-order' data-order-id=" + data + ">Show Order Details</button>" +
                        "<button class='btn-link js-delete' data-order-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#OrderTbl").on("click", ".js-order", function () {
        var button = $(this);
       var  orderId = button.attr("data-order-id");
        var otable = $("#ViewOrderTbl").DataTable({
                "ordering": false,
                "paging": false,
               "destroy": true,
            ajax: {
                url: "/api/orders?id=" + orderId,
                dataSrc: "",
                headers: { 'Authorization': 'Basic ' + btoa(Useername + ':' + password) },
               // success: function (res) {console.log(res)}
            },
            columns: [
                {
                    data: "product.Image",
                    render: function (data) { return '<img style=" height: 60px; " src=' + data + ' alt="Alternate Text" />' }
                },
                { data: "product.ProductName" },
                { data: "Quatity" },
                { data: "product.UnitPrice" },
            ]
        });
        $("#ViewOrderModal").modal("show");
    });
 

});
