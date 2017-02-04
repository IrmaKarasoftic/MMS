(function () {
    var MmsWebSite = angular.module('MmsWebSite', ['ngRoute']);

    MmsWebSite.config(function ($routeProvider) {

        $routeProvider
            .when("/login", {
                templateUrl: "views/login.html",
                controller: "loginController"
            })
            .when("/users", {
                templateUrl: "views/users.html",
                controller: "usersController"
            })
            .when("/images", {
                templateUrl: "views/images.html",
                controller: "imagesController"
            })
            .otherwise({ redirectTo: "/login" });
    })

}());