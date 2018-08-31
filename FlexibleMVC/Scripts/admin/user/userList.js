var userList = {};

$(function () {
    // Setup - add a text input to each footer cell
    $('#example2 tfoot th').each(function () {
        var title = $('#example2 thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    var table = $('#example2').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin_SysUser/GetListJson?token=" + util.urlParams.token,
            "type": "POST",
        },
        columns: [
            { data: 'ID', "visible": false },
            { data: 'UserName' },
            { data: 'LoginName', "bSortable": false },
            { data: 'IsLocked' },
            { data: 'Mobile' },
            { data: 'Email' },
            { data: null }
        ],
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
                "width": "100px",
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
