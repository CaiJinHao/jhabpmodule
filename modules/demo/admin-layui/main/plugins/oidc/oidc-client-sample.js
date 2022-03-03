if (location.search.indexOf('_p') != -1) {
    localStorage.setItem('urlsearch', location.search);//记录跳转前search
}

// Oidc.Log.logger = console;
// Oidc.Log.level = Oidc.Log.INFO;
var settings = {
    authority: 'https://localhost:7001',
    client_id: 'YourProjectName_Js',
    redirect_uri: window.location.origin + '/ids/callback.html',
    response_type: 'id_token token',
    scope: 'email openid profile role phone address YourProjectName offline_access',
    post_logout_redirect_uri: 'https://localhost:7001/index',

    filterProtocolClaims: false,
    loadUserInfo: false
};

var manager = new Oidc.UserManager(settings);

var oidcManager = {
    getUser: function (_fn) {
        let _the=this;
        var signinResponseJson = sessionStorage.getItem("signinResponse");
        if (signinResponseJson) {
            var signinResponse = JSON.parse(signinResponseJson);
            _fn(signinResponse);
        } else {
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
