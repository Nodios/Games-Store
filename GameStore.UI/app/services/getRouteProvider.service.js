(function (angular) {
    
    angular.module("mainModule").service('getRouteProvider',
        ['ROUTE_PREFIX',
            function (ROUTE_PREFIX) {

        return {

            // Collection
            getPublishers: function (pageNumber, pageSize) {
                return ROUTE_PREFIX.PUBLISHER + "/" + pageNumber + "/" + pageSize;
            },

            // Single
            getPublishersByName: function (name) {
                return ROUTE_PREFIX.PUBLISHER + "/getbyname/" + name;
            },

            // Single
            getSupport: function(publisherId){
                return ROUTE_PREFIX.PUBLISHER + "/getsupport/" + publisherId;
            },

            // Collection
            getGames: function (pageNumber,pageSize) {
                return ROUTE_PREFIX.GAME + "/" + pageNumber + "/" + pageSize;
            },

            // GetGameByid
            getGame: function (id) {
                return ROUTE_PREFIX.GAME + "/gamebyid/" + id;
            },

            // Single
            getGameByName: function (name) {
                return ROUTE_PREFIX.GAME + "/getByName/" + name;
            },

            // Collection
            getGamesByPublisherId: function (publisherId) {
                return ROUTE_PREFIX.GAME + /getRangeFromPublisherId/ + publisherId;
            },

            // Collection
            getPosts: function (gameId, pageNumber, pageSize) {
                return ROUTE_PREFIX.POST + "/" + gameId + "/" + pageNumber + "/" + pageSize;
            }
            ,

            // Single
            getUserByUsername: function (username) {
                return ROUTE_PREFIX.USER + "/" + username;
            },

            // Collection
            getImages: function (gameId) {
                return ROUTE_PREFIX.GAME_IMAGE + "/" + gameId;
            },

            // Collection
            getReviews: function (gameId, pageNumber, pageSize) {
                return ROUTE_PREFIX.REVIEW + "/" + gameId + "/" + pageNumber + "/" + pageSize;
            },

            // Get cart
            getCart: function (userId) {
                return ROUTE_PREFIX.CART + "/" + userId;
            }
            
        }

    }]);

})(angular);