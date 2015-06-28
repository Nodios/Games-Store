

// Used when modal is created 
(function (angular) {

    angular.module("mainModule").controller("ModalController",
        ['$scope', '$modalInstance', 'injectRegistration', 'injectUserInfo',
        function ($scope, $modalInstance, injectRegistration, injectUserInfo) {

            var vm = this;
            vm.registration = injectRegistration;
            vm.userInfo = injectUserInfo;

            // For cancel button
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            // User register
            $scope.registerUser = function (user) {
                $modalInstance.close(user);
            };

            // User login
            $scope.userLogin = function (user) {
                $modalInstance.close(user);
            };

        }]);


})(angular)