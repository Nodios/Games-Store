(function (angular) {

    angular.module("mainModule").service("homeService",
        ['$http', 'routePrefix',
            function ($http, routePrefix) {

                return {

                    getGames: function (pageNumber, pageSize) {
                        return $http.get(routePrefix.game + "/" + pageNumber + "/" + pageSize);
                    },
                }
            }
        ]);

})(angular);