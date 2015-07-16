
(function (angular) {

    angular.module("mainModule").service("orderService", ['routePrefix', '$http', '$window',
    function (routePrefix, $http, $window) {

        return {
            getOrders: function (userId, pageNumber, pageSize) {

                var token = $window.localStorage.token;

                return $http({
                    method: 'get',
                    url: routePrefix.order + "/" + userId + "/" + pageNumber + "/" + pageSize,
                    headers: { 'Authorization': 'Bearer ' + token }
                }); 
            }
        }
    }
    ]);

})(angular);