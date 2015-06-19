(function (angular) {

    angular.module('mainModule').service('postRouteProvider', [function () {

        var postUrl = "gameStore/api/post";

        return {

            // Post single post
            postPost: function (post) {
                return postUrl + "/" + post;
            }
        };

    }]);

})(angular);