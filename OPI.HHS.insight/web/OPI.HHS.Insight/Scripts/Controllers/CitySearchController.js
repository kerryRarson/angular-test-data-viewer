var CitySearchController = function ($scope, $modal, searchFactory) {
    $scope.models = {
        searching: true,
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
        searchFactory.searchByCity($scope.searchState, $scope.searchCity).then(function (results){
            $scope.searchResults = results;
            $scope.searching = false;
            $scope.loaded = true;
        }, processError);
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
        $scope.searching = true;
        searchFactory.getStates().then(function (states) {
            $scope.searchState = 'MT';//default to MT
            $scope.states = states;
            getCities($scope.searchState);
            $scope.searching = false;
        }, processError);
    };
    function getCities(st) {
        searchFactory.getCities(st).then(function (cities) {
            $scope.cities = cities;
        }, processError);
    };
    function processError(error) {
        $scope.showAjaxError = true;
        $scope.searching = false;
        if (error.data != null) {
            if (error.data.ExceptionMessage != null) {
                $scope.ajaxError = error.data.ExceptionMessage;
            } else {
                $scope.ajaxError = error.data.MessageDetail;
            }
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
    $scope.launchMap = function (lat, lon, caseNum) {
        //alert('lat-' + lat);
        $scope.lat = lat;
        $scope.lon = lon;
        $scope.caseNum = caseNum;
        $scope.searchFactory = searchFactory;

        var modalInstance = $modal.open({
            templateUrl: '/scripts/partials/theDialogPartial.html',
            size: 'lg',
            controller: 'TheDialogController',
            resolve: {
                lat: function () { return $scope.lat; },
                lon: function () { return $scope.lon; },
                caseNum: function () { return $scope.caseNum; },
                searchFactory: function () { return $scope.searchFactory; }
            }
        });
        //showLocation($scope.lat, $scope.lon, 'XXXX');

        modalInstance.result.then(function (paramFromDialog) {
            $scope.paramFromDialog = paramFromDialog;
        });

    };
}



// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$modal', 'searchFactory'];
