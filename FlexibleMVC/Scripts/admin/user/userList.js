var userList = {};

$(function () {
    $('#example2').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin_SysUser/GetListJson?token=" + util.urlParams.token
    });

});
