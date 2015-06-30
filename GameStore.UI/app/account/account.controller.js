(function (angular) {

    angular.module("mainModule").controller("AccountController", [
        '$scope','$window', 'userService',
        function ($scope, $window, userService) {

            var vm = this;
            vm.showUserChangeTab = false;


            $scope.user;
            
            userService.getUserByUsername($window.sessionStorage.user).success(function (data) {
                $scope.user = data;
            });


            // Change username click
            vm.changeUsername = function () {
                vm.showUserChangeTab = true;
            }

            // Confirm username change
            vm.confirmNewUsername = function (user) {
                userService.updateUser(user).success(function (data) {
                    console.log(data);
                    alert(data);
                }).error(function (data) {
                    console.log(data);
                    alert(data);
                });

                
            }
    }]);

})(angular);