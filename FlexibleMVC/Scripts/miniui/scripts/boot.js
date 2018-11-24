var bootPATH = bootPath = __CreateJSPath("boot.js");

mini_debugger = true;                                           //

var skin = 'blue2010';//getCookie("miniuiSkin") || 'blue2010';//skin cookie   cupertino
var mode = 'medium';//getCookie("miniuiMode") || 'medium';//mode cookie     medium     

//miniui
document.write('<script src="' + bootPATH + 'jquery.min.js" type="text/javascript"></sc' + 'ript>');
document.write('<script src="' + bootPATH + 'miniui/miniui.js" type="text/javascript" ></sc' + 'ript>');
document.write('<link href="' + bootPATH + '../res/fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />');
document.write('<link href="' + bootPATH + 'miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />');

//common
document.write('<link href="' + bootPATH + '../res/css/common.css" rel="stylesheet" type="text/css" />');
document.write('<script src="' + bootPATH + '../res/js/common.js" type="text/javascript" ></sc' + 'ript>');

//skin
if (skin && skin != "default") document.write('<link href="' + bootPATH + 'miniui/themes/' + skin + '/skin.css" rel="stylesheet" type="text/css" />');

//mode
if (mode && mode != "default") document.write('<link href="' + bootPATH + 'miniui/themes/default/' + mode + '-mode.css" rel="stylesheet" type="text/css" />');

//icon
document.write('<link href="' + bootPATH + 'miniui/themes/icons.css" rel="stylesheet" type="text/css" />');

////////////////////////////////////////////////////////////////////////////////////////
function getCookie(sName) {
    var aCookie = document.cookie.split("; ");
    var lastMatch = null;
    for (var i = 0; i < aCookie.length; i++) {
        var aCrumb = aCookie[i].split("=");
        if (sName == aCrumb[0]) {
            lastMatch = aCrumb;
        }
    }
    if (lastMatch) {
        var v = lastMatch[1];
        if (v === undefined) return v;
        return unescape(v);
    }
    return null;
}

function __CreateJSPath(js) {
    var scripts = document.getElementsByTagName("script");
    var path = "";
    for (var i = 0, l = scripts.length; i < l; i++) {
        var src = scripts[i].src;
        if (src.indexOf(js) != -1) {
            var ss = src.split(js);
            path = ss[0];
            break;
        }
    }
    var href = location.href;
    href = href.split("#")[0];
    href = href.split("?")[0];
    var ss = href.split("/");
    ss.length = ss.length - 1;
    href = ss.join("/");
    if (path.indexOf("https:") == -1 && path.indexOf("http:") == -1 && path.indexOf("file:") == -1 && path.indexOf("\/") != 0) {
        path = href + "/" + path;
    }
    return path;
}


//html多级iframe嵌套时获取顶级窗口
var topWin = (function () { var p = window.parent; while (p != p.window.parent) { p = p.window.parent; } return p; })();

//全局ajax拦截
document.write('<script src="' + bootPATH + 'ajaxhook.min.js" type="text/javascript"></sc' + 'ript>');

var timer = setInterval(HasJqueryLoadComplete, 1000);

function HasJqueryLoadComplete() {
    if (hookAjax && mini) {
        hookAjax({
            //拦截回调
            onreadystatechange: function (xhr) {
                //console.log("onreadystatechange called: %O", xhr)
                var sessionstatus = xhr.getResponseHeader("SessionStatus");
                if (sessionstatus == "TimeOut" && xhr.readyState == 4 && xhr.responseText != "") {                    
                    var json = mini.decode(xhr.responseText);
                    alert(json.Msg);
                    topWin.exit();
                }
            },
            onload: function (xhr) {
                //console.log("onload called: %O", xhr)
            },
            //拦截方法
            open: function (arg, xhr) {
                //console.log("open called: method:%s,url:%s,async:%s", arg[0], arg[1], arg[2])
            }
        })

        clearInterval(timer);
    }
}


