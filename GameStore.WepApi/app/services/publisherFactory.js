app.factory("publisherFactory", ['$http', function ($http) {

    // Main url
    var urlBase = "/api/publisher";
    var dataFactory = {};

    // GET publisher collection
    dataFactory.getPublishers = function () {
        return $http.get(urlBase); 
    }

    // GET publisher by name
    dataFactory.getPublisher = function (name) {
        return $http.get(urlBase + "/getbyname/0/" + name);
    }

    // GET support by id
    dataFactory.getSupport = function (id) {
        return $http.get(urlBase + "/" + id);
    }

    return dataFactory;

}]);