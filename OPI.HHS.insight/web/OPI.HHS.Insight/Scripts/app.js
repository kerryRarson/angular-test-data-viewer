var demoApp = angular.module('demoApp', ['ngRoute', 'ui.bootstrap']);

demoApp.controller('LandingPageController', LandingPageController);
//demoApp.controller('LoginController', LoginController);
//demoApp.controller('RegisterController', RegisterController);

//demoApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
//demoApp.factory('LoginFactory', LoginFactory);
//demoApp.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/citySearch', {
            templateUrl: 'search/searchbycity'
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
        })
        .when('/caseSearch', {
            templateUrl: 'search/searchbycase'
        })
        .when('/nameSearch', {
            templateUrl: 'search/searchbyname'
        })
        //.when('/routeThree', {
        //    templateUrl: 'routesDemo/three'
        //})
        //.when('/login', {
        //    templateUrl: '/Account/Login',
        //    controller: LoginController
        //})
        //.when('/register', {
        //    templateUrl: '/Account/Register',
        //    controller: RegisterController
        //});

    //$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

demoApp.config(configFunction);