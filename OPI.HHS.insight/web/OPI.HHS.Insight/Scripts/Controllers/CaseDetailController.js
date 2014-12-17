var CaseDetailController = function ($scope, $http, $rootScope) {
    $scope.showAjaxError = false,
    $scope.ajaxError = '',
    $scope.loading = true;
    $scope.loaded = false;
    $scope.caseNum = '';
    $scope.county = '';
    $scope.referrals = [];
    $scope.relationships = [];
    $scope.programs = [];
    $scope.addresses = [];
    
    $scope.init = function (caseNum) {
        $scope.loading = true;
        $scope.loaded = false;

        $scope.caseNum = caseNum;
        
        //county
        getCounty(caseNum);
        //referrals
        getReferrals(caseNum);
        //relationships
        getParents(caseNum);
        //programs
        getPrograms(caseNum);
        //addresses
        getAddresses(caseNum);

    }
    function getAddresses(caseNum) {
        $http.get('api/search/getaddrsbycase?casenum=' + caseNum)
            .success(function (data, status, headers, config) {
                $scope.addresses = data;
                //LOOK AT
                //http://stackoverflow.com/questions/23361883/angular-js-detect-when-all-http-have-finished
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }
    function getPrograms(caseNum) {
        $http.get('api/search/getprogramsbycase?casenum=' + caseNum)
            .success(function (data, status, headers, config) {
                $scope.programs = data;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }
    function getCounty(caseNum) {
        $http.get('api/search/countybycase?casenum=' + caseNum)
            .success(function (data, status, headers, config) {
                $scope.county = JSON.parse(data);
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }
    function getReferrals(caseNum) {
        $http.get('api/search/getreferralsbycase?casenum=' + caseNum)
            .success(function (data, status, headers, config) {
                $scope.referrals = data;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }
    function getParents(caseNum) {
        $http.get('api/search/getparentsbycase?casenum=' + caseNum)
            .success(function (data, status, headers, config) {
                $scope.parents = data;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }
    //$scope.$on('$viewContentLoaded', function () {
    //    alert('$viewContentLoaded!')
    //this event is fired before the controller is active;
    //});
    $rootScope.$on('loading:progress', function () {
        // show loading gif
        $scope.loading = true;
    });

    $rootScope.$on('loading:finish', function () {
        // hide loading gif
        $scope.loading = false;
        $scope.loaded = true;
    });
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CaseDetailController.$inject = ['$scope', '$http', '$rootScope'];