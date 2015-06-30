
// Main Module
(function (angular) {



    // Configure routes
    angular.module("mainModule", ['ngRoute', 'ui.bootstrap', 'gamestoreFilters']).config(config);


    function config($routeProvider) {

        $routeProvider
            .when('/', { templateUrl: 'app/navigation/home.html' })
            .when('/publisher', { templateUrl: 'app/publisher/publisher.html', controller: 'PublisherController', controllerAs: 'vm' })
            .when('/game', { templateUrl: 'app/game/game.html', controller: 'GameController', controllerAs: 'vm' })
            .when('/register', { templateUrl: 'app/register/register.html', controller: 'RegisterController', controllerAs: 'vm' })
            .when('/login', { templateUrl: 'app/login/login.html', controller: 'LoginController', controllerAs: 'vm' })
            .when('/account', { templateUrl: 'app/account/account.html', controller: 'AccountController', controllerAs: 'vm' })
            .otherwise({ redirectTo: '/' });
    }

})(angular);