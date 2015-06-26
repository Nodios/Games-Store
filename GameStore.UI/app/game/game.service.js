(function (angular) {

    angular.module("mainModule").service("gameService",
        ['$http', '$window', 'getRouteProvider', 'postRouteProvider',
            function ($http,$window, getRouteProvider, postRouteProvider) {

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

                        var token = $window.sessionStorage.token;

                        return $http({
                            method: 'put',
                            url: postRouteProvider.postPost(),
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: post
                        });
                    }
                };

            }]);

})(angular)