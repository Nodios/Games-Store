(function (angular) {

    angular.module("mainModule").service("topicService",
        ['$http', 'routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {

                    getPostsByTopicId: function (topicId, pageNumber, pageSize) {
                        return $http.get(routePrefix.post + "/" + topicId + "/" + pageNumber + "/" + pageSize);
                    },

                    getCommentsByPostId: function (postId, pageNumber, pageSize) {
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
                    },

                    editPost: function (postId, post) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: routePrefix.post + "/update/" + postId,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: post
                        });
                    },

                    editComment: function (commentId, comment) {
                        var token = $window.localStorage.token;

                        return $http({
                            method: 'put',
                            url: routePrefix.comment + "/update/" + commentId,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: comment
                        });
                    },

                    deletePost: function (id) {

                        var token = $window.localStorage.token;

                        return $http.delete(routePrefix.post + "/delete/" + id,
                            {
                                headers: { 'Authorization': 'Bearer ' + token }
                            });
                    },

                    deleteComment: function (id) {

                        var token = $window.localStorage.token;

                        return $http.delete(routePrefix.comment + "/delete/" + id,
                            {
                                headers: { 'Authorization': 'Bearer ' + token }
                            });
                    }
                }
            }
        ]);
})(angular);