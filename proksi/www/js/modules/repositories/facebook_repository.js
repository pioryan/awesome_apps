(function() {
    var app = angular.module('proksi');
    app.factory('facebookRepository', ['$http', function ($http) {
        var urlBase = 'http://graph.facebook.com/';
        var repository = {};
        repository.getProfile = function (fbId) {
            return $http.get(urlBase + fbId);
        };
        repository.getImage = function (fbId) {
            return urlBase + fbId + '/picture?type=square';
        };
        return repository;
    }]);    
})();