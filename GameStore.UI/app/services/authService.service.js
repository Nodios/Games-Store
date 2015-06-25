(function (angular) {

    angular.module("mainModule").service('authService',
        ['$http', function ($http) {

            var baseUrl = "gameStore/api/user";
            var authentification = {
                isAuth: false,
                username: ""
            };

            return {

                logOut: function () {

                },

                saveRegistration: function (registration) {
                    //logOut();
                    console.log($.param(registration));

                    return $http({
                        method: 'post',
                        url: baseUrl + "/register",
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                        data : $.param(registration)              // $.param()   is from jQuery library 
                    })

                }
            };

        }]);

})(angular)