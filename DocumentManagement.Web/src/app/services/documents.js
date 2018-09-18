class DocumentService {

  constructor($http) {
    this.$http = $http;
  }

  listDocuments() {
    this.$http({
      method: 'GET',
      url: 'https://localhost:44349/api/Document'
    }).then(response => response.data);
  }

  addDocument(document) {
    this.$http({
      method: 'POST',
      url: 'https://localhost:44349/api/Document',
      headers: {
        'Content-Type': 'application/json'
      },
      data: angular.toJson(document)
    }).then(response => response.data);
  }

  downloadDocument() {
  }

  deleteDocument(id, docs) {
  }
}
