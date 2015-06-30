
(function (angular) {

    angular.module("mainModule").controller('ModalRegisterController',
        ['$scope', '$modal', '$log', 'authService', function ($scope, $modal, $log, authService) {

            var vm = this;

            vm.registration = {
                userName: null,
                passwordHash: null,
                confirmPassword: null,
                email: null
            };

            // Open modal
            $scope.open = function () {

                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'app/modals/register/register.html',
                    controller: 'OpenRegisterModalCtrl',
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
                });
            };

            // Private functions
            // Used to register user
            var register = function (item) {

                if (item.passwordHash === item.confirmPassword) {

                    authService.saveRegistration(item).success(function (data, status, header, config) {

                    }).error(function (data, status, header, config) {
                        alert(data);
                    });
                }
                else {
                    alert("Please check your password fields.");
                }


            };

        }]);

})(angular);




// Used when modal is created 
(function (angular) {

    angular.module("mainModule").controller("OpenRegisterModalCtrl",
        ['$scope', '$modalInstance', 'injectRegistration',
        function ($scope, $modalInstance, injectRegistration) {


            $scope.registration = injectRegistration;

            // For cancel button
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            // User register
            $scope.registerUser = function (user) {
                $modalInstance.close(user);
            };

        }]);


})(angular);