(function () {
    var MmsWebSite = angular.module('MmsWebSite');

    MmsWebSite.controller('usersController',  ['$rootScope', '$scope', '$location', 'dataService', function ($rootScope, $scope, $location, dataService) {
        $scope.newUser = {
            id: 0,
            username: "",
            password: "",
            name: "",
            isAdmin: false
        }
        $scope.isLoggedIn = function () {
            if (!$rootScope.loggedIn) {
                alert('You are not logged in!');
                $location.url('/login');
            }
        }
        $scope.isLoggedIn();
        $scope.loadUsers = function () {
            $scope.waitUsers = true;
            dataService.list("users", function (data) {
                if (data) {
                    $scope.users = data;
                    $scope.waitUsers = false;
                }
                else {
                    notificationsConfig.error("Error!");
                }
            })
            console.log($rootScope.isAdmin);
            console.log($rootScope.loggedIn);
        };

        $scope.loadUsers();

        $scope.createNewUser = function () {
            if ($scope.newUser)
                dataService.create("users", $scope.newUser, function (data) {
                    if (data) {
                        alert("User created");
                    }
                    else
                        alert("Error");
                })
        }

    }]);
}());
