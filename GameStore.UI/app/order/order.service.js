
(function (angular) {

    angular.module("mainModule").service("orderService", ['cns_route_prefix', '$http', '$window',
    function (cns_route_prefix, $http, $window) {

        return {
            getOrders: function (userId) {

                var token = $window.localStorage.token;

                return $http({
                    method: 'get',
                    url: cns_route_prefix.order + "/" + userId,
                    headers: { 'Authorization': 'Bearer ' + token }
                }); 
            }
        }
    }
    ]);

})(angular);