﻿
(function (angular) {


    angular.module("mainModule").controller("NavigationController", ['$scope', '$window', '$controller', '$location',
    function ($scope, $window, $controller, $location) {

        // Nav controller is first loaded controller and is alive all time 
        $location.path("#/");  // redirect to home page every time when controller is created 

        var vm = this;

        vm.loggedIn = false;
        vm.loggedOut = true;

        // GLOBALS  
        $window.sessionStorage.user = "Log in";
        $window.sessionStorage.id = "";
        $window.sessionStorage.token = "";

        // Controllers 
        var modalRegisterController = $scope.$new();
        var modalLoginController = $scope.$new();

        $controller('ModalRegisterController', { $scope: modalRegisterController });
        $controller('ModalLoginController', { $scope: modalLoginController });

        // Proporties
        $scope.menus =
            [
                { name: "Home", link: "#/", active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: "#/game", active: "" },
                { name: "Publisher", link: "#/publisher", active: "" },
                { name: "Discussion forum", active: "" }
            ];

        // Right part of menu for unsigned user
        vm.user;
        vm.authRegister = { name: "Register" };
        vm.authUser = { name: "Log in" };

        // Drop down menu items for signed user
        vm.cart = { name: "Cart" , link: "#/cart"};
        vm.account = { name: "Account", link: "#/account" };
        vm.logout = { name: "Logout", link: "#/" };


        // If button is pressed set it's class to active - used just for effect 
        vm.setActive = function (index) {
            clearActive();
            $scope.menus[index].active = "active";
        };

        // Opens register modal
        vm.registerClick = function () {
            modalRegisterController.open();
        };

        // Opens login modal
        vm.loginClick = function () {
            modalLoginController.open();
        };

        // Opens logout model
        vm.logoutClick = function () {
            $window.sessionStorage.user = "Log in";
            $window.sessionStorage.token = "";
            vm.user = "Log in";
            setMenuUser;
        };

        // Private 
        // Sets active in menus to empty
        var clearActive = function () {

            for (var i = 0; i < $scope.menus.length; i++) {
                $scope.menus[i].active = "";
            }
        };

        // Sets menu name if user is signed in
        var setMenuUser = function () {

            // Sets up log in menu item to user name if there is user signed in , else just says log in
            if ($window.sessionStorage.token.length > 0) {
                vm.loggedIn = true;
                vm.loggedOut = false;
                vm.user = $window.sessionStorage.user + " ";
            }
            else {
                vm.loggedIn = false;
                vm.loggedOut = true;
            }
        };

        // Keeps track on $window.sessionStorage.user changes            // ? 
        $scope.$watch(function () {
            return $window.sessionStorage.user;
        }, function (newVal, oldVal) {
            setMenuUser();
        });

      
        // EVENTS 
        // used by child controller to set game link to active
        $scope.$on('setGameLinkToActive', function (event, data) {

            // Clear menu classes and set game menu class to active 
            vm.setActive(1);
        });
    }
    ]);
})(angular);

