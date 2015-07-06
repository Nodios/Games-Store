(function (angular) {

    angular.module("mainModule").controller("CartController", [
        '$window', 'cartService',
        function ($window, cartService) {

            var vm = this;
            vm.games = "";

            
            cartService.getCart($window.sessionStorage.id).success(function (data) {
                console.log(data);
                vm.games = data.GamesInCart;
            });
    }]);

})(angular);