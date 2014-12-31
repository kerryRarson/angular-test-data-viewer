var CaseDetailController = function ($scope, $rootScope, $modal, searchFactory) {
    $scope.showAjaxError = false,
    $scope.ajaxError = '',
    $scope.loading = true;
    $scope.loaded = false;
    $scope.caseNum = '';
    $scope.county = '';
    $scope.referrals = [];
    $scope.relationships = [];
    $scope.programs = [];
    $scope.addresses = [];
    
    $scope.init = function (caseNum) {
        $scope.loading = true;
        $scope.loaded = false;

        $scope.caseNum = caseNum;
        
        //county
        getCounty(caseNum);
        //referrals
        getReferrals(caseNum);
        //relationships
        getParents(caseNum);
        //programs
        getPrograms(caseNum);
        //addresses
        getAddresses(caseNum);

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
    $scope.showMapModal = function(line1, line2, city, state, title)
    {
        $scope.loading = true;
        searchFactory.geoCode(line1, line2, city, state).then(function (results) {
            $scope.Lat = results.Lat;
            $scope.Lon = results.Lon;
            alert('geoCoded ' + results.FormattedAddress);
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                size: 'lg',
                resolve: {
                    Lat: function () { return $scope.Lat; },
                    Lon: function() { return $scope.Lon}
                }
            });
            $scope.loading = false;
        }, processError);
        //var data = { line1: line1, line2: line2, city: city, state: state };
        //$http.post('/api/geocode?line1=' + line1 + '&line2=' + line2 + '&city=' + city + '&state=' + state, data)
        //    .success(function (data, status, headers, config) {
        //        $scope.Lat = data.Lat;
        //        $scope.Lon = data.Lon;

        //        //alert('geoCoded ' + data.FormattedAddress);
        //        var modalInstance = $modal.open({
        //            templateUrl: 'myModalContent.html',
        //            controller: 'ModalInstanceCtrl',
        //            size: 'lg',
        //            resolve: {
        //                Lat: function () { return $scope.Lat; },
        //                Lon: function() { return $scope.Lon}
        //            }
        //        });

        //        //modalInstance.result.then(function (selectedItem) {
        //        //    $scope.selected = selectedItem;
        //        //}, function () {
        //        //    $log.info('Modal dismissed at: ' + new Date());
        //        //});

        //        $scope.loading = false;
        //    }
        //    ).error(function (data, status, headers, config) {
        //        $scope.ajaxError = data.MessageDetail;
        //        $scope.showAjaxError = true;
        //        $scope.loading = false;
        //    });
    }
    function getAddresses(caseNum) {
        searchFactory.addrsByCase(caseNum).then(function (results) {
            $scope.addresses = results;
        }, processError);
    };
    function getPrograms(caseNum) {
        searchFactory.programsByCase(caseNum).then(function (results) {
            $scope.programs = results;
        },processError);
    };
    function getCounty(caseNum) {
        searchFactory.countyByCase(caseNum).then(function (results) {
            $scope.county = results;
        }, processError);
    };
    function getReferrals(caseNum) {
        searchFactory.referralsByCase(caseNum).then(function (results) {
            $scope.referrals = results;
        }, processError);
    };
    function getParents(caseNum) {
        searchFactory.parentsByCase(caseNum).then(function (results) {
            $scope.parents = results;
        }, processError);
    };
    //$scope.$on('$viewContentLoaded', function () {
    //    alert('$viewContentLoaded!')
    //this event is fired before the controller is active;
    //});
    $rootScope.$on('loading:progress', function () {
        // show loading gif
        $scope.loading = true;
    });

    $rootScope.$on('loading:finish', function () {
        // hide loading gif
        $scope.loading = false;
        $scope.loaded = true;
    });
    $scope.buildReferralUrl = function (referralId) {
        var returnUrl = '#/referral/' + referralId;
        return returnUrl;
    };
}

// The inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
CaseDetailController.$inject = ['$scope', '$rootScope', '$modal','searchFactory'];