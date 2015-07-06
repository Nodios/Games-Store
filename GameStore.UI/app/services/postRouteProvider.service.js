(function (angular) {

    angular.module('mainModule').service('postRouteProvider', [function () {

        var postUrl = "gameStore/api/post";
        var postUser = "gameStore/api/user/update";
        var postReview = "gameStore/api/review";

        return {

            // Post single post
            postPost: function () {
                return postUrl + "/insert";
            },
            
            // Post single review
            postReview: function () {
                return postReview;
            }
        };

    }]);

})(angular);