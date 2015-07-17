(function (angular) {

    angular.module("mainModule").controller("OrderController",
        ['orderService', '$window','$scope', 'notificationService',
         function (orderService, $window, $scope,notificationService) {

             var vm = $scope.vm = {};

             //#region Proporites

             vm.orders = "";
             vm.pageNumber = 1;
             vm.pageSize = 15;

             //#endregion


             //#region Methods

             vm.next = function () {

                 vm.pageNumber++;
                 getOrder();
             };

             vm.back = function () {

                 vm.pageNumber--;

                 if (vm.pageNumber < 1)
                     vm.pageNumber = 1;

                 getOrder();
             }
           
             //#endregion

             //#region Private methods

             function getOrder() {

                 orderService.getOrders($window.localStorage.id, vm.pageNumber, vm.pageSize).success(function (data) {
                     vm.orders = data;
                 }).error(function () {
                     notificationService.addNotification("Couldn't find any orders.", false);
                 });
             };

             //#endregion

             //#region To do after navigated to controller

             getOrder();

             //#endregion
        }
    ]);

})(angular);