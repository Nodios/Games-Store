(function (angular) {

    angular.module("mainModule").controller("CartController", [
        '$scope', '$window', '$route', 'cartService', 'notificationService',
             function ($scope, $window, $route, cartService, notificationService) {

                 //#region Proporties

                 var vm = $scope.vm = {};
                 vm.games = "";
                 vm.total = 0;
                 vm.showTablesIfThereAreGames = false;
                 vm.showIfThereAreNoGames = false;
                 vm.showOrderForm = false;

                 vm.order = {
                     Name: "",
                     Surname: "",
                     DeliveryAddress: "",
                     ContactEmail: "",
                     Amount: "",
                     UserId: "",
                     Games: null
                 };

                 //#endregion

                 //#region Methods

                 // Get items in cart
                 vm.getCartItems = function () {
                     cartService.getCart($window.localStorage.id).success(function (data) {
                         vm.games = data.GamesInCart;

                         if (vm.games.length > 0) {

                             vm.showTablesIfThereAreGames = true;
                             totalSum();
                         } else {
                             vm.showIfThereAreNoGames = true;
                         }
                     }).error(function (data) {
                         notificationService.addNotification(data, false);
                     });
                 };

                 // Delete item from cart
                 vm.delete = function (item) {

                     console.log(item);

                     cartService.deleteGame(item).success(function (data) {

                         notificationService.addNotification("Game removed from cart.", true);
                         if (data === 1)
                             $route.reload();

                     }).error(function (data) {
                         notificationService.addNotification("Error occurred. Couldn't delete item from cart.", false);
                     });
                 }

                 // Show order form
                 vm.newOrder = function () {
                     vm.showIfThereAreNoGames = false;
                     vm.showTablesIfThereAreGames = false;
                     vm.showOrderForm = true;
                 };

                 // Cancels order
                 vm.cancelOrder = function () {
                     vm.getCartItems();
                     vm.showOrderForm = false;
                 }

                 // Place order
                 vm.addOrder = function (item) {
                     
                     vm.order = item;
                     vm.order.Amount = vm.total;
                     vm.order.UserId = $window.localStorage.id;
                     vm.order.Games = vm.games;

                     cartService.addOrder(vm.order).success(function (data) {
                         notificationService.addNotification("Order placed. Please check e-mail to confirm order.", true);
                     }).error(function (data) {
                         notificationService.addNotification(data, false);
                     });
                 };

                 //#endregion

                 //#region Private methods

                 // Price of all games
                 function totalSum() {
                     var sum = 0;
                     for (var i = 0; i < vm.games.length; i++) {

                         sum += vm.games[i].Price;
                     }
                     vm.total = sum;
                 }

                 //#endregion

                 //#region Initalize when navigated to

                 vm.getCartItems();

                 //#endregion
             }]);

})(angular);