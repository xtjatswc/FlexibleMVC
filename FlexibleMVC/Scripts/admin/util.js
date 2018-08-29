var util = {};
util.urlParams = {};

$(function () {
    util.urlParams = util.urlToObject(window.location.search);

});

//将URL中的参数提取出来作为对象
util.urlToObject = function (url) {
    var urlObject = {};
    if (/\?/.test(url)) {
        var urlString = url.substring(url.indexOf("?") + 1);
        var urlArray = urlString.split("&");
        for (var i = 0, len = urlArray.length; i < len; i++) {
            var urlItem = urlArray[i];
            var item = urlItem.split("=");
            urlObject[item[0]] = item[1];
        }
        return urlObject;
    }
};



