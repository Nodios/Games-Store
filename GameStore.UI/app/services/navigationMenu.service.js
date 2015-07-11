

// Used for setting up navigation menu 
(function (angular) {


    angular.module("mainModule").service("navigationMenuService", ["NAVIGATION_LINKS", function(NAVIGATION_LINKS){

        var menus =
            [
                { name: "Home", link: NAVIGATION_LINKS.HOME , active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: NAVIGATION_LINKS.GAME, active: "" },
                { name: "Publisher", link: NAVIGATION_LINKS.PUBLISHER , active: "" },
                { name: "Discussion forum", link: NAVIGATION_LINKS.FORUM, active: "" }
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