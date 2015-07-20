(function (angular) {

    angular.module("mainModule").controller("HomeController", ['$scope','homeService', 'notificationService','navigationMenuService',
        function ($scope, homeService, notificationService, navigationMenuService) {

            var vm = $scope.vm = {};

            //#region Variables 

            // TODO 
            vm.myInterval = 5000; 

            vm.slides = [
            {
                image: '../../images/menu1.jpg',
                text: 'Dirt',
                description: 'No, no, no, I kill the bus driver.'
            },
            {
                image: '../../images/menu2.jpg',
                text: 'Fifa',
                description: "I hope you're not a member of the fire brigade."
            },
            {
                image: '../../images/menu3.png',
                text: 'Portal',
                description: "If you're good at something, never do it for free."
            }];

            vm.games = [];

            //#endregion

            //#region Methods

            vm.findGamesClick = function () {
                navigationMenuService.setMenuToActive(1);
            };

            //#endregion

            //#region Private functions

          
            //#endregion

            //#region Do on controller creation

            //#endregion

        }
    ]);

})(angular)