
(function (angular) {

    angular.module("mainModule").controller('ModalRegisterController',
        ['$scope', '$modal', '$log', 'authService', function ($scope, $modal, $log, authService) {

            var vm = this;

            vm.registration = {
                userName: null,
                password: null,
                confirmPassword: null,
                email: null
            };

            // Open modal
            $scope.open = function (size) {
                console.log("Open");
                test = false;

                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'app/modals/register/register.html',
                    controller: 'ModalController',
                    windowClass: 'modal-style',
                    backdrop: true,
                    resolve: {
                        injectRegistration: function () {
                            return vm.registration;
                        }
                    }
                });

                // Called after closing modal
                modalInstance.result.then(function (userToRegister) {

                    register(userToRegister);

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            // Private functions
            // Used to register user
            var register = function (item) {

                console.log(toString(item));
                if (item.password === item.confirmPassword) {

                    authService.saveRegistration(item).success(function (data) {

                    }).error(function (data) {
                        alert(data);
                    });
                }
                else {
                    alert("Please check your password fields.");
                }


            };

        }]);

})(angular)
