(function (angular) {

    angular.module("mainModule").controller("OrderController",
        ['orderService', '$window','$scope', 'notificationService',
         function (orderService, $window, $scope,notificationService) {

             var vm = $scope.vm = this;

             //#region Proporites

             vm.orders = "";

             //#endregion


             //#region Methods

             vm.getOrder = function () {

                 orderService.getOrders($window.localStorage.id).success(function (data) {
                     vm.orders = data;
                 }).error(function () {
                     notificationService.addNotification("Couldn't find any orders.", false);
                 });
             };

             //#endregion

             //#region To do after navigated to controller

             vm.getOrder();

             //#endregion
        }
    ]);

})(angular);