var login = {};

$(function () {
    //防止页面后退
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });

    $("#txtLoginName").val($.cookie('latestLoginName'));

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
    if (data.Success) {
        $.cookie('latestLoginName', $("#txtLoginName").val(), { expires: 7 });
        location.href = "/Admin_Home/Index?token=" + data.Token;
    } else {
        alert(data.Msg);
    }
}