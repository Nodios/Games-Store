(function (angular) {

    angular.module("mainModule").service("topicService",
        ['$http','routePrefix', '$window',
            function ($http,routePrefix, $window) {

                return {

                    getPostsByTopicId: function (topicId, pageNumber, pageSize) {
                        return  $http.get(routePrefix.post + "/" + topicId + "/" + pageNumber + "/" + pageSize);
                    },

                    getCommentsByPostId: function(postId, pageNumber, pageSize){
                        return $http.get(routePrefix.comment + "/" + postId + "/" + pageNumber + "/" + pageSize)
                    },

                    addNewPost: function (post) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.post + "/insert",
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: post
                        });
                    },

                    addNewComment: function (comment) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.comment + "/insert",
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: comment
                        })
                    }
                }
            }
        ]);
})(angular);