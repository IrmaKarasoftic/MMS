(function () {
    var MmsWebSite = angular.module('MmsWebSite');

    MmsWebSite.controller('usersController', function ($scope, dataService) {
        $scope.newUser = {
            id: 0,
            username: "",
            password: "",
            name: "",
            isAdmin: false
        }
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

    });
}());
