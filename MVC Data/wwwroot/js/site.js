"use strict";

function ConfirmCancelListItem(html_id, cancel_url) {
    $.get(cancel_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function CreateListItem(update_url, item_name, item_phone, item_city) {

    var item_name = document.getElementById('name' + item_id).value;
    var item_phone = document.getElementById('phone' + item_id).value;
    var item_city = document.getElementById('city' + item_id).value;

    console.log(item_name);
    console.log('error: ' + status)

    $.post(update_url,
        {
            Name: item_name,
            Phone: item_phone,
            City: item_city
        },
        function (data, status) {
            console.log(data);
            if (status === 'success') {
                $('#people').append(data);
            }
            else {
                console.log('error: ' + status);
            }
        }
    );

}

function EditListItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}


function ConfirmEditListItem(html_id, update_url, item_id) {

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
                alert("Your list seems to be to old old.");
            }
            else if (status === 'badrequest') {
                $('#' + html_id).replaceWith('');
                alert("Yor list seems to be  corrupt.");
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
                alert("Your list is old, pleace refrece.");
            }
            else if (status === 'badrequest') {
                $('#' + html_id).replaceWith('');
                alert("Your list is corrupt, pleace refrece.");
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