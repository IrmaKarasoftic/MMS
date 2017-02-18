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
        $rootScope.isAdmin = false;
        $rootScope.checkLogin = function () {
                dataService.create("login", $scope.login, function (data) {
                    if (data) {
                        if (data.isAdmin) $rootScope.isAdmin = true;
                        else $rootScope.isAdmin = false;
                        $rootScope.loggedIn = true;
                        
                    }
                    else {
                        $rootScope.loggedIn = false;
                        alert("Login failed");
                    }
                })
                console.log($rootScope.isAdmin);
                console.log($rootScope.loggedIn);
        }

        console.log($rootScope.isAdmin);
        console.log($rootScope.loggedIn);
    }]);

}());