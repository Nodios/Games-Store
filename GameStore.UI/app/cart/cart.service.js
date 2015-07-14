(function (angular) {

    angular.module("mainModule").service("cartService",
        ['$http', '$window','ROUTE_PREFIX',
             function ($http, $window, ROUTE_PREFIX) {

                 return {

                     // gets cart and items
                     getCart: function (userId) {
                         return $http.get(ROUTE_PREFIX.CART + "/" + userId);
                     },

                     addOrder: function(order){

                         var token = $window.localStorage.token;

                         return $http({
                             method: 'post',
                             url: ROUTE_PREFIX.ORDER,
                             headers: { 'Authorization': 'Bearer ' + token },
                             data: order
                         });
                     },

                     deleteGame: function (game) {

                         var token = $window.localStorage.token;

                         return $http({
                             method: 'DELETE',
                             url: ROUTE_PREFIX.GAME,
                             headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                             data: game
                         });
                     }

                 }
             }]);

})(angular);