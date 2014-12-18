var ReferralDetailController = function ($scope, $http) {
    $scope.showAjaxError = false;
    $scope.ajaxError = '';
    $scope.loaded = false;
    $scope.ReferralId = '';
    $scope.LastName = '';
    $scope.FirstName = '';

    $scope.init = function (referralId) {
        $scope.referralId = referralId;
        getReferral(referralId);
        $scope.loaded = true;
    }
    function getReferral(id) {
        $http.get('api/search/getreferral?id=' + id)
            .success(function (data, status, headers, config) {
                $scope.LastName = data.LastName;
                $scope.FirstName = data.FirstName;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    }

}
// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
ReferralDetailController.$inject = ['$scope', '$http'];