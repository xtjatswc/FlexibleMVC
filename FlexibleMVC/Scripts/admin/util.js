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



//DataTables.js  这是Datatables的相关知识，具体作用请求官网查看
$.extend($.fn.dataTable.defaults, {
    "processing": true,//加载中
    "serverSide": true,//服务器模式（★★★★★重要，本文主要介绍服务器模式）
    "searching": false,//datatables自带的搜索
    //"scrollX": false,//X滑动条 开启此属性后，横向滚动条显示会让人感觉很别扭
    "pagingType": "full_numbers",//分页模式
    "stateSave": true,//保存界面状态，页面刷新后依然是上次的界面
    //"scrollY": "200px",
    //"scrollCollapse": false,//垂直滚动条
    "paging": true,//显示分页
    "ajax": {
        "type": "POST",//（★★★★★重要）
        //"contentType": "application/json; charset=utf-8" //被这行代码坑惨了，post提交时，老用Rayload而不用Form，后来看了官网示例对比才发现的
    },
    "autoWidth": false,
    "lengthChange": true,//每页显示多少条数据
    "info": true,//显示第 x 至 x 项结果，共 x 项
    "language": {
        "processing": "加载中...",
        "lengthMenu": "每页显示 _MENU_ 条数据",
        "zeroRecords": "没有匹配结果",
        "info": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
        "infoEmpty": "显示第 0 至 0 项结果，共 0 项",
        "infoFiltered": "(由 _MAX_ 项结果过滤)",
        "infoPostFix": "",
        "search": "搜索:",
        "url": "",
        "emptyTable": "没有匹配结果",
        "loadingRecords": "载入中...",
        "thousands": ",",
        "paginate": {
            "first": "首页",
            "previous": "上一页",
            "next": "下一页",
            "last": "末页"
        },
        "aria": {
            "sortAscending": ": 以升序排列此列",
            "sortDescending": ": 以降序排列此列"
        }
    }
});