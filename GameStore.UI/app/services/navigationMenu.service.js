﻿

// Used for setting up navigation menu 
(function (angular) {


    angular.module("mainModule").service("navigationMenuService", ["cns_navigation_links", function(cns_navigation_links){

        var menus =
            [
                { name: "Home", link: cns_navigation_links.home , active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: cns_navigation_links.game, active: "" },
                { name: "Publisher", link: cns_navigation_links.publisher , active: "" },
                { name: "Discussion forum", link: cns_navigation_links.forum, active: "" }
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