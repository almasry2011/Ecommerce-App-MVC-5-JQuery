$(document).ready(function () {
    var Products = $("#ProductsContainer");
    var Useername = localStorage.Useername;
    var password = localStorage.password;
    
    var ApiUrl = "/api/Products/";
    $("#ProductsContainer").on("click", ".js-cart", function () {
        if ("Useername" in localStorage) {
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

        } else {
            window.location.replace("/home/login");
        }
    });

    $.ajax({
        type: 'GET',
        url: '/api/Products',
         headers: { 'Authorization': 'Basic ' + btoa(Useername + ':' + password) },  
        success: function (data) {
            $.each(data, function (k, v) {
                Products.append(
                    ' <div class="col-md-4"><figure class="card card-product"><div class="col-md-12"><img style="width:100%;height:320px;"  src='
                    + v.Image + '></div><figcaption class="info-wrap"><h4 class="title">' + v.ProductName + '</h4><p class="desc">'
                    + v.ProductName + '</p> </figcaption>  <div class="bottom-wrap"> <a data-product-id=' + v.ProductID + '   class= "btn btn-sm btn-primary float-right js-cart">'
                    +'Add To Cart</a > <div class="price-wrap h5"><span class="price-new">'
                +v.UnitPrice+'</span > <del class="price-old"> </del></div></div> </figure></div>  ')
            });       
        },
        error: function () {
        }
    });     
});
