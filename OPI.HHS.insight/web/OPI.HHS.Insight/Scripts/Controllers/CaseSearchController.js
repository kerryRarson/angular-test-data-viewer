var CaseSearchController = function ($scope, $http) {
    $scope.models = {
        searching: false,
        showAjaxError: false,
        ajaxError: '',
        searchCase: '',
        searchResults: []
    };
    $scope.searchByCase = function () {
        //alert('searching for case #' + $scope.searchForm.searchCase);
        $scope.searching = true;
        var data = {caseNumber: $scope.searchForm.searchCase};
        $http.post('/api/search/bycase?casenumber=' + $scope.searchForm.searchCase, data)
            .success(function (data, status, headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                $scope.ajaxError = data.Message;//data.execptionMessage;
                $scope.showAjaxError = true;
                $scope.searching = false;
        });
    };
    $scope.buildPeopleUrl = function (caseNum) {
        var returnUrl = '#/casedetail/' + caseNum;
        return returnUrl;
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CaseSearchController.$inject = ['$scope', '$http'];