$(document).ready(function () {
    var Useername = localStorage.Useername;
    var password = localStorage.password;
    var EditId;
    var table = $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: "",
            headers: { 'Authorization': 'Basic ' + btoa(Useername+ ':' +password) },  
        },
        columns: [
            {
                data: "Image",
                render: function (data) { return '<img style=" height: 60px; " src=' + data + ' alt="Alternate Text" />' }
            },
            { data: "CustomerName" },
            { data: "Email" },
            { data: "Phone" },
            { data: "Country" },
            {
                data: "CustomerID",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>" +
                        "<button class='btn-link js-edit' data-customer-id=" + data + ">Update</button>";
                }
            }
        ]
    });
    $('#createCustomer').click(function () {
        var CustName = $("#CustName").val();
        var Email = $("#Email").val();
        var CustPhone = $("#CustPhone").val();
        var CustPhoto = $("#CustPhoto").val();
        var CustAddress = $("#CustAddress").val();
        var User = $("#UserName").val();
        var Password = $("#password").val();
        $.ajax({
            url: "/api/customers",
            type: 'POST',
            dataType: 'json',
            data: {
                CustomerName: CustName,
                Email: Email,
                Phone: CustPhone,
                Country: CustAddress,
                Image: CustPhoto,
                UserName: User,
                Password: Password,

            },
            success: function (data) {
                $('#customers').DataTable().ajax.reload();
                $("#CreateCustomerModal").modal("hide");
            }
        });
    });
    $("#customers").on("click", ".js-edit", function () {
        var button = $(this);
        EditId = button.attr("data-customer-id");
        $.ajax({
            url: "/api/Customers/" + button.attr("data-customer-id"),
            method: "GET",
            success: function (data) {
                $("#ECustName").val(data.CustomerName);
                $("#EEmail").val(data.Email);
                $("#ECustPhone").val(data.Phone);
                $("#ECustPhoto").val(data.Image);
                $("#ECustAddress").val(data.Country);
                $("#EditCustomerModal").modal("show");
            }
        });
    });
    $('#EditCustomerBtn').click(function () {
        var CustName = $("#ECustName").val();
        var Email = $("#EEmail").val();
        var CustPhone = $("#ECustPhone").val();
        var CustPhoto = $("#ECustPhoto").val();
        var CustAddress = $("#ECustAddress").val();
        $.ajax({
            url: "/api/customers/" + EditId,
            type: 'PUT',
            dataType: 'json',
            data: {
                CustomerName: CustName,
                Email: Email,
                Phone: CustPhone,
                Country: CustAddress,
                Image: CustPhoto
            },
            success: function (data) {
                EditId = 0;
                $('#customers').DataTable().ajax.reload();
                $("#EditCustomerModal").modal("hide");
            }
        });
    });
    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        $('#customers').DataTable().ajax.reload();
                    }
                });
            }
        });
    });
});
