(function (angular) {

    angular.module("mainModule").service("putRouteProvider", [function () {
        var postUser = "gameStore/api/user";

        return {
            updateUser: function (user) {
                return postUser + "/update/" + user;
            }
        }
    }]);
})(angular);