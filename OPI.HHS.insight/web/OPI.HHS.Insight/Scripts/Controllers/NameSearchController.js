var NameSearchController = function ($scope, ModalService, searchFactory) {
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
        //http://adamalbrecht.com/2013/12/12/creating-a-simple-modal-dialog-directive-in-angular-js/
        alert('yo referral -' + referralId);
        //var modalInstance = $modal.open({
        //    //TODO LOOK AT 
        //    //http://www.codeproject.com/Articles/786609/The-Only-AngularJS-Modal-Service-Youll-Ever-Need
        //    //Instead of using the bootstrap modal

        //    templateUrl: '/scripts/partials/CaseListPartial.html',
        //    size: 'lg',
        //    controller: 'ProgramListController',
        //    resolve: {
        //        referralId: function () { return referralId; }
        //    }
        //});
            
        //modalInstance.result.then(function (paramFromDialog) {
        //    $scope.paramFromDialog = paramFromDialog;
        //});
        ModalService.showModal({
            templateUrl: '/scripts/partials/caselistpartial.html',
            controller: 'ProgramListController'
        }).then(function (modal) {
            alert('yo in the THEN!');
            //it's a bootstrap element, use 'modal' to show it
            modal.element.modal();
            modal.close.then(function (result) {
                console.log(result);
            });
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