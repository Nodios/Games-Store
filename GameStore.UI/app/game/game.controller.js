
(function (angular) {

    angular.module("mainModule").controller("GameController", ['$scope', '$routeParams', '$window', 'gameService',
        function ($scope, $routeParams, $window, gameService) {

            var vm = this;

            // Variables
            var pageSize = 5;
            vm.pageNumber = 1;

            vm.games = [];              //for collection of games
            vm.game = null;             //for single game
            vm.reviews = [];            // For showing all reviews
            vm.review = {};             //For adding review
            vm.gameImages;

            vm.searchString = "";
            vm.showGamesTable = false;
            vm.gameDetails = false;
            vm.addReview = false;
            var reviewPage = 1;             // User for reviews when watching game details

            // If there is paramater publisherId within route, used when navigated from other menus 
            if ($routeParams.publisherId != null) {
                gameService.getGamesByPublisherId($routeParams.publisherId).success(function (data) {
                    vm.showGamesTable = true;
                    vm.games = data;

                    // Sends data upwards to parent controller, navigation controller that is
                    $scope.$emit('setGameLinkToActive', 'active');
                }).error(function (data) {
                    console.log(data);
                });
            };

            // Search by name, if there is no name get every game
            vm.get = function () {

                vm.showGamesTable = true;
                vm.gameDetails = false;

                // If there is text in search box
                if (vm.searchString.length > 0) {
                    gameService.getGameByName(vm.searchString).success(function (data) {
                        vm.games = [];                                                      //empty array
                        vm.games = data;
                    });
                }
                else {
                    gameService.getGames(vm.pageNumber, pageSize).success(function (data) {
                        vm.games = [];                                                    // emtpy array
                        vm.games = data;
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
                vm.gameDetails = true;          // show details table     

                // Get images for detail
                gameService.getImages(vm.game.Id).success(function (data) {
                    vm.gameImages = data;
                });

                // Get game reviews
                gameService.getReviews(vm.game.Id, 1, 2).success(function (data) {
                    vm.reviews = [];
                    vm.reviews = data;
                });
            };

            // Next review click
            vm.Next = function () {

                reviewPage++;

                // Get game reviews
                gameService.getReviews(vm.game.Id, reviewPage, 2).success(function (data) {
                    vm.reviews = data;

                    if (vm.reviews.length === 0) {
                        reviewPage = 1;
                        vm.Previous();
                    }
                });
            }

            // Previews review click
            vm.Previous = function () {

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

                review.gameId = vm.game.GameId;

                // Checks if there is token... User is logged in if there is token
                if ($window.sessionStorage.token.length > 0) {
                    gameService.postReview(review).success(function (data) {
                        
                        // add to reviews
                        vm.reviews.push(data);
                    }).error(function (data) {
                        alert("Server error");
                    });
                } else {
                    alert("Please log in to add review.");
                }
            };

            // Add game to car
            vm.addToCart = function () {

                console.log(vm.game);
                if ($window.sessionStorage.token.length > 0) {
                    var cart = {
                        userId: $window.sessionStorage.id,
                        gamesInCart: []
                    };
                    cart.gamesInCart.push(vm.game);

                    gameService.putCart(cart).success(function () {
                        alert("Added to cart");
                    }).error(function (data) {
                        console.log(data);
                    });
                }
                else {
                    alert("Please log in");
                }
            }

            // Next items in games list
            vm.nextInGamesList = function () {
                vm.pageNumber++;

                gameService.getGames(vm.pageNumber, pageSize).success(function (data) {
                    vm.games = [];                                                    // emtpy array

                    if (data.length > 0)
                        vm.games = data;
                    else
                        vm.pageNumber--;
                  
                });
            };

            // previous items in games list
            vm.previousInGamesList = function () {

                vm.pageNumber--;
                if (vm.pageNumber < 1)
                    vm.pageNumber = 1;

                gameService.getGames(vm.pageNumber, pageSize).success(function (data) {
                    vm.games = [];                                                    // emtpy array
                    vm.games = data;
                });
            };
        }
    ])
})(angular);
