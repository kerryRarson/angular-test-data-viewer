var ReferralDetailController = function ($scope, $http) {
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

        var data = { line1: line1, line2: line2, city: city, state: state };
        $http.post('/api/geocode?line1=' + line1 + '&line2=' + line2 + '&city=' + city + '&state=' + state, data)
            .success(function (data, status, headers, config) {
                $scope.Lat = data.Lat;
                $scope.Lon = data.Lon;
                showLocation(data.Lat, data.Lon, data.FormattedAddress);
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                $scope.ajaxError = data.MessageDetails;
                $scope.showAjaxError = true;
                $scope.searching = false;
            });

    }
    function getAddresses(referralId) {
        $http.get('api/search/getaddrsbyreferral?id=' + referralId)
            .success(function (data, status, headers, config) {
                $scope.addresses = data;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.MessageDetail;
                $scope.showAjaxError = true;
            });
    }
    function getPrograms(referralId) {
        $http.get('api/search/getprogramsbyreferral?id=' + referralId)
            .success(function (data, status, headers, config) {
                $scope.programs = data;
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.MessageDetail;
                $scope.showAjaxError = true;
            });
    }

}
// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
ReferralDetailController.$inject = ['$scope', '$http'];