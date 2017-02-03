(function () {
    var taskAngular = angular.module('taskAngular');

    taskAngular.controller('usersController', function ($scope, dataService) {

        $scope.loadUsers = function () {
            $scope.waitCustomers = true;
            dataService.get("users", function (data) {
                if (data) {
                    $scope.users = data;
                    $scope.waitCustomers = false;
                }
                else {
                    notificationsConfig.error("Error!");
                }
            })
        };

        $scope.loadUsers();


    });
}());
