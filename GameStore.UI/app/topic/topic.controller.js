(function (angular) {

    angular.module("mainModule").controller("TopicController", [
        '$scope', '$routeParams', 'topicService', 'notificationService', '$window', '$location', '$anchorScroll',
            function ($scope, $routeParams, topicService, notificationService, $window, $location, $anchorScroll) {

                var vm = $scope.vm = {};

                //#region Proporties and variables


                var topicId = $routeParams.topicId;
                var pageSize = 15;

                vm.topicTitle = $routeParams.topicTitle;
                vm.pageNumber = 1;
                vm.posts = [];
                vm.showEditPostAnchor = [];
                vm.showAddCommentFormOnPost = [];               // Comment form, only one should be active at time
                vm.postDescription = "";

                vm.comments = [];
                vm.commentDescription = "";

                //#endregion

                //#region Methods

                vm.showAddComment = function (index) {

                    hideAddComments();

                    // Set selected element to true
                    vm.showAddCommentFormOnPost[index] = true;
                    vm.commentDescription = "";
                };

                vm.getComments = function (post, index, pageSize) {

                    topicService.getCommentsByPostId(post.Id, 1, pageSize).success(function (data) {

                        vm.posts[index].comments = data;
                        hideAddComments();

                    }).error(function (data) {
                        notificationService.addLongNotification(data, false);
                    })
                };

                vm.addNewPost = function (description) {

                    var post = {
                        TopicId: topicId,
                        UserName: $window.localStorage.user,
                        UserId: $window.localStorage.id,
                        Description: description
                    };

                    // If user is not logged in 
                    if ($window.localStorage.id === null || $window.localStorage.id === "") {
                        notificationService.addNotification("Please log in.", false);
                        return;
                    }

                    // Request
                    topicService.addNewPost(post).success(function (data) {

                        // Add notification, clear description and get posts
                        notificationService.addNotification("Post added.", true);
                        vm.postDescription = "";
                        getPosts();
                    }).error(function (data) {
                        notificationService.addNotification("Error while adding post.", false);
                    });
                };

                vm.addNewComment = function (description, post, index) {

                    var comment = {
                        Description: description,
                        PostId: post.Id,
                        UserName: $window.localStorage.user,
                        UserId: $window.localStorage.id
                    };

                    // If user is not logged in 
                    if ($window.localStorage.id === null || $window.localStorage.id === "") {
                        notificationService.addNotification("Please log in.", false);
                        return;
                    };

                    // Request
                    topicService.addNewComment(comment).success(function (data) {

                        // Add notification, clear description and get posts
                        notificationService.addNotification("Comment added.", true);
                        vm.commentDescription = "";

                        vm.getComments(post, index, 5);
                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                    });

                }

                // Scroll to add new post
                vm.goToAddNewPost = function () {

                    $anchorScroll($location.hash('add-post-id'));
                }

                //#endregion

                //#region Private methods

                // Gets posts
                function getPosts() {

                    topicService.getPostsByTopicId(topicId, vm.pageNumber, pageSize).success(function (data) {
                        vm.posts = data;

                        // Check if vm.posts is of type array
                        if (vm.posts !== undefined && vm.posts.length) {

                            // Fill add comments array
                            for (var i = 0; i < vm.posts.length; i++) {

                                // Fill array , but don't show any add comments forms
                                vm.showAddCommentFormOnPost.push(false);

                                // Fill show edit post anchor array. If user is logged in push true, in order to show edit for that user
                                if ($window.localStorage.user === vm.posts[i].UserName && $window.localStorage.id === vm.posts[i].UserId)
                                    vm.showEditPostAnchor.push(true);
                                else
                                    vm.showEditPostAnchor.push(false);

                            }
                        }

                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                    });
                };

                // Hide add comments 
                function hideAddComments() {

                    // Set each element in array to false
                    for (var i = 0; i < vm.showAddCommentFormOnPost.length; i++) {
                        vm.showAddCommentFormOnPost[i] = false;
                    }
                };

                //#endregion

                //#region To handle on controller creation

                getPosts();

                //#endregion

            }
    ]);

})(angular);