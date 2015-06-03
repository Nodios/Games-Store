
app.controller("PublisherController", function ($scope, $http) {

    console.log("ALLLO");
    $scope.publishers = [];

    // TODO: Premjesti kasnije u factory ili servis 
    $scope.get = function () {
        $http.get('/api/publisher').success(function (data, status, headers, config) {
            $scope.publishers = data;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("Ne radi :P");                         //TODO PREPRAVI KASNIJE 
        });
    };
});