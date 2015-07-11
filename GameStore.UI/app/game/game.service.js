(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'getRouteProvider', 'postRouteProvider', 'putRouteProvider', 'deleteRouteProvider',
            function ($http, $window, getRouteProvider, postRouteProvider, putRouteProvider, deleteRouteProvider) {

                return {

                    //#region GET

                    // Get games collection
                    getGames: function (pageNumber, pageSize) {
                        return $http.get(getRouteProvider.getGames(pageNumber, pageSize));
                    },

                    // Get game
                    getGame: function (id) {
                        return $http.get(getRouteProvider.getGame(id));
                    },

                    // Get game
                    getGameByName: function (name) {
                        return $http.get(getRouteProvider.getGameByName(name));
                    },

                    // Get collection that belongs to publisher
                    getGamesByPublisherId: function (publisherId) {
                        return $http.get(getRouteProvider.getGamesByPublisherId(publisherId));
                    },

                    // Get images that belong to game
                    getImages: function (gameId) {
                        return $http.get(getRouteProvider.getImages(gameId));
                    },

                    // Get ocllection of reviews that belong to game
                    getReviews: function (gameId, pageNumber, pageSize) {
                        return $http.get(getRouteProvider.getReviews(gameId, pageNumber, pageSize));
                    },

                    //#endregion

                    //#region POST

                    postReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: postRouteProvider.postReview(),
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
                            url: putRouteProvider.updateCart(),
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: cart
                        });
                    },

                    putReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: putRouteProvider.updateReview(),
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
                            url: deleteRouteProvider.deleteReview(),
                            headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                            data: review
                        });
                    }

                    //#endregion
                };

            }]);

})(angular)