(function (angular) {

    angular.module("mainModule").controller("ForumController",
        ['$scope',
            function ($scope) {

                var vm = $scope.vm = {};

                vm.showAddTopic = false;
            }
        ]);

})(angular);