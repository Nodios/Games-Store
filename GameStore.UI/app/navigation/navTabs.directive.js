
(function (angular) {
    angular
        .module("mainModule")
        .directive('navTabs', [function () {

            var directive = {
                restrict: 'E',
                templateUrl: 'app/navigation/navTabs.html',
                scope: {
                    max: "="
                },
                controller: 'NavigationController',
                controllerAs: 'vm',
                bindToController: true
            };

            return directive;
        }
        ])
})(angular);


