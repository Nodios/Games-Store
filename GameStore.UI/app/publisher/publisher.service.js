(function (angular) {

    angular.module("mainModule").service("publisherService",
        ['$http', 'routePrefix', function ($http, routePrefix) {

        return {

            // Get publisher by name
            getPublishersByName: function (name, pageNumber, pageSize) {
                return $http.get(routePrefix.publisher + "/getByName/" + name + "/" + pageNumber + "/" + pageSize);
            },

            // Get publishers
            getPublishers: function (pageNumber, pageSize) {
                return $http.get(routePrefix.publisher + "/" + pageNumber + "/" + pageSize);
            },

            // Get support
            getSupport: function(publisherId){
                return $http.get(routePrefix.publisher + "/getSupport/" + publisherId);
            }
        }
    }

    ]);

})(angular);