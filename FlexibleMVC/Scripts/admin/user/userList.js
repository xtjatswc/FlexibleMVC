var userList = {};

//DataTables.js  这是Datatables的相关知识，具体作用请求官网查看
$.extend($.fn.dataTable.defaults, {
    "dom": "<'row'<'col-sm-12'tr>>" +
    "<'row'<'col-sm-12 text-center'i>>" +
    "<'row'<'col-sm-5'l><'col-sm-7'p>>",//默认是lfrtip
    "processing": true,//加载中
    "serverSide": true,//服务器模式（★★★★★重要，本文主要介绍服务器模式）
    "searching": false,//datatables自带的搜索
    "scrollX": false,//X滑动条
    "pagingType": "full_numbers",//分页模式
    "ajax": {
        "type": "POST",//（★★★★★重要）
        "contentType": "application/json; charset=utf-8"
    },
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

$(function () {
    $('#example2').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin_SysUser/GetListJson?token=" + util.urlParams.token,
        columns: [
            { data: 'ID', "visible": false },
            { data: 'UserName' },
            { data: 'LoginName', "bSortable": false },
            { data: 'IsLocked' },
            { data: 'Mobile' },
            { data: 'Email' }
        ],
        "columnDefs": [
            {
                "targets": [3],
                "data": "ID",
                "render": function (data, type, full) {
                    return "<a href='/update?id=" + data + "'>" + (full.IsLocked == 0 ? "未锁定" : "已锁定") + "</a>";
                }
            }
        ]
    });

});
