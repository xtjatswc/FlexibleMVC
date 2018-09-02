var userList = {};

$(function () {
    // Setup - add a text input to each footer cell
    $('#example2 tfoot th').each(function () {
        var index = $(this).index();
        if(index == 1 || index == 2){
            var title = $('#example2 thead th').eq(index).text();
            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        }
    });

    var table = $('#example2').DataTable({
        "dom": 'lBrtip',//隐藏全局搜索框
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin_SysUser/GetListJson?token=" + util.urlParams.token,
            "type": "POST",
        },
        columns: [
            { data: 'ID', "visible": false },
            { data: 'UserName' },
            { data: 'LoginName' },
            { data: 'IsLocked' },
            { data: 'Mobile', "bSortable": false},
            { data: 'Email', "bSortable": false},
            { data: null }
        ],
        // 默认排序字段
        "order": [[2, "desc"]],
        "columnDefs": [
            {
                "targets": [3],
                "data": "ID",
                "render": function (data, type, full) {
                    return "<a href='/update?id=" + data + "'>" + (full.IsLocked == 0 ? "未锁定" : "已锁定") + "</a>";
                }
            },
            {
                "targets": -1,//-1表示最后一行
                //"width": "100px",
                render: function (data, type, full, meta) {
                    return '<a class="btn btn-sm btn-info" href="javascript:;">设置<i class="fa fa-cogs"></i></a>  ' +
                        '<a class="btn btn-sm btn-info" href="javascript:;">删除<i class="fa fa-trash"></i></a>';
                }
            }
        ]
    });

    // Apply the search
    table.columns().eq(0).each(function (colIdx) {
        $('input', table.column(colIdx).footer()).on('keyup change', function () {
            table
                .column(colIdx)
                .search(this.value)
                .draw();
        });
    });

});
