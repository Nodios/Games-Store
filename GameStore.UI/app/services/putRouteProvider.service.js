(function (angular) {

    angular.module("mainModule").service("putRouteProvider", [function () {
        var postUser = "gameStore/api/user";
        var postCart = "gameStore/api/cart";

        return {
            // used for updating mail or username
            updateUser: function () {
                return postUser + "/UpdateUserOrMail";
            },
            updateUserPassword: function () {
                return postUser + "/UpdatePassword";
            },
            updateCart: function () {
                return postCart + "/Update";
            },
            updateFromCart: function () {
                return postCart + "/UpdateFromCart";
            }

        }
    }]);
})(angular);