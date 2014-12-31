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
        return $http.post(serviceBase + 'bycity?st=' + st + '&city=' + city, data).then(
                function (results){
                    return results.data;
                });
    };
    //Search by Case
    factory.searchByCase = function (caseNumber) {
        var data = { caseNumber: caseNumber };
        return $http.post(serviceBase + 'bycase?casenumber=' + caseNumber, data).then(
            function (results) {
                return results.data;
            });
    };
    //Search by Name
    factory.searchByName = function (searchName) {
        var data = { lastName: searchName };
        return $http.post(serviceBase + 'byname?lastname=' + searchName, data).then(
            function (results) {
                return results.data;
            });
    };
    /************************
    Address
    ************************/
    factory.addrsByCase = function (caseNumber) {
        return $http.get(serviceBase + 'getaddrsbycase?casenum=' + caseNumber).then(
            function (results) {
                return results.data;
        });
    };
    factory.addrsByReferral = function (id) {
        return $http.get(serviceBase + 'getaddrsbyreferral?id=' + id).then(
            function (results) {
                return results.data;
            });
    };
    /************************
    Programs
    ************************/
    factory.programsByCase = function (caseNumber) {
        return $http.get(serviceBase + 'getprogramsbycase?casenum=' + caseNumber).then(
            function (results) { return results.data; }
            );
    };
    factory.programsByReferral = function (id) {
        return $http.get(serviceBase + 'getprogramsbyreferral?id=' + id).then(
            function (results) { return results.data;}
            );
    };
    /************************
    County
    ************************/
    factory.countyByCase = function (caseNumber) {
        return $http.get(serviceBase + 'countybycase?casenum=' + caseNumber).then(
            function (results) { return results.data; }
            );
    };
    /************************
    Referrals
    ************************/
    factory.referralsByCase = function (caseNumber) {
        return $http.get(serviceBase + 'getreferralsbycase?casenum=' + caseNumber).then(
            function (results) { return results.data; }
            );
    };
    /************************
    Parents
    ************************/
    factory.parentsByCase = function (caseNumber) {
        return $http.get(serviceBase + 'getparentsbycase?casenum=' + caseNumber).then(
            function (results) { return results.data; }
            );
    };
    /************************
    Geocode
    ************************/
    factory.geoCode = function (street1,street2,city,st) {
        var data = { line1: street1, line2: street2, city: city, state: st };
        return $http.post('/api/geocode?line1=' + street1 + '&line2=' + street2 + '&city=' + city + '&state=' + st, data).then(
            function (results) {
                return results.data;
            });
    };

    return factory;
};

searchFactory.$inject = ['$http', '$q'];
