(function() {
    var app = angular.module('proksi');
    app.factory('UserMessageRepository', ['$http', function ($http) {
        var urlBase = 'https://awesomeapp-alexcalingasanruby-1.c9.io/user_messages';
        var repository = {};
        repository.getItem = function (id) {
            return $http.get(urlBase + '/' + id);
        };
        return repository;
    }]);
})();