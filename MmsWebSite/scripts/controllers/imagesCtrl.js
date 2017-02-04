(function () {
    var MmsWebSite = angular.module('MmsWebSite');

    MmsWebSite.controller('imagesController', function ($scope, dataService) {

        $scope.loadImages = function () {
            $scope.waitImages = true;
            dataService.list("images", function (data) {
                if (data) {
                    $scope.images = data;
                    $scope.waitImages = false;
                }
                else {
                    notificationsConfig.error("Error!");
                }
            })
        };

        $scope.loadImages();


    });
}());
