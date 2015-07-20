(function (angular) {

    angular.module("mainModule").controller("TopicController", [
        '$scope', '$routeParams', 'topicService', 'notificationService', '$window', '$location', '$anchorScroll',
            function ($scope, $routeParams, topicService, notificationService, $window, $location, $anchorScroll) {

                var vm = $scope.vm = {};

                //#region Proporties and variables


                var topicId = $routeParams.topicId;
                var pageSize = 5;

                vm.topicTitle = $routeParams.topicTitle;
                vm.pageNumber = 1;
                vm.posts = [];
                vm.showEditDeletePostButtons = [];              // display only for posts where user is logged in

                vm.showAddCommentFormOnPost = [];               // Comment form, only one should be active at time
                vm.showEditCommentFormOnPost = [];              // Edit comment form

                vm.postDescription = "";

                vm.showEditPost = false;
                vm.showAddPost = false;

                vm.paginationNext = true;
                vm.paginationPrevious = false;

                vm.comments = [];
                vm.commentDescription = "";

                // Edit variables
                var editPostObject = {};
                var editCommentObject = {};

                //#endregion

                //#region Methods

                vm.showAddComment = function (postIndex) {

                    hideAddAndEditComments();

                    // Set selected element to true
                    vm.showAddCommentFormOnPost[postIndex] = true;
                    vm.commentDescription = "";
                };

                vm.showEditComment = function (postIndex, comment) {

                    hideAddAndEditComments();                  // hide form
                    editCommentObject = comment;                // edit object
                    vm.commentDescription = comment.Description;
                    vm.showEditCommentFormOnPost[postIndex] = true;        // show edit form where post index is 
                };

                vm.getComments = function (postId, postIndex, pageSize) {

                    topicService.getCommentsByPostId(postId, 1, pageSize).success(function (data) {

                        vm.posts[postIndex].comments = data;

                        // Create array to show or hide edit and delete on comments
                        vm.posts[postIndex].showEditDeleteCommentButtons = [];

                        // Check if comments exists and is array
                        if (vm.posts[postIndex].comments !== undefined && vm.posts[postIndex].comments.length) {

                            // Fill array that shows or hides comment edit and delete options
                            for (var i = 0; i < vm.posts[postIndex].comments.length; i++) {

                                // Fill show edit comment anchor array. If user is logged in push true, in order to show edit for that user
                                if ($window.localStorage.user === vm.posts[postIndex].comments[i].UserName && $window.localStorage.id === vm.posts[postIndex].comments[i].UserId)
                                    vm.posts[postIndex].showEditDeleteCommentButtons.push(true);
                                else
                                    vm.posts[postIndex].showEditDeleteCommentButtons.push(false);
                            }

                        }

                        hideAddAndEditComments();

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

                    vm.showEditPost = false;
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

                        vm.getComments(post.Id, index, 5);
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

                vm.editComment = function (postIndex, pageSize) {

                    // If user is not logged in return 
                    if ($window.localStorage.id === null || $window.localStorage.id === "") {
                        notificationService.addNotification("Please log in.", false);
                        return;
                    };

                    // New comment description 
                    editCommentObject.Description = vm.commentDescription;

                    topicService.editComment(editCommentObject.Id, editCommentObject).success(function (data) {

                        // Add notification and get comments
                        notificationService.addNotification("Post edited", true);
                        vm.getComments(editCommentObject.PostId, postIndex, pageSize);
                    }).error(function (data) {
                        notificationService.addLongNotification(data, false);
                    });
                }

                vm.deletePost = function (post) {

                    topicService.deletePost(post.Id).success(function () {

                        notificationService.addNotification("Post deleted.", true);
                        vm.showEditPost = false;
                        vm.showAddPost = false;
                        getPosts();

                    }).error(function (data) {
                        notificationService.addLongNotification(data, false);
                    });
                };

                vm.deleteComment = function (comment, postIndex, pageSize) {

                    topicService.deleteComment(comment.Id).success(function () {

                        notificationService.addNotification("Comment deleted.", true);

                        // Get comments
                        vm.getComments(comment.PostId, postIndex, pageSize);

                    }).error(function (data) {
                        notificationService.addLongNotification(data, false);
                    });
                }

                // Go to and close
                vm.goToAddNewPost = function () {

                    vm.showAddPost = true;
                    vm.showEditPost = false;
                    vm.postDescription = "";
                    $anchorScroll($location.hash('add-post-id'));
                };

                vm.goToEditNewPost = function (post) {

                    vm.showEditPost = true;
                    vm.showAddPost = false;
                    editPostObject = post;
                    vm.postDescription = editPostObject.Description;
                    $anchorScroll($location.hash('edit-post-id'));
                };

                vm.closeEditForm = function () {
                    vm.showEditPost = false;
                    vm.postDescription = "";
                };

                vm.pageNumberIncrease = function () {
                    vm.pageNumber++;
                    getPosts();
                };

                vm.pageNumberDecrease = function () {
                    vm.pageNumber--;
                    getPosts();
                };

                //#endregion

                //#region Private methods

                function getPosts() {

                    if (vm.pageNumber < 1)
                        vm.pageNumber = 1;

                    topicService.getPostsByTopicId(topicId, vm.pageNumber, pageSize).success(function (data) {
                        vm.posts = data;

                        // If user is logged in , shows edit and delete actions on post
                        setShowEditAndDeletePostButtons();

                        if (vm.posts.length === pageSize)
                            vm.paginationNext = true;
                        else {
                            vm.paginationNext = false;
                        }

                        if (vm.pageNumber > 1)
                            vm.paginationPrevious = true;
                        else {
                            vm.paginationPrevious = false;
                        }


                    }).error(function (data) {
                        notificationService.addNotification(data, false);
                        vm.pageNumber--;
                    });
                };

                // Hides add and edit comment forms
                function hideAddAndEditComments() {

                    // Set each element in array to false
                    for (var i = 0; i < vm.showAddCommentFormOnPost.length; i++) {
                        vm.showAddCommentFormOnPost[i] = false;
                        vm.showEditCommentFormOnPost[i] = false;
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
                    }
                }

                //#endregion

                //#region To handle on controller creation

                getPosts();

                //#endregion

            }
    ]);

})(angular);