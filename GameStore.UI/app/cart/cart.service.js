(function (angular) {

    angular.module("mainModule").service("cartService", ['$http','getRouteProvider',
    function ($http, getRouteProvider) {

        return {

            // gets cart and items
            getCart: function (userId) {
                return $http.get(getRouteProvider.getCart(userId));
            }
        }
    }]);

})(angular);