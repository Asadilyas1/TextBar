var t = "";
$(document).ready(function () {
    let i = 1;
    t = $("#CoreDatatable").DataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 5,
        "ajax": {
            "url": "/core/view-commitee",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [
            {
                targets: ['_all'],
                className: 'mdc-data-table__cell',
            }
        ],
        "columns": [
            {
                "render": function (data, type, full, meta) {
                    return i++;
                }
            },
            { "data": "name", "name": "Name", "autoWidth": false },
            { "data": "role", "name": "Role", "autoWidth": false },
            { "data": "position", "name": "Position", "autoWidth": false },
            { "data": "mobile", "name": "Mobile", "autoWidth": false },
            {
                data: null, render: function (data, type, row) {
                    return `<a href="javascript:void(0)" onclick="Edit('${row.id}')" class="btn btn-warning btn-sm"><i class="fa fa-edit"></i></a>` +
                        `<a href="javascript:void(0)" onclick="Delete('${row.id}')" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i></a>`;
                }
            }
        ]
    });
});

function reload_table() {
    t.ajax.reload(null, false); //reload datatable ajax 
}

$("#btnNew").click(function () {
    $('#modal-lg').modal({ backdrop: 'static', keyboard: false }, 'show');
    $("#btnSave").text('Save Changes');
    $("#btnSave").css({
        backgroundColor: "#17a2b8"
    });
    $("[name='Id']").val('');
});

$("#form").submit(function (e) {
    e.preventDefault();
    $("#nameErr").text('');
    $("#mobileErr").text('');
    $("#roleErr").text('');
    $("#positionErr").text('');
    if ($("[name='Name']").val() == "") {
        $("#nameErr").text('Name is required!');
    }
    else if ($("[name='Role']").val() == "") {
        $("#roleErr").text('Role is required!');
    }
    else if ($("[name='Position']").val() == "") {
        $("#positionErr").text('Position is required!');
    }
    else if ($("[name='Mobile']").val() == "") {
        $("#mobileErr").text('Mobile # is required!');
    } else {
        let url = "/core/save";
        if ($("[name='Id']").val() != "") {
            url = "/core/update";
        }
        $.ajax({
            url: url,
            method: "POST",
            data: $("#form").serialize(),
            datatype: "JSON",
            success: function (r) {
                alert(r.data);
                $("#form")[0].reset();
                $('#modal-lg').modal("hide");
                reload_table();
            },
            error: function (e) {
                alert(e);
            }
        });
    }
});

function Edit(id) {
    $.ajax({
        url: "/core/edit",
        method: "POST",
        data: {
            id: id
        },
        datatype: "JSON",
        success: function (r) {
            if (r.data != null) {
                $("[name='Id']").val(r.data.id);
                $("[name='Name']").val(r.data.name);
                $("[name='Role']").val(r.data.role);
                $("[name='Position']").val(r.data.position);
                $("[name='Mobile']").val(r.data.mobile);
                $("#btnSave").text('Update Changes');
                $("#btnSave").css({
                    backgroundColor: "#17a2b8"
                });
                $('#modal-lg').modal({ backdrop: 'static', keyboard: false }, 'show');
            }
        },
        error: function (e) {
            alert(e);
        }
    });
}

function Delete(id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/core/delete",
                    type: "POST",
                    data: {
                        id: id
                    },
                    dataType: "json",
                    success: function () {
                        swal("Done!", "It was succesfully deleted!", "success");
                        reload_table();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Error deleting!", "Please try again", "error");
                    }
                });
            } else {
                swal("Your imaginary file is safe!");
            }
        });
}



