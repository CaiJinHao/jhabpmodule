'use strict';

$('#sendcode').on('click', function () {
    alert('sendcode');
    abp.ajax({
        type: 'post',
        url: '/api/v1/Email/SendEmailCode',
        data: { email: '531003539@qq.com' },
        success: function success(data) {
            alert('ok');
            console.log(data);
        }
    });
});
alert('ddd');

