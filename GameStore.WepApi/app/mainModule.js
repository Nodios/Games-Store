
var app = angular.module("mainModule", ['ngRoute']);

// Configure routes
app.config(function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {templateUrl: 'app/views/home.html'})
        .when('/publisher', { templateUrl: 'app/views/publisher.html', controller: 'PublisherController' })
        .otherwise({ redirectTo: '/' });

});