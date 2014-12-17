var CitySearchController = function ($scope, $http, $modal) {
    $scope.models = {
        searching: false,
        showAjaxError: false,
        ajaxError: '',
        searchState: '',
        searchCity: '',
        searchResults: [],
        states: []
    };
    $scope.searchByCity = function () {
        $scope.searching = true;
        $http.get('/api/search/bycity?st=' + $scope.searchState + '&city=' + $scope.searchCity)
            .success(function (data, status,         headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
                $scope.searching = false;
            });
    };
    $scope.buildPeopleUrl = function (caseNum){
        var returnUrl = '#/casedetail/' + caseNum;
        return returnUrl;
    };

    function getStates() {
        $http.get('api/search/getstates')
            .success(function (data, status, headers, config) {
                $scope.states = data;
                $scope.searchState = 'MT';
            })
            .error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
            });
    };
    function init() {
        //populate the state dropdown
        getStates();
    }
    init();
    //Modal functions
    $scope.launchMap = function (lat, lon) {
        // from http://www.kendar.org/?p=/tutorials/angularjs/part03
        //alert('lat-' + lat);
        $scope.valueToPass = lat + "/" + lon;

        var modalInstance = $modal.open({
            templateUrl: '/scripts/theDialogPartial.html',
            controller: 'TheDialogController',
            resolve: {
                aValue: function () {
                    return $scope.valueToPass;
                }
            }
        });
        modalInstance.result.then(function (paramFromDialog) {
            $scope.paramFromDialog = paramFromDialog;
        });

    };
}



// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$http', '$modal'];
