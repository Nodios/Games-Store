(function (angular) {

    angular.module("mainModule").service("cartService",
        ['$http', '$window','ROUTE_PREFIX',
             function ($http, $window, ROUTE_PREFIX) {

                 return {

                     // gets cart and items
                     getCart: function (userId) {
                         return $http.get(ROUTE_PREFIX.CART + "/" + userId);
                     },

                     getUser: function(username){
                         return $http.get(ROUTE_PREFIX.USER + "/" + username);
                     },

                     addOrder: function (order) {

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
                     },

                     deleteMultiple: function (arrayId) {

                         var token = $window.localStorage.token;
                         var toSend = "";
                         for (var i = 0; i < arrayId.length; i++) {
                             toSend += "&id=" + arrayId[i];
                         };
                         
                         return $http({
                             method: 'delete',
                             url: ROUTE_PREFIX.GAME + "/deleteMultiple?",
                             headers: { 'Authorization': 'Bearer ' + token, 'Content-Type':'application/json' /*'Content-Type': 'application/x-www-form-urlencoded'*/ },
                             data: arrayId
                         })
                     }
                 }
             }]);

})(angular);