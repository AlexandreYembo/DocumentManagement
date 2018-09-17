(function () {
    var app = angular.module('DocumentManagementApp', ['ui.router', 'LocalStorageModule']);

    app.run(function ($rootScope, $location, $state) {
        $state.go('index');
    });

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/index');

        $stateProvider
            .state('index', {
                url: '/index',
                templateUrl: 'view/index.html',
                controller: 'UsernameController'
            })
            .state('home', {
                url: '/home',
                templateUrl: 'view/home.html',
                controller: 'HomeController'
            });
    }]);

    app.controller('UsernameController', function ($scope, $rootScope, $stateParams, $state, localStorageService) {
        $scope.formSubmit = function () {

            localStorageService.set('loginData', { username: $scope.username, isAdmin: $scope.isAdmin });
            $state.go('home');
        };

    });

    app.controller('HomeController', function ($scope, $rootScope, $stateParams, $state, DocumentService) {
        DocumentService.getDocuments()
            .then(
            function (result) {
                if (result) {
                    $scope.data = result.data;
                }
            });
    });

    app.factory("DocumentService", function ($http, $state) {
        
        var _getDocuments = function () {
            return $http.get('http://localhost:52352/' + 'api/document');
        };

        return {
            getDocuments: _getDocuments
        };
    });

    app.factory('authInterceptorService', function ($q, $state, localStorageService) {

        var authInterceptorServiceFactory = {};

        var _request = function (config) {

            config.headers = config.headers || {};

            var loginData = localStorageService.get('loginData');
            if (loginData) {
                config.headers.username = loginData.username;
                if (loginData.isAdmin)
                    config.headers.admin = '1';
            }

            return config;
        }

        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                $state.go('index');
            }
        }

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    });

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });
})();