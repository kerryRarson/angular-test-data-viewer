var ParentSearchController = function ($scope, searchFactory) {
    $scope.models = {
        searching: false,
        showAjaxError: false,
        ajaxError: '',
        searchName: '',
        searchResults: []
    };
    $scope.init = function () {
        $scope.searching = false;
        $scope.ajaxError = "TODO:  This controller needs to be finished.";
        $scope.showAjaxError = true;
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
ParentSearchController.$inject = ['$scope', 'searchFactory'];