
(function (angular) {

    angular.module("mainModule").controller("GameController", ['getFactory', 'postFactory',
        function (getFactory, postFactory) {

            console.log("Load success");
            var vm = this;

            // Variables
            var pageSize = 10;
            vm.pageNumber = 1;
            vm.games = [];
            vm.post = { GameId: 0, Title: null, Description: null };
            vm.posts = [];
            vm.searchString = "";
            vm.showGamesTable = false;
            vm.gameDetails = false;


            // Search by name, if there is no name get every game
            vm.get = function () {

                vm.showGamesTable = true;

                // If there is text in search box
                if (vm.searchString.length > 0) {
                    getFactory.getGameByName(vm.searchString).success(function (data) {
                        vm.games = [];                // Empty games collection and add data to id
                        vm.games.push(data);
                    });
                }
                else {
                    getFactory.getGames(vm.pageNumber, pageSize).success(function (data) {
                        vm.games = data;
                    });
                }
            }

            // Get details of certain game
            vm.getItemDetails = function (item) {

                vm.games = [];                //Empty array
                vm.games.push(item);            // Add item item to array
                vm.showGamesTable = false;       // hide game table
                vm.gameDetails = true;          // show details table     
            }

            // Post        TODO: add logic 
            vm.postPost = function (post) {
                post.GameId = $scope.posts[0].Id;
                postFactory.postPost(post).success(function (data) {
                    console.log("success");
                    console.log(post);
                }).error(function () {
                    console.log("error");
                });
            }
        }
    ])
})(angular);
