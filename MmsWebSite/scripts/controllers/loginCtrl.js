(function () {
    var MmsWebSite = angular.module('MmsWebSite');

    MmsWebSite.controller('loginController', ['$rootScope', '$scope', '$location', 'dataService', function ($rootScope, $scope, $location, dataService) {
        $scope.login = {
            id:0,
            username: "",
            password: "",
            name: "",
            isAdmin: false
        }
        $rootScope.loggedIn = false;
        $scope.checkLogin = function () {
                dataService.create("login", $scope.login, function (data) {
                    if (data) {
                        if (data.isAdmin) $rootScope.isAdmin = true;
                        else $rootScope.isAdmin = false;
                        $rootScope.loggedIn = true;
                        $location.href = "#/users";
                    }
                    else {
                        $rootScope.loggedIn = false;
                        alert("Login failed");
                    }
                })
            }
    }]);
}());