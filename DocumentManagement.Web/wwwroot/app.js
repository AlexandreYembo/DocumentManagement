(function () {
    var app = angular.module('DocumentManagementApp', ['ui.router']);

    app.run(function ($state) {
        $state.go('index');
    });

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/index');

        $stateProvider
            .state('index', {
                url: '/index',
                templateUrl: 'view/index.html',
                controller: 'HomeController'
            });
    }]);

    app.controller('HomeController', function ($scope, DocumentService) {

        $scope.getDocuments = function () {
            const headers = { username: $scope.username };

            DocumentService.getDocuments(headers)
                .then(
                    function (result) {
                        if (result && result.status === 200) {
                            $scope.documents = result.data;
                        }
                    });
        };

        $scope.addDocument = function () {

            if (document.getElementById('file').files.length === 0){
                alert("No files selected");
                return;
            }

            const f = document.getElementById('file').files[0];
            
            const r = new FileReader();
            r.onload = (function (e) {
                var document = {
                    name: f.name,
                    size: f.size,
                    format: f.type,
                    ContentBase64: e.target.result
                };

                const headers = { username: $scope.username, isAdmin: $scope.isAdmin === true ? '1' : null };
                DocumentService.addDocument(document, headers)
                    .then(
                        function (result) {
                            if (result && result.status === 201) {
                                alert("Uploaded");
                            }
                        });
            });
            r.readAsDataURL(f);
        };

        $scope.viewDocument = function (doc) {
            const headers = { username: $scope.username };
            DocumentService.updateAccessDateDocument(doc.id, headers).then(() => DocumentService.downloadDocument(doc.contentBase64, doc.name));
        };

        $scope.deleteDocument = function (id) {
            const headers = { username: $scope.username };
            DocumentService.deleteDocument(id, headers).then(() => $scope.documents = $scope.documents.filter(d => d.id !== id));
        };

    });

    app.factory("DocumentService", function ($http, $state) {
        
        var _getDocuments = function (headers) {
            return $http({
                method: 'GET',
                url: 'https://localhost:44349/api/Document',
                headers: {
                    'username': headers.username,
                    'admin': headers.isAdmin
                }
            });
        };

        var _addDocument = function (document, headers) {
            return $http({
                method: 'POST',
                url: 'https://localhost:44349/api/Document',
                headers: {
                    'Content-Type': 'application/json',
                    username: headers.username,
                    admin: headers.isAdmin
                },
                data: angular.toJson(document)
            });
        };

        var _downloadDocument = function (content, fileName) {
            if (!content) throw new Error('no content found');

            var split1 = content.split(':');
            if (split1.length === 1) throw new Error('could not parse content');

            var split2 = split1[1].split(';');
            if (split2.length === 1) throw new Error('could not parse content');

            var split3 = split2[1].split(',');
            if (split3.length === 1) throw new Error('could not parse content');

            var mime = split2[0];
            if (!mime) throw new Error('no mime type found');

            var base64 = split3[1];
            if (!base64) throw new Error('no base64 data found');

            var a = document.createElement("a");
            document.body.appendChild(a);
            a.style = "display: none";
            a.href = content;
            a.download = fileName;
            a.click();

            return base64;
        };
        
        var _updateAccessDateDocument = function (id, headers) {
            return $http({
                method: 'PATCH',
                url: 'https://localhost:44349/api/Document/' + id,
                headers: {
                    username: headers.username
                }
            });
        };

        var _deleteDocument = function (id, headers) {
            return $http({
                method: 'DELETE',
                url: 'https://localhost:44349/api/Document/' + id,
                headers: {
                    username: headers.username
                }
            });
        };

        return {
            getDocuments: _getDocuments,
            addDocument: _addDocument,
            downloadDocument: _downloadDocument,
            updateAccessDateDocument: _updateAccessDateDocument,
            deleteDocument: _deleteDocument
        };
    });
})();