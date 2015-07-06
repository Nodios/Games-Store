(function (angular) {
    
    angular.module("mainModule").service('getRouteProvider', [function () {

        var apiPublisher = "gameStore/api/publisher";
        var apiGame = "gameStore/api/game"
        var apiPost = "gameStore/api/post"
        var apiUser = "gameStore/api/user";
        var apiGameImage = "gameStore/api/gameImage";
        var apiReview = "gamestore/api/review";
        var apiCart = "gamestore/api/cart";

        return {

            // Collection
            getPublishers: function (pageNumber, pageSize) {
                return apiPublisher + "/" + pageNumber + "/" + pageSize;
            },

            // Single
            getPublishersByName: function (name) {
                return apiPublisher + "/getbyname/" + name;
            },

            // Single
            getSupport: function(publisherId){
                return apiPublisher + "/getsupport/" + publisherId;
            },

            // Collection
            getGames: function (pageNumber,pageSize) {
                return apiGame + "/" + pageNumber + "/" + pageSize;
            },

            // GetGameByid
            getGame: function (id) {
                return apiGame + "/gamebyid/" + id;
            },

            // Single
            getGameByName: function (name) {
                return apiGame + "/getByName/" + name;
            },

            // Collection
            getGamesByPublisherId: function (publisherId) {
                return apiGame + /getRangeFromPublisherId/ + publisherId;
            },

            // Collection
            getPosts: function (gameId, pageNumber, pageSize) {
                return apiPost + "/" + gameId + "/" + pageNumber + "/" + pageSize;
            }
            ,

            // Single
            getUserByUsername: function (username) {
                return apiUser + "/" + username;
            },

            // Collection
            getImages: function (gameId) {
                return apiGameImage + "/" + gameId;
            },

            // Collection
            getReviews: function (gameId, pageNumber, pageSize) {
                return apiReview + "/" + gameId + "/" + pageNumber + "/" + pageSize;
            },

            // Get cart
            getCart: function (userId) {
                return apiCart + "/" + userId;
            }
            
        }

    }]);

})(angular);