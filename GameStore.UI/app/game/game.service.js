(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'ROUTE_PREFIX' ,
            function ($http, $window, ROUTE_PREFIX) {

                return {

                    //#region GET

                    // Get games collection
                    getGames: function (pageNumber, pageSize) {
                        return $http.get(ROUTE_PREFIX.GAME + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get game
                    getGame: function (id) {
                        return $http.get(ROUTE_PREFIX.GAME + "/getById/" + id);
                    },

                    // Get game
                    getGameByName: function (name) {
                        return $http.get(ROUTE_PREFIX.GAME + "/getByName/" + name);
                    },

                    // Get collection that belongs to publisher
                    getGamesByPublisherId: function (publisherId) {
                        return $http.get(ROUTE_PREFIX.GAME  + "/getRangeFromPublisherId/" + publisherId);
                    },

                    // Get images that belong to game
                    getImages: function (gameId) {
                        return $http.get(ROUTE_PREFIX.GAME_IMAGE + "/" + gameId);
                    },

                    // Get ocllection of reviews that belong to game
                    getReviews: function (gameId, pageNumber, pageSize) {
                        return $http.get(ROUTE_PREFIX.REVIEW + "/" + gameId + "/" + pageNumber + "/" + pageSize);
                    },

                    //#endregion

                    //#region POST

                    postReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: ROUTE_PREFIX.REVIEW,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: review
                        });
                    },

                    //#endregion

                    //#region PUT

                    putCart: function (cart) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: ROUTE_PREFIX.CART,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: cart
                        });
                    },

                    putReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: ROUTE_PREFIX.REVIEW,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: review
                        });
                    },

                    //#endregion

                    //#region DELETE

                    deleteReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'delete',
                            url: ROUTE_PREFIX.REVIEW,
                            headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                            data: review
                        });
                    }

                    //#endregion
                };

            }]);

})(angular)