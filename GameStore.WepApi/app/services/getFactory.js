
angular.module("mainModule").factory('getFactory', getFactory);

getFactory.$inject = ['$http'];

function getFactory ($http) {

    // Urls 
    var urlPublisher = "/api/publisher";
    var urlGame = "/api/game"
    var urlPost = "/api/post"
    var dataFactory = {};

    // GET publisher collection
    dataFactory.getPublishers = function (pageNumber, pageSize) {
        return $http.get(urlPublisher + "/" + pageNumber + "/" + pageSize);
    }

    // GET publisher by name
    dataFactory.getPublisher = function (name) {
        return $http.get(urlPublisher + "/getbyname/" + name);
    }

    // GET support by id
    dataFactory.getSupport = function (id) {
        return $http.get(urlPublisher + "/getsupport/" + id);
    }

    // GET collection of all games
    dataFactory.getGames = function (pageNumber, pageSize) {
        return $http.get(urlGame + "/" + pageNumber + "/" + pageSize);
    }

    // GET game by id
    dataFactory.getGame = function (id) {
        return $http.get(urlGame + "/" + id);
    }

    // GET game by name search
    dataFactory.getGameByName = function (name) {
        return $http.get(urlGame + "/getByName/" + name);
    }

    // GET games by publisherId search  - collection of games
    dataFactory.getGamesByPublisherId = function (id) {
        return $http.get(urlGame + /getRangeFromPublisherId/ + id);
    }

    // GET post by gameId, pageNumber, pageSize - return colletion of posts
    dataFactory.getPosts = function (gameId, pageNumber, pageSize) {
        return $http.get(urlPost + "/" + gameId + "/" + pageNumber + "/" + pageSize);
    }

    return dataFactory;

}