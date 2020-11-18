var User = {
    create: function () {
        name = $("#name").text();
        surname = $("#surname").text();
        adress = $("#adress").text();
        email = $("#email").text();

        Transaction.post("\Add", {
            name: name,
            surname: surname,
            adress: adress,
            email: email
        }, function (result) {
            console.log(result);
        });
    }
}