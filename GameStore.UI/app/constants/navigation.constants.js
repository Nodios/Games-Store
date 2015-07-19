(function (angular) {

    angular.module("mainModule").constant("navigationLinks",
        {
            home: "#/",
            account: "#/account",
            cart: "#/cart",
            game: "#/game",
            forum: "#/forum",
            order: "#/order",
            publisher: "#/publisher"
        });

    angular.module("mainModule").constant("routePrefix",
        {
            cart: "gamestore/api/cart",
            comment: "gamestore/api/comment",
            topic: "gamestore/api/topic",
            game: "gamestore/api/game",
            game_image: "gamestore/api/gameImage",
            publisher: "gamestore/api/publisher",
            post: "gamestore/api/post",
            review: "gamestore/api/review",
            order: "gamestore/api/order",
            user: "gamestore/api/user",
        });

})(angular);