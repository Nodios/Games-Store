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

                 //#endregion

                 //#region Methods

                 // Get items in cart
                 cartService.getCart($window.localStorage.id).success(function (data) {
                     vm.games = data.GamesInCart;

                     if (vm.games.length > 0) {

                         vm.showTablesIfThereAreGames = true;
                         totalSum();
                     } else {
                         vm.showIfThereAreNoGames = true;
                     }
                 });

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

                 //#endregion

                 //#region Private methods

                 // Price of all games
                 function totalSum() {
                     var sum = 0;
                     for (var i = 0; i < vm.games.length; i++) {

                         sum += vm.games[i].Price;
                     }
                     $scope.total = sum;
                 }

                 //#endregion
             }]);

})(angular);