

// Used for setting up navigation menu 
(function (angular) {


    angular.module("mainModule").service("navigationMenuService", ["navigationLinks", function(navigationLinks){

        var menus =
            [
                { name: "Home", link: navigationLinks.home , active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: navigationLinks.game, active: "" },
                { name: "Publisher", link: navigationLinks.publisher , active: "" },
                { name: "Discussion forum", link: navigationLinks.forum, active: "" }
            ];

        return {
            
            // Pass index of item, and set item to active
            setMenuToActive: function (menuItemIndex) {             

                for (var i = 0; i < menus.length; i++) {
                    menus[i].active = "";
                };
                menus[menuItemIndex].active = "active";
            },

            getMenu: function () {
                return menus;
            }


        }
    }]);


})(angular);