(function (angular) {

    angular.module("mainModule").controller("AccountController", [
        '$scope','$window', 'userService',
        function ($scope, $window, userService) {

            var vm = this;
            vm.tableUserName;
            vm.tableEmail;
            vm.showUserChangeTab = false;

            // Crate user and add data to it
            $scope.user;
            userService.getUserByUsername($window.sessionStorage.user).success(function (data) {
                $scope.user = data;
                $scope.user.PasswordHash = "";
            });


            // Change username click
            vm.changeUsername = function () {
                vm.showUserChangeTab = true;
            };

            // Confirm username change
            vm.confirmNewUsername = function (userData) {

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