app.controller("NavigationController",function () {

    // Proporties
    this.menus =
        [
            { name: "Home", active:"active"},
            { name: "Games", active:"" },
            { name: "Publisher", active:"" },
            { name: "About", active:"" }
        ];


    // Sets active menu based on click
    this.setActive = function (index) {
        for (var i = 0; i < this.menus.length; i++) {
            this.menus[i].active = "";
        }

        this.menus[index].active = "active";
    };

});