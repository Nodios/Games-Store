﻿
(function (angular) {

    angular.module("mainModule").controller("GameController",
        ['$scope', '$routeParams', '$window', 'gameService', 'notificationService',
           function ($scope, $routeParams, $window, gameService, notificationService) {

               //#region Proporties

               var vm = $scope.vm = {};

               // Variables
               var pageSize = 5;
               var reviewsToShowCount = 2;
               vm.pageNumber = 1;
               vm.rate = 0; // Review score
               vm.overstart = 0;

               vm.games = [];              //for collection of games
               vm.game = null;             //for single game
               vm.reviews = [];            // For showing all reviews
               vm.review = {};             //For adding review
               vm.userId;
               vm.gameImages;
               var searchingByName = false;   

               vm.searchString = "";
               vm.showGamesTable = false;
               vm.showGameDetails = false;
               vm.showAddReview = false;            // show add review form
               vm.showEditReview = false;           // show edit review form
               var reviewPage = 1;             // Used for reviews when watching game details

               //#endregion

               //#region Methods

               // Set review score
               vm.clickRate = function () {
                   vm.overStar = vm.rate;
                   vm.review.Score = vm.rate;
               };

               // Search by name, if there is no name get every game
               vm.get = function () {

                   vm.showGameDetails = false;

                   // If there is text in search box
                   if (vm.searchString.length > 0) {

                       // If previous search was not by name set page number to 1
                       if (searchingByName === false)
                           vm.pageNumber = 1;

                       // Set to true since now it's searching by name
                       searchingByName = true;

                       gameService.getGameByName(vm.searchString, vm.pageNumber, pageSize).success(function (data) {

                           // Show tables if there is data , otherwise notify not found
                           checkForDataAndPageNumber(data)
                           alertIfNotFound();
                       });
                   }
                   else {
                       // If previous search way by name set page number to 1
                       if (searchingByName === true)
                           vm.pageNumber = 1;

                       // Set searchByName to false since it's not searching by name
                       searchingByName = false;

                       gameService.getGames(vm.pageNumber, pageSize).success(function (data) {

                           // Show tables if there is data , otherwise notify not found
                           checkForDataAndPageNumber(data)
                           alertIfNotFound();
                       });
                   }




               };

               // Get details of certain game
               vm.getItemDetails = function (item) {

                   vm.games = [];                //Empty array
                   vm.game = item;            // Add item
                   vm.review = {
                       GameId: item.Id,
                       Title: null,
                       Description: null,
                       Score: null
                   };

                   vm.showGamesTable = false;       // hide game table
                   vm.showGameDetails = true;          // show details table     

                   // Get images for detail
                   gameService.getImages(vm.game.Id, 1,1).success(function (data) {
                       vm.gameImages = data;
                   });

                   // Get game reviews
                   gameService.getReviews(vm.game.Id, 1, 2).success(function (data) {
                       vm.reviews = [];
                       vm.reviews = data;
                   });
               }
               // Next review click
               vm.Next = function () {

                   reviewPage++;

                   // Get game reviews
                   gameService.getReviews(vm.game.Id, reviewPage, 2).success(function (data) {
                       vm.reviews = data;

                       if (vm.reviews.length === 0) {
                           reviewPage = 1;
                           vm.Back();
                       }
                   });
               }

               // Previews review click
               vm.Back = function () {

                   reviewPage--;
                   if (reviewPage < 1)
                       reviewPage = 1;

                   // Get game reviews
                   gameService.getReviews(vm.game.Id, reviewPage, 2).success(function (data) {
                       vm.reviews = data;
                   });

               }

               // Post new review
               vm.postReview = function (review) {

                   review.gameId = vm.game.Id;
                   review.userId = $window.localStorage.id;
                   review.author = $window.localStorage.user;

                   // Checks if there is token... User is logged in if there is token
                   if ($window.localStorage.token.length > 0) {


                       // If title or review are short, show error and return
                       if (vm.review.Title.length < 5 || vm.review.Description.length < 20) {
                           notificationService.addNotification("Title should be at least 5 charachters long. Description should be at least 20 charachters long", false);
                           return;
                       }

                       gameService.postReview(review).success(function (data) {

                           // Pop if it goes above max show list
                           if (vm.reviews.length >= reviewsToShowCount) {

                               // swap so that new review comes to top
                               var temp = vm.reviews[0];
                               vm.reviews[0] = data;
                               vm.reviews[1] = temp;
                           } else {
                               vm.reviews.push(data);
                           }

                           notificationService.addNotification("Review added.", true);
                       }).error(function (data) {
                           notificationService.addNotificationalert("Unable to add new review.",false);
                       });
                   } else {
                       notificationService.addNotification("Please log in.", false);
                   }
               };

               // Add game to car
               vm.addToCart = function () {

                   if ($window.localStorage.token.length > 0) {
                       var cart = {
                           userId: $window.localStorage.id,
                           gamesInCart: []
                       };
                       cart.gamesInCart.push(vm.game);

                       gameService.putCart(cart).success(function () {
                           notificationService.addNotification("Added to cart.", true);
                       }).error(function (data) {
                           notificationService.addNotification("Error occurred. Game is not in cart.", false);
                       });
                   }
                   else {
                       //TODO add tool top or pop up for log in
                   }
               }

               // Next items in games list
               vm.nextInGamesList = function () {
                   vm.pageNumber++;

                   vm.get();
               };

               // previous items in games list
               vm.backInGamesList = function () {

                   vm.pageNumber--;
                   if (vm.pageNumber < 1)
                       vm.pageNumber = 1;

                   vm.get();
               };

               // If delete review is clicked
               vm.deleteReview = function (review) {
                   gameService.deleteReview(review.Id).success(function () {
                       notificationService.addNotification("Review deleted", true);
                       vm.reviews.pop(review);
                       vm.Next();
                   }).error(function () {
                       notificationService.addNotification("Review delete operation failed", false);
                   });
               };

               // edit review click
               vm.editReview = function (review) {
                   if ($window.localStorage.token.length > 0) {

                       // If title or review are short, show error and return
                       if (vm.review.Title.length < 5 || vm.review.Description.length < 20) {
                           notificationService.addNotification("Title should be at least 5 charachters long. Description should be at least 20 charachters long", false);
                           return;
                       }

                       gameService.putReview(review).success(function (data) {

                           notificationService.addNotification("Review edited", true);

                           // Remove old review ,and add new
                           vm.reviews.pop(review);
                           vm.reviews.push(data);
                       }).error(function (data) {
                          
                           notificationService.addNotification("Review edit operation failed.", false);
                       });
                   }
                   else {
                       notificationService.addNotification("Please log in.", false);
                   }
               };

               //#endregion

               //#region Private methods

               // If there are items in vm.games shows table, otherwise alerts not found
               function alertIfNotFound() {
                   if (vm.games.length > 0) {
                       vm.showGamesTable = true;
                   }
                   else {
                       notificationService.addNotification("No games found.", false);
                   }
               };

               // If there is data set vm.games, else decrease page number
               function checkForDataAndPageNumber(data) {

                   if (data.length > 0)
                       vm.games = data;
                   else
                       vm.pageNumber--;
               };

               //#endregion

               //#region To handle on controller creation

               // If there is paramater publisherId within route ... used when navigated from other menus 
               if ($routeParams.publisherId != null) {
                   gameService.getGamesByPublisherId($routeParams.publisherId, vm.pageNumber, 20).success(function (data) {

                       vm.games = data;
                       if (vm.games.length > 0)
                           vm.showGamesTable = true;

                   }).error(function (data) {
                       notificationService.addNotification(data, false);
                   });
               } else {

                   // Default, if not navigated from other place, just search
                   vm.get();
               }

               //#endregion

               //#region Events

               // Watch changes on id, if changed change user id
               $scope.$watch(function () {
                   return $window.localStorage.id;
               }, function (newValue, oldValue) {
                   vm.userId = newValue;
               });

               //#endregion
           }
        ])
})(angular);
