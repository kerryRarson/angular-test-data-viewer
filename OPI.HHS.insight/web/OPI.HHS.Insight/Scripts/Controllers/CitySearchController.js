var CitySearchController = function ($scope, $http) {
    $scope.searchForm = {
        searchState: 'MT',
        searchCity: '',
        searchResults: []
    };
    $scope.models = {
        searching: false
    };
    $scope.states = getStates();
    $scope.searchByCity = function () {
        //var result = ProductFactory($scope.searchForm.searchState, $scope.searchForm.searchCity);
        $scope.searching = true;
        $http.get('/api/search/bycity?state=' + $scope.searchForm.searchState + '&city=' + $scope.searchForm.searchCity)
            .success(function (data, status, headers, config) {
                debugger;//KLL
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                alert("Oops... something went wrong");
                $scope.searching = false;
            });

        //result.then(function (result) {
        //	if (result.success) {
        //		if ($scope.productForm.returnUrl !== undefined) {
        //			$location.path('/routeOne');
        //		} else {
        //			$location.path($scope.productForm.returnUrl);
        //		}
        //	} else {
        //		$scope.productForm.ReturnCount = 0;
        //		$scope.productForm.ResultMessage = "Something bad happened.";
        //	}
        //	$scope.searching = false;
    };
    //$scope.navbarProperties = {
    //    isCollapsed: true
    //};
    function getStates() {
        $http.get('api/search/getstates')
            .success(function (data, status, headers, config) {
                return data;
            })
            .error(function (data, status, headers, config) {
                alert("Oops... something went wrong");
            });
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$http'];