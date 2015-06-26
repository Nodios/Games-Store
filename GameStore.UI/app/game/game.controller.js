
(function (angular) {

    angular.module("mainModule").controller("GameController", ['$window','gameService',
        function ( $window, gameService) {

            var vm = this;

            // Variables
            var pageSize = 10;
            vm.pageNumber = 1;
            vm.games = [];      //for collection of games
            vm.game = null;   //for single game
            vm.post = { GameId: 0, Title: null, Description: null};
            vm.posts = [];
            vm.searchString = "";
            vm.showGamesTable = false;
            vm.gameDetails = false;
            vm.userLogedIn = false;


            // Search by name, if there is no name get every game
            vm.get = function () {

                vm.showGamesTable = true;

                // If there is text in search box
                if (vm.searchString.length > 0) {
                    gameService.getGameByName(vm.searchString).success(function (data) {
                        vm.games = [];
                        vm.games = data;
                    });
                }
                else {
                    gameService.getGames(vm.pageNumber, pageSize).success(function (data) {
                        vm.games = [];
                        vm.games = data;
                    });
                }
            };

            // Get details of certain game
            vm.getItemDetails = function (item) {

                vm.games = [];                //Empty array
                vm.game = item;            // Add item item to array
                vm.showGamesTable = false;       // hide game table
                vm.gameDetails = true;          // show details table     

                // Ako user ima token
                if ($window.sessionStorage.token.length > 0)
                    vm.userLogedIn = true;
                else
                    vm.userLogedIn = false;
            };

            // Post        TODO: add logic 
            vm.postPost = function (post) {

                // Add id to post
                post.GameId = vm.game.PublisherId;
                gameService.postPost(post).success(function (response) {

                }).error(function (response) {

                });
            };
        }
    ])
})(angular);
