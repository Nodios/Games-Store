(function (angular) {

    angular.module("mainModule").service("publisherService", ['$http', 'getRouteProvider', function ($http, getRouteProvider) {

        return {

            // Get publisher by name
            getPublishersByName: function (name) {
                return $http.get(getRouteProvider.getPublishersByName(name));
            },

            // Get publishers
            getPublishers: function (pageNumber, pageSize) {
                return $http.get(getRouteProvider.getPublishers(pageNumber, pageSize));
            },

            // Get support
            getSupport: function(publisherId){
                return $http.get(getRouteProvider.getSupport(publisherId));
            }
        }
    }

    ]);

})(angular);