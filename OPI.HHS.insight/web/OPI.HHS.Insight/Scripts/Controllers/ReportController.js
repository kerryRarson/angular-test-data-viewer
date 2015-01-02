var ReportController = function ($scope) {
    $scope.models = {
        showAjaxError: false,
        ajaxError: ''
    };
    function processError(error) {
        $scope.showAjaxError = true;
        if (error.data != null) {
            $scope.ajaxError = error.data.ExceptionMessage;
        } else {
            $scope.ajaxError = error.statusText;
        }
    };
}
ReportController.$inject = ['$scope'];