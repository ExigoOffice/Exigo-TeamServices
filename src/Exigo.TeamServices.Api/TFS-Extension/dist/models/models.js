define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Project = (function () {
        function Project() {
        }
        return Project;
    }());
    exports.Project = Project;
    var ProjectDetail = (function () {
        function ProjectDetail() {
        }
        return ProjectDetail;
    }());
    exports.ProjectDetail = ProjectDetail;
    var User = (function () {
        function User() {
        }
        return User;
    }());
    exports.User = User;
    var TimeEntry = (function () {
        function TimeEntry() {
        }
        return TimeEntry;
    }());
    exports.TimeEntry = TimeEntry;
    //TODO: Get the rest of the status types
    var ProjectStatusTy;
    (function (ProjectStatusTy) {
        ProjectStatusTy[ProjectStatusTy["NewSubmittion"] = 1] = "NewSubmittion";
    })(ProjectStatusTy = exports.ProjectStatusTy || (exports.ProjectStatusTy = {}));
});
