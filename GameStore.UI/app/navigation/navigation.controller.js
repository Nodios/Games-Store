
(function (angular) {


    angular.module("mainModule").controller("NavigationController", ['$scope', '$window', '$controller', 
    function ($scope, $window, $controller) {



        var modalRegisterController = $scope.$new();

        $controller('ModalRegisterController', { $scope: modalRegisterController });

        // GLOBALS  
        $window.sessionStorage.user = "";
        $window.sessionStorage.id = "";
        $window.sessionStorage.token = "";

        var vm = this;
        vm.userLogged = false;

        // Proporties
        vm.menus =
            [
                { name: "Home", link: "#/", active: "active" },          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
                { name: "Games", link: "#/game", active: "" },
                { name: "Publisher", link: "#/publisher", active: "" },
                { name: "About", active: "" }
            ];

        vm.authRegister = { name: "Register", link: "#/register" };

        // If button is pressed set it's class to active - used just for effect 
        vm.setActive = function (index) {
            clearActive();
            vm.menus[index].active = "active";
        };

        // Opens register modal
        vm.registerClick = function () {
            modalRegisterController.open();
        };


        // Private 
        // Sets active in menus to empty
        var clearActive = function () {

            for (var i = 0; i < vm.menus.length; i++) {
                vm.menus[i].active = "";
            }
        };

        // Sets up log in menu item to user name if there is user signed in , else just says log in
        if ($window.sessionStorage.user.length <= 0) {
            vm.authUser = { name: "Log in", link: "#/login " };
        }
        else {
            vm.authUser = { name: "Welcome " + $window.sessionStorage.user, link: "#/login" };
        }

    }
    ])
})(angular);

