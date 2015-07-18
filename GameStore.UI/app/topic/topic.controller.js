(function (angular) {

    angular.module("mainModule").controller("TopicController", [
        '$scope', '$routeParams','topicService','notificationService', '$window',
            function ($scope, $routeParams, topicService, notificationService, $window) {

                var vm = $scope.vm = {};

                //#region Proporties and variables


                var topicId = $routeParams.topicId;
                var pageSize = 15;

                vm.topicTitle = $routeParams.topicTitle;
                vm.pageNumber = 1;
                vm.posts = [];
                vm.postDescription = "";

                //#endregion

                //#region Methods

                vm.addNewPost = function (description) {

                    var post = {
                        TopicId: topicId,
                        UserName: $window.localStorage.user,
                        UserId: $window.localStorage.id,
                        Description: description
                    };

                    // If user is not logged in 
                    if ($window.localStorage.id === null || $window.localStorage.id === "")
                    {
                        notificationService.addNotification("Please log in.", false);
                        return;
                    }

                    // Request
                    topicService.addNewPost(post).success(function(data){
                        notificationService.addNotification("Post added.", true);
                        getPosts();
                    }).error(function(data){
                        notificationService.addNotification("Error while adding post.", false);
                    });
                };

                //#endregion

                //#region Private methods

                // Gets posts
                function getPosts() {

                    topicService.getPostsById(topicId, vm.pageNumber, pageSize).success(function (data) {
                        vm.posts = data;

                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                    });
                };

                //#endregion

                //#region To handle on controller creation

                getPosts();

                //#endregion

            }
    ]);

})(angular);