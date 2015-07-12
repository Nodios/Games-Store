(function (angular) {

    angular.module("mainModule").service("putRouteProvider",
        ['ROUTE_PREFIX'
        , function (ROUTE_PREFIX) {

        return {
            // used for updating mail or username
            updateUser: function () {
                return ROUTE_PREFIX.USER + "/UpdateUserOrMail";
            },
            updateUserPassword: function () {
                return ROUTE_PREFIX.USER + "/UpdatePassword";
            },
            updateCart: function () {
                return ROUTE_PREFIX.CART + "/Update";
            },
            updateFromCart: function () {
                return ROUTE_PREFIX.CART + "/UpdateFromCart";
            },
            updateReview: function () {
                return ROUTE_PREFIX.REVIEW + "/Update";
            }

        }
    }]);
})(angular);