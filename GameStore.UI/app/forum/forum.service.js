(function (angular) {

    angular.module("mainModule").service("forumService",
        ['$http', 'routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {

                    getTopics: function (pageNumber, pageSize) {

                        return $http.get(routePrefix.topic + "/" + pageNumber + "/" + pageSize);
                    },

                    getTopicsBySearch: function (search, pageNumber, pageSize) {
                        return $http.get(routePrefix.topic + "/GetByName/" + search + "/" + pageNumber + "/" + pageSize);
                    },

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