(function () {
    var taskAngular = angular.module('taskAngular');

    taskAngular.controller('usersController', function ($scope, dataService) {

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


    });
}());
