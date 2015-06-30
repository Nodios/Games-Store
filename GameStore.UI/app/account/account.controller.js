(function (angular) {

    angular.module("mainModule").controller("AccountController", [
        '$scope','$window', 'userService',
        function ($scope, $window, userService) {

            var vm = this;
            vm.showUserChangeTab = false;

            // Crate user and add data to it
            $scope.user;
            userService.getUserByUsername($window.sessionStorage.user).success(function (data) {
                $scope.user = data;
                $scope.user.PasswordHash = "";
                console.log(data);
            });


            // Change username click
            vm.changeUsername = function () {
                vm.showUserChangeTab = true;
            };

            // Confirm username change
            vm.confirmNewUsername = function (userData) {

                console.log(userData);

                userService.updateUser(userData).success(function (data) {
                    console.log(data);
                    alert(data);
                }).error(function (data) {
                    console.log(data);
                    alert(data);
                });
            };
    }]);

})(angular);