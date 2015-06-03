
app.controller("NavigationController", function () {

    // Proporties
    this.menus =
        [
            { name: "Home", link:"#/", active:"active"},
            { name: "Games", active:"" },
            { name: "Publisher", link:"#/publisher", active:"" },
            { name: "About", active:"" }
        ];


    // TODO: Premjesti u servis ili komletno obrisi
    this.setActive = function (index) {
        for (var i = 0; i < this.menus.length; i++) {
            this.menus[i].active = "";
        }

        this.menus[index].active = "active";
    };


});