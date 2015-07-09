(function (angular) {

    angular.module("mainModule").controller("CartController", [
        '$scope','$window', '$route', 'cartService',
        function ($scope, $window, $route, cartService) {

            var vm = this;
            vm.games = "";
            $scope.total = 0;
            vm.showTablesIfThereAreGames = false;
            vm.showIfThereAreNoGames = false;

            // Get items in cart
            cartService.getCart($window.sessionStorage.id).success(function (data) {
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
                    
                    if (data === 1)
                        $route.reload();

                }).error(function (data) {                   
                    alert(data);
                });
            }

            // Price of all games
            function totalSum () {
                var sum = 0;
                for (var i = 0; i < vm.games.length; i++) {

                    sum += vm.games[i].Price;
                }
                $scope.total = sum;
            }
    }]);

})(angular);