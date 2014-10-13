var Dependencies = ["angular-loading-bar", "ui.bootstrap", "ui.calendar"];
var HomeApp = angular.module("HomeApp", Dependencies);

var HomeCtrl = HomeApp.controller("HomeCtrl", function ($scope, $http) {
    
    $scope.formatJsonDate = function (dateString) {
        return moment(dateString).fromNow();
    };
    $scope.formatJsonDate2 = function (dateString) {
        return moment(dateString).calendar();
    };
    
    $http.get("/Home/News").success(function (data) {
        $scope.news = data;
    });
    $http.get("/Home/Events").success(function (data) {
        $scope.events = data;
    });
})