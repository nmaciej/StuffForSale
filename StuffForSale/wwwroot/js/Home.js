$(document).ready(function () {

    loadOrders(true);
    loadOrders(false);

    var userName;
    $.ajax({
        url: "https://localhost:5001/UserProfile/GetUserName/",
        data: {},
        type: "POST"
    }).done(function(result) {
        userName = result;
    });

    function loadOrders(buyer) {
        $.ajax({
            url: "https://localhost:5001/Product/GetAll/",
            data: {},
            type: "POST",
            dataType: "json"
        }).done(function (result) {

            console.log(result);

            var table = $('#table_form_1').clone();
            var tbody = table.find('tbody');
            table.removeClass('d-none');

            var div = $('#index_table');
            div.find('table').remove();

            var tr = table.find('.data_tr');

            table.find('tbody tr:not(.data_tr)').each(function () { $(this).remove(); });

            for (var i = 0; i < result.length; i++) {
                tr.removeClass('d-none');
                var record = tr.clone();
                tr.addClass('d-none');

                record.removeClass('data_tr');
                record.find('.id').text(i + 1);
                record.find('.name').text(result[i].Name);
                record.find('.description').text(result[i].Description);
                record.find('.tag').text(result[i].Tag.Name);
                record.find('.price').text(result[i].Price);
                record.find('.quantity').text(result[i].Quantity);
                record.find('.seller').text(result[i].User.UserName);
                record.find('.date').text(result[i].DateAdded);

                record.attr('data', result[i].ProductId);

                var buttonRec = record.find('.b');

                if (userName !== 'none') {

                    if (userName === result[i].User.UserName) {
                        buttonRec.find('button').append("<i class=\"far fa-times-circle fa-2x\"></i>");
                        buttonRec.find('button').addClass('btn-warning');

                        buttonRec.click(function() {
                            bootbox.alert("This is your product!");
                        });

                    } else {
                        buttonRec.find('button').append("<i class=\"fas fa-cart-plus fa-2x\">");
                        buttonRec.find('button').addClass('btn-success');

                        console.log($(this).parent().attr('data'));

                        buttonRec.click(function() {
                            $.ajax({
                                url: "https://localhost:5001/Cart/AddToCart/",
                                data: { id: $(this).parent().attr('data') },
                                type: "POST"
                            }).done(function() {
                                bootbox.confirm({
                                    message: "Dodano produkt do koszyka!",
                                    buttons: {
                                        cancel: {
                                            label: 'OK',
                                            className: 'btn-info'
                                        },
                                        confirm: {
                                            label: 'Cart',
                                            className: 'btn-success'
                                        }
                                    },
                                    callback: function(result) {
                                        if (result) {

                                            $.ajax({
                                                url: "https://localhost:5001/Cart/IndexPartial/",
                                                data: {},
                                                type: "GET"
                                            }).done(function(result) {

                                                $('#partial').html(result);

                                            });

                                        }
                                    }
                                });
                            }).fail(function(xhr, status, err) {

                                bootbox.alert("Quantity not sufficient!");

                            });
                        });
                    }
                } else {
                    buttonRec.remove();}

                tbody.append(record);
            }
            div.append(table);

        }).fail(function (xhr, status, err) {

        });
    }
});