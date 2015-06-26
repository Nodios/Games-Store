(function (angular) {

    angular.module('mainModule').service('postRouteProvider', [function () {

        var postUrl = "gameStore/api/post";

        return {

            // Post single post
            postPost: function () {
                return postUrl + "/insert";
            }
        };

    }]);

})(angular);