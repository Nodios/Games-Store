
// Main Module
(function (angular) {



    // Configure routes
    angular.module("mainModule", ['ngRoute', 'ui.bootstrap', 'gamestoreFilters']).config(config);


    function config($routeProvider) {

        $routeProvider
            .when('/', { templateUrl: 'app/home/home.html', controller: 'HomeController', controllerAs: 'vm'})
            .when('/publisher', { templateUrl: 'app/publisher/publisher.html', controller: 'PublisherController', controllerAs: 'vm' })
            .when('/game', { templateUrl: 'app/game/game.html', controller: 'GameController', controllerAs: 'vm' })
            .when('/game/:publisherId', { templateUrl: 'app/game/game.html', controller: 'GameController', controllerAs: 'vm'})
            .when('/account', { templateUrl: 'app/account/account.html', controller: 'AccountController', controllerAs: 'vm' })
            .when('/cart', { templateUrl: 'app/cart/cart.html', controller: 'CartController', controllerAs: 'vm' })
            .when('/order', { templateUrl: 'app/order/order.html', controller: 'OrderController', controllerAs: 'vm'})
            .otherwise({ redirectTo: '/' });
    }

})(angular);