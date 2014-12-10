var CaseSearchController = function ($scope, $http) {
    $scope.searchForm = {
        searchCase: '',
        searchResults: []
    };
    $scope.models = {
        searching: false
    };
    $scope.searchByCase = function () {
        alert('searching for case #' + $scope.searchForm.searchCase);
        $scope.searching = true;
        
        //	$scope.searching = false;
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CaseSearchController.$inject = ['$scope'];