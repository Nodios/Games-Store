(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'routePrefix' ,
            function ($http, $window, routePrefix) {

                return {

                    //#region GET

                    // Get games collection
                    getGames: function (pageNumber, pageSize) {
                        return $http.get(routePrefix.game + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get game
                    getGame: function (id) {
                        return $http.get(routePrefix.game + "/getById/" + id);
                    },

                    // Get game
                    getGameByName: function (name, pageNumber, pageSize) {
                        return $http.get(routePrefix.game + "/getByName/" + name + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get collection that belongs to publisher
                    getGamesByPublisherId: function (publisherId, pageNumber, pageSize) {
                        return $http.get(routePrefix.game  + "/getRangeFromPublisherId/" + publisherId + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get images that belong to game
                    getImages: function (gameId, pageNumber, pageSize) {
                        return $http.get(routePrefix.game_image + "/" + gameId + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get ocllection of reviews that belong to game
                    getReviews: function (gameId, pageNumber, pageSize) {
                        return $http.get(routePrefix.review + "/" + gameId + "/" + pageNumber + "/" + pageSize);
                    },

                    //#endregion

                    //#region POST

                    postReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.review,
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
                            url: routePrefix.cart,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: cart
                        });
                    },

                    putReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: routePrefix.review + "/" + review.Id,
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
                            url: routePrefix.review,
                            headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                            data: review
                        });
                    }

                    //#endregion
                };

            }]);

})(angular)