var demoApp = angular.module('demoApp', ['ngRoute', 'ui.bootstrap']);

demoApp.controller('CitySearchController', CitySearchController);
demoApp.controller('CaseSearchController', CaseSearchController);
demoApp.controller('NameSearchController', NameSearchController);
demoApp.controller('CaseDetailController', CaseDetailController);
demoApp.controller('ReferralDetailController', ReferralDetailController);
demoApp.controller('ProgramListController', ProgramListController);
demoApp.controller('ParentSearchController', ParentSearchController);
demoApp.controller('ReportController', ReportController);
//TODO refactor this to it's own controller .js
demoApp.controller('TheDialogController', function ($scope, $modalInstance, lat, lon, title) {
    $scope.valuePassed = lat;
    $scope.valuePassed = lon;
    $scope.title = title;
    $scope.close = function () {
        $modalInstance.close("Someone Closed Me");
    };
});
demoApp.directive('focusOn', function () {
    return function (scope, elem, attr) {
        scope.$on(attr.focusOn, function (e) {
            elem[0].focus();
        });
    };
});
//demoApp.controller('LoginController', LoginController);
//demoApp.controller('RegisterController', RegisterController);
demoApp.factory('searchFactory', searchFactory);
//demoApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
//demoApp.factory('LoginFactory', LoginFactory);
//demoApp.factory('RegistrationFactory', RegistrationFactory);
demoApp.factory('httpInterceptor', function ($q, $rootScope, $log) {
    var loadingCount = 0;

    return {
        request: function (config) {
            if(++loadingCount === 1) $rootScope.$broadcast('loading:progress');
            return config || $q.when(config);
        },

        response: function (response) {
            if(--loadingCount === 0) $rootScope.$broadcast('loading:finish');
            return response || $q.when(response);
        },

        responseError: function (response) {
            if(--loadingCount === 0) $rootScope.$broadcast('loading:finish');
            return $q.reject(response);
        }
    };
})

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
            templateUrl: function (params) { return '/search/casedetail?caseNum=' + params.caseNum; },
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
        .when('/parentSearch', {
            templateUrl: 'search/searchbyparent',
            controller: ParentSearchController
        })
        .when('/referral/:id', {
            templateUrl: function (params) { return '/search/referraldetail?id=' + params.id; },
            controller: ReferralDetailController
        })
        .when('/reportHome', {
            templateUrl: 'report/index',
            controller: ReportController
        })
        .when('/reportByCity', {
            templateUrl: 'report/city',
            controller: ReportController
        })
        .when('/caseExtract', {
            templateUrl: 'report/CaseExtract',
            controller: ReportController
        })
        .otherwise('/citySearch', {
            templateUrl: 'search/searchbycity',
            controller: CitySearchController
        });
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
    $httpProvider.interceptors.push('httpInterceptor');
    //$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

demoApp.config(configFunction);