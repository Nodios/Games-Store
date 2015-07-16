(function (angular) {

    angular.module("mainModule").service("userService",
        ['$http', '$window', 'cns_route_prefix',
            function ($http, $window, cns_route_prefix) {


            return {

                getUserByUsername: function (username) {
                    return $http.get(cns_route_prefix.user + "/" + username);
                },

                // Updates user username or email
                updateUser: function (user, password) {                                  

                    var token = $window.localStorage.token;

                    return $http({
                        method: 'put',
                        url: cns_route_prefix.user + "/UpdateUserOrMail/",
                        headers: { 'Authorization': 'Bearer ' + token },
                        data: {
                            user: user,
                            password: password
                        }
                    });
                },

                updateUserPassword: function (userId, oldPassword, newPassword) {

                    var token = $window.localStorage.token;

                    return $http({
                        method: 'put',
                        url: cns_route_prefix.user + "/updatePassword/",
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