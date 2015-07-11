(function(angular){

    angular.module("mainModule").service("deleteRouteProvider", [
    function () {

        var apiGame = "gameStore/api/Game";
        var apiReview = "gameStore/api/Review";

        return {
            deleteGame: function () {
                return apiGame + "/delete";
            },

            deleteReview: function () {
                return apiReview + "/delete";
            }
        };
    }]);
})(angular);