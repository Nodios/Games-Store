(function (angular) {

    angular.module("mainModule").constant("NAVIGATION_LINKS",
        {
            HOME: "#/",
            ACCOUNT: "#/account",
            CART: "#/cart",
            GAME: "#/game",
            FORUM: "#/forum",
            PUBLISHER: "#/publisher"
        });

    angular.module("mainModule").constant("ROUTE_PREFIX",
        {
            CART: "gamestore/api/cart",
            GAME: "gamestore/api/game",
            GAME_IMAGE: "gamestore/api/gameImage",
            PUBLISHER: "gamestore/api/publisher",
            POST: "gamestore/api/post",
            REVIEW: "gamestore/api/review",
            ORDER: "gamestore/api/order",
            USER: "gamestore/api/user",
        });

})(angular);