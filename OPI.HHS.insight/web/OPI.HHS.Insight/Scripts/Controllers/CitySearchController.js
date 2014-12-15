var CitySearchController = function ($scope, $http, $modal) {
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
    //Modal functions
    $scope.launchMap = function (lat, lon) {
        alert('lat-' + lat);
        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html'
            ,size: 'lg'
            //, controller: 'ModalInstanceCtrl'
            ,size: 'lg',
        //    resolve: {
        //        items: function () {
        //            return $scope.items;
        //        }
        //    }
        });

        var coords = new google.maps.LatLng(lat, lon);
        var mapOptions = {
            zoom: 15,
            center: coords,
            mapTypeControl: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        _map = new google.maps.Map(
                document.getElementById("mapPlaceholder"), mapOptions
        );
    };
}



// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CitySearchController.$inject = ['$scope', '$http', '$modal'];
