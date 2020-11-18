
var Transaction = {
    get: function (url, data, onSuccess) {
        if (data == undefined) {
            data = {};
        }

        $.ajax({
            type: 'GET',
            url: url,
            traditional: true,
            data: data,
            cache: false,
            success: function (result) {
                if (!Transaction.isEmpty(onSuccess)) {
                    onSuccess(result);
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    },
    post: function (url, data, onSuccess) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            cache: false,
            success: function (result) {
                if (!Transaction.isEmpty(onSuccess)) {
                    onSuccess(result);
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });

    },
    isEmpty: function (obj) {
        var result = false;
        var undef, key, i, len;
        var emptyValues = [undefined, undef, null, false, 0, '', '0', 'NaN', NaN];

        for (i = 0, len = emptyValues.length; i < len; i++) {
            if (obj === emptyValues[i]) {
                result = true;
                return result;
            }
        }
        return result;
    },
}