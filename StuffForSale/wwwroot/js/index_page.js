$(document).ready(function () {

    var dataURL = 'https://localhost:5001/Product/GetAll';
    var App = new Vue({
        el: '#firstTable',
        data: {
            columnsDisplay: ['Id', 'Name', 'Description', 'Price', 'Added'],
            columns: ['productId', 'name', 'description', 'price', 'dateAdded'],
            rows: [] // initialize empty array
        },
        mounted() { // when the Vue app is booted up, this is run automatically.
            var self = this; // create a closure to access component in the callback below
            $.getJSON(dataURL, function (result) {
                console.log(result);
                self.rows = result;
            });
        }
    });
});