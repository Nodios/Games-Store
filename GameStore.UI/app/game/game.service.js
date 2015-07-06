(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'getRouteProvider', 'postRouteProvider', 'putRouteProvider',
            function ($http, $window, getRouteProvider, postRouteProvider, putRouteProvider) {

                return {

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

                    // Post
                    postPost: function (post) {

                        var token = $window.sessionStorage.token;

                        return $http({
                            method: 'put',
                            url: postRouteProvider.postPost(),
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: post
                        });
                    },

                    // Post review 
                    postReview: function (review) {

                        var token = $window.sessionStorage.token;

                        return $http({
                            method: 'post',
                            url: postRouteProvider.postReview(),
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: review
                        });
                    },

                    // Update cart
                    putCart: function (cart) {

                        var token = $window.sessionStorage.token;
                        console.log(cart);
                        return $http({
                            method: 'put',
                            url: putRouteProvider.updateCart(),
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: cart
                        });
                    }
                };

            }]);

})(angular)