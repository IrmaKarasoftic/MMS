(function () {
    var MmsWebSite = angular.module('MmsWebSite');

    MmsWebSite.controller('imagesController', function ($scope, dataService) {
        $scope.newImage = {
            id: 0,
            description: "",
            location: ""
        }

        $scope.imageToCompress = {
            id: 0,
            description: "",
            location: ""
        }

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

        $scope.createNewImage = function () {
            $scope.newImage.location = document.getElementById("browsedImage").files[0].name;
            if ($scope.newImage)
                dataService.create("images", $scope.newImage, function (data) {
                    if (data) {
                        alert("Image added");
                    }
                    else
                        alert("Error");
                })
        }
        $scope.setImageToCompress = function(image)
        {
            $scope.imageToCompress = image;
        }

        $scope.compress = function (image) {
            //kompresovanje
        }
    });
}());
