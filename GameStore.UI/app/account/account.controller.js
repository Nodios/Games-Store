(function (angular) {

    angular.module("mainModule").controller("AccountController", [
        '$scope','$window', '$route','userService',
        function ($scope, $window, $route, userService) {

            var vm = this;

            vm.showUserChangeTab = false;
            vm.showEmailChangeTab = false;

            // Crate user and add data to it
            $scope.user;
            userService.getUserByUsername($window.sessionStorage.user).success(function (data) {
                $scope.user = {
                    userData: data,
                    password: ""
                }
            });


            // Change username click
            vm.changeUsername = function () {
                vm.showUserChangeTab = true;
                vm.showEmailChangeTab = false;
            };

            // Change mail click
            vm.changeEmail = function () {
                vm.showEmailChangeTab = true;
                vm.showUserChangeTab = false;
            };

            // Confirm username change  
            vm.confirmNewUsernameOrEmail = function (user) {
                var userToUpload = user.userData;
                var passToSend = user.password;
                userService.updateUser(userToUpload, passToSend).success(function (data) {
                    alert("Username:  " + data.UserName + "\n" + "Email: " + data.Email);
                    $window.sessionStorage.user = data.UserName;
                    $route.reload();
                }).error(function (data) {
                    alert(data);
                });
            };
    }]);

})(angular);