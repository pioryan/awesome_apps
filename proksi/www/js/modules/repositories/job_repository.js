(function() {
	var app = angular.module('proksi');
	app.factory('JobRepository', ['$http', function ($http) {
        var urlBase = 'https://awesomeapp-alexcalingasanruby-1.c9.io/jobs';
        var repository = {};
        repository.getItems = function () {
            return $http.get(urlBase);
        };
        repository.getItem = function (id) {
            return $http.get(urlBase + '/' + id);
        };
        repository.insertItem = function (item) {
            return $http.post(urlBase, item);
        };
        repository.updateItem = function (item) {
            return $http.post(urlBase + '/' + item.Id, item);
        };
        repository.deleteItem = function (id) {
            return $http.delete(urlBase + '/' + id);
        };
        return repository;
    }]);
})();