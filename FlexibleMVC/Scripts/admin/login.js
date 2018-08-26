var login = {};

$(function () {
    //∑¿÷π“≥√Ê∫ÛÕÀ
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });

    $("#btnLogin").click(function () {

        var user = {
            "loginName": $("#txtLoginName").val(),
            "password": $("#txtPassword").val()
        };

        $.post("/Admin_Login/CheckLogin", user, function (data) {
            login.doLoginResult(data);
        });
    });

});

login.doLoginResult = function (data) {
    if (data.success) {
        location.href = "/Admin_Home/Index?token=" + data.token;
    } else {
        alert(data.msg);
    }
}