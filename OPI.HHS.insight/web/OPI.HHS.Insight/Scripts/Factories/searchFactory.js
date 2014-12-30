var searchFactory = function ($http, $q) {
    
    var serviceBase = '/api/search/',
        factory = {};

    //Search by City 
    factory.getStates = function () {
        return $http.get(serviceBase + 'getstates').then(
            function (results) {
                return results.data;
            });
    };
    factory.getCities = function (st) {
        return $http.get(serviceBase + 'getcities?st=' + st).then(
            function (results) {
                return results.data;
            });
    };
    factory.searchByCity = function (st, city) {
        var data = { st: st, city: city };
        return $http.post('/api/search/bycity?st=' + st + '&city=' + city, data).then(
                function (results){
                    return results.data;
                });
    };

    //Search by Case

    return factory;
};

searchFactory.$inject = ['$http', '$q'];
