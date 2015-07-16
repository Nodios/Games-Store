(function (angular) {

    angular.module("mainModule").controller("OrderController",
        ['orderService', '$window', 'notificationService',
         function (orderService, $window,notificationService) {

             var vm = $scope.vm = this;

             //#region Proporites


             //#endregion


             //#region Methods

             vm.getOrder = function () {

                 orderService.getOrder($window.localStorage.user).success(function (data) {

                 }).error(function () {
                     notificationService.addNotification("Couldn't find any orders.", false);
                 });
             };

             //#endregion

             //#region To do after navigated to controller

             //#endregion
        }
    ]);

})(angular);