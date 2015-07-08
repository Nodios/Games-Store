
(function (angular) {
    angular.module("mainModule").controller("PublisherController",
        ['$location', 'publisherService',
    function ($location, publisherService) {

        var vm = this;

        vm.publishers = [];
        vm.publisher = null;
        vm.support = null;
        vm.searchString = "";
        vm.showPublishersTable = false;        // tables are hidden by default
        vm.showSupportInfoTable = false;        // tables are hidden by default
        vm.pageNumber = 1;
        var pageSize = 5;

        // Get Publishers
        vm.get = function () {

            vm.showPublishersTable = true;      // show publisher table
            vm.showSupportInfoTable = false;    // hide support table

            // If there is search string get by search string, else get all
            if (vm.searchString.length > 0) {
                publisherService.getPublishersByName(vm.searchString).success(function (data) {
                    vm.publishers = data;
                }).error(function () {
                    vm.showPublishersTable = false;       // if there is error hide table
                });
            }
            else {
                // Pass page number and page size 
                publisherService.getPublishers(vm.pageNumber, pageSize).success(function (data) {
                    vm.publishers = data;
                }).error(function () {
                    vm.showPublishersTable = false;         // if there is error hide table
                });;
            }
        };

        // Gets support data... item - clicked item, id is FK in db
        vm.getSupport = function (item, id) {

            vm.publisher = item;
            vm.showPublishersTable = false;   // hide publishers table
            vm.showSupportInfoTable = true;   // show support table

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
            $location.path('/game/' + publisherId);
        };

        vm.next = function () {

            vm.pageNumber++;

            publisherService.getPublishers(vm.pageNumber, pageSize).success(function (data) {

                vm.publishers = data;

                if (data.length == 0)
                    vm.pageNumber--;
            })
        };

        vm.previous = function () {

            vm.pageNumber--;
            if (vm.pageNumber < 1)
                vm.pageNumber = 1;

            publisherService.getPublishers(vm.pageNumber, pageSize).success(function (data) {
                vm.publishers = data;
            })
        };
    }
        ]);
})(angular);
