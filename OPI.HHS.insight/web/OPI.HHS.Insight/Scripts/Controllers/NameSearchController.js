var NameSearchController = function ($scope, $http) {
    $scope.models = {
        showAjaxError: false,
        ajaxError: '',
        searching: false,
        searchName: '',
        searchResults: []
    };
    $scope.searchByName = function () {
        $scope.searching = true;

        var data = { lastName: $scope.searchForm.searchName };
        $http.post('/api/search/byname?lastname=' + $scope.searchForm.searchName, data)
            .success(function (data, status, headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                $scop.ajaxError = status;//data.MessageDetail;
                $scope.showAjaxError = true;
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