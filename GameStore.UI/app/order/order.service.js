
(function (angular) {

    angular.module("mainModule").service("orderService", ['ROUTE_PREFIX', '$http',
    function (ROUTE_PREFIX, $http) {

        return {
            getOrders: function (userId) {
                return $http.get(ROUTE_PREFIX.ORDER + "/" + userId);
            }
        }
    }
    ]);

})(angular);