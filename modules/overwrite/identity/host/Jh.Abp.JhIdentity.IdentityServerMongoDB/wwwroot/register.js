var btnSendCode = $(), email = $('#Input_EmailAddress');

$('#sendcode').on('click', function () {
    abp.ajax({
        type: 'POST',
        url:'/api/v1/Email/SendEmailCode',
        data: JSON.stringify({ email: email.val() }),
        success: function (data) {
            alert('ok');
            console.log(data);
        }
    })
});
