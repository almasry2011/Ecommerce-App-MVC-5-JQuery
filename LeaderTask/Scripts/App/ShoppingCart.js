$(document).ready(function () {
    var Products = $("#ProductsContainer");
    var Username = localStorage.Useername;
    var password = localStorage.password;
    $("#CompleteOrderBTN").click(function () {
        $("#CompleteOrderModal").modal("show");
    });
    var table = $("#ShoppingCart").DataTable({
        ajax: {
            url: "/api/cart?username="+Username,
            dataSrc: "",
            headers: { 'Authorization': 'Basic ' + btoa(Username + ':' + password) },
        },
        columns: [
            {
                data: "product.Image",
                render: function (data) { return '<img style=" height: 60px; " src=' + data + ' alt="Alternate Text" />' }
            },
            { data: "product.ProductName" },
            { data: "product.UnitPrice" },
            { data: "amount"  },
   
        ]
    });

    $("#ShoppingCart").on("change", ".js-amount", function () {
        var button = $(this);
        var ProductId = button.attr("data-product-id");
        $.ajax({
            url: "/api/Cart/Add_RemoveToCart?ProductId=" + ProductId + "&amount=1&username=" + Useername,
            type: 'POST',
            headers: { 'Authorization': 'Basic ' + btoa(Useername + ':' + password) },
            dataType: 'json',
            success: function (data) {
                alert("Product Added To Cart")
            }
        });

    });

});
