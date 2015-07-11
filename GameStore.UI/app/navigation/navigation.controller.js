
(function (angular) {


    angular.module("mainModule").controller("NavigationController",
        ['NAVIGATION_LINKS', '$scope', '$window', '$controller', '$location', 'navigationMenuService',
             function (NAVIGATION_LINKS, $scope, $window, $controller, $location, navigationMenuService) {

                 // Nav controller is first loaded controller and is alive all time 
                 $location.path("#/");  // redirect to home page every time when controller is created 

                 //#region Proporties

                 var vm = $scope.vm = {};

                 vm.loggedIn = false;
                 vm.loggedOut = true;

                 // Controllers 
                 var modalRegisterController = $scope.$new();
                 var modalLoginController = $scope.$new();

                 $controller('ModalRegisterController', { $scope: modalRegisterController });
                 $controller('ModalLoginController', { $scope: modalLoginController });


                 vm.menus = navigationMenuService.getMenu();

                 // Right part of menu for unsigned user , handled without navigatonMenuService
                 vm.user;
                 vm.authRegister = { name: "Register" };
                 vm.authUser = { name: "Log in" };

                 // Drop down menu items for signed user
                 vm.cart = { name: "Cart", link: NAVIGATION_LINKS.CART }
                 vm.account = { name: "Account", link: NAVIGATION_LINKS.ACCOUNT };
                 vm.logout = { name: "Logout", link: NAVIGATION_LINKS.HOME };

                 //#endregion

                 //#region Methods

                 // Set CSS of navigation menu to active
                 vm.setActive = function (index) {
                     navigationMenuService.setMenuToActive(index);
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
                     $window.localStorage.user = "Log in";
                     $window.localStorage.token = "";
                     $window.localStorage.id = "";
                     vm.user = "Log in";
                     var hash = $location.path();
                     console.log(hash);
                 };

                 //#endregion

                 //#region Private methods

                 // Sets menu name if user is signed in
                 var setMenuUser = function () {

                     // Sets up log in menu item to user name if there is user signed in , else just says log in
                     if ($window.localStorage.token.length > 0) {
                         vm.loggedIn = true;
                         vm.loggedOut = false;
                         vm.user = $window.localStorage.user + " ";
                     }
                     else {
                         vm.loggedIn = false;
                         vm.loggedOut = true;
                     }
                 };

                 //#endregion

                 //#region Events and handlers

                 // Keeps track on $window.localStorage.user changes          
                 $scope.$watch(function () {
                     return $window.localStorage.user;
                 }, function (newVal, oldVal) {
                     setMenuUser();
                 });

                 //#endregion

             }]);
})(angular);

