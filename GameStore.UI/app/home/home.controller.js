(function (angular) {

    angular.module("mainModule").controller("HomeController", ['$scope',
        function ($scope) {


            $scope.myInterval = 5000; 

            $scope.slides = [
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
        }
    ]);

})(angular)