(function () {
    var MmsWebSite = angular.module('MmsWebSite');
    MmsWebSite.controller('imagesController',  ['$rootScope', '$scope', '$location', 'dataService', function ($rootScope, $scope, $location, dataService)  {
        $scope.newImage = {
            id: 0,
            description: "",
            location: "",
            ratio:0
        }
        $scope.imageToCompress = {
            id:null,
            description: "",
            location: "",
            ratio:0
        }
        $scope.compressedImage = {
            id: null,
            description: "",
            location: "",
            ratio: 0
        }
        $scope.isLoggedIn = function() {
            if (!$rootScope.loggedIn) {
                alert('You are not logged in!');
                $location.url('/login');
            }
        }
        //$scope.isLoggedIn();
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
            console.log($rootScope.isAdmin);
            console.log($rootScope.loggedIn);
        };
        $scope.loadImages();

        $scope.createNewImage = function () {
            $scope.newImage.location = document.getElementById("browsedImage").files[0].name;
            if ($scope.newImage)
                dataService.create("images", $scope.newImage, function (data) {
                    if (data) {
                        $scope.loadImages();
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

        $scope.goBack = function () {
            $scope.compressedImage.location = null;
        }
        $scope.setName = function (image) {
            var name = image.value.substr(0,image.value.length - 5);
            name = name.substr(12,name.length);
            $scope.newImage.description = name;
        }
        $scope.cancelImage = function(image)
        {
            $scope.newImage = {
                id: 0,
                description: "",
                location: ""
            }
        }

        $scope.compress = function (image, ratio) {
            image.ratio = ratio;
            dataService.update("images",image.id, image, function (data) {
                if (data) {
                    $scope.compressedImage = data;
                }
                else {
                    notificationsConfig.error("Error!");
                }
            })
        }
    }]);
}());
