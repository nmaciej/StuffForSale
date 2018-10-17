$(document).ready(function () {

    loadTags();
    addTagBtn();

    function loadTags() {
        $.ajax({
            url: "https://localhost:5001/Admin/GetTags",
            data: {},
            type: "POST"
        }).done(function (result) {

            console.log(result);

            var tableSpot = $('#tags_table_location');
            tableSpot.empty();

            //console.log(result);
            var tab = $('#tags_table').clone();
            tab.removeClass('d-none');
            var tabBody = tab.find('tbody');
            tableSpot.append(tab);

            var tr = tab.find('.data_tr');

            for (var i = 0; i < result.length; i++) {

                var trCopy = tr.clone();
                trCopy.removeClass('d-none');

                trCopy.attr('id', result[i].TagId);
                trCopy.find('.id').text(i + 1);
                trCopy.find('.name').text(result[i].Name);
                trCopy.find('.products').text(result[i].Products.length);
                var btn = trCopy.find('.b').find('.btn');
                btn.text("Remove");
                btn.addClass('btn-outline-danger');

                btn.click(removeTag);

                tabBody.append(trCopy);
            }


        }).fail(function (xhr, status, err) {
            alert("Error!");
        });
    }

    function removeTag() {

        var id = $(this).parent().parent().attr('id');
        var products = $(this).parent().parent().find('.products').text();

        if (products === 0) {
            $.ajax({
                url: "https://localhost:5001/Admin/RemoveTag",
                data: { id: id },
                type: "POST"
            }).done(function (result) {
                loadTags();
                bootbox.alert("Tag deleted!");
            }).fail(function (xhr, status, err) {
                loadTags();
                bootbox.alert("Something went wrong!");
            });
        }
        else {
            bootbox.alert("There are products with this tag assigned!");
        }
    }



    function addTagBtn() {

        $('#btn').click(function () {

            var inp = $('#input').val();

            if (inp.length < 3) {
                bootbox.alert("Tag name should have at least 3 letters!");
            } else {
                $.ajax({
                    url: "https://localhost:5001/Admin/AddTag",
                    data: { newTag: inp },
                    type: "POST"
                }).done(function (result) {
                    loadTags();
                    bootbox.alert("Tag added!");
                }).fail(function (xhr, status, err) {
                    loadTags();
                    bootbox.alert("Tag already exists!");
                });
            }

        });

    }
});