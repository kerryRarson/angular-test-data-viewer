var CitySearchController = function ($scope, $http, $modal, searchFactory) {
    $scope.models = {
        searching: false,
        loaded: false,
        showAjaxError: false,
        ajaxError: '',
        searchState: '',
        searchCity: '',
        cityFocus: false,
        searchResults: [],
        states: [],
        cities: [],
    };
    $scope.searchByCity = function () {
        $scope.searching = true;
        var data = {st: $scope.searchState, city: $scope.searchByCity};
        $http.post('/api/search/bycity?st=' + $scope.searchState + '&city=' + $scope.searchCity, data)
            .success(function (data, status,         headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
                $scope.loaded = true;
            }).error(function (data, status, headers, config) {
                $scope.ajaxError = data.ExceptionMessage;
                $scope.showAjaxError = true;
                $scope.searching = false;
            });
    };
    $scope.buildPeopleUrl = function (caseNum){
        var returnUrl = '#/casedetail/' + caseNum;
        return returnUrl;
    };
    $scope.buildReferralUrl = function (referralId) {
        var returnUrl = '#/referral/' + referralId;
        return returnUrl;
    };
    $scope.stateChange = function (val) {
        $scope.searchCity = '';
        getCities(val);
        //raise the event to set focus on the city textbox
        $scope.$broadcast('cityFocus');
    };
    function getStates() {
        searchFactory.getStates().then(function (states) {
            $scope.searchState = 'MT';//default to MT
            $scope.states = states;
        }, processError);
    };
    function getCities(st) {
        searchFactory.getCities(st).then(function (cities) {
            $scope.cities = cities;
        }, processError);
    };
    function processError(error) {
        $scope.showAjaxError = true;
        if (error.data != null) {
            $scope.ajaxError = error.data.ExceptionMessage;
        } else {
            $scope.ajaxError = error.statusText;
        }


    };
    function init() {
        //populate the state dropdown
        getStates();
        getCities($scope.searchState);
    }
    init();

    //Modal functions
    $scope.launchMap = function (lat, lon, title) {
        //alert('lat-' + lat);
        $scope.lat = lat;
        $scope.lon = lon;
        $scope.title = title;

        var modalInstance = $modal.open({
            templateUrl: '/scripts/partials/theDialogPartial.html',
            size: 'lg',
            controller: 'TheDialogController',
            resolve: {
                lat: function () { return $scope.lat; },
                lon: function () { return $scope.lon; },
                title: function () { return $scope.title; }
            }
        });
        showLocation($scope.lat, $scope.lon, 'XXXX');

        modalInstance.result.then(function (paramFromDialog) {
            $scope.paramFromDialog = paramFromDialog;
        });

    };
}



// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$http', '$modal', 'searchFactory'];
