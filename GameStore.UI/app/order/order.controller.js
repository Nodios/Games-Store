(function (angular) {

    angular.module("mainModule").controller("OrderController",
        ['orderService', '$window', '$scope', 'notificationService', 'navigationMenuService',
            function (orderService, $window, $scope, notificationService, navigationMenuService) {

                var vm = $scope.vm = {};

                //#region Proporites

                vm.orders = "";
                vm.pageNumber = 1;
                vm.pageSize = 15;
                vm.showOrders = false;

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

                vm.findGamesClick = function () {
                    navigationMenuService.setMenuToActive(1);
                };

                //#endregion

                //#region Private methods

                function getOrder() {

                    orderService.getOrders($window.localStorage.id, vm.pageNumber, vm.pageSize).success(function (data) {
                        vm.orders = data;

                        // If there are orders show table
                        if (vm.orders.length > 0)
                            vm.showOrders = true;
                        else
                            vm.showOrders = false;

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