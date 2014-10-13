var Dependencies = ["ui.bootstrap", "ui.tinymce", "angular-loading-bar", "angularFileUpload"];
var AdminApp = angular.module("AdminApp", Dependencies);
var NewsCtrl = AdminApp.controller("NewsCtrl", function ($scope, $http) {
    $scope.tinymceOptions = {
        resize: false,
        height: 300,
        plugins: 'print textcolor advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor',
        toolbar: "undo redo styleselect  | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons sizeselect | bold italic | fontselect |  fontsizeselect"

    };
    $scope.formatJsonDate = function (dateString) {
        return moment(dateString).fromNow();
    };
    $scope.userid = document.getElementById('UserId').value;
    $http.get("/Admin/AdminNewsBar").success(function (data) {
        $scope.latestNews = data;
    });
    $scope.createNews = function () {
        var News = { Title: $scope.title, News1: $scope.body, UserID: $scope.userid, Caption: $scope.caption };
        $http.post("/Admin/CreateNewsJson", News).success(function () {
            $scope.newsId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminNewsBar").success(function (data) {
                $scope.latestNews = data;
            });
        })
    }
    $scope.getNewsForUpdate = function (id) {
        $http.get("/Admin/AdminNewsForUpdate/" + id).success(function (data) {
            $scope.newsId = data.NewsID;
            $scope.title = data.Title;
            $scope.id = data.NewsID;
            $scope.body = data.News1;
            $scope.caption = data.Caption;
            console.log(data)
        });
    }
    $scope.updateNews = function () {
        var News = { NewsID: $scope.newsId, Title: $scope.title, News1: $scope.body, Caption: $scope.caption };
        $http.post("/Admin/UpdateNews", News).success(function (data) {
            $scope.newsId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminNewsBar").success(function (data) {
                $scope.latestNews = data;
            });
            console.log(data)
        })
    }
    $scope.deleteNews = function (id) {
        $http.post("/Admin/DeleteNews/" + id).success(function (data) {
            $scope.newsId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminNewsBar").success(function (data) {
                $scope.latestNews = data;
            });
            console.log(data)
        })
    }
});

var EventsCtrl = AdminApp.controller("EventsCtrl", function ($scope, $http) {

    $scope.tinymceOptions = {
        resize: false,
        height: 300,
        plugins: 'print textcolor advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor',
        toolbar: "undo redo styleselect  | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons sizeselect | bold italic | fontselect |  fontsizeselect"

    };
    $scope.formatJsonDate = function (dateString) {
        return moment(dateString).fromNow();
    };
    $scope.userid = document.getElementById('UserId').value;
    $http.get("/Admin/AdminEventsBar").success(function (data) {
        $scope.latestEvents = data;
    });
    $scope.createEvent = function () {
        var Event = { Title: $scope.title, Event1: $scope.body, UserID: $scope.userid, Caption: $scope.caption, EventDate: $scope.eventDate };
        $http.post("/Admin/CreateEventJson", Event).success(function () {
            $scope.eventId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminEventsBar").success(function (data) {
                $scope.latestEvents = data;
            });
        })
    }
    $scope.getEventForUpdate = function (id) {
        $http.get("/Admin/AdminEventForUpdate/" + id).success(function (data) {
            $scope.eventId = data.EventID;
            $scope.eventDate = data.Date;
            $scope.title = data.Title;
            $scope.body = data.Event1;
            $scope.caption = data.Caption;
            console.log(data)
        });
    }
    $scope.updateEvent = function () {
        var Event = { EventID: $scope.eventId, Title: $scope.title, Event1: $scope.body, Caption: $scope.caption, EventDate: $scope.eventDate };
        $http.post("/Admin/UpdateEvent", Event).success(function (data) {
            $scope.eventId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminEventsBar").success(function (data) {
                $scope.latestEvents = data;
            });
            console.log(data)
        })
    }
    $scope.deleteEvent = function (id) {
        $http.get("/Admin/DeleteEvent/" + id).success(function (data) {
            $scope.eventId = "";
            $scope.title = "";
            $scope.body = "";
            $scope.caption = "";
            $http.get("/Admin/AdminEventsBar").success(function (data) {
                $scope.latestEvents = data;
            });
            console.log(data)
        })
    }
});

