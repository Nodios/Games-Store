(function (angular) {

    angular.module("mainModule").controller("CartController", [
        '$window', 'cartService',
        function ($window, cartService) {

            var vm = this;
            vm.games = "";

            
            cartService.getCart($window.sessionStorage.id).success(function (data) {
                console.log(data);
                vm.games = data.GamesInCart;
            }).error(function (data) {
                console.log(data);
            });

            vm.delete = function (item) {

                // Delete from list
                var cart = {
                    gamesInCart: vm.games,
                    userId: $window.sessionStorage.id
                };

                cart.gamesInCart.pop(item);

                cartService.updateFromCart(cart).success(function (data) {
                    alert(data);
                }).error(function () {
                    alert("Server error");
                });
            }
    }]);

})(angular);