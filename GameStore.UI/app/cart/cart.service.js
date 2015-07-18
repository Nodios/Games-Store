(function (angular) {

    angular.module("mainModule").service("cartService",
        ['$http', '$window','routePrefix',
             function ($http, $window, routePrefix) {

                 return {

                     // gets cart and items
                     getCart: function (userId) {
                         return $http.get(routePrefix.cart + "/" + userId);
                     },

                     getUser: function(username){
                         return $http.get(routePrefix.user + "/" + username);
                     },

                     addOrder: function (order) {

                         var token = $window.localStorage.token;

                         return $http({
                             method: 'post',
                             url: routePrefix.order,
                             headers: { 'Authorization': 'Bearer ' + token },
                             data: order
                         });
                     },

                     deleteGame: function (game) {

                         var token = $window.localStorage.token;

                         return $http({
                             method: 'delete',
                             url: routePrefix.game + "/delete/" + game.Id,
                             headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                         });
                     },

                     deleteMultiple: function (arrayId) {

                         var token = $window.localStorage.token;
                 
                         return $http({
                             method: 'delete',
                             url: routePrefix.game + "/deleteMultiple?",
                             headers: { 'Authorization': 'Bearer ' + token, 'Content-Type':'application/json' },
                             data: arrayId
                         })
                     }
                 }
             }]);

})(angular);