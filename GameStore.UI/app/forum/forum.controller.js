(function (angular) {

    angular.module("mainModule").controller("ForumController",
        ['$scope', 'forumService', '$window', 'notificationService', '$location',
            function ($scope, forumService, $window, notificationService, $location) {

                var vm = $scope.vm = {};

                //#region Proporties

                vm.showAddTopic = false;
                vm.searchString = "";
                vm.pageNumber = 1;
                vm.showTable = false;

                var pageSize = 15;

                vm.topicToAdd = {
                    Title: "",
                    UserName: "",
                    UserId: ""
                };
                vm.topics = [];

                //#endregion

                //#region Methods

                // Click on create topic button , that only shows form for new topic
                vm.showAddTopicClick = function () {

                    if ($window.localStorage.id === "" || $window.localStorage.id === null) {

                        notificationService.addNotification("Please log in to add new topic... ", false);
                        return;
                    };

                    vm.showAddTopic = true;
                }

                // Get topics
                vm.get = function () {

                    if (vm.searchString.length > 0) {

                        forumService.getTopicsBySearch(vm.searchString, vm.pageNumber, pageSize).success(function (data) {
                            vm.topics = data;

                            if (vm.topics.length > 0)
                                vm.showTable = true;
                        }).error(function (data) {

                        });
                    }
                    else {

                        forumService.getTopics(vm.pageNumber, pageSize).success(function (data) {
                            vm.topics = data;

                            if (vm.topics.length > 0)
                                vm.showTable = true;
                        }).error(function (data) {

                        });
                    }
                };

                // Add new topic
                vm.addTopic = function () {

                    // Add values to topic proporties
                    vm.topicToAdd.UserName = $window.localStorage.user;
                    vm.topicToAdd.UserId = $window.localStorage.id;

                    forumService.addTopic(vm.topicToAdd).success(function (data) {

                        if (data > 0) {
                            notificationService.addNotification("Topic created", true);
                            vm.showAddTopic = false;
                        }
                        else
                            notificationService.addNotification("Error while creating topic.", false);

                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                    });
                }

                // Navigates to topic page with topic title as parameter
                vm.goToTopic = function (topic) {
                    $location.path('/topic/' + topic.Title + "/" + topic.Id);
                }
                //#endregion

                //#region Do on controller creation

                vm.get();

                //#endregion$

            }
        ]);

})(angular);