(function (angular) {

    angular.module("mainModule").service("putRouteProvider", [function () {
        var putUser = "gameStore/api/user";
        var putCart = "gameStore/api/cart";
        var putReview = "gameStore/api/review";

        return {
            // used for updating mail or username
            updateUser: function () {
                return putUser + "/UpdateUserOrMail";
            },
            updateUserPassword: function () {
                return putUser + "/UpdatePassword";
            },
            updateCart: function () {
                return putCart + "/Update";
            },
            updateFromCart: function () {
                return putCart + "/UpdateFromCart";
            },
            updateReview: function () {
                return putReview + "/Update";
            }

        }
    }]);
})(angular);