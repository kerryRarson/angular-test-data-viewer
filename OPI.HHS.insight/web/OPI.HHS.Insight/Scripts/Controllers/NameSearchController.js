var NameSearchController = function ($scope, $modal, searchFactory) {
    $scope.models = {
        showAjaxError: false,
        ajaxError: '',
        searching: false,
        searchName: '',
        searchResults: []
    };
    $scope.searchByName = function () {
        $scope.searching = true;
        searchFactory.searchByName($scope.searchForm.searchName).then(function (results) {
            $scope.searchResults = results;
            $scope.searching = false;
        },processError)
    };
        
    $scope.buildReferralUrl = function (referralId) {
        var returnUrl = '#/referral/' + referralId;
        return returnUrl;
    };
    $scope.showCases = function (referralId) {
        alert('yo referral -' + referralId);
        var modalInstance = $modal.open({
            //TODO LOOK AT 
            //http://www.codeproject.com/Articles/786609/The-Only-AngularJS-Modal-Service-Youll-Ever-Need
            //Instead of using the bootstrap modal

            templateUrl: '/scripts/partials/CaseListPartial.html',
            size: 'lg',
            controller: 'ProgramListController',
            resolve: {
                referralId: function () { return referralId; }
            }
        });
            
        modalInstance.result.then(function (paramFromDialog) {
            $scope.paramFromDialog = paramFromDialog;
        });
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

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
NameSearchController.$inject = ['$scope', '$modal', 'searchFactory'];