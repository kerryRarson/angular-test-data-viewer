var CitySearchController = function ($scope, $http) {
    $scope.models = {
        searching: false,
        searchState: '',
        searchCity: '',
        searchResults: [],
        states: []
    };
    $scope.searchByCity = function () {
        $scope.searching = true;
        $http.get('/api/search/bycity?st=' + $scope.searchState + '&city=' + $scope.searchCity)
            .success(function (data, status, headers, config) {
                $scope.searchResults = data;
                $scope.searching = false;
            }
            ).error(function (data, status, headers, config) {
                debugger;
                alert("Oops... something went wrong");
                $scope.searching = false;
            });
    };
    //$scope.launchMap = function (lat,lon){
    //    var rtn = "XXX";
    //    alert('yo');
    //}
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
                alert("Oops... something went wrong");
            });
    };
    function init() {
        //populate the state dropdown
        getStates();
    }
    init();
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$http'];