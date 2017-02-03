(function () {
    var taskAngular = angular.module('taskAngular');

    taskAngular.controller('loginController', function ($scope, dataService) {
        $scope.login = {
            id:0,
            username: "",
            password: "",
            name: "",
            isAdmin: false
        }
        $scope.checkLogin = function () {
                dataService.create("login", $scope.login, function (data) {
                    if (data) {
                        alert("ok");
                    }
                    else {
                        alert("error");
                    }
                })
            }
    });
}());