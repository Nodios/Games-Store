﻿
(function (angular) {


    angular.module("mainModule").controller("NavigationController", [
    function () {

        var vm = this;

        // Proporties
        vm.menus =
            [
                { name: "Home", link: "#/", active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: "#/game", active: "" },
                { name: "Publisher", link: "#/publisher", active: "" },
                { name: "About", active: "" }
            ];

        vm.auth =
            [  
                { name: "Register", link: "#/register" },
                { name: globalUser, link: "#/login" },
            ];

        // If button is pressed set it's class to active - used just for effect 
        vm.setActive = function (index) {
            vm.clearActive();
            vm.menus[index].active = "active";
        };

        vm.clearActive = function () {
            for (var i = 0; i < vm.menus.length; i++) {
                vm.menus[i].active = "";
            }
        };
    }
    ])})(angular);

