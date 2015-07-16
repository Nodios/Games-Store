(function (angular) {

    angular.module("mainModule").service("publisherService",
        ['$http', 'cns_route_prefix', function ($http, cns_route_prefix) {

        return {

            // Get publisher by name
            getPublishersByName: function (name) {
                return $http.get(cns_route_prefix.publisher + "/getByName/" + name);
            },

            // Get publishers
            getPublishers: function (pageNumber, pageSize) {
                return $http.get(cns_route_prefix.publisher + "/" + pageNumber + "/" + pageSize);
            },

            // Get support
            getSupport: function(publisherId){
                return $http.get(cns_route_prefix.publisher + "/getSupport/" + publisherId);
            }
        }
    }

    ]);

})(angular);