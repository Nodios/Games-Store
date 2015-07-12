(function(angular){

    angular.module("mainModule").service("deleteRouteProvider", ['ROUTE_PREFIX',
    function (ROUTE_PREFIX) {

        var apiGame = "gameStore/api/Game";
        var apiReview = "gameStore/api/Review";

        return {
            deleteGame: function () {
                return ROUTE_PREFIX.GAME + "/delete";
            },

            deleteReview: function () {
                return ROUTE_PREFIX.REVIEW + "/delete";
            }
        };
    }]);
})(angular);