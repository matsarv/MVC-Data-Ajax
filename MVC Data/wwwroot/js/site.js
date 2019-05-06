"use strict";

function ConfirmCancelListItem(html_id, cancel_url) {
    $.get(cancel_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

//function CreateListItem(update_url, item_name, item_phone, item_city) {
function sCreateListItem(update_url) {
    console.log(update_url)
    //var item_name = document.getElementById('name').value;
    //var item_phone = document.getElementById('phone').value;
    //var item_city = document.getElementById('city').value;

    //alert(update_url);

    $.post(update_url,
        {
            //Name: item_name,
            //Phone: item_phone,
            //City: item_city
            Name: $('#name').val(),
            Phone: $('#phone').val(),
            City: $('#city').val()

        },
        function (data, status) {

            if (status === 'success') {

                $('#people').html(data);
            }
            else {
                console.log('error: ' + status);
                alert('error: ' + status);
            }
        }
    );
    alert('Done!');

}

function CreateListItem(update_url) {
    console.log(update_url);
    alert(update_url);
    $.ajax({
        url: update_url,
        method: "POST",
        data: {
            Name: $('#name').val(),
            Phone: $('#phone').val(),
            City: $('#city').val()
        },
        success: function (data) {
            console.log(data);
            
            $('#people').html(data);
            alert('Replace');
        }

    })
}


function FilterListItem(update_url) {
    console.log(update_url);
    alert(update_url);
    $.ajax({
        url: update_url,
        method: "POST",
        data: {
            Filter: $('#filter').val()

        },
        success: function (data) {
            console.log(data);

            $('#people').html(data);
            alert('Replace');
        }

    })
}

function EditListItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}


function ConfirmEditListItem(html_id, update_url, item_id) {
    console.log(update_url)
    var item_name = document.getElementById('name-' + item_id).value;
    var item_phone = document.getElementById('phone-' + item_id).value;
    var item_city = document.getElementById('city-' + item_id).value;

    $.post(update_url,
        {
            Id: item_id,
            Name: item_name,
            Phone: item_phone,
            City: item_city

        },
        function (data, status) {

            if (status === 'success') {
                $('#' + html_id).replaceWith(data);
            }
            else if (status === 'notfound') {
                $('#' + html_id).replaceWith('');
                alert("Your list seems to be to old ");
            }
            else if (status === 'badrequest') {
                $('#' + html_id).replaceWith('');
                alert("Yor list seems to be corrupt.");
            }
            else {
                console.log('error: ' + status);
            }
        }
    );
}

function DeleteListItem(html_id, delete_url) {
    $.get(delete_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function ConfirmDeleteListItem(html_id, delete_url, item_id) {
    $.post(delete_url,
        {
            itemId: item_id
        },
        function (data, status) {

            if (status === 'success') {
                $('#' + html_id).replaceWith(data);
            }
            else if (status === 'notfound') {
                $('#' + html_id).replaceWith('');
                alert("Your list seems to be to old ");
            }
            else if (status === 'badrequest') {
                $('#' + html_id).replaceWith('');
                alert("Yor list seems to be corrupt.");
            }
            else {
                console.log('error: ' + status);
            }
        }
    );
}

//function CancelDeleteListItem(html_id, cancel_url) {
//    $.get(cancel_url, function (data, status) {
//        $('#' + html_id).replaceWith(data);
//    });
//}

//$("#aUpdate").click(function (e) {
//    e.preventDefault();
//    var _this = $(this);
//    $.get(_this.attr("href"), function (res) {
//        $('#' + _this.data("target")).html(res);
//    });
//});

//$(document).ready(function () {
//    $("#Delete").on("click", function () {
//        var parent = $(this).parent().parent();
//        $.ajax({
//            type: "post",
//            url: "@Url.Action("Delete","People")",
//            ajaxasync: true,
//            success: function () {
//                alert("success");
//            },
//            error: function (data) {
//                alert(data.x);
//            }
//        });
//    });
//});