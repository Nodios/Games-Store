(function (angular) {

    angular.module("mainModule").service("userService", [
        '$http', '$window', 'getRouteProvider', 'putRouteProvider',
        function ($http, $window, getRouteProvider, putRouteProvider) {

            return {
                getUserByUsername: function (username) {
                    return $http.get(getRouteProvider.getUserByUsername(username));
                },

                // Updates user username or email
                updateUser: function (user, password) {                                  

                    var token = $window.sessionStorage.token;

                    return $http({
                        method: 'put',
                        url: putRouteProvider.updateUser(),
                        headers: { 'Authorization': 'Bearer ' + token },
                        data: {
                            user: user,
                            password: password
                        }
                    });
                },

                updateUserPassword: function (userId, oldPassword, newPassword) {

                    var token = $window.sessionStorage.token;

                    return $http({
                        method: 'put',
                        url: putRouteProvider.updateUserPassword(),
                        headers: { 'Authorization': 'Bearer ' + token },
                        data: {
                            userId: userId,
                            oldPassword: oldPassword,
                            newPassword: newPassword
                        }
                    })
                }
            };
        }]);

})(angular);