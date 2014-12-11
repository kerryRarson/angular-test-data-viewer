var demoApp = angular.module('demoApp', ['ngRoute', 'ui.bootstrap']);

demoApp.controller('LandingPageController', LandingPageController);
demoApp.controller('CitySearchController', CitySearchController);
demoApp.controller('CaseSearchController', CaseSearchController);
demoApp.controller('NameSearchController', NameSearchController);
demoApp.controller('CaseDetailController', CaseDetailController);
//demoApp.controller('LoginController', LoginController);
//demoApp.controller('RegisterController', RegisterController);

//demoApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
//demoApp.factory('LoginFactory', LoginFactory);
//demoApp.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/citySearch', {
            templateUrl: 'search/searchbycity',
            controller: CitySearchController
        })
        //.when('/casedetail/:line1/:line2/:city/:st/:zip',{
        //    templateUrl: function (params) { return '/search/peopleByAddress?line1=' + params.line1 + '&line2=' + params.line2 + '&city=' + params.city + '&st=' + params.st + '&zip=' + params.zip; },
        //    controller: PeopleSearchController
        //})
        .when('/casedetail/:caseNum', {
            templateUrl: function (params) { return '/search/casedetail?caseNum=' + params.caseNum ; },
            controller: CaseDetailController
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
        })
        .when('/caseSearch', {
            templateUrl: 'search/searchbycase',
            controller: CaseSearchController
        })
        .when('/nameSearch', {
            templateUrl: 'search/searchbyname',
            controller: NameSearchController
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