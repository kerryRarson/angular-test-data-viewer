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
}
ParentSearchController.$inject = ['$scope', 'searchFactory'];