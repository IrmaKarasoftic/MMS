(function(){
    var taskAngular = angular.module('taskAngular', ['ngRoute']);

        taskAngular.config(function ($routeProvider) {

            $routeProvider
                .when("/home", {
                    templateUrl: "views/home.html",
                    controller: "loginController"
                })
                .when("/users", {
                    templateUrl: "views/users.html",
                    controller: "usersController"
                })
                .when("/customers", {
                    templateUrl: "views/images.html",
                    controller: "imagesController"
                })
                .otherwise({ redirectTo: "/home" });
        })
    
}());