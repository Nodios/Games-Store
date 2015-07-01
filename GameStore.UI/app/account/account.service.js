(function (angular) {

    angular.module("mainModule").service("userService", [
        '$http', '$window', 'getRouteProvider', 'putRouteProvider',
        function ($http, $window, getRouteProvider, putRouteProvider) {

            return {
                getUserByUsername: function (username) {
                    return $http.get(getRouteProvider.getUserByUsername(username));
                },

                updateUser: function (user, password) {                                       // update 

                    var token = $window.sessionStorage.token;

                    return $http({
                        method: 'put',
                        url: putRouteProvider.updateUser(user),
                        headers: { 'Authorization': 'Bearer ' + token },
                        data: {
                            user: user,
                            password: password
                        }
                    });
                }
            };
        }]);

})(angular);