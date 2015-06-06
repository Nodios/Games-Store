
var app = angular.module("mainModule", ['ngRoute']);

// Configure routes
app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {templateUrl: 'app/views/home.html'})
        .when('/publisher', { templateUrl: 'app/views/publisher.html', controller: 'PublisherController' })
        .when('/game', { templateUrl: 'app/views/game.html', controller: 'GameController'})
        .otherwise({ redirectTo: '/' });

});