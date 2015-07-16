(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'cns_route_prefix' ,
            function ($http, $window, cns_route_prefix) {

                return {

                    //#region GET

                    // Get games collection
                    getGames: function (pageNumber, pageSize) {
                        return $http.get(cns_route_prefix.game + "/" + pageNumber + "/" + pageSize);
                    },

                    // Get game
                    getGame: function (id) {
                        return $http.get(cns_route_prefix.game + "/getById/" + id);
                    },

                    // Get game
                    getGameByName: function (name) {
                        return $http.get(cns_route_prefix.game + "/getByName/" + name);
                    },

                    // Get collection that belongs to publisher
                    getGamesByPublisherId: function (publisherId) {
                        return $http.get(cns_route_prefix.game  + "/getRangeFromPublisherId/" + publisherId);
                    },

                    // Get images that belong to game
                    getImages: function (gameId) {
                        return $http.get(cns_route_prefix.game_image + "/" + gameId);
                    },

                    // Get ocllection of reviews that belong to game
                    getReviews: function (gameId, pageNumber, pageSize) {
                        return $http.get(cns_route_prefix.review + "/" + gameId + "/" + pageNumber + "/" + pageSize);
                    },

                    //#endregion

                    //#region POST

                    postReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: cns_route_prefix.review,
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
                            url: cns_route_prefix.cart,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: cart
                        });
                    },

                    putReview: function (review) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: cns_route_prefix.review,
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
                            url: cns_route_prefix.review,
                            headers: { 'Authorization': 'Bearer ' + token, 'Content-Type': 'application/json' },
                            data: review
                        });
                    }

                    //#endregion
                };

            }]);

})(angular)