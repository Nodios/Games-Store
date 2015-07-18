(function (angular) {

    angular.module("mainModule").service("topicService",
        ['$http','routePrefix', '$window',
            function ($http,routePrefix, $window) {

                return {

                    getPostsById: function (id, pageNumber, pageSize) {
                       return  $http.get(routePrefix.post + "/" + id + "/" + pageNumber + "/" + pageSize);
                    },

                    addNewPost: function (post) {

                        console.log(post);
                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.post + "/insert",
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: post
                        });
                    }
                }
            }
        ]);
})(angular);