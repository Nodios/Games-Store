
(function (angular) {
    angular.module("mainModule").controller("PublisherController",
        ['$scope','$location', 'publisherService','navigationMenuService',
    function ($scope, $location, publisherService,navigationMenuService) {


        //#region Proporties

        var vm = $scope.vm = {};

        vm.publishers = [];
        vm.publisher = null;
        vm.support = null;
        vm.searchString = "";
        vm.showPublishersTable = false;        // tables are hidden by default
        vm.showSupportInfoTable = false;        // tables are hidden by default
        vm.pageNumber = 1;
        var pageSize = 5;
        var searchingByName = false;

        //#endregion

        //#region Methods

        // Get Publishers
        vm.get = function () {
 
            vm.showSupportInfoTable = false;    // hide support table

            // If there is search string get by search string, else get all
            if (vm.searchString.length > 0) {

                // If prevoious seatch wasn't by name set page number to 1
                if (searchingByName === false)
                    vm.pageNumber = 1;

                // Now searching by name
                searchingByName = true;

                publisherService.getPublishersByName(vm.searchString, vm.pageNumber, pageSize).success(function (data) {
                    vm.publishers = data;

                    // If there is no data
                    if (data.length == 0)
                        vm.pageNumber = 1;

                    vm.showPublishersTable = true;      // show publisher table

                }).error(function () {
                    vm.showPublishersTable = false;       // if there is error hide table
                });
            }
            else {

                // If previous search wasn't by name, set page number to 1
                if (searchingByName === true)
                    vm.pageNumber = 1;

                searchingByName = false;


                // Pass page number and page size 
                publisherService.getPublishers(vm.pageNumber, pageSize).success(function (data) {
                    vm.publishers = data;

                    // if there is no data
                    if (data.length == 0)
                        vm.pageNumber--;

                    vm.showPublishersTable = true;      // show publisher table

                }).error(function () {
                    vm.showPublishersTable = false;         // if there is error hide table
                });;
            }
        };

        // Gets support data... item - clicked item, id is FK in db
        vm.getSupport = function (item, id) {

            vm.publisher = item;
            vm.showPublishersTable = false;   // hide publishers table

            // Get support info related to publisher
            publisherService.getSupport(id).success(function (data) {
                vm.support = data;
                vm.showSupportInfoTable = true;
            }).error(function () {
                vm.showSupportInfoTable = false;
            })
        };

        // Get publishers - Click on paging numbers or arrows
        vm.setPageNumberTo = function (pageNumber) {

            vm.pageNumber = pageNumber;
            if (vm.pageNumber < 1) {
                vm.pageNumber = 1;
            }

            vm.get();
        };

        // Should redirect to games and get games that belong to publisher
        vm.showGames = function (publisherId) {
            navigationMenuService.setMenuToActive(1);
            $location.path('/game/' + publisherId);
        };

        vm.next = function () {

            vm.pageNumber++;

            vm.get();
        };

        vm.back = function () {

            vm.pageNumber--;
            if (vm.pageNumber < 1)
                vm.pageNumber = 1;

            vm.get();
        };

        //#endregion

        //#region To handle on controller load

        vm.get();

        //#endregion

    }
        ]);
})(angular);
