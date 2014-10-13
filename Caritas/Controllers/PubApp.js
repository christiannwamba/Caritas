var PubApp = angular.module("PubApp", ["ui.bootstrap", "angular-loading-bar", "ngSanitize"]);
var PubCtrl = PubApp.controller("PubCtrl", function ($scope, $http, $sce) {
    $http.get("/Publication/Projects").success(function (data) {
        $scope.pubs = data;
    })
});