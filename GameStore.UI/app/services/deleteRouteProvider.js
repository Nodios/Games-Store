(function(angular){

    angular.module("mainModule").service("deleteRouteProvider", [
    function () {

        var apiGame = "gameStore/api/Game";

        return {
            deleteGame: function () {
                return apiGame + "/delete";
            }
        };
    }]);
})(angular);