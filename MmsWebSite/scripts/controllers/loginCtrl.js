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
        $rootScope.foo = false;
        $scope.loggedIn = false;
        $scope.isAdmin = false;
        $scope.checkLogin = function () {
                dataService.create("login", $scope.login, function (data) {
                    if (data) {
                        if (data.isAdmin) $scope.isAdmin = true;
                        else $scope.isAdmin = false;
                        $scope.loggedIn = true;
                        
                    }
                    else {
                        $scope.loggedIn = false;
                        alert("Login failed");
                    }
                })
            }
    }]);
}());