(function (angular) {

    angular.module("mainModule").service("forumService", 
        ['$http','routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {
                    addTopic: function (topic) {

                        var token = $window.localStorage.token;

                        return $http({
                            method: 'post',
                            url: routePrefix.topic,
                            headers: { 'Authorization': 'Bearer ' + token },
                            data: topic
                        });
                    }
                }
            }
        ]);

})(angular);