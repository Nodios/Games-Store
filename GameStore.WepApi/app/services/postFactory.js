app.factory("postFactory", ['$http', function ($http) {
    var postUrl = "api/post";
    var dataFactory = {};

    // POST - posts post item o.O
    dataFactory.postPost = function (post) {
        return $http.post(postUrl + "/" + post);
    }

    return dataFactory;
}]);