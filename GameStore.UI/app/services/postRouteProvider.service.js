(function (angular) {

    angular.module('mainModule').service('postRouteProvider', [function () {

        var postUrl = "gameStore/api/post";
        var postUser = "gameStore/api/user/update";

        return {

            // Post single post
            postPost: function () {
                return postUrl + "/insert";
            },  
        };

    }]);

})(angular);