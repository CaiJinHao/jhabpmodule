var urlsearchStorageName = 'urlsearch';
localStorage.setItem(urlsearchStorageName, location.search); //记录跳转前search

var host = window.location.origin;
var authorityHost='https://localhost:7001';
// Oidc.Log.logger = console;
// Oidc.Log.level = Oidc.Log.INFO;
var settings = {
    authority: 'https://localhost:7001',
    client_id: 'YourProjectName_Js',
    redirect_uri: host + '/ids/callback.html',
    response_type: 'id_token token',
    scope: 'email openid profile role phone address YourProjectName offline_access',
    post_logout_redirect_uri: 'https://localhost:7001/index',
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
    console.log('UserSignedOut：', arguments);
    manager.removeUser();
});


var oidcManager = {
    getUser:function(callback){
        var _the=this;
        manager.getUser().then(function(user){
            if (user) {
                callback(user);
            } else {
                _the.loginRedirect();
            }
        });
    },
    login:function(){
        var _the=this;
        _the.logoutRedirect();
    },
    logout:function(){
        var _the=this;
        _the.logoutRedirect();
    },
    loginRedirect:function(){
        manager.signinRedirect()
                .catch(function (error) {
                    console.error('error while logging', error);
                });
    },
    logoutRedirect:function(){
        manager.signoutRedirect()
                .catch(function (error) {
                    console.error('error while signing out user', error);
                });
    }
};
