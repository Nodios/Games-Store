
(function (angular) {
    angular.module("mainModule").controller("PublisherController", ['getFactory',
    function (getFactory) {

        var vm = this;

        vm.publishers = [];
        vm.support = null;
        vm.searchString = "";
        vm.showPublishersTable = false;        // tables are hidden by default
        vm.showSupportInfoTable = false;        // tables are hidden by default
        vm.pageNumber = 1;
        var pageSize = 10;

        // Get Publishers
        vm.get = function () {

            vm.showPublishersTable = true;      // show publisher table
            vm.showSupportInfoTable = false;    // hide support table

            // If there is search string get by search string, else get all
            if (vm.searchString.length > 0) {
                getFactory.getPublisher(vm.searchString).success(function (data) {
                    vm.publishers = [];
                    vm.publishers.push(data);
                }).error(function () {
                    vm.showPublishersTable = false;       // if there is error hide table
                });
            }
            else {
                // Pass page number and page size 
                getFactory.getPublishers(vm.pageNumber, pageSize).success(function (data) {
                    vm.publishers = data;
                }).error(function () {
                    vm.showPublishersTable = false;         // if there is error hide table
                });;
            }
        };

        // Gets support data... item - clicked item, id is FK in db
        vm.getSupport = function (item, id) {
            // Empty array and add item to it
            vm.publishers = [];
            vm.publishers.push(item);
            vm.showPublishersTable = false;   // hide publishers table
            vm.showSupportInfoTable = true;   // show support table

            // Get support info related to publisher
            getFactory.getSupport(id).success(function (data) {
                vm.support = data;
                vm.showSupportInfoTable = true;
            }).error(function () {
                vm.showSupportInfoTable = false;
            })
        };

    }
    ])
})(angular);
