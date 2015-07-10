(function (angular) {

    angular.module("mainModule").controller("AccountController",
        ['$scope', '$window', '$route', 'userService',
             function ($scope, $window, $route, userService) {

                 //#region Proporties

                 var vm = $scope.vm = {};

                 // Tables to show
                 vm.showUserChangeTab = false;
                 vm.showEmailChangeTab = false;
                 vm.showPasswordChangeTab = false;

                 // For password changes
                 vm.newPassword = "";
                 vm.confirmNew = "";

                 // Crate user and add data to it
                 vm.user;
                 userService.getUserByUsername($window.localStorage.user).success(function (data) {

                     vm.user = {
                         userData: data,
                         password: ""
                     }
                 });

                 //#endregion

                 //#region Methods

                 // Change username click
                 vm.changeUsername = function () {
                     vm.showUserChangeTab = true;
                     vm.showEmailChangeTab = false;
                     vm.showPasswordChangeTab = false;
                 };

                 // Change mail click
                 vm.changeEmail = function () {
                     vm.showEmailChangeTab = true;
                     vm.showUserChangeTab = false;
                     vm.showPasswordChangeTab = false;
                 };

                 //Change password click
                 vm.changePassword = function () {
                     vm.showPasswordChangeTab = true;
                     vm.showUserChangeTab = false;
                     vm.showEmailChangeTab = false;
                 }

                 // Confirm username change  
                 vm.confirmNewUsernameOrEmail = function (user) {

                     var userToUpload = user.userData;
                     var passToSend = user.password;

                     userService.updateUser(userToUpload, passToSend).success(function (data) {

                         alert("Username:  " + data.UserName + "\n" + "Email: " + data.Email);
                         $window.localStorage.user = data.UserName;
                         $route.reload();               // reload route

                     }).error(function (data) {
                         alert(data);
                     });
                 };

                 // Confirm new pass, userdata and confirm pass
                 vm.confirmNewPassword = function (user, newPassword, confirmPass) {

                     // Data to send
                     var userId = user.userData.Id;
                     var oldPassword = user.password;
                     var newPass = newPassword;

                     // Check if password are same and have required length
                     if (newPass === confirmPass && newPass.length >= 6) {

                         userService.updateUserPassword(userId, oldPassword, newPass).success(function (data) {

                             alert(data);
                             $route.reload();                       //reload route

                         }).error(function (data) {
                             alert(data);
                         });
                     }
                     else {
                         alert("Password length should at least 6 charachters. Make sure that new password and confirm new password fields are same.");
                     }
                 }

                 //#endregion

             }]);

})(angular);