var CourseCtrl = AdminApp.controller("CourseCtrl", function ($scope, $http) {

    $scope.tinymceOptions = {
        resize: false,
        height: 300,
        plugins: 'print textcolor advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor',
        toolbar: "undo redo styleselect  | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons sizeselect | bold italic | fontselect |  fontsizeselect"

    };
    //Faculty
    $http.get("/Admin/AdminFacultyBar").success(function (data) {
        $scope.faculties = data;
    })
    $scope.createFaculty = function () {
        var Faculty = { FacultyName: $scope.facultyName };
        $http.post("/Admin/CreateFaculty", Faculty).success(function (data) {
            $http.get("/Admin/AdminFacultyBar").success(function (data) {
                $scope.faculties = data;
            })
            console.log(data);
        });
    }
    $scope.getFacultyForUpdate = function (id) {
        $http.get("/Admin/AdminFacultyForUpdate/" + id).success(function (data) {
            $scope.facultyId = data.FacultyID
            $scope.facultyName = data.FacultyName;
        });
    }
    $scope.updateFaculty = function () {
        var Faculty = {FacultyID:$scope.facultyId, FacultyName:$scope.facultyName};
        $http.post("/Admin/UpdateFaculty", Faculty).success(function (data) {
            $scope.facultyName = "";
            $scope.facultyId = "";
            $http.get("/Admin/AdminFacultyBar").success(function (data) {
                $scope.faculties = data;
            })
            console.log(data)
        })
    }
    //Department
    $http.get("/Admin/AdminDeptBar").success(function (data) {
        $scope.departments = data;
    })
    $scope.createDept = function () {
        var Dept = { FacultyID: $scope.faculty.FacultyID, DepartmentName: $scope.deptName, Description: $scope.description };
        console.log(Dept);
        $http.post("/Admin/CreateDept", Dept).success(function (data) {
            $http.get("/Admin/AdminDeptBar").success(function (data) {
                $scope.departments = data;
            })
            console.log(data);
        });
    }
    $scope.getDeptForUpdate = function (id) {
        $http.get("/Admin/AdminDeptForUpdate/" + id).success(function (data) {
            $scope.deptId = data.DepartmentID
            $scope.deptName = data.DepartmentName;
            $scope.description = data.Description;
            $scope.faculty = data.FacultyID;
        });
    }
    $scope.updateDept = function () {
        var Dept = {DepartmentID:$scope.deptId, DepartmentName:$scope.deptName, Description:$scope.description, FacultyID:$scope.faculty};
        $http.post("/Admin/UpdateDept", Dept).success(function (data) {
            $scope.deptName = "";
            $scope.deptId = "";
            $scope.faculty= "";
            $http.get("/Admin/AdminDeptBar").success(function (data) {
                $scope.departments = data;
            })
            console.log(data)
        })
    }
})

var ContentsCtrl = AdminApp.controller("ContentsCtrl", function ($scope, $http) {
    $scope.tinymceOptions = {
        resize: false,
        height: 300,
        plugins: 'print textcolor advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor',
        toolbar: "undo redo styleselect  | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons sizeselect | bold italic | fontselect |  fontsizeselect"

    };

    $scope.getContentForUpdate = function (id) {
        $http.get("/Admin/ContentForUpdate/" + id).success(function (data) {
            $scope.content = data.Content1;
            console.log(data)
        });
    }
    $scope.updateContent = function () {
        var Content = { Content1: $scope.content, ContentType: $scope.contentType };
        $http.post("/Admin/UpdateContent", Content).success(function (data) {
            alert("Updated");
            console.log(data);
        });
    }
})

var ProjectsCtrl = AdminApp.controller("ProjectsCtrl", function ($http, $scope, $upload) {

    $scope.tinymceOptions = {

        resize: false,
        height: 200,
        plugins: 'print textcolor advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor codemirror',
        toolbar: "undo redo styleselect  | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | autolink link image | print preview media fullpage | forecolor backcolor emoticons code sizeselect | bold italic | fontselect |  fontsizeselect",
        codemirror: {
            path: '/Scripts/tinymce/plugins/codemirror/CodeMirror',
            indentOnInit: true,
            jsFiles: [
   'mode/clike/clike.js',
   'mode/php/php.js'
            ],
            cssFiles: [
   'theme/neat.css',
   'theme/elegant.css'
            ]
        }, file_browser_callback: RoxyFileBrowser

    };



    $http.get("/Admin/SelectFaculty").success(function (data) {
        $scope.faculties = data;
    })
    $scope.GetDept = function () {
        $http.get("/Admin/SelectDepartment/" + $scope.faculty).success(function (data) {
            $scope.departments = data;
        })
    }
    $scope.onFileSelect = function ($files) {
        var Project = { Title: $scope.title, Author: $scope.author, AuthorRegNo: $scope.regNo, DepartmentID: $scope.dept };
        $http.post("/Admin/UploadProjects", Project);
        for (var i = 0; i < $files.length; i++) {
            var file = $files[i];
            $scope.upload = $upload.upload({
                url: '/Admin/UploadProjects',
                data: { myObj: $scope.myModelObj },
                file: file,
            }).progress(function (evt) {
                $scope.ongoing = evt;
                $scope.progressValue = parseInt(100.0 * evt.loaded / evt.total);
                console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
            }).success(function (data, status, headers, config) {
                // file is uploaded successfully
                console.log(data);
                $scope.uploaded = data;
                
                //Add logistics here
            });
        }

    };
})