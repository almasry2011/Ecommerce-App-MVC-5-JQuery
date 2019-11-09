$(document).ready(function () {
    $("#btn-login").click(function () {
        var Useername = $('#login-username').val();
        var password = $('#login-password').val();
        localStorage.Useername = $('#login-username').val();
        localStorage.password = $('#login-password').val();
        console.log(Useername + "  ***  " + password)
        window.location.replace("/home/productslist");

    });

    $("#btn-logout").click(function () {
        localStorage.clear();
        alert("Logged out ")
    });

});