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

            // Submit 
            vm.register = function (item) {

                if (item.password === item.confirmPassword) {
                    authService.saveRegistration(item).success(function (data) {

                    }).error(function (data) {
                        console.log("error " + String(data));
                    });
                }
                else {
                    alert("Please check your password fields.");
                }


            };

        }]);

})(angular)