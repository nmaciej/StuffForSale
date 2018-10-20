$(document).ready(function () {

    loadOrders(null, 1);

    var userName;
    $.ajax({
        url: "https://localhost:5001/UserProfile/GetUserName/",
        data: {},
        type: "POST"
    }).done(function (result) {
        userName = result;
    });

    function loadOrders(tag, currPage) {
        $.ajax({
            url: "https://localhost:5001/Product/GetAll/",
            data: { tag: tag, productPage: currPage },
            type: "POST",
            dataType: "json"
        }).done(function (result) {

            console.log(result);
            pagination(result);
            loadTagBadges(result);

            var table = $('#table_form_1').clone();
            var tbody = table.find('tbody');
            table.removeClass('d-none');

            var div = $('#index_table');
            div.find('table').remove();

            var tr = table.find('.data_tr');

            table.find('tbody tr:not(.data_tr)').each(function () { $(this).remove(); });

            for (var i = 0; i < result.ProductList.length; i++) {
                tr.removeClass('d-none');
                var record = tr.clone();
                tr.addClass('d-none');

                record.removeClass('data_tr');
                record.find('.name').text(result.ProductList[i].Name);
                record.find('.description').text(result.ProductList[i].Description);
                record.find('.tag').text(result.ProductList[i].Tag.Name);
                record.find('.price').text(result.ProductList[i].Price);
                record.find('.quantity').text(result.ProductList[i].Quantity);
                record.find('.seller').text(result.ProductList[i].User.UserName);
                record.find('.date').text(result.ProductList[i].DateAdded);

                record.attr('data', result.ProductList[i].ProductId);

                var buttonRec = record.find('.b');

                if (userName !== 'none') {

                    if (userName === result.ProductList[i].User.UserName) {
                        buttonRec.find('button').append("<i class=\"far fa-times-circle fa-1x\"></i>");
                        buttonRec.find('button').addClass('btn-warning');

                        buttonRec.click(function () {
                            bootbox.alert("This is your product!");
                        });

                    } else {
                        buttonRec.find('button').append("<i class=\"fas fa-cart-plus fa-1x\">");
                        buttonRec.find('button').addClass('btn-success');

                        console.log($(this).parent().attr('data'));

                        buttonRec.click(function () {
                            $.ajax({
                                url: "https://localhost:5001/Cart/AddToCart/",
                                data: { id: $(this).parent().attr('data') },
                                type: "POST"
                            }).done(function () {
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
                                    callback: function (result) {
                                        if (result) {

                                            $.ajax({
                                                url: "https://localhost:5001/Cart/IndexPartial/",
                                                data: {},
                                                type: "GET"
                                            }).done(function (result) {

                                                $('#partial').html(result);

                                            });

                                        }
                                    }
                                });
                            }).fail(function (xhr, status, err) {

                                bootbox.alert("Quantity not sufficient!");

                            });
                        });
                    }
                } else {
                    buttonRec.remove();
                }

                tbody.append(record);
            }
            div.append(table);



        }).fail(function (xhr, status, err) {

        });
    }

    function loadTagBadges(paging) {

        $.ajax({
            url: "https://localhost:5001/Admin/GetTags",
            data: {},
            type: "POST"
        }).done(function (result) {

            $('#tags').children().remove();

            var badLay = $('#badge_layout').clone();
            badLay.removeAttr('id');
            badLay.removeClass('d-none');
            badLay.addClass('d-inline');

            var tagsDiv = $('#tags');

            for (var i = 0; i < result.length; i++) {
                var badTmp = badLay.clone();
                badTmp.find('button').text(result[i].Name);

                if (result[i].Name == paging.Tag) {
                    badTmp.find('button').removeClass('btn-outline-primary');
                    badTmp.find('button').addClass('btn-primary');
                }

                badTmp.click(function () {

                    var tag = $.trim($(this).text());
                    console.log(tag);

                    loadOrders(tag, 1);



                });

                tagsDiv.append(badTmp);
            }

        }).fail(function (xhr, status, err) {
            alert("Error!");
        });


    }

    function pagination(result) {

        console.log(result.Tag);

        var div = $('#PagingDiv');
        div.children().remove();

        var aaa = $('#Page').clone();
        aaa.removeClass('d-none');
        aaa.removeAttr('id');


        for (var i = 1; i <= result.Pages; i++) {
            var tmp = aaa.clone();
            tmp.find('a').text(i);

            if (i === result.CurrentPage) {
                tmp.removeClass('btn-outline-primary');
                tmp.addClass('btn-primary');
            }

            tmp.attr('data', i);

            tmp.click(function () {
                console.log(result.Tag);
                loadOrders(result.Tag, $(this).attr('data'));
            });

            div.append(tmp);
        }
    }
});