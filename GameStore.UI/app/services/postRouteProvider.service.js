(function (angular) {

    angular.module('mainModule').service('postRouteProvider',
        ['ROUTE_PREFIX',
            function (ROUTE_PREFIX) {

        return {

            // Post single post
            postPost: function () {
                return ROUTE_PREFIX.POST + "/insert";
            },
            
            // Post single review
            postReview: function () {
                return ROUTE_PREFIX.REVIEW;
            }
        };

    }]);

})(angular);