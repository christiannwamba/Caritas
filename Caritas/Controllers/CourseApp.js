var CourseApp = angular.module("CourseApp", ["ui.bootstrap", "angular-loading-bar", "ngSanitize"]);
var CourseCtrl = CourseApp.controller("CourseCtrl", function ($scope, $http, $sce) {
    $http.get("/Courses/Faculties").success(function (data) {
        $scope.faculties = data;
    })
    $scope.getDepts = function (id) {
        $http.get("/Courses/Departments/" + id).success(function (data) {
            $scope.depts = data;
        })
    }
    $scope.getDesc = function (id) {
        $http.get("/Courses/Description/" + id).success(function (data) {
            $scope.desc = data.Description;
        })
    }
});