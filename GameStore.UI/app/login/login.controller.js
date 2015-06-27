(function (angular) {


    angular.module("mainModule").controller("LoginController",
        ['$scope', '$window', 'authService',  function ($scope, $window, authService) {

            var vm = this;
         
            $scope.test = "Test woho";

            if ($window.sessionStorage.user.length > 0) {
                vm.login = false;
                vm.logout = true;
            }
            else {
                vm.login = true;
                vm.logout = false;
            }

            vm.user = {
                password: null,
                userName: $window.sessionStorage.user.userName
            };

            // Login click
            vm.loginUser = function (item) {

                console.log(toString(item));
                authService.login(item).success(function (response) {

                    // Success

                    // save token and user to session storage
                    $window.sessionStorage.token = response.access_token;
                    $window.sessionStorage.userName = item.userName;
                    $window.sessionStorage.id = response.id;

                    vm.login = false;
                    vm.logout = true;

                }).error(function (err, status) {

                    // Error 
                    console.log("error");
                });
            };

            // Logout click
            vm.logoutUser = function () {
                $window.sessionStorage.token = "";
                $window.sessionStorage.userName = "";
                $window.sessionStorage.id = "";

                vm.login = true;
               vm.logout = false;
            };
            
        }]);

})(angular);