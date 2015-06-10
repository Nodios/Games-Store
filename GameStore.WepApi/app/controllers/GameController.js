﻿app.controller("GameController",
    ['$scope', 'getFactory', 'postFactory', function ($scope, getFactory, postFactory) {

        // Variables
        var pageSize = 10;
        $scope.pageNumber = 1;
        $scope.games = [];
        $scope.post = { GameId: 0, Title: null, Description: null };
        $scope.posts = [];
        $scope.searchString = "";
        $scope.showGamesTable = false;
        $scope.gameDetails = false;


        // Search by name, if there is no name get every game
        $scope.get = function () {

            $scope.showGamesTable = true;

            // If there is text in search box
            if ($scope.searchString.length > 0) {
                getFactory.getGameByName($scope.searchString).success(function (data) {
                    $scope.games = [];                // Empty games collection and add data to id
                    $scope.games.push(data);
                });
            }
            else {
                getFactory.getGames($scope.pageNumber, pageSize).success(function (data) {
                    $scope.games = data;
                });
            }
        }

        // Get details of certain game
        $scope.getItemDetails = function (item) {

            $scope.games = [];                //Empty array
            $scope.games.push(item);            // Add item item to array
            $scope.showGamesTable = false;       // hide game table
            $scope.gameDetails = true;          // show details table     
        }

        // Post        TODO: add logic 
        $scope.postPost = function (post) {
            post.GameId = $scope.posts[0].Id;
            postFactory.postPost(post).success(function (data) {
                console.log("success");
                console.log(post);
            }).error(function () {
                console.log("error");
            });
        }
    }]);