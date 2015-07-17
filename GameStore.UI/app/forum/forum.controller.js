(function (angular) {

    angular.module("mainModule").controller("ForumController",
        ['$scope', 'forumService', '$window', 'notificationService',
            function ($scope, forumService, $window, notificationService) {

                var vm = $scope.vm = {};

                //#region Proporties

                vm.showAddTopic = false;
                vm.topicToAdd = {
                    Title: "",
                    UserName: "",
                    UserId: ""
                };

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

                //#endregion

            }
        ]);

})(angular);