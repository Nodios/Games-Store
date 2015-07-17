(function (angular) {

    angular.module("mainModule").service("forumService", 
        ['$http','routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {
                    addForum: function (forum) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.forum,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: forum
                        });
                    }
                }
            }
        ]);

})(angular);