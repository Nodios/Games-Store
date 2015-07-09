(function (angular) {

    angular.module("mainModule").service("cartService", ['$http', '$window', 'getRouteProvider', 'putRouteProvider', 'deleteRouteProvider',
    function ($http, $window, getRouteProvider, putRouteProvider, deleteRouteProvider) {

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
            },

            deleteGame: function (game) {

                var token = $window.sessionStorage.token;

                return $http({
                    method: 'DELETE',
                    url: deleteRouteProvider.deleteGame(),
                    headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json'},
                    data: game
                });
            }

        }
    }]);

})(angular);