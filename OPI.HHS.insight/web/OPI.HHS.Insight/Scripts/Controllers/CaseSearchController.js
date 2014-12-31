var CaseSearchController = function ($scope, searchFactory) {
    $scope.models = {
        searching: false,
        showAjaxError: false,
        ajaxError: '',
        searchCase: '',
        searchResults: []
    };
    $scope.searchByCase = function () {
        $scope.searching = true;
        searchFactory.searchByCase($scope.searchForm.searchCase).then(function (results) {
            $scope.searchResults = results;
            $scope.searching = false;
        }, processError);
    };
    $scope.buildPeopleUrl = function (caseNum) {
        var returnUrl = '#/casedetail/' + caseNum;
        return returnUrl;
    };
    function processError(error) {
        $scope.showAjaxError = true;
        $scope.searching = false;
        if (error.data != null) {
            $scope.ajaxError = error.data.ExceptionMessage;
        } else {
            $scope.ajaxError = error.statusText;
        }
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CaseSearchController.$inject = ['$scope', 'searchFactory'];