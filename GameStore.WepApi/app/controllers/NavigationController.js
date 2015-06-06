
app.controller("NavigationController", function () {

    // Proporties
    this.menus =
        [
            { name: "Home", link:"#/", active:"active"},          // Link goes into ng-href , link it's just bootstrap class used for menu selected effect
            { name: "Games", link:"#/game",  active:"" },
            { name: "Publisher", link:"#/publisher", active:"" },
            { name: "About", active:"" }
        ];


    // If button is pressed set it's class to active - used just for effect 
    this.setActive = function (index) {
        for (var i = 0; i < this.menus.length; i++) {
            this.menus[i].active = "";
        }

        this.menus[index].active = "active";
    };


});