$('#SliderDatatable').DataTable({
    autoWidth: false,
    columnDefs: [
        {
            targets: ['_all'],
            className: 'mdc-data-table__cell',
        },
    ],
});
$(document).ready(function () {
    LoadSlider();
});
function LoadSlider() {
    $.ajax({
        type: "GET",
        url: "/Dashboard/LoadSlider",
        data: {

        },
        success: function (res) {
            $("#LoadSlider").html(res);
        },
        error: function (res) {
            alert(res);
        }
    });
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            const image = new Image();
            image.src = e.target.result;
            image.onload = () => {
                const {
                    height,
                    width
                } = image;
                if (height < 1024 || width < 1920) {
                    alert("Minimum height 1025 and width 1920!");
                    $('#preview_image').attr('src', 'https://ultranews.thesky9.com/vendor/core/core/base/images/placeholder.png')
                    return false;
                }
                $('#preview_image')
                    .attr('src', e.target.result)
                    .width(1920)
                    .height(300);
                return true;
            };
        };

        reader.readAsDataURL(input.files[0]);
    }
}

$("#is_visible").click(function () {
    if ($(this).prop("checked") == true) {
        $("#Visibility").val(1);
    }
    else if ($(this).prop("checked") == false) {
        $("#Visibility").val(0);
    }
});

function RemoveImage(x) {
    let filesAmount = document.getElementsByClassName("preview-image-wrapper");
    filesAmount[x].remove();
}

$(".btn_remove").click(function () {
    $('#preview_image')
        .attr('src', 'https://ultranews.thesky9.com/vendor/core/core/base/images/placeholder.png')
        .css({
            height: '300px',
            maxWidth: '100%'
        });
    $("#Image").val('');
});

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
                    url: "/Dashboard/DeleteSlider",
                    type: "POST",
                    data: {
                        id: id
                    },
                    dataType: "json",
                    success: function () {
                        swal("Done!", "It was succesfully deleted!", "success");
                        LoadSlider();
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
