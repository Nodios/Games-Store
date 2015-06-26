(function (angular) {


    angular.module("mainModule").controller("LoginController",
        ['$scope', '$window', 'authService', 'userName', function ($scope, $window, authService, userName) {

            var vm = this;
         
            vm.login = true;
            vm.logout = false;

            $scope.user = {
                password: null,
                userName: null
            };


            vm.login = function (item) {

                authService.login(item).success(function (response) {

                    // Success

                    // save token and user to session storage
                    $window.sessionStorage.token = response.access_token;
                    $window.sessionStorage.user = item.userName;

                    vm.login = false;
                    vm.logout = true;

                }).error(function (err, status) {

                    // Error 
                    console.log("error");
                });
            };
            
        }]);

})(angular);