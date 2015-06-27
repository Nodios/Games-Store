

// Used when modal is created 
(function (angular) {

    angular.module("mainModule").controller("ModalController", ['$scope', '$modalInstance', 'injectRegistration', function ($scope, $modalInstance, injectRegistration) {
        
        var vm = this;
        vm.registration = injectRegistration;
          

        // For cancel button
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.registerUser = function (user) {
            $modalInstance.close(user);
        }
    }]);


})(angular)