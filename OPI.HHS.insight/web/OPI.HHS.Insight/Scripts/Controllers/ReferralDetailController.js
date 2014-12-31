var ReferralDetailController = function ($scope, searchFactory) {
    $scope.showAjaxError = false;
    $scope.ajaxError = '';
    $scope.loaded = false;
    $scope.ReferralId = '';
    $scope.addresses = [];
    $scope.programs = [];
    $scope.showMap = false;
    $scope.Lat = '';
    $scope.Lon = '';

    
    $scope.init = function (referralId) {
        $scope.referralId = referralId;
        getAddresses(referralId);
        getPrograms(referralId);
        $scope.loaded = true;
    }
    $scope.rowClick = function (line1, line2, city, state) {
        $scope.showMap = true;
        searchFactory.geoCode(line1, line2, city, state).then(function (results) {
            $scope.Lat = results.Lat;
            $scope.Lon = results.Lon;
            showLocation($scope.Lat,$scope.Lon, results.FormattedAddress);
            $scope.searching = false;
        }, processError);
    };
    function getAddresses(referralId) {
        searchFactory.addrsByReferral(referralId).then(function ( results ){
            $scope.addresses = results;
        },processError);
    };
        
    function getPrograms(referralId) {
        searchFactory.programsByReferral(referralId).then(function (results) {
            $scope.programs = results;
        }, processError);
    }
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
ReferralDetailController.$inject = ['$scope', 'searchFactory'];