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
                vm.showEditDeletePostButtons = [];              // display only for posts where user is logged in
                vm.showAddCommentFormOnPost = [];               // Comment form, only one should be active at time
                vm.postDescription = "";

                // if false, add post form is shown. Otherwise edit post form is shown. Should be true only when edit post is clicked
                vm.showEditPost = false;         

                vm.comments = [];
                vm.commentDescription = "";

                // Edit variables
                var editPostObject = {};

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
                        notificationService.addLongNotification(data, false);
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

                vm.editPost = function () {

                    // If user is not logged in return 
                    if ($window.localStorage.id === null || $window.localStorage.id === "") {
                        notificationService.addNotification("Please log in.", false);
                        return;
                    }

                    // new post description
                    editPostObject.Description = vm.postDescription;

                    topicService.editPost(editPostObject.Id, editPostObject).success(function (data) {

                        notificationService.addNotification("Post changes saved.", true);
                        vm.closeEditForm();
                        getPosts();
                    }).error(function () {
                        notificationService.addNotification("Error while trying to edit post.", false);
                    });
                };

                vm.deletePost = function (post) {

                    topicService.deletePost(post.Id).success(function () {

                        notificationService.addNotification("Post deleted.", true);
                        getPosts();
                     
                    }).error(function (data) {
                        notificationService.addLongNotification(data, false);
                    });
                };

                // Go to and close
                vm.goToAddNewPost = function () {

                    vm.showEditPost = false;
                    vm.postDescription = "";
                    $anchorScroll( $location.hash('add-post-id'));
                };

                vm.goToEditNewPost = function (post) {

                    vm.showEditPost = true;
                    editPostObject = post;
                    vm.postDescription = editPostObject.Description;
                    $anchorScroll($location.hash('edit-post-id'));
                };

                vm.closeEditForm = function () {
                    vm.showEditPost = false;
                    vm.postDescription = "";
                };

                //#endregion

                //#region Private methods

                function getPosts() {

                    topicService.getPostsByTopicId(topicId, vm.pageNumber, pageSize).success(function (data) {
                        vm.posts = data;

                        // If user is logged in , shows edit and delete actions on post
                        setShowEditAndDeletePostButtons();

                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                    });
                };

                function hideAddComments() {

                    // Set each element in array to false
                    for (var i = 0; i < vm.showAddCommentFormOnPost.length; i++) {
                        vm.showAddCommentFormOnPost[i] = false;
                    }
                };

                // If user is logged in , shows edit and delete actions on post
                function setShowEditAndDeletePostButtons() {

                    // Check if vm.posts is of type array
                    if (vm.posts !== undefined && vm.posts.length) {

                        // Empty array before adding new data
                        vm.showEditDeletePostButtons = [];

                        // Fill add comments array
                        for (var i = 0; i < vm.posts.length; i++) {

                            // Fill array , but don't show any add comments forms
                            vm.showAddCommentFormOnPost = [];
                            vm.showAddCommentFormOnPost.push(false);

                            // Fill show edit post anchor array. If user is logged in push true, in order to show edit for that user
                            if ($window.localStorage.user === vm.posts[i].UserName && $window.localStorage.id === vm.posts[i].UserId)
                                vm.showEditDeletePostButtons.push(true);
                            else
                                vm.showEditDeletePostButtons.push(false);

                        }

                        console.log(vm.showEditDeletePostButtons);
                    }
                }

                //#endregion

                //#region To handle on controller creation

                getPosts();

                //#endregion

            }
    ]);

})(angular);