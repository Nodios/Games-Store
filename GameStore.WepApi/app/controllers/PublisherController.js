
app.controller("PublisherController", ['$scope', 'getFactory', function ($scope, getFactory) {

    $scope.publishers = [];
    $scope.support = null;
    $scope.searchString = "";
    $scope.showPublishersTable = false;        // tables are hidden by default
    $scope.showSupportInfoTable = false;        // tables are hidden by default
    $scope.pageNumber = 1;
    var pageSize = 10;

    // Get Publishers
    $scope.get = function () {

        $scope.showPublishersTable = true;      // show publisher table
        $scope.showSupportInfoTable = false;    // hide support table

        // If there is search string get by search string, else get all
        if ($scope.searchString.length > 0) {
            getFactory.getPublisher($scope.searchString).success(function (data) {
                $scope.publishers = [];
                $scope.publishers.push(data);
            }).error(function(){
                $scope.showPublishersTable = false;       // if there is error hide table
            });
        }
        else {
            // Pass page number and page size 
            getFactory.getPublishers($scope.pageNumber, pageSize).success(function (data) {
                $scope.publishers = data;
            }).error(function () {
                $scope.showPublishersTable = false;         // if there is error hide table
            });;
        }
    };

    // Gets support data... item - clicked item, id is FK in db
    $scope.getSupport = function (item, id) {
        // Empty array and add item to it
        $scope.publishers = [];
        $scope.publishers.push(item);
        $scope.showPublishersTable = false;   // hide publishers table
        $scope.showSupportInfoTable = true;   // show support table

        // Get support info related to publisher
        getFactory.getSupport(id).success(function (data) {
            $scope.support = data;
            $scope.showSupportInfoTable = true;
        }).error(function () {
            alert("no info");
            $scope.showSupportInfoTable = false;
        })
    };

}]);