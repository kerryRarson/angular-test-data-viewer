var NameSearchController = function ($scope, $http) {
    $scope.models = {
        searching: false,
        searchName: '',
        searchResults: []
    };
    $scope.searchByName = function () {
        $scope.searching = true;

        $http.get('/api/search/byname?lastname=' + $scope.searchForm.searchName)
            .success(function (data, status, headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                alert("Oops... something went wrong");
                $scope.searching = false;
            });
        $scope.buildReferralUrl = function (referralId) {
            var returnUrl = '#/referral/' + referralId;
            return returnUrl;
        };
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
NameSearchController.$inject = ['$scope', '$http'];