
app.controller("PublisherController",['$scope', 'publisherFactory', function ($scope, publisherFactory) {

    $scope.searchString = "";
    $scope.publishers = [];

    console.log("Kontroler");

    // TODO: 
    $scope.get = function () {
        console.log("Radi");
        if ($scope.searchString.length > 0) {
            publisherFactory.getPublisher($scope.searchString).success(function (data) {
                $scope.publishers = [];
                $scope.publishers.push(data);
                console.log("Jipi");
            });
        }
        else {
           publisherFactory.getPublishers().success(function (data) {
                $scope.publishers = data;
                console.log(data);
                console.log("Whoa");
            });
        }
    };
}]);