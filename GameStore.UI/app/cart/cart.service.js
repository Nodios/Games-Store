(function (angular) {

    angular.module("mainModule").service("cartService", ['$http','$window','getRouteProvider', 'putRouteProvider',
    function ($http,$window, getRouteProvider, putRouteProvider) {

        return {

            // gets cart and items
            getCart: function (userId) {
                return $http.get(getRouteProvider.getCart(userId));
            },

            // Update cart
            updateFromCart: function (data) {

                var token = $window.sessionStorage.token;

                return $http({
                    method: 'PUT',
                    url: putRouteProvider.updateFromCart(),
                    headers: { 'Authorization': 'Bearer ' + token },
                    data: data
                })
            }

        }
    }]);

})(angular);