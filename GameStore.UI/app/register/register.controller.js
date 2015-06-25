(function (angular) {

    angular.module("mainModule").controller('RegisterController',
        ['$scope', 'authService', function ($scope, authService) {

            var vm = this;
        
            $scope.registration =
                {
                   userName: null,
                    email: null,
                    password: null,
                    confirmPassword: null
                };

            vm.register = function (item) {
                console.log(item);
                authService.saveRegistration(item).success(function (data) {

                    // Success
                    console.log("Jipi");

                }).error(function (data) {
                    console.log("error " + String(data));
                });


            };

        }]);

})(angular)