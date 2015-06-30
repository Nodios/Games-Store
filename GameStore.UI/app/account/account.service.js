(function (angular) {

    angular.module("mainModule").service("userService", [
        '$http', '$window', 'getRouteProvider', 'postRouteProvider',
        function ($http, $window, getRouteProvider, postRouteProvider) {

            return {
                getUserByUsername: function (username) {
                    return $http.get(getRouteProvider.getUserByUsername(username));
                },

                updateUser: function (user) {                                       // update 

                    var token = $window.sessionStorage.token;

                    return $http({
                        method: 'post',
                        url: postRouteProvider.updateUser(user),
                        headers: { 'Authorization': 'Bearer ' + token },
                        data: user
                    });
                }
            };
    }]);
    
})(angular);