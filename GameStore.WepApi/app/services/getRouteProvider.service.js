(function (angular) {
    
    angular.module("mainModule").service('getRouteProvider', [function () {

        var apiPublisher = "/api/publisher";
        var apiGame = "/api/game"
        var apiPost = "/api/post"

        return {

            // Collection
            getPublishers: function (pageNumber, pageSize) {
                return apiPublisher + "/" + pageNumber + "/" + pageSize;
            },

            // Single
            getPublisher: function (name) {
                return apiPublisher + "/" + name;
            },

            // Single
            getSupport: function(publisherId){
                return apiPublisher + "/getsupport/" + publisherId;
            },

            // Collection
            getGames: function (pageNumber,pageSize) {
                return apiGame + "/" + pageNumber + "/" + pageSize;
            },

            // Game
            getGame: function (id) {
                return apiGame + "/" + id;
            },

            // Single
            getGameByName: function (name) {
                return apiGame + "/getByName/" + name;
            },

            // Collection
            getGamesByPublisherId: function (publisherId) {
                return urlGame + /getRangeFromPublisherId/ + publisherId;
            },

            // Collection
            getPosts: function (gameId, pageNumber, pageSize) {
                return apiPost + "/" + gameId + "/" + pageNumber + "/" + pageSize;
            }

            
        }

    }]);

})(angular);