var ProgramListController = function ($scope, $http, close, referralId) {
    $scope.showAjaxError = false;
    $scope.ajaxError = '';
    $scope.loaded = false;
    $scope.ReferralId = referralId;
    $scope.ReferralName = '';
    $scope.Programs = [];

    alert('yo in progamListController')

    $scope.init = function () {
        $http.get('api/search/GETreferral?referralid=' + $scope.ReferralId)
            .success(function (data, status, headers, config) {
                $scope.ReferralName = data.FormattedName;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.MessageDetail;
                $scope.showAjaxError = true;
            });
        $http.get('api/search/getProgramImportByReferral?referralId=' + $scope.ReferralId)
            .success(function (data, status, headers, config) {
                $scope.Programs = data;
                $scope.loaded = true;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.MessageDetail;
                $scope.showAjaxError = true;
            });
    };
    $scope.close = function () {
        $modalInstance.close("Someone Closed Me");
    };

}
ProgramListController.$inject = ['$scope', '$http', close];