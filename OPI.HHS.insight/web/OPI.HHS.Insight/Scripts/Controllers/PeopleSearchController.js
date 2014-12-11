var PeopleSearchController = function ($scope, $http) {    
    $scope.caseNum = '';
        //line1: '',
        //line2: '',
        //city: '',
        //st: '',
        //zip: '',
        //searchResults: [],
        //searching: false
    
    $scope.searchByAddr = function () {
        alert('searching for people by address...');
        $scope.searching = true;

        //	$scope.searching = false;
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
PeopleSearchController.$inject = ['$scope', '$http'];