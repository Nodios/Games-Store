
// Main Module
(function (angular) {

    angular.module("mainModule", ['ngRoute']);

    // Configure routes
    angular.module("mainModule", ['ngRoute']).config(config);

    angular.module("mainModule").value("userName", "");


    function config($routeProvider) {

        $routeProvider
            .when('/', { templateUrl: 'app/navigation/home.html' })
            .when('/publisher', { templateUrl: 'app/publisher/publisher.html', controller: 'PublisherController', controllerAs: 'vm' })
            .when('/game', { templateUrl: 'app/game/game.html', controller: 'GameController', controllerAs: 'vm' })
            .when('/register', { templateUrl: 'app/register/register.html', controller: 'RegisterController', controllerAs: 'vm' })
            .when('/login', { templateUrl: 'app/login/login.html', controller: 'LoginController', controllerAs: 'vm'})
            .otherwise({ redirectTo: '/' });
    }
})(angular);