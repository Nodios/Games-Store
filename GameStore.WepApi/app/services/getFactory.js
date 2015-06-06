app.factory("getFactory", ['$http', function ($http) {

    // Urls 
    var urlPublisher = "/api/publisher";
    var urlGame = "/api/game"
    var dataFactory = {};

    // GET publisher collection
    dataFactory.getPublishers = function () {
        return $http.get(urlPublisher);
    }

    // GET publisher by name
    dataFactory.getPublisher = function (name) {
        return $http.get(urlPublisher + "/getbyname/0/" + name);
    }

    // GET support by id
    dataFactory.getSupport = function (id) {
        return $http.get(urlPublisher + "/getsupport/" + id);
    }

    // GET collection of all games
    dataFactory.getGames = function () {
        return $http.get(urlGame);
    }

    // GET game by id
    dataFactory.getGame = function (id) {
        return $http.get(urlGame + "/" + id);
    }

    // GET game by name search
    dataFactory.getGameByName = function (name) {
        return $http.get(urlGame + "/getByName/0/" + name);
    }

    // GET games by publisherId search  - collection of games
    dataFactory.getGamesByPublisherId = function (id) {
        return $http.get(urlGame + /getRangeFromPublisherId/ + id);
    }

    return dataFactory;

}]);