(function (angular) {

    angular.module("mainModule").service("notificationService",
        ['$rootScope', '$timeout',
            function ($rootScope, $timeout) {

                var notification = {
                    cls: "",
                    msg: ""
                };

                function animateOnValueChange() {
                    // fade in 
                    jQuery("#notification").fadeIn(400);

                    // Keep it for 2 sec then fade out
                    $timeout(function () {
                        jQuery("#notification").fadeOut(400);
                    }, 1000, false);
                };

                return {

                    returnNotification: function(){
                        return notification;
                    },

                    addNotification: function (message, success) {

                        // If true add alert success, if false add alert 
                        if (success == true)
                        {
                            notification.cls = "alert alert-success";
                            notification.msg = message;
                            animateOnValueChange();
                        }
                        else if (success == false)
                        {
                            notification.cls = "alert alert-danger";
                            notification.msg = message;
                            animateOnValueChange();
                        };
                    }

                };
            }]);

})(angular);