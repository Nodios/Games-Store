app.controller("GameController", ['$scope', 'getFactory', function ($scope, getFactory) {

    // Variables
    $scope.games = [];
    $scope.searchString = "";


    $scope.get = function () {
        // If there is text in search box
        if ($scope.searchString.length > 0) {
            getFactory.getGameByName($scope.searchString).success(function (data) {
                $scope.games = [];                // Empty games collection and add data to id
                $scope.games.push(data);
            });
        }
        else {
            getFactory.getGames().success(function (data) {
                $scope.games = data;
            });
        }
    }
}]);