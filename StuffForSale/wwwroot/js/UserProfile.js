$(document).ready(function () {

    loadOrders(true);
    loadOrders(false);

    function loadOrders(buyer) {
        $.ajax({
            url: "https://localhost:5001/Order/GetOrdersForCustomer/",
            data: { buyer: buyer },
            type: "POST",
            dataType: "json"
        }).done(function (result) {
            var table = $('#table_form_1').clone();
            var tbody = table.find('tbody');
            table.removeClass('d-none');

            console.log(result);

            if (buyer) {
                table.find('.who').text('Seller');
                $('#ordered').find('table').remove();
            } else {
                table.find('.who').text('Buyer');
                $('#sold').find('table').remove();
            }
            var tr = table.find('.data_tr');

            table.find('tbody tr:not(.data_tr)').each(function () { $(this).remove(); });

            for (var i = 0; i < result.length; i++) {
                tr.removeClass('d-none');
                var record = tr.clone();
                tr.addClass('d-none');
                record.removeClass('data_tr');
                record.find('.id').text(i + 1);

                if (buyer) {
                    record.find('.seller').text(result[i].Seller);
                } else {
                    record.find('.seller').text(result[i].Buyer);
                }

                record.find('.quantity').text(result[i].Quantity);
                record.find('.price').text(result[i].Price);
                record.find('.date').text(result[i].Date);

                record.attr('order_data', result[i].OrderId);

                var btn = record.find('.status button');

                switch (result[i].InProcess) {
                    case 0:
                        btn.addClass('btn-outline-success');
                        btn.text('Completed');
                        break;
                    case 1:
                        if (buyer) {
                            btn.addClass('btn-outline-info');
                            btn.text('Confirm / Cancel');

                            btn.click(function () {

                                var o = $(this).parent().parent().attr('order_data');

                                bootbox.confirm({
                                    message: "Please click 'Confirm' to confirm the order or 'Cancel' to cancel it.",
                                    buttons: {
                                        cancel: {
                                            label: 'Cancel',
                                            className: 'btn-danger'
                                        },
                                        confirm: {
                                            label: 'Confirm',
                                            className: 'btn-success'
                                        }
                                    },
                                    callback: function (result) {
                                        if (result) {
                                            orderConfirm(o);
                                        } else {
                                            orderCancel(o);
                                        }
                                    }
                                });
                            });
                        } else {
                            btn.addClass('btn-outline-warning');
                            btn.text('Pending Confirmation');
                        }
                        break;
                    case 2:
                        btn.addClass('btn-outline-secondary');
                        btn.text('Canceled');
                        break;

                    default:
                }
                tbody.append(record);
            }

            if (buyer) {
                $('#ordered').removeClass('d-none');
                $('#ordered').append(table);
            } else {
                $('#sold').removeClass('d-none');
                $('#sold').removeClass('d-none').append(table);
            }
        }).fail(function (xhr, status, err) {
            alert("Error");
        });
    }

    function orderConfirm(order) {
        $.ajax({
            url: "https://localhost:5001/Order/OrderConfirm/",
            data: { orderId: order },
            type: "POST"
        }).done(function () {

            loadOrders(true);

        }).fail(function (xhr, status, err) {
        });
    }

    function orderCancel(order) {
        $.ajax({
            url: "https://localhost:5001/Order/OrderCancel/",
            data: { orderId: order },
            type: "POST"
        }).done(function () {

            loadOrders(true);

        }).fail(function (xhr, status, err) {
        });
    }
});