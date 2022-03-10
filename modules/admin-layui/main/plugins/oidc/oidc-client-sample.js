if (location.search.indexOf('_p') != -1) {
    localStorage.setItem('urlsearch', location.search);//记录跳转前search
}

var host = window.location.origin;
var authorityHost='https://localhost:6201';
// Oidc.Log.logger = console;
// Oidc.Log.level = Oidc.Log.INFO;
var settings = {
    authority: 'https://localhost:6201',
    client_id: 'WebAppYourName_Js',
    redirect_uri: host + '/ids/callback.html',
    response_type: 'id_token token',
    scope: 'email openid profile role phone address WebAppYourName offline_access',
    post_logout_redirect_uri: 'https://localhost:6201/index',
    filterProtocolClaims: false,
    loadUserInfo: false,
    
    // silent_redirect_uri: host + '/ids/refresh-token.html',
    // ccessTokenExpiringNotificationTime: 4,
    // automaticSilentRenew: false,
};

var manager = new Oidc.UserManager(settings);
manager.events.addUserLoaded(function () {
    console.log('UserLoaded：', arguments);
});

manager.events.addAccessTokenExpiring(function () {
    console.log('AccessTokenExpiring：', arguments);
});

manager.events.addAccessTokenExpired(function () {
    console.log('AccessTokenExpired：', arguments);
});

manager.events.addSilentRenewError(function () {
    console.error('SilentRenewError：', arguments);
});

manager.events.addUserSignedOut(function () {
    alert("已经退出！");
    console.log('UserSignedOut：', arguments);
    manager.removeUser();
});


var oidcManager = {
    // getUserInfo:function(callback){
    //     manager.getUser().then(callback);
    // },
    // getUser:function(callback){
    //     var _the=this;
    //     console.log('dd');
    //     manager.getUser().then(function(user){
    //         console.log(user);
    //         if (user) {
    //             alert("已经登录！");
    //             callback(user);
    //         } else {
    //             _the.loginRedirect();
    //         }
    //     });
    // },
    // login:function(){
    //     var _the=this;
    //     _the.getUserInfo(function(user){
    //         if (user) {
    //             alert("已经登录！");
    //             return user;
    //         } else {
    //             _the.loginRedirect();
    //         }
    //     });
    // },
    // logout:function(){
    //     var _the=this;
    //     _the.getUserInfo(function (user) {
    //         if (!user) {
    //             alert("已经注销！");
    //         } else {
    //             _the.logoutRedirect();
    //         }
    //     });
    // },
    // loginRedirect:function(){
    //     manager.signinRedirect()
    //             .catch(function (error) {
    //                 console.error('error while logging', error);
    //             });
    // },
    // logoutRedirect:function(){
    //     manager.signoutRedirect()
    //             .catch(function (error) {
    //                 console.error('error while signing out user', error);
    //             });
    // }


    getUser: function (_fn) {
        let _the=this;
        var signinResponseJson = sessionStorage.getItem("signinResponse");
        if (signinResponseJson) {
            var signinResponse = JSON.parse(signinResponseJson);
            _fn(signinResponse);
        } else {
            console.log(signinResponseJson);
            _the.login();
        }
    },
    login: function () {
        manager.signinRedirect({ state: { bar: 15 } });
    },
    logout: function () {
        var signinResponseJson= sessionStorage.getItem("signinResponse");
        var signinResponse=JSON.parse(signinResponseJson);
        sessionStorage.removeItem("signinResponse");
        manager.signoutRedirect({ id_token_hint: signinResponse && signinResponse.id_token, state: { foo: 5 } });
    }
};
