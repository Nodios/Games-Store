(function (angular) {

    angular.module("mainModule").service("publisherService",
        ['$http', 'ROUTE_PREFIX', function ($http, ROUTE_PREFIX) {

        return {

            // Get publisher by name
            getPublishersByName: function (name) {
                return $http.get(ROUTE_PREFIX.PUBLISHER + "/getByName/" + name);
            },

            // Get publishers
            getPublishers: function (pageNumber, pageSize) {
                return $http.get(ROUTE_PREFIX.PUBLISHER + "/" + pageNumber + "/" + pageSize);
            },

            // Get support
            getSupport: function(publisherId){
                return $http.get(ROUTE_PREFIX.PUBLISHER + "/getSupport/" + publisherId);
            }
        }
    }

    ]);

})(angular);