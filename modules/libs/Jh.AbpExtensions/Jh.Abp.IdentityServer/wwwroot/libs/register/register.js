var btnSendCode = $(), email = $('#Input_EmailAddress');

var callBackObj = {
    sendCodeCallBack: function () {
        alert('发送成功');
    }
};
$('#sendcode').on('click', function () {
    var myform = $(this).parents('form');
    var _b = myform.validate().element(email);
    if (_b) {
        var data = { email: email.val() };
        var stringifyData = JSON.stringify(data);
        abp.ajax({
            type: 'POST',
            url: abp.appPath + 'api/v1/Email/SendEmailCode',
            data: stringifyData,
            success: function () {
                callBackObj.sendCodeCallBack();
            }
        })
    }
});