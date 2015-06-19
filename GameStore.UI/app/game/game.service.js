(function (angular) {

    angular.module("mainModule").service("gameService", 
        ['$http', 'getRouteProvider', 'postRouteProvider',
            function ($http, getRouteProvider, postRouteProvider) {

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

                    // Post
                    postPost: function (post) {
                        return $http.post(postRouteProvider.postPost(post));
                    }
                };

        }]);

})(angular